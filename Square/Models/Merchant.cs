
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
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The business name of the merchant.
        /// </summary>
        [JsonProperty("business_name", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty("language_code", NullValueHandling = NullValueHandling.Ignore)]
        public string LanguageCode { get; }

        /// <summary>
        /// Indicates the associated currency for an amount of money. Values correspond
        /// to [ISO 4217](https://wikipedia.org/wiki/ISO_4217).
        /// </summary>
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; }

        /// <summary>
        /// Getter for status
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// The ID of the main `Location` for this merchant.
        /// </summary>
        [JsonProperty("main_location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MainLocationId { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Merchant : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"BusinessName = {(BusinessName == null ? "null" : BusinessName == string.Empty ? "" : BusinessName)}");
            toStringOutput.Add($"Country = {(Country == null ? "null" : Country.ToString())}");
            toStringOutput.Add($"LanguageCode = {(LanguageCode == null ? "null" : LanguageCode == string.Empty ? "" : LanguageCode)}");
            toStringOutput.Add($"Currency = {(Currency == null ? "null" : Currency.ToString())}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status.ToString())}");
            toStringOutput.Add($"MainLocationId = {(MainLocationId == null ? "null" : MainLocationId == string.Empty ? "" : MainLocationId)}");
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

            return obj is Merchant other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((BusinessName == null && other.BusinessName == null) || (BusinessName?.Equals(other.BusinessName) == true)) &&
                ((Country == null && other.Country == null) || (Country?.Equals(other.Country) == true)) &&
                ((LanguageCode == null && other.LanguageCode == null) || (LanguageCode?.Equals(other.LanguageCode) == true)) &&
                ((Currency == null && other.Currency == null) || (Currency?.Equals(other.Currency) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true)) &&
                ((MainLocationId == null && other.MainLocationId == null) || (MainLocationId?.Equals(other.MainLocationId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1340049772;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (BusinessName != null)
            {
               hashCode += BusinessName.GetHashCode();
            }

            if (Country != null)
            {
               hashCode += Country.GetHashCode();
            }

            if (LanguageCode != null)
            {
               hashCode += LanguageCode.GetHashCode();
            }

            if (Currency != null)
            {
               hashCode += Currency.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }

            if (MainLocationId != null)
            {
               hashCode += MainLocationId.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder Country(string country)
            {
                this.country = country;
                return this;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder BusinessName(string businessName)
            {
                this.businessName = businessName;
                return this;
            }

            public Builder LanguageCode(string languageCode)
            {
                this.languageCode = languageCode;
                return this;
            }

            public Builder Currency(string currency)
            {
                this.currency = currency;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public Builder MainLocationId(string mainLocationId)
            {
                this.mainLocationId = mainLocationId;
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