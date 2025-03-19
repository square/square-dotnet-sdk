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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// TerminalActionQueryFilter.
    /// </summary>
    public class TerminalActionQueryFilter
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalActionQueryFilter"/> class.
        /// </summary>
        /// <param name="deviceId">device_id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="status">status.</param>
        /// <param name="type">type.</param>
        public TerminalActionQueryFilter(
            string deviceId = null,
            Models.TimeRange createdAt = null,
            string status = null,
            string type = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "device_id", false },
                { "status", false },
            };

            if (deviceId != null)
            {
                shouldSerialize["device_id"] = true;
                this.DeviceId = deviceId;
            }
            this.CreatedAt = createdAt;

            if (status != null)
            {
                shouldSerialize["status"] = true;
                this.Status = status;
            }
            this.Type = type;
        }

        internal TerminalActionQueryFilter(
            Dictionary<string, bool> shouldSerialize,
            string deviceId = null,
            Models.TimeRange createdAt = null,
            string status = null,
            string type = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            DeviceId = deviceId;
            CreatedAt = createdAt;
            Status = status;
            Type = type;
        }

        /// <summary>
        /// `TerminalAction`s associated with a specific device. If no device is specified then all
        /// `TerminalAction`s for the merchant will be displayed.
        /// </summary>
        [JsonProperty("device_id")]
        public string DeviceId { get; }

        /// <summary>
        /// Represents a generic time range. The start and end values are
        /// represented in RFC 3339 format. Time ranges are customized to be
        /// inclusive or exclusive based on the needs of a particular endpoint.
        /// Refer to the relevant endpoint-specific documentation to determine
        /// how time ranges are handled.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TimeRange CreatedAt { get; }

        /// <summary>
        /// Filter results with the desired status of the `TerminalAction`
        /// Options: `PENDING`, `IN_PROGRESS`, `CANCEL_REQUESTED`, `CANCELED`, `COMPLETED`
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// Describes the type of this unit and indicates which field contains the unit information. This is an ‘open’ enum.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"TerminalActionQueryFilter : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeStatus()
        {
            return this.shouldSerialize["status"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is TerminalActionQueryFilter other
                && (
                    this.DeviceId == null && other.DeviceId == null
                    || this.DeviceId?.Equals(other.DeviceId) == true
                )
                && (
                    this.CreatedAt == null && other.CreatedAt == null
                    || this.CreatedAt?.Equals(other.CreatedAt) == true
                )
                && (
                    this.Status == null && other.Status == null
                    || this.Status?.Equals(other.Status) == true
                )
                && (
                    this.Type == null && other.Type == null || this.Type?.Equals(other.Type) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 160430547;
            hashCode = HashCode.Combine(
                hashCode,
                this.DeviceId,
                this.CreatedAt,
                this.Status,
                this.Type
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DeviceId = {this.DeviceId ?? "null"}");
            toStringOutput.Add(
                $"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt.ToString())}"
            );
            toStringOutput.Add($"this.Status = {this.Status ?? "null"}");
            toStringOutput.Add(
                $"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .DeviceId(this.DeviceId)
                .CreatedAt(this.CreatedAt)
                .Status(this.Status)
                .Type(this.Type);
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
                { "status", false },
            };

            private string deviceId;
            private Models.TimeRange createdAt;
            private string status;
            private string type;

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
            /// CreatedAt.
            /// </summary>
            /// <param name="createdAt"> createdAt. </param>
            /// <returns> Builder. </returns>
            public Builder CreatedAt(Models.TimeRange createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            /// <summary>
            /// Status.
            /// </summary>
            /// <param name="status"> status. </param>
            /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                shouldSerialize["status"] = true;
                this.status = status;
                return this;
            }

            /// <summary>
            /// Type.
            /// </summary>
            /// <param name="type"> type. </param>
            /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
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
            public void UnsetStatus()
            {
                this.shouldSerialize["status"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TerminalActionQueryFilter. </returns>
            public TerminalActionQueryFilter Build()
            {
                return new TerminalActionQueryFilter(
                    shouldSerialize,
                    this.deviceId,
                    this.createdAt,
                    this.status,
                    this.type
                );
            }
        }
    }
}
