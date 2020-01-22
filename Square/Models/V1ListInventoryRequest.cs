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
    public class V1ListInventoryRequest 
    {
        public V1ListInventoryRequest(int? limit = null,
            string batchToken = null)
        {
            Limit = limit;
            BatchToken = batchToken;
        }

        /// <summary>
        /// The maximum number of inventory entries to return in a single response. This value cannot exceed 1000.
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
                .Limit(Limit)
                .BatchToken(BatchToken);
            return builder;
        }

        public class Builder
        {
            private int? limit;
            private string batchToken;

            public Builder() { }
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

            public V1ListInventoryRequest Build()
            {
                return new V1ListInventoryRequest(limit,
                    batchToken);
            }
        }
    }
}