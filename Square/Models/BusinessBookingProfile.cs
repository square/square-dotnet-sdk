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
    public class BusinessBookingProfile 
    {
        public BusinessBookingProfile(string sellerId = null,
            string createdAt = null,
            bool? bookingEnabled = null,
            string customerTimezoneChoice = null,
            string bookingPolicy = null,
            bool? allowUserCancel = null,
            Models.BusinessAppointmentSettings businessAppointmentSettings = null)
        {
            SellerId = sellerId;
            CreatedAt = createdAt;
            BookingEnabled = bookingEnabled;
            CustomerTimezoneChoice = customerTimezoneChoice;
            BookingPolicy = bookingPolicy;
            AllowUserCancel = allowUserCancel;
            BusinessAppointmentSettings = businessAppointmentSettings;
        }

        /// <summary>
        /// The ID of the seller, obtainable using the Merchants API.
        /// </summary>
        [JsonProperty("seller_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SellerId { get; }

        /// <summary>
        /// The RFC-3339 timestamp specifying the booking's creation time.
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

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .SellerId(SellerId)
                .CreatedAt(CreatedAt)
                .BookingEnabled(BookingEnabled)
                .CustomerTimezoneChoice(CustomerTimezoneChoice)
                .BookingPolicy(BookingPolicy)
                .AllowUserCancel(AllowUserCancel)
                .BusinessAppointmentSettings(BusinessAppointmentSettings);
            return builder;
        }

        public class Builder
        {
            private string sellerId;
            private string createdAt;
            private bool? bookingEnabled;
            private string customerTimezoneChoice;
            private string bookingPolicy;
            private bool? allowUserCancel;
            private Models.BusinessAppointmentSettings businessAppointmentSettings;



            public Builder SellerId(string sellerId)
            {
                this.sellerId = sellerId;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder BookingEnabled(bool? bookingEnabled)
            {
                this.bookingEnabled = bookingEnabled;
                return this;
            }

            public Builder CustomerTimezoneChoice(string customerTimezoneChoice)
            {
                this.customerTimezoneChoice = customerTimezoneChoice;
                return this;
            }

            public Builder BookingPolicy(string bookingPolicy)
            {
                this.bookingPolicy = bookingPolicy;
                return this;
            }

            public Builder AllowUserCancel(bool? allowUserCancel)
            {
                this.allowUserCancel = allowUserCancel;
                return this;
            }

            public Builder BusinessAppointmentSettings(Models.BusinessAppointmentSettings businessAppointmentSettings)
            {
                this.businessAppointmentSettings = businessAppointmentSettings;
                return this;
            }

            public BusinessBookingProfile Build()
            {
                return new BusinessBookingProfile(sellerId,
                    createdAt,
                    bookingEnabled,
                    customerTimezoneChoice,
                    bookingPolicy,
                    allowUserCancel,
                    businessAppointmentSettings);
            }
        }
    }
}