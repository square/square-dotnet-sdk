
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
        [JsonProperty("start_date", NullValueHandling = NullValueHandling.Ignore)]
        public string StartDate { get; }

        /// <summary>
        /// String in `YYYY-MM-DD` format, e.g. `2017-10-31` per the ISO 8601
        /// extended format for calendar dates.
        /// The end of a date range (inclusive)
        /// </summary>
        [JsonProperty("end_date", NullValueHandling = NullValueHandling.Ignore)]
        public string EndDate { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DateRange : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"StartDate = {(StartDate == null ? "null" : StartDate == string.Empty ? "" : StartDate)}");
            toStringOutput.Add($"EndDate = {(EndDate == null ? "null" : EndDate == string.Empty ? "" : EndDate)}");
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

            return obj is DateRange other &&
                ((StartDate == null && other.StartDate == null) || (StartDate?.Equals(other.StartDate) == true)) &&
                ((EndDate == null && other.EndDate == null) || (EndDate?.Equals(other.EndDate) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1178039224;

            if (StartDate != null)
            {
               hashCode += StartDate.GetHashCode();
            }

            if (EndDate != null)
            {
               hashCode += EndDate.GetHashCode();
            }

            return hashCode;
        }

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



            public Builder StartDate(string startDate)
            {
                this.startDate = startDate;
                return this;
            }

            public Builder EndDate(string endDate)
            {
                this.endDate = endDate;
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