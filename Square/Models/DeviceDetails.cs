
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
        /// The Square-issued ID of the device.
        /// </summary>
        [JsonProperty("device_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceId { get; }

        /// <summary>
        /// The Square-issued installation ID for the device.
        /// </summary>
        [JsonProperty("device_installation_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceInstallationId { get; }

        /// <summary>
        /// The name of the device set by the seller.
        /// </summary>
        [JsonProperty("device_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceName { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DeviceDetails : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"DeviceId = {(DeviceId == null ? "null" : DeviceId == string.Empty ? "" : DeviceId)}");
            toStringOutput.Add($"DeviceInstallationId = {(DeviceInstallationId == null ? "null" : DeviceInstallationId == string.Empty ? "" : DeviceInstallationId)}");
            toStringOutput.Add($"DeviceName = {(DeviceName == null ? "null" : DeviceName == string.Empty ? "" : DeviceName)}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is DeviceDetails other &&
                ((DeviceId == null && other.DeviceId == null) || (DeviceId?.Equals(other.DeviceId) == true)) &&
                ((DeviceInstallationId == null && other.DeviceInstallationId == null) || (DeviceInstallationId?.Equals(other.DeviceInstallationId) == true)) &&
                ((DeviceName == null && other.DeviceName == null) || (DeviceName?.Equals(other.DeviceName) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -363727408;

            if (DeviceId != null)
            {
               hashCode += DeviceId.GetHashCode();
            }

            if (DeviceInstallationId != null)
            {
               hashCode += DeviceInstallationId.GetHashCode();
            }

            if (DeviceName != null)
            {
               hashCode += DeviceName.GetHashCode();
            }

            return hashCode;
        }

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