
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
    public class BusinessHoursPeriod 
    {
        public BusinessHoursPeriod(string dayOfWeek = null,
            string startLocalTime = null,
            string endLocalTime = null)
        {
            DayOfWeek = dayOfWeek;
            StartLocalTime = startLocalTime;
            EndLocalTime = endLocalTime;
        }

        /// <summary>
        /// Indicates the specific day  of the week.
        /// </summary>
        [JsonProperty("day_of_week", NullValueHandling = NullValueHandling.Ignore)]
        public string DayOfWeek { get; }

        /// <summary>
        /// The start time of a business hours period, specified in local time using partial-time
        /// RFC 3339 format.
        /// </summary>
        [JsonProperty("start_local_time", NullValueHandling = NullValueHandling.Ignore)]
        public string StartLocalTime { get; }

        /// <summary>
        /// The end time of a business hours period, specified in local time using partial-time
        /// RFC 3339 format.
        /// </summary>
        [JsonProperty("end_local_time", NullValueHandling = NullValueHandling.Ignore)]
        public string EndLocalTime { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BusinessHoursPeriod : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"DayOfWeek = {(DayOfWeek == null ? "null" : DayOfWeek.ToString())}");
            toStringOutput.Add($"StartLocalTime = {(StartLocalTime == null ? "null" : StartLocalTime == string.Empty ? "" : StartLocalTime)}");
            toStringOutput.Add($"EndLocalTime = {(EndLocalTime == null ? "null" : EndLocalTime == string.Empty ? "" : EndLocalTime)}");
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

            return obj is BusinessHoursPeriod other &&
                ((DayOfWeek == null && other.DayOfWeek == null) || (DayOfWeek?.Equals(other.DayOfWeek) == true)) &&
                ((StartLocalTime == null && other.StartLocalTime == null) || (StartLocalTime?.Equals(other.StartLocalTime) == true)) &&
                ((EndLocalTime == null && other.EndLocalTime == null) || (EndLocalTime?.Equals(other.EndLocalTime) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 870467587;

            if (DayOfWeek != null)
            {
               hashCode += DayOfWeek.GetHashCode();
            }

            if (StartLocalTime != null)
            {
               hashCode += StartLocalTime.GetHashCode();
            }

            if (EndLocalTime != null)
            {
               hashCode += EndLocalTime.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .DayOfWeek(DayOfWeek)
                .StartLocalTime(StartLocalTime)
                .EndLocalTime(EndLocalTime);
            return builder;
        }

        public class Builder
        {
            private string dayOfWeek;
            private string startLocalTime;
            private string endLocalTime;



            public Builder DayOfWeek(string dayOfWeek)
            {
                this.dayOfWeek = dayOfWeek;
                return this;
            }

            public Builder StartLocalTime(string startLocalTime)
            {
                this.startLocalTime = startLocalTime;
                return this;
            }

            public Builder EndLocalTime(string endLocalTime)
            {
                this.endLocalTime = endLocalTime;
                return this;
            }

            public BusinessHoursPeriod Build()
            {
                return new BusinessHoursPeriod(dayOfWeek,
                    startLocalTime,
                    endLocalTime);
            }
        }
    }
}