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
            Models.TenderBankTransferDetails bankTransferDetails = null,
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
            BankTransferDetails = bankTransferDetails;
            AdditionalRecipients = additionalRecipients;
            PaymentId = paymentId;
        }

        /// <summary>
        /// The tender's unique ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The ID of the transaction's associated location.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The ID of the tender's associated transaction.
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; }

        /// <summary>
        /// The timestamp for when the tender was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// An optional note associated with the tender at the time of payment.
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; }

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
        [JsonProperty("tip_money")]
        public Models.Money TipMoney { get; }

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
        /// If the tender is associated with a customer or represents a customer's card on file,
        /// this is the ID of the associated customer.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <summary>
        /// Indicates a tender's type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// Represents additional details of a tender with `type` `CARD` or `SQUARE_GIFT_CARD`
        /// </summary>
        [JsonProperty("card_details")]
        public Models.TenderCardDetails CardDetails { get; }

        /// <summary>
        /// Represents the details of a tender with `type` `CASH`.
        /// </summary>
        [JsonProperty("cash_details")]
        public Models.TenderCashDetails CashDetails { get; }

        /// <summary>
        /// Represents the details of a tender with `type` `BANK_TRANSFER`.
        /// See [PaymentBankTransferDetails](#type-paymentbanktransferdetails) for more exposed details of a bank transfer payment.
        /// </summary>
        [JsonProperty("bank_transfer_details")]
        public Models.TenderBankTransferDetails BankTransferDetails { get; }

        /// <summary>
        /// Additional recipients (other than the merchant) receiving a portion of this tender.
        /// For example, fees assessed on the purchase by a third party integration.
        /// </summary>
        [JsonProperty("additional_recipients")]
        public IList<Models.AdditionalRecipient> AdditionalRecipients { get; }

        /// <summary>
        /// The ID of the [Payment](#type-payment) that corresponds to this tender.
        /// This value is only present for payments created with the v2 Payments API.
        /// </summary>
        [JsonProperty("payment_id")]
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
                .BankTransferDetails(BankTransferDetails)
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
            private Models.TenderBankTransferDetails bankTransferDetails;
            private IList<Models.AdditionalRecipient> additionalRecipients = new List<Models.AdditionalRecipient>();
            private string paymentId;

            public Builder(string type)
            {
                this.type = type;
            }
            public Builder Type(string value)
            {
                type = value;
                return this;
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

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public Builder Note(string value)
            {
                note = value;
                return this;
            }

            public Builder AmountMoney(Models.Money value)
            {
                amountMoney = value;
                return this;
            }

            public Builder TipMoney(Models.Money value)
            {
                tipMoney = value;
                return this;
            }

            public Builder ProcessingFeeMoney(Models.Money value)
            {
                processingFeeMoney = value;
                return this;
            }

            public Builder CustomerId(string value)
            {
                customerId = value;
                return this;
            }

            public Builder CardDetails(Models.TenderCardDetails value)
            {
                cardDetails = value;
                return this;
            }

            public Builder CashDetails(Models.TenderCashDetails value)
            {
                cashDetails = value;
                return this;
            }

            public Builder BankTransferDetails(Models.TenderBankTransferDetails value)
            {
                bankTransferDetails = value;
                return this;
            }

            public Builder AdditionalRecipients(IList<Models.AdditionalRecipient> value)
            {
                additionalRecipients = value;
                return this;
            }

            public Builder PaymentId(string value)
            {
                paymentId = value;
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
                    bankTransferDetails,
                    additionalRecipients,
                    paymentId);
            }
        }
    }
}