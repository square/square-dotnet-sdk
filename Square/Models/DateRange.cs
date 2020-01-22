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
    public class DateRange 
    {
        public DateRange(string startDate = null,
            string endDate = null)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        /// <summary>
        /// String in `YYYY-MM-DD` format, e.g. `2017-10-31` per the ISO 8601
        /// extended format for calendar dates.
        /// The beginning of a date range (inclusive)
        /// </summary>
        [JsonProperty("start_date")]
        public string StartDate { get; }

        /// <summary>
        /// String in `YYYY-MM-DD` format, e.g. `2017-10-31` per the ISO 8601
        /// extended format for calendar dates.
        /// The end of a date range (inclusive)
        /// </summary>
        [JsonProperty("end_date")]
        public string EndDate { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .StartDate(StartDate)
                .EndDate(EndDate);
            return builder;
        }

        public class Builder
        {
            private string startDate;
            private string endDate;

            public Builder() { }
            public Builder StartDate(string value)
            {
                startDate = value;
                return this;
            }

            public Builder EndDate(string value)
            {
                endDate = value;
                return this;
            }

            public DateRange Build()
            {
                return new DateRange(startDate,
                    endDate);
            }
        }
    }
}