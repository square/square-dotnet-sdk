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
    /// UpdateCustomerRequest.
    /// </summary>
    public class UpdateCustomerRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCustomerRequest"/> class.
        /// </summary>
        /// <param name="givenName">given_name.</param>
        /// <param name="familyName">family_name.</param>
        /// <param name="companyName">company_name.</param>
        /// <param name="nickname">nickname.</param>
        /// <param name="emailAddress">email_address.</param>
        /// <param name="address">address.</param>
        /// <param name="phoneNumber">phone_number.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="note">note.</param>
        /// <param name="birthday">birthday.</param>
        /// <param name="version">version.</param>
        public UpdateCustomerRequest(
            string givenName = null,
            string familyName = null,
            string companyName = null,
            string nickname = null,
            string emailAddress = null,
            Models.Address address = null,
            string phoneNumber = null,
            string referenceId = null,
            string note = null,
            string birthday = null,
            long? version = null)
        {
            this.GivenName = givenName;
            this.FamilyName = familyName;
            this.CompanyName = companyName;
            this.Nickname = nickname;
            this.EmailAddress = emailAddress;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.ReferenceId = referenceId;
            this.Note = note;
            this.Birthday = birthday;
            this.Version = version;
        }

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
        /// A business name associated with the customer profile.
        /// </summary>
        [JsonProperty("company_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyName { get; }

        /// <summary>
        /// A nickname for the customer profile.
        /// </summary>
        [JsonProperty("nickname", NullValueHandling = NullValueHandling.Ignore)]
        public string Nickname { get; }

        /// <summary>
        /// The email address associated with the customer profile.
        /// </summary>
        [JsonProperty("email_address", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; }

        /// <summary>
        /// Represents a physical address.
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address Address { get; }

        /// <summary>
        /// The 11-digit phone number associated with the customer profile.
        /// </summary>
        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; }

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
        /// The birthday associated with the customer profile, in RFC 3339 format. The year is optional. The timezone and time are not allowed.
        /// For example, `0000-09-21T00:00:00-00:00` represents a birthday on September 21 and `1998-09-21T00:00:00-00:00` represents a birthday on September 21, 1998.
        /// You can also specify this value in `YYYY-MM-DD` format.
        /// </summary>
        [JsonProperty("birthday", NullValueHandling = NullValueHandling.Ignore)]
        public string Birthday { get; }

        /// <summary>
        /// The current version of the customer profile.
        /// As a best practice, you should include this field to enable [optimistic concurrency](https://developer.squareup.com/docs/working-with-apis/optimistic-concurrency) control. For more information, see [Update a customer profile](https://developer.squareup.com/docs/customers-api/use-the-api/keep-records#update-a-customer-profile).
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public long? Version { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateCustomerRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is UpdateCustomerRequest other &&
                ((this.GivenName == null && other.GivenName == null) || (this.GivenName?.Equals(other.GivenName) == true)) &&
                ((this.FamilyName == null && other.FamilyName == null) || (this.FamilyName?.Equals(other.FamilyName) == true)) &&
                ((this.CompanyName == null && other.CompanyName == null) || (this.CompanyName?.Equals(other.CompanyName) == true)) &&
                ((this.Nickname == null && other.Nickname == null) || (this.Nickname?.Equals(other.Nickname) == true)) &&
                ((this.EmailAddress == null && other.EmailAddress == null) || (this.EmailAddress?.Equals(other.EmailAddress) == true)) &&
                ((this.Address == null && other.Address == null) || (this.Address?.Equals(other.Address) == true)) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((this.Note == null && other.Note == null) || (this.Note?.Equals(other.Note) == true)) &&
                ((this.Birthday == null && other.Birthday == null) || (this.Birthday?.Equals(other.Birthday) == true)) &&
                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1250370317;

            if (this.GivenName != null)
            {
               hashCode += this.GivenName.GetHashCode();
            }

            if (this.FamilyName != null)
            {
               hashCode += this.FamilyName.GetHashCode();
            }

            if (this.CompanyName != null)
            {
               hashCode += this.CompanyName.GetHashCode();
            }

            if (this.Nickname != null)
            {
               hashCode += this.Nickname.GetHashCode();
            }

            if (this.EmailAddress != null)
            {
               hashCode += this.EmailAddress.GetHashCode();
            }

            if (this.Address != null)
            {
               hashCode += this.Address.GetHashCode();
            }

            if (this.PhoneNumber != null)
            {
               hashCode += this.PhoneNumber.GetHashCode();
            }

            if (this.ReferenceId != null)
            {
               hashCode += this.ReferenceId.GetHashCode();
            }

            if (this.Note != null)
            {
               hashCode += this.Note.GetHashCode();
            }

            if (this.Birthday != null)
            {
               hashCode += this.Birthday.GetHashCode();
            }

            if (this.Version != null)
            {
               hashCode += this.Version.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.GivenName = {(this.GivenName == null ? "null" : this.GivenName == string.Empty ? "" : this.GivenName)}");
            toStringOutput.Add($"this.FamilyName = {(this.FamilyName == null ? "null" : this.FamilyName == string.Empty ? "" : this.FamilyName)}");
            toStringOutput.Add($"this.CompanyName = {(this.CompanyName == null ? "null" : this.CompanyName == string.Empty ? "" : this.CompanyName)}");
            toStringOutput.Add($"this.Nickname = {(this.Nickname == null ? "null" : this.Nickname == string.Empty ? "" : this.Nickname)}");
            toStringOutput.Add($"this.EmailAddress = {(this.EmailAddress == null ? "null" : this.EmailAddress == string.Empty ? "" : this.EmailAddress)}");
            toStringOutput.Add($"this.Address = {(this.Address == null ? "null" : this.Address.ToString())}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber == string.Empty ? "" : this.PhoneNumber)}");
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId == string.Empty ? "" : this.ReferenceId)}");
            toStringOutput.Add($"this.Note = {(this.Note == null ? "null" : this.Note == string.Empty ? "" : this.Note)}");
            toStringOutput.Add($"this.Birthday = {(this.Birthday == null ? "null" : this.Birthday == string.Empty ? "" : this.Birthday)}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .GivenName(this.GivenName)
                .FamilyName(this.FamilyName)
                .CompanyName(this.CompanyName)
                .Nickname(this.Nickname)
                .EmailAddress(this.EmailAddress)
                .Address(this.Address)
                .PhoneNumber(this.PhoneNumber)
                .ReferenceId(this.ReferenceId)
                .Note(this.Note)
                .Birthday(this.Birthday)
                .Version(this.Version);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string givenName;
            private string familyName;
            private string companyName;
            private string nickname;
            private string emailAddress;
            private Models.Address address;
            private string phoneNumber;
            private string referenceId;
            private string note;
            private string birthday;
            private long? version;

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
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateCustomerRequest. </returns>
            public UpdateCustomerRequest Build()
            {
                return new UpdateCustomerRequest(
                    this.givenName,
                    this.familyName,
                    this.companyName,
                    this.nickname,
                    this.emailAddress,
                    this.address,
                    this.phoneNumber,
                    this.referenceId,
                    this.note,
                    this.birthday,
                    this.version);
            }
        }
    }
}