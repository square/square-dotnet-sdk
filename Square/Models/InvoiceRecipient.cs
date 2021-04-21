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
    /// InvoiceRecipient.
    /// </summary>
    public class InvoiceRecipient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceRecipient"/> class.
        /// </summary>
        /// <param name="customerId">customer_id.</param>
        /// <param name="givenName">given_name.</param>
        /// <param name="familyName">family_name.</param>
        /// <param name="emailAddress">email_address.</param>
        /// <param name="address">address.</param>
        /// <param name="phoneNumber">phone_number.</param>
        /// <param name="companyName">company_name.</param>
        public InvoiceRecipient(
            string customerId = null,
            string givenName = null,
            string familyName = null,
            string emailAddress = null,
            Models.Address address = null,
            string phoneNumber = null,
            string companyName = null)
        {
            this.CustomerId = customerId;
            this.GivenName = givenName;
            this.FamilyName = familyName;
            this.EmailAddress = emailAddress;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.CompanyName = companyName;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InvoiceRecipient : ({string.Join(", ", toStringOutput)})";
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

            return obj is InvoiceRecipient other &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.GivenName == null && other.GivenName == null) || (this.GivenName?.Equals(other.GivenName) == true)) &&
                ((this.FamilyName == null && other.FamilyName == null) || (this.FamilyName?.Equals(other.FamilyName) == true)) &&
                ((this.EmailAddress == null && other.EmailAddress == null) || (this.EmailAddress?.Equals(other.EmailAddress) == true)) &&
                ((this.Address == null && other.Address == null) || (this.Address?.Equals(other.Address) == true)) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((this.CompanyName == null && other.CompanyName == null) || (this.CompanyName?.Equals(other.CompanyName) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1383071021;

            if (this.CustomerId != null)
            {
               hashCode += this.CustomerId.GetHashCode();
            }

            if (this.GivenName != null)
            {
               hashCode += this.GivenName.GetHashCode();
            }

            if (this.FamilyName != null)
            {
               hashCode += this.FamilyName.GetHashCode();
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

            if (this.CompanyName != null)
            {
               hashCode += this.CompanyName.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId == string.Empty ? "" : this.CustomerId)}");
            toStringOutput.Add($"this.GivenName = {(this.GivenName == null ? "null" : this.GivenName == string.Empty ? "" : this.GivenName)}");
            toStringOutput.Add($"this.FamilyName = {(this.FamilyName == null ? "null" : this.FamilyName == string.Empty ? "" : this.FamilyName)}");
            toStringOutput.Add($"this.EmailAddress = {(this.EmailAddress == null ? "null" : this.EmailAddress == string.Empty ? "" : this.EmailAddress)}");
            toStringOutput.Add($"this.Address = {(this.Address == null ? "null" : this.Address.ToString())}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber == string.Empty ? "" : this.PhoneNumber)}");
            toStringOutput.Add($"this.CompanyName = {(this.CompanyName == null ? "null" : this.CompanyName == string.Empty ? "" : this.CompanyName)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CustomerId(this.CustomerId)
                .GivenName(this.GivenName)
                .FamilyName(this.FamilyName)
                .EmailAddress(this.EmailAddress)
                .Address(this.Address)
                .PhoneNumber(this.PhoneNumber)
                .CompanyName(this.CompanyName);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string customerId;
            private string givenName;
            private string familyName;
            private string emailAddress;
            private Models.Address address;
            private string phoneNumber;
            private string companyName;

             /// <summary>
             /// CustomerId.
             /// </summary>
             /// <param name="customerId"> customerId. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerId(string customerId)
            {
                this.customerId = customerId;
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
            /// Builds class object.
            /// </summary>
            /// <returns> InvoiceRecipient. </returns>
            public InvoiceRecipient Build()
            {
                return new InvoiceRecipient(
                    this.customerId,
                    this.givenName,
                    this.familyName,
                    this.emailAddress,
                    this.address,
                    this.phoneNumber,
                    this.companyName);
            }
        }
    }
}