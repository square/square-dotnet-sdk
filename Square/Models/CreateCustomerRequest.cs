
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
    public class CreateCustomerRequest 
    {
        public CreateCustomerRequest(string idempotencyKey = null,
            string givenName = null,
            string familyName = null,
            string companyName = null,
            string nickname = null,
            string emailAddress = null,
            Models.Address address = null,
            string phoneNumber = null,
            string referenceId = null,
            string note = null,
            string birthday = null)
        {
            IdempotencyKey = idempotencyKey;
            GivenName = givenName;
            FamilyName = familyName;
            CompanyName = companyName;
            Nickname = nickname;
            EmailAddress = emailAddress;
            Address = address;
            PhoneNumber = phoneNumber;
            ReferenceId = referenceId;
            Note = note;
            Birthday = birthday;
        }

        /// <summary>
        /// The idempotency key for the request.	See the
        /// [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency) guide for more information.
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The given (i.e., first) name associated with the customer profile.
        /// </summary>
        [JsonProperty("given_name", NullValueHandling = NullValueHandling.Ignore)]
        public string GivenName { get; }

        /// <summary>
        /// The family (i.e., last) name associated with the customer profile.
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
        /// An optional, second ID used to associate the customer profile with an
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
        /// The birthday associated with the customer profile, in RFC 3339 format.
        /// Year is optional, timezone and times are not allowed.
        /// For example: `0000-09-01T00:00:00-00:00` indicates a birthday on September 1st.
        /// `1998-09-01T00:00:00-00:00` indications a birthday on September 1st __1998__.
        /// </summary>
        [JsonProperty("birthday", NullValueHandling = NullValueHandling.Ignore)]
        public string Birthday { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateCustomerRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
            toStringOutput.Add($"GivenName = {(GivenName == null ? "null" : GivenName == string.Empty ? "" : GivenName)}");
            toStringOutput.Add($"FamilyName = {(FamilyName == null ? "null" : FamilyName == string.Empty ? "" : FamilyName)}");
            toStringOutput.Add($"CompanyName = {(CompanyName == null ? "null" : CompanyName == string.Empty ? "" : CompanyName)}");
            toStringOutput.Add($"Nickname = {(Nickname == null ? "null" : Nickname == string.Empty ? "" : Nickname)}");
            toStringOutput.Add($"EmailAddress = {(EmailAddress == null ? "null" : EmailAddress == string.Empty ? "" : EmailAddress)}");
            toStringOutput.Add($"Address = {(Address == null ? "null" : Address.ToString())}");
            toStringOutput.Add($"PhoneNumber = {(PhoneNumber == null ? "null" : PhoneNumber == string.Empty ? "" : PhoneNumber)}");
            toStringOutput.Add($"ReferenceId = {(ReferenceId == null ? "null" : ReferenceId == string.Empty ? "" : ReferenceId)}");
            toStringOutput.Add($"Note = {(Note == null ? "null" : Note == string.Empty ? "" : Note)}");
            toStringOutput.Add($"Birthday = {(Birthday == null ? "null" : Birthday == string.Empty ? "" : Birthday)}");
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

            return obj is CreateCustomerRequest other &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((GivenName == null && other.GivenName == null) || (GivenName?.Equals(other.GivenName) == true)) &&
                ((FamilyName == null && other.FamilyName == null) || (FamilyName?.Equals(other.FamilyName) == true)) &&
                ((CompanyName == null && other.CompanyName == null) || (CompanyName?.Equals(other.CompanyName) == true)) &&
                ((Nickname == null && other.Nickname == null) || (Nickname?.Equals(other.Nickname) == true)) &&
                ((EmailAddress == null && other.EmailAddress == null) || (EmailAddress?.Equals(other.EmailAddress) == true)) &&
                ((Address == null && other.Address == null) || (Address?.Equals(other.Address) == true)) &&
                ((PhoneNumber == null && other.PhoneNumber == null) || (PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((ReferenceId == null && other.ReferenceId == null) || (ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((Note == null && other.Note == null) || (Note?.Equals(other.Note) == true)) &&
                ((Birthday == null && other.Birthday == null) || (Birthday?.Equals(other.Birthday) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 769706177;

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            if (GivenName != null)
            {
               hashCode += GivenName.GetHashCode();
            }

            if (FamilyName != null)
            {
               hashCode += FamilyName.GetHashCode();
            }

            if (CompanyName != null)
            {
               hashCode += CompanyName.GetHashCode();
            }

            if (Nickname != null)
            {
               hashCode += Nickname.GetHashCode();
            }

            if (EmailAddress != null)
            {
               hashCode += EmailAddress.GetHashCode();
            }

            if (Address != null)
            {
               hashCode += Address.GetHashCode();
            }

            if (PhoneNumber != null)
            {
               hashCode += PhoneNumber.GetHashCode();
            }

            if (ReferenceId != null)
            {
               hashCode += ReferenceId.GetHashCode();
            }

            if (Note != null)
            {
               hashCode += Note.GetHashCode();
            }

            if (Birthday != null)
            {
               hashCode += Birthday.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .IdempotencyKey(IdempotencyKey)
                .GivenName(GivenName)
                .FamilyName(FamilyName)
                .CompanyName(CompanyName)
                .Nickname(Nickname)
                .EmailAddress(EmailAddress)
                .Address(Address)
                .PhoneNumber(PhoneNumber)
                .ReferenceId(ReferenceId)
                .Note(Note)
                .Birthday(Birthday);
            return builder;
        }

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



            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public Builder GivenName(string givenName)
            {
                this.givenName = givenName;
                return this;
            }

            public Builder FamilyName(string familyName)
            {
                this.familyName = familyName;
                return this;
            }

            public Builder CompanyName(string companyName)
            {
                this.companyName = companyName;
                return this;
            }

            public Builder Nickname(string nickname)
            {
                this.nickname = nickname;
                return this;
            }

            public Builder EmailAddress(string emailAddress)
            {
                this.emailAddress = emailAddress;
                return this;
            }

            public Builder Address(Models.Address address)
            {
                this.address = address;
                return this;
            }

            public Builder PhoneNumber(string phoneNumber)
            {
                this.phoneNumber = phoneNumber;
                return this;
            }

            public Builder ReferenceId(string referenceId)
            {
                this.referenceId = referenceId;
                return this;
            }

            public Builder Note(string note)
            {
                this.note = note;
                return this;
            }

            public Builder Birthday(string birthday)
            {
                this.birthday = birthday;
                return this;
            }

            public CreateCustomerRequest Build()
            {
                return new CreateCustomerRequest(idempotencyKey,
                    givenName,
                    familyName,
                    companyName,
                    nickname,
                    emailAddress,
                    address,
                    phoneNumber,
                    referenceId,
                    note,
                    birthday);
            }
        }
    }
}