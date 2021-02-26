
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
        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; }

        /// <summary>
        /// The recipient's given (that is, first) name.
        /// </summary>
        [JsonProperty("given_name", NullValueHandling = NullValueHandling.Ignore)]
        public string GivenName { get; }

        /// <summary>
        /// The recipient's family (that is, last) name.
        /// </summary>
        [JsonProperty("family_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FamilyName { get; }

        /// <summary>
        /// The recipient's email address.
        /// </summary>
        [JsonProperty("email_address", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; }

        /// <summary>
        /// Represents a physical address.
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address Address { get; }

        /// <summary>
        /// The recipient's phone number.
        /// </summary>
        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; }

        /// <summary>
        /// The name of the recipient's company.
        /// </summary>
        [JsonProperty("company_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyName { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InvoiceRecipient : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"CustomerId = {(CustomerId == null ? "null" : CustomerId == string.Empty ? "" : CustomerId)}");
            toStringOutput.Add($"GivenName = {(GivenName == null ? "null" : GivenName == string.Empty ? "" : GivenName)}");
            toStringOutput.Add($"FamilyName = {(FamilyName == null ? "null" : FamilyName == string.Empty ? "" : FamilyName)}");
            toStringOutput.Add($"EmailAddress = {(EmailAddress == null ? "null" : EmailAddress == string.Empty ? "" : EmailAddress)}");
            toStringOutput.Add($"Address = {(Address == null ? "null" : Address.ToString())}");
            toStringOutput.Add($"PhoneNumber = {(PhoneNumber == null ? "null" : PhoneNumber == string.Empty ? "" : PhoneNumber)}");
            toStringOutput.Add($"CompanyName = {(CompanyName == null ? "null" : CompanyName == string.Empty ? "" : CompanyName)}");
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

            return obj is InvoiceRecipient other &&
                ((CustomerId == null && other.CustomerId == null) || (CustomerId?.Equals(other.CustomerId) == true)) &&
                ((GivenName == null && other.GivenName == null) || (GivenName?.Equals(other.GivenName) == true)) &&
                ((FamilyName == null && other.FamilyName == null) || (FamilyName?.Equals(other.FamilyName) == true)) &&
                ((EmailAddress == null && other.EmailAddress == null) || (EmailAddress?.Equals(other.EmailAddress) == true)) &&
                ((Address == null && other.Address == null) || (Address?.Equals(other.Address) == true)) &&
                ((PhoneNumber == null && other.PhoneNumber == null) || (PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((CompanyName == null && other.CompanyName == null) || (CompanyName?.Equals(other.CompanyName) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1383071021;

            if (CustomerId != null)
            {
               hashCode += CustomerId.GetHashCode();
            }

            if (GivenName != null)
            {
               hashCode += GivenName.GetHashCode();
            }

            if (FamilyName != null)
            {
               hashCode += FamilyName.GetHashCode();
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

            if (CompanyName != null)
            {
               hashCode += CompanyName.GetHashCode();
            }

            return hashCode;
        }

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



            public Builder CustomerId(string customerId)
            {
                this.customerId = customerId;
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

            public Builder CompanyName(string companyName)
            {
                this.companyName = companyName;
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