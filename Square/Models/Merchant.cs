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

namespace Square.Models
{
    /// <summary>
    /// Merchant.
    /// </summary>
    public class Merchant
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="Merchant"/> class.
        /// </summary>
        /// <param name="country">country.</param>
        /// <param name="id">id.</param>
        /// <param name="businessName">business_name.</param>
        /// <param name="languageCode">language_code.</param>
        /// <param name="currency">currency.</param>
        /// <param name="status">status.</param>
        /// <param name="mainLocationId">main_location_id.</param>
        /// <param name="createdAt">created_at.</param>
        public Merchant(
            string country,
            string id = null,
            string businessName = null,
            string languageCode = null,
            string currency = null,
            string status = null,
            string mainLocationId = null,
            string createdAt = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "business_name", false },
                { "language_code", false },
                { "main_location_id", false }
            };

            this.Id = id;
            if (businessName != null)
            {
                shouldSerialize["business_name"] = true;
                this.BusinessName = businessName;
            }

            this.Country = country;
            if (languageCode != null)
            {
                shouldSerialize["language_code"] = true;
                this.LanguageCode = languageCode;
            }

            this.Currency = currency;
            this.Status = status;
            if (mainLocationId != null)
            {
                shouldSerialize["main_location_id"] = true;
                this.MainLocationId = mainLocationId;
            }

            this.CreatedAt = createdAt;
        }
        internal Merchant(Dictionary<string, bool> shouldSerialize,
            string country,
            string id = null,
            string businessName = null,
            string languageCode = null,
            string currency = null,
            string status = null,
            string mainLocationId = null,
            string createdAt = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            BusinessName = businessName;
            Country = country;
            LanguageCode = languageCode;
            Currency = currency;
            Status = status;
            MainLocationId = mainLocationId;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// The Square-issued ID of the merchant.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The name of the merchant's overall business.
        /// </summary>
        [JsonProperty("business_name")]
        public string BusinessName { get; }

        /// <summary>
        /// Indicates the country associated with another entity, such as a business.
        /// Values are in [ISO 3166-1-alpha-2 format](http://www.iso.org/iso/home/standards/country_codes.htm).
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; }

        /// <summary>
        /// The code indicating the [language preferences](https://developer.squareup.com/docs/build-basics/general-considerations/language-preferences) of the merchant, in [BCP 47 format](https://tools.ietf.org/html/bcp47#appendix-A). For example, `en-US` or `fr-CA`.
        /// </summary>
        [JsonProperty("language_code")]
        public string LanguageCode { get; }

        /// <summary>
        /// Indicates the associated currency for an amount of money. Values correspond
        /// to [ISO 4217](https://wikipedia.org/wiki/ISO_4217).
        /// </summary>
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// The ID of the [main `Location`](https://developer.squareup.com/docs/locations-api#about-the-main-location) for this merchant.
        /// </summary>
        [JsonProperty("main_location_id")]
        public string MainLocationId { get; }

        /// <summary>
        /// The time when the merchant was created, in RFC 3339 format.
        ///    For more information, see [Working with Dates](https://developer.squareup.com/docs/build-basics/working-with-dates).
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Merchant : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBusinessName()
        {
            return this.shouldSerialize["business_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLanguageCode()
        {
            return this.shouldSerialize["language_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMainLocationId()
        {
            return this.shouldSerialize["main_location_id"];
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
            return obj is Merchant other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.BusinessName == null && other.BusinessName == null) || (this.BusinessName?.Equals(other.BusinessName) == true)) &&
                ((this.Country == null && other.Country == null) || (this.Country?.Equals(other.Country) == true)) &&
                ((this.LanguageCode == null && other.LanguageCode == null) || (this.LanguageCode?.Equals(other.LanguageCode) == true)) &&
                ((this.Currency == null && other.Currency == null) || (this.Currency?.Equals(other.Currency) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.MainLocationId == null && other.MainLocationId == null) || (this.MainLocationId?.Equals(other.MainLocationId) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1868202221;
            hashCode = HashCode.Combine(this.Id, this.BusinessName, this.Country, this.LanguageCode, this.Currency, this.Status, this.MainLocationId);

            hashCode = HashCode.Combine(hashCode, this.CreatedAt);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.BusinessName = {(this.BusinessName == null ? "null" : this.BusinessName)}");
            toStringOutput.Add($"this.Country = {(this.Country == null ? "null" : this.Country.ToString())}");
            toStringOutput.Add($"this.LanguageCode = {(this.LanguageCode == null ? "null" : this.LanguageCode)}");
            toStringOutput.Add($"this.Currency = {(this.Currency == null ? "null" : this.Currency.ToString())}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.MainLocationId = {(this.MainLocationId == null ? "null" : this.MainLocationId)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Country)
                .Id(this.Id)
                .BusinessName(this.BusinessName)
                .LanguageCode(this.LanguageCode)
                .Currency(this.Currency)
                .Status(this.Status)
                .MainLocationId(this.MainLocationId)
                .CreatedAt(this.CreatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "business_name", false },
                { "language_code", false },
                { "main_location_id", false },
            };

            private string country;
            private string id;
            private string businessName;
            private string languageCode;
            private string currency;
            private string status;
            private string mainLocationId;
            private string createdAt;

            /// <summary>
            /// Initialize Builder for Merchant.
            /// </summary>
            /// <param name="country"> country. </param>
            public Builder(
                string country)
            {
                this.country = country;
            }

             /// <summary>
             /// Country.
             /// </summary>
             /// <param name="country"> country. </param>
             /// <returns> Builder. </returns>
            public Builder Country(string country)
            {
                this.country = country;
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
             /// BusinessName.
             /// </summary>
             /// <param name="businessName"> businessName. </param>
             /// <returns> Builder. </returns>
            public Builder BusinessName(string businessName)
            {
                shouldSerialize["business_name"] = true;
                this.businessName = businessName;
                return this;
            }

             /// <summary>
             /// LanguageCode.
             /// </summary>
             /// <param name="languageCode"> languageCode. </param>
             /// <returns> Builder. </returns>
            public Builder LanguageCode(string languageCode)
            {
                shouldSerialize["language_code"] = true;
                this.languageCode = languageCode;
                return this;
            }

             /// <summary>
             /// Currency.
             /// </summary>
             /// <param name="currency"> currency. </param>
             /// <returns> Builder. </returns>
            public Builder Currency(string currency)
            {
                this.currency = currency;
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
             /// MainLocationId.
             /// </summary>
             /// <param name="mainLocationId"> mainLocationId. </param>
             /// <returns> Builder. </returns>
            public Builder MainLocationId(string mainLocationId)
            {
                shouldSerialize["main_location_id"] = true;
                this.mainLocationId = mainLocationId;
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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBusinessName()
            {
                this.shouldSerialize["business_name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLanguageCode()
            {
                this.shouldSerialize["language_code"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMainLocationId()
            {
                this.shouldSerialize["main_location_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Merchant. </returns>
            public Merchant Build()
            {
                return new Merchant(shouldSerialize,
                    this.country,
                    this.id,
                    this.businessName,
                    this.languageCode,
                    this.currency,
                    this.status,
                    this.mainLocationId,
                    this.createdAt);
            }
        }
    }
}