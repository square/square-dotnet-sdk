namespace Square.Models
{
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

    /// <summary>
    /// TerminalRefundQueryFilter.
    /// </summary>
    public class TerminalRefundQueryFilter
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalRefundQueryFilter"/> class.
        /// </summary>
        /// <param name="deviceId">device_id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="status">status.</param>
        public TerminalRefundQueryFilter(
            string deviceId = null,
            Models.TimeRange createdAt = null,
            string status = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "device_id", false },
                { "status", false }
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

        }
        internal TerminalRefundQueryFilter(Dictionary<string, bool> shouldSerialize,
            string deviceId = null,
            Models.TimeRange createdAt = null,
            string status = null)
        {
            this.shouldSerialize = shouldSerialize;
            DeviceId = deviceId;
            CreatedAt = createdAt;
            Status = status;
        }

        /// <summary>
        /// `TerminalRefund` objects associated with a specific device. If no device is specified, then all
        /// `TerminalRefund` objects for the signed-in account are displayed.
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
        /// Filtered results with the desired status of the `TerminalRefund`.
        /// Options: `PENDING`, `IN_PROGRESS`, `CANCEL_REQUESTED`, `CANCELED`, or `COMPLETED`.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TerminalRefundQueryFilter : ({string.Join(", ", toStringOutput)})";
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
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is TerminalRefundQueryFilter other &&                ((this.DeviceId == null && other.DeviceId == null) || (this.DeviceId?.Equals(other.DeviceId) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 227219520;
            hashCode = HashCode.Combine(this.DeviceId, this.CreatedAt, this.Status);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DeviceId = {(this.DeviceId == null ? "null" : this.DeviceId)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt.ToString())}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status)}");
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
                .Status(this.Status);
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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDeviceId()
            {
                this.shouldSerialize["device_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetStatus()
            {
                this.shouldSerialize["status"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TerminalRefundQueryFilter. </returns>
            public TerminalRefundQueryFilter Build()
            {
                return new TerminalRefundQueryFilter(shouldSerialize,
                    this.deviceId,
                    this.createdAt,
                    this.status);
            }
        }
    }
}