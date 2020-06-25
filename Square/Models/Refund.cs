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
        [JsonProperty("created_at")]
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
        [JsonProperty("processing_fee_money")]
        public Models.Money ProcessingFeeMoney { get; }

        /// <summary>
        /// Additional recipients (other than the merchant) receiving a portion of this refund.
        /// For example, fees assessed on a refund of a purchase by a third party integration.
        /// </summary>
        [JsonProperty("additional_recipients")]
        public IList<Models.AdditionalRecipient> AdditionalRecipients { get; }

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
            private IList<Models.AdditionalRecipient> additionalRecipients = new List<Models.AdditionalRecipient>();

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
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public Builder TransactionId(string value)
            {
                transactionId = value;
                return this;
            }

            public Builder TenderId(string value)
            {
                tenderId = value;
                return this;
            }

            public Builder Reason(string value)
            {
                reason = value;
                return this;
            }

            public Builder AmountMoney(Models.Money value)
            {
                amountMoney = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public Builder ProcessingFeeMoney(Models.Money value)
            {
                processingFeeMoney = value;
                return this;
            }

            public Builder AdditionalRecipients(IList<Models.AdditionalRecipient> value)
            {
                additionalRecipients = value;
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