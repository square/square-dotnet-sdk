
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
    public class Refund 
    {
        public Refund(string id,
            string locationId,
            string transactionId,
            string tenderId,
            string reason,
            Models.Money amountMoney,
            string status,
            string createdAt = null,
            Models.Money processingFeeMoney = null,
            IList<Models.AdditionalRecipient> additionalRecipients = null)
        {
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
        [JsonProperty("additional_recipients", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.AdditionalRecipient> AdditionalRecipients { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Refund : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"LocationId = {(LocationId == null ? "null" : LocationId == string.Empty ? "" : LocationId)}");
            toStringOutput.Add($"TransactionId = {(TransactionId == null ? "null" : TransactionId == string.Empty ? "" : TransactionId)}");
            toStringOutput.Add($"TenderId = {(TenderId == null ? "null" : TenderId == string.Empty ? "" : TenderId)}");
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
            toStringOutput.Add($"Reason = {(Reason == null ? "null" : Reason == string.Empty ? "" : Reason)}");
            toStringOutput.Add($"AmountMoney = {(AmountMoney == null ? "null" : AmountMoney.ToString())}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status.ToString())}");
            toStringOutput.Add($"ProcessingFeeMoney = {(ProcessingFeeMoney == null ? "null" : ProcessingFeeMoney.ToString())}");
            toStringOutput.Add($"AdditionalRecipients = {(AdditionalRecipients == null ? "null" : $"[{ string.Join(", ", AdditionalRecipients)} ]")}");
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

            return obj is Refund other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((LocationId == null && other.LocationId == null) || (LocationId?.Equals(other.LocationId) == true)) &&
                ((TransactionId == null && other.TransactionId == null) || (TransactionId?.Equals(other.TransactionId) == true)) &&
                ((TenderId == null && other.TenderId == null) || (TenderId?.Equals(other.TenderId) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((Reason == null && other.Reason == null) || (Reason?.Equals(other.Reason) == true)) &&
                ((AmountMoney == null && other.AmountMoney == null) || (AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true)) &&
                ((ProcessingFeeMoney == null && other.ProcessingFeeMoney == null) || (ProcessingFeeMoney?.Equals(other.ProcessingFeeMoney) == true)) &&
                ((AdditionalRecipients == null && other.AdditionalRecipients == null) || (AdditionalRecipients?.Equals(other.AdditionalRecipients) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -772282082;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (LocationId != null)
            {
               hashCode += LocationId.GetHashCode();
            }

            if (TransactionId != null)
            {
               hashCode += TransactionId.GetHashCode();
            }

            if (TenderId != null)
            {
               hashCode += TenderId.GetHashCode();
            }

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            if (Reason != null)
            {
               hashCode += Reason.GetHashCode();
            }

            if (AmountMoney != null)
            {
               hashCode += AmountMoney.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }

            if (ProcessingFeeMoney != null)
            {
               hashCode += ProcessingFeeMoney.GetHashCode();
            }

            if (AdditionalRecipients != null)
            {
               hashCode += AdditionalRecipients.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Id,
                LocationId,
                TransactionId,
                TenderId,
                Reason,
                AmountMoney,
                Status)
                .CreatedAt(CreatedAt)
                .ProcessingFeeMoney(ProcessingFeeMoney)
                .AdditionalRecipients(AdditionalRecipients);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string locationId;
            private string transactionId;
            private string tenderId;
            private string reason;
            private Models.Money amountMoney;
            private string status;
            private string createdAt;
            private Models.Money processingFeeMoney;
            private IList<Models.AdditionalRecipient> additionalRecipients;

            public Builder(string id,
                string locationId,
                string transactionId,
                string tenderId,
                string reason,
                Models.Money amountMoney,
                string status)
            {
                this.id = id;
                this.locationId = locationId;
                this.transactionId = transactionId;
                this.tenderId = tenderId;
                this.reason = reason;
                this.amountMoney = amountMoney;
                this.status = status;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public Builder TransactionId(string transactionId)
            {
                this.transactionId = transactionId;
                return this;
            }

            public Builder TenderId(string tenderId)
            {
                this.tenderId = tenderId;
                return this;
            }

            public Builder Reason(string reason)
            {
                this.reason = reason;
                return this;
            }

            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder ProcessingFeeMoney(Models.Money processingFeeMoney)
            {
                this.processingFeeMoney = processingFeeMoney;
                return this;
            }

            public Builder AdditionalRecipients(IList<Models.AdditionalRecipient> additionalRecipients)
            {
                this.additionalRecipients = additionalRecipients;
                return this;
            }

            public Refund Build()
            {
                return new Refund(id,
                    locationId,
                    transactionId,
                    tenderId,
                    reason,
                    amountMoney,
                    status,
                    createdAt,
                    processingFeeMoney,
                    additionalRecipients);
            }
        }
    }
}