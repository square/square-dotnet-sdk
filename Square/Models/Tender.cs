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
    public class Tender 
    {
        public Tender(string type,
            string id = null,
            string locationId = null,
            string transactionId = null,
            string createdAt = null,
            string note = null,
            Models.Money amountMoney = null,
            Models.Money tipMoney = null,
            Models.Money processingFeeMoney = null,
            string customerId = null,
            Models.TenderCardDetails cardDetails = null,
            Models.TenderCashDetails cashDetails = null,
            IList<Models.AdditionalRecipient> additionalRecipients = null,
            string paymentId = null)
        {
            Id = id;
            LocationId = locationId;
            TransactionId = transactionId;
            CreatedAt = createdAt;
            Note = note;
            AmountMoney = amountMoney;
            TipMoney = tipMoney;
            ProcessingFeeMoney = processingFeeMoney;
            CustomerId = customerId;
            Type = type;
            CardDetails = cardDetails;
            CashDetails = cashDetails;
            AdditionalRecipients = additionalRecipients;
            PaymentId = paymentId;
        }

        /// <summary>
        /// The tender's unique ID.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The ID of the transaction's associated location.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The ID of the tender's associated transaction.
        /// </summary>
        [JsonProperty("transaction_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionId { get; }

        /// <summary>
        /// The timestamp for when the tender was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// An optional note associated with the tender at the time of payment.
        /// </summary>
        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AmountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("tip_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TipMoney { get; }

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
        /// If the tender is associated with a customer or represents a customer's card on file,
        /// this is the ID of the associated customer.
        /// </summary>
        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; }

        /// <summary>
        /// Indicates a tender's type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// Represents additional details of a tender with `type` `CARD` or `SQUARE_GIFT_CARD`
        /// </summary>
        [JsonProperty("card_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TenderCardDetails CardDetails { get; }

        /// <summary>
        /// Represents the details of a tender with `type` `CASH`.
        /// </summary>
        [JsonProperty("cash_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TenderCashDetails CashDetails { get; }

        /// <summary>
        /// Additional recipients (other than the merchant) receiving a portion of this tender.
        /// For example, fees assessed on the purchase by a third party integration.
        /// </summary>
        [JsonProperty("additional_recipients", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.AdditionalRecipient> AdditionalRecipients { get; }

        /// <summary>
        /// The ID of the [Payment](#type-payment) that corresponds to this tender.
        /// This value is only present for payments created with the v2 Payments API.
        /// </summary>
        [JsonProperty("payment_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Type)
                .Id(Id)
                .LocationId(LocationId)
                .TransactionId(TransactionId)
                .CreatedAt(CreatedAt)
                .Note(Note)
                .AmountMoney(AmountMoney)
                .TipMoney(TipMoney)
                .ProcessingFeeMoney(ProcessingFeeMoney)
                .CustomerId(CustomerId)
                .CardDetails(CardDetails)
                .CashDetails(CashDetails)
                .AdditionalRecipients(AdditionalRecipients)
                .PaymentId(PaymentId);
            return builder;
        }

        public class Builder
        {
            private string type;
            private string id;
            private string locationId;
            private string transactionId;
            private string createdAt;
            private string note;
            private Models.Money amountMoney;
            private Models.Money tipMoney;
            private Models.Money processingFeeMoney;
            private string customerId;
            private Models.TenderCardDetails cardDetails;
            private Models.TenderCashDetails cashDetails;
            private IList<Models.AdditionalRecipient> additionalRecipients;
            private string paymentId;

            public Builder(string type)
            {
                this.type = type;
            }

            public Builder Type(string type)
            {
                this.type = type;
                return this;
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

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder Note(string note)
            {
                this.note = note;
                return this;
            }

            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

            public Builder TipMoney(Models.Money tipMoney)
            {
                this.tipMoney = tipMoney;
                return this;
            }

            public Builder ProcessingFeeMoney(Models.Money processingFeeMoney)
            {
                this.processingFeeMoney = processingFeeMoney;
                return this;
            }

            public Builder CustomerId(string customerId)
            {
                this.customerId = customerId;
                return this;
            }

            public Builder CardDetails(Models.TenderCardDetails cardDetails)
            {
                this.cardDetails = cardDetails;
                return this;
            }

            public Builder CashDetails(Models.TenderCashDetails cashDetails)
            {
                this.cashDetails = cashDetails;
                return this;
            }

            public Builder AdditionalRecipients(IList<Models.AdditionalRecipient> additionalRecipients)
            {
                this.additionalRecipients = additionalRecipients;
                return this;
            }

            public Builder PaymentId(string paymentId)
            {
                this.paymentId = paymentId;
                return this;
            }

            public Tender Build()
            {
                return new Tender(type,
                    id,
                    locationId,
                    transactionId,
                    createdAt,
                    note,
                    amountMoney,
                    tipMoney,
                    processingFeeMoney,
                    customerId,
                    cardDetails,
                    cashDetails,
                    additionalRecipients,
                    paymentId);
            }
        }
    }
}