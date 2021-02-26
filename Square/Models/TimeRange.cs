
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TimeRange : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"StartAt = {(StartAt == null ? "null" : StartAt == string.Empty ? "" : StartAt)}");
            toStringOutput.Add($"EndAt = {(EndAt == null ? "null" : EndAt == string.Empty ? "" : EndAt)}");
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

            return obj is TimeRange other &&
                ((StartAt == null && other.StartAt == null) || (StartAt?.Equals(other.StartAt) == true)) &&
                ((EndAt == null && other.EndAt == null) || (EndAt?.Equals(other.EndAt) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1397829395;

            if (StartAt != null)
            {
               hashCode += StartAt.GetHashCode();
            }

            if (EndAt != null)
            {
               hashCode += EndAt.GetHashCode();
            }

            return hashCode;
        }

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