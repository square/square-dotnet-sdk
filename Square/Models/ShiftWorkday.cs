
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
    public class ShiftWorkday 
    {
        public ShiftWorkday(Models.DateRange dateRange = null,
            string matchShiftsBy = null,
            string defaultTimezone = null)
        {
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
        /// Every location included in the query must have a timezone, or this field
        /// must be provided as a fallback. Format: the IANA timezone database
        /// identifier for the relevant timezone.
        /// </summary>
        [JsonProperty("default_timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultTimezone { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ShiftWorkday : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"DateRange = {(DateRange == null ? "null" : DateRange.ToString())}");
            toStringOutput.Add($"MatchShiftsBy = {(MatchShiftsBy == null ? "null" : MatchShiftsBy.ToString())}");
            toStringOutput.Add($"DefaultTimezone = {(DefaultTimezone == null ? "null" : DefaultTimezone == string.Empty ? "" : DefaultTimezone)}");
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

            return obj is ShiftWorkday other &&
                ((DateRange == null && other.DateRange == null) || (DateRange?.Equals(other.DateRange) == true)) &&
                ((MatchShiftsBy == null && other.MatchShiftsBy == null) || (MatchShiftsBy?.Equals(other.MatchShiftsBy) == true)) &&
                ((DefaultTimezone == null && other.DefaultTimezone == null) || (DefaultTimezone?.Equals(other.DefaultTimezone) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1536716736;

            if (DateRange != null)
            {
               hashCode += DateRange.GetHashCode();
            }

            if (MatchShiftsBy != null)
            {
               hashCode += MatchShiftsBy.GetHashCode();
            }

            if (DefaultTimezone != null)
            {
               hashCode += DefaultTimezone.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .DateRange(DateRange)
                .MatchShiftsBy(MatchShiftsBy)
                .DefaultTimezone(DefaultTimezone);
            return builder;
        }

        public class Builder
        {
            private Models.DateRange dateRange;
            private string matchShiftsBy;
            private string defaultTimezone;



            public Builder DateRange(Models.DateRange dateRange)
            {
                this.dateRange = dateRange;
                return this;
            }

            public Builder MatchShiftsBy(string matchShiftsBy)
            {
                this.matchShiftsBy = matchShiftsBy;
                return this;
            }

            public Builder DefaultTimezone(string defaultTimezone)
            {
                this.defaultTimezone = defaultTimezone;
                return this;
            }

            public ShiftWorkday Build()
            {
                return new ShiftWorkday(dateRange,
                    matchShiftsBy,
                    defaultTimezone);
            }
        }
    }
}