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
    /// Customer.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="cards">cards.</param>
        /// <param name="givenName">given_name.</param>
        /// <param name="familyName">family_name.</param>
        /// <param name="nickname">nickname.</param>
        /// <param name="companyName">company_name.</param>
        /// <param name="emailAddress">email_address.</param>
        /// <param name="address">address.</param>
        /// <param name="phoneNumber">phone_number.</param>
        /// <param name="birthday">birthday.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="note">note.</param>
        /// <param name="preferences">preferences.</param>
        /// <param name="creationSource">creation_source.</param>
        /// <param name="groupIds">group_ids.</param>
        /// <param name="segmentIds">segment_ids.</param>
        /// <param name="version">version.</param>
        /// <param name="taxIds">tax_ids.</param>
        public Customer(
            string id = null,
            string createdAt = null,
            string updatedAt = null,
            IList<Models.Card> cards = null,
            string givenName = null,
            string familyName = null,
            string nickname = null,
            string companyName = null,
            string emailAddress = null,
            Models.Address address = null,
            string phoneNumber = null,
            string birthday = null,
            string referenceId = null,
            string note = null,
            Models.CustomerPreferences preferences = null,
            string creationSource = null,
            IList<string> groupIds = null,
            IList<string> segmentIds = null,
            long? version = null,
            Models.CustomerTaxIds taxIds = null)
        {
            this.Id = id;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.Cards = cards;
            this.GivenName = givenName;
            this.FamilyName = familyName;
            this.Nickname = nickname;
            this.CompanyName = companyName;
            this.EmailAddress = emailAddress;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Birthday = birthday;
            this.ReferenceId = referenceId;
            this.Note = note;
            this.Preferences = preferences;
            this.CreationSource = creationSource;
            this.GroupIds = groupIds;
            this.SegmentIds = segmentIds;
            this.Version = version;
            this.TaxIds = taxIds;
        }

        /// <summary>
        /// A unique Square-assigned ID for the customer profile.
        /// If you need this ID for an API request, use the ID returned when you created the customer profile or call the [SearchCustomers]($e/Customers/SearchCustomers)
        /// or [ListCustomers]($e/Customers/ListCustomers) endpoint.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The timestamp when the customer profile was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the customer profile was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// Payment details of the credit, debit, and gift cards stored on file for the customer profile.
        /// DEPRECATED at version 2021-06-16. Replaced by calling [ListCards]($e/Cards/ListCards) (for credit and debit cards on file)
        /// or [ListGiftCards]($e/GiftCards/ListGiftCards) (for gift cards on file) and including the `customer_id` query parameter.
        /// For more information, see [Migration notes](https://developer.squareup.com/docs/customers-api/what-it-does#migrate-customer-cards).
        /// </summary>
        [JsonProperty("cards", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Card> Cards { get; }

        /// <summary>
        /// The given name (that is, the first name) associated with the customer profile.
        /// </summary>
        [JsonProperty("given_name", NullValueHandling = NullValueHandling.Ignore)]
        public string GivenName { get; }

        /// <summary>
        /// The family name (that is, the last name) associated with the customer profile.
        /// </summary>
        [JsonProperty("family_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FamilyName { get; }

        /// <summary>
        /// A nickname for the customer profile.
        /// </summary>
        [JsonProperty("nickname", NullValueHandling = NullValueHandling.Ignore)]
        public string Nickname { get; }

        /// <summary>
        /// A business name associated with the customer profile.
        /// </summary>
        [JsonProperty("company_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyName { get; }

        /// <summary>
        /// The email address associated with the customer profile.
        /// </summary>
        [JsonProperty("email_address", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; }

        /// <summary>
        /// Represents a postal address in a country.
        /// For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address Address { get; }

        /// <summary>
        /// The phone number associated with the customer profile.
        /// </summary>
        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; }

        /// <summary>
        /// The birthday associated with the customer profile, in `YYYY-MM-DD` format. For example, `1998-09-21`
        /// represents September 21, 1998, and `0000-09-21` represents September 21 (without a birth year).
        /// </summary>
        [JsonProperty("birthday", NullValueHandling = NullValueHandling.Ignore)]
        public string Birthday { get; }

        /// <summary>
        /// An optional second ID used to associate the customer profile with an
        /// entity in another system.
        /// </summary>
        [JsonProperty("reference_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceId { get; }

        /// <summary>
        /// A custom note associated with the customer profile.
        /// </summary>
        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; }

        /// <summary>
        /// Represents communication preferences for the customer profile.
        /// </summary>
        [JsonProperty("preferences", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerPreferences Preferences { get; }

        /// <summary>
        /// Indicates the method used to create the customer profile.
        /// </summary>
        [JsonProperty("creation_source", NullValueHandling = NullValueHandling.Ignore)]
        public string CreationSource { get; }

        /// <summary>
        /// The IDs of customer groups the customer belongs to.
        /// </summary>
        [JsonProperty("group_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> GroupIds { get; }

        /// <summary>
        /// The IDs of segments the customer belongs to.
        /// </summary>
        [JsonProperty("segment_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> SegmentIds { get; }

        /// <summary>
        /// The Square-assigned version number of the customer profile. The version number is incremented each time an update is committed to the customer profile, except for changes to customer segment membership and cards on file.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public long? Version { get; }

        /// <summary>
        /// Represents the tax ID associated with a [customer profile]($m/Customer). The corresponding `tax_ids` field is available only for customers of sellers in EU countries or the United Kingdom.
        /// For more information, see [Customer tax IDs](https://developer.squareup.com/docs/customers-api/what-it-does#customer-tax-ids).
        /// </summary>
        [JsonProperty("tax_ids", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerTaxIds TaxIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Customer : ({string.Join(", ", toStringOutput)})";
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

            return obj is Customer other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.Cards == null && other.Cards == null) || (this.Cards?.Equals(other.Cards) == true)) &&
                ((this.GivenName == null && other.GivenName == null) || (this.GivenName?.Equals(other.GivenName) == true)) &&
                ((this.FamilyName == null && other.FamilyName == null) || (this.FamilyName?.Equals(other.FamilyName) == true)) &&
                ((this.Nickname == null && other.Nickname == null) || (this.Nickname?.Equals(other.Nickname) == true)) &&
                ((this.CompanyName == null && other.CompanyName == null) || (this.CompanyName?.Equals(other.CompanyName) == true)) &&
                ((this.EmailAddress == null && other.EmailAddress == null) || (this.EmailAddress?.Equals(other.EmailAddress) == true)) &&
                ((this.Address == null && other.Address == null) || (this.Address?.Equals(other.Address) == true)) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((this.Birthday == null && other.Birthday == null) || (this.Birthday?.Equals(other.Birthday) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((this.Note == null && other.Note == null) || (this.Note?.Equals(other.Note) == true)) &&
                ((this.Preferences == null && other.Preferences == null) || (this.Preferences?.Equals(other.Preferences) == true)) &&
                ((this.CreationSource == null && other.CreationSource == null) || (this.CreationSource?.Equals(other.CreationSource) == true)) &&
                ((this.GroupIds == null && other.GroupIds == null) || (this.GroupIds?.Equals(other.GroupIds) == true)) &&
                ((this.SegmentIds == null && other.SegmentIds == null) || (this.SegmentIds?.Equals(other.SegmentIds) == true)) &&
                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true)) &&
                ((this.TaxIds == null && other.TaxIds == null) || (this.TaxIds?.Equals(other.TaxIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1930083275;
            hashCode = HashCode.Combine(this.Id, this.CreatedAt, this.UpdatedAt, this.Cards, this.GivenName, this.FamilyName, this.Nickname);

            hashCode = HashCode.Combine(hashCode, this.CompanyName, this.EmailAddress, this.Address, this.PhoneNumber, this.Birthday, this.ReferenceId, this.Note);

            hashCode = HashCode.Combine(hashCode, this.Preferences, this.CreationSource, this.GroupIds, this.SegmentIds, this.Version, this.TaxIds);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
            toStringOutput.Add($"this.Cards = {(this.Cards == null ? "null" : $"[{string.Join(", ", this.Cards)} ]")}");
            toStringOutput.Add($"this.GivenName = {(this.GivenName == null ? "null" : this.GivenName == string.Empty ? "" : this.GivenName)}");
            toStringOutput.Add($"this.FamilyName = {(this.FamilyName == null ? "null" : this.FamilyName == string.Empty ? "" : this.FamilyName)}");
            toStringOutput.Add($"this.Nickname = {(this.Nickname == null ? "null" : this.Nickname == string.Empty ? "" : this.Nickname)}");
            toStringOutput.Add($"this.CompanyName = {(this.CompanyName == null ? "null" : this.CompanyName == string.Empty ? "" : this.CompanyName)}");
            toStringOutput.Add($"this.EmailAddress = {(this.EmailAddress == null ? "null" : this.EmailAddress == string.Empty ? "" : this.EmailAddress)}");
            toStringOutput.Add($"this.Address = {(this.Address == null ? "null" : this.Address.ToString())}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber == string.Empty ? "" : this.PhoneNumber)}");
            toStringOutput.Add($"this.Birthday = {(this.Birthday == null ? "null" : this.Birthday == string.Empty ? "" : this.Birthday)}");
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId == string.Empty ? "" : this.ReferenceId)}");
            toStringOutput.Add($"this.Note = {(this.Note == null ? "null" : this.Note == string.Empty ? "" : this.Note)}");
            toStringOutput.Add($"this.Preferences = {(this.Preferences == null ? "null" : this.Preferences.ToString())}");
            toStringOutput.Add($"this.CreationSource = {(this.CreationSource == null ? "null" : this.CreationSource.ToString())}");
            toStringOutput.Add($"this.GroupIds = {(this.GroupIds == null ? "null" : $"[{string.Join(", ", this.GroupIds)} ]")}");
            toStringOutput.Add($"this.SegmentIds = {(this.SegmentIds == null ? "null" : $"[{string.Join(", ", this.SegmentIds)} ]")}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
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
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .Cards(this.Cards)
                .GivenName(this.GivenName)
                .FamilyName(this.FamilyName)
                .Nickname(this.Nickname)
                .CompanyName(this.CompanyName)
                .EmailAddress(this.EmailAddress)
                .Address(this.Address)
                .PhoneNumber(this.PhoneNumber)
                .Birthday(this.Birthday)
                .ReferenceId(this.ReferenceId)
                .Note(this.Note)
                .Preferences(this.Preferences)
                .CreationSource(this.CreationSource)
                .GroupIds(this.GroupIds)
                .SegmentIds(this.SegmentIds)
                .Version(this.Version)
                .TaxIds(this.TaxIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string id;
            private string createdAt;
            private string updatedAt;
            private IList<Models.Card> cards;
            private string givenName;
            private string familyName;
            private string nickname;
            private string companyName;
            private string emailAddress;
            private Models.Address address;
            private string phoneNumber;
            private string birthday;
            private string referenceId;
            private string note;
            private Models.CustomerPreferences preferences;
            private string creationSource;
            private IList<string> groupIds;
            private IList<string> segmentIds;
            private long? version;
            private Models.CustomerTaxIds taxIds;

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
             /// Cards.
             /// </summary>
             /// <param name="cards"> cards. </param>
             /// <returns> Builder. </returns>
            public Builder Cards(IList<Models.Card> cards)
            {
                this.cards = cards;
                return this;
            }

             /// <summary>
             /// GivenName.
             /// </summary>
             /// <param name="givenName"> givenName. </param>
             /// <returns> Builder. </returns>
            public Builder GivenName(string givenName)
            {
                this.givenName = givenName;
                return this;
            }

             /// <summary>
             /// FamilyName.
             /// </summary>
             /// <param name="familyName"> familyName. </param>
             /// <returns> Builder. </returns>
            public Builder FamilyName(string familyName)
            {
                this.familyName = familyName;
                return this;
            }

             /// <summary>
             /// Nickname.
             /// </summary>
             /// <param name="nickname"> nickname. </param>
             /// <returns> Builder. </returns>
            public Builder Nickname(string nickname)
            {
                this.nickname = nickname;
                return this;
            }

             /// <summary>
             /// CompanyName.
             /// </summary>
             /// <param name="companyName"> companyName. </param>
             /// <returns> Builder. </returns>
            public Builder CompanyName(string companyName)
            {
                this.companyName = companyName;
                return this;
            }

             /// <summary>
             /// EmailAddress.
             /// </summary>
             /// <param name="emailAddress"> emailAddress. </param>
             /// <returns> Builder. </returns>
            public Builder EmailAddress(string emailAddress)
            {
                this.emailAddress = emailAddress;
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
             /// Birthday.
             /// </summary>
             /// <param name="birthday"> birthday. </param>
             /// <returns> Builder. </returns>
            public Builder Birthday(string birthday)
            {
                this.birthday = birthday;
                return this;
            }

             /// <summary>
             /// ReferenceId.
             /// </summary>
             /// <param name="referenceId"> referenceId. </param>
             /// <returns> Builder. </returns>
            public Builder ReferenceId(string referenceId)
            {
                this.referenceId = referenceId;
                return this;
            }

             /// <summary>
             /// Note.
             /// </summary>
             /// <param name="note"> note. </param>
             /// <returns> Builder. </returns>
            public Builder Note(string note)
            {
                this.note = note;
                return this;
            }

             /// <summary>
             /// Preferences.
             /// </summary>
             /// <param name="preferences"> preferences. </param>
             /// <returns> Builder. </returns>
            public Builder Preferences(Models.CustomerPreferences preferences)
            {
                this.preferences = preferences;
                return this;
            }

             /// <summary>
             /// CreationSource.
             /// </summary>
             /// <param name="creationSource"> creationSource. </param>
             /// <returns> Builder. </returns>
            public Builder CreationSource(string creationSource)
            {
                this.creationSource = creationSource;
                return this;
            }

             /// <summary>
             /// GroupIds.
             /// </summary>
             /// <param name="groupIds"> groupIds. </param>
             /// <returns> Builder. </returns>
            public Builder GroupIds(IList<string> groupIds)
            {
                this.groupIds = groupIds;
                return this;
            }

             /// <summary>
             /// SegmentIds.
             /// </summary>
             /// <param name="segmentIds"> segmentIds. </param>
             /// <returns> Builder. </returns>
            public Builder SegmentIds(IList<string> segmentIds)
            {
                this.segmentIds = segmentIds;
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
             /// TaxIds.
             /// </summary>
             /// <param name="taxIds"> taxIds. </param>
             /// <returns> Builder. </returns>
            public Builder TaxIds(Models.CustomerTaxIds taxIds)
            {
                this.taxIds = taxIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Customer. </returns>
            public Customer Build()
            {
                return new Customer(
                    this.id,
                    this.createdAt,
                    this.updatedAt,
                    this.cards,
                    this.givenName,
                    this.familyName,
                    this.nickname,
                    this.companyName,
                    this.emailAddress,
                    this.address,
                    this.phoneNumber,
                    this.birthday,
                    this.referenceId,
                    this.note,
                    this.preferences,
                    this.creationSource,
                    this.groupIds,
                    this.segmentIds,
                    this.version,
                    this.taxIds);
            }
        }
    }
}