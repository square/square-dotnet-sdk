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
    public class WorkweekConfig 
    {
        public WorkweekConfig(string startOfWeek,
            string startOfDayLocalTime,
            string id = null,
            int? version = null,
            string createdAt = null,
            string updatedAt = null)
        {
            Id = id;
            StartOfWeek = startOfWeek;
            StartOfDayLocalTime = startOfDayLocalTime;
            Version = version;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// UUID for this object
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The days of the week.
        /// </summary>
        [JsonProperty("start_of_week")]
        public string StartOfWeek { get; }

        /// <summary>
        /// The local time at which a business week cuts over. Represented as a
        /// string in `HH:MM` format (`HH:MM:SS` is also accepted, but seconds are
        /// truncated).
        /// </summary>
        [JsonProperty("start_of_day_local_time")]
        public string StartOfDayLocalTime { get; }

        /// <summary>
        /// Used for resolving concurrency issues; request will fail if version
        /// provided does not match server version at time of request. If not provided,
        /// Square executes a blind write; potentially overwriting data from another
        /// write.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format; presented in UTC
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format; presented in UTC
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(StartOfWeek,
                StartOfDayLocalTime)
                .Id(Id)
                .Version(Version)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt);
            return builder;
        }

        public class Builder
        {
            private string startOfWeek;
            private string startOfDayLocalTime;
            private string id;
            private int? version;
            private string createdAt;
            private string updatedAt;

            public Builder(string startOfWeek,
                string startOfDayLocalTime)
            {
                this.startOfWeek = startOfWeek;
                this.startOfDayLocalTime = startOfDayLocalTime;
            }

            public Builder StartOfWeek(string startOfWeek)
            {
                this.startOfWeek = startOfWeek;
                return this;
            }

            public Builder StartOfDayLocalTime(string startOfDayLocalTime)
            {
                this.startOfDayLocalTime = startOfDayLocalTime;
                return this;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Version(int? version)
            {
                this.version = version;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            public WorkweekConfig Build()
            {
                return new WorkweekConfig(startOfWeek,
                    startOfDayLocalTime,
                    id,
                    version,
                    createdAt,
                    updatedAt);
            }
        }
    }
}