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
    public class TerminalRefundQueryFilter 
    {
        public TerminalRefundQueryFilter(string deviceId = null,
            Models.TimeRange createdAt = null,
            string status = null)
        {
            DeviceId = deviceId;
            CreatedAt = createdAt;
            Status = status;
        }

        /// <summary>
        /// `TerminalRefund`s associated with a specific device. If no device is specified then all
        /// `TerminalRefund`s for the signed in account will be displayed.
        /// </summary>
        [JsonProperty("device_id", NullValueHandling = NullValueHandling.Ignore)]
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
        /// Filtered results with the desired status of the `TerminalRefund`
        /// Options: `PENDING`, `IN_PROGRESS`, `CANCEL_REQUESTED`, `CANCELED`, `COMPLETED`
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .DeviceId(DeviceId)
                .CreatedAt(CreatedAt)
                .Status(Status);
            return builder;
        }

        public class Builder
        {
            private string deviceId;
            private Models.TimeRange createdAt;
            private string status;



            public Builder DeviceId(string deviceId)
            {
                this.deviceId = deviceId;
                return this;
            }

            public Builder CreatedAt(Models.TimeRange createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public TerminalRefundQueryFilter Build()
            {
                return new TerminalRefundQueryFilter(deviceId,
                    createdAt,
                    status);
            }
        }
    }
}