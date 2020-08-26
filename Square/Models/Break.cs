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
    public class Break 
    {
        public Break(string startAt,
            string breakTypeId,
            string name,
            string expectedDuration,
            bool isPaid,
            string id = null,
            string endAt = null)
        {
            Id = id;
            StartAt = startAt;
            EndAt = endAt;
            BreakTypeId = breakTypeId;
            Name = name;
            ExpectedDuration = expectedDuration;
            IsPaid = isPaid;
        }

        /// <summary>
        /// UUID for this object
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// RFC 3339; follows same timezone info as `Shift`. Precision up to
        /// the minute is respected; seconds are truncated.
        /// </summary>
        [JsonProperty("start_at")]
        public string StartAt { get; }

        /// <summary>
        /// RFC 3339; follows same timezone info as `Shift`. Precision up to
        /// the minute is respected; seconds are truncated.
        /// </summary>
        [JsonProperty("end_at")]
        public string EndAt { get; }

        /// <summary>
        /// The `BreakType` this `Break` was templated on.
        /// </summary>
        [JsonProperty("break_type_id")]
        public string BreakTypeId { get; }

        /// <summary>
        /// A human-readable name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Format: RFC-3339 P[n]Y[n]M[n]DT[n]H[n]M[n]S. The expected length of
        /// the break.
        /// </summary>
        [JsonProperty("expected_duration")]
        public string ExpectedDuration { get; }

        /// <summary>
        /// Whether this break counts towards time worked for compensation
        /// purposes.
        /// </summary>
        [JsonProperty("is_paid")]
        public bool IsPaid { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(StartAt,
                BreakTypeId,
                Name,
                ExpectedDuration,
                IsPaid)
                .Id(Id)
                .EndAt(EndAt);
            return builder;
        }

        public class Builder
        {
            private string startAt;
            private string breakTypeId;
            private string name;
            private string expectedDuration;
            private bool isPaid;
            private string id;
            private string endAt;

            public Builder(string startAt,
                string breakTypeId,
                string name,
                string expectedDuration,
                bool isPaid)
            {
                this.startAt = startAt;
                this.breakTypeId = breakTypeId;
                this.name = name;
                this.expectedDuration = expectedDuration;
                this.isPaid = isPaid;
            }
            public Builder StartAt(string value)
            {
                startAt = value;
                return this;
            }

            public Builder BreakTypeId(string value)
            {
                breakTypeId = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder ExpectedDuration(string value)
            {
                expectedDuration = value;
                return this;
            }

            public Builder IsPaid(bool value)
            {
                isPaid = value;
                return this;
            }

            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder EndAt(string value)
            {
                endAt = value;
                return this;
            }

            public Break Build()
            {
                return new Break(startAt,
                    breakTypeId,
                    name,
                    expectedDuration,
                    isPaid,
                    id,
                    endAt);
            }
        }
    }
}