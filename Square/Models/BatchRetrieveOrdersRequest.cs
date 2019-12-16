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
    public class BatchRetrieveOrdersRequest 
    {
        public BatchRetrieveOrdersRequest(IList<string> orderIds)
        {
            OrderIds = orderIds;
        }

        /// <summary>
        /// The IDs of the orders to retrieve. A maximum of 100 orders can be retrieved per request.
        /// </summary>
        [JsonProperty("order_ids")]
        public IList<string> OrderIds { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(OrderIds);
            return builder;
        }

        public class Builder
        {
            private IList<string> orderIds;

            public Builder(IList<string> orderIds)
            {
                this.orderIds = orderIds;
            }
            public Builder OrderIds(IList<string> value)
            {
                orderIds = value;
                return this;
            }

            public BatchRetrieveOrdersRequest Build()
            {
                return new BatchRetrieveOrdersRequest(orderIds);
            }
        }
    }
} 