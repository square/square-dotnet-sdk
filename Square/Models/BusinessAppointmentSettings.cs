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
    public class BusinessAppointmentSettings 
    {
        public BusinessAppointmentSettings(IList<string> locationTypes = null,
            string alignmentTime = null,
            int? minBookingLeadTimeSeconds = null,
            int? maxBookingLeadTimeSeconds = null,
            bool? anyTeamMemberBookingEnabled = null,
            bool? multipleServiceBookingEnabled = null,
            string maxAppointmentsPerDayLimitType = null,
            int? maxAppointmentsPerDayLimit = null,
            int? cancellationWindowSeconds = null,
            Models.Money cancellationFeeMoney = null,
            string cancellationPolicy = null,
            string cancellationPolicyText = null,
            bool? skipBookingFlowStaffSelection = null)
        {
            LocationTypes = locationTypes;
            AlignmentTime = alignmentTime;
            MinBookingLeadTimeSeconds = minBookingLeadTimeSeconds;
            MaxBookingLeadTimeSeconds = maxBookingLeadTimeSeconds;
            AnyTeamMemberBookingEnabled = anyTeamMemberBookingEnabled;
            MultipleServiceBookingEnabled = multipleServiceBookingEnabled;
            MaxAppointmentsPerDayLimitType = maxAppointmentsPerDayLimitType;
            MaxAppointmentsPerDayLimit = maxAppointmentsPerDayLimit;
            CancellationWindowSeconds = cancellationWindowSeconds;
            CancellationFeeMoney = cancellationFeeMoney;
            CancellationPolicy = cancellationPolicy;
            CancellationPolicyText = cancellationPolicyText;
            SkipBookingFlowStaffSelection = skipBookingFlowStaffSelection;
        }

        /// <summary>
        /// Types of the location allowed for bookings.
        /// See [BusinessAppointmentSettingsBookingLocationType](#type-businessappointmentsettingsbookinglocationtype) for possible values
        /// </summary>
        [JsonProperty("location_types", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> LocationTypes { get; }

        /// <summary>
        /// Time units of a service duration for bookings.
        /// </summary>
        [JsonProperty("alignment_time", NullValueHandling = NullValueHandling.Ignore)]
        public string AlignmentTime { get; }

        /// <summary>
        /// The minimum lead time in seconds before a service can be booked. Bookings must be created at least this far ahead of the booking's starting time.
        /// </summary>
        [JsonProperty("min_booking_lead_time_seconds", NullValueHandling = NullValueHandling.Ignore)]
        public int? MinBookingLeadTimeSeconds { get; }

        /// <summary>
        /// The maximum lead time in seconds before a service can be booked. Bookings must be created at most this far ahead of the booking's starting time.
        /// </summary>
        [JsonProperty("max_booking_lead_time_seconds", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxBookingLeadTimeSeconds { get; }

        /// <summary>
        /// Indicates whether a customer can choose from all available time slots and have a staff member assigned
        /// automatically (`true`) or not (`false`).
        /// </summary>
        [JsonProperty("any_team_member_booking_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AnyTeamMemberBookingEnabled { get; }

        /// <summary>
        /// Indicates whether a customer can book multiple services in a single online booking.
        /// </summary>
        [JsonProperty("multiple_service_booking_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MultipleServiceBookingEnabled { get; }

        /// <summary>
        /// Types of daily appointment limits.
        /// </summary>
        [JsonProperty("max_appointments_per_day_limit_type", NullValueHandling = NullValueHandling.Ignore)]
        public string MaxAppointmentsPerDayLimitType { get; }

        /// <summary>
        /// The maximum number of daily appointments per team member or per location.
        /// </summary>
        [JsonProperty("max_appointments_per_day_limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxAppointmentsPerDayLimit { get; }

        /// <summary>
        /// The cut-off time in seconds for allowing clients to cancel or reschedule an appointment.
        /// </summary>
        [JsonProperty("cancellation_window_seconds", NullValueHandling = NullValueHandling.Ignore)]
        public int? CancellationWindowSeconds { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("cancellation_fee_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money CancellationFeeMoney { get; }

        /// <summary>
        /// The category of the seller’s cancellation policy.
        /// </summary>
        [JsonProperty("cancellation_policy", NullValueHandling = NullValueHandling.Ignore)]
        public string CancellationPolicy { get; }

        /// <summary>
        /// The free-form text of the seller's cancellation policy.
        /// </summary>
        [JsonProperty("cancellation_policy_text", NullValueHandling = NullValueHandling.Ignore)]
        public string CancellationPolicyText { get; }

        /// <summary>
        /// Indicates whether customers has an assigned staff member (`true`) or can select s staff member of their choice (`false`).
        /// </summary>
        [JsonProperty("skip_booking_flow_staff_selection", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SkipBookingFlowStaffSelection { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationTypes(LocationTypes)
                .AlignmentTime(AlignmentTime)
                .MinBookingLeadTimeSeconds(MinBookingLeadTimeSeconds)
                .MaxBookingLeadTimeSeconds(MaxBookingLeadTimeSeconds)
                .AnyTeamMemberBookingEnabled(AnyTeamMemberBookingEnabled)
                .MultipleServiceBookingEnabled(MultipleServiceBookingEnabled)
                .MaxAppointmentsPerDayLimitType(MaxAppointmentsPerDayLimitType)
                .MaxAppointmentsPerDayLimit(MaxAppointmentsPerDayLimit)
                .CancellationWindowSeconds(CancellationWindowSeconds)
                .CancellationFeeMoney(CancellationFeeMoney)
                .CancellationPolicy(CancellationPolicy)
                .CancellationPolicyText(CancellationPolicyText)
                .SkipBookingFlowStaffSelection(SkipBookingFlowStaffSelection);
            return builder;
        }

        public class Builder
        {
            private IList<string> locationTypes;
            private string alignmentTime;
            private int? minBookingLeadTimeSeconds;
            private int? maxBookingLeadTimeSeconds;
            private bool? anyTeamMemberBookingEnabled;
            private bool? multipleServiceBookingEnabled;
            private string maxAppointmentsPerDayLimitType;
            private int? maxAppointmentsPerDayLimit;
            private int? cancellationWindowSeconds;
            private Models.Money cancellationFeeMoney;
            private string cancellationPolicy;
            private string cancellationPolicyText;
            private bool? skipBookingFlowStaffSelection;



            public Builder LocationTypes(IList<string> locationTypes)
            {
                this.locationTypes = locationTypes;
                return this;
            }

            public Builder AlignmentTime(string alignmentTime)
            {
                this.alignmentTime = alignmentTime;
                return this;
            }

            public Builder MinBookingLeadTimeSeconds(int? minBookingLeadTimeSeconds)
            {
                this.minBookingLeadTimeSeconds = minBookingLeadTimeSeconds;
                return this;
            }

            public Builder MaxBookingLeadTimeSeconds(int? maxBookingLeadTimeSeconds)
            {
                this.maxBookingLeadTimeSeconds = maxBookingLeadTimeSeconds;
                return this;
            }

            public Builder AnyTeamMemberBookingEnabled(bool? anyTeamMemberBookingEnabled)
            {
                this.anyTeamMemberBookingEnabled = anyTeamMemberBookingEnabled;
                return this;
            }

            public Builder MultipleServiceBookingEnabled(bool? multipleServiceBookingEnabled)
            {
                this.multipleServiceBookingEnabled = multipleServiceBookingEnabled;
                return this;
            }

            public Builder MaxAppointmentsPerDayLimitType(string maxAppointmentsPerDayLimitType)
            {
                this.maxAppointmentsPerDayLimitType = maxAppointmentsPerDayLimitType;
                return this;
            }

            public Builder MaxAppointmentsPerDayLimit(int? maxAppointmentsPerDayLimit)
            {
                this.maxAppointmentsPerDayLimit = maxAppointmentsPerDayLimit;
                return this;
            }

            public Builder CancellationWindowSeconds(int? cancellationWindowSeconds)
            {
                this.cancellationWindowSeconds = cancellationWindowSeconds;
                return this;
            }

            public Builder CancellationFeeMoney(Models.Money cancellationFeeMoney)
            {
                this.cancellationFeeMoney = cancellationFeeMoney;
                return this;
            }

            public Builder CancellationPolicy(string cancellationPolicy)
            {
                this.cancellationPolicy = cancellationPolicy;
                return this;
            }

            public Builder CancellationPolicyText(string cancellationPolicyText)
            {
                this.cancellationPolicyText = cancellationPolicyText;
                return this;
            }

            public Builder SkipBookingFlowStaffSelection(bool? skipBookingFlowStaffSelection)
            {
                this.skipBookingFlowStaffSelection = skipBookingFlowStaffSelection;
                return this;
            }

            public BusinessAppointmentSettings Build()
            {
                return new BusinessAppointmentSettings(locationTypes,
                    alignmentTime,
                    minBookingLeadTimeSeconds,
                    maxBookingLeadTimeSeconds,
                    anyTeamMemberBookingEnabled,
                    multipleServiceBookingEnabled,
                    maxAppointmentsPerDayLimitType,
                    maxAppointmentsPerDayLimit,
                    cancellationWindowSeconds,
                    cancellationFeeMoney,
                    cancellationPolicy,
                    cancellationPolicyText,
                    skipBookingFlowStaffSelection);
            }
        }
    }
}