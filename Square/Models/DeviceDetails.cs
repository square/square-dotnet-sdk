using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class DeviceDetails 
    {
        public DeviceDetails(string deviceId = null,
            string deviceName = null)
        {
            DeviceId = deviceId;
            DeviceName = deviceName;
        }

        /// <summary>
        /// Square-issued ID of the device.
        /// </summary>
        [JsonProperty("device_id")]
        public string DeviceId { get; }

        /// <summary>
        /// The name of the device set by the merchant.
        /// </summary>
        [JsonProperty("device_name")]
        public string DeviceName { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .DeviceId(DeviceId)
                .DeviceName(DeviceName);
            return builder;
        }

        public class Builder
        {
            private string deviceId;
            private string deviceName;

            public Builder() { }
            public Builder DeviceId(string value)
            {
                deviceId = value;
                return this;
            }

            public Builder DeviceName(string value)
            {
                deviceName = value;
                return this;
            }

            public DeviceDetails Build()
            {
                return new DeviceDetails(deviceId,
                    deviceName);
            }
        }
    }
}