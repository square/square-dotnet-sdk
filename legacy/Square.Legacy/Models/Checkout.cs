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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// Checkout.
    /// </summary>
    public class Checkout
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="Checkout"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="checkoutPageUrl">checkout_page_url.</param>
        /// <param name="askForShippingAddress">ask_for_shipping_address.</param>
        /// <param name="merchantSupportEmail">merchant_support_email.</param>
        /// <param name="prePopulateBuyerEmail">pre_populate_buyer_email.</param>
        /// <param name="prePopulateShippingAddress">pre_populate_shipping_address.</param>
        /// <param name="redirectUrl">redirect_url.</param>
        /// <param name="order">order.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="additionalRecipients">additional_recipients.</param>
        public Checkout(
            string id = null,
            string checkoutPageUrl = null,
            bool? askForShippingAddress = null,
            string merchantSupportEmail = null,
            string prePopulateBuyerEmail = null,
            Models.Address prePopulateShippingAddress = null,
            string redirectUrl = null,
            Models.Order order = null,
            string createdAt = null,
            IList<Models.AdditionalRecipient> additionalRecipients = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "checkout_page_url", false },
                { "ask_for_shipping_address", false },
                { "merchant_support_email", false },
                { "pre_populate_buyer_email", false },
                { "redirect_url", false },
                { "additional_recipients", false },
            };
            this.Id = id;

            if (checkoutPageUrl != null)
            {
                shouldSerialize["checkout_page_url"] = true;
                this.CheckoutPageUrl = checkoutPageUrl;
            }

            if (askForShippingAddress != null)
            {
                shouldSerialize["ask_for_shipping_address"] = true;
                this.AskForShippingAddress = askForShippingAddress;
            }

            if (merchantSupportEmail != null)
            {
                shouldSerialize["merchant_support_email"] = true;
                this.MerchantSupportEmail = merchantSupportEmail;
            }

            if (prePopulateBuyerEmail != null)
            {
                shouldSerialize["pre_populate_buyer_email"] = true;
                this.PrePopulateBuyerEmail = prePopulateBuyerEmail;
            }
            this.PrePopulateShippingAddress = prePopulateShippingAddress;

            if (redirectUrl != null)
            {
                shouldSerialize["redirect_url"] = true;
                this.RedirectUrl = redirectUrl;
            }
            this.Order = order;
            this.CreatedAt = createdAt;

            if (additionalRecipients != null)
            {
                shouldSerialize["additional_recipients"] = true;
                this.AdditionalRecipients = additionalRecipients;
            }
        }

        internal Checkout(
            Dictionary<string, bool> shouldSerialize,
            string id = null,
            string checkoutPageUrl = null,
            bool? askForShippingAddress = null,
            string merchantSupportEmail = null,
            string prePopulateBuyerEmail = null,
            Models.Address prePopulateShippingAddress = null,
            string redirectUrl = null,
            Models.Order order = null,
            string createdAt = null,
            IList<Models.AdditionalRecipient> additionalRecipients = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            CheckoutPageUrl = checkoutPageUrl;
            AskForShippingAddress = askForShippingAddress;
            MerchantSupportEmail = merchantSupportEmail;
            PrePopulateBuyerEmail = prePopulateBuyerEmail;
            PrePopulateShippingAddress = prePopulateShippingAddress;
            RedirectUrl = redirectUrl;
            Order = order;
            CreatedAt = createdAt;
            AdditionalRecipients = additionalRecipients;
        }

        /// <summary>
        /// ID generated by Square Checkout when a new checkout is requested.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The URL that the buyer's browser should be redirected to after the
        /// checkout is completed.
        /// </summary>
        [JsonProperty("checkout_page_url")]
        public string CheckoutPageUrl { get; }

        /// <summary>
        /// If `true`, Square Checkout will collect shipping information on your
        /// behalf and store that information with the transaction information in your
        /// Square Dashboard.
        /// Default: `false`.
        /// </summary>
        [JsonProperty("ask_for_shipping_address")]
        public bool? AskForShippingAddress { get; }

        /// <summary>
        /// The email address to display on the Square Checkout confirmation page
        /// and confirmation email that the buyer can use to contact the merchant.
        /// If this value is not set, the confirmation page and email will display the
        /// primary email address associated with the merchant's Square account.
        /// Default: none; only exists if explicitly set.
        /// </summary>
        [JsonProperty("merchant_support_email")]
        public string MerchantSupportEmail { get; }

        /// <summary>
        /// If provided, the buyer's email is pre-populated on the checkout page
        /// as an editable text field.
        /// Default: none; only exists if explicitly set.
        /// </summary>
        [JsonProperty("pre_populate_buyer_email")]
        public string PrePopulateBuyerEmail { get; }

        /// <summary>
        /// Represents a postal address in a country.
        /// For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        /// </summary>
        [JsonProperty(
            "pre_populate_shipping_address",
            NullValueHandling = NullValueHandling.Ignore
        )]
        public Models.Address PrePopulateShippingAddress { get; }

        /// <summary>
        /// The URL to redirect to after checkout is completed with `checkoutId`,
        /// Square's `orderId`, `transactionId`, and `referenceId` appended as URL
        /// parameters. For example, if the provided redirect_url is
        /// `http://www.example.com/order-complete`, a successful transaction redirects
        /// the customer to:
        /// <pre><code>http://www.example.com/order-complete?checkoutId=xxxxxx&amp;orderId=xxxxxx&amp;referenceId=xxxxxx&amp;transactionId=xxxxxx</code></pre>
        /// If you do not provide a redirect URL, Square Checkout will display an order
        /// confirmation page on your behalf; however Square strongly recommends that
        /// you provide a redirect URL so you can verify the transaction results and
        /// finalize the order through your existing/normal confirmation workflow.
        /// </summary>
        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; }

        /// <summary>
        /// Contains all information related to a single order to process with Square,
        /// including line items that specify the products to purchase. `Order` objects also
        /// include information about any associated tenders, refunds, and returns.
        /// All Connect V2 Transactions have all been converted to Orders including all associated
        /// itemization data.
        /// </summary>
        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Order Order { get; }

        /// <summary>
        /// The time when the checkout was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// Additional recipients (other than the merchant) receiving a portion of this checkout.
        /// For example, fees assessed on the purchase by a third party integration.
        /// </summary>
        [JsonProperty("additional_recipients")]
        public IList<Models.AdditionalRecipient> AdditionalRecipients { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"Checkout : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCheckoutPageUrl()
        {
            return this.shouldSerialize["checkout_page_url"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAskForShippingAddress()
        {
            return this.shouldSerialize["ask_for_shipping_address"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMerchantSupportEmail()
        {
            return this.shouldSerialize["merchant_support_email"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePrePopulateBuyerEmail()
        {
            return this.shouldSerialize["pre_populate_buyer_email"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRedirectUrl()
        {
            return this.shouldSerialize["redirect_url"];
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
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is Checkout other
                && (this.Id == null && other.Id == null || this.Id?.Equals(other.Id) == true)
                && (
                    this.CheckoutPageUrl == null && other.CheckoutPageUrl == null
                    || this.CheckoutPageUrl?.Equals(other.CheckoutPageUrl) == true
                )
                && (
                    this.AskForShippingAddress == null && other.AskForShippingAddress == null
                    || this.AskForShippingAddress?.Equals(other.AskForShippingAddress) == true
                )
                && (
                    this.MerchantSupportEmail == null && other.MerchantSupportEmail == null
                    || this.MerchantSupportEmail?.Equals(other.MerchantSupportEmail) == true
                )
                && (
                    this.PrePopulateBuyerEmail == null && other.PrePopulateBuyerEmail == null
                    || this.PrePopulateBuyerEmail?.Equals(other.PrePopulateBuyerEmail) == true
                )
                && (
                    this.PrePopulateShippingAddress == null
                        && other.PrePopulateShippingAddress == null
                    || this.PrePopulateShippingAddress?.Equals(other.PrePopulateShippingAddress)
                        == true
                )
                && (
                    this.RedirectUrl == null && other.RedirectUrl == null
                    || this.RedirectUrl?.Equals(other.RedirectUrl) == true
                )
                && (
                    this.Order == null && other.Order == null
                    || this.Order?.Equals(other.Order) == true
                )
                && (
                    this.CreatedAt == null && other.CreatedAt == null
                    || this.CreatedAt?.Equals(other.CreatedAt) == true
                )
                && (
                    this.AdditionalRecipients == null && other.AdditionalRecipients == null
                    || this.AdditionalRecipients?.Equals(other.AdditionalRecipients) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1629433824;
            hashCode = HashCode.Combine(
                hashCode,
                this.Id,
                this.CheckoutPageUrl,
                this.AskForShippingAddress,
                this.MerchantSupportEmail,
                this.PrePopulateBuyerEmail,
                this.PrePopulateShippingAddress,
                this.RedirectUrl
            );

            hashCode = HashCode.Combine(
                hashCode,
                this.Order,
                this.CreatedAt,
                this.AdditionalRecipients
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id ?? "null"}");
            toStringOutput.Add($"this.CheckoutPageUrl = {this.CheckoutPageUrl ?? "null"}");
            toStringOutput.Add(
                $"this.AskForShippingAddress = {(this.AskForShippingAddress == null ? "null" : this.AskForShippingAddress.ToString())}"
            );
            toStringOutput.Add(
                $"this.MerchantSupportEmail = {this.MerchantSupportEmail ?? "null"}"
            );
            toStringOutput.Add(
                $"this.PrePopulateBuyerEmail = {this.PrePopulateBuyerEmail ?? "null"}"
            );
            toStringOutput.Add(
                $"this.PrePopulateShippingAddress = {(this.PrePopulateShippingAddress == null ? "null" : this.PrePopulateShippingAddress.ToString())}"
            );
            toStringOutput.Add($"this.RedirectUrl = {this.RedirectUrl ?? "null"}");
            toStringOutput.Add(
                $"this.Order = {(this.Order == null ? "null" : this.Order.ToString())}"
            );
            toStringOutput.Add($"this.CreatedAt = {this.CreatedAt ?? "null"}");
            toStringOutput.Add(
                $"this.AdditionalRecipients = {(this.AdditionalRecipients == null ? "null" : $"[{string.Join(", ", this.AdditionalRecipients)} ]")}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .CheckoutPageUrl(this.CheckoutPageUrl)
                .AskForShippingAddress(this.AskForShippingAddress)
                .MerchantSupportEmail(this.MerchantSupportEmail)
                .PrePopulateBuyerEmail(this.PrePopulateBuyerEmail)
                .PrePopulateShippingAddress(this.PrePopulateShippingAddress)
                .RedirectUrl(this.RedirectUrl)
                .Order(this.Order)
                .CreatedAt(this.CreatedAt)
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
                { "checkout_page_url", false },
                { "ask_for_shipping_address", false },
                { "merchant_support_email", false },
                { "pre_populate_buyer_email", false },
                { "redirect_url", false },
                { "additional_recipients", false },
            };

            private string id;
            private string checkoutPageUrl;
            private bool? askForShippingAddress;
            private string merchantSupportEmail;
            private string prePopulateBuyerEmail;
            private Models.Address prePopulateShippingAddress;
            private string redirectUrl;
            private Models.Order order;
            private string createdAt;
            private IList<Models.AdditionalRecipient> additionalRecipients;

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
            /// CheckoutPageUrl.
            /// </summary>
            /// <param name="checkoutPageUrl"> checkoutPageUrl. </param>
            /// <returns> Builder. </returns>
            public Builder CheckoutPageUrl(string checkoutPageUrl)
            {
                shouldSerialize["checkout_page_url"] = true;
                this.checkoutPageUrl = checkoutPageUrl;
                return this;
            }

            /// <summary>
            /// AskForShippingAddress.
            /// </summary>
            /// <param name="askForShippingAddress"> askForShippingAddress. </param>
            /// <returns> Builder. </returns>
            public Builder AskForShippingAddress(bool? askForShippingAddress)
            {
                shouldSerialize["ask_for_shipping_address"] = true;
                this.askForShippingAddress = askForShippingAddress;
                return this;
            }

            /// <summary>
            /// MerchantSupportEmail.
            /// </summary>
            /// <param name="merchantSupportEmail"> merchantSupportEmail. </param>
            /// <returns> Builder. </returns>
            public Builder MerchantSupportEmail(string merchantSupportEmail)
            {
                shouldSerialize["merchant_support_email"] = true;
                this.merchantSupportEmail = merchantSupportEmail;
                return this;
            }

            /// <summary>
            /// PrePopulateBuyerEmail.
            /// </summary>
            /// <param name="prePopulateBuyerEmail"> prePopulateBuyerEmail. </param>
            /// <returns> Builder. </returns>
            public Builder PrePopulateBuyerEmail(string prePopulateBuyerEmail)
            {
                shouldSerialize["pre_populate_buyer_email"] = true;
                this.prePopulateBuyerEmail = prePopulateBuyerEmail;
                return this;
            }

            /// <summary>
            /// PrePopulateShippingAddress.
            /// </summary>
            /// <param name="prePopulateShippingAddress"> prePopulateShippingAddress. </param>
            /// <returns> Builder. </returns>
            public Builder PrePopulateShippingAddress(Models.Address prePopulateShippingAddress)
            {
                this.prePopulateShippingAddress = prePopulateShippingAddress;
                return this;
            }

            /// <summary>
            /// RedirectUrl.
            /// </summary>
            /// <param name="redirectUrl"> redirectUrl. </param>
            /// <returns> Builder. </returns>
            public Builder RedirectUrl(string redirectUrl)
            {
                shouldSerialize["redirect_url"] = true;
                this.redirectUrl = redirectUrl;
                return this;
            }

            /// <summary>
            /// Order.
            /// </summary>
            /// <param name="order"> order. </param>
            /// <returns> Builder. </returns>
            public Builder Order(Models.Order order)
            {
                this.order = order;
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
            /// AdditionalRecipients.
            /// </summary>
            /// <param name="additionalRecipients"> additionalRecipients. </param>
            /// <returns> Builder. </returns>
            public Builder AdditionalRecipients(
                IList<Models.AdditionalRecipient> additionalRecipients
            )
            {
                shouldSerialize["additional_recipients"] = true;
                this.additionalRecipients = additionalRecipients;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCheckoutPageUrl()
            {
                this.shouldSerialize["checkout_page_url"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetAskForShippingAddress()
            {
                this.shouldSerialize["ask_for_shipping_address"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetMerchantSupportEmail()
            {
                this.shouldSerialize["merchant_support_email"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetPrePopulateBuyerEmail()
            {
                this.shouldSerialize["pre_populate_buyer_email"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetRedirectUrl()
            {
                this.shouldSerialize["redirect_url"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetAdditionalRecipients()
            {
                this.shouldSerialize["additional_recipients"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Checkout. </returns>
            public Checkout Build()
            {
                return new Checkout(
                    shouldSerialize,
                    this.id,
                    this.checkoutPageUrl,
                    this.askForShippingAddress,
                    this.merchantSupportEmail,
                    this.prePopulateBuyerEmail,
                    this.prePopulateShippingAddress,
                    this.redirectUrl,
                    this.order,
                    this.createdAt,
                    this.additionalRecipients
                );
            }
        }
    }
}
