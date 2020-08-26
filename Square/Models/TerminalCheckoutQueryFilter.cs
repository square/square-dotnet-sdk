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
    public class TerminalCheckoutQueryFilter 
    {
        public TerminalCheckoutQueryFilter(string deviceId = null,
            Models.TimeRange createdAt = null,
            string status = null)
        {
            DeviceId = deviceId;
            CreatedAt = createdAt;
            Status = status;
        }

        /// <summary>
        /// `TerminalCheckout`s associated with a specific device. If no device is specified then all
        /// `TerminalCheckout`s for the merchant will be displayed.
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
        [JsonProperty("created_at")]
        public Models.TimeRange CreatedAt { get; }

        /// <summary>
        /// Filtered results with the desired status of the `TerminalCheckout`
        /// Options: PENDING, IN\_PROGRESS, CANCELED, COMPLETED
        /// </summary>
        [JsonProperty("status")]
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

            public Builder() { }
            public Builder DeviceId(string value)
            {
                deviceId = value;
                return this;
            }

            public Builder CreatedAt(Models.TimeRange value)
            {
                createdAt = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public TerminalCheckoutQueryFilter Build()
            {
                return new TerminalCheckoutQueryFilter(deviceId,
                    createdAt,
                    status);
            }
        }
    }
}