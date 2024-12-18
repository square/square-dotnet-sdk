using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// DeviceDetails.
    /// </summary>
    public class DeviceDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceDetails"/> class.
        /// </summary>
        /// <param name="deviceId">device_id.</param>
        /// <param name="deviceInstallationId">device_installation_id.</param>
        /// <param name="deviceName">device_name.</param>
        public DeviceDetails(
            string deviceId = null,
            string deviceInstallationId = null,
            string deviceName = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "device_id", false },
                { "device_installation_id", false },
                { "device_name", false }
            };

            if (deviceId != null)
            {
                shouldSerialize["device_id"] = true;
                this.DeviceId = deviceId;
            }

            if (deviceInstallationId != null)
            {
                shouldSerialize["device_installation_id"] = true;
                this.DeviceInstallationId = deviceInstallationId;
            }

            if (deviceName != null)
            {
                shouldSerialize["device_name"] = true;
                this.DeviceName = deviceName;
            }
        }

        internal DeviceDetails(
            Dictionary<string, bool> shouldSerialize,
            string deviceId = null,
            string deviceInstallationId = null,
            string deviceName = null)
        {
            this.shouldSerialize = shouldSerialize;
            DeviceId = deviceId;
            DeviceInstallationId = deviceInstallationId;
            DeviceName = deviceName;
        }

        /// <summary>
        /// The Square-issued ID of the device.
        /// </summary>
        [JsonProperty("device_id")]
        public string DeviceId { get; }

        /// <summary>
        /// The Square-issued installation ID for the device.
        /// </summary>
        [JsonProperty("device_installation_id")]
        public string DeviceInstallationId { get; }

        /// <summary>
        /// The name of the device set by the seller.
        /// </summary>
        [JsonProperty("device_name")]
        public string DeviceName { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"DeviceDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDeviceId()
        {
            return this.shouldSerialize["device_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDeviceInstallationId()
        {
            return this.shouldSerialize["device_installation_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDeviceName()
        {
            return this.shouldSerialize["device_name"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is DeviceDetails other &&
                (this.DeviceId == null && other.DeviceId == null ||
                 this.DeviceId?.Equals(other.DeviceId) == true) &&
                (this.DeviceInstallationId == null && other.DeviceInstallationId == null ||
                 this.DeviceInstallationId?.Equals(other.DeviceInstallationId) == true) &&
                (this.DeviceName == null && other.DeviceName == null ||
                 this.DeviceName?.Equals(other.DeviceName) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -363727408;
            hashCode = HashCode.Combine(hashCode, this.DeviceId, this.DeviceInstallationId, this.DeviceName);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DeviceId = {this.DeviceId ?? "null"}");
            toStringOutput.Add($"this.DeviceInstallationId = {this.DeviceInstallationId ?? "null"}");
            toStringOutput.Add($"this.DeviceName = {this.DeviceName ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .DeviceId(this.DeviceId)
                .DeviceInstallationId(this.DeviceInstallationId)
                .DeviceName(this.DeviceName);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "device_id", false },
                { "device_installation_id", false },
                { "device_name", false },
            };

            private string deviceId;
            private string deviceInstallationId;
            private string deviceName;

             /// <summary>
             /// DeviceId.
             /// </summary>
             /// <param name="deviceId"> deviceId. </param>
             /// <returns> Builder. </returns>
            public Builder DeviceId(string deviceId)
            {
                shouldSerialize["device_id"] = true;
                this.deviceId = deviceId;
                return this;
            }

             /// <summary>
             /// DeviceInstallationId.
             /// </summary>
             /// <param name="deviceInstallationId"> deviceInstallationId. </param>
             /// <returns> Builder. </returns>
            public Builder DeviceInstallationId(string deviceInstallationId)
            {
                shouldSerialize["device_installation_id"] = true;
                this.deviceInstallationId = deviceInstallationId;
                return this;
            }

             /// <summary>
             /// DeviceName.
             /// </summary>
             /// <param name="deviceName"> deviceName. </param>
             /// <returns> Builder. </returns>
            public Builder DeviceName(string deviceName)
            {
                shouldSerialize["device_name"] = true;
                this.deviceName = deviceName;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetDeviceId()
            {
                this.shouldSerialize["device_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetDeviceInstallationId()
            {
                this.shouldSerialize["device_installation_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetDeviceName()
            {
                this.shouldSerialize["device_name"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DeviceDetails. </returns>
            public DeviceDetails Build()
            {
                return new DeviceDetails(
                    shouldSerialize,
                    this.deviceId,
                    this.deviceInstallationId,
                    this.deviceName);
            }
        }
    }
}