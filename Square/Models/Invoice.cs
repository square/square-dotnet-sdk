
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
            string deliveryMethod = null,
            string invoiceNumber = null,
            string title = null,
            string description = null,
            string scheduledAt = null,
            string publicUrl = null,
            Models.Money nextPaymentAmountMoney = null,
            string status = null,
            string timezone = null,
            string createdAt = null,
            string updatedAt = null,
            IList<Models.InvoiceCustomField> customFields = null)
        {
            Id = id;
            Version = version;
            LocationId = locationId;
            OrderId = orderId;
            PrimaryRecipient = primaryRecipient;
            PaymentRequests = paymentRequests;
            DeliveryMethod = deliveryMethod;
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
            CustomFields = customFields;
        }

        /// <summary>
        /// The Square-assigned ID of the invoice.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The Square-assigned version number, which is incremented each time an update is committed to the invoice.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// The ID of the location that this invoice is associated with.
        /// This field is required when creating an invoice.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The ID of the [order](#type-order) for which the invoice is created.
        /// This order must be in the `OPEN` state and must belong to the `location_id`
        /// specified for this invoice. This field is required when creating an invoice.
        /// </summary>
        [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; }

        /// <summary>
        /// Provides customer data that Square uses to deliver an invoice.
        /// </summary>
        [JsonProperty("primary_recipient", NullValueHandling = NullValueHandling.Ignore)]
        public Models.InvoiceRecipient PrimaryRecipient { get; }

        /// <summary>
        /// The payment schedule for the invoice, represented by one or more payment requests that
        /// define payment settings, such as amount due and due date. You can specify a maximum of 13
        /// payment requests, with up to 12 `INSTALLMENT` request types. For more information, see
        /// [Payment requests](https://developer.squareup.com/docs/invoices-api/overview#payment-requests).
        /// This field is required when creating an invoice. It must contain at least one payment request.
        /// </summary>
        [JsonProperty("payment_requests", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.InvoicePaymentRequest> PaymentRequests { get; }

        /// <summary>
        /// Indicates how Square delivers the [invoice](#type-Invoice) to the customer.
        /// </summary>
        [JsonProperty("delivery_method", NullValueHandling = NullValueHandling.Ignore)]
        public string DeliveryMethod { get; }

        /// <summary>
        /// A user-friendly invoice number. The value is unique within a location.
        /// If not provided when creating an invoice, Square assigns a value.
        /// It increments from 1 and padded with zeros making it 7 characters long
        /// for example, 0000001, 0000002.
        /// </summary>
        [JsonProperty("invoice_number", NullValueHandling = NullValueHandling.Ignore)]
        public string InvoiceNumber { get; }

        /// <summary>
        /// The title of the invoice.
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; }

        /// <summary>
        /// The description of the invoice. This is visible to the customer receiving the invoice.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; }

        /// <summary>
        /// The timestamp when the invoice is scheduled for processing, in RFC 3339 format.
        /// After the invoice is published, Square processes the invoice on the specified date, according to the delivery method and payment request settings.
        /// If the field is not set, Square processes the invoice immediately after it is published.
        /// </summary>
        [JsonProperty("scheduled_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ScheduledAt { get; }

        /// <summary>
        /// The URL of the Square-hosted invoice page.
        /// After you publish the invoice using the `PublishInvoice` endpoint, Square hosts the invoice
        /// page and returns the page URL in the response.
        /// </summary>
        [JsonProperty("public_url", NullValueHandling = NullValueHandling.Ignore)]
        public string PublicUrl { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("next_payment_amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money NextPaymentAmountMoney { get; }

        /// <summary>
        /// Indicates the status of an invoice.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// The time zone of the date values (for example, `due_date`) specified in the invoice.
        /// </summary>
        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string Timezone { get; }

        /// <summary>
        /// The timestamp when the invoice was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the invoice was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// Additional seller-defined fields to render on the invoice. These fields are visible to sellers and buyers
        /// on the Square-hosted invoice page and in emailed or PDF copies of invoices. For more information, see
        /// [Custom fields](https://developer.squareup.com/docs/invoices-api/overview#custom-fields).
        /// Max: 2 custom fields
        /// </summary>
        [JsonProperty("custom_fields", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.InvoiceCustomField> CustomFields { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Invoice : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"Version = {(Version == null ? "null" : Version.ToString())}");
            toStringOutput.Add($"LocationId = {(LocationId == null ? "null" : LocationId == string.Empty ? "" : LocationId)}");
            toStringOutput.Add($"OrderId = {(OrderId == null ? "null" : OrderId == string.Empty ? "" : OrderId)}");
            toStringOutput.Add($"PrimaryRecipient = {(PrimaryRecipient == null ? "null" : PrimaryRecipient.ToString())}");
            toStringOutput.Add($"PaymentRequests = {(PaymentRequests == null ? "null" : $"[{ string.Join(", ", PaymentRequests)} ]")}");
            toStringOutput.Add($"DeliveryMethod = {(DeliveryMethod == null ? "null" : DeliveryMethod.ToString())}");
            toStringOutput.Add($"InvoiceNumber = {(InvoiceNumber == null ? "null" : InvoiceNumber == string.Empty ? "" : InvoiceNumber)}");
            toStringOutput.Add($"Title = {(Title == null ? "null" : Title == string.Empty ? "" : Title)}");
            toStringOutput.Add($"Description = {(Description == null ? "null" : Description == string.Empty ? "" : Description)}");
            toStringOutput.Add($"ScheduledAt = {(ScheduledAt == null ? "null" : ScheduledAt == string.Empty ? "" : ScheduledAt)}");
            toStringOutput.Add($"PublicUrl = {(PublicUrl == null ? "null" : PublicUrl == string.Empty ? "" : PublicUrl)}");
            toStringOutput.Add($"NextPaymentAmountMoney = {(NextPaymentAmountMoney == null ? "null" : NextPaymentAmountMoney.ToString())}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status.ToString())}");
            toStringOutput.Add($"Timezone = {(Timezone == null ? "null" : Timezone == string.Empty ? "" : Timezone)}");
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
            toStringOutput.Add($"UpdatedAt = {(UpdatedAt == null ? "null" : UpdatedAt == string.Empty ? "" : UpdatedAt)}");
            toStringOutput.Add($"CustomFields = {(CustomFields == null ? "null" : $"[{ string.Join(", ", CustomFields)} ]")}");
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

            return obj is Invoice other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((Version == null && other.Version == null) || (Version?.Equals(other.Version) == true)) &&
                ((LocationId == null && other.LocationId == null) || (LocationId?.Equals(other.LocationId) == true)) &&
                ((OrderId == null && other.OrderId == null) || (OrderId?.Equals(other.OrderId) == true)) &&
                ((PrimaryRecipient == null && other.PrimaryRecipient == null) || (PrimaryRecipient?.Equals(other.PrimaryRecipient) == true)) &&
                ((PaymentRequests == null && other.PaymentRequests == null) || (PaymentRequests?.Equals(other.PaymentRequests) == true)) &&
                ((DeliveryMethod == null && other.DeliveryMethod == null) || (DeliveryMethod?.Equals(other.DeliveryMethod) == true)) &&
                ((InvoiceNumber == null && other.InvoiceNumber == null) || (InvoiceNumber?.Equals(other.InvoiceNumber) == true)) &&
                ((Title == null && other.Title == null) || (Title?.Equals(other.Title) == true)) &&
                ((Description == null && other.Description == null) || (Description?.Equals(other.Description) == true)) &&
                ((ScheduledAt == null && other.ScheduledAt == null) || (ScheduledAt?.Equals(other.ScheduledAt) == true)) &&
                ((PublicUrl == null && other.PublicUrl == null) || (PublicUrl?.Equals(other.PublicUrl) == true)) &&
                ((NextPaymentAmountMoney == null && other.NextPaymentAmountMoney == null) || (NextPaymentAmountMoney?.Equals(other.NextPaymentAmountMoney) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true)) &&
                ((Timezone == null && other.Timezone == null) || (Timezone?.Equals(other.Timezone) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((UpdatedAt == null && other.UpdatedAt == null) || (UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((CustomFields == null && other.CustomFields == null) || (CustomFields?.Equals(other.CustomFields) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1321207967;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (Version != null)
            {
               hashCode += Version.GetHashCode();
            }

            if (LocationId != null)
            {
               hashCode += LocationId.GetHashCode();
            }

            if (OrderId != null)
            {
               hashCode += OrderId.GetHashCode();
            }

            if (PrimaryRecipient != null)
            {
               hashCode += PrimaryRecipient.GetHashCode();
            }

            if (PaymentRequests != null)
            {
               hashCode += PaymentRequests.GetHashCode();
            }

            if (DeliveryMethod != null)
            {
               hashCode += DeliveryMethod.GetHashCode();
            }

            if (InvoiceNumber != null)
            {
               hashCode += InvoiceNumber.GetHashCode();
            }

            if (Title != null)
            {
               hashCode += Title.GetHashCode();
            }

            if (Description != null)
            {
               hashCode += Description.GetHashCode();
            }

            if (ScheduledAt != null)
            {
               hashCode += ScheduledAt.GetHashCode();
            }

            if (PublicUrl != null)
            {
               hashCode += PublicUrl.GetHashCode();
            }

            if (NextPaymentAmountMoney != null)
            {
               hashCode += NextPaymentAmountMoney.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }

            if (Timezone != null)
            {
               hashCode += Timezone.GetHashCode();
            }

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            if (UpdatedAt != null)
            {
               hashCode += UpdatedAt.GetHashCode();
            }

            if (CustomFields != null)
            {
               hashCode += CustomFields.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .Version(Version)
                .LocationId(LocationId)
                .OrderId(OrderId)
                .PrimaryRecipient(PrimaryRecipient)
                .PaymentRequests(PaymentRequests)
                .DeliveryMethod(DeliveryMethod)
                .InvoiceNumber(InvoiceNumber)
                .Title(Title)
                .Description(Description)
                .ScheduledAt(ScheduledAt)
                .PublicUrl(PublicUrl)
                .NextPaymentAmountMoney(NextPaymentAmountMoney)
                .Status(Status)
                .Timezone(Timezone)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt)
                .CustomFields(CustomFields);
            return builder;
        }

        public class Builder
        {
            private string id;
            private int? version;
            private string locationId;
            private string orderId;
            private Models.InvoiceRecipient primaryRecipient;
            private IList<Models.InvoicePaymentRequest> paymentRequests;
            private string deliveryMethod;
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
            private IList<Models.InvoiceCustomField> customFields;



            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Version(int? version)
            {
                this.version = version;
                return this;
            }

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
                return this;
            }

            public Builder PrimaryRecipient(Models.InvoiceRecipient primaryRecipient)
            {
                this.primaryRecipient = primaryRecipient;
                return this;
            }

            public Builder PaymentRequests(IList<Models.InvoicePaymentRequest> paymentRequests)
            {
                this.paymentRequests = paymentRequests;
                return this;
            }

            public Builder DeliveryMethod(string deliveryMethod)
            {
                this.deliveryMethod = deliveryMethod;
                return this;
            }

            public Builder InvoiceNumber(string invoiceNumber)
            {
                this.invoiceNumber = invoiceNumber;
                return this;
            }

            public Builder Title(string title)
            {
                this.title = title;
                return this;
            }

            public Builder Description(string description)
            {
                this.description = description;
                return this;
            }

            public Builder ScheduledAt(string scheduledAt)
            {
                this.scheduledAt = scheduledAt;
                return this;
            }

            public Builder PublicUrl(string publicUrl)
            {
                this.publicUrl = publicUrl;
                return this;
            }

            public Builder NextPaymentAmountMoney(Models.Money nextPaymentAmountMoney)
            {
                this.nextPaymentAmountMoney = nextPaymentAmountMoney;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public Builder Timezone(string timezone)
            {
                this.timezone = timezone;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            public Builder CustomFields(IList<Models.InvoiceCustomField> customFields)
            {
                this.customFields = customFields;
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
                    deliveryMethod,
                    invoiceNumber,
                    title,
                    description,
                    scheduledAt,
                    publicUrl,
                    nextPaymentAmountMoney,
                    status,
                    timezone,
                    createdAt,
                    updatedAt,
                    customFields);
            }
        }
    }
}