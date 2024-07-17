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
    /// Refund.
    /// </summary>
    public class Refund
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="Refund"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="tenderId">tender_id.</param>
        /// <param name="reason">reason.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="status">status.</param>
        /// <param name="transactionId">transaction_id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="processingFeeMoney">processing_fee_money.</param>
        /// <param name="additionalRecipients">additional_recipients.</param>
        public Refund(
            string id,
            string locationId,
            string tenderId,
            string reason,
            Models.Money amountMoney,
            string status,
            string transactionId = null,
            string createdAt = null,
            Models.Money processingFeeMoney = null,
            IList<Models.AdditionalRecipient> additionalRecipients = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "transaction_id", false },
                { "additional_recipients", false }
            };

            this.Id = id;
            this.LocationId = locationId;
            if (transactionId != null)
            {
                shouldSerialize["transaction_id"] = true;
                this.TransactionId = transactionId;
            }

            this.TenderId = tenderId;
            this.CreatedAt = createdAt;
            this.Reason = reason;
            this.AmountMoney = amountMoney;
            this.Status = status;
            this.ProcessingFeeMoney = processingFeeMoney;
            if (additionalRecipients != null)
            {
                shouldSerialize["additional_recipients"] = true;
                this.AdditionalRecipients = additionalRecipients;
            }

        }
        internal Refund(Dictionary<string, bool> shouldSerialize,
            string id,
            string locationId,
            string tenderId,
            string reason,
            Models.Money amountMoney,
            string status,
            string transactionId = null,
            string createdAt = null,
            Models.Money processingFeeMoney = null,
            IList<Models.AdditionalRecipient> additionalRecipients = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            LocationId = locationId;
            TransactionId = transactionId;
            TenderId = tenderId;
            CreatedAt = createdAt;
            Reason = reason;
            AmountMoney = amountMoney;
            Status = status;
            ProcessingFeeMoney = processingFeeMoney;
            AdditionalRecipients = additionalRecipients;
        }

        /// <summary>
        /// The refund's unique ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The ID of the refund's associated location.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The ID of the transaction that the refunded tender is part of.
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; }

        /// <summary>
        /// The ID of the refunded tender.
        /// </summary>
        [JsonProperty("tender_id")]
        public string TenderId { get; }

        /// <summary>
        /// The timestamp for when the refund was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The reason for the refund being issued.
        /// </summary>
        [JsonProperty("reason")]
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

        /// <summary>
        /// Indicates a refund's current status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("processing_fee_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money ProcessingFeeMoney { get; }

        /// <summary>
        /// Additional recipients (other than the merchant) receiving a portion of this refund.
        /// For example, fees assessed on a refund of a purchase by a third party integration.
        /// </summary>
        [JsonProperty("additional_recipients")]
        public IList<Models.AdditionalRecipient> AdditionalRecipients { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Refund : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTransactionId()
        {
            return this.shouldSerialize["transaction_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAdditionalRecipients()
        {
            return this.shouldSerialize["additional_recipients"];
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
            return obj is Refund other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.TransactionId == null && other.TransactionId == null) || (this.TransactionId?.Equals(other.TransactionId) == true)) &&
                ((this.TenderId == null && other.TenderId == null) || (this.TenderId?.Equals(other.TenderId) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.Reason == null && other.Reason == null) || (this.Reason?.Equals(other.Reason) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.ProcessingFeeMoney == null && other.ProcessingFeeMoney == null) || (this.ProcessingFeeMoney?.Equals(other.ProcessingFeeMoney) == true)) &&
                ((this.AdditionalRecipients == null && other.AdditionalRecipients == null) || (this.AdditionalRecipients?.Equals(other.AdditionalRecipients) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -772282082;
            hashCode = HashCode.Combine(this.Id, this.LocationId, this.TransactionId, this.TenderId, this.CreatedAt, this.Reason, this.AmountMoney);

            hashCode = HashCode.Combine(hashCode, this.Status, this.ProcessingFeeMoney, this.AdditionalRecipients);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.TransactionId = {(this.TransactionId == null ? "null" : this.TransactionId)}");
            toStringOutput.Add($"this.TenderId = {(this.TenderId == null ? "null" : this.TenderId)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt)}");
            toStringOutput.Add($"this.Reason = {(this.Reason == null ? "null" : this.Reason)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.ProcessingFeeMoney = {(this.ProcessingFeeMoney == null ? "null" : this.ProcessingFeeMoney.ToString())}");
            toStringOutput.Add($"this.AdditionalRecipients = {(this.AdditionalRecipients == null ? "null" : $"[{string.Join(", ", this.AdditionalRecipients)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Id,
                this.LocationId,
                this.TenderId,
                this.Reason,
                this.AmountMoney,
                this.Status)
                .TransactionId(this.TransactionId)
                .CreatedAt(this.CreatedAt)
                .ProcessingFeeMoney(this.ProcessingFeeMoney)
                .AdditionalRecipients(this.AdditionalRecipients);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "transaction_id", false },
                { "additional_recipients", false },
            };

            private string id;
            private string locationId;
            private string tenderId;
            private string reason;
            private Models.Money amountMoney;
            private string status;
            private string transactionId;
            private string createdAt;
            private Models.Money processingFeeMoney;
            private IList<Models.AdditionalRecipient> additionalRecipients;

            /// <summary>
            /// Initialize Builder for Refund.
            /// </summary>
            /// <param name="id"> id. </param>
            /// <param name="locationId"> locationId. </param>
            /// <param name="tenderId"> tenderId. </param>
            /// <param name="reason"> reason. </param>
            /// <param name="amountMoney"> amountMoney. </param>
            /// <param name="status"> status. </param>
            public Builder(
                string id,
                string locationId,
                string tenderId,
                string reason,
                Models.Money amountMoney,
                string status)
            {
                this.id = id;
                this.locationId = locationId;
                this.tenderId = tenderId;
                this.reason = reason;
                this.amountMoney = amountMoney;
                this.status = status;
            }

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
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
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

             /// <summary>
             /// TransactionId.
             /// </summary>
             /// <param name="transactionId"> transactionId. </param>
             /// <returns> Builder. </returns>
            public Builder TransactionId(string transactionId)
            {
                shouldSerialize["transaction_id"] = true;
                this.transactionId = transactionId;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// ProcessingFeeMoney.
             /// </summary>
             /// <param name="processingFeeMoney"> processingFeeMoney. </param>
             /// <returns> Builder. </returns>
            public Builder ProcessingFeeMoney(Models.Money processingFeeMoney)
            {
                this.processingFeeMoney = processingFeeMoney;
                return this;
            }

             /// <summary>
             /// AdditionalRecipients.
             /// </summary>
             /// <param name="additionalRecipients"> additionalRecipients. </param>
             /// <returns> Builder. </returns>
            public Builder AdditionalRecipients(IList<Models.AdditionalRecipient> additionalRecipients)
            {
                shouldSerialize["additional_recipients"] = true;
                this.additionalRecipients = additionalRecipients;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTransactionId()
            {
                this.shouldSerialize["transaction_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAdditionalRecipients()
            {
                this.shouldSerialize["additional_recipients"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Refund. </returns>
            public Refund Build()
            {
                return new Refund(shouldSerialize,
                    this.id,
                    this.locationId,
                    this.tenderId,
                    this.reason,
                    this.amountMoney,
                    this.status,
                    this.transactionId,
                    this.createdAt,
                    this.processingFeeMoney,
                    this.additionalRecipients);
            }
        }
    }
}