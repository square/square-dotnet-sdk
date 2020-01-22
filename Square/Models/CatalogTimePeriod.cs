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
    public class CatalogTimePeriod 
    {
        public CatalogTimePeriod(string mEvent = null)
        {
            MEvent = mEvent;
        }

        /// <summary>
        /// An iCalendar (RFC5545) [event](https://tools.ietf.org/html/rfc5545#section-3.6.1), which
        /// specifies the name, timing, duration and recurrence of this time period.
        /// Example:
        /// ```
        /// DTSTART:20190707T180000
        /// DURATION:P2H
        /// RRULE:FREQ=WEEKLY;BYDAY=MO,WE,FR
        /// ```
        /// Only `SUMMARY`, `DTSTART`, `DURATION` and `RRULE` fields are supported.
        /// `DTSTART` must be in local (unzoned) time format. Note that while `BEGIN:VEVENT`
        /// and `END:VEVENT` is not required in the request. The response will always
        /// include them.
        /// </summary>
        [JsonProperty("event")]
        public string MEvent { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .MEvent(MEvent);
            return builder;
        }

        public class Builder
        {
            private string mEvent;

            public Builder() { }
            public Builder MEvent(string value)
            {
                mEvent = value;
                return this;
            }

            public CatalogTimePeriod Build()
            {
                return new CatalogTimePeriod(mEvent);
            }
        }
    }
}