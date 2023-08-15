namespace Square.Models
{
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

    /// <summary>
    /// ListGiftCardsRequest.
    /// </summary>
    public class ListGiftCardsRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ListGiftCardsRequest"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="state">state.</param>
        /// <param name="limit">limit.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="customerId">customer_id.</param>
        public ListGiftCardsRequest(
            string type = null,
            string state = null,
            int? limit = null,
            string cursor = null,
            string customerId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "type", false },
                { "state", false },
                { "limit", false },
                { "cursor", false },
                { "customer_id", false }
            };

            if (type != null)
            {
                shouldSerialize["type"] = true;
                this.Type = type;
            }

            if (state != null)
            {
                shouldSerialize["state"] = true;
                this.State = state;
            }

            if (limit != null)
            {
                shouldSerialize["limit"] = true;
                this.Limit = limit;
            }

            if (cursor != null)
            {
                shouldSerialize["cursor"] = true;
                this.Cursor = cursor;
            }

            if (customerId != null)
            {
                shouldSerialize["customer_id"] = true;
                this.CustomerId = customerId;
            }

        }
        internal ListGiftCardsRequest(Dictionary<string, bool> shouldSerialize,
            string type = null,
            string state = null,
            int? limit = null,
            string cursor = null,
            string customerId = null)
        {
            this.shouldSerialize = shouldSerialize;
            Type = type;
            State = state;
            Limit = limit;
            Cursor = cursor;
            CustomerId = customerId;
        }

        /// <summary>
        /// If a [type](entity:GiftCardType) is provided, the endpoint returns gift cards of the specified type.
        /// Otherwise, the endpoint returns gift cards of all types.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// If a [state](entity:GiftCardStatus) is provided, the endpoint returns the gift cards in the specified state.
        /// Otherwise, the endpoint returns the gift cards of all states.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; }

        /// <summary>
        /// If a limit is provided, the endpoint returns only the specified number of results per page.
        /// The maximum value is 200. The default value is 30.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this cursor to retrieve the next set of results for the original query.
        /// If a cursor is not provided, the endpoint returns the first page of the results.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// If a customer ID is provided, the endpoint returns only the gift cards linked to the specified customer.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListGiftCardsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeType()
        {
            return this.shouldSerialize["type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeState()
        {
            return this.shouldSerialize["state"];
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
        public bool ShouldSerializeCursor()
        {
            return this.shouldSerialize["cursor"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerId()
        {
            return this.shouldSerialize["customer_id"];
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
            return obj is ListGiftCardsRequest other &&                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.State == null && other.State == null) || (this.State?.Equals(other.State) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1903998366;
            hashCode = HashCode.Combine(this.Type, this.State, this.Limit, this.Cursor, this.CustomerId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type)}");
            toStringOutput.Add($"this.State = {(this.State == null ? "null" : this.State)}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor)}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Type(this.Type)
                .State(this.State)
                .Limit(this.Limit)
                .Cursor(this.Cursor)
                .CustomerId(this.CustomerId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "type", false },
                { "state", false },
                { "limit", false },
                { "cursor", false },
                { "customer_id", false },
            };

            private string type;
            private string state;
            private int? limit;
            private string cursor;
            private string customerId;

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                shouldSerialize["type"] = true;
                this.type = type;
                return this;
            }

             /// <summary>
             /// State.
             /// </summary>
             /// <param name="state"> state. </param>
             /// <returns> Builder. </returns>
            public Builder State(string state)
            {
                shouldSerialize["state"] = true;
                this.state = state;
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
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                shouldSerialize["cursor"] = true;
                this.cursor = cursor;
                return this;
            }

             /// <summary>
             /// CustomerId.
             /// </summary>
             /// <param name="customerId"> customerId. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerId(string customerId)
            {
                shouldSerialize["customer_id"] = true;
                this.customerId = customerId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetType()
            {
                this.shouldSerialize["type"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetState()
            {
                this.shouldSerialize["state"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLimit()
            {
                this.shouldSerialize["limit"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCursor()
            {
                this.shouldSerialize["cursor"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCustomerId()
            {
                this.shouldSerialize["customer_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListGiftCardsRequest. </returns>
            public ListGiftCardsRequest Build()
            {
                return new ListGiftCardsRequest(shouldSerialize,
                    this.type,
                    this.state,
                    this.limit,
                    this.cursor,
                    this.customerId);
            }
        }
    }
}