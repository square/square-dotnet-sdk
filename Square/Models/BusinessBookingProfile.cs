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
    /// BusinessBookingProfile.
    /// </summary>
    public class BusinessBookingProfile
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessBookingProfile"/> class.
        /// </summary>
        /// <param name="sellerId">seller_id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="bookingEnabled">booking_enabled.</param>
        /// <param name="customerTimezoneChoice">customer_timezone_choice.</param>
        /// <param name="bookingPolicy">booking_policy.</param>
        /// <param name="allowUserCancel">allow_user_cancel.</param>
        /// <param name="businessAppointmentSettings">business_appointment_settings.</param>
        /// <param name="supportSellerLevelWrites">support_seller_level_writes.</param>
        public BusinessBookingProfile(
            string sellerId = null,
            string createdAt = null,
            bool? bookingEnabled = null,
            string customerTimezoneChoice = null,
            string bookingPolicy = null,
            bool? allowUserCancel = null,
            Models.BusinessAppointmentSettings businessAppointmentSettings = null,
            bool? supportSellerLevelWrites = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "seller_id", false },
                { "booking_enabled", false },
                { "allow_user_cancel", false },
                { "support_seller_level_writes", false }
            };

            if (sellerId != null)
            {
                shouldSerialize["seller_id"] = true;
                this.SellerId = sellerId;
            }

            this.CreatedAt = createdAt;
            if (bookingEnabled != null)
            {
                shouldSerialize["booking_enabled"] = true;
                this.BookingEnabled = bookingEnabled;
            }

            this.CustomerTimezoneChoice = customerTimezoneChoice;
            this.BookingPolicy = bookingPolicy;
            if (allowUserCancel != null)
            {
                shouldSerialize["allow_user_cancel"] = true;
                this.AllowUserCancel = allowUserCancel;
            }

            this.BusinessAppointmentSettings = businessAppointmentSettings;
            if (supportSellerLevelWrites != null)
            {
                shouldSerialize["support_seller_level_writes"] = true;
                this.SupportSellerLevelWrites = supportSellerLevelWrites;
            }

        }
        internal BusinessBookingProfile(Dictionary<string, bool> shouldSerialize,
            string sellerId = null,
            string createdAt = null,
            bool? bookingEnabled = null,
            string customerTimezoneChoice = null,
            string bookingPolicy = null,
            bool? allowUserCancel = null,
            Models.BusinessAppointmentSettings businessAppointmentSettings = null,
            bool? supportSellerLevelWrites = null)
        {
            this.shouldSerialize = shouldSerialize;
            SellerId = sellerId;
            CreatedAt = createdAt;
            BookingEnabled = bookingEnabled;
            CustomerTimezoneChoice = customerTimezoneChoice;
            BookingPolicy = bookingPolicy;
            AllowUserCancel = allowUserCancel;
            BusinessAppointmentSettings = businessAppointmentSettings;
            SupportSellerLevelWrites = supportSellerLevelWrites;
        }

        /// <summary>
        /// The ID of the seller, obtainable using the Merchants API.
        /// </summary>
        [JsonProperty("seller_id")]
        public string SellerId { get; }

        /// <summary>
        /// The RFC 3339 timestamp specifying the booking's creation time.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// Indicates whether the seller is open for booking.
        /// </summary>
        [JsonProperty("booking_enabled")]
        public bool? BookingEnabled { get; }

        /// <summary>
        /// Choices of customer-facing time zone used for bookings.
        /// </summary>
        [JsonProperty("customer_timezone_choice", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerTimezoneChoice { get; }

        /// <summary>
        /// Policies for accepting bookings.
        /// </summary>
        [JsonProperty("booking_policy", NullValueHandling = NullValueHandling.Ignore)]
        public string BookingPolicy { get; }

        /// <summary>
        /// Indicates whether customers can cancel or reschedule their own bookings (`true`) or not (`false`).
        /// </summary>
        [JsonProperty("allow_user_cancel")]
        public bool? AllowUserCancel { get; }

        /// <summary>
        /// The service appointment settings, including where and how the service is provided.
        /// </summary>
        [JsonProperty("business_appointment_settings", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BusinessAppointmentSettings BusinessAppointmentSettings { get; }

        /// <summary>
        /// Indicates whether the seller's subscription to Square Appointments supports creating, updating or canceling an appointment through the API (`true`) or not (`false`) using seller permission.
        /// </summary>
        [JsonProperty("support_seller_level_writes")]
        public bool? SupportSellerLevelWrites { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BusinessBookingProfile : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSellerId()
        {
            return this.shouldSerialize["seller_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBookingEnabled()
        {
            return this.shouldSerialize["booking_enabled"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAllowUserCancel()
        {
            return this.shouldSerialize["allow_user_cancel"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSupportSellerLevelWrites()
        {
            return this.shouldSerialize["support_seller_level_writes"];
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
            return obj is BusinessBookingProfile other &&                ((this.SellerId == null && other.SellerId == null) || (this.SellerId?.Equals(other.SellerId) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.BookingEnabled == null && other.BookingEnabled == null) || (this.BookingEnabled?.Equals(other.BookingEnabled) == true)) &&
                ((this.CustomerTimezoneChoice == null && other.CustomerTimezoneChoice == null) || (this.CustomerTimezoneChoice?.Equals(other.CustomerTimezoneChoice) == true)) &&
                ((this.BookingPolicy == null && other.BookingPolicy == null) || (this.BookingPolicy?.Equals(other.BookingPolicy) == true)) &&
                ((this.AllowUserCancel == null && other.AllowUserCancel == null) || (this.AllowUserCancel?.Equals(other.AllowUserCancel) == true)) &&
                ((this.BusinessAppointmentSettings == null && other.BusinessAppointmentSettings == null) || (this.BusinessAppointmentSettings?.Equals(other.BusinessAppointmentSettings) == true)) &&
                ((this.SupportSellerLevelWrites == null && other.SupportSellerLevelWrites == null) || (this.SupportSellerLevelWrites?.Equals(other.SupportSellerLevelWrites) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -513318848;
            hashCode = HashCode.Combine(this.SellerId, this.CreatedAt, this.BookingEnabled, this.CustomerTimezoneChoice, this.BookingPolicy, this.AllowUserCancel, this.BusinessAppointmentSettings);

            hashCode = HashCode.Combine(hashCode, this.SupportSellerLevelWrites);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SellerId = {(this.SellerId == null ? "null" : this.SellerId)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt)}");
            toStringOutput.Add($"this.BookingEnabled = {(this.BookingEnabled == null ? "null" : this.BookingEnabled.ToString())}");
            toStringOutput.Add($"this.CustomerTimezoneChoice = {(this.CustomerTimezoneChoice == null ? "null" : this.CustomerTimezoneChoice.ToString())}");
            toStringOutput.Add($"this.BookingPolicy = {(this.BookingPolicy == null ? "null" : this.BookingPolicy.ToString())}");
            toStringOutput.Add($"this.AllowUserCancel = {(this.AllowUserCancel == null ? "null" : this.AllowUserCancel.ToString())}");
            toStringOutput.Add($"this.BusinessAppointmentSettings = {(this.BusinessAppointmentSettings == null ? "null" : this.BusinessAppointmentSettings.ToString())}");
            toStringOutput.Add($"this.SupportSellerLevelWrites = {(this.SupportSellerLevelWrites == null ? "null" : this.SupportSellerLevelWrites.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .SellerId(this.SellerId)
                .CreatedAt(this.CreatedAt)
                .BookingEnabled(this.BookingEnabled)
                .CustomerTimezoneChoice(this.CustomerTimezoneChoice)
                .BookingPolicy(this.BookingPolicy)
                .AllowUserCancel(this.AllowUserCancel)
                .BusinessAppointmentSettings(this.BusinessAppointmentSettings)
                .SupportSellerLevelWrites(this.SupportSellerLevelWrites);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "seller_id", false },
                { "booking_enabled", false },
                { "allow_user_cancel", false },
                { "support_seller_level_writes", false },
            };

            private string sellerId;
            private string createdAt;
            private bool? bookingEnabled;
            private string customerTimezoneChoice;
            private string bookingPolicy;
            private bool? allowUserCancel;
            private Models.BusinessAppointmentSettings businessAppointmentSettings;
            private bool? supportSellerLevelWrites;

             /// <summary>
             /// SellerId.
             /// </summary>
             /// <param name="sellerId"> sellerId. </param>
             /// <returns> Builder. </returns>
            public Builder SellerId(string sellerId)
            {
                shouldSerialize["seller_id"] = true;
                this.sellerId = sellerId;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// BookingEnabled.
             /// </summary>
             /// <param name="bookingEnabled"> bookingEnabled. </param>
             /// <returns> Builder. </returns>
            public Builder BookingEnabled(bool? bookingEnabled)
            {
                shouldSerialize["booking_enabled"] = true;
                this.bookingEnabled = bookingEnabled;
                return this;
            }

             /// <summary>
             /// CustomerTimezoneChoice.
             /// </summary>
             /// <param name="customerTimezoneChoice"> customerTimezoneChoice. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerTimezoneChoice(string customerTimezoneChoice)
            {
                this.customerTimezoneChoice = customerTimezoneChoice;
                return this;
            }

             /// <summary>
             /// BookingPolicy.
             /// </summary>
             /// <param name="bookingPolicy"> bookingPolicy. </param>
             /// <returns> Builder. </returns>
            public Builder BookingPolicy(string bookingPolicy)
            {
                this.bookingPolicy = bookingPolicy;
                return this;
            }

             /// <summary>
             /// AllowUserCancel.
             /// </summary>
             /// <param name="allowUserCancel"> allowUserCancel. </param>
             /// <returns> Builder. </returns>
            public Builder AllowUserCancel(bool? allowUserCancel)
            {
                shouldSerialize["allow_user_cancel"] = true;
                this.allowUserCancel = allowUserCancel;
                return this;
            }

             /// <summary>
             /// BusinessAppointmentSettings.
             /// </summary>
             /// <param name="businessAppointmentSettings"> businessAppointmentSettings. </param>
             /// <returns> Builder. </returns>
            public Builder BusinessAppointmentSettings(Models.BusinessAppointmentSettings businessAppointmentSettings)
            {
                this.businessAppointmentSettings = businessAppointmentSettings;
                return this;
            }

             /// <summary>
             /// SupportSellerLevelWrites.
             /// </summary>
             /// <param name="supportSellerLevelWrites"> supportSellerLevelWrites. </param>
             /// <returns> Builder. </returns>
            public Builder SupportSellerLevelWrites(bool? supportSellerLevelWrites)
            {
                shouldSerialize["support_seller_level_writes"] = true;
                this.supportSellerLevelWrites = supportSellerLevelWrites;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSellerId()
            {
                this.shouldSerialize["seller_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBookingEnabled()
            {
                this.shouldSerialize["booking_enabled"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAllowUserCancel()
            {
                this.shouldSerialize["allow_user_cancel"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSupportSellerLevelWrites()
            {
                this.shouldSerialize["support_seller_level_writes"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BusinessBookingProfile. </returns>
            public BusinessBookingProfile Build()
            {
                return new BusinessBookingProfile(shouldSerialize,
                    this.sellerId,
                    this.createdAt,
                    this.bookingEnabled,
                    this.customerTimezoneChoice,
                    this.bookingPolicy,
                    this.allowUserCancel,
                    this.businessAppointmentSettings,
                    this.supportSellerLevelWrites);
            }
        }
    }
}