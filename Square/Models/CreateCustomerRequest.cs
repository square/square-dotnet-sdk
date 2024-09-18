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
    /// CreateCustomerRequest.
    /// </summary>
    public class CreateCustomerRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
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
        /// <param name="taxIds">tax_ids.</param>
        public CreateCustomerRequest(
            string idempotencyKey = null,
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
            Models.CustomerTaxIds taxIds = null)
        {
            this.IdempotencyKey = idempotencyKey;
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
            this.TaxIds = taxIds;
        }

        /// <summary>
        /// The idempotency key for the request.	For more information, see
        /// [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The given name (that is, the first name) associated with the customer profile.
        /// The maximum length for this value is 300 characters.
        /// </summary>
        [JsonProperty("given_name", NullValueHandling = NullValueHandling.Ignore)]
        public string GivenName { get; }

        /// <summary>
        /// The family name (that is, the last name) associated with the customer profile.
        /// The maximum length for this value is 300 characters.
        /// </summary>
        [JsonProperty("family_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FamilyName { get; }

        /// <summary>
        /// A business name associated with the customer profile.
        /// The maximum length for this value is 500 characters.
        /// </summary>
        [JsonProperty("company_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyName { get; }

        /// <summary>
        /// A nickname for the customer profile.
        /// The maximum length for this value is 100 characters.
        /// </summary>
        [JsonProperty("nickname", NullValueHandling = NullValueHandling.Ignore)]
        public string Nickname { get; }

        /// <summary>
        /// The email address associated with the customer profile.
        /// The maximum length for this value is 254 characters.
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
        /// The phone number associated with the customer profile. The phone number must be valid and can contain
        /// 9–16 digits, with an optional `+` prefix and country code. For more information, see
        /// [Customer phone numbers](https://developer.squareup.com/docs/customers-api/use-the-api/keep-records#phone-number).
        /// </summary>
        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; }

        /// <summary>
        /// An optional second ID used to associate the customer profile with an
        /// entity in another system.
        /// The maximum length for this value is 100 characters.
        /// </summary>
        [JsonProperty("reference_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceId { get; }

        /// <summary>
        /// A custom note associated with the customer profile.
        /// </summary>
        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; }

        /// <summary>
        /// The birthday associated with the customer profile, in `YYYY-MM-DD` or `MM-DD` format. For example,
        /// specify `1998-09-21` for September 21, 1998, or `09-21` for September 21. Birthdays are returned in `YYYY-MM-DD`
        /// format, where `YYYY` is the specified birth year or `0000` if a birth year is not specified.
        /// </summary>
        [JsonProperty("birthday", NullValueHandling = NullValueHandling.Ignore)]
        public string Birthday { get; }

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

            return $"CreateCustomerRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is CreateCustomerRequest other &&                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
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
                ((this.TaxIds == null && other.TaxIds == null) || (this.TaxIds?.Equals(other.TaxIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 786103414;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.GivenName, this.FamilyName, this.CompanyName, this.Nickname, this.EmailAddress, this.Address);

            hashCode = HashCode.Combine(hashCode, this.PhoneNumber, this.ReferenceId, this.Note, this.Birthday, this.TaxIds);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.GivenName = {(this.GivenName == null ? "null" : this.GivenName)}");
            toStringOutput.Add($"this.FamilyName = {(this.FamilyName == null ? "null" : this.FamilyName)}");
            toStringOutput.Add($"this.CompanyName = {(this.CompanyName == null ? "null" : this.CompanyName)}");
            toStringOutput.Add($"this.Nickname = {(this.Nickname == null ? "null" : this.Nickname)}");
            toStringOutput.Add($"this.EmailAddress = {(this.EmailAddress == null ? "null" : this.EmailAddress)}");
            toStringOutput.Add($"this.Address = {(this.Address == null ? "null" : this.Address.ToString())}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber)}");
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId)}");
            toStringOutput.Add($"this.Note = {(this.Note == null ? "null" : this.Note)}");
            toStringOutput.Add($"this.Birthday = {(this.Birthday == null ? "null" : this.Birthday)}");
            toStringOutput.Add($"this.TaxIds = {(this.TaxIds == null ? "null" : this.TaxIds.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .IdempotencyKey(this.IdempotencyKey)
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
                .TaxIds(this.TaxIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
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
            private Models.CustomerTaxIds taxIds;

             /// <summary>
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
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
            /// <returns> CreateCustomerRequest. </returns>
            public CreateCustomerRequest Build()
            {
                return new CreateCustomerRequest(
                    this.idempotencyKey,
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
                    this.taxIds);
            }
        }
    }
}