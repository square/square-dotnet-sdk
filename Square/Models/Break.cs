
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
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty("end_at", NullValueHandling = NullValueHandling.Ignore)]
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Break : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"StartAt = {(StartAt == null ? "null" : StartAt == string.Empty ? "" : StartAt)}");
            toStringOutput.Add($"EndAt = {(EndAt == null ? "null" : EndAt == string.Empty ? "" : EndAt)}");
            toStringOutput.Add($"BreakTypeId = {(BreakTypeId == null ? "null" : BreakTypeId == string.Empty ? "" : BreakTypeId)}");
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
            toStringOutput.Add($"ExpectedDuration = {(ExpectedDuration == null ? "null" : ExpectedDuration == string.Empty ? "" : ExpectedDuration)}");
            toStringOutput.Add($"IsPaid = {IsPaid}");
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

            return obj is Break other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((StartAt == null && other.StartAt == null) || (StartAt?.Equals(other.StartAt) == true)) &&
                ((EndAt == null && other.EndAt == null) || (EndAt?.Equals(other.EndAt) == true)) &&
                ((BreakTypeId == null && other.BreakTypeId == null) || (BreakTypeId?.Equals(other.BreakTypeId) == true)) &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true)) &&
                ((ExpectedDuration == null && other.ExpectedDuration == null) || (ExpectedDuration?.Equals(other.ExpectedDuration) == true)) &&
                IsPaid.Equals(other.IsPaid);
        }

        public override int GetHashCode()
        {
            int hashCode = 168552180;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (StartAt != null)
            {
               hashCode += StartAt.GetHashCode();
            }

            if (EndAt != null)
            {
               hashCode += EndAt.GetHashCode();
            }

            if (BreakTypeId != null)
            {
               hashCode += BreakTypeId.GetHashCode();
            }

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            if (ExpectedDuration != null)
            {
               hashCode += ExpectedDuration.GetHashCode();
            }
            hashCode += IsPaid.GetHashCode();

            return hashCode;
        }

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

            public Builder StartAt(string startAt)
            {
                this.startAt = startAt;
                return this;
            }

            public Builder BreakTypeId(string breakTypeId)
            {
                this.breakTypeId = breakTypeId;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder ExpectedDuration(string expectedDuration)
            {
                this.expectedDuration = expectedDuration;
                return this;
            }

            public Builder IsPaid(bool isPaid)
            {
                this.isPaid = isPaid;
                return this;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder EndAt(string endAt)
            {
                this.endAt = endAt;
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