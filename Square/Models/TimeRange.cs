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
    public class TimeRange 
    {
        public TimeRange(string startAt = null,
            string endAt = null)
        {
            StartAt = startAt;
            EndAt = endAt;
        }

        /// <summary>
        /// A datetime value in RFC 3339 format indicating when the time range
        /// starts.
        /// </summary>
        [JsonProperty("start_at", NullValueHandling = NullValueHandling.Ignore)]
        public string StartAt { get; }

        /// <summary>
        /// A datetime value in RFC 3339 format indicating when the time range
        /// ends.
        /// </summary>
        [JsonProperty("end_at", NullValueHandling = NullValueHandling.Ignore)]
        public string EndAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .StartAt(StartAt)
                .EndAt(EndAt);
            return builder;
        }

        public class Builder
        {
            private string startAt;
            private string endAt;



            public Builder StartAt(string startAt)
            {
                this.startAt = startAt;
                return this;
            }

            public Builder EndAt(string endAt)
            {
                this.endAt = endAt;
                return this;
            }

            public TimeRange Build()
            {
                return new TimeRange(startAt,
                    endAt);
            }
        }
    }
}