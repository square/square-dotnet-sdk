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