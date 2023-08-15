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
    /// PaymentLink.
    /// </summary>
    public class PaymentLink
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentLink"/> class.
        /// </summary>
        /// <param name="version">version.</param>
        /// <param name="id">id.</param>
        /// <param name="description">description.</param>
        /// <param name="orderId">order_id.</param>
        /// <param name="checkoutOptions">checkout_options.</param>
        /// <param name="prePopulatedData">pre_populated_data.</param>
        /// <param name="url">url.</param>
        /// <param name="longUrl">long_url.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="paymentNote">payment_note.</param>
        public PaymentLink(
            int version,
            string id = null,
            string description = null,
            string orderId = null,
            Models.CheckoutOptions checkoutOptions = null,
            Models.PrePopulatedData prePopulatedData = null,
            string url = null,
            string longUrl = null,
            string createdAt = null,
            string updatedAt = null,
            string paymentNote = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "description", false },
                { "payment_note", false }
            };

            this.Id = id;
            this.Version = version;
            if (description != null)
            {
                shouldSerialize["description"] = true;
                this.Description = description;
            }

            this.OrderId = orderId;
            this.CheckoutOptions = checkoutOptions;
            this.PrePopulatedData = prePopulatedData;
            this.Url = url;
            this.LongUrl = longUrl;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            if (paymentNote != null)
            {
                shouldSerialize["payment_note"] = true;
                this.PaymentNote = paymentNote;
            }

        }
        internal PaymentLink(Dictionary<string, bool> shouldSerialize,
            int version,
            string id = null,
            string description = null,
            string orderId = null,
            Models.CheckoutOptions checkoutOptions = null,
            Models.PrePopulatedData prePopulatedData = null,
            string url = null,
            string longUrl = null,
            string createdAt = null,
            string updatedAt = null,
            string paymentNote = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            Version = version;
            Description = description;
            OrderId = orderId;
            CheckoutOptions = checkoutOptions;
            PrePopulatedData = prePopulatedData;
            Url = url;
            LongUrl = longUrl;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            PaymentNote = paymentNote;
        }

        /// <summary>
        /// The Square-assigned ID of the payment link.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The Square-assigned version number, which is incremented each time an update is committed to the payment link.
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; }

        /// <summary>
        /// The optional description of the `payment_link` object.
        /// It is primarily for use by your application and is not used anywhere.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <summary>
        /// The ID of the order associated with the payment link.
        /// </summary>
        [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; }

        /// <summary>
        /// Gets or sets CheckoutOptions.
        /// </summary>
        [JsonProperty("checkout_options", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CheckoutOptions CheckoutOptions { get; }

        /// <summary>
        /// Describes buyer data to prepopulate in the payment form.
        /// For more information,
        /// see [Optional Checkout Configurations](https://developer.squareup.com/docs/checkout-api/optional-checkout-configurations).
        /// </summary>
        [JsonProperty("pre_populated_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PrePopulatedData PrePopulatedData { get; }

        /// <summary>
        /// The shortened URL of the payment link.
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; }

        /// <summary>
        /// The long URL of the payment link.
        /// </summary>
        [JsonProperty("long_url", NullValueHandling = NullValueHandling.Ignore)]
        public string LongUrl { get; }

        /// <summary>
        /// The timestamp when the payment link was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the payment link was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// An optional note. After Square processes the payment, this note is added to the
        /// resulting `Payment`.
        /// </summary>
        [JsonProperty("payment_note")]
        public string PaymentNote { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaymentLink : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializePaymentNote()
        {
            return this.shouldSerialize["payment_note"];
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
            return obj is PaymentLink other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.Version.Equals(other.Version) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true)) &&
                ((this.CheckoutOptions == null && other.CheckoutOptions == null) || (this.CheckoutOptions?.Equals(other.CheckoutOptions) == true)) &&
                ((this.PrePopulatedData == null && other.PrePopulatedData == null) || (this.PrePopulatedData?.Equals(other.PrePopulatedData) == true)) &&
                ((this.Url == null && other.Url == null) || (this.Url?.Equals(other.Url) == true)) &&
                ((this.LongUrl == null && other.LongUrl == null) || (this.LongUrl?.Equals(other.LongUrl) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.PaymentNote == null && other.PaymentNote == null) || (this.PaymentNote?.Equals(other.PaymentNote) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 766737082;
            hashCode = HashCode.Combine(this.Id, this.Version, this.Description, this.OrderId, this.CheckoutOptions, this.PrePopulatedData, this.Url);

            hashCode = HashCode.Combine(hashCode, this.LongUrl, this.CreatedAt, this.UpdatedAt, this.PaymentNote);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.Version = {this.Version}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description)}");
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId)}");
            toStringOutput.Add($"this.CheckoutOptions = {(this.CheckoutOptions == null ? "null" : this.CheckoutOptions.ToString())}");
            toStringOutput.Add($"this.PrePopulatedData = {(this.PrePopulatedData == null ? "null" : this.PrePopulatedData.ToString())}");
            toStringOutput.Add($"this.Url = {(this.Url == null ? "null" : this.Url)}");
            toStringOutput.Add($"this.LongUrl = {(this.LongUrl == null ? "null" : this.LongUrl)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt)}");
            toStringOutput.Add($"this.PaymentNote = {(this.PaymentNote == null ? "null" : this.PaymentNote)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Version)
                .Id(this.Id)
                .Description(this.Description)
                .OrderId(this.OrderId)
                .CheckoutOptions(this.CheckoutOptions)
                .PrePopulatedData(this.PrePopulatedData)
                .Url(this.Url)
                .LongUrl(this.LongUrl)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .PaymentNote(this.PaymentNote);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "description", false },
                { "payment_note", false },
            };

            private int version;
            private string id;
            private string description;
            private string orderId;
            private Models.CheckoutOptions checkoutOptions;
            private Models.PrePopulatedData prePopulatedData;
            private string url;
            private string longUrl;
            private string createdAt;
            private string updatedAt;
            private string paymentNote;

            public Builder(
                int version)
            {
                this.version = version;
            }

             /// <summary>
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(int version)
            {
                this.version = version;
                return this;
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
             /// OrderId.
             /// </summary>
             /// <param name="orderId"> orderId. </param>
             /// <returns> Builder. </returns>
            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
                return this;
            }

             /// <summary>
             /// CheckoutOptions.
             /// </summary>
             /// <param name="checkoutOptions"> checkoutOptions. </param>
             /// <returns> Builder. </returns>
            public Builder CheckoutOptions(Models.CheckoutOptions checkoutOptions)
            {
                this.checkoutOptions = checkoutOptions;
                return this;
            }

             /// <summary>
             /// PrePopulatedData.
             /// </summary>
             /// <param name="prePopulatedData"> prePopulatedData. </param>
             /// <returns> Builder. </returns>
            public Builder PrePopulatedData(Models.PrePopulatedData prePopulatedData)
            {
                this.prePopulatedData = prePopulatedData;
                return this;
            }

             /// <summary>
             /// Url.
             /// </summary>
             /// <param name="url"> url. </param>
             /// <returns> Builder. </returns>
            public Builder Url(string url)
            {
                this.url = url;
                return this;
            }

             /// <summary>
             /// LongUrl.
             /// </summary>
             /// <param name="longUrl"> longUrl. </param>
             /// <returns> Builder. </returns>
            public Builder LongUrl(string longUrl)
            {
                this.longUrl = longUrl;
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
             /// PaymentNote.
             /// </summary>
             /// <param name="paymentNote"> paymentNote. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentNote(string paymentNote)
            {
                shouldSerialize["payment_note"] = true;
                this.paymentNote = paymentNote;
                return this;
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
            public void UnsetPaymentNote()
            {
                this.shouldSerialize["payment_note"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PaymentLink. </returns>
            public PaymentLink Build()
            {
                return new PaymentLink(shouldSerialize,
                    this.version,
                    this.id,
                    this.description,
                    this.orderId,
                    this.checkoutOptions,
                    this.prePopulatedData,
                    this.url,
                    this.longUrl,
                    this.createdAt,
                    this.updatedAt,
                    this.paymentNote);
            }
        }
    }
}