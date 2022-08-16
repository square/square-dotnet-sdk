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
    /// CalculateLoyaltyPointsRequest.
    /// </summary>
    public class CalculateLoyaltyPointsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculateLoyaltyPointsRequest"/> class.
        /// </summary>
        /// <param name="orderId">order_id.</param>
        /// <param name="transactionAmountMoney">transaction_amount_money.</param>
        /// <param name="loyaltyAccountId">loyalty_account_id.</param>
        public CalculateLoyaltyPointsRequest(
            string orderId = null,
            Models.Money transactionAmountMoney = null,
            string loyaltyAccountId = null)
        {
            this.OrderId = orderId;
            this.TransactionAmountMoney = transactionAmountMoney;
            this.LoyaltyAccountId = loyaltyAccountId;
        }

        /// <summary>
        /// The [order]($m/Order) ID for which to calculate the points.
        /// Specify this field if your application uses the Orders API to process orders.
        /// Otherwise, specify the `transaction_amount_money`.
        /// </summary>
        [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("transaction_amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TransactionAmountMoney { get; }

        /// <summary>
        /// The ID of the target [loyalty account]($m/LoyaltyAccount). Optionally specify this field
        /// if your application uses the Orders API to process orders.
        /// If specified, the `promotion_points` field in the response shows the number of points the buyer would
        /// earn from the purchase. In this case, Square uses the account ID to determine whether the promotion's
        /// `trigger_limit` (the maximum number of times that a buyer can trigger the promotion) has been reached.
        /// If not specified, the `promotion_points` field shows the number of points the purchase qualifies
        /// for regardless of the trigger limit.
        /// </summary>
        [JsonProperty("loyalty_account_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LoyaltyAccountId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CalculateLoyaltyPointsRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CalculateLoyaltyPointsRequest other &&
                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true)) &&
                ((this.TransactionAmountMoney == null && other.TransactionAmountMoney == null) || (this.TransactionAmountMoney?.Equals(other.TransactionAmountMoney) == true)) &&
                ((this.LoyaltyAccountId == null && other.LoyaltyAccountId == null) || (this.LoyaltyAccountId?.Equals(other.LoyaltyAccountId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 528944996;
            hashCode = HashCode.Combine(this.OrderId, this.TransactionAmountMoney, this.LoyaltyAccountId);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId == string.Empty ? "" : this.OrderId)}");
            toStringOutput.Add($"this.TransactionAmountMoney = {(this.TransactionAmountMoney == null ? "null" : this.TransactionAmountMoney.ToString())}");
            toStringOutput.Add($"this.LoyaltyAccountId = {(this.LoyaltyAccountId == null ? "null" : this.LoyaltyAccountId == string.Empty ? "" : this.LoyaltyAccountId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderId(this.OrderId)
                .TransactionAmountMoney(this.TransactionAmountMoney)
                .LoyaltyAccountId(this.LoyaltyAccountId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string orderId;
            private Models.Money transactionAmountMoney;
            private string loyaltyAccountId;

             /// <summary>
             /// OrderId.
             /// </summary>
             /// <param name="orderId"> orderId. </param>
             /// <returns> Builder. </returns>
            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
                return this;
            }

             /// <summary>
             /// TransactionAmountMoney.
             /// </summary>
             /// <param name="transactionAmountMoney"> transactionAmountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TransactionAmountMoney(Models.Money transactionAmountMoney)
            {
                this.transactionAmountMoney = transactionAmountMoney;
                return this;
            }

             /// <summary>
             /// LoyaltyAccountId.
             /// </summary>
             /// <param name="loyaltyAccountId"> loyaltyAccountId. </param>
             /// <returns> Builder. </returns>
            public Builder LoyaltyAccountId(string loyaltyAccountId)
            {
                this.loyaltyAccountId = loyaltyAccountId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CalculateLoyaltyPointsRequest. </returns>
            public CalculateLoyaltyPointsRequest Build()
            {
                return new CalculateLoyaltyPointsRequest(
                    this.orderId,
                    this.transactionAmountMoney,
                    this.loyaltyAccountId);
            }
        }
    }
}