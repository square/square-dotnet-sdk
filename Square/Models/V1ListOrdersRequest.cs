using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// V1ListOrdersRequest.
    /// </summary>
    public class V1ListOrdersRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="V1ListOrdersRequest"/> class.
        /// </summary>
        /// <param name="order">order.</param>
        /// <param name="limit">limit.</param>
        /// <param name="batchToken">batch_token.</param>
        public V1ListOrdersRequest(
            string order = null,
            int? limit = null,
            string batchToken = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "limit", false },
                { "batch_token", false }
            };
            this.Order = order;

            if (limit != null)
            {
                shouldSerialize["limit"] = true;
                this.Limit = limit;
            }

            if (batchToken != null)
            {
                shouldSerialize["batch_token"] = true;
                this.BatchToken = batchToken;
            }
        }

        internal V1ListOrdersRequest(
            Dictionary<string, bool> shouldSerialize,
            string order = null,
            int? limit = null,
            string batchToken = null)
        {
            this.shouldSerialize = shouldSerialize;
            Order = order;
            Limit = limit;
            BatchToken = batchToken;
        }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public string Order { get; }

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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"V1ListOrdersRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLimit()
        {
            return this.shouldSerialize["limit"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBatchToken()
        {
            return this.shouldSerialize["batch_token"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is V1ListOrdersRequest other &&
                (this.Order == null && other.Order == null ||
                 this.Order?.Equals(other.Order) == true) &&
                (this.Limit == null && other.Limit == null ||
                 this.Limit?.Equals(other.Limit) == true) &&
                (this.BatchToken == null && other.BatchToken == null ||
                 this.BatchToken?.Equals(other.BatchToken) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 121264426;
            hashCode = HashCode.Combine(hashCode, this.Order, this.Limit, this.BatchToken);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Order = {(this.Order == null ? "null" : this.Order.ToString())}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.BatchToken = {this.BatchToken ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Order(this.Order)
                .Limit(this.Limit)
                .BatchToken(this.BatchToken);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "limit", false },
                { "batch_token", false },
            };

            private string order;
            private int? limit;
            private string batchToken;

             /// <summary>
             /// Order.
             /// </summary>
             /// <param name="order"> order. </param>
             /// <returns> Builder. </returns>
            public Builder Order(string order)
            {
                this.order = order;
                return this;
            }

             /// <summary>
             /// Limit.
             /// </summary>
             /// <param name="limit"> limit. </param>
             /// <returns> Builder. </returns>
            public Builder Limit(int? limit)
            {
                shouldSerialize["limit"] = true;
                this.limit = limit;
                return this;
            }

             /// <summary>
             /// BatchToken.
             /// </summary>
             /// <param name="batchToken"> batchToken. </param>
             /// <returns> Builder. </returns>
            public Builder BatchToken(string batchToken)
            {
                shouldSerialize["batch_token"] = true;
                this.batchToken = batchToken;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLimit()
            {
                this.shouldSerialize["limit"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetBatchToken()
            {
                this.shouldSerialize["batch_token"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1ListOrdersRequest. </returns>
            public V1ListOrdersRequest Build()
            {
                return new V1ListOrdersRequest(
                    shouldSerialize,
                    this.order,
                    this.limit,
                    this.batchToken);
            }
        }
    }
}