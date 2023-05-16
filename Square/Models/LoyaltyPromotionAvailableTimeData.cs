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
    /// LoyaltyPromotionAvailableTimeData.
    /// </summary>
    public class LoyaltyPromotionAvailableTimeData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyPromotionAvailableTimeData"/> class.
        /// </summary>
        /// <param name="timePeriods">time_periods.</param>
        /// <param name="startDate">start_date.</param>
        /// <param name="endDate">end_date.</param>
        public LoyaltyPromotionAvailableTimeData(
            IList<string> timePeriods,
            string startDate = null,
            string endDate = null)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.TimePeriods = timePeriods;
        }

        /// <summary>
        /// The date that the promotion starts, in `YYYY-MM-DD` format. Square populates this field
        /// based on the provided `time_periods`.
        /// </summary>
        [JsonProperty("start_date", NullValueHandling = NullValueHandling.Ignore)]
        public string StartDate { get; }

        /// <summary>
        /// The date that the promotion ends, in `YYYY-MM-DD` format. Square populates this field
        /// based on the provided `time_periods`. If an end date is not specified, an `ACTIVE` promotion
        /// remains available until it is canceled.
        /// </summary>
        [JsonProperty("end_date", NullValueHandling = NullValueHandling.Ignore)]
        public string EndDate { get; }

        /// <summary>
        /// A list of [iCalendar (RFC 5545) events](https://tools.ietf.org/html/rfc5545#section-3.6.1)
        /// (`VEVENT`). Each event represents an available time period per day or days of the week.
        /// A day can have a maximum of one available time period.
        /// Only `DTSTART`, `DURATION`, and `RRULE` are supported. `DTSTART` and `DURATION` are required and
        /// timestamps must be in local (unzoned) time format. Include `RRULE` to specify recurring promotions,
        /// an end date (using the `UNTIL` keyword), or both. For more information, see
        /// [Available time](https://developer.squareup.com/docs/loyalty-api/loyalty-promotions#available-time).
        /// Note that `BEGIN:VEVENT` and `END:VEVENT` are optional in a `CreateLoyaltyPromotion` request
        /// but are always included in the response.
        /// </summary>
        [JsonProperty("time_periods")]
        public IList<string> TimePeriods { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyPromotionAvailableTimeData : ({string.Join(", ", toStringOutput)})";
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
            return obj is LoyaltyPromotionAvailableTimeData other &&                ((this.StartDate == null && other.StartDate == null) || (this.StartDate?.Equals(other.StartDate) == true)) &&
                ((this.EndDate == null && other.EndDate == null) || (this.EndDate?.Equals(other.EndDate) == true)) &&
                ((this.TimePeriods == null && other.TimePeriods == null) || (this.TimePeriods?.Equals(other.TimePeriods) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 185496256;
            hashCode = HashCode.Combine(this.StartDate, this.EndDate, this.TimePeriods);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.StartDate = {(this.StartDate == null ? "null" : this.StartDate == string.Empty ? "" : this.StartDate)}");
            toStringOutput.Add($"this.EndDate = {(this.EndDate == null ? "null" : this.EndDate == string.Empty ? "" : this.EndDate)}");
            toStringOutput.Add($"this.TimePeriods = {(this.TimePeriods == null ? "null" : $"[{string.Join(", ", this.TimePeriods)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.TimePeriods)
                .StartDate(this.StartDate)
                .EndDate(this.EndDate);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> timePeriods;
            private string startDate;
            private string endDate;

            public Builder(
                IList<string> timePeriods)
            {
                this.timePeriods = timePeriods;
            }

             /// <summary>
             /// TimePeriods.
             /// </summary>
             /// <param name="timePeriods"> timePeriods. </param>
             /// <returns> Builder. </returns>
            public Builder TimePeriods(IList<string> timePeriods)
            {
                this.timePeriods = timePeriods;
                return this;
            }

             /// <summary>
             /// StartDate.
             /// </summary>
             /// <param name="startDate"> startDate. </param>
             /// <returns> Builder. </returns>
            public Builder StartDate(string startDate)
            {
                this.startDate = startDate;
                return this;
            }

             /// <summary>
             /// EndDate.
             /// </summary>
             /// <param name="endDate"> endDate. </param>
             /// <returns> Builder. </returns>
            public Builder EndDate(string endDate)
            {
                this.endDate = endDate;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyPromotionAvailableTimeData. </returns>
            public LoyaltyPromotionAvailableTimeData Build()
            {
                return new LoyaltyPromotionAvailableTimeData(
                    this.timePeriods,
                    this.startDate,
                    this.endDate);
            }
        }
    }
}