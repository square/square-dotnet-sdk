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
    public class V1ListSettlementsRequest 
    {
        public V1ListSettlementsRequest(string order = null,
            string beginTime = null,
            string endTime = null,
            int? limit = null,
            string status = null,
            string batchToken = null)
        {
            Order = order;
            BeginTime = beginTime;
            EndTime = endTime;
            Limit = limit;
            Status = status;
            BatchToken = batchToken;
        }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("order")]
        public string Order { get; }

        /// <summary>
        /// The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year.
        /// </summary>
        [JsonProperty("begin_time")]
        public string BeginTime { get; }

        /// <summary>
        /// The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time.
        /// </summary>
        [JsonProperty("end_time")]
        public string EndTime { get; }

        /// <summary>
        /// The maximum number of settlements to return in a single response. This value cannot exceed 200.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// Getter for status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// A pagination cursor to retrieve the next set of results for your
        /// original query to the endpoint.
        /// </summary>
        [JsonProperty("batch_token")]
        public string BatchToken { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Order(Order)
                .BeginTime(BeginTime)
                .EndTime(EndTime)
                .Limit(Limit)
                .Status(Status)
                .BatchToken(BatchToken);
            return builder;
        }

        public class Builder
        {
            private string order;
            private string beginTime;
            private string endTime;
            private int? limit;
            private string status;
            private string batchToken;

            public Builder() { }
            public Builder Order(string value)
            {
                order = value;
                return this;
            }

            public Builder BeginTime(string value)
            {
                beginTime = value;
                return this;
            }

            public Builder EndTime(string value)
            {
                endTime = value;
                return this;
            }

            public Builder Limit(int? value)
            {
                limit = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder BatchToken(string value)
            {
                batchToken = value;
                return this;
            }

            public V1ListSettlementsRequest Build()
            {
                return new V1ListSettlementsRequest(order,
                    beginTime,
                    endTime,
                    limit,
                    status,
                    batchToken);
            }
        }
    }
}