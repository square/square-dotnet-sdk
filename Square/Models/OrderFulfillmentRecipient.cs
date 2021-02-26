
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
    public class OrderFulfillmentRecipient 
    {
        public OrderFulfillmentRecipient(string customerId = null,
            string displayName = null,
            string emailAddress = null,
            string phoneNumber = null,
            Models.Address address = null)
        {
            CustomerId = customerId;
            DisplayName = displayName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        /// <summary>
        /// The Customer ID of the customer associated with the fulfillment.
        /// If `customer_id` is provided, the fulfillment recipient's `display_name`,
        /// `email_address`, and `phone_number` are automatically populated from the
        /// targeted customer profile. If these fields are set in the request, the request
        /// values will override the information from the customer profile. If the
        /// targeted customer profile does not contain the necessary information and
        /// these fields are left unset, the request will result in an error.
        /// </summary>
        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; }

        /// <summary>
        /// The display name of the fulfillment recipient.
        /// If provided, overrides the value pulled from the customer profile indicated by `customer_id`.
        /// </summary>
        [JsonProperty("display_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; }

        /// <summary>
        /// The email address of the fulfillment recipient.
        /// If provided, overrides the value pulled from the customer profile indicated by `customer_id`.
        /// </summary>
        [JsonProperty("email_address", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; }

        /// <summary>
        /// The phone number of the fulfillment recipient.
        /// If provided, overrides the value pulled from the customer profile indicated by `customer_id`.
        /// </summary>
        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; }

        /// <summary>
        /// Represents a physical address.
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address Address { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderFulfillmentRecipient : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"CustomerId = {(CustomerId == null ? "null" : CustomerId == string.Empty ? "" : CustomerId)}");
            toStringOutput.Add($"DisplayName = {(DisplayName == null ? "null" : DisplayName == string.Empty ? "" : DisplayName)}");
            toStringOutput.Add($"EmailAddress = {(EmailAddress == null ? "null" : EmailAddress == string.Empty ? "" : EmailAddress)}");
            toStringOutput.Add($"PhoneNumber = {(PhoneNumber == null ? "null" : PhoneNumber == string.Empty ? "" : PhoneNumber)}");
            toStringOutput.Add($"Address = {(Address == null ? "null" : Address.ToString())}");
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

            return obj is OrderFulfillmentRecipient other &&
                ((CustomerId == null && other.CustomerId == null) || (CustomerId?.Equals(other.CustomerId) == true)) &&
                ((DisplayName == null && other.DisplayName == null) || (DisplayName?.Equals(other.DisplayName) == true)) &&
                ((EmailAddress == null && other.EmailAddress == null) || (EmailAddress?.Equals(other.EmailAddress) == true)) &&
                ((PhoneNumber == null && other.PhoneNumber == null) || (PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((Address == null && other.Address == null) || (Address?.Equals(other.Address) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1654316684;

            if (CustomerId != null)
            {
               hashCode += CustomerId.GetHashCode();
            }

            if (DisplayName != null)
            {
               hashCode += DisplayName.GetHashCode();
            }

            if (EmailAddress != null)
            {
               hashCode += EmailAddress.GetHashCode();
            }

            if (PhoneNumber != null)
            {
               hashCode += PhoneNumber.GetHashCode();
            }

            if (Address != null)
            {
               hashCode += Address.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CustomerId(CustomerId)
                .DisplayName(DisplayName)
                .EmailAddress(EmailAddress)
                .PhoneNumber(PhoneNumber)
                .Address(Address);
            return builder;
        }

        public class Builder
        {
            private string customerId;
            private string displayName;
            private string emailAddress;
            private string phoneNumber;
            private Models.Address address;



            public Builder CustomerId(string customerId)
            {
                this.customerId = customerId;
                return this;
            }

            public Builder DisplayName(string displayName)
            {
                this.displayName = displayName;
                return this;
            }

            public Builder EmailAddress(string emailAddress)
            {
                this.emailAddress = emailAddress;
                return this;
            }

            public Builder PhoneNumber(string phoneNumber)
            {
                this.phoneNumber = phoneNumber;
                return this;
            }

            public Builder Address(Models.Address address)
            {
                this.address = address;
                return this;
            }

            public OrderFulfillmentRecipient Build()
            {
                return new OrderFulfillmentRecipient(customerId,
                    displayName,
                    emailAddress,
                    phoneNumber,
                    address);
            }
        }
    }
}