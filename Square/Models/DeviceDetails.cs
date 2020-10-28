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
            string deviceInstallationId = null,
            string deviceName = null)
        {
            DeviceId = deviceId;
            DeviceInstallationId = deviceInstallationId;
            DeviceName = deviceName;
        }

        /// <summary>
        /// Square-issued ID of the device.
        /// </summary>
        [JsonProperty("device_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceId { get; }

        /// <summary>
        /// Square-issued installation ID for the device.
        /// </summary>
        [JsonProperty("device_installation_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceInstallationId { get; }

        /// <summary>
        /// The name of the device set by the merchant.
        /// </summary>
        [JsonProperty("device_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceName { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .DeviceId(DeviceId)
                .DeviceInstallationId(DeviceInstallationId)
                .DeviceName(DeviceName);
            return builder;
        }

        public class Builder
        {
            private string deviceId;
            private string deviceInstallationId;
            private string deviceName;



            public Builder DeviceId(string deviceId)
            {
                this.deviceId = deviceId;
                return this;
            }

            public Builder DeviceInstallationId(string deviceInstallationId)
            {
                this.deviceInstallationId = deviceInstallationId;
                return this;
            }

            public Builder DeviceName(string deviceName)
            {
                this.deviceName = deviceName;
                return this;
            }

            public DeviceDetails Build()
            {
                return new DeviceDetails(deviceId,
                    deviceInstallationId,
                    deviceName);
            }
        }
    }
}