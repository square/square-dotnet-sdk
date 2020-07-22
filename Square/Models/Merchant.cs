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
    public class Merchant 
    {
        public Merchant(string country,
            string id = null,
            string businessName = null,
            string languageCode = null,
            string currency = null,
            string status = null,
            string mainLocationId = null)
        {
            Id = id;
            BusinessName = businessName;
            Country = country;
            LanguageCode = languageCode;
            Currency = currency;
            Status = status;
            MainLocationId = mainLocationId;
        }

        /// <summary>
        /// The Square-issued ID of the merchant.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The business name of the merchant.
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
        /// The language code associated with the merchant account, in BCP 47 format.
        /// </summary>
        [JsonProperty("language_code")]
        public string LanguageCode { get; }

        /// <summary>
        /// Indicates the associated currency for an amount of money. Values correspond
        /// to [ISO 4217](https://wikipedia.org/wiki/ISO_4217).
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; }

        /// <summary>
        /// Getter for status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// The ID of the main `Location` for this merchant.
        /// </summary>
        [JsonProperty("main_location_id")]
        public string MainLocationId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Country)
                .Id(Id)
                .BusinessName(BusinessName)
                .LanguageCode(LanguageCode)
                .Currency(Currency)
                .Status(Status)
                .MainLocationId(MainLocationId);
            return builder;
        }

        public class Builder
        {
            private string country;
            private string id;
            private string businessName;
            private string languageCode;
            private string currency;
            private string status;
            private string mainLocationId;

            public Builder(string country)
            {
                this.country = country;
            }
            public Builder Country(string value)
            {
                country = value;
                return this;
            }

            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder BusinessName(string value)
            {
                businessName = value;
                return this;
            }

            public Builder LanguageCode(string value)
            {
                languageCode = value;
                return this;
            }

            public Builder Currency(string value)
            {
                currency = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder MainLocationId(string value)
            {
                mainLocationId = value;
                return this;
            }

            public Merchant Build()
            {
                return new Merchant(country,
                    id,
                    businessName,
                    languageCode,
                    currency,
                    status,
                    mainLocationId);
            }
        }
    }
}