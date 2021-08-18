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
    /// OrderFulfillmentRecipient.
    /// </summary>
    public class OrderFulfillmentRecipient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFulfillmentRecipient"/> class.
        /// </summary>
        /// <param name="customerId">customer_id.</param>
        /// <param name="displayName">display_name.</param>
        /// <param name="emailAddress">email_address.</param>
        /// <param name="phoneNumber">phone_number.</param>
        /// <param name="address">address.</param>
        public OrderFulfillmentRecipient(
            string customerId = null,
            string displayName = null,
            string emailAddress = null,
            string phoneNumber = null,
            Models.Address address = null)
        {
            this.CustomerId = customerId;
            this.DisplayName = displayName;
            this.EmailAddress = emailAddress;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
        }

        /// <summary>
        /// The customer ID of the customer associated with the fulfillment.
        /// If `customer_id` is provided, the fulfillment recipient's `display_name`,
        /// `email_address`, and `phone_number` are automatically populated from the
        /// targeted customer profile. If these fields are set in the request, the request
        /// values overrides the information from the customer profile. If the
        /// targeted customer profile does not contain the necessary information and
        /// these fields are left unset, the request results in an error.
        /// </summary>
        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; }

        /// <summary>
        /// The display name of the fulfillment recipient.
        /// If provided, the display name overrides the value pulled from the customer profile indicated by `customer_id`.
        /// </summary>
        [JsonProperty("display_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; }

        /// <summary>
        /// The email address of the fulfillment recipient.
        /// If provided, the email address overrides the value pulled from the customer profile indicated by `customer_id`.
        /// </summary>
        [JsonProperty("email_address", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; }

        /// <summary>
        /// The phone number of the fulfillment recipient.
        /// If provided, the phone number overrides the value pulled from the customer profile indicated by `customer_id`.
        /// </summary>
        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; }

        /// <summary>
        /// Represents a postal address in a country. The address format is based
        /// on an [open-source library from Google](https://github.com/google/libaddressinput). For more information,
        /// see [AddressValidationMetadata](https://github.com/google/libaddressinput/wiki/AddressValidationMetadata).
        /// This format has dedicated fields for four address components: postal code,
        /// locality (city), administrative district (state, prefecture, or province), and
        /// sublocality (town or village). These components have dedicated fields in the
        /// `Address` object because software sometimes behaves differently based on them.
        /// For example, sales tax software may charge different amounts of sales tax
        /// based on the postal code, and some software is only available in
        /// certain states due to compliance reasons.
        /// For the remaining address components, the `Address` type provides the
        /// `address_line_1` and `address_line_2` fields for free-form data entry.
        /// These fields are free-form because the remaining address components have
        /// too many variations around the world and typical software does not parse
        /// these components. These fields enable users to enter anything they want.
        /// Note that, in the current implementation, all other `Address` type fields are blank.
        /// These include `address_line_3`, `sublocality_2`, `sublocality_3`,
        /// `administrative_district_level_2`, `administrative_district_level_3`,
        /// `first_name`, `last_name`, and `organization`.
        /// When it comes to localization, the seller's language preferences
        /// (see [Language preferences](https://developer.squareup.com/docs/locations-api#location-specific-and-seller-level-language-preferences))
        /// are ignored for addresses. Even though Square products (such as Square Point of Sale
        /// and the Seller Dashboard) mostly use a seller's language preference in
        /// communication, when it comes to addresses, they will use English for a US address,
        /// Japanese for an address in Japan, and so on.
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address Address { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderFulfillmentRecipient : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderFulfillmentRecipient other &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.DisplayName == null && other.DisplayName == null) || (this.DisplayName?.Equals(other.DisplayName) == true)) &&
                ((this.EmailAddress == null && other.EmailAddress == null) || (this.EmailAddress?.Equals(other.EmailAddress) == true)) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((this.Address == null && other.Address == null) || (this.Address?.Equals(other.Address) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1654316684;

            if (this.CustomerId != null)
            {
               hashCode += this.CustomerId.GetHashCode();
            }

            if (this.DisplayName != null)
            {
               hashCode += this.DisplayName.GetHashCode();
            }

            if (this.EmailAddress != null)
            {
               hashCode += this.EmailAddress.GetHashCode();
            }

            if (this.PhoneNumber != null)
            {
               hashCode += this.PhoneNumber.GetHashCode();
            }

            if (this.Address != null)
            {
               hashCode += this.Address.GetHashCode();
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
            toStringOutput.Add($"this.DisplayName = {(this.DisplayName == null ? "null" : this.DisplayName == string.Empty ? "" : this.DisplayName)}");
            toStringOutput.Add($"this.EmailAddress = {(this.EmailAddress == null ? "null" : this.EmailAddress == string.Empty ? "" : this.EmailAddress)}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber == string.Empty ? "" : this.PhoneNumber)}");
            toStringOutput.Add($"this.Address = {(this.Address == null ? "null" : this.Address.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CustomerId(this.CustomerId)
                .DisplayName(this.DisplayName)
                .EmailAddress(this.EmailAddress)
                .PhoneNumber(this.PhoneNumber)
                .Address(this.Address);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string customerId;
            private string displayName;
            private string emailAddress;
            private string phoneNumber;
            private Models.Address address;

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
             /// DisplayName.
             /// </summary>
             /// <param name="displayName"> displayName. </param>
             /// <returns> Builder. </returns>
            public Builder DisplayName(string displayName)
            {
                this.displayName = displayName;
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
            /// Builds class object.
            /// </summary>
            /// <returns> OrderFulfillmentRecipient. </returns>
            public OrderFulfillmentRecipient Build()
            {
                return new OrderFulfillmentRecipient(
                    this.customerId,
                    this.displayName,
                    this.emailAddress,
                    this.phoneNumber,
                    this.address);
            }
        }
    }
}