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
    public class SearchOrdersDateTimeFilter 
    {
        public SearchOrdersDateTimeFilter(Models.TimeRange createdAt = null,
            Models.TimeRange updatedAt = null,
            Models.TimeRange closedAt = null)
        {
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ClosedAt = closedAt;
        }

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
        /// Represents a generic time range. The start and end values are
        /// represented in RFC 3339 format. Time ranges are customized to be
        /// inclusive or exclusive based on the needs of a particular endpoint.
        /// Refer to the relevant endpoint-specific documentation to determine
        /// how time ranges are handled.
        /// </summary>
        [JsonProperty("updated_at")]
        public Models.TimeRange UpdatedAt { get; }

        /// <summary>
        /// Represents a generic time range. The start and end values are
        /// represented in RFC 3339 format. Time ranges are customized to be
        /// inclusive or exclusive based on the needs of a particular endpoint.
        /// Refer to the relevant endpoint-specific documentation to determine
        /// how time ranges are handled.
        /// </summary>
        [JsonProperty("closed_at")]
        public Models.TimeRange ClosedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt)
                .ClosedAt(ClosedAt);
            return builder;
        }

        public class Builder
        {
            private Models.TimeRange createdAt;
            private Models.TimeRange updatedAt;
            private Models.TimeRange closedAt;

            public Builder() { }
            public Builder CreatedAt(Models.TimeRange value)
            {
                createdAt = value;
                return this;
            }

            public Builder UpdatedAt(Models.TimeRange value)
            {
                updatedAt = value;
                return this;
            }

            public Builder ClosedAt(Models.TimeRange value)
            {
                closedAt = value;
                return this;
            }

            public SearchOrdersDateTimeFilter Build()
            {
                return new SearchOrdersDateTimeFilter(createdAt,
                    updatedAt,
                    closedAt);
            }
        }
    }
}