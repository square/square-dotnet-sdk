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
    /// DeviceComponentDetailsApplicationDetails.
    /// </summary>
    public class DeviceComponentDetailsApplicationDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceComponentDetailsApplicationDetails"/> class.
        /// </summary>
        /// <param name="applicationType">application_type.</param>
        /// <param name="version">version.</param>
        /// <param name="sessionLocation">session_location.</param>
        /// <param name="deviceCodeId">device_code_id.</param>
        public DeviceComponentDetailsApplicationDetails(
            string applicationType = null,
            string version = null,
            string sessionLocation = null,
            string deviceCodeId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "session_location", false },
                { "device_code_id", false }
            };
            this.ApplicationType = applicationType;
            this.Version = version;

            if (sessionLocation != null)
            {
                shouldSerialize["session_location"] = true;
                this.SessionLocation = sessionLocation;
            }

            if (deviceCodeId != null)
            {
                shouldSerialize["device_code_id"] = true;
                this.DeviceCodeId = deviceCodeId;
            }
        }

        internal DeviceComponentDetailsApplicationDetails(
            Dictionary<string, bool> shouldSerialize,
            string applicationType = null,
            string version = null,
            string sessionLocation = null,
            string deviceCodeId = null)
        {
            this.shouldSerialize = shouldSerialize;
            ApplicationType = applicationType;
            Version = version;
            SessionLocation = sessionLocation;
            DeviceCodeId = deviceCodeId;
        }

        /// <summary>
        /// Gets or sets ApplicationType.
        /// </summary>
        [JsonProperty("application_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ApplicationType { get; }

        /// <summary>
        /// The version of the application.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; }

        /// <summary>
        /// The location_id of the session for the application.
        /// </summary>
        [JsonProperty("session_location")]
        public string SessionLocation { get; }

        /// <summary>
        /// The id of the device code that was used to log in to the device.
        /// </summary>
        [JsonProperty("device_code_id")]
        public string DeviceCodeId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"DeviceComponentDetailsApplicationDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSessionLocation()
        {
            return this.shouldSerialize["session_location"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDeviceCodeId()
        {
            return this.shouldSerialize["device_code_id"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is DeviceComponentDetailsApplicationDetails other &&
                (this.ApplicationType == null && other.ApplicationType == null ||
                 this.ApplicationType?.Equals(other.ApplicationType) == true) &&
                (this.Version == null && other.Version == null ||
                 this.Version?.Equals(other.Version) == true) &&
                (this.SessionLocation == null && other.SessionLocation == null ||
                 this.SessionLocation?.Equals(other.SessionLocation) == true) &&
                (this.DeviceCodeId == null && other.DeviceCodeId == null ||
                 this.DeviceCodeId?.Equals(other.DeviceCodeId) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1410667962;
            hashCode = HashCode.Combine(hashCode, this.ApplicationType, this.Version, this.SessionLocation, this.DeviceCodeId);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ApplicationType = {(this.ApplicationType == null ? "null" : this.ApplicationType.ToString())}");
            toStringOutput.Add($"this.Version = {this.Version ?? "null"}");
            toStringOutput.Add($"this.SessionLocation = {this.SessionLocation ?? "null"}");
            toStringOutput.Add($"this.DeviceCodeId = {this.DeviceCodeId ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ApplicationType(this.ApplicationType)
                .Version(this.Version)
                .SessionLocation(this.SessionLocation)
                .DeviceCodeId(this.DeviceCodeId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "session_location", false },
                { "device_code_id", false },
            };

            private string applicationType;
            private string version;
            private string sessionLocation;
            private string deviceCodeId;

             /// <summary>
             /// ApplicationType.
             /// </summary>
             /// <param name="applicationType"> applicationType. </param>
             /// <returns> Builder. </returns>
            public Builder ApplicationType(string applicationType)
            {
                this.applicationType = applicationType;
                return this;
            }

             /// <summary>
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(string version)
            {
                this.version = version;
                return this;
            }

             /// <summary>
             /// SessionLocation.
             /// </summary>
             /// <param name="sessionLocation"> sessionLocation. </param>
             /// <returns> Builder. </returns>
            public Builder SessionLocation(string sessionLocation)
            {
                shouldSerialize["session_location"] = true;
                this.sessionLocation = sessionLocation;
                return this;
            }

             /// <summary>
             /// DeviceCodeId.
             /// </summary>
             /// <param name="deviceCodeId"> deviceCodeId. </param>
             /// <returns> Builder. </returns>
            public Builder DeviceCodeId(string deviceCodeId)
            {
                shouldSerialize["device_code_id"] = true;
                this.deviceCodeId = deviceCodeId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetSessionLocation()
            {
                this.shouldSerialize["session_location"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetDeviceCodeId()
            {
                this.shouldSerialize["device_code_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DeviceComponentDetailsApplicationDetails. </returns>
            public DeviceComponentDetailsApplicationDetails Build()
            {
                return new DeviceComponentDetailsApplicationDetails(
                    shouldSerialize,
                    this.applicationType,
                    this.version,
                    this.sessionLocation,
                    this.deviceCodeId);
            }
        }
    }
}