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
        [JsonProperty("day_of_week")]
        public string DayOfWeek { get; }

        /// <summary>
        /// The start time of a business hours period, specified in local time using partial-time
        /// RFC3339 format.
        /// </summary>
        [JsonProperty("start_local_time")]
        public string StartLocalTime { get; }

        /// <summary>
        /// The end time of a business hours period, specified in local time using partial-time
        /// RFC3339 format.
        /// </summary>
        [JsonProperty("end_local_time")]
        public string EndLocalTime { get; }

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

            public Builder() { }
            public Builder DayOfWeek(string value)
            {
                dayOfWeek = value;
                return this;
            }

            public Builder StartLocalTime(string value)
            {
                startLocalTime = value;
                return this;
            }

            public Builder EndLocalTime(string value)
            {
                endLocalTime = value;
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