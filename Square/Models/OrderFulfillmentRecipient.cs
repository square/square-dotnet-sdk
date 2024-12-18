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
    /// OrderFulfillmentRecipient.
    /// </summary>
    public class OrderFulfillmentRecipient
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "customer_id", false },
                { "display_name", false },
                { "email_address", false },
                { "phone_number", false }
            };

            if (customerId != null)
            {
                shouldSerialize["customer_id"] = true;
                this.CustomerId = customerId;
            }

            if (displayName != null)
            {
                shouldSerialize["display_name"] = true;
                this.DisplayName = displayName;
            }

            if (emailAddress != null)
            {
                shouldSerialize["email_address"] = true;
                this.EmailAddress = emailAddress;
            }

            if (phoneNumber != null)
            {
                shouldSerialize["phone_number"] = true;
                this.PhoneNumber = phoneNumber;
            }
            this.Address = address;
        }

        internal OrderFulfillmentRecipient(
            Dictionary<string, bool> shouldSerialize,
            string customerId = null,
            string displayName = null,
            string emailAddress = null,
            string phoneNumber = null,
            Models.Address address = null)
        {
            this.shouldSerialize = shouldSerialize;
            CustomerId = customerId;
            DisplayName = displayName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        /// <summary>
        /// The ID of the customer associated with the fulfillment.
        /// If `customer_id` is provided, the fulfillment recipient's `display_name`,
        /// `email_address`, and `phone_number` are automatically populated from the
        /// targeted customer profile. If these fields are set in the request, the request
        /// values override the information from the customer profile. If the
        /// targeted customer profile does not contain the necessary information and
        /// these fields are left unset, the request results in an error.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <summary>
        /// The display name of the fulfillment recipient. This field is required.
        /// If provided, the display name overrides the corresponding customer profile value
        /// indicated by `customer_id`.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; }

        /// <summary>
        /// The email address of the fulfillment recipient.
        /// If provided, the email address overrides the corresponding customer profile value
        /// indicated by `customer_id`.
        /// </summary>
        [JsonProperty("email_address")]
        public string EmailAddress { get; }

        /// <summary>
        /// The phone number of the fulfillment recipient. This field is required.
        /// If provided, the phone number overrides the corresponding customer profile value
        /// indicated by `customer_id`.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; }

        /// <summary>
        /// Represents a postal address in a country.
        /// For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
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

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerId()
        {
            return this.shouldSerialize["customer_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDisplayName()
        {
            return this.shouldSerialize["display_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmailAddress()
        {
            return this.shouldSerialize["email_address"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePhoneNumber()
        {
            return this.shouldSerialize["phone_number"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is OrderFulfillmentRecipient other &&
                (this.CustomerId == null && other.CustomerId == null ||
                 this.CustomerId?.Equals(other.CustomerId) == true) &&
                (this.DisplayName == null && other.DisplayName == null ||
                 this.DisplayName?.Equals(other.DisplayName) == true) &&
                (this.EmailAddress == null && other.EmailAddress == null ||
                 this.EmailAddress?.Equals(other.EmailAddress) == true) &&
                (this.PhoneNumber == null && other.PhoneNumber == null ||
                 this.PhoneNumber?.Equals(other.PhoneNumber) == true) &&
                (this.Address == null && other.Address == null ||
                 this.Address?.Equals(other.Address) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1654316684;
            hashCode = HashCode.Combine(hashCode, this.CustomerId, this.DisplayName, this.EmailAddress, this.PhoneNumber, this.Address);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CustomerId = {this.CustomerId ?? "null"}");
            toStringOutput.Add($"this.DisplayName = {this.DisplayName ?? "null"}");
            toStringOutput.Add($"this.EmailAddress = {this.EmailAddress ?? "null"}");
            toStringOutput.Add($"this.PhoneNumber = {this.PhoneNumber ?? "null"}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "customer_id", false },
                { "display_name", false },
                { "email_address", false },
                { "phone_number", false },
            };

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
                shouldSerialize["customer_id"] = true;
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
                shouldSerialize["display_name"] = true;
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
                shouldSerialize["email_address"] = true;
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
                shouldSerialize["phone_number"] = true;
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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCustomerId()
            {
                this.shouldSerialize["customer_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetDisplayName()
            {
                this.shouldSerialize["display_name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetEmailAddress()
            {
                this.shouldSerialize["email_address"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetPhoneNumber()
            {
                this.shouldSerialize["phone_number"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderFulfillmentRecipient. </returns>
            public OrderFulfillmentRecipient Build()
            {
                return new OrderFulfillmentRecipient(
                    shouldSerialize,
                    this.customerId,
                    this.displayName,
                    this.emailAddress,
                    this.phoneNumber,
                    this.address);
            }
        }
    }
}