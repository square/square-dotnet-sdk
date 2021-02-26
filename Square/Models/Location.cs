
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
            string mcc = null,
            string fullFormatLogoUrl = null)
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
            FullFormatLogoUrl = fullFormatLogoUrl;
        }

        /// <summary>
        /// The Square-issued ID of the location.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The name of the location.
        /// This information appears in the dashboard as the nickname.
        /// A location name must be unique within a seller account.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// Represents a physical address.
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address Address { get; }

        /// <summary>
        /// The [IANA Timezone](https://www.iana.org/time-zones) identifier for
        /// the timezone of the location.
        /// </summary>
        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string Timezone { get; }

        /// <summary>
        /// The Square features that are enabled for the location.
        /// See [LocationCapability](#type-locationcapability) for possible values.
        /// See [LocationCapability](#type-locationcapability) for possible values
        /// </summary>
        [JsonProperty("capabilities", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Capabilities { get; }

        /// <summary>
        /// The status of the location, whether a location is active or inactive.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// The time when the location was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The ID of the merchant that owns the location.
        /// </summary>
        [JsonProperty("merchant_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantId { get; }

        /// <summary>
        /// Indicates the country associated with another entity, such as a business.
        /// Values are in [ISO 3166-1-alpha-2 format](http://www.iso.org/iso/home/standards/country_codes.htm).
        /// </summary>
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; }

        /// <summary>
        /// The language associated with the location, in
        /// [BCP 47 format](https://tools.ietf.org/html/bcp47#appendix-A).
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
        /// The phone number of the location in human readable format.
        /// </summary>
        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; }

        /// <summary>
        /// The business name of the location
        /// This is the name visible to the customers of the location.
        /// For example, this name appears on customer receipts.
        /// </summary>
        [JsonProperty("business_name", NullValueHandling = NullValueHandling.Ignore)]
        public string BusinessName { get; }

        /// <summary>
        /// A location's physical or mobile type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// The website URL of the location.
        /// </summary>
        [JsonProperty("website_url", NullValueHandling = NullValueHandling.Ignore)]
        public string WebsiteUrl { get; }

        /// <summary>
        /// Represents the hours of operation for a business location.
        /// </summary>
        [JsonProperty("business_hours", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BusinessHours BusinessHours { get; }

        /// <summary>
        /// The email of the location.
        /// This email is visible to the customers of the location.
        /// For example, the email appears on customer receipts.
        /// </summary>
        [JsonProperty("business_email", NullValueHandling = NullValueHandling.Ignore)]
        public string BusinessEmail { get; }

        /// <summary>
        /// The description of the location.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; }

        /// <summary>
        /// The Twitter username of the location without the '@' symbol.
        /// </summary>
        [JsonProperty("twitter_username", NullValueHandling = NullValueHandling.Ignore)]
        public string TwitterUsername { get; }

        /// <summary>
        /// The Instagram username of the location without the '@' symbol.
        /// </summary>
        [JsonProperty("instagram_username", NullValueHandling = NullValueHandling.Ignore)]
        public string InstagramUsername { get; }

        /// <summary>
        /// The Facebook profile URL of the location. The URL should begin with 'facebook.com/'.
        /// </summary>
        [JsonProperty("facebook_url", NullValueHandling = NullValueHandling.Ignore)]
        public string FacebookUrl { get; }

        /// <summary>
        /// Latitude and longitude coordinates.
        /// </summary>
        [JsonProperty("coordinates", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Coordinates Coordinates { get; }

        /// <summary>
        /// The URL of the logo image for the location. The Seller must choose this logo in the Seller
        /// dashboard (Receipts section) for the logo to appear on transactions (such as receipts, invoices)
        /// that Square generates on behalf of the Seller. This image should have an aspect ratio
        /// close to 1:1 and is recommended to be at least 200x200 pixels.
        /// </summary>
        [JsonProperty("logo_url", NullValueHandling = NullValueHandling.Ignore)]
        public string LogoUrl { get; }

        /// <summary>
        /// The URL of the Point of Sale background image for the location.
        /// </summary>
        [JsonProperty("pos_background_url", NullValueHandling = NullValueHandling.Ignore)]
        public string PosBackgroundUrl { get; }

        /// <summary>
        /// The merchant category code (MCC) of the location, as standardized by ISO 18245.
        /// The MCC describes the kind of goods or services sold at the location.
        /// </summary>
        [JsonProperty("mcc", NullValueHandling = NullValueHandling.Ignore)]
        public string Mcc { get; }

        /// <summary>
        /// The URL of a full-format logo image for the location. The Seller must choose this logo in the
        /// Seller dashboard (Receipts section) for the logo to appear on transactions (such as receipts, invoices)
        /// that Square generates on behalf of the Seller. This image can have an aspect ratio of 2:1 or greater
        /// and is recommended to be at least 1280x648 pixels.
        /// </summary>
        [JsonProperty("full_format_logo_url", NullValueHandling = NullValueHandling.Ignore)]
        public string FullFormatLogoUrl { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Location : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
            toStringOutput.Add($"Address = {(Address == null ? "null" : Address.ToString())}");
            toStringOutput.Add($"Timezone = {(Timezone == null ? "null" : Timezone == string.Empty ? "" : Timezone)}");
            toStringOutput.Add($"Capabilities = {(Capabilities == null ? "null" : $"[{ string.Join(", ", Capabilities)} ]")}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status.ToString())}");
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
            toStringOutput.Add($"MerchantId = {(MerchantId == null ? "null" : MerchantId == string.Empty ? "" : MerchantId)}");
            toStringOutput.Add($"Country = {(Country == null ? "null" : Country.ToString())}");
            toStringOutput.Add($"LanguageCode = {(LanguageCode == null ? "null" : LanguageCode == string.Empty ? "" : LanguageCode)}");
            toStringOutput.Add($"Currency = {(Currency == null ? "null" : Currency.ToString())}");
            toStringOutput.Add($"PhoneNumber = {(PhoneNumber == null ? "null" : PhoneNumber == string.Empty ? "" : PhoneNumber)}");
            toStringOutput.Add($"BusinessName = {(BusinessName == null ? "null" : BusinessName == string.Empty ? "" : BusinessName)}");
            toStringOutput.Add($"Type = {(Type == null ? "null" : Type.ToString())}");
            toStringOutput.Add($"WebsiteUrl = {(WebsiteUrl == null ? "null" : WebsiteUrl == string.Empty ? "" : WebsiteUrl)}");
            toStringOutput.Add($"BusinessHours = {(BusinessHours == null ? "null" : BusinessHours.ToString())}");
            toStringOutput.Add($"BusinessEmail = {(BusinessEmail == null ? "null" : BusinessEmail == string.Empty ? "" : BusinessEmail)}");
            toStringOutput.Add($"Description = {(Description == null ? "null" : Description == string.Empty ? "" : Description)}");
            toStringOutput.Add($"TwitterUsername = {(TwitterUsername == null ? "null" : TwitterUsername == string.Empty ? "" : TwitterUsername)}");
            toStringOutput.Add($"InstagramUsername = {(InstagramUsername == null ? "null" : InstagramUsername == string.Empty ? "" : InstagramUsername)}");
            toStringOutput.Add($"FacebookUrl = {(FacebookUrl == null ? "null" : FacebookUrl == string.Empty ? "" : FacebookUrl)}");
            toStringOutput.Add($"Coordinates = {(Coordinates == null ? "null" : Coordinates.ToString())}");
            toStringOutput.Add($"LogoUrl = {(LogoUrl == null ? "null" : LogoUrl == string.Empty ? "" : LogoUrl)}");
            toStringOutput.Add($"PosBackgroundUrl = {(PosBackgroundUrl == null ? "null" : PosBackgroundUrl == string.Empty ? "" : PosBackgroundUrl)}");
            toStringOutput.Add($"Mcc = {(Mcc == null ? "null" : Mcc == string.Empty ? "" : Mcc)}");
            toStringOutput.Add($"FullFormatLogoUrl = {(FullFormatLogoUrl == null ? "null" : FullFormatLogoUrl == string.Empty ? "" : FullFormatLogoUrl)}");
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

            return obj is Location other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true)) &&
                ((Address == null && other.Address == null) || (Address?.Equals(other.Address) == true)) &&
                ((Timezone == null && other.Timezone == null) || (Timezone?.Equals(other.Timezone) == true)) &&
                ((Capabilities == null && other.Capabilities == null) || (Capabilities?.Equals(other.Capabilities) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((MerchantId == null && other.MerchantId == null) || (MerchantId?.Equals(other.MerchantId) == true)) &&
                ((Country == null && other.Country == null) || (Country?.Equals(other.Country) == true)) &&
                ((LanguageCode == null && other.LanguageCode == null) || (LanguageCode?.Equals(other.LanguageCode) == true)) &&
                ((Currency == null && other.Currency == null) || (Currency?.Equals(other.Currency) == true)) &&
                ((PhoneNumber == null && other.PhoneNumber == null) || (PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((BusinessName == null && other.BusinessName == null) || (BusinessName?.Equals(other.BusinessName) == true)) &&
                ((Type == null && other.Type == null) || (Type?.Equals(other.Type) == true)) &&
                ((WebsiteUrl == null && other.WebsiteUrl == null) || (WebsiteUrl?.Equals(other.WebsiteUrl) == true)) &&
                ((BusinessHours == null && other.BusinessHours == null) || (BusinessHours?.Equals(other.BusinessHours) == true)) &&
                ((BusinessEmail == null && other.BusinessEmail == null) || (BusinessEmail?.Equals(other.BusinessEmail) == true)) &&
                ((Description == null && other.Description == null) || (Description?.Equals(other.Description) == true)) &&
                ((TwitterUsername == null && other.TwitterUsername == null) || (TwitterUsername?.Equals(other.TwitterUsername) == true)) &&
                ((InstagramUsername == null && other.InstagramUsername == null) || (InstagramUsername?.Equals(other.InstagramUsername) == true)) &&
                ((FacebookUrl == null && other.FacebookUrl == null) || (FacebookUrl?.Equals(other.FacebookUrl) == true)) &&
                ((Coordinates == null && other.Coordinates == null) || (Coordinates?.Equals(other.Coordinates) == true)) &&
                ((LogoUrl == null && other.LogoUrl == null) || (LogoUrl?.Equals(other.LogoUrl) == true)) &&
                ((PosBackgroundUrl == null && other.PosBackgroundUrl == null) || (PosBackgroundUrl?.Equals(other.PosBackgroundUrl) == true)) &&
                ((Mcc == null && other.Mcc == null) || (Mcc?.Equals(other.Mcc) == true)) &&
                ((FullFormatLogoUrl == null && other.FullFormatLogoUrl == null) || (FullFormatLogoUrl?.Equals(other.FullFormatLogoUrl) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -255518735;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            if (Address != null)
            {
               hashCode += Address.GetHashCode();
            }

            if (Timezone != null)
            {
               hashCode += Timezone.GetHashCode();
            }

            if (Capabilities != null)
            {
               hashCode += Capabilities.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            if (MerchantId != null)
            {
               hashCode += MerchantId.GetHashCode();
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

            if (PhoneNumber != null)
            {
               hashCode += PhoneNumber.GetHashCode();
            }

            if (BusinessName != null)
            {
               hashCode += BusinessName.GetHashCode();
            }

            if (Type != null)
            {
               hashCode += Type.GetHashCode();
            }

            if (WebsiteUrl != null)
            {
               hashCode += WebsiteUrl.GetHashCode();
            }

            if (BusinessHours != null)
            {
               hashCode += BusinessHours.GetHashCode();
            }

            if (BusinessEmail != null)
            {
               hashCode += BusinessEmail.GetHashCode();
            }

            if (Description != null)
            {
               hashCode += Description.GetHashCode();
            }

            if (TwitterUsername != null)
            {
               hashCode += TwitterUsername.GetHashCode();
            }

            if (InstagramUsername != null)
            {
               hashCode += InstagramUsername.GetHashCode();
            }

            if (FacebookUrl != null)
            {
               hashCode += FacebookUrl.GetHashCode();
            }

            if (Coordinates != null)
            {
               hashCode += Coordinates.GetHashCode();
            }

            if (LogoUrl != null)
            {
               hashCode += LogoUrl.GetHashCode();
            }

            if (PosBackgroundUrl != null)
            {
               hashCode += PosBackgroundUrl.GetHashCode();
            }

            if (Mcc != null)
            {
               hashCode += Mcc.GetHashCode();
            }

            if (FullFormatLogoUrl != null)
            {
               hashCode += FullFormatLogoUrl.GetHashCode();
            }

            return hashCode;
        }

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
                .Mcc(Mcc)
                .FullFormatLogoUrl(FullFormatLogoUrl);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string name;
            private Models.Address address;
            private string timezone;
            private IList<string> capabilities;
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
            private string fullFormatLogoUrl;



            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder Address(Models.Address address)
            {
                this.address = address;
                return this;
            }

            public Builder Timezone(string timezone)
            {
                this.timezone = timezone;
                return this;
            }

            public Builder Capabilities(IList<string> capabilities)
            {
                this.capabilities = capabilities;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder MerchantId(string merchantId)
            {
                this.merchantId = merchantId;
                return this;
            }

            public Builder Country(string country)
            {
                this.country = country;
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

            public Builder PhoneNumber(string phoneNumber)
            {
                this.phoneNumber = phoneNumber;
                return this;
            }

            public Builder BusinessName(string businessName)
            {
                this.businessName = businessName;
                return this;
            }

            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

            public Builder WebsiteUrl(string websiteUrl)
            {
                this.websiteUrl = websiteUrl;
                return this;
            }

            public Builder BusinessHours(Models.BusinessHours businessHours)
            {
                this.businessHours = businessHours;
                return this;
            }

            public Builder BusinessEmail(string businessEmail)
            {
                this.businessEmail = businessEmail;
                return this;
            }

            public Builder Description(string description)
            {
                this.description = description;
                return this;
            }

            public Builder TwitterUsername(string twitterUsername)
            {
                this.twitterUsername = twitterUsername;
                return this;
            }

            public Builder InstagramUsername(string instagramUsername)
            {
                this.instagramUsername = instagramUsername;
                return this;
            }

            public Builder FacebookUrl(string facebookUrl)
            {
                this.facebookUrl = facebookUrl;
                return this;
            }

            public Builder Coordinates(Models.Coordinates coordinates)
            {
                this.coordinates = coordinates;
                return this;
            }

            public Builder LogoUrl(string logoUrl)
            {
                this.logoUrl = logoUrl;
                return this;
            }

            public Builder PosBackgroundUrl(string posBackgroundUrl)
            {
                this.posBackgroundUrl = posBackgroundUrl;
                return this;
            }

            public Builder Mcc(string mcc)
            {
                this.mcc = mcc;
                return this;
            }

            public Builder FullFormatLogoUrl(string fullFormatLogoUrl)
            {
                this.fullFormatLogoUrl = fullFormatLogoUrl;
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
                    mcc,
                    fullFormatLogoUrl);
            }
        }
    }
}