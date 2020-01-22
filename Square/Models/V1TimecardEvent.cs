using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1TimecardEvent 
    {
        public V1TimecardEvent(string id = null,
            string eventType = null,
            string clockinTime = null,
            string clockoutTime = null,
            string createdAt = null)
        {
            Id = id;
            EventType = eventType;
            ClockinTime = clockinTime;
            ClockoutTime = clockoutTime;
            CreatedAt = createdAt;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The event's unique ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// Actions that resulted in a change to a timecard. All timecard
        /// events created with the Connect API have an event type that begins with
        /// `API`.
        /// </summary>
        [JsonProperty("event_type")]
        public string EventType { get; }

        /// <summary>
        /// The time the employee clocked in, in ISO 8601 format.
        /// </summary>
        [JsonProperty("clockin_time")]
        public string ClockinTime { get; }

        /// <summary>
        /// The time the employee clocked out, in ISO 8601 format.
        /// </summary>
        [JsonProperty("clockout_time")]
        public string ClockoutTime { get; }

        /// <summary>
        /// The time when the event was created, in ISO 8601 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .EventType(EventType)
                .ClockinTime(ClockinTime)
                .ClockoutTime(ClockoutTime)
                .CreatedAt(CreatedAt);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string eventType;
            private string clockinTime;
            private string clockoutTime;
            private string createdAt;

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder EventType(string value)
            {
                eventType = value;
                return this;
            }

            public Builder ClockinTime(string value)
            {
                clockinTime = value;
                return this;
            }

            public Builder ClockoutTime(string value)
            {
                clockoutTime = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public V1TimecardEvent Build()
            {
                return new V1TimecardEvent(id,
                    eventType,
                    clockinTime,
                    clockoutTime,
                    createdAt);
            }
        }
    }
}