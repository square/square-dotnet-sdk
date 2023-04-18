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
    /// CreateRefundRequest.
    /// </summary>
    public class CreateRefundRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRefundRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="tenderId">tender_id.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="reason">reason.</param>
        public CreateRefundRequest(
            string idempotencyKey,
            string tenderId,
            Models.Money amountMoney,
            string reason = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.TenderId = tenderId;
            this.Reason = reason;
            this.AmountMoney = amountMoney;
        }

        /// <summary>
        /// A value you specify that uniquely identifies this
        /// refund among refunds you've created for the tender.
        /// If you're unsure whether a particular refund succeeded,
        /// you can reattempt it with the same idempotency key without
        /// worrying about duplicating the refund.
        /// See [Idempotency keys](https://developer.squareup.com/docs/working-with-apis/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The ID of the tender to refund.
        /// A [`Transaction`](entity:Transaction) has one or more `tenders` (i.e., methods
        /// of payment) associated with it, and you refund each tender separately with
        /// the Connect API.
        /// </summary>
        [JsonProperty("tender_id")]
        public string TenderId { get; }

        /// <summary>
        /// A description of the reason for the refund.
        /// Default value: `Refund via API`
        /// </summary>
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("amount_money")]
        public Models.Money AmountMoney { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateRefundRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateRefundRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.TenderId == null && other.TenderId == null) || (this.TenderId?.Equals(other.TenderId) == true)) &&
                ((this.Reason == null && other.Reason == null) || (this.Reason?.Equals(other.Reason) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 50633946;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.TenderId, this.Reason, this.AmountMoney);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.TenderId = {(this.TenderId == null ? "null" : this.TenderId == string.Empty ? "" : this.TenderId)}");
            toStringOutput.Add($"this.Reason = {(this.Reason == null ? "null" : this.Reason == string.Empty ? "" : this.Reason)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey,
                this.TenderId,
                this.AmountMoney)
                .Reason(this.Reason);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private string tenderId;
            private Models.Money amountMoney;
            private string reason;

            public Builder(
                string idempotencyKey,
                string tenderId,
                Models.Money amountMoney)
            {
                this.idempotencyKey = idempotencyKey;
                this.tenderId = tenderId;
                this.amountMoney = amountMoney;
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
             /// TenderId.
             /// </summary>
             /// <param name="tenderId"> tenderId. </param>
             /// <returns> Builder. </returns>
            public Builder TenderId(string tenderId)
            {
                this.tenderId = tenderId;
                return this;
            }

             /// <summary>
             /// AmountMoney.
             /// </summary>
             /// <param name="amountMoney"> amountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

             /// <summary>
             /// Reason.
             /// </summary>
             /// <param name="reason"> reason. </param>
             /// <returns> Builder. </returns>
            public Builder Reason(string reason)
            {
                this.reason = reason;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateRefundRequest. </returns>
            public CreateRefundRequest Build()
            {
                return new CreateRefundRequest(
                    this.idempotencyKey,
                    this.tenderId,
                    this.amountMoney,
                    this.reason);
            }
        }
    }
}