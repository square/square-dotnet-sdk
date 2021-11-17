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
    /// RefundPaymentRequest.
    /// </summary>
    public class RefundPaymentRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefundPaymentRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="appFeeMoney">app_fee_money.</param>
        /// <param name="paymentId">payment_id.</param>
        /// <param name="reason">reason.</param>
        /// <param name="paymentVersionToken">payment_version_token.</param>
        /// <param name="teamMemberId">team_member_id.</param>
        public RefundPaymentRequest(
            string idempotencyKey,
            Models.Money amountMoney,
            Models.Money appFeeMoney = null,
            string paymentId = null,
            string reason = null,
            string paymentVersionToken = null,
            string teamMemberId = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.AmountMoney = amountMoney;
            this.AppFeeMoney = appFeeMoney;
            this.PaymentId = paymentId;
            this.Reason = reason;
            this.PaymentVersionToken = paymentVersionToken;
            this.TeamMemberId = teamMemberId;
        }

        /// <summary>
        /// A unique string that identifies this `RefundPayment` request. The key can be any valid string
        /// but must be unique for every `RefundPayment` request.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

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

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("app_fee_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AppFeeMoney { get; }

        /// <summary>
        /// The unique ID of the payment being refunded. Must be provided and non-empty.
        /// </summary>
        [JsonProperty("payment_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentId { get; }

        /// <summary>
        /// A description of the reason for the refund.
        /// </summary>
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; }

        /// <summary>
        /// Used for optimistic concurrency. This opaque token identifies the current `Payment`
        /// version that the caller expects. If the server has a different version of the Payment,
        /// the update fails and a response with a VERSION_MISMATCH error is returned.
        /// If the versions match, or the field is not provided, the refund proceeds as normal.
        /// </summary>
        [JsonProperty("payment_version_token", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentVersionToken { get; }

        /// <summary>
        /// An optional [TeamMember]($m/TeamMember) ID to associate with this refund.
        /// </summary>
        [JsonProperty("team_member_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamMemberId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RefundPaymentRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is RefundPaymentRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.AppFeeMoney == null && other.AppFeeMoney == null) || (this.AppFeeMoney?.Equals(other.AppFeeMoney) == true)) &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true)) &&
                ((this.Reason == null && other.Reason == null) || (this.Reason?.Equals(other.Reason) == true)) &&
                ((this.PaymentVersionToken == null && other.PaymentVersionToken == null) || (this.PaymentVersionToken?.Equals(other.PaymentVersionToken) == true)) &&
                ((this.TeamMemberId == null && other.TeamMemberId == null) || (this.TeamMemberId?.Equals(other.TeamMemberId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -789771424;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.AmountMoney, this.AppFeeMoney, this.PaymentId, this.Reason, this.PaymentVersionToken, this.TeamMemberId);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.AppFeeMoney = {(this.AppFeeMoney == null ? "null" : this.AppFeeMoney.ToString())}");
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId == string.Empty ? "" : this.PaymentId)}");
            toStringOutput.Add($"this.Reason = {(this.Reason == null ? "null" : this.Reason == string.Empty ? "" : this.Reason)}");
            toStringOutput.Add($"this.PaymentVersionToken = {(this.PaymentVersionToken == null ? "null" : this.PaymentVersionToken == string.Empty ? "" : this.PaymentVersionToken)}");
            toStringOutput.Add($"this.TeamMemberId = {(this.TeamMemberId == null ? "null" : this.TeamMemberId == string.Empty ? "" : this.TeamMemberId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey,
                this.AmountMoney)
                .AppFeeMoney(this.AppFeeMoney)
                .PaymentId(this.PaymentId)
                .Reason(this.Reason)
                .PaymentVersionToken(this.PaymentVersionToken)
                .TeamMemberId(this.TeamMemberId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private Models.Money amountMoney;
            private Models.Money appFeeMoney;
            private string paymentId;
            private string reason;
            private string paymentVersionToken;
            private string teamMemberId;

            public Builder(
                string idempotencyKey,
                Models.Money amountMoney)
            {
                this.idempotencyKey = idempotencyKey;
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
             /// AppFeeMoney.
             /// </summary>
             /// <param name="appFeeMoney"> appFeeMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AppFeeMoney(Models.Money appFeeMoney)
            {
                this.appFeeMoney = appFeeMoney;
                return this;
            }

             /// <summary>
             /// PaymentId.
             /// </summary>
             /// <param name="paymentId"> paymentId. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentId(string paymentId)
            {
                this.paymentId = paymentId;
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
             /// PaymentVersionToken.
             /// </summary>
             /// <param name="paymentVersionToken"> paymentVersionToken. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentVersionToken(string paymentVersionToken)
            {
                this.paymentVersionToken = paymentVersionToken;
                return this;
            }

             /// <summary>
             /// TeamMemberId.
             /// </summary>
             /// <param name="teamMemberId"> teamMemberId. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberId(string teamMemberId)
            {
                this.teamMemberId = teamMemberId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RefundPaymentRequest. </returns>
            public RefundPaymentRequest Build()
            {
                return new RefundPaymentRequest(
                    this.idempotencyKey,
                    this.amountMoney,
                    this.appFeeMoney,
                    this.paymentId,
                    this.reason,
                    this.paymentVersionToken,
                    this.teamMemberId);
            }
        }
    }
}