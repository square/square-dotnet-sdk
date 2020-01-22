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
    public class V1ListEmployeeRolesRequest 
    {
        public V1ListEmployeeRolesRequest(string order = null,
            int? limit = null,
            string batchToken = null)
        {
            Order = order;
            Limit = limit;
            BatchToken = batchToken;
        }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("order")]
        public string Order { get; }

        /// <summary>
        /// The maximum integer number of employee entities to return in a single response. Default 100, maximum 200.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

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
                .Limit(Limit)
                .BatchToken(BatchToken);
            return builder;
        }

        public class Builder
        {
            private string order;
            private int? limit;
            private string batchToken;

            public Builder() { }
            public Builder Order(string value)
            {
                order = value;
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

            public V1ListEmployeeRolesRequest Build()
            {
                return new V1ListEmployeeRolesRequest(order,
                    limit,
                    batchToken);
            }
        }
    }
}