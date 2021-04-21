namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// BatchRetrieveOrdersRequest.
    /// </summary>
    public class BatchRetrieveOrdersRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchRetrieveOrdersRequest"/> class.
        /// </summary>
        /// <param name="orderIds">order_ids.</param>
        /// <param name="locationId">location_id.</param>
        public BatchRetrieveOrdersRequest(
            IList<string> orderIds,
            string locationId = null)
        {
            this.LocationId = locationId;
            this.OrderIds = orderIds;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BatchRetrieveOrdersRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.OrderIds == null && other.OrderIds == null) || (this.OrderIds?.Equals(other.OrderIds) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 224728365;

            if (this.LocationId != null)
            {
               hashCode += this.LocationId.GetHashCode();
            }

            if (this.OrderIds != null)
            {
               hashCode += this.OrderIds.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.OrderIds = {(this.OrderIds == null ? "null" : $"[{string.Join(", ", this.OrderIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.OrderIds)
                .LocationId(this.LocationId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> orderIds;
            private string locationId;

            public Builder(
                IList<string> orderIds)
            {
                this.orderIds = orderIds;
            }

             /// <summary>
             /// OrderIds.
             /// </summary>
             /// <param name="orderIds"> orderIds. </param>
             /// <returns> Builder. </returns>
            public Builder OrderIds(IList<string> orderIds)
            {
                this.orderIds = orderIds;
                return this;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BatchRetrieveOrdersRequest. </returns>
            public BatchRetrieveOrdersRequest Build()
            {
                return new BatchRetrieveOrdersRequest(
                    this.orderIds,
                    this.locationId);
            }
        }
    }
}