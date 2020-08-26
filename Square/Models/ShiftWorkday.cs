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
        [JsonProperty("date_range")]
        public Models.DateRange DateRange { get; }

        /// <summary>
        /// Defines the logic used to apply a workday filter.
        /// </summary>
        [JsonProperty("match_shifts_by")]
        public string MatchShiftsBy { get; }

        /// <summary>
        /// Location-specific timezones convert workdays to datetime filters.
        /// Every location included in the query must have a timezone, or this field
        /// must be provided as a fallback. Format: the IANA timezone database
        /// identifier for the relevant timezone.
        /// </summary>
        [JsonProperty("default_timezone")]
        public string DefaultTimezone { get; }

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

            public Builder() { }
            public Builder DateRange(Models.DateRange value)
            {
                dateRange = value;
                return this;
            }

            public Builder MatchShiftsBy(string value)
            {
                matchShiftsBy = value;
                return this;
            }

            public Builder DefaultTimezone(string value)
            {
                defaultTimezone = value;
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