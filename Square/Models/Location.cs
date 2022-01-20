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
    /// Location.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="address">address.</param>
        /// <param name="timezone">timezone.</param>
        /// <param name="capabilities">capabilities.</param>
        /// <param name="status">status.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="merchantId">merchant_id.</param>
        /// <param name="country">country.</param>
        /// <param name="languageCode">language_code.</param>
        /// <param name="currency">currency.</param>
        /// <param name="phoneNumber">phone_number.</param>
        /// <param name="businessName">business_name.</param>
        /// <param name="type">type.</param>
        /// <param name="websiteUrl">website_url.</param>
        /// <param name="businessHours">business_hours.</param>
        /// <param name="businessEmail">business_email.</param>
        /// <param name="description">description.</param>
        /// <param name="twitterUsername">twitter_username.</param>
        /// <param name="instagramUsername">instagram_username.</param>
        /// <param name="facebookUrl">facebook_url.</param>
        /// <param name="coordinates">coordinates.</param>
        /// <param name="logoUrl">logo_url.</param>
        /// <param name="posBackgroundUrl">pos_background_url.</param>
        /// <param name="mcc">mcc.</param>
        /// <param name="fullFormatLogoUrl">full_format_logo_url.</param>
        /// <param name="taxIds">tax_ids.</param>
        public Location(
            string id = null,
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
            string fullFormatLogoUrl = null,
            Models.TaxIds taxIds = null)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Timezone = timezone;
            this.Capabilities = capabilities;
            this.Status = status;
            this.CreatedAt = createdAt;
            this.MerchantId = merchantId;
            this.Country = country;
            this.LanguageCode = languageCode;
            this.Currency = currency;
            this.PhoneNumber = phoneNumber;
            this.BusinessName = businessName;
            this.Type = type;
            this.WebsiteUrl = websiteUrl;
            this.BusinessHours = businessHours;
            this.BusinessEmail = businessEmail;
            this.Description = description;
            this.TwitterUsername = twitterUsername;
            this.InstagramUsername = instagramUsername;
            this.FacebookUrl = facebookUrl;
            this.Coordinates = coordinates;
            this.LogoUrl = logoUrl;
            this.PosBackgroundUrl = posBackgroundUrl;
            this.Mcc = mcc;
            this.FullFormatLogoUrl = fullFormatLogoUrl;
            this.TaxIds = taxIds;
        }

        /// <summary>
        /// A short, generated string of letters and numbers that uniquely identifies this location instance.
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
        /// Represents a postal address in a country.
        /// For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address Address { get; }

        /// <summary>
        /// The [IANA Timezone](https://www.iana.org/time-zones) identifier for
        /// the timezone of the location. For example, `America/Los_Angeles`.
        /// </summary>
        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string Timezone { get; }

        /// <summary>
        /// The Square features that are enabled for the location.
        /// See [LocationCapability]($m/LocationCapability) for possible values.
        /// See [LocationCapability](#type-locationcapability) for possible values
        /// </summary>
        [JsonProperty("capabilities", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Capabilities { get; }

        /// <summary>
        /// A location's status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// The time when the location was created, in RFC 3339 format.
        /// For more information, see [Working with Dates](https://developer.squareup.com/docs/build-basics/working-with-dates).
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
        /// For more information, see [Location language code](https://developer.squareup.com/docs/locations-api#location-language-code).
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
        /// The phone number of the location. For example, `+1 855-700-6000`.
        /// </summary>
        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; }

        /// <summary>
        /// The business name of the location.
        /// </summary>
        [JsonProperty("business_name", NullValueHandling = NullValueHandling.Ignore)]
        public string BusinessName { get; }

        /// <summary>
        /// A location's type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// The website URL of the location.  For example, `https://squareup.com`.
        /// </summary>
        [JsonProperty("website_url", NullValueHandling = NullValueHandling.Ignore)]
        public string WebsiteUrl { get; }

        /// <summary>
        /// The hours of operation for a location.
        /// </summary>
        [JsonProperty("business_hours", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BusinessHours BusinessHours { get; }

        /// <summary>
        /// The email address of the location. This can be unique to the location, and is not always the email address for the business owner or admin.
        /// </summary>
        [JsonProperty("business_email", NullValueHandling = NullValueHandling.Ignore)]
        public string BusinessEmail { get; }

        /// <summary>
        /// The description of the location. For example, `Main Street location`.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; }

        /// <summary>
        /// The Twitter username of the location without the '@' symbol. For example, `Square`.
        /// </summary>
        [JsonProperty("twitter_username", NullValueHandling = NullValueHandling.Ignore)]
        public string TwitterUsername { get; }

        /// <summary>
        /// The Instagram username of the location without the '@' symbol. For example, `square`.
        /// </summary>
        [JsonProperty("instagram_username", NullValueHandling = NullValueHandling.Ignore)]
        public string InstagramUsername { get; }

        /// <summary>
        /// The Facebook profile URL of the location. The URL should begin with 'facebook.com/'. For example, `https://www.facebook.com/square`.
        /// </summary>
        [JsonProperty("facebook_url", NullValueHandling = NullValueHandling.Ignore)]
        public string FacebookUrl { get; }

        /// <summary>
        /// Latitude and longitude coordinates.
        /// </summary>
        [JsonProperty("coordinates", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Coordinates Coordinates { get; }

        /// <summary>
        /// The URL of the logo image for the location. When configured in the Seller
        /// dashboard (Receipts section), the logo appears on transactions (such as receipts and invoices)
        /// that Square generates on behalf of the Seller. This image should have a roughly square (1:1) aspect ratio
        /// and is recommended to be at least 200x200 pixels.
        /// </summary>
        [JsonProperty("logo_url", NullValueHandling = NullValueHandling.Ignore)]
        public string LogoUrl { get; }

        /// <summary>
        /// The URL of the Point of Sale background image for the location.
        /// </summary>
        [JsonProperty("pos_background_url", NullValueHandling = NullValueHandling.Ignore)]
        public string PosBackgroundUrl { get; }

        /// <summary>
        /// A four-digit number that describes the kind of goods or services sold at the location.
        /// The [merchant category code (MCC)](https://developer.squareup.com/docs/locations-api#initialize-a-merchant-category-code) of the location as standardized by ISO 18245.
        /// For example, `5045`, for a location that sells computer goods and software.
        /// </summary>
        [JsonProperty("mcc", NullValueHandling = NullValueHandling.Ignore)]
        public string Mcc { get; }

        /// <summary>
        /// The URL of a full-format logo image for the location. When configured in the Seller
        /// dashboard (Receipts section), the logo appears on transactions (such as receipts and invoices)
        /// that Square generates on behalf of the Seller. This image can be wider than it is tall,
        /// and is recommended to be at least 1280x648 pixels.
        /// </summary>
        [JsonProperty("full_format_logo_url", NullValueHandling = NullValueHandling.Ignore)]
        public string FullFormatLogoUrl { get; }

        /// <summary>
        /// Identifiers for the location used by various governments for tax purposes.
        /// </summary>
        [JsonProperty("tax_ids", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TaxIds TaxIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Location : ({string.Join(", ", toStringOutput)})";
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

            return obj is Location other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Address == null && other.Address == null) || (this.Address?.Equals(other.Address) == true)) &&
                ((this.Timezone == null && other.Timezone == null) || (this.Timezone?.Equals(other.Timezone) == true)) &&
                ((this.Capabilities == null && other.Capabilities == null) || (this.Capabilities?.Equals(other.Capabilities) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.MerchantId == null && other.MerchantId == null) || (this.MerchantId?.Equals(other.MerchantId) == true)) &&
                ((this.Country == null && other.Country == null) || (this.Country?.Equals(other.Country) == true)) &&
                ((this.LanguageCode == null && other.LanguageCode == null) || (this.LanguageCode?.Equals(other.LanguageCode) == true)) &&
                ((this.Currency == null && other.Currency == null) || (this.Currency?.Equals(other.Currency) == true)) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((this.BusinessName == null && other.BusinessName == null) || (this.BusinessName?.Equals(other.BusinessName) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.WebsiteUrl == null && other.WebsiteUrl == null) || (this.WebsiteUrl?.Equals(other.WebsiteUrl) == true)) &&
                ((this.BusinessHours == null && other.BusinessHours == null) || (this.BusinessHours?.Equals(other.BusinessHours) == true)) &&
                ((this.BusinessEmail == null && other.BusinessEmail == null) || (this.BusinessEmail?.Equals(other.BusinessEmail) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.TwitterUsername == null && other.TwitterUsername == null) || (this.TwitterUsername?.Equals(other.TwitterUsername) == true)) &&
                ((this.InstagramUsername == null && other.InstagramUsername == null) || (this.InstagramUsername?.Equals(other.InstagramUsername) == true)) &&
                ((this.FacebookUrl == null && other.FacebookUrl == null) || (this.FacebookUrl?.Equals(other.FacebookUrl) == true)) &&
                ((this.Coordinates == null && other.Coordinates == null) || (this.Coordinates?.Equals(other.Coordinates) == true)) &&
                ((this.LogoUrl == null && other.LogoUrl == null) || (this.LogoUrl?.Equals(other.LogoUrl) == true)) &&
                ((this.PosBackgroundUrl == null && other.PosBackgroundUrl == null) || (this.PosBackgroundUrl?.Equals(other.PosBackgroundUrl) == true)) &&
                ((this.Mcc == null && other.Mcc == null) || (this.Mcc?.Equals(other.Mcc) == true)) &&
                ((this.FullFormatLogoUrl == null && other.FullFormatLogoUrl == null) || (this.FullFormatLogoUrl?.Equals(other.FullFormatLogoUrl) == true)) &&
                ((this.TaxIds == null && other.TaxIds == null) || (this.TaxIds?.Equals(other.TaxIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 232879438;
            hashCode = HashCode.Combine(this.Id, this.Name, this.Address, this.Timezone, this.Capabilities, this.Status, this.CreatedAt);

            hashCode = HashCode.Combine(hashCode, this.MerchantId, this.Country, this.LanguageCode, this.Currency, this.PhoneNumber, this.BusinessName, this.Type);

            hashCode = HashCode.Combine(hashCode, this.WebsiteUrl, this.BusinessHours, this.BusinessEmail, this.Description, this.TwitterUsername, this.InstagramUsername, this.FacebookUrl);

            hashCode = HashCode.Combine(hashCode, this.Coordinates, this.LogoUrl, this.PosBackgroundUrl, this.Mcc, this.FullFormatLogoUrl, this.TaxIds);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Address = {(this.Address == null ? "null" : this.Address.ToString())}");
            toStringOutput.Add($"this.Timezone = {(this.Timezone == null ? "null" : this.Timezone == string.Empty ? "" : this.Timezone)}");
            toStringOutput.Add($"this.Capabilities = {(this.Capabilities == null ? "null" : $"[{string.Join(", ", this.Capabilities)} ]")}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.MerchantId = {(this.MerchantId == null ? "null" : this.MerchantId == string.Empty ? "" : this.MerchantId)}");
            toStringOutput.Add($"this.Country = {(this.Country == null ? "null" : this.Country.ToString())}");
            toStringOutput.Add($"this.LanguageCode = {(this.LanguageCode == null ? "null" : this.LanguageCode == string.Empty ? "" : this.LanguageCode)}");
            toStringOutput.Add($"this.Currency = {(this.Currency == null ? "null" : this.Currency.ToString())}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber == string.Empty ? "" : this.PhoneNumber)}");
            toStringOutput.Add($"this.BusinessName = {(this.BusinessName == null ? "null" : this.BusinessName == string.Empty ? "" : this.BusinessName)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.WebsiteUrl = {(this.WebsiteUrl == null ? "null" : this.WebsiteUrl == string.Empty ? "" : this.WebsiteUrl)}");
            toStringOutput.Add($"this.BusinessHours = {(this.BusinessHours == null ? "null" : this.BusinessHours.ToString())}");
            toStringOutput.Add($"this.BusinessEmail = {(this.BusinessEmail == null ? "null" : this.BusinessEmail == string.Empty ? "" : this.BusinessEmail)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.TwitterUsername = {(this.TwitterUsername == null ? "null" : this.TwitterUsername == string.Empty ? "" : this.TwitterUsername)}");
            toStringOutput.Add($"this.InstagramUsername = {(this.InstagramUsername == null ? "null" : this.InstagramUsername == string.Empty ? "" : this.InstagramUsername)}");
            toStringOutput.Add($"this.FacebookUrl = {(this.FacebookUrl == null ? "null" : this.FacebookUrl == string.Empty ? "" : this.FacebookUrl)}");
            toStringOutput.Add($"this.Coordinates = {(this.Coordinates == null ? "null" : this.Coordinates.ToString())}");
            toStringOutput.Add($"this.LogoUrl = {(this.LogoUrl == null ? "null" : this.LogoUrl == string.Empty ? "" : this.LogoUrl)}");
            toStringOutput.Add($"this.PosBackgroundUrl = {(this.PosBackgroundUrl == null ? "null" : this.PosBackgroundUrl == string.Empty ? "" : this.PosBackgroundUrl)}");
            toStringOutput.Add($"this.Mcc = {(this.Mcc == null ? "null" : this.Mcc == string.Empty ? "" : this.Mcc)}");
            toStringOutput.Add($"this.FullFormatLogoUrl = {(this.FullFormatLogoUrl == null ? "null" : this.FullFormatLogoUrl == string.Empty ? "" : this.FullFormatLogoUrl)}");
            toStringOutput.Add($"this.TaxIds = {(this.TaxIds == null ? "null" : this.TaxIds.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .Name(this.Name)
                .Address(this.Address)
                .Timezone(this.Timezone)
                .Capabilities(this.Capabilities)
                .Status(this.Status)
                .CreatedAt(this.CreatedAt)
                .MerchantId(this.MerchantId)
                .Country(this.Country)
                .LanguageCode(this.LanguageCode)
                .Currency(this.Currency)
                .PhoneNumber(this.PhoneNumber)
                .BusinessName(this.BusinessName)
                .Type(this.Type)
                .WebsiteUrl(this.WebsiteUrl)
                .BusinessHours(this.BusinessHours)
                .BusinessEmail(this.BusinessEmail)
                .Description(this.Description)
                .TwitterUsername(this.TwitterUsername)
                .InstagramUsername(this.InstagramUsername)
                .FacebookUrl(this.FacebookUrl)
                .Coordinates(this.Coordinates)
                .LogoUrl(this.LogoUrl)
                .PosBackgroundUrl(this.PosBackgroundUrl)
                .Mcc(this.Mcc)
                .FullFormatLogoUrl(this.FullFormatLogoUrl)
                .TaxIds(this.TaxIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
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
            private Models.TaxIds taxIds;

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
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

             /// <summary>
             /// Address.
             /// </summary>
             /// <param name="address"> address. </param>
             /// <returns> Builder. </returns>
            public Builder Address(Models.Address address)
            {
                this.address = address;
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
             /// Capabilities.
             /// </summary>
             /// <param name="capabilities"> capabilities. </param>
             /// <returns> Builder. </returns>
            public Builder Capabilities(IList<string> capabilities)
            {
                this.capabilities = capabilities;
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
             /// LanguageCode.
             /// </summary>
             /// <param name="languageCode"> languageCode. </param>
             /// <returns> Builder. </returns>
            public Builder LanguageCode(string languageCode)
            {
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
             /// PhoneNumber.
             /// </summary>
             /// <param name="phoneNumber"> phoneNumber. </param>
             /// <returns> Builder. </returns>
            public Builder PhoneNumber(string phoneNumber)
            {
                this.phoneNumber = phoneNumber;
                return this;
            }

             /// <summary>
             /// BusinessName.
             /// </summary>
             /// <param name="businessName"> businessName. </param>
             /// <returns> Builder. </returns>
            public Builder BusinessName(string businessName)
            {
                this.businessName = businessName;
                return this;
            }

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// WebsiteUrl.
             /// </summary>
             /// <param name="websiteUrl"> websiteUrl. </param>
             /// <returns> Builder. </returns>
            public Builder WebsiteUrl(string websiteUrl)
            {
                this.websiteUrl = websiteUrl;
                return this;
            }

             /// <summary>
             /// BusinessHours.
             /// </summary>
             /// <param name="businessHours"> businessHours. </param>
             /// <returns> Builder. </returns>
            public Builder BusinessHours(Models.BusinessHours businessHours)
            {
                this.businessHours = businessHours;
                return this;
            }

             /// <summary>
             /// BusinessEmail.
             /// </summary>
             /// <param name="businessEmail"> businessEmail. </param>
             /// <returns> Builder. </returns>
            public Builder BusinessEmail(string businessEmail)
            {
                this.businessEmail = businessEmail;
                return this;
            }

             /// <summary>
             /// Description.
             /// </summary>
             /// <param name="description"> description. </param>
             /// <returns> Builder. </returns>
            public Builder Description(string description)
            {
                this.description = description;
                return this;
            }

             /// <summary>
             /// TwitterUsername.
             /// </summary>
             /// <param name="twitterUsername"> twitterUsername. </param>
             /// <returns> Builder. </returns>
            public Builder TwitterUsername(string twitterUsername)
            {
                this.twitterUsername = twitterUsername;
                return this;
            }

             /// <summary>
             /// InstagramUsername.
             /// </summary>
             /// <param name="instagramUsername"> instagramUsername. </param>
             /// <returns> Builder. </returns>
            public Builder InstagramUsername(string instagramUsername)
            {
                this.instagramUsername = instagramUsername;
                return this;
            }

             /// <summary>
             /// FacebookUrl.
             /// </summary>
             /// <param name="facebookUrl"> facebookUrl. </param>
             /// <returns> Builder. </returns>
            public Builder FacebookUrl(string facebookUrl)
            {
                this.facebookUrl = facebookUrl;
                return this;
            }

             /// <summary>
             /// Coordinates.
             /// </summary>
             /// <param name="coordinates"> coordinates. </param>
             /// <returns> Builder. </returns>
            public Builder Coordinates(Models.Coordinates coordinates)
            {
                this.coordinates = coordinates;
                return this;
            }

             /// <summary>
             /// LogoUrl.
             /// </summary>
             /// <param name="logoUrl"> logoUrl. </param>
             /// <returns> Builder. </returns>
            public Builder LogoUrl(string logoUrl)
            {
                this.logoUrl = logoUrl;
                return this;
            }

             /// <summary>
             /// PosBackgroundUrl.
             /// </summary>
             /// <param name="posBackgroundUrl"> posBackgroundUrl. </param>
             /// <returns> Builder. </returns>
            public Builder PosBackgroundUrl(string posBackgroundUrl)
            {
                this.posBackgroundUrl = posBackgroundUrl;
                return this;
            }

             /// <summary>
             /// Mcc.
             /// </summary>
             /// <param name="mcc"> mcc. </param>
             /// <returns> Builder. </returns>
            public Builder Mcc(string mcc)
            {
                this.mcc = mcc;
                return this;
            }

             /// <summary>
             /// FullFormatLogoUrl.
             /// </summary>
             /// <param name="fullFormatLogoUrl"> fullFormatLogoUrl. </param>
             /// <returns> Builder. </returns>
            public Builder FullFormatLogoUrl(string fullFormatLogoUrl)
            {
                this.fullFormatLogoUrl = fullFormatLogoUrl;
                return this;
            }

             /// <summary>
             /// TaxIds.
             /// </summary>
             /// <param name="taxIds"> taxIds. </param>
             /// <returns> Builder. </returns>
            public Builder TaxIds(Models.TaxIds taxIds)
            {
                this.taxIds = taxIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Location. </returns>
            public Location Build()
            {
                return new Location(
                    this.id,
                    this.name,
                    this.address,
                    this.timezone,
                    this.capabilities,
                    this.status,
                    this.createdAt,
                    this.merchantId,
                    this.country,
                    this.languageCode,
                    this.currency,
                    this.phoneNumber,
                    this.businessName,
                    this.type,
                    this.websiteUrl,
                    this.businessHours,
                    this.businessEmail,
                    this.description,
                    this.twitterUsername,
                    this.instagramUsername,
                    this.facebookUrl,
                    this.coordinates,
                    this.logoUrl,
                    this.posBackgroundUrl,
                    this.mcc,
                    this.fullFormatLogoUrl,
                    this.taxIds);
            }
        }
    }
}