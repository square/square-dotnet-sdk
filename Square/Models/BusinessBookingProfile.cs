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
    /// BusinessBookingProfile.
    /// </summary>
    public class BusinessBookingProfile
    {
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
        public BusinessBookingProfile(
            string sellerId = null,
            string createdAt = null,
            bool? bookingEnabled = null,
            string customerTimezoneChoice = null,
            string bookingPolicy = null,
            bool? allowUserCancel = null,
            Models.BusinessAppointmentSettings businessAppointmentSettings = null)
        {
            this.SellerId = sellerId;
            this.CreatedAt = createdAt;
            this.BookingEnabled = bookingEnabled;
            this.CustomerTimezoneChoice = customerTimezoneChoice;
            this.BookingPolicy = bookingPolicy;
            this.AllowUserCancel = allowUserCancel;
            this.BusinessAppointmentSettings = businessAppointmentSettings;
        }

        /// <summary>
        /// The ID of the seller, obtainable using the Merchants API.
        /// </summary>
        [JsonProperty("seller_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SellerId { get; }

        /// <summary>
        /// The RFC 3339 timestamp specifying the booking's creation time.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// Indicates whether the seller is open for booking.
        /// </summary>
        [JsonProperty("booking_enabled", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty("allow_user_cancel", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowUserCancel { get; }

        /// <summary>
        /// The service appointment settings, including where and how the service is provided.
        /// </summary>
        [JsonProperty("business_appointment_settings", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BusinessAppointmentSettings BusinessAppointmentSettings { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BusinessBookingProfile : ({string.Join(", ", toStringOutput)})";
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

            return obj is BusinessBookingProfile other &&
                ((this.SellerId == null && other.SellerId == null) || (this.SellerId?.Equals(other.SellerId) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.BookingEnabled == null && other.BookingEnabled == null) || (this.BookingEnabled?.Equals(other.BookingEnabled) == true)) &&
                ((this.CustomerTimezoneChoice == null && other.CustomerTimezoneChoice == null) || (this.CustomerTimezoneChoice?.Equals(other.CustomerTimezoneChoice) == true)) &&
                ((this.BookingPolicy == null && other.BookingPolicy == null) || (this.BookingPolicy?.Equals(other.BookingPolicy) == true)) &&
                ((this.AllowUserCancel == null && other.AllowUserCancel == null) || (this.AllowUserCancel?.Equals(other.AllowUserCancel) == true)) &&
                ((this.BusinessAppointmentSettings == null && other.BusinessAppointmentSettings == null) || (this.BusinessAppointmentSettings?.Equals(other.BusinessAppointmentSettings) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 604613904;
            hashCode = HashCode.Combine(this.SellerId, this.CreatedAt, this.BookingEnabled, this.CustomerTimezoneChoice, this.BookingPolicy, this.AllowUserCancel, this.BusinessAppointmentSettings);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SellerId = {(this.SellerId == null ? "null" : this.SellerId == string.Empty ? "" : this.SellerId)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.BookingEnabled = {(this.BookingEnabled == null ? "null" : this.BookingEnabled.ToString())}");
            toStringOutput.Add($"this.CustomerTimezoneChoice = {(this.CustomerTimezoneChoice == null ? "null" : this.CustomerTimezoneChoice.ToString())}");
            toStringOutput.Add($"this.BookingPolicy = {(this.BookingPolicy == null ? "null" : this.BookingPolicy.ToString())}");
            toStringOutput.Add($"this.AllowUserCancel = {(this.AllowUserCancel == null ? "null" : this.AllowUserCancel.ToString())}");
            toStringOutput.Add($"this.BusinessAppointmentSettings = {(this.BusinessAppointmentSettings == null ? "null" : this.BusinessAppointmentSettings.ToString())}");
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
                .BusinessAppointmentSettings(this.BusinessAppointmentSettings);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string sellerId;
            private string createdAt;
            private bool? bookingEnabled;
            private string customerTimezoneChoice;
            private string bookingPolicy;
            private bool? allowUserCancel;
            private Models.BusinessAppointmentSettings businessAppointmentSettings;

             /// <summary>
             /// SellerId.
             /// </summary>
             /// <param name="sellerId"> sellerId. </param>
             /// <returns> Builder. </returns>
            public Builder SellerId(string sellerId)
            {
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
            /// Builds class object.
            /// </summary>
            /// <returns> BusinessBookingProfile. </returns>
            public BusinessBookingProfile Build()
            {
                return new BusinessBookingProfile(
                    this.sellerId,
                    this.createdAt,
                    this.bookingEnabled,
                    this.customerTimezoneChoice,
                    this.bookingPolicy,
                    this.allowUserCancel,
                    this.businessAppointmentSettings);
            }
        }
    }
}