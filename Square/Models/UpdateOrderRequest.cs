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
    /// UpdateOrderRequest.
    /// </summary>
    public class UpdateOrderRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateOrderRequest"/> class.
        /// </summary>
        /// <param name="order">order.</param>
        /// <param name="fieldsToClear">fields_to_clear.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public UpdateOrderRequest(
            Models.Order order = null,
            IList<string> fieldsToClear = null,
            string idempotencyKey = null)
        {
            this.Order = order;
            this.FieldsToClear = fieldsToClear;
            this.IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// Contains all information related to a single order to process with Square,
        /// including line items that specify the products to purchase. `Order` objects also
        /// include information about any associated tenders, refunds, and returns.
        /// All Connect V2 Transactions have all been converted to Orders including all associated
        /// itemization data.
        /// </summary>
        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Order Order { get; }

        /// <summary>
        /// The [dot notation paths](https://developer.squareup.com/docs/orders-api/manage-orders#on-dot-notation)
        /// fields to clear. For example, `line_items[uid].note`.
        /// For more information, see [Deleting fields](https://developer.squareup.com/docs/orders-api/manage-orders#delete-fields).
        /// </summary>
        [JsonProperty("fields_to_clear", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> FieldsToClear { get; }

        /// <summary>
        /// A value you specify that uniquely identifies this update request.
        /// If you are unsure whether a particular update was applied to an order successfully,
        /// you can reattempt it with the same idempotency key without
        /// worrying about creating duplicate updates to the order.
        /// The latest order version is returned.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateOrderRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is UpdateOrderRequest other &&
                ((this.Order == null && other.Order == null) || (this.Order?.Equals(other.Order) == true)) &&
                ((this.FieldsToClear == null && other.FieldsToClear == null) || (this.FieldsToClear?.Equals(other.FieldsToClear) == true)) &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1953116001;
            hashCode = HashCode.Combine(this.Order, this.FieldsToClear, this.IdempotencyKey);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Order = {(this.Order == null ? "null" : this.Order.ToString())}");
            toStringOutput.Add($"this.FieldsToClear = {(this.FieldsToClear == null ? "null" : $"[{string.Join(", ", this.FieldsToClear)} ]")}");
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Order(this.Order)
                .FieldsToClear(this.FieldsToClear)
                .IdempotencyKey(this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Order order;
            private IList<string> fieldsToClear;
            private string idempotencyKey;

             /// <summary>
             /// Order.
             /// </summary>
             /// <param name="order"> order. </param>
             /// <returns> Builder. </returns>
            public Builder Order(Models.Order order)
            {
                this.order = order;
                return this;
            }

             /// <summary>
             /// FieldsToClear.
             /// </summary>
             /// <param name="fieldsToClear"> fieldsToClear. </param>
             /// <returns> Builder. </returns>
            public Builder FieldsToClear(IList<string> fieldsToClear)
            {
                this.fieldsToClear = fieldsToClear;
                return this;
            }

             /// <summary>
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateOrderRequest. </returns>
            public UpdateOrderRequest Build()
            {
                return new UpdateOrderRequest(
                    this.order,
                    this.fieldsToClear,
                    this.idempotencyKey);
            }
        }
    }
}