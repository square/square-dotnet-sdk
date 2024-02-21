namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// Break.
    /// </summary>
    public class Break
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="Break"/> class.
        /// </summary>
        /// <param name="startAt">start_at.</param>
        /// <param name="breakTypeId">break_type_id.</param>
        /// <param name="name">name.</param>
        /// <param name="expectedDuration">expected_duration.</param>
        /// <param name="isPaid">is_paid.</param>
        /// <param name="id">id.</param>
        /// <param name="endAt">end_at.</param>
        public Break(
            string startAt,
            string breakTypeId,
            string name,
            string expectedDuration,
            bool isPaid,
            string id = null,
            string endAt = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "end_at", false }
            };

            this.Id = id;
            this.StartAt = startAt;
            if (endAt != null)
            {
                shouldSerialize["end_at"] = true;
                this.EndAt = endAt;
            }

            this.BreakTypeId = breakTypeId;
            this.Name = name;
            this.ExpectedDuration = expectedDuration;
            this.IsPaid = isPaid;
        }
        internal Break(Dictionary<string, bool> shouldSerialize,
            string startAt,
            string breakTypeId,
            string name,
            string expectedDuration,
            bool isPaid,
            string id = null,
            string endAt = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            StartAt = startAt;
            EndAt = endAt;
            BreakTypeId = breakTypeId;
            Name = name;
            ExpectedDuration = expectedDuration;
            IsPaid = isPaid;
        }

        /// <summary>
        /// The UUID for this object.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// RFC 3339; follows the same timezone information as `Shift`. Precision up to
        /// the minute is respected; seconds are truncated.
        /// </summary>
        [JsonProperty("start_at")]
        public string StartAt { get; }

        /// <summary>
        /// RFC 3339; follows the same timezone information as `Shift`. Precision up to
        /// the minute is respected; seconds are truncated.
        /// </summary>
        [JsonProperty("end_at")]
        public string EndAt { get; }

        /// <summary>
        /// The `BreakType` that this `Break` was templated on.
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Break : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEndAt()
        {
            return this.shouldSerialize["end_at"];
        }

        /// <inheritdoc/>
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
            return obj is Break other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.StartAt == null && other.StartAt == null) || (this.StartAt?.Equals(other.StartAt) == true)) &&
                ((this.EndAt == null && other.EndAt == null) || (this.EndAt?.Equals(other.EndAt) == true)) &&
                ((this.BreakTypeId == null && other.BreakTypeId == null) || (this.BreakTypeId?.Equals(other.BreakTypeId) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.ExpectedDuration == null && other.ExpectedDuration == null) || (this.ExpectedDuration?.Equals(other.ExpectedDuration) == true)) &&
                this.IsPaid.Equals(other.IsPaid);
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 168552180;
            hashCode = HashCode.Combine(this.Id, this.StartAt, this.EndAt, this.BreakTypeId, this.Name, this.ExpectedDuration, this.IsPaid);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.StartAt = {(this.StartAt == null ? "null" : this.StartAt)}");
            toStringOutput.Add($"this.EndAt = {(this.EndAt == null ? "null" : this.EndAt)}");
            toStringOutput.Add($"this.BreakTypeId = {(this.BreakTypeId == null ? "null" : this.BreakTypeId)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.ExpectedDuration = {(this.ExpectedDuration == null ? "null" : this.ExpectedDuration)}");
            toStringOutput.Add($"this.IsPaid = {this.IsPaid}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.StartAt,
                this.BreakTypeId,
                this.Name,
                this.ExpectedDuration,
                this.IsPaid)
                .Id(this.Id)
                .EndAt(this.EndAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "end_at", false },
            };

            private string startAt;
            private string breakTypeId;
            private string name;
            private string expectedDuration;
            private bool isPaid;
            private string id;
            private string endAt;

            /// <summary>
            /// Initialize Builder for Break.
            /// </summary>
            /// <param name="startAt"> startAt. </param>
            /// <param name="breakTypeId"> breakTypeId. </param>
            /// <param name="name"> name. </param>
            /// <param name="expectedDuration"> expectedDuration. </param>
            /// <param name="isPaid"> isPaid. </param>
            public Builder(
                string startAt,
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

             /// <summary>
             /// StartAt.
             /// </summary>
             /// <param name="startAt"> startAt. </param>
             /// <returns> Builder. </returns>
            public Builder StartAt(string startAt)
            {
                this.startAt = startAt;
                return this;
            }

             /// <summary>
             /// BreakTypeId.
             /// </summary>
             /// <param name="breakTypeId"> breakTypeId. </param>
             /// <returns> Builder. </returns>
            public Builder BreakTypeId(string breakTypeId)
            {
                this.breakTypeId = breakTypeId;
                return this;
            }

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

             /// <summary>
             /// ExpectedDuration.
             /// </summary>
             /// <param name="expectedDuration"> expectedDuration. </param>
             /// <returns> Builder. </returns>
            public Builder ExpectedDuration(string expectedDuration)
            {
                this.expectedDuration = expectedDuration;
                return this;
            }

             /// <summary>
             /// IsPaid.
             /// </summary>
             /// <param name="isPaid"> isPaid. </param>
             /// <returns> Builder. </returns>
            public Builder IsPaid(bool isPaid)
            {
                this.isPaid = isPaid;
                return this;
            }

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// EndAt.
             /// </summary>
             /// <param name="endAt"> endAt. </param>
             /// <returns> Builder. </returns>
            public Builder EndAt(string endAt)
            {
                shouldSerialize["end_at"] = true;
                this.endAt = endAt;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEndAt()
            {
                this.shouldSerialize["end_at"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Break. </returns>
            public Break Build()
            {
                return new Break(shouldSerialize,
                    this.startAt,
                    this.breakTypeId,
                    this.name,
                    this.expectedDuration,
                    this.isPaid,
                    this.id,
                    this.endAt);
            }
        }
    }
}