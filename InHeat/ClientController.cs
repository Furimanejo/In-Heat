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

        public async Task UpdateValue(float value)
        {
            // clamp
            value = value > 0 ? value : 0;
            value = value < 1 ? value : 1;
            // send
            foreach (var device in client.Devices)
            {
                if (device.Name.Contains("Gamepad"))
                    await device.SendStopDeviceCmd();
                if(device.AllowedMessages.ContainsKey(ServerMessage.Types.MessageAttributeType.VibrateCmd))
                    await device.SendVibrateCmd(value);
            }
        }
    }
}
