using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buttplug;

namespace InHeat
{
    class ClientController
    {
        ButtplugWebsocketConnectorOptions connector;
        ButtplugClient client;
        public bool isConnected { get { return client.Connected; } }

        double linearPosition = 0;
        int linearDirectionMultiplier = 1;
        public float minBPM;
        public float maxBPM;

        public ClientController()
        {
            Console.WriteLine("Initializing Client Controller");
            connector = new ButtplugWebsocketConnectorOptions(new Uri("ws://localhost:12345/buttplug"));
            client = new ButtplugClient("In Heat");
            //client.DeviceAdded += OnDeviceAdded;
            ButtplugFFILog.LogMessage += (obj, msg) => Console.WriteLine(msg);
            ButtplugFFILog.SetLogOptions(ButtplugLogLevel.Debug, false);
        }

        public async Task ConnectAsync()
        {
            if (client.Connected)
                return;
            try
            {
                await client.ConnectAsync(connector);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Can't connect to Buttplug Server, exiting!" +
                    $"Message: {ex.InnerException.Message}");
                return;
            }
            await client.StartScanningAsync();
        }

        public async Task UpdateValue(float value, uint deltaMiliseconds)
        {
            // clamp value
            value = value > 0f ? value : 0f;
            value = value < 1f ? value : 1f;

            // linear oscillation
            float linearOScillationFrequency = (minBPM + value * (maxBPM- minBPM))/60f;

            uint duration;
            try
            {
                duration = Convert.ToUInt32((1000 / 2) / linearOScillationFrequency);
            }
            catch 
            {
                duration = uint.MaxValue;
            }

            linearPosition += linearDirectionMultiplier * linearOScillationFrequency * deltaMiliseconds / 1000;
            bool sendLinearCmd = false;
            if (linearPosition > 1)
            {
                linearPosition = 1;
                sendLinearCmd = true;
                linearDirectionMultiplier = -1;
            }
            else if (linearPosition < 0)
            {
                linearPosition = 0;
                sendLinearCmd = true;
                linearDirectionMultiplier = 1;
            }

            // send
            foreach (var device in client.Devices)
            {
                if (device.Name.Contains("Gamepad")) 
                    await device.SendStopDeviceCmd(); //avoid some bugs with gamepads

                if (device.AllowedMessages.ContainsKey(ServerMessage.Types.MessageAttributeType.VibrateCmd))
                    await device.SendVibrateCmd(value);

                if (sendLinearCmd && device.AllowedMessages.ContainsKey(ServerMessage.Types.MessageAttributeType.LinearCmd))
                        await device.SendLinearCmd(duration, linearPosition);
            }
        }
    }
}
