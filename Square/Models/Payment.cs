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
    public class Payment 
    {
        public Payment(string id = null,
            string createdAt = null,
            string updatedAt = null,
            Models.Money amountMoney = null,
            Models.Money tipMoney = null,
            Models.Money totalMoney = null,
            Models.Money appFeeMoney = null,
            IList<Models.ProcessingFee> processingFee = null,
            Models.Money refundedMoney = null,
            string status = null,
            string delayDuration = null,
            string delayAction = null,
            string delayedUntil = null,
            string sourceType = null,
            Models.CardPaymentDetails cardDetails = null,
            string locationId = null,
            string orderId = null,
            string referenceId = null,
            string customerId = null,
            string employeeId = null,
            IList<string> refundIds = null,
            string buyerEmailAddress = null,
            Models.Address billingAddress = null,
            Models.Address shippingAddress = null,
            string note = null,
            string statementDescriptionIdentifier = null,
            string receiptNumber = null,
            string receiptUrl = null)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            AmountMoney = amountMoney;
            TipMoney = tipMoney;
            TotalMoney = totalMoney;
            AppFeeMoney = appFeeMoney;
            ProcessingFee = processingFee;
            RefundedMoney = refundedMoney;
            Status = status;
            DelayDuration = delayDuration;
            DelayAction = delayAction;
            DelayedUntil = delayedUntil;
            SourceType = sourceType;
            CardDetails = cardDetails;
            LocationId = locationId;
            OrderId = orderId;
            ReferenceId = referenceId;
            CustomerId = customerId;
            EmployeeId = employeeId;
            RefundIds = refundIds;
            BuyerEmailAddress = buyerEmailAddress;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            Note = note;
            StatementDescriptionIdentifier = statementDescriptionIdentifier;
            ReceiptNumber = receiptNumber;
            ReceiptUrl = receiptUrl;
        }

        /// <summary>
        /// Unique ID for the payment.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// Timestamp of when the payment was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// Timestamp of when the payment was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; }

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
        [JsonProperty("total_money")]
        public Models.Money TotalMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("app_fee_money")]
        public Models.Money AppFeeMoney { get; }

        /// <summary>
        /// Processing fees and fee adjustments assessed by Square on this payment.
        /// </summary>
        [JsonProperty("processing_fee")]
        public IList<Models.ProcessingFee> ProcessingFee { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("refunded_money")]
        public Models.Money RefundedMoney { get; }

        /// <summary>
        /// Indicates whether the payment is `APPROVED`, `COMPLETED`, `CANCELED`, or `FAILED`.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// The duration of time after the payment's creation when Square automatically applies the
        /// `delay_action` to the payment. This automatic `delay_action` applies only to payments that
        /// don't reach a terminal state (COMPLETED, CANCELED, or FAILED) before the `delay_duration`
        /// time period.
        /// This field is specified as a time duration, in RFC 3339 format.
        /// Notes:
        /// This feature is only supported for card payments.
        /// Default:
        /// - Card Present payments: "PT36H" (36 hours) from the creation time.
        /// - Card Not Present payments: "P7D" (7 days) from the creation time.
        /// </summary>
        [JsonProperty("delay_duration")]
        public string DelayDuration { get; }

        /// <summary>
        /// The action to be applied to the payment when the `delay_duration` has elapsed. This field
        /// is read only.
        /// Current values include:
        /// `CANCEL`
        /// </summary>
        [JsonProperty("delay_action")]
        public string DelayAction { get; }

        /// <summary>
        /// Read only timestamp of when the `delay_action` will automatically be applied,
        /// in RFC 3339 format.
        /// Note that this field is calculated by summing the payment's `delay_duration` and `created_at`
        /// fields. The `created_at` field is generated by Square and may not exactly match the
        /// time on your local machine.
        /// </summary>
        [JsonProperty("delayed_until")]
        public string DelayedUntil { get; }

        /// <summary>
        /// The source type for this payment
        /// Current values include: `CARD`.
        /// </summary>
        [JsonProperty("source_type")]
        public string SourceType { get; }

        /// <summary>
        /// Reflects the current status of a card payment.
        /// </summary>
        [JsonProperty("card_details")]
        public Models.CardPaymentDetails CardDetails { get; }

        /// <summary>
        /// ID of the location associated with the payment.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// ID of the order associated with this payment.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <summary>
        /// An optional ID that associates this payment with an entity in
        /// another system.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// The [Customer](#type-customer) ID of the customer associated with the payment.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <summary>
        /// An optional ID of the employee associated with taking this payment.
        /// </summary>
        [JsonProperty("employee_id")]
        public string EmployeeId { get; }

        /// <summary>
        /// List of `refund_id`s identifying refunds for this payment.
        /// </summary>
        [JsonProperty("refund_ids")]
        public IList<string> RefundIds { get; }

        /// <summary>
        /// The buyer's e-mail address
        /// </summary>
        [JsonProperty("buyer_email_address")]
        public string BuyerEmailAddress { get; }

        /// <summary>
        /// Represents a physical address.
        /// </summary>
        [JsonProperty("billing_address")]
        public Models.Address BillingAddress { get; }

        /// <summary>
        /// Represents a physical address.
        /// </summary>
        [JsonProperty("shipping_address")]
        public Models.Address ShippingAddress { get; }

        /// <summary>
        /// An optional note to include when creating a payment
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; }

        /// <summary>
        /// Additional payment information that gets added on the customer's card statement
        /// as part of the statement description.
        /// Note that the `statement_description_identifier` may get truncated on the statement description
        /// to fit the required information including the Square identifier (SQ *) and name of the
        /// merchant taking the payment.
        /// </summary>
        [JsonProperty("statement_description_identifier")]
        public string StatementDescriptionIdentifier { get; }

        /// <summary>
        /// The payment's receipt number.
        /// The field will be missing if a payment is CANCELED
        /// </summary>
        [JsonProperty("receipt_number")]
        public string ReceiptNumber { get; }

        /// <summary>
        /// The URL for the payment's receipt.
        /// The field will only be populated for COMPLETED payments.
        /// </summary>
        [JsonProperty("receipt_url")]
        public string ReceiptUrl { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt)
                .AmountMoney(AmountMoney)
                .TipMoney(TipMoney)
                .TotalMoney(TotalMoney)
                .AppFeeMoney(AppFeeMoney)
                .ProcessingFee(ProcessingFee)
                .RefundedMoney(RefundedMoney)
                .Status(Status)
                .DelayDuration(DelayDuration)
                .DelayAction(DelayAction)
                .DelayedUntil(DelayedUntil)
                .SourceType(SourceType)
                .CardDetails(CardDetails)
                .LocationId(LocationId)
                .OrderId(OrderId)
                .ReferenceId(ReferenceId)
                .CustomerId(CustomerId)
                .EmployeeId(EmployeeId)
                .RefundIds(RefundIds)
                .BuyerEmailAddress(BuyerEmailAddress)
                .BillingAddress(BillingAddress)
                .ShippingAddress(ShippingAddress)
                .Note(Note)
                .StatementDescriptionIdentifier(StatementDescriptionIdentifier)
                .ReceiptNumber(ReceiptNumber)
                .ReceiptUrl(ReceiptUrl);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string createdAt;
            private string updatedAt;
            private Models.Money amountMoney;
            private Models.Money tipMoney;
            private Models.Money totalMoney;
            private Models.Money appFeeMoney;
            private IList<Models.ProcessingFee> processingFee = new List<Models.ProcessingFee>();
            private Models.Money refundedMoney;
            private string status;
            private string delayDuration;
            private string delayAction;
            private string delayedUntil;
            private string sourceType;
            private Models.CardPaymentDetails cardDetails;
            private string locationId;
            private string orderId;
            private string referenceId;
            private string customerId;
            private string employeeId;
            private IList<string> refundIds = new List<string>();
            private string buyerEmailAddress;
            private Models.Address billingAddress;
            private Models.Address shippingAddress;
            private string note;
            private string statementDescriptionIdentifier;
            private string receiptNumber;
            private string receiptUrl;

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public Builder UpdatedAt(string value)
            {
                updatedAt = value;
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

            public Builder TotalMoney(Models.Money value)
            {
                totalMoney = value;
                return this;
            }

            public Builder AppFeeMoney(Models.Money value)
            {
                appFeeMoney = value;
                return this;
            }

            public Builder ProcessingFee(IList<Models.ProcessingFee> value)
            {
                processingFee = value;
                return this;
            }

            public Builder RefundedMoney(Models.Money value)
            {
                refundedMoney = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder DelayDuration(string value)
            {
                delayDuration = value;
                return this;
            }

            public Builder DelayAction(string value)
            {
                delayAction = value;
                return this;
            }

            public Builder DelayedUntil(string value)
            {
                delayedUntil = value;
                return this;
            }

            public Builder SourceType(string value)
            {
                sourceType = value;
                return this;
            }

            public Builder CardDetails(Models.CardPaymentDetails value)
            {
                cardDetails = value;
                return this;
            }

            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public Builder OrderId(string value)
            {
                orderId = value;
                return this;
            }

            public Builder ReferenceId(string value)
            {
                referenceId = value;
                return this;
            }

            public Builder CustomerId(string value)
            {
                customerId = value;
                return this;
            }

            public Builder EmployeeId(string value)
            {
                employeeId = value;
                return this;
            }

            public Builder RefundIds(IList<string> value)
            {
                refundIds = value;
                return this;
            }

            public Builder BuyerEmailAddress(string value)
            {
                buyerEmailAddress = value;
                return this;
            }

            public Builder BillingAddress(Models.Address value)
            {
                billingAddress = value;
                return this;
            }

            public Builder ShippingAddress(Models.Address value)
            {
                shippingAddress = value;
                return this;
            }

            public Builder Note(string value)
            {
                note = value;
                return this;
            }

            public Builder StatementDescriptionIdentifier(string value)
            {
                statementDescriptionIdentifier = value;
                return this;
            }

            public Builder ReceiptNumber(string value)
            {
                receiptNumber = value;
                return this;
            }

            public Builder ReceiptUrl(string value)
            {
                receiptUrl = value;
                return this;
            }

            public Payment Build()
            {
                return new Payment(id,
                    createdAt,
                    updatedAt,
                    amountMoney,
                    tipMoney,
                    totalMoney,
                    appFeeMoney,
                    processingFee,
                    refundedMoney,
                    status,
                    delayDuration,
                    delayAction,
                    delayedUntil,
                    sourceType,
                    cardDetails,
                    locationId,
                    orderId,
                    referenceId,
                    customerId,
                    employeeId,
                    refundIds,
                    buyerEmailAddress,
                    billingAddress,
                    shippingAddress,
                    note,
                    statementDescriptionIdentifier,
                    receiptNumber,
                    receiptUrl);
            }
        }
    }
}