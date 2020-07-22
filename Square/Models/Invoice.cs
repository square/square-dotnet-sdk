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
    public class Invoice 
    {
        public Invoice(string id = null,
            int? version = null,
            string locationId = null,
            string orderId = null,
            Models.InvoiceRecipient primaryRecipient = null,
            IList<Models.InvoicePaymentRequest> paymentRequests = null,
            string invoiceNumber = null,
            string title = null,
            string description = null,
            string scheduledAt = null,
            string publicUrl = null,
            Models.Money nextPaymentAmountMoney = null,
            string status = null,
            string timezone = null,
            string createdAt = null,
            string updatedAt = null)
        {
            Id = id;
            Version = version;
            LocationId = locationId;
            OrderId = orderId;
            PrimaryRecipient = primaryRecipient;
            PaymentRequests = paymentRequests;
            InvoiceNumber = invoiceNumber;
            Title = title;
            Description = description;
            ScheduledAt = scheduledAt;
            PublicUrl = publicUrl;
            NextPaymentAmountMoney = nextPaymentAmountMoney;
            Status = status;
            Timezone = timezone;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// The Square-assigned ID of the invoice.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The version number, which is incremented each time an update is committed to the invoice.
        /// </summary>
        [JsonProperty("version")]
        public int? Version { get; }

        /// <summary>
        /// The ID of the location that this invoice is associated with.
        /// This field is required when creating an invoice.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The ID of the [order](#type-order) for which the invoice is created.
        /// This order must be in the `OPEN` state and must belong to the `location_id`
        /// specified for this invoice. This field is required when creating an invoice.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <summary>
        /// Provides customer data that Square uses to deliver an invoice.
        /// </summary>
        [JsonProperty("primary_recipient")]
        public Models.InvoiceRecipient PrimaryRecipient { get; }

        /// <summary>
        /// An array of `InvoicePaymentRequest` objects. Each object defines
        /// a payment request in an invoice payment schedule. It provides information
        /// such as when and how Square processes payments. You can specify maximum of
        /// nine payment requests. All all the payment requests must specify the
        /// same `request_method`.
        /// This field is required when creating an invoice.
        /// </summary>
        [JsonProperty("payment_requests")]
        public IList<Models.InvoicePaymentRequest> PaymentRequests { get; }

        /// <summary>
        /// A user-friendly invoice number. The value is unique within a location.
        /// If not provided when creating an invoice, Square assigns a value.
        /// It increments from 1 and padded with zeros making it 7 characters long
        /// for example, 0000001, 0000002.
        /// </summary>
        [JsonProperty("invoice_number")]
        public string InvoiceNumber { get; }

        /// <summary>
        /// The title of the invoice.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; }

        /// <summary>
        /// The description of the invoice. This is visible the customer receiving the invoice.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <summary>
        /// The timestamp when the invoice is scheduled for processing, in RFC 3339 format.
        /// At the specified time, depending on the `request_method`, Square sends the
        /// invoice to the customer's email address or charge the customer's card on file.
        /// If the field is not set, Square processes the invoice immediately after publication.
        /// </summary>
        [JsonProperty("scheduled_at")]
        public string ScheduledAt { get; }

        /// <summary>
        /// The URL of the Square-hosted invoice page.
        /// After you publish the invoice using the `PublishInvoice` endpoint, Square hosts the invoice
        /// page and returns the page URL in the response.
        /// </summary>
        [JsonProperty("public_url")]
        public string PublicUrl { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("next_payment_amount_money")]
        public Models.Money NextPaymentAmountMoney { get; }

        /// <summary>
        /// Indicates the status of an invoice.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// The time zone of the date values (for example, `due_date`) specified in the invoice.
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; }

        /// <summary>
        /// The timestamp when the invoice was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the invoice was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .Version(Version)
                .LocationId(LocationId)
                .OrderId(OrderId)
                .PrimaryRecipient(PrimaryRecipient)
                .PaymentRequests(PaymentRequests)
                .InvoiceNumber(InvoiceNumber)
                .Title(Title)
                .Description(Description)
                .ScheduledAt(ScheduledAt)
                .PublicUrl(PublicUrl)
                .NextPaymentAmountMoney(NextPaymentAmountMoney)
                .Status(Status)
                .Timezone(Timezone)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt);
            return builder;
        }

        public class Builder
        {
            private string id;
            private int? version;
            private string locationId;
            private string orderId;
            private Models.InvoiceRecipient primaryRecipient;
            private IList<Models.InvoicePaymentRequest> paymentRequests = new List<Models.InvoicePaymentRequest>();
            private string invoiceNumber;
            private string title;
            private string description;
            private string scheduledAt;
            private string publicUrl;
            private Models.Money nextPaymentAmountMoney;
            private string status;
            private string timezone;
            private string createdAt;
            private string updatedAt;

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder Version(int? value)
            {
                version = value;
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

            public Builder PrimaryRecipient(Models.InvoiceRecipient value)
            {
                primaryRecipient = value;
                return this;
            }

            public Builder PaymentRequests(IList<Models.InvoicePaymentRequest> value)
            {
                paymentRequests = value;
                return this;
            }

            public Builder InvoiceNumber(string value)
            {
                invoiceNumber = value;
                return this;
            }

            public Builder Title(string value)
            {
                title = value;
                return this;
            }

            public Builder Description(string value)
            {
                description = value;
                return this;
            }

            public Builder ScheduledAt(string value)
            {
                scheduledAt = value;
                return this;
            }

            public Builder PublicUrl(string value)
            {
                publicUrl = value;
                return this;
            }

            public Builder NextPaymentAmountMoney(Models.Money value)
            {
                nextPaymentAmountMoney = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder Timezone(string value)
            {
                timezone = value;
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

            public Invoice Build()
            {
                return new Invoice(id,
                    version,
                    locationId,
                    orderId,
                    primaryRecipient,
                    paymentRequests,
                    invoiceNumber,
                    title,
                    description,
                    scheduledAt,
                    publicUrl,
                    nextPaymentAmountMoney,
                    status,
                    timezone,
                    createdAt,
                    updatedAt);
            }
        }
    }
}