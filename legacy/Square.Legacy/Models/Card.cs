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
    /// Card.
    /// </summary>
    public class Card
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="cardBrand">card_brand.</param>
        /// <param name="last4">last_4.</param>
        /// <param name="expMonth">exp_month.</param>
        /// <param name="expYear">exp_year.</param>
        /// <param name="cardholderName">cardholder_name.</param>
        /// <param name="billingAddress">billing_address.</param>
        /// <param name="fingerprint">fingerprint.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="merchantId">merchant_id.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="enabled">enabled.</param>
        /// <param name="cardType">card_type.</param>
        /// <param name="prepaidType">prepaid_type.</param>
        /// <param name="bin">bin.</param>
        /// <param name="version">version.</param>
        /// <param name="cardCoBrand">card_co_brand.</param>
        public Card(
            string id = null,
            string cardBrand = null,
            string last4 = null,
            long? expMonth = null,
            long? expYear = null,
            string cardholderName = null,
            Models.Address billingAddress = null,
            string fingerprint = null,
            string customerId = null,
            string merchantId = null,
            string referenceId = null,
            bool? enabled = null,
            string cardType = null,
            string prepaidType = null,
            string bin = null,
            long? version = null,
            string cardCoBrand = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "exp_month", false },
                { "exp_year", false },
                { "cardholder_name", false },
                { "customer_id", false },
                { "reference_id", false },
            };
            this.Id = id;
            this.CardBrand = cardBrand;
            this.Last4 = last4;

            if (expMonth != null)
            {
                shouldSerialize["exp_month"] = true;
                this.ExpMonth = expMonth;
            }

            if (expYear != null)
            {
                shouldSerialize["exp_year"] = true;
                this.ExpYear = expYear;
            }

            if (cardholderName != null)
            {
                shouldSerialize["cardholder_name"] = true;
                this.CardholderName = cardholderName;
            }
            this.BillingAddress = billingAddress;
            this.Fingerprint = fingerprint;

            if (customerId != null)
            {
                shouldSerialize["customer_id"] = true;
                this.CustomerId = customerId;
            }
            this.MerchantId = merchantId;

            if (referenceId != null)
            {
                shouldSerialize["reference_id"] = true;
                this.ReferenceId = referenceId;
            }
            this.Enabled = enabled;
            this.CardType = cardType;
            this.PrepaidType = prepaidType;
            this.Bin = bin;
            this.Version = version;
            this.CardCoBrand = cardCoBrand;
        }

        internal Card(
            Dictionary<string, bool> shouldSerialize,
            string id = null,
            string cardBrand = null,
            string last4 = null,
            long? expMonth = null,
            long? expYear = null,
            string cardholderName = null,
            Models.Address billingAddress = null,
            string fingerprint = null,
            string customerId = null,
            string merchantId = null,
            string referenceId = null,
            bool? enabled = null,
            string cardType = null,
            string prepaidType = null,
            string bin = null,
            long? version = null,
            string cardCoBrand = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            CardBrand = cardBrand;
            Last4 = last4;
            ExpMonth = expMonth;
            ExpYear = expYear;
            CardholderName = cardholderName;
            BillingAddress = billingAddress;
            Fingerprint = fingerprint;
            CustomerId = customerId;
            MerchantId = merchantId;
            ReferenceId = referenceId;
            Enabled = enabled;
            CardType = cardType;
            PrepaidType = prepaidType;
            Bin = bin;
            Version = version;
            CardCoBrand = cardCoBrand;
        }

        /// <summary>
        /// Unique ID for this card. Generated by Square.Legacy.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// Indicates a card's brand, such as `VISA` or `MASTERCARD`.
        /// </summary>
        [JsonProperty("card_brand", NullValueHandling = NullValueHandling.Ignore)]
        public string CardBrand { get; }

        /// <summary>
        /// The last 4 digits of the card number.
        /// </summary>
        [JsonProperty("last_4", NullValueHandling = NullValueHandling.Ignore)]
        public string Last4 { get; }

        /// <summary>
        /// The expiration month of the associated card as an integer between 1 and 12.
        /// </summary>
        [JsonProperty("exp_month")]
        public long? ExpMonth { get; }

        /// <summary>
        /// The four-digit year of the card's expiration date.
        /// </summary>
        [JsonProperty("exp_year")]
        public long? ExpYear { get; }

        /// <summary>
        /// The name of the cardholder.
        /// </summary>
        [JsonProperty("cardholder_name")]
        public string CardholderName { get; }

        /// <summary>
        /// Represents a postal address in a country.
        /// For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        /// </summary>
        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address BillingAddress { get; }

        /// <summary>
        /// Intended as a Square-assigned identifier, based
        /// on the card number, to identify the card across multiple locations within a
        /// single application.
        /// </summary>
        [JsonProperty("fingerprint", NullValueHandling = NullValueHandling.Ignore)]
        public string Fingerprint { get; }

        /// <summary>
        /// **Required** The ID of a customer created using the Customers API to be associated with the card.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <summary>
        /// The ID of the merchant associated with the card.
        /// </summary>
        [JsonProperty("merchant_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantId { get; }

        /// <summary>
        /// An optional user-defined reference ID that associates this card with
        /// another entity in an external system. For example, a customer ID from an
        /// external customer management system.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// Indicates whether or not a card can be used for payments.
        /// </summary>
        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enabled { get; }

        /// <summary>
        /// Indicates a card's type, such as `CREDIT` or `DEBIT`.
        /// </summary>
        [JsonProperty("card_type", NullValueHandling = NullValueHandling.Ignore)]
        public string CardType { get; }

        /// <summary>
        /// Indicates a card's prepaid type, such as `NOT_PREPAID` or `PREPAID`.
        /// </summary>
        [JsonProperty("prepaid_type", NullValueHandling = NullValueHandling.Ignore)]
        public string PrepaidType { get; }

        /// <summary>
        /// The first six digits of the card number, known as the Bank Identification Number (BIN). Only the Payments API
        /// returns this field.
        /// </summary>
        [JsonProperty("bin", NullValueHandling = NullValueHandling.Ignore)]
        public string Bin { get; }

        /// <summary>
        /// Current version number of the card. Increments with each card update. Requests to update an
        /// existing Card object will be rejected unless the version in the request matches the current
        /// version for the Card.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public long? Version { get; }

        /// <summary>
        /// Indicates the brand for a co-branded card.
        /// </summary>
        [JsonProperty("card_co_brand", NullValueHandling = NullValueHandling.Ignore)]
        public string CardCoBrand { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"Card : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeExpMonth()
        {
            return this.shouldSerialize["exp_month"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeExpYear()
        {
            return this.shouldSerialize["exp_year"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCardholderName()
        {
            return this.shouldSerialize["cardholder_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerId()
        {
            return this.shouldSerialize["customer_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReferenceId()
        {
            return this.shouldSerialize["reference_id"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is Card other
                && (this.Id == null && other.Id == null || this.Id?.Equals(other.Id) == true)
                && (
                    this.CardBrand == null && other.CardBrand == null
                    || this.CardBrand?.Equals(other.CardBrand) == true
                )
                && (
                    this.Last4 == null && other.Last4 == null
                    || this.Last4?.Equals(other.Last4) == true
                )
                && (
                    this.ExpMonth == null && other.ExpMonth == null
                    || this.ExpMonth?.Equals(other.ExpMonth) == true
                )
                && (
                    this.ExpYear == null && other.ExpYear == null
                    || this.ExpYear?.Equals(other.ExpYear) == true
                )
                && (
                    this.CardholderName == null && other.CardholderName == null
                    || this.CardholderName?.Equals(other.CardholderName) == true
                )
                && (
                    this.BillingAddress == null && other.BillingAddress == null
                    || this.BillingAddress?.Equals(other.BillingAddress) == true
                )
                && (
                    this.Fingerprint == null && other.Fingerprint == null
                    || this.Fingerprint?.Equals(other.Fingerprint) == true
                )
                && (
                    this.CustomerId == null && other.CustomerId == null
                    || this.CustomerId?.Equals(other.CustomerId) == true
                )
                && (
                    this.MerchantId == null && other.MerchantId == null
                    || this.MerchantId?.Equals(other.MerchantId) == true
                )
                && (
                    this.ReferenceId == null && other.ReferenceId == null
                    || this.ReferenceId?.Equals(other.ReferenceId) == true
                )
                && (
                    this.Enabled == null && other.Enabled == null
                    || this.Enabled?.Equals(other.Enabled) == true
                )
                && (
                    this.CardType == null && other.CardType == null
                    || this.CardType?.Equals(other.CardType) == true
                )
                && (
                    this.PrepaidType == null && other.PrepaidType == null
                    || this.PrepaidType?.Equals(other.PrepaidType) == true
                )
                && (this.Bin == null && other.Bin == null || this.Bin?.Equals(other.Bin) == true)
                && (
                    this.Version == null && other.Version == null
                    || this.Version?.Equals(other.Version) == true
                )
                && (
                    this.CardCoBrand == null && other.CardCoBrand == null
                    || this.CardCoBrand?.Equals(other.CardCoBrand) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1800511148;
            hashCode = HashCode.Combine(
                hashCode,
                this.Id,
                this.CardBrand,
                this.Last4,
                this.ExpMonth,
                this.ExpYear,
                this.CardholderName,
                this.BillingAddress
            );

            hashCode = HashCode.Combine(
                hashCode,
                this.Fingerprint,
                this.CustomerId,
                this.MerchantId,
                this.ReferenceId,
                this.Enabled,
                this.CardType,
                this.PrepaidType
            );

            hashCode = HashCode.Combine(hashCode, this.Bin, this.Version, this.CardCoBrand);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id ?? "null"}");
            toStringOutput.Add(
                $"this.CardBrand = {(this.CardBrand == null ? "null" : this.CardBrand.ToString())}"
            );
            toStringOutput.Add($"this.Last4 = {this.Last4 ?? "null"}");
            toStringOutput.Add(
                $"this.ExpMonth = {(this.ExpMonth == null ? "null" : this.ExpMonth.ToString())}"
            );
            toStringOutput.Add(
                $"this.ExpYear = {(this.ExpYear == null ? "null" : this.ExpYear.ToString())}"
            );
            toStringOutput.Add($"this.CardholderName = {this.CardholderName ?? "null"}");
            toStringOutput.Add(
                $"this.BillingAddress = {(this.BillingAddress == null ? "null" : this.BillingAddress.ToString())}"
            );
            toStringOutput.Add($"this.Fingerprint = {this.Fingerprint ?? "null"}");
            toStringOutput.Add($"this.CustomerId = {this.CustomerId ?? "null"}");
            toStringOutput.Add($"this.MerchantId = {this.MerchantId ?? "null"}");
            toStringOutput.Add($"this.ReferenceId = {this.ReferenceId ?? "null"}");
            toStringOutput.Add(
                $"this.Enabled = {(this.Enabled == null ? "null" : this.Enabled.ToString())}"
            );
            toStringOutput.Add(
                $"this.CardType = {(this.CardType == null ? "null" : this.CardType.ToString())}"
            );
            toStringOutput.Add(
                $"this.PrepaidType = {(this.PrepaidType == null ? "null" : this.PrepaidType.ToString())}"
            );
            toStringOutput.Add($"this.Bin = {this.Bin ?? "null"}");
            toStringOutput.Add(
                $"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}"
            );
            toStringOutput.Add(
                $"this.CardCoBrand = {(this.CardCoBrand == null ? "null" : this.CardCoBrand.ToString())}"
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
                .CardBrand(this.CardBrand)
                .Last4(this.Last4)
                .ExpMonth(this.ExpMonth)
                .ExpYear(this.ExpYear)
                .CardholderName(this.CardholderName)
                .BillingAddress(this.BillingAddress)
                .Fingerprint(this.Fingerprint)
                .CustomerId(this.CustomerId)
                .MerchantId(this.MerchantId)
                .ReferenceId(this.ReferenceId)
                .Enabled(this.Enabled)
                .CardType(this.CardType)
                .PrepaidType(this.PrepaidType)
                .Bin(this.Bin)
                .Version(this.Version)
                .CardCoBrand(this.CardCoBrand);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "exp_month", false },
                { "exp_year", false },
                { "cardholder_name", false },
                { "customer_id", false },
                { "reference_id", false },
            };

            private string id;
            private string cardBrand;
            private string last4;
            private long? expMonth;
            private long? expYear;
            private string cardholderName;
            private Models.Address billingAddress;
            private string fingerprint;
            private string customerId;
            private string merchantId;
            private string referenceId;
            private bool? enabled;
            private string cardType;
            private string prepaidType;
            private string bin;
            private long? version;
            private string cardCoBrand;

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
            /// CardBrand.
            /// </summary>
            /// <param name="cardBrand"> cardBrand. </param>
            /// <returns> Builder. </returns>
            public Builder CardBrand(string cardBrand)
            {
                this.cardBrand = cardBrand;
                return this;
            }

            /// <summary>
            /// Last4.
            /// </summary>
            /// <param name="last4"> last4. </param>
            /// <returns> Builder. </returns>
            public Builder Last4(string last4)
            {
                this.last4 = last4;
                return this;
            }

            /// <summary>
            /// ExpMonth.
            /// </summary>
            /// <param name="expMonth"> expMonth. </param>
            /// <returns> Builder. </returns>
            public Builder ExpMonth(long? expMonth)
            {
                shouldSerialize["exp_month"] = true;
                this.expMonth = expMonth;
                return this;
            }

            /// <summary>
            /// ExpYear.
            /// </summary>
            /// <param name="expYear"> expYear. </param>
            /// <returns> Builder. </returns>
            public Builder ExpYear(long? expYear)
            {
                shouldSerialize["exp_year"] = true;
                this.expYear = expYear;
                return this;
            }

            /// <summary>
            /// CardholderName.
            /// </summary>
            /// <param name="cardholderName"> cardholderName. </param>
            /// <returns> Builder. </returns>
            public Builder CardholderName(string cardholderName)
            {
                shouldSerialize["cardholder_name"] = true;
                this.cardholderName = cardholderName;
                return this;
            }

            /// <summary>
            /// BillingAddress.
            /// </summary>
            /// <param name="billingAddress"> billingAddress. </param>
            /// <returns> Builder. </returns>
            public Builder BillingAddress(Models.Address billingAddress)
            {
                this.billingAddress = billingAddress;
                return this;
            }

            /// <summary>
            /// Fingerprint.
            /// </summary>
            /// <param name="fingerprint"> fingerprint. </param>
            /// <returns> Builder. </returns>
            public Builder Fingerprint(string fingerprint)
            {
                this.fingerprint = fingerprint;
                return this;
            }

            /// <summary>
            /// CustomerId.
            /// </summary>
            /// <param name="customerId"> customerId. </param>
            /// <returns> Builder. </returns>
            public Builder CustomerId(string customerId)
            {
                shouldSerialize["customer_id"] = true;
                this.customerId = customerId;
                return this;
            }

            /// <summary>
            /// MerchantId.
            /// </summary>
            /// <param name="merchantId"> merchantId. </param>
            /// <returns> Builder. </returns>
            public Builder MerchantId(string merchantId)
            {
                this.merchantId = merchantId;
                return this;
            }

            /// <summary>
            /// ReferenceId.
            /// </summary>
            /// <param name="referenceId"> referenceId. </param>
            /// <returns> Builder. </returns>
            public Builder ReferenceId(string referenceId)
            {
                shouldSerialize["reference_id"] = true;
                this.referenceId = referenceId;
                return this;
            }

            /// <summary>
            /// Enabled.
            /// </summary>
            /// <param name="enabled"> enabled. </param>
            /// <returns> Builder. </returns>
            public Builder Enabled(bool? enabled)
            {
                this.enabled = enabled;
                return this;
            }

            /// <summary>
            /// CardType.
            /// </summary>
            /// <param name="cardType"> cardType. </param>
            /// <returns> Builder. </returns>
            public Builder CardType(string cardType)
            {
                this.cardType = cardType;
                return this;
            }

            /// <summary>
            /// PrepaidType.
            /// </summary>
            /// <param name="prepaidType"> prepaidType. </param>
            /// <returns> Builder. </returns>
            public Builder PrepaidType(string prepaidType)
            {
                this.prepaidType = prepaidType;
                return this;
            }

            /// <summary>
            /// Bin.
            /// </summary>
            /// <param name="bin"> bin. </param>
            /// <returns> Builder. </returns>
            public Builder Bin(string bin)
            {
                this.bin = bin;
                return this;
            }

            /// <summary>
            /// Version.
            /// </summary>
            /// <param name="version"> version. </param>
            /// <returns> Builder. </returns>
            public Builder Version(long? version)
            {
                this.version = version;
                return this;
            }

            /// <summary>
            /// CardCoBrand.
            /// </summary>
            /// <param name="cardCoBrand"> cardCoBrand. </param>
            /// <returns> Builder. </returns>
            public Builder CardCoBrand(string cardCoBrand)
            {
                this.cardCoBrand = cardCoBrand;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetExpMonth()
            {
                this.shouldSerialize["exp_month"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetExpYear()
            {
                this.shouldSerialize["exp_year"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCardholderName()
            {
                this.shouldSerialize["cardholder_name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCustomerId()
            {
                this.shouldSerialize["customer_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetReferenceId()
            {
                this.shouldSerialize["reference_id"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Card. </returns>
            public Card Build()
            {
                return new Card(
                    shouldSerialize,
                    this.id,
                    this.cardBrand,
                    this.last4,
                    this.expMonth,
                    this.expYear,
                    this.cardholderName,
                    this.billingAddress,
                    this.fingerprint,
                    this.customerId,
                    this.merchantId,
                    this.referenceId,
                    this.enabled,
                    this.cardType,
                    this.prepaidType,
                    this.bin,
                    this.version,
                    this.cardCoBrand
                );
            }
        }
    }
}
