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
    public class V1ListItemsRequest 
    {
        public V1ListItemsRequest(string batchToken = null)
        {
            BatchToken = batchToken;
        }

        /// <summary>
        /// A pagination cursor to retrieve the next set of results for your
        /// original query to the endpoint.
        /// </summary>
        [JsonProperty("batch_token")]
        public string BatchToken { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BatchToken(BatchToken);
            return builder;
        }

        public class Builder
        {
            private string batchToken;

            public Builder() { }
            public Builder BatchToken(string value)
            {
                batchToken = value;
                return this;
            }

            public V1ListItemsRequest Build()
            {
                return new V1ListItemsRequest(batchToken);
            }
        }
    }
}