
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
        public BatchRetrieveOrdersRequest(IList<string> orderIds,
            string locationId = null)
        {
            LocationId = locationId;
            OrderIds = orderIds;
        }

        /// <summary>
        /// The ID of the location for these orders. This field is optional: omit it to retrieve
        /// orders within the scope of the current authorization's merchant ID.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The IDs of the orders to retrieve. A maximum of 100 orders can be retrieved per request.
        /// </summary>
        [JsonProperty("order_ids")]
        public IList<string> OrderIds { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BatchRetrieveOrdersRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LocationId = {(LocationId == null ? "null" : LocationId == string.Empty ? "" : LocationId)}");
            toStringOutput.Add($"OrderIds = {(OrderIds == null ? "null" : $"[{ string.Join(", ", OrderIds)} ]")}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is BatchRetrieveOrdersRequest other &&
                ((LocationId == null && other.LocationId == null) || (LocationId?.Equals(other.LocationId) == true)) &&
                ((OrderIds == null && other.OrderIds == null) || (OrderIds?.Equals(other.OrderIds) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 224728365;

            if (LocationId != null)
            {
               hashCode += LocationId.GetHashCode();
            }

            if (OrderIds != null)
            {
               hashCode += OrderIds.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(OrderIds)
                .LocationId(LocationId);
            return builder;
        }

        public class Builder
        {
            private IList<string> orderIds;
            private string locationId;

            public Builder(IList<string> orderIds)
            {
                this.orderIds = orderIds;
            }

            public Builder OrderIds(IList<string> orderIds)
            {
                this.orderIds = orderIds;
                return this;
            }

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public BatchRetrieveOrdersRequest Build()
            {
                return new BatchRetrieveOrdersRequest(orderIds,
                    locationId);
            }
        }
    }
}