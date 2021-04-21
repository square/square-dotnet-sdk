namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// DeviceDetails.
    /// </summary>
    public class DeviceDetails
    {
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
            this.DeviceId = deviceId;
            this.DeviceInstallationId = deviceInstallationId;
            this.DeviceName = deviceName;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DeviceDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
                ((this.DeviceId == null && other.DeviceId == null) || (this.DeviceId?.Equals(other.DeviceId) == true)) &&
                ((this.DeviceInstallationId == null && other.DeviceInstallationId == null) || (this.DeviceInstallationId?.Equals(other.DeviceInstallationId) == true)) &&
                ((this.DeviceName == null && other.DeviceName == null) || (this.DeviceName?.Equals(other.DeviceName) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -363727408;

            if (this.DeviceId != null)
            {
               hashCode += this.DeviceId.GetHashCode();
            }

            if (this.DeviceInstallationId != null)
            {
               hashCode += this.DeviceInstallationId.GetHashCode();
            }

            if (this.DeviceName != null)
            {
               hashCode += this.DeviceName.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DeviceId = {(this.DeviceId == null ? "null" : this.DeviceId == string.Empty ? "" : this.DeviceId)}");
            toStringOutput.Add($"this.DeviceInstallationId = {(this.DeviceInstallationId == null ? "null" : this.DeviceInstallationId == string.Empty ? "" : this.DeviceInstallationId)}");
            toStringOutput.Add($"this.DeviceName = {(this.DeviceName == null ? "null" : this.DeviceName == string.Empty ? "" : this.DeviceName)}");
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
                this.deviceName = deviceName;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DeviceDetails. </returns>
            public DeviceDetails Build()
            {
                return new DeviceDetails(
                    this.deviceId,
                    this.deviceInstallationId,
                    this.deviceName);
            }
        }
    }
}