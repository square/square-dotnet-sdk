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
    /// Invoice.
    /// </summary>
    public class Invoice
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="Invoice"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="version">version.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="orderId">order_id.</param>
        /// <param name="primaryRecipient">primary_recipient.</param>
        /// <param name="paymentRequests">payment_requests.</param>
        /// <param name="deliveryMethod">delivery_method.</param>
        /// <param name="invoiceNumber">invoice_number.</param>
        /// <param name="title">title.</param>
        /// <param name="description">description.</param>
        /// <param name="scheduledAt">scheduled_at.</param>
        /// <param name="publicUrl">public_url.</param>
        /// <param name="nextPaymentAmountMoney">next_payment_amount_money.</param>
        /// <param name="status">status.</param>
        /// <param name="timezone">timezone.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="acceptedPaymentMethods">accepted_payment_methods.</param>
        /// <param name="customFields">custom_fields.</param>
        /// <param name="subscriptionId">subscription_id.</param>
        /// <param name="saleOrServiceDate">sale_or_service_date.</param>
        /// <param name="paymentConditions">payment_conditions.</param>
        /// <param name="storePaymentMethodEnabled">store_payment_method_enabled.</param>
        public Invoice(
            string id = null,
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
            Models.InvoiceAcceptedPaymentMethods acceptedPaymentMethods = null,
            IList<Models.InvoiceCustomField> customFields = null,
            string subscriptionId = null,
            string saleOrServiceDate = null,
            string paymentConditions = null,
            bool? storePaymentMethodEnabled = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "location_id", false },
                { "order_id", false },
                { "payment_requests", false },
                { "invoice_number", false },
                { "title", false },
                { "description", false },
                { "scheduled_at", false },
                { "custom_fields", false },
                { "sale_or_service_date", false },
                { "payment_conditions", false },
                { "store_payment_method_enabled", false }
            };

            this.Id = id;
            this.Version = version;
            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

            if (orderId != null)
            {
                shouldSerialize["order_id"] = true;
                this.OrderId = orderId;
            }

            this.PrimaryRecipient = primaryRecipient;
            if (paymentRequests != null)
            {
                shouldSerialize["payment_requests"] = true;
                this.PaymentRequests = paymentRequests;
            }

            this.DeliveryMethod = deliveryMethod;
            if (invoiceNumber != null)
            {
                shouldSerialize["invoice_number"] = true;
                this.InvoiceNumber = invoiceNumber;
            }

            if (title != null)
            {
                shouldSerialize["title"] = true;
                this.Title = title;
            }

            if (description != null)
            {
                shouldSerialize["description"] = true;
                this.Description = description;
            }

            if (scheduledAt != null)
            {
                shouldSerialize["scheduled_at"] = true;
                this.ScheduledAt = scheduledAt;
            }

            this.PublicUrl = publicUrl;
            this.NextPaymentAmountMoney = nextPaymentAmountMoney;
            this.Status = status;
            this.Timezone = timezone;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.AcceptedPaymentMethods = acceptedPaymentMethods;
            if (customFields != null)
            {
                shouldSerialize["custom_fields"] = true;
                this.CustomFields = customFields;
            }

            this.SubscriptionId = subscriptionId;
            if (saleOrServiceDate != null)
            {
                shouldSerialize["sale_or_service_date"] = true;
                this.SaleOrServiceDate = saleOrServiceDate;
            }

            if (paymentConditions != null)
            {
                shouldSerialize["payment_conditions"] = true;
                this.PaymentConditions = paymentConditions;
            }

            if (storePaymentMethodEnabled != null)
            {
                shouldSerialize["store_payment_method_enabled"] = true;
                this.StorePaymentMethodEnabled = storePaymentMethodEnabled;
            }

        }
        internal Invoice(Dictionary<string, bool> shouldSerialize,
            string id = null,
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
            Models.InvoiceAcceptedPaymentMethods acceptedPaymentMethods = null,
            IList<Models.InvoiceCustomField> customFields = null,
            string subscriptionId = null,
            string saleOrServiceDate = null,
            string paymentConditions = null,
            bool? storePaymentMethodEnabled = null)
        {
            this.shouldSerialize = shouldSerialize;
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
            AcceptedPaymentMethods = acceptedPaymentMethods;
            CustomFields = customFields;
            SubscriptionId = subscriptionId;
            SaleOrServiceDate = saleOrServiceDate;
            PaymentConditions = paymentConditions;
            StorePaymentMethodEnabled = storePaymentMethodEnabled;
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
        /// If specified in a `CreateInvoice` request, the value must match the `location_id` of the associated order.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The ID of the [order]($m/Order) for which the invoice is created.
        /// This field is required when creating an invoice, and the order must be in the `OPEN` state.
        /// To view the line items and other information for the associated order, call the
        /// [RetrieveOrder]($e/Orders/RetrieveOrder) endpoint using the order ID.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <summary>
        /// Represents a snapshot of customer data. This object stores customer data that is displayed on the invoice
        /// and that Square uses to deliver the invoice.
        /// When you provide a customer ID for a draft invoice, Square retrieves the associated customer profile and populates
        /// the remaining `InvoiceRecipient` fields. You cannot update these fields after the invoice is published.
        /// Square updates the customer ID in response to a merge operation, but does not update other fields.
        /// </summary>
        [JsonProperty("primary_recipient", NullValueHandling = NullValueHandling.Ignore)]
        public Models.InvoiceRecipient PrimaryRecipient { get; }

        /// <summary>
        /// The payment schedule for the invoice, represented by one or more payment requests that
        /// define payment settings, such as amount due and due date. An invoice supports the following payment request combinations:
        /// - One balance
        /// - One deposit with one balance
        /// - 2–12 installments
        /// - One deposit with 2–12 installments
        /// This field is required when creating an invoice. It must contain at least one payment request.
        /// All payment requests for the invoice must equal the total order amount. For more information, see
        /// [Configuring payment requests](https://developer.squareup.com/docs/invoices-api/create-publish-invoices#payment-requests).
        /// Adding `INSTALLMENT` payment requests to an invoice requires an
        /// [Invoices Plus subscription](https://developer.squareup.com/docs/invoices-api/overview#invoices-plus-subscription).
        /// </summary>
        [JsonProperty("payment_requests")]
        public IList<Models.InvoicePaymentRequest> PaymentRequests { get; }

        /// <summary>
        /// Indicates how Square delivers the [invoice]($m/Invoice) to the customer.
        /// </summary>
        [JsonProperty("delivery_method", NullValueHandling = NullValueHandling.Ignore)]
        public string DeliveryMethod { get; }

        /// <summary>
        /// A user-friendly invoice number that is displayed on the invoice. The value is unique within a location.
        /// If not provided when creating an invoice, Square assigns a value.
        /// It increments from 1 and is padded with zeros making it 7 characters long
        /// (for example, 0000001 and 0000002).
        /// </summary>
        [JsonProperty("invoice_number")]
        public string InvoiceNumber { get; }

        /// <summary>
        /// The title of the invoice, which is displayed on the invoice.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; }

        /// <summary>
        /// The description of the invoice, which is displayed on the invoice.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <summary>
        /// The timestamp when the invoice is scheduled for processing, in RFC 3339 format.
        /// After the invoice is published, Square processes the invoice on the specified date,
        /// according to the delivery method and payment request settings.
        /// If the field is not set, Square processes the invoice immediately after it is published.
        /// </summary>
        [JsonProperty("scheduled_at")]
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
        /// The time zone used to interpret calendar dates on the invoice, such as `due_date`.
        /// When an invoice is created, this field is set to the `timezone` specified for the seller
        /// location. The value cannot be changed.
        /// For example, a payment `due_date` of 2021-03-09 with a `timezone` of America/Los\_Angeles
        /// becomes overdue at midnight on March 9 in America/Los\_Angeles (which equals a UTC timestamp
        /// of 2021-03-10T08:00:00Z).
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
        /// The payment methods that customers can use to pay an [invoice]($m/Invoice) on the Square-hosted invoice payment page.
        /// </summary>
        [JsonProperty("accepted_payment_methods", NullValueHandling = NullValueHandling.Ignore)]
        public Models.InvoiceAcceptedPaymentMethods AcceptedPaymentMethods { get; }

        /// <summary>
        /// Additional seller-defined fields that are displayed on the invoice. For more information, see
        /// [Custom fields](https://developer.squareup.com/docs/invoices-api/overview#custom-fields).
        /// Adding custom fields to an invoice requires an
        /// [Invoices Plus subscription](https://developer.squareup.com/docs/invoices-api/overview#invoices-plus-subscription).
        /// Max: 2 custom fields
        /// </summary>
        [JsonProperty("custom_fields")]
        public IList<Models.InvoiceCustomField> CustomFields { get; }

        /// <summary>
        /// The ID of the [subscription]($m/Subscription) associated with the invoice.
        /// This field is present only on subscription billing invoices.
        /// </summary>
        [JsonProperty("subscription_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SubscriptionId { get; }

        /// <summary>
        /// The date of the sale or the date that the service is rendered, in `YYYY-MM-DD` format.
        /// This field can be used to specify a past or future date which is displayed on the invoice.
        /// </summary>
        [JsonProperty("sale_or_service_date")]
        public string SaleOrServiceDate { get; }

        /// <summary>
        /// **France only.** The payment terms and conditions that are displayed on the invoice. For more information,
        /// see [Payment conditions](https://developer.squareup.com/docs/invoices-api/overview#payment-conditions).
        /// For countries other than France, Square returns an `INVALID_REQUEST_ERROR` with a `BAD_REQUEST` code and
        /// "Payment conditions are not supported for this location's country" detail if this field is included in `CreateInvoice` or `UpdateInvoice` requests.
        /// </summary>
        [JsonProperty("payment_conditions")]
        public string PaymentConditions { get; }

        /// <summary>
        /// Indicates whether to allow a customer to save a credit or debit card as a card on file or a bank transfer as a
        /// bank account on file. If `true`, Square displays a __Save my card on file__ or __Save my bank on file__ checkbox on the
        /// invoice payment page. Stored payment information can be used for future automatic payments. The default value is `false`.
        /// </summary>
        [JsonProperty("store_payment_method_enabled")]
        public bool? StorePaymentMethodEnabled { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Invoice : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeOrderId()
        {
            return this.shouldSerialize["order_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentRequests()
        {
            return this.shouldSerialize["payment_requests"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInvoiceNumber()
        {
            return this.shouldSerialize["invoice_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTitle()
        {
            return this.shouldSerialize["title"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDescription()
        {
            return this.shouldSerialize["description"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeScheduledAt()
        {
            return this.shouldSerialize["scheduled_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomFields()
        {
            return this.shouldSerialize["custom_fields"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSaleOrServiceDate()
        {
            return this.shouldSerialize["sale_or_service_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentConditions()
        {
            return this.shouldSerialize["payment_conditions"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStorePaymentMethodEnabled()
        {
            return this.shouldSerialize["store_payment_method_enabled"];
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

            return obj is Invoice other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true)) &&
                ((this.PrimaryRecipient == null && other.PrimaryRecipient == null) || (this.PrimaryRecipient?.Equals(other.PrimaryRecipient) == true)) &&
                ((this.PaymentRequests == null && other.PaymentRequests == null) || (this.PaymentRequests?.Equals(other.PaymentRequests) == true)) &&
                ((this.DeliveryMethod == null && other.DeliveryMethod == null) || (this.DeliveryMethod?.Equals(other.DeliveryMethod) == true)) &&
                ((this.InvoiceNumber == null && other.InvoiceNumber == null) || (this.InvoiceNumber?.Equals(other.InvoiceNumber) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.ScheduledAt == null && other.ScheduledAt == null) || (this.ScheduledAt?.Equals(other.ScheduledAt) == true)) &&
                ((this.PublicUrl == null && other.PublicUrl == null) || (this.PublicUrl?.Equals(other.PublicUrl) == true)) &&
                ((this.NextPaymentAmountMoney == null && other.NextPaymentAmountMoney == null) || (this.NextPaymentAmountMoney?.Equals(other.NextPaymentAmountMoney) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.Timezone == null && other.Timezone == null) || (this.Timezone?.Equals(other.Timezone) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.AcceptedPaymentMethods == null && other.AcceptedPaymentMethods == null) || (this.AcceptedPaymentMethods?.Equals(other.AcceptedPaymentMethods) == true)) &&
                ((this.CustomFields == null && other.CustomFields == null) || (this.CustomFields?.Equals(other.CustomFields) == true)) &&
                ((this.SubscriptionId == null && other.SubscriptionId == null) || (this.SubscriptionId?.Equals(other.SubscriptionId) == true)) &&
                ((this.SaleOrServiceDate == null && other.SaleOrServiceDate == null) || (this.SaleOrServiceDate?.Equals(other.SaleOrServiceDate) == true)) &&
                ((this.PaymentConditions == null && other.PaymentConditions == null) || (this.PaymentConditions?.Equals(other.PaymentConditions) == true)) &&
                ((this.StorePaymentMethodEnabled == null && other.StorePaymentMethodEnabled == null) || (this.StorePaymentMethodEnabled?.Equals(other.StorePaymentMethodEnabled) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1679181268;
            hashCode = HashCode.Combine(this.Id, this.Version, this.LocationId, this.OrderId, this.PrimaryRecipient, this.PaymentRequests, this.DeliveryMethod);

            hashCode = HashCode.Combine(hashCode, this.InvoiceNumber, this.Title, this.Description, this.ScheduledAt, this.PublicUrl, this.NextPaymentAmountMoney, this.Status);

            hashCode = HashCode.Combine(hashCode, this.Timezone, this.CreatedAt, this.UpdatedAt, this.AcceptedPaymentMethods, this.CustomFields, this.SubscriptionId, this.SaleOrServiceDate);

            hashCode = HashCode.Combine(hashCode, this.PaymentConditions, this.StorePaymentMethodEnabled);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId == string.Empty ? "" : this.OrderId)}");
            toStringOutput.Add($"this.PrimaryRecipient = {(this.PrimaryRecipient == null ? "null" : this.PrimaryRecipient.ToString())}");
            toStringOutput.Add($"this.PaymentRequests = {(this.PaymentRequests == null ? "null" : $"[{string.Join(", ", this.PaymentRequests)} ]")}");
            toStringOutput.Add($"this.DeliveryMethod = {(this.DeliveryMethod == null ? "null" : this.DeliveryMethod.ToString())}");
            toStringOutput.Add($"this.InvoiceNumber = {(this.InvoiceNumber == null ? "null" : this.InvoiceNumber == string.Empty ? "" : this.InvoiceNumber)}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title == string.Empty ? "" : this.Title)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.ScheduledAt = {(this.ScheduledAt == null ? "null" : this.ScheduledAt == string.Empty ? "" : this.ScheduledAt)}");
            toStringOutput.Add($"this.PublicUrl = {(this.PublicUrl == null ? "null" : this.PublicUrl == string.Empty ? "" : this.PublicUrl)}");
            toStringOutput.Add($"this.NextPaymentAmountMoney = {(this.NextPaymentAmountMoney == null ? "null" : this.NextPaymentAmountMoney.ToString())}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.Timezone = {(this.Timezone == null ? "null" : this.Timezone == string.Empty ? "" : this.Timezone)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
            toStringOutput.Add($"this.AcceptedPaymentMethods = {(this.AcceptedPaymentMethods == null ? "null" : this.AcceptedPaymentMethods.ToString())}");
            toStringOutput.Add($"this.CustomFields = {(this.CustomFields == null ? "null" : $"[{string.Join(", ", this.CustomFields)} ]")}");
            toStringOutput.Add($"this.SubscriptionId = {(this.SubscriptionId == null ? "null" : this.SubscriptionId == string.Empty ? "" : this.SubscriptionId)}");
            toStringOutput.Add($"this.SaleOrServiceDate = {(this.SaleOrServiceDate == null ? "null" : this.SaleOrServiceDate == string.Empty ? "" : this.SaleOrServiceDate)}");
            toStringOutput.Add($"this.PaymentConditions = {(this.PaymentConditions == null ? "null" : this.PaymentConditions == string.Empty ? "" : this.PaymentConditions)}");
            toStringOutput.Add($"this.StorePaymentMethodEnabled = {(this.StorePaymentMethodEnabled == null ? "null" : this.StorePaymentMethodEnabled.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .Version(this.Version)
                .LocationId(this.LocationId)
                .OrderId(this.OrderId)
                .PrimaryRecipient(this.PrimaryRecipient)
                .PaymentRequests(this.PaymentRequests)
                .DeliveryMethod(this.DeliveryMethod)
                .InvoiceNumber(this.InvoiceNumber)
                .Title(this.Title)
                .Description(this.Description)
                .ScheduledAt(this.ScheduledAt)
                .PublicUrl(this.PublicUrl)
                .NextPaymentAmountMoney(this.NextPaymentAmountMoney)
                .Status(this.Status)
                .Timezone(this.Timezone)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .AcceptedPaymentMethods(this.AcceptedPaymentMethods)
                .CustomFields(this.CustomFields)
                .SubscriptionId(this.SubscriptionId)
                .SaleOrServiceDate(this.SaleOrServiceDate)
                .PaymentConditions(this.PaymentConditions)
                .StorePaymentMethodEnabled(this.StorePaymentMethodEnabled);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "location_id", false },
                { "order_id", false },
                { "payment_requests", false },
                { "invoice_number", false },
                { "title", false },
                { "description", false },
                { "scheduled_at", false },
                { "custom_fields", false },
                { "sale_or_service_date", false },
                { "payment_conditions", false },
                { "store_payment_method_enabled", false },
            };

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
            private Models.InvoiceAcceptedPaymentMethods acceptedPaymentMethods;
            private IList<Models.InvoiceCustomField> customFields;
            private string subscriptionId;
            private string saleOrServiceDate;
            private string paymentConditions;
            private bool? storePaymentMethodEnabled;

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
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(int? version)
            {
                this.version = version;
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
             /// OrderId.
             /// </summary>
             /// <param name="orderId"> orderId. </param>
             /// <returns> Builder. </returns>
            public Builder OrderId(string orderId)
            {
                shouldSerialize["order_id"] = true;
                this.orderId = orderId;
                return this;
            }

             /// <summary>
             /// PrimaryRecipient.
             /// </summary>
             /// <param name="primaryRecipient"> primaryRecipient. </param>
             /// <returns> Builder. </returns>
            public Builder PrimaryRecipient(Models.InvoiceRecipient primaryRecipient)
            {
                this.primaryRecipient = primaryRecipient;
                return this;
            }

             /// <summary>
             /// PaymentRequests.
             /// </summary>
             /// <param name="paymentRequests"> paymentRequests. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentRequests(IList<Models.InvoicePaymentRequest> paymentRequests)
            {
                shouldSerialize["payment_requests"] = true;
                this.paymentRequests = paymentRequests;
                return this;
            }

             /// <summary>
             /// DeliveryMethod.
             /// </summary>
             /// <param name="deliveryMethod"> deliveryMethod. </param>
             /// <returns> Builder. </returns>
            public Builder DeliveryMethod(string deliveryMethod)
            {
                this.deliveryMethod = deliveryMethod;
                return this;
            }

             /// <summary>
             /// InvoiceNumber.
             /// </summary>
             /// <param name="invoiceNumber"> invoiceNumber. </param>
             /// <returns> Builder. </returns>
            public Builder InvoiceNumber(string invoiceNumber)
            {
                shouldSerialize["invoice_number"] = true;
                this.invoiceNumber = invoiceNumber;
                return this;
            }

             /// <summary>
             /// Title.
             /// </summary>
             /// <param name="title"> title. </param>
             /// <returns> Builder. </returns>
            public Builder Title(string title)
            {
                shouldSerialize["title"] = true;
                this.title = title;
                return this;
            }

             /// <summary>
             /// Description.
             /// </summary>
             /// <param name="description"> description. </param>
             /// <returns> Builder. </returns>
            public Builder Description(string description)
            {
                shouldSerialize["description"] = true;
                this.description = description;
                return this;
            }

             /// <summary>
             /// ScheduledAt.
             /// </summary>
             /// <param name="scheduledAt"> scheduledAt. </param>
             /// <returns> Builder. </returns>
            public Builder ScheduledAt(string scheduledAt)
            {
                shouldSerialize["scheduled_at"] = true;
                this.scheduledAt = scheduledAt;
                return this;
            }

             /// <summary>
             /// PublicUrl.
             /// </summary>
             /// <param name="publicUrl"> publicUrl. </param>
             /// <returns> Builder. </returns>
            public Builder PublicUrl(string publicUrl)
            {
                this.publicUrl = publicUrl;
                return this;
            }

             /// <summary>
             /// NextPaymentAmountMoney.
             /// </summary>
             /// <param name="nextPaymentAmountMoney"> nextPaymentAmountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder NextPaymentAmountMoney(Models.Money nextPaymentAmountMoney)
            {
                this.nextPaymentAmountMoney = nextPaymentAmountMoney;
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
             /// Timezone.
             /// </summary>
             /// <param name="timezone"> timezone. </param>
             /// <returns> Builder. </returns>
            public Builder Timezone(string timezone)
            {
                this.timezone = timezone;
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
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

             /// <summary>
             /// AcceptedPaymentMethods.
             /// </summary>
             /// <param name="acceptedPaymentMethods"> acceptedPaymentMethods. </param>
             /// <returns> Builder. </returns>
            public Builder AcceptedPaymentMethods(Models.InvoiceAcceptedPaymentMethods acceptedPaymentMethods)
            {
                this.acceptedPaymentMethods = acceptedPaymentMethods;
                return this;
            }

             /// <summary>
             /// CustomFields.
             /// </summary>
             /// <param name="customFields"> customFields. </param>
             /// <returns> Builder. </returns>
            public Builder CustomFields(IList<Models.InvoiceCustomField> customFields)
            {
                shouldSerialize["custom_fields"] = true;
                this.customFields = customFields;
                return this;
            }

             /// <summary>
             /// SubscriptionId.
             /// </summary>
             /// <param name="subscriptionId"> subscriptionId. </param>
             /// <returns> Builder. </returns>
            public Builder SubscriptionId(string subscriptionId)
            {
                this.subscriptionId = subscriptionId;
                return this;
            }

             /// <summary>
             /// SaleOrServiceDate.
             /// </summary>
             /// <param name="saleOrServiceDate"> saleOrServiceDate. </param>
             /// <returns> Builder. </returns>
            public Builder SaleOrServiceDate(string saleOrServiceDate)
            {
                shouldSerialize["sale_or_service_date"] = true;
                this.saleOrServiceDate = saleOrServiceDate;
                return this;
            }

             /// <summary>
             /// PaymentConditions.
             /// </summary>
             /// <param name="paymentConditions"> paymentConditions. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentConditions(string paymentConditions)
            {
                shouldSerialize["payment_conditions"] = true;
                this.paymentConditions = paymentConditions;
                return this;
            }

             /// <summary>
             /// StorePaymentMethodEnabled.
             /// </summary>
             /// <param name="storePaymentMethodEnabled"> storePaymentMethodEnabled. </param>
             /// <returns> Builder. </returns>
            public Builder StorePaymentMethodEnabled(bool? storePaymentMethodEnabled)
            {
                shouldSerialize["store_payment_method_enabled"] = true;
                this.storePaymentMethodEnabled = storePaymentMethodEnabled;
                return this;
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
            public void UnsetOrderId()
            {
                this.shouldSerialize["order_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPaymentRequests()
            {
                this.shouldSerialize["payment_requests"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetInvoiceNumber()
            {
                this.shouldSerialize["invoice_number"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTitle()
            {
                this.shouldSerialize["title"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDescription()
            {
                this.shouldSerialize["description"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetScheduledAt()
            {
                this.shouldSerialize["scheduled_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCustomFields()
            {
                this.shouldSerialize["custom_fields"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSaleOrServiceDate()
            {
                this.shouldSerialize["sale_or_service_date"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPaymentConditions()
            {
                this.shouldSerialize["payment_conditions"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetStorePaymentMethodEnabled()
            {
                this.shouldSerialize["store_payment_method_enabled"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Invoice. </returns>
            public Invoice Build()
            {
                return new Invoice(shouldSerialize,
                    this.id,
                    this.version,
                    this.locationId,
                    this.orderId,
                    this.primaryRecipient,
                    this.paymentRequests,
                    this.deliveryMethod,
                    this.invoiceNumber,
                    this.title,
                    this.description,
                    this.scheduledAt,
                    this.publicUrl,
                    this.nextPaymentAmountMoney,
                    this.status,
                    this.timezone,
                    this.createdAt,
                    this.updatedAt,
                    this.acceptedPaymentMethods,
                    this.customFields,
                    this.subscriptionId,
                    this.saleOrServiceDate,
                    this.paymentConditions,
                    this.storePaymentMethodEnabled);
            }
        }
    }
}