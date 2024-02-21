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
    /// RefundPaymentRequest.
    /// </summary>
    public class RefundPaymentRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="RefundPaymentRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="appFeeMoney">app_fee_money.</param>
        /// <param name="paymentId">payment_id.</param>
        /// <param name="destinationId">destination_id.</param>
        /// <param name="unlinked">unlinked.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="reason">reason.</param>
        /// <param name="paymentVersionToken">payment_version_token.</param>
        /// <param name="teamMemberId">team_member_id.</param>
        public RefundPaymentRequest(
            string idempotencyKey,
            Models.Money amountMoney,
            Models.Money appFeeMoney = null,
            string paymentId = null,
            string destinationId = null,
            bool? unlinked = null,
            string locationId = null,
            string customerId = null,
            string reason = null,
            string paymentVersionToken = null,
            string teamMemberId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "payment_id", false },
                { "destination_id", false },
                { "unlinked", false },
                { "location_id", false },
                { "customer_id", false },
                { "reason", false },
                { "payment_version_token", false },
                { "team_member_id", false }
            };

            this.IdempotencyKey = idempotencyKey;
            this.AmountMoney = amountMoney;
            this.AppFeeMoney = appFeeMoney;
            if (paymentId != null)
            {
                shouldSerialize["payment_id"] = true;
                this.PaymentId = paymentId;
            }

            if (destinationId != null)
            {
                shouldSerialize["destination_id"] = true;
                this.DestinationId = destinationId;
            }

            if (unlinked != null)
            {
                shouldSerialize["unlinked"] = true;
                this.Unlinked = unlinked;
            }

            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

            if (customerId != null)
            {
                shouldSerialize["customer_id"] = true;
                this.CustomerId = customerId;
            }

            if (reason != null)
            {
                shouldSerialize["reason"] = true;
                this.Reason = reason;
            }

            if (paymentVersionToken != null)
            {
                shouldSerialize["payment_version_token"] = true;
                this.PaymentVersionToken = paymentVersionToken;
            }

            if (teamMemberId != null)
            {
                shouldSerialize["team_member_id"] = true;
                this.TeamMemberId = teamMemberId;
            }

        }
        internal RefundPaymentRequest(Dictionary<string, bool> shouldSerialize,
            string idempotencyKey,
            Models.Money amountMoney,
            Models.Money appFeeMoney = null,
            string paymentId = null,
            string destinationId = null,
            bool? unlinked = null,
            string locationId = null,
            string customerId = null,
            string reason = null,
            string paymentVersionToken = null,
            string teamMemberId = null)
        {
            this.shouldSerialize = shouldSerialize;
            IdempotencyKey = idempotencyKey;
            AmountMoney = amountMoney;
            AppFeeMoney = appFeeMoney;
            PaymentId = paymentId;
            DestinationId = destinationId;
            Unlinked = unlinked;
            LocationId = locationId;
            CustomerId = customerId;
            Reason = reason;
            PaymentVersionToken = paymentVersionToken;
            TeamMemberId = teamMemberId;
        }

        /// <summary>
        /// A unique string that identifies this `RefundPayment` request. The key can be any valid string
        /// but must be unique for every `RefundPayment` request.
        /// Keys are limited to a max of 45 characters - however, the number of allowed characters might be
        /// less than 45, if multi-byte characters are used.
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
        /// The unique ID of the payment being refunded.
        /// Required when unlinked=false, otherwise must not be set.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        /// <summary>
        /// The ID indicating where funds will be refunded to, if this is an unlinked refund.
        /// This can be any of the following: A token generated by Web Payments SDK;
        /// a card-on-file identifier.
        /// Required for requests specifying unlinked=true.
        /// Otherwise, if included when `unlinked=false`, will throw an error.
        /// </summary>
        [JsonProperty("destination_id")]
        public string DestinationId { get; }

        /// <summary>
        /// Indicates that the refund is not linked to a Square payment.
        /// If set to true, `destination_id` and `location_id` must be supplied while `payment_id` must not
        /// be provided.
        /// </summary>
        [JsonProperty("unlinked")]
        public bool? Unlinked { get; }

        /// <summary>
        /// The location ID associated with the unlinked refund.
        /// Required for requests specifying `unlinked=true`.
        /// Otherwise, if included when `unlinked=false`, will throw an error.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The [Customer](entity:Customer) ID of the customer associated with the refund.
        /// This is required if the `destination_id` refers to a card on file created using the Cards
        /// API. Only allowed when `unlinked=true`.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <summary>
        /// A description of the reason for the refund.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; }

        /// <summary>
        /// Used for optimistic concurrency. This opaque token identifies the current `Payment`
        /// version that the caller expects. If the server has a different version of the Payment,
        /// the update fails and a response with a VERSION_MISMATCH error is returned.
        /// If the versions match, or the field is not provided, the refund proceeds as normal.
        /// </summary>
        [JsonProperty("payment_version_token")]
        public string PaymentVersionToken { get; }

        /// <summary>
        /// An optional [TeamMember](entity:TeamMember) ID to associate with this refund.
        /// </summary>
        [JsonProperty("team_member_id")]
        public string TeamMemberId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RefundPaymentRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentId()
        {
            return this.shouldSerialize["payment_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDestinationId()
        {
            return this.shouldSerialize["destination_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUnlinked()
        {
            return this.shouldSerialize["unlinked"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerId()
        {
            return this.shouldSerialize["customer_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReason()
        {
            return this.shouldSerialize["reason"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentVersionToken()
        {
            return this.shouldSerialize["payment_version_token"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTeamMemberId()
        {
            return this.shouldSerialize["team_member_id"];
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
            return obj is RefundPaymentRequest other &&                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.AppFeeMoney == null && other.AppFeeMoney == null) || (this.AppFeeMoney?.Equals(other.AppFeeMoney) == true)) &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true)) &&
                ((this.DestinationId == null && other.DestinationId == null) || (this.DestinationId?.Equals(other.DestinationId) == true)) &&
                ((this.Unlinked == null && other.Unlinked == null) || (this.Unlinked?.Equals(other.Unlinked) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.Reason == null && other.Reason == null) || (this.Reason?.Equals(other.Reason) == true)) &&
                ((this.PaymentVersionToken == null && other.PaymentVersionToken == null) || (this.PaymentVersionToken?.Equals(other.PaymentVersionToken) == true)) &&
                ((this.TeamMemberId == null && other.TeamMemberId == null) || (this.TeamMemberId?.Equals(other.TeamMemberId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1978621375;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.AmountMoney, this.AppFeeMoney, this.PaymentId, this.DestinationId, this.Unlinked, this.LocationId);

            hashCode = HashCode.Combine(hashCode, this.CustomerId, this.Reason, this.PaymentVersionToken, this.TeamMemberId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.AppFeeMoney = {(this.AppFeeMoney == null ? "null" : this.AppFeeMoney.ToString())}");
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId)}");
            toStringOutput.Add($"this.DestinationId = {(this.DestinationId == null ? "null" : this.DestinationId)}");
            toStringOutput.Add($"this.Unlinked = {(this.Unlinked == null ? "null" : this.Unlinked.ToString())}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId)}");
            toStringOutput.Add($"this.Reason = {(this.Reason == null ? "null" : this.Reason)}");
            toStringOutput.Add($"this.PaymentVersionToken = {(this.PaymentVersionToken == null ? "null" : this.PaymentVersionToken)}");
            toStringOutput.Add($"this.TeamMemberId = {(this.TeamMemberId == null ? "null" : this.TeamMemberId)}");
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
                .DestinationId(this.DestinationId)
                .Unlinked(this.Unlinked)
                .LocationId(this.LocationId)
                .CustomerId(this.CustomerId)
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "payment_id", false },
                { "destination_id", false },
                { "unlinked", false },
                { "location_id", false },
                { "customer_id", false },
                { "reason", false },
                { "payment_version_token", false },
                { "team_member_id", false },
            };

            private string idempotencyKey;
            private Models.Money amountMoney;
            private Models.Money appFeeMoney;
            private string paymentId;
            private string destinationId;
            private bool? unlinked;
            private string locationId;
            private string customerId;
            private string reason;
            private string paymentVersionToken;
            private string teamMemberId;

            /// <summary>
            /// Initialize Builder for RefundPaymentRequest.
            /// </summary>
            /// <param name="idempotencyKey"> idempotencyKey. </param>
            /// <param name="amountMoney"> amountMoney. </param>
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
                shouldSerialize["payment_id"] = true;
                this.paymentId = paymentId;
                return this;
            }

             /// <summary>
             /// DestinationId.
             /// </summary>
             /// <param name="destinationId"> destinationId. </param>
             /// <returns> Builder. </returns>
            public Builder DestinationId(string destinationId)
            {
                shouldSerialize["destination_id"] = true;
                this.destinationId = destinationId;
                return this;
            }

             /// <summary>
             /// Unlinked.
             /// </summary>
             /// <param name="unlinked"> unlinked. </param>
             /// <returns> Builder. </returns>
            public Builder Unlinked(bool? unlinked)
            {
                shouldSerialize["unlinked"] = true;
                this.unlinked = unlinked;
                return this;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                shouldSerialize["location_id"] = true;
                this.locationId = locationId;
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
             /// Reason.
             /// </summary>
             /// <param name="reason"> reason. </param>
             /// <returns> Builder. </returns>
            public Builder Reason(string reason)
            {
                shouldSerialize["reason"] = true;
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
                shouldSerialize["payment_version_token"] = true;
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
                shouldSerialize["team_member_id"] = true;
                this.teamMemberId = teamMemberId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPaymentId()
            {
                this.shouldSerialize["payment_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDestinationId()
            {
                this.shouldSerialize["destination_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetUnlinked()
            {
                this.shouldSerialize["unlinked"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCustomerId()
            {
                this.shouldSerialize["customer_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetReason()
            {
                this.shouldSerialize["reason"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPaymentVersionToken()
            {
                this.shouldSerialize["payment_version_token"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTeamMemberId()
            {
                this.shouldSerialize["team_member_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RefundPaymentRequest. </returns>
            public RefundPaymentRequest Build()
            {
                return new RefundPaymentRequest(shouldSerialize,
                    this.idempotencyKey,
                    this.amountMoney,
                    this.appFeeMoney,
                    this.paymentId,
                    this.destinationId,
                    this.unlinked,
                    this.locationId,
                    this.customerId,
                    this.reason,
                    this.paymentVersionToken,
                    this.teamMemberId);
            }
        }
    }
}