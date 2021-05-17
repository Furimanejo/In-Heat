﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buttplug;

namespace OBI
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
            client = new ButtplugClient("OBI");
            client.DeviceAdded += OnDeviceAdded;
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

        static void OnDeviceAdded(object sender, DeviceAddedEventArgs args)
        {
            //Console.WriteLine($"Device ${args.Device.Name} connected");
        }

        public async Task UpdateValue(float value)
        {
            foreach(var device in client.Devices)
            {
                await device.SendVibrateCmd(value);
                Console.WriteLine($"sending cmd { value} to {device.Name}");
            }
        }
    }
}