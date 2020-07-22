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
    public class InvoiceRecipient 
    {
        public InvoiceRecipient(string customerId = null,
            string givenName = null,
            string familyName = null,
            string emailAddress = null,
            Models.Address address = null,
            string phoneNumber = null,
            string companyName = null)
        {
            CustomerId = customerId;
            GivenName = givenName;
            FamilyName = familyName;
            EmailAddress = emailAddress;
            Address = address;
            PhoneNumber = phoneNumber;
            CompanyName = companyName;
        }

        /// <summary>
        /// The ID of the customer. This is the customer profile ID that 
        /// you provide when creating a draft invoice.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <summary>
        /// The recipient's given (that is, first) name.
        /// </summary>
        [JsonProperty("given_name")]
        public string GivenName { get; }

        /// <summary>
        /// The recipient's family (that is, last) name.
        /// </summary>
        [JsonProperty("family_name")]
        public string FamilyName { get; }

        /// <summary>
        /// The recipient's email address.
        /// </summary>
        [JsonProperty("email_address")]
        public string EmailAddress { get; }

        /// <summary>
        /// Represents a physical address.
        /// </summary>
        [JsonProperty("address")]
        public Models.Address Address { get; }

        /// <summary>
        /// The recipient's phone number.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; }

        /// <summary>
        /// The name of the recipient's company.
        /// </summary>
        [JsonProperty("company_name")]
        public string CompanyName { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CustomerId(CustomerId)
                .GivenName(GivenName)
                .FamilyName(FamilyName)
                .EmailAddress(EmailAddress)
                .Address(Address)
                .PhoneNumber(PhoneNumber)
                .CompanyName(CompanyName);
            return builder;
        }

        public class Builder
        {
            private string customerId;
            private string givenName;
            private string familyName;
            private string emailAddress;
            private Models.Address address;
            private string phoneNumber;
            private string companyName;

            public Builder() { }
            public Builder CustomerId(string value)
            {
                customerId = value;
                return this;
            }

            public Builder GivenName(string value)
            {
                givenName = value;
                return this;
            }

            public Builder FamilyName(string value)
            {
                familyName = value;
                return this;
            }

            public Builder EmailAddress(string value)
            {
                emailAddress = value;
                return this;
            }

            public Builder Address(Models.Address value)
            {
                address = value;
                return this;
            }

            public Builder PhoneNumber(string value)
            {
                phoneNumber = value;
                return this;
            }

            public Builder CompanyName(string value)
            {
                companyName = value;
                return this;
            }

            public InvoiceRecipient Build()
            {
                return new InvoiceRecipient(customerId,
                    givenName,
                    familyName,
                    emailAddress,
                    address,
                    phoneNumber,
                    companyName);
            }
        }
    }
}