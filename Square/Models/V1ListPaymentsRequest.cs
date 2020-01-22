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
    public class V1ListPaymentsRequest 
    {
        public V1ListPaymentsRequest(string order = null,
            string beginTime = null,
            string endTime = null,
            int? limit = null,
            string batchToken = null,
            bool? includePartial = null)
        {
            Order = order;
            BeginTime = beginTime;
            EndTime = endTime;
            Limit = limit;
            BatchToken = batchToken;
            IncludePartial = includePartial;
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
        /// The maximum number of payments to return in a single response. This value cannot exceed 200.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// A pagination cursor to retrieve the next set of results for your
        /// original query to the endpoint.
        /// </summary>
        [JsonProperty("batch_token")]
        public string BatchToken { get; }

        /// <summary>
        /// Indicates whether or not to include partial payments in the response. Partial payments will have the tenders collected so far, but the itemizations will be empty until the payment is completed.
        /// </summary>
        [JsonProperty("include_partial")]
        public bool? IncludePartial { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Order(Order)
                .BeginTime(BeginTime)
                .EndTime(EndTime)
                .Limit(Limit)
                .BatchToken(BatchToken)
                .IncludePartial(IncludePartial);
            return builder;
        }

        public class Builder
        {
            private string order;
            private string beginTime;
            private string endTime;
            private int? limit;
            private string batchToken;
            private bool? includePartial;

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

            public Builder BatchToken(string value)
            {
                batchToken = value;
                return this;
            }

            public Builder IncludePartial(bool? value)
            {
                includePartial = value;
                return this;
            }

            public V1ListPaymentsRequest Build()
            {
                return new V1ListPaymentsRequest(order,
                    beginTime,
                    endTime,
                    limit,
                    batchToken,
                    includePartial);
            }
        }
    }
}