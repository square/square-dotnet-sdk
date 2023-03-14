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
    /// ShiftWorkday.
    /// </summary>
    public class ShiftWorkday
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ShiftWorkday"/> class.
        /// </summary>
        /// <param name="dateRange">date_range.</param>
        /// <param name="matchShiftsBy">match_shifts_by.</param>
        /// <param name="defaultTimezone">default_timezone.</param>
        public ShiftWorkday(
            Models.DateRange dateRange = null,
            string matchShiftsBy = null,
            string defaultTimezone = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "default_timezone", false }
            };

            this.DateRange = dateRange;
            this.MatchShiftsBy = matchShiftsBy;
            if (defaultTimezone != null)
            {
                shouldSerialize["default_timezone"] = true;
                this.DefaultTimezone = defaultTimezone;
            }

        }
        internal ShiftWorkday(Dictionary<string, bool> shouldSerialize,
            Models.DateRange dateRange = null,
            string matchShiftsBy = null,
            string defaultTimezone = null)
        {
            this.shouldSerialize = shouldSerialize;
            DateRange = dateRange;
            MatchShiftsBy = matchShiftsBy;
            DefaultTimezone = defaultTimezone;
        }

        /// <summary>
        /// A range defined by two dates. Used for filtering a query for Connect v2
        /// objects that have date properties.
        /// </summary>
        [JsonProperty("date_range", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DateRange DateRange { get; }

        /// <summary>
        /// Defines the logic used to apply a workday filter.
        /// </summary>
        [JsonProperty("match_shifts_by", NullValueHandling = NullValueHandling.Ignore)]
        public string MatchShiftsBy { get; }

        /// <summary>
        /// Location-specific timezones convert workdays to datetime filters.
        /// Every location included in the query must have a timezone or this field
        /// must be provided as a fallback. Format: the IANA timezone database
        /// identifier for the relevant timezone.
        /// </summary>
        [JsonProperty("default_timezone")]
        public string DefaultTimezone { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ShiftWorkday : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDefaultTimezone()
        {
            return this.shouldSerialize["default_timezone"];
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

            return obj is ShiftWorkday other &&
                ((this.DateRange == null && other.DateRange == null) || (this.DateRange?.Equals(other.DateRange) == true)) &&
                ((this.MatchShiftsBy == null && other.MatchShiftsBy == null) || (this.MatchShiftsBy?.Equals(other.MatchShiftsBy) == true)) &&
                ((this.DefaultTimezone == null && other.DefaultTimezone == null) || (this.DefaultTimezone?.Equals(other.DefaultTimezone) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1536716736;
            hashCode = HashCode.Combine(this.DateRange, this.MatchShiftsBy, this.DefaultTimezone);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DateRange = {(this.DateRange == null ? "null" : this.DateRange.ToString())}");
            toStringOutput.Add($"this.MatchShiftsBy = {(this.MatchShiftsBy == null ? "null" : this.MatchShiftsBy.ToString())}");
            toStringOutput.Add($"this.DefaultTimezone = {(this.DefaultTimezone == null ? "null" : this.DefaultTimezone == string.Empty ? "" : this.DefaultTimezone)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .DateRange(this.DateRange)
                .MatchShiftsBy(this.MatchShiftsBy)
                .DefaultTimezone(this.DefaultTimezone);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "default_timezone", false },
            };

            private Models.DateRange dateRange;
            private string matchShiftsBy;
            private string defaultTimezone;

             /// <summary>
             /// DateRange.
             /// </summary>
             /// <param name="dateRange"> dateRange. </param>
             /// <returns> Builder. </returns>
            public Builder DateRange(Models.DateRange dateRange)
            {
                this.dateRange = dateRange;
                return this;
            }

             /// <summary>
             /// MatchShiftsBy.
             /// </summary>
             /// <param name="matchShiftsBy"> matchShiftsBy. </param>
             /// <returns> Builder. </returns>
            public Builder MatchShiftsBy(string matchShiftsBy)
            {
                this.matchShiftsBy = matchShiftsBy;
                return this;
            }

             /// <summary>
             /// DefaultTimezone.
             /// </summary>
             /// <param name="defaultTimezone"> defaultTimezone. </param>
             /// <returns> Builder. </returns>
            public Builder DefaultTimezone(string defaultTimezone)
            {
                shouldSerialize["default_timezone"] = true;
                this.defaultTimezone = defaultTimezone;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDefaultTimezone()
            {
                this.shouldSerialize["default_timezone"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ShiftWorkday. </returns>
            public ShiftWorkday Build()
            {
                return new ShiftWorkday(shouldSerialize,
                    this.dateRange,
                    this.matchShiftsBy,
                    this.defaultTimezone);
            }
        }
    }
}