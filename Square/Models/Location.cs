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
    public class Location 
    {
        public Location(string id = null,
            string name = null,
            Models.Address address = null,
            string timezone = null,
            IList<string> capabilities = null,
            string status = null,
            string createdAt = null,
            string merchantId = null,
            string country = null,
            string languageCode = null,
            string currency = null,
            string phoneNumber = null,
            string businessName = null,
            string type = null,
            string websiteUrl = null,
            Models.BusinessHours businessHours = null,
            string businessEmail = null,
            string description = null,
            string twitterUsername = null,
            string instagramUsername = null,
            string facebookUrl = null,
            Models.Coordinates coordinates = null,
            string logoUrl = null,
            string posBackgroundUrl = null,
            string mcc = null)
        {
            Id = id;
            Name = name;
            Address = address;
            Timezone = timezone;
            Capabilities = capabilities;
            Status = status;
            CreatedAt = createdAt;
            MerchantId = merchantId;
            Country = country;
            LanguageCode = languageCode;
            Currency = currency;
            PhoneNumber = phoneNumber;
            BusinessName = businessName;
            Type = type;
            WebsiteUrl = websiteUrl;
            BusinessHours = businessHours;
            BusinessEmail = businessEmail;
            Description = description;
            TwitterUsername = twitterUsername;
            InstagramUsername = instagramUsername;
            FacebookUrl = facebookUrl;
            Coordinates = coordinates;
            LogoUrl = logoUrl;
            PosBackgroundUrl = posBackgroundUrl;
            Mcc = mcc;
        }

        /// <summary>
        /// The Square-issued ID of the location.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The name of the location.
        /// This information appears in the dashboard as the nickname.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Represents a physical address.
        /// </summary>
        [JsonProperty("address")]
        public Models.Address Address { get; }

        /// <summary>
        /// The [IANA Timezone](https://www.iana.org/time-zones) identifier for
        /// the timezone of the location.
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; }

        /// <summary>
        /// The Square features that are enabled for the location.
        /// See [LocationCapability](#type-locationcapability) for possible values.
        /// See [LocationCapability](#type-locationcapability) for possible values
        /// </summary>
        [JsonProperty("capabilities")]
        public IList<string> Capabilities { get; }

        /// <summary>
        /// The status of the location, whether a location is active or inactive.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// The time when the location was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// The ID of the merchant that owns the location.
        /// </summary>
        [JsonProperty("merchant_id")]
        public string MerchantId { get; }

        /// <summary>
        /// Indicates the country associated with another entity, such as a business.
        /// Values are in [ISO 3166-1-alpha-2 format](http://www.iso.org/iso/home/standards/country_codes.htm).
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; }

        /// <summary>
        /// The language associated with the location, in
        /// [BCP 47 format](https://tools.ietf.org/html/bcp47#appendix-A).
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
        /// The phone number of the location in human readable format.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; }

        /// <summary>
        /// The business name of the location
        /// This is the name visible to the customers of the location.
        /// For example, this name appears on customer receipts.
        /// </summary>
        [JsonProperty("business_name")]
        public string BusinessName { get; }

        /// <summary>
        /// A location's physical or mobile type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// The website URL of the location.
        /// </summary>
        [JsonProperty("website_url")]
        public string WebsiteUrl { get; }

        /// <summary>
        /// Represents the hours of operation for a business location.
        /// </summary>
        [JsonProperty("business_hours")]
        public Models.BusinessHours BusinessHours { get; }

        /// <summary>
        /// The email of the location.
        /// This email is visible to the customers of the location.
        /// For example, the email appears on customer receipts.
        /// </summary>
        [JsonProperty("business_email")]
        public string BusinessEmail { get; }

        /// <summary>
        /// The description of the location.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <summary>
        /// The Twitter username of the location without the '@' symbol.
        /// </summary>
        [JsonProperty("twitter_username")]
        public string TwitterUsername { get; }

        /// <summary>
        /// The Instagram username of the location without the '@' symbol.
        /// </summary>
        [JsonProperty("instagram_username")]
        public string InstagramUsername { get; }

        /// <summary>
        /// The Facebook profile URL of the location. The URL should begin with 'facebook.com/'.
        /// </summary>
        [JsonProperty("facebook_url")]
        public string FacebookUrl { get; }

        /// <summary>
        /// Latitude and longitude coordinates.
        /// </summary>
        [JsonProperty("coordinates")]
        public Models.Coordinates Coordinates { get; }

        /// <summary>
        /// The URL of the logo image for the location.
        /// </summary>
        [JsonProperty("logo_url")]
        public string LogoUrl { get; }

        /// <summary>
        /// The URL of the Point of Sale background image for the location.
        /// </summary>
        [JsonProperty("pos_background_url")]
        public string PosBackgroundUrl { get; }

        /// <summary>
        /// The merchant category code (MCC) of the location, as standardized by ISO 18245.
        /// The MCC describes the kind of goods or services sold at the location.
        /// </summary>
        [JsonProperty("mcc")]
        public string Mcc { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .Name(Name)
                .Address(Address)
                .Timezone(Timezone)
                .Capabilities(Capabilities)
                .Status(Status)
                .CreatedAt(CreatedAt)
                .MerchantId(MerchantId)
                .Country(Country)
                .LanguageCode(LanguageCode)
                .Currency(Currency)
                .PhoneNumber(PhoneNumber)
                .BusinessName(BusinessName)
                .Type(Type)
                .WebsiteUrl(WebsiteUrl)
                .BusinessHours(BusinessHours)
                .BusinessEmail(BusinessEmail)
                .Description(Description)
                .TwitterUsername(TwitterUsername)
                .InstagramUsername(InstagramUsername)
                .FacebookUrl(FacebookUrl)
                .Coordinates(Coordinates)
                .LogoUrl(LogoUrl)
                .PosBackgroundUrl(PosBackgroundUrl)
                .Mcc(Mcc);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string name;
            private Models.Address address;
            private string timezone;
            private IList<string> capabilities = new List<string>();
            private string status;
            private string createdAt;
            private string merchantId;
            private string country;
            private string languageCode;
            private string currency;
            private string phoneNumber;
            private string businessName;
            private string type;
            private string websiteUrl;
            private Models.BusinessHours businessHours;
            private string businessEmail;
            private string description;
            private string twitterUsername;
            private string instagramUsername;
            private string facebookUrl;
            private Models.Coordinates coordinates;
            private string logoUrl;
            private string posBackgroundUrl;
            private string mcc;

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

            public Builder Address(Models.Address value)
            {
                address = value;
                return this;
            }

            public Builder Timezone(string value)
            {
                timezone = value;
                return this;
            }

            public Builder Capabilities(IList<string> value)
            {
                capabilities = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public Builder MerchantId(string value)
            {
                merchantId = value;
                return this;
            }

            public Builder Country(string value)
            {
                country = value;
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

            public Builder PhoneNumber(string value)
            {
                phoneNumber = value;
                return this;
            }

            public Builder BusinessName(string value)
            {
                businessName = value;
                return this;
            }

            public Builder Type(string value)
            {
                type = value;
                return this;
            }

            public Builder WebsiteUrl(string value)
            {
                websiteUrl = value;
                return this;
            }

            public Builder BusinessHours(Models.BusinessHours value)
            {
                businessHours = value;
                return this;
            }

            public Builder BusinessEmail(string value)
            {
                businessEmail = value;
                return this;
            }

            public Builder Description(string value)
            {
                description = value;
                return this;
            }

            public Builder TwitterUsername(string value)
            {
                twitterUsername = value;
                return this;
            }

            public Builder InstagramUsername(string value)
            {
                instagramUsername = value;
                return this;
            }

            public Builder FacebookUrl(string value)
            {
                facebookUrl = value;
                return this;
            }

            public Builder Coordinates(Models.Coordinates value)
            {
                coordinates = value;
                return this;
            }

            public Builder LogoUrl(string value)
            {
                logoUrl = value;
                return this;
            }

            public Builder PosBackgroundUrl(string value)
            {
                posBackgroundUrl = value;
                return this;
            }

            public Builder Mcc(string value)
            {
                mcc = value;
                return this;
            }

            public Location Build()
            {
                return new Location(id,
                    name,
                    address,
                    timezone,
                    capabilities,
                    status,
                    createdAt,
                    merchantId,
                    country,
                    languageCode,
                    currency,
                    phoneNumber,
                    businessName,
                    type,
                    websiteUrl,
                    businessHours,
                    businessEmail,
                    description,
                    twitterUsername,
                    instagramUsername,
                    facebookUrl,
                    coordinates,
                    logoUrl,
                    posBackgroundUrl,
                    mcc);
            }
        }
    }
}