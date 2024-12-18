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
    /// BusinessAppointmentSettings.
    /// </summary>
    public class BusinessAppointmentSettings
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessAppointmentSettings"/> class.
        /// </summary>
        /// <param name="locationTypes">location_types.</param>
        /// <param name="alignmentTime">alignment_time.</param>
        /// <param name="minBookingLeadTimeSeconds">min_booking_lead_time_seconds.</param>
        /// <param name="maxBookingLeadTimeSeconds">max_booking_lead_time_seconds.</param>
        /// <param name="anyTeamMemberBookingEnabled">any_team_member_booking_enabled.</param>
        /// <param name="multipleServiceBookingEnabled">multiple_service_booking_enabled.</param>
        /// <param name="maxAppointmentsPerDayLimitType">max_appointments_per_day_limit_type.</param>
        /// <param name="maxAppointmentsPerDayLimit">max_appointments_per_day_limit.</param>
        /// <param name="cancellationWindowSeconds">cancellation_window_seconds.</param>
        /// <param name="cancellationFeeMoney">cancellation_fee_money.</param>
        /// <param name="cancellationPolicy">cancellation_policy.</param>
        /// <param name="cancellationPolicyText">cancellation_policy_text.</param>
        /// <param name="skipBookingFlowStaffSelection">skip_booking_flow_staff_selection.</param>
        public BusinessAppointmentSettings(
            IList<string> locationTypes = null,
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "location_types", false },
                { "min_booking_lead_time_seconds", false },
                { "max_booking_lead_time_seconds", false },
                { "any_team_member_booking_enabled", false },
                { "multiple_service_booking_enabled", false },
                { "max_appointments_per_day_limit", false },
                { "cancellation_window_seconds", false },
                { "cancellation_policy_text", false },
                { "skip_booking_flow_staff_selection", false }
            };

            if (locationTypes != null)
            {
                shouldSerialize["location_types"] = true;
                this.LocationTypes = locationTypes;
            }
            this.AlignmentTime = alignmentTime;

            if (minBookingLeadTimeSeconds != null)
            {
                shouldSerialize["min_booking_lead_time_seconds"] = true;
                this.MinBookingLeadTimeSeconds = minBookingLeadTimeSeconds;
            }

            if (maxBookingLeadTimeSeconds != null)
            {
                shouldSerialize["max_booking_lead_time_seconds"] = true;
                this.MaxBookingLeadTimeSeconds = maxBookingLeadTimeSeconds;
            }

            if (anyTeamMemberBookingEnabled != null)
            {
                shouldSerialize["any_team_member_booking_enabled"] = true;
                this.AnyTeamMemberBookingEnabled = anyTeamMemberBookingEnabled;
            }

            if (multipleServiceBookingEnabled != null)
            {
                shouldSerialize["multiple_service_booking_enabled"] = true;
                this.MultipleServiceBookingEnabled = multipleServiceBookingEnabled;
            }
            this.MaxAppointmentsPerDayLimitType = maxAppointmentsPerDayLimitType;

            if (maxAppointmentsPerDayLimit != null)
            {
                shouldSerialize["max_appointments_per_day_limit"] = true;
                this.MaxAppointmentsPerDayLimit = maxAppointmentsPerDayLimit;
            }

            if (cancellationWindowSeconds != null)
            {
                shouldSerialize["cancellation_window_seconds"] = true;
                this.CancellationWindowSeconds = cancellationWindowSeconds;
            }
            this.CancellationFeeMoney = cancellationFeeMoney;
            this.CancellationPolicy = cancellationPolicy;

            if (cancellationPolicyText != null)
            {
                shouldSerialize["cancellation_policy_text"] = true;
                this.CancellationPolicyText = cancellationPolicyText;
            }

            if (skipBookingFlowStaffSelection != null)
            {
                shouldSerialize["skip_booking_flow_staff_selection"] = true;
                this.SkipBookingFlowStaffSelection = skipBookingFlowStaffSelection;
            }
        }

        internal BusinessAppointmentSettings(
            Dictionary<string, bool> shouldSerialize,
            IList<string> locationTypes = null,
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
            this.shouldSerialize = shouldSerialize;
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
        [JsonProperty("location_types")]
        public IList<string> LocationTypes { get; }

        /// <summary>
        /// Time units of a service duration for bookings.
        /// </summary>
        [JsonProperty("alignment_time", NullValueHandling = NullValueHandling.Ignore)]
        public string AlignmentTime { get; }

        /// <summary>
        /// The minimum lead time in seconds before a service can be booked. A booking must be created at least this amount of time before its starting time.
        /// </summary>
        [JsonProperty("min_booking_lead_time_seconds")]
        public int? MinBookingLeadTimeSeconds { get; }

        /// <summary>
        /// The maximum lead time in seconds before a service can be booked. A booking must be created at most this amount of time before its starting time.
        /// </summary>
        [JsonProperty("max_booking_lead_time_seconds")]
        public int? MaxBookingLeadTimeSeconds { get; }

        /// <summary>
        /// Indicates whether a customer can choose from all available time slots and have a staff member assigned
        /// automatically (`true`) or not (`false`).
        /// </summary>
        [JsonProperty("any_team_member_booking_enabled")]
        public bool? AnyTeamMemberBookingEnabled { get; }

        /// <summary>
        /// Indicates whether a customer can book multiple services in a single online booking.
        /// </summary>
        [JsonProperty("multiple_service_booking_enabled")]
        public bool? MultipleServiceBookingEnabled { get; }

        /// <summary>
        /// Types of daily appointment limits.
        /// </summary>
        [JsonProperty("max_appointments_per_day_limit_type", NullValueHandling = NullValueHandling.Ignore)]
        public string MaxAppointmentsPerDayLimitType { get; }

        /// <summary>
        /// The maximum number of daily appointments per team member or per location.
        /// </summary>
        [JsonProperty("max_appointments_per_day_limit")]
        public int? MaxAppointmentsPerDayLimit { get; }

        /// <summary>
        /// The cut-off time in seconds for allowing clients to cancel or reschedule an appointment.
        /// </summary>
        [JsonProperty("cancellation_window_seconds")]
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
        [JsonProperty("cancellation_policy_text")]
        public string CancellationPolicyText { get; }

        /// <summary>
        /// Indicates whether customers has an assigned staff member (`true`) or can select s staff member of their choice (`false`).
        /// </summary>
        [JsonProperty("skip_booking_flow_staff_selection")]
        public bool? SkipBookingFlowStaffSelection { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"BusinessAppointmentSettings : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationTypes()
        {
            return this.shouldSerialize["location_types"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMinBookingLeadTimeSeconds()
        {
            return this.shouldSerialize["min_booking_lead_time_seconds"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMaxBookingLeadTimeSeconds()
        {
            return this.shouldSerialize["max_booking_lead_time_seconds"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAnyTeamMemberBookingEnabled()
        {
            return this.shouldSerialize["any_team_member_booking_enabled"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMultipleServiceBookingEnabled()
        {
            return this.shouldSerialize["multiple_service_booking_enabled"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMaxAppointmentsPerDayLimit()
        {
            return this.shouldSerialize["max_appointments_per_day_limit"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCancellationWindowSeconds()
        {
            return this.shouldSerialize["cancellation_window_seconds"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCancellationPolicyText()
        {
            return this.shouldSerialize["cancellation_policy_text"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSkipBookingFlowStaffSelection()
        {
            return this.shouldSerialize["skip_booking_flow_staff_selection"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is BusinessAppointmentSettings other &&
                (this.LocationTypes == null && other.LocationTypes == null ||
                 this.LocationTypes?.Equals(other.LocationTypes) == true) &&
                (this.AlignmentTime == null && other.AlignmentTime == null ||
                 this.AlignmentTime?.Equals(other.AlignmentTime) == true) &&
                (this.MinBookingLeadTimeSeconds == null && other.MinBookingLeadTimeSeconds == null ||
                 this.MinBookingLeadTimeSeconds?.Equals(other.MinBookingLeadTimeSeconds) == true) &&
                (this.MaxBookingLeadTimeSeconds == null && other.MaxBookingLeadTimeSeconds == null ||
                 this.MaxBookingLeadTimeSeconds?.Equals(other.MaxBookingLeadTimeSeconds) == true) &&
                (this.AnyTeamMemberBookingEnabled == null && other.AnyTeamMemberBookingEnabled == null ||
                 this.AnyTeamMemberBookingEnabled?.Equals(other.AnyTeamMemberBookingEnabled) == true) &&
                (this.MultipleServiceBookingEnabled == null && other.MultipleServiceBookingEnabled == null ||
                 this.MultipleServiceBookingEnabled?.Equals(other.MultipleServiceBookingEnabled) == true) &&
                (this.MaxAppointmentsPerDayLimitType == null && other.MaxAppointmentsPerDayLimitType == null ||
                 this.MaxAppointmentsPerDayLimitType?.Equals(other.MaxAppointmentsPerDayLimitType) == true) &&
                (this.MaxAppointmentsPerDayLimit == null && other.MaxAppointmentsPerDayLimit == null ||
                 this.MaxAppointmentsPerDayLimit?.Equals(other.MaxAppointmentsPerDayLimit) == true) &&
                (this.CancellationWindowSeconds == null && other.CancellationWindowSeconds == null ||
                 this.CancellationWindowSeconds?.Equals(other.CancellationWindowSeconds) == true) &&
                (this.CancellationFeeMoney == null && other.CancellationFeeMoney == null ||
                 this.CancellationFeeMoney?.Equals(other.CancellationFeeMoney) == true) &&
                (this.CancellationPolicy == null && other.CancellationPolicy == null ||
                 this.CancellationPolicy?.Equals(other.CancellationPolicy) == true) &&
                (this.CancellationPolicyText == null && other.CancellationPolicyText == null ||
                 this.CancellationPolicyText?.Equals(other.CancellationPolicyText) == true) &&
                (this.SkipBookingFlowStaffSelection == null && other.SkipBookingFlowStaffSelection == null ||
                 this.SkipBookingFlowStaffSelection?.Equals(other.SkipBookingFlowStaffSelection) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 114929036;
            hashCode = HashCode.Combine(hashCode, this.LocationTypes, this.AlignmentTime, this.MinBookingLeadTimeSeconds, this.MaxBookingLeadTimeSeconds, this.AnyTeamMemberBookingEnabled, this.MultipleServiceBookingEnabled, this.MaxAppointmentsPerDayLimitType);

            hashCode = HashCode.Combine(hashCode, this.MaxAppointmentsPerDayLimit, this.CancellationWindowSeconds, this.CancellationFeeMoney, this.CancellationPolicy, this.CancellationPolicyText, this.SkipBookingFlowStaffSelection);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationTypes = {(this.LocationTypes == null ? "null" : $"[{string.Join(", ", this.LocationTypes)} ]")}");
            toStringOutput.Add($"this.AlignmentTime = {(this.AlignmentTime == null ? "null" : this.AlignmentTime.ToString())}");
            toStringOutput.Add($"this.MinBookingLeadTimeSeconds = {(this.MinBookingLeadTimeSeconds == null ? "null" : this.MinBookingLeadTimeSeconds.ToString())}");
            toStringOutput.Add($"this.MaxBookingLeadTimeSeconds = {(this.MaxBookingLeadTimeSeconds == null ? "null" : this.MaxBookingLeadTimeSeconds.ToString())}");
            toStringOutput.Add($"this.AnyTeamMemberBookingEnabled = {(this.AnyTeamMemberBookingEnabled == null ? "null" : this.AnyTeamMemberBookingEnabled.ToString())}");
            toStringOutput.Add($"this.MultipleServiceBookingEnabled = {(this.MultipleServiceBookingEnabled == null ? "null" : this.MultipleServiceBookingEnabled.ToString())}");
            toStringOutput.Add($"this.MaxAppointmentsPerDayLimitType = {(this.MaxAppointmentsPerDayLimitType == null ? "null" : this.MaxAppointmentsPerDayLimitType.ToString())}");
            toStringOutput.Add($"this.MaxAppointmentsPerDayLimit = {(this.MaxAppointmentsPerDayLimit == null ? "null" : this.MaxAppointmentsPerDayLimit.ToString())}");
            toStringOutput.Add($"this.CancellationWindowSeconds = {(this.CancellationWindowSeconds == null ? "null" : this.CancellationWindowSeconds.ToString())}");
            toStringOutput.Add($"this.CancellationFeeMoney = {(this.CancellationFeeMoney == null ? "null" : this.CancellationFeeMoney.ToString())}");
            toStringOutput.Add($"this.CancellationPolicy = {(this.CancellationPolicy == null ? "null" : this.CancellationPolicy.ToString())}");
            toStringOutput.Add($"this.CancellationPolicyText = {this.CancellationPolicyText ?? "null"}");
            toStringOutput.Add($"this.SkipBookingFlowStaffSelection = {(this.SkipBookingFlowStaffSelection == null ? "null" : this.SkipBookingFlowStaffSelection.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationTypes(this.LocationTypes)
                .AlignmentTime(this.AlignmentTime)
                .MinBookingLeadTimeSeconds(this.MinBookingLeadTimeSeconds)
                .MaxBookingLeadTimeSeconds(this.MaxBookingLeadTimeSeconds)
                .AnyTeamMemberBookingEnabled(this.AnyTeamMemberBookingEnabled)
                .MultipleServiceBookingEnabled(this.MultipleServiceBookingEnabled)
                .MaxAppointmentsPerDayLimitType(this.MaxAppointmentsPerDayLimitType)
                .MaxAppointmentsPerDayLimit(this.MaxAppointmentsPerDayLimit)
                .CancellationWindowSeconds(this.CancellationWindowSeconds)
                .CancellationFeeMoney(this.CancellationFeeMoney)
                .CancellationPolicy(this.CancellationPolicy)
                .CancellationPolicyText(this.CancellationPolicyText)
                .SkipBookingFlowStaffSelection(this.SkipBookingFlowStaffSelection);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "location_types", false },
                { "min_booking_lead_time_seconds", false },
                { "max_booking_lead_time_seconds", false },
                { "any_team_member_booking_enabled", false },
                { "multiple_service_booking_enabled", false },
                { "max_appointments_per_day_limit", false },
                { "cancellation_window_seconds", false },
                { "cancellation_policy_text", false },
                { "skip_booking_flow_staff_selection", false },
            };

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

             /// <summary>
             /// LocationTypes.
             /// </summary>
             /// <param name="locationTypes"> locationTypes. </param>
             /// <returns> Builder. </returns>
            public Builder LocationTypes(IList<string> locationTypes)
            {
                shouldSerialize["location_types"] = true;
                this.locationTypes = locationTypes;
                return this;
            }

             /// <summary>
             /// AlignmentTime.
             /// </summary>
             /// <param name="alignmentTime"> alignmentTime. </param>
             /// <returns> Builder. </returns>
            public Builder AlignmentTime(string alignmentTime)
            {
                this.alignmentTime = alignmentTime;
                return this;
            }

             /// <summary>
             /// MinBookingLeadTimeSeconds.
             /// </summary>
             /// <param name="minBookingLeadTimeSeconds"> minBookingLeadTimeSeconds. </param>
             /// <returns> Builder. </returns>
            public Builder MinBookingLeadTimeSeconds(int? minBookingLeadTimeSeconds)
            {
                shouldSerialize["min_booking_lead_time_seconds"] = true;
                this.minBookingLeadTimeSeconds = minBookingLeadTimeSeconds;
                return this;
            }

             /// <summary>
             /// MaxBookingLeadTimeSeconds.
             /// </summary>
             /// <param name="maxBookingLeadTimeSeconds"> maxBookingLeadTimeSeconds. </param>
             /// <returns> Builder. </returns>
            public Builder MaxBookingLeadTimeSeconds(int? maxBookingLeadTimeSeconds)
            {
                shouldSerialize["max_booking_lead_time_seconds"] = true;
                this.maxBookingLeadTimeSeconds = maxBookingLeadTimeSeconds;
                return this;
            }

             /// <summary>
             /// AnyTeamMemberBookingEnabled.
             /// </summary>
             /// <param name="anyTeamMemberBookingEnabled"> anyTeamMemberBookingEnabled. </param>
             /// <returns> Builder. </returns>
            public Builder AnyTeamMemberBookingEnabled(bool? anyTeamMemberBookingEnabled)
            {
                shouldSerialize["any_team_member_booking_enabled"] = true;
                this.anyTeamMemberBookingEnabled = anyTeamMemberBookingEnabled;
                return this;
            }

             /// <summary>
             /// MultipleServiceBookingEnabled.
             /// </summary>
             /// <param name="multipleServiceBookingEnabled"> multipleServiceBookingEnabled. </param>
             /// <returns> Builder. </returns>
            public Builder MultipleServiceBookingEnabled(bool? multipleServiceBookingEnabled)
            {
                shouldSerialize["multiple_service_booking_enabled"] = true;
                this.multipleServiceBookingEnabled = multipleServiceBookingEnabled;
                return this;
            }

             /// <summary>
             /// MaxAppointmentsPerDayLimitType.
             /// </summary>
             /// <param name="maxAppointmentsPerDayLimitType"> maxAppointmentsPerDayLimitType. </param>
             /// <returns> Builder. </returns>
            public Builder MaxAppointmentsPerDayLimitType(string maxAppointmentsPerDayLimitType)
            {
                this.maxAppointmentsPerDayLimitType = maxAppointmentsPerDayLimitType;
                return this;
            }

             /// <summary>
             /// MaxAppointmentsPerDayLimit.
             /// </summary>
             /// <param name="maxAppointmentsPerDayLimit"> maxAppointmentsPerDayLimit. </param>
             /// <returns> Builder. </returns>
            public Builder MaxAppointmentsPerDayLimit(int? maxAppointmentsPerDayLimit)
            {
                shouldSerialize["max_appointments_per_day_limit"] = true;
                this.maxAppointmentsPerDayLimit = maxAppointmentsPerDayLimit;
                return this;
            }

             /// <summary>
             /// CancellationWindowSeconds.
             /// </summary>
             /// <param name="cancellationWindowSeconds"> cancellationWindowSeconds. </param>
             /// <returns> Builder. </returns>
            public Builder CancellationWindowSeconds(int? cancellationWindowSeconds)
            {
                shouldSerialize["cancellation_window_seconds"] = true;
                this.cancellationWindowSeconds = cancellationWindowSeconds;
                return this;
            }

             /// <summary>
             /// CancellationFeeMoney.
             /// </summary>
             /// <param name="cancellationFeeMoney"> cancellationFeeMoney. </param>
             /// <returns> Builder. </returns>
            public Builder CancellationFeeMoney(Models.Money cancellationFeeMoney)
            {
                this.cancellationFeeMoney = cancellationFeeMoney;
                return this;
            }

             /// <summary>
             /// CancellationPolicy.
             /// </summary>
             /// <param name="cancellationPolicy"> cancellationPolicy. </param>
             /// <returns> Builder. </returns>
            public Builder CancellationPolicy(string cancellationPolicy)
            {
                this.cancellationPolicy = cancellationPolicy;
                return this;
            }

             /// <summary>
             /// CancellationPolicyText.
             /// </summary>
             /// <param name="cancellationPolicyText"> cancellationPolicyText. </param>
             /// <returns> Builder. </returns>
            public Builder CancellationPolicyText(string cancellationPolicyText)
            {
                shouldSerialize["cancellation_policy_text"] = true;
                this.cancellationPolicyText = cancellationPolicyText;
                return this;
            }

             /// <summary>
             /// SkipBookingFlowStaffSelection.
             /// </summary>
             /// <param name="skipBookingFlowStaffSelection"> skipBookingFlowStaffSelection. </param>
             /// <returns> Builder. </returns>
            public Builder SkipBookingFlowStaffSelection(bool? skipBookingFlowStaffSelection)
            {
                shouldSerialize["skip_booking_flow_staff_selection"] = true;
                this.skipBookingFlowStaffSelection = skipBookingFlowStaffSelection;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLocationTypes()
            {
                this.shouldSerialize["location_types"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetMinBookingLeadTimeSeconds()
            {
                this.shouldSerialize["min_booking_lead_time_seconds"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetMaxBookingLeadTimeSeconds()
            {
                this.shouldSerialize["max_booking_lead_time_seconds"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetAnyTeamMemberBookingEnabled()
            {
                this.shouldSerialize["any_team_member_booking_enabled"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetMultipleServiceBookingEnabled()
            {
                this.shouldSerialize["multiple_service_booking_enabled"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetMaxAppointmentsPerDayLimit()
            {
                this.shouldSerialize["max_appointments_per_day_limit"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCancellationWindowSeconds()
            {
                this.shouldSerialize["cancellation_window_seconds"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCancellationPolicyText()
            {
                this.shouldSerialize["cancellation_policy_text"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetSkipBookingFlowStaffSelection()
            {
                this.shouldSerialize["skip_booking_flow_staff_selection"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BusinessAppointmentSettings. </returns>
            public BusinessAppointmentSettings Build()
            {
                return new BusinessAppointmentSettings(
                    shouldSerialize,
                    this.locationTypes,
                    this.alignmentTime,
                    this.minBookingLeadTimeSeconds,
                    this.maxBookingLeadTimeSeconds,
                    this.anyTeamMemberBookingEnabled,
                    this.multipleServiceBookingEnabled,
                    this.maxAppointmentsPerDayLimitType,
                    this.maxAppointmentsPerDayLimit,
                    this.cancellationWindowSeconds,
                    this.cancellationFeeMoney,
                    this.cancellationPolicy,
                    this.cancellationPolicyText,
                    this.skipBookingFlowStaffSelection);
            }
        }
    }
}