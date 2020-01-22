using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1Merchant 
    {
        public V1Merchant(string id = null,
            string name = null,
            string email = null,
            string accountType = null,
            IList<string> accountCapabilities = null,
            string countryCode = null,
            string languageCode = null,
            string currencyCode = null,
            string businessName = null,
            Models.Address businessAddress = null,
            Models.V1PhoneNumber businessPhone = null,
            string businessType = null,
            Models.Address shippingAddress = null,
            Models.V1MerchantLocationDetails locationDetails = null,
            string marketUrl = null)
        {
            Id = id;
            Name = name;
            Email = email;
            AccountType = accountType;
            AccountCapabilities = accountCapabilities;
            CountryCode = countryCode;
            LanguageCode = languageCode;
            CurrencyCode = currencyCode;
            BusinessName = businessName;
            BusinessAddress = businessAddress;
            BusinessPhone = businessPhone;
            BusinessType = businessType;
            ShippingAddress = shippingAddress;
            LocationDetails = locationDetails;
            MarketUrl = marketUrl;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The merchant account's unique identifier.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The name associated with the merchant account.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The email address associated with the merchant account.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; }

        /// <summary>
        /// Getter for account_type
        /// </summary>
        [JsonProperty("account_type")]
        public string AccountType { get; }

        /// <summary>
        /// Capabilities that are enabled for the merchant's Square account. Capabilities that are not listed in this array are not enabled for the account.
        /// </summary>
        [JsonProperty("account_capabilities")]
        public IList<string> AccountCapabilities { get; }

        /// <summary>
        /// The country associated with the merchant account, in ISO 3166-1-alpha-2 format.
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; }

        /// <summary>
        /// The language associated with the merchant account, in BCP 47 format.
        /// </summary>
        [JsonProperty("language_code")]
        public string LanguageCode { get; }

        /// <summary>
        /// The currency associated with the merchant account, in ISO 4217 format. For example, the currency code for US dollars is USD.
        /// </summary>
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; }

        /// <summary>
        /// The name of the merchant's business.
        /// </summary>
        [JsonProperty("business_name")]
        public string BusinessName { get; }

        /// <summary>
        /// Represents a physical address.
        /// </summary>
        [JsonProperty("business_address")]
        public Models.Address BusinessAddress { get; }

        /// <summary>
        /// Represents a phone number.
        /// </summary>
        [JsonProperty("business_phone")]
        public Models.V1PhoneNumber BusinessPhone { get; }

        /// <summary>
        /// Getter for business_type
        /// </summary>
        [JsonProperty("business_type")]
        public string BusinessType { get; }

        /// <summary>
        /// Represents a physical address.
        /// </summary>
        [JsonProperty("shipping_address")]
        public Models.Address ShippingAddress { get; }

        /// <summary>
        /// Additional information for a single-location account specified by its associated business account, if it has one.
        /// </summary>
        [JsonProperty("location_details")]
        public Models.V1MerchantLocationDetails LocationDetails { get; }

        /// <summary>
        /// The URL of the merchant's online store.
        /// </summary>
        [JsonProperty("market_url")]
        public string MarketUrl { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .Name(Name)
                .Email(Email)
                .AccountType(AccountType)
                .AccountCapabilities(AccountCapabilities)
                .CountryCode(CountryCode)
                .LanguageCode(LanguageCode)
                .CurrencyCode(CurrencyCode)
                .BusinessName(BusinessName)
                .BusinessAddress(BusinessAddress)
                .BusinessPhone(BusinessPhone)
                .BusinessType(BusinessType)
                .ShippingAddress(ShippingAddress)
                .LocationDetails(LocationDetails)
                .MarketUrl(MarketUrl);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string name;
            private string email;
            private string accountType;
            private IList<string> accountCapabilities = new List<string>();
            private string countryCode;
            private string languageCode;
            private string currencyCode;
            private string businessName;
            private Models.Address businessAddress;
            private Models.V1PhoneNumber businessPhone;
            private string businessType;
            private Models.Address shippingAddress;
            private Models.V1MerchantLocationDetails locationDetails;
            private string marketUrl;

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder Email(string value)
            {
                email = value;
                return this;
            }

            public Builder AccountType(string value)
            {
                accountType = value;
                return this;
            }

            public Builder AccountCapabilities(IList<string> value)
            {
                accountCapabilities = value;
                return this;
            }

            public Builder CountryCode(string value)
            {
                countryCode = value;
                return this;
            }

            public Builder LanguageCode(string value)
            {
                languageCode = value;
                return this;
            }

            public Builder CurrencyCode(string value)
            {
                currencyCode = value;
                return this;
            }

            public Builder BusinessName(string value)
            {
                businessName = value;
                return this;
            }

            public Builder BusinessAddress(Models.Address value)
            {
                businessAddress = value;
                return this;
            }

            public Builder BusinessPhone(Models.V1PhoneNumber value)
            {
                businessPhone = value;
                return this;
            }

            public Builder BusinessType(string value)
            {
                businessType = value;
                return this;
            }

            public Builder ShippingAddress(Models.Address value)
            {
                shippingAddress = value;
                return this;
            }

            public Builder LocationDetails(Models.V1MerchantLocationDetails value)
            {
                locationDetails = value;
                return this;
            }

            public Builder MarketUrl(string value)
            {
                marketUrl = value;
                return this;
            }

            public V1Merchant Build()
            {
                return new V1Merchant(id,
                    name,
                    email,
                    accountType,
                    accountCapabilities,
                    countryCode,
                    languageCode,
                    currencyCode,
                    businessName,
                    businessAddress,
                    businessPhone,
                    businessType,
                    shippingAddress,
                    locationDetails,
                    marketUrl);
            }
        }
    }
}