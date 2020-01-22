using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class BatchRetrieveOrdersResponse 
    {
        public BatchRetrieveOrdersResponse(IList<Models.Order> orders = null,
            IList<Models.Error> errors = null)
        {
            Orders = orders;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The requested orders. This will omit any requested orders that do not exist.
        /// </summary>
        [JsonProperty("orders")]
        public IList<Models.Order> Orders { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Orders(Orders)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Order> orders = new List<Models.Order>();
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder Orders(IList<Models.Order> value)
            {
                orders = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public BatchRetrieveOrdersResponse Build()
            {
                return new BatchRetrieveOrdersResponse(orders,
                    errors);
            }
        }
    }
}