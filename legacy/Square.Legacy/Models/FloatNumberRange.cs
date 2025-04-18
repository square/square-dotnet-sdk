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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// FloatNumberRange.
    /// </summary>
    public class FloatNumberRange
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatNumberRange"/> class.
        /// </summary>
        /// <param name="startAt">start_at.</param>
        /// <param name="endAt">end_at.</param>
        public FloatNumberRange(string startAt = null, string endAt = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "start_at", false },
                { "end_at", false },
            };

            if (startAt != null)
            {
                shouldSerialize["start_at"] = true;
                this.StartAt = startAt;
            }

            if (endAt != null)
            {
                shouldSerialize["end_at"] = true;
                this.EndAt = endAt;
            }
        }

        internal FloatNumberRange(
            Dictionary<string, bool> shouldSerialize,
            string startAt = null,
            string endAt = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            StartAt = startAt;
            EndAt = endAt;
        }

        /// <summary>
        /// A decimal value indicating where the range starts.
        /// </summary>
        [JsonProperty("start_at")]
        public string StartAt { get; }

        /// <summary>
        /// A decimal value indicating where the range ends.
        /// </summary>
        [JsonProperty("end_at")]
        public string EndAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"FloatNumberRange : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStartAt()
        {
            return this.shouldSerialize["start_at"];
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
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is FloatNumberRange other
                && (
                    this.StartAt == null && other.StartAt == null
                    || this.StartAt?.Equals(other.StartAt) == true
                )
                && (
                    this.EndAt == null && other.EndAt == null
                    || this.EndAt?.Equals(other.EndAt) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1801913165;
            hashCode = HashCode.Combine(hashCode, this.StartAt, this.EndAt);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.StartAt = {this.StartAt ?? "null"}");
            toStringOutput.Add($"this.EndAt = {this.EndAt ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().StartAt(this.StartAt).EndAt(this.EndAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "start_at", false },
                { "end_at", false },
            };

            private string startAt;
            private string endAt;

            /// <summary>
            /// StartAt.
            /// </summary>
            /// <param name="startAt"> startAt. </param>
            /// <returns> Builder. </returns>
            public Builder StartAt(string startAt)
            {
                shouldSerialize["start_at"] = true;
                this.startAt = startAt;
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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetStartAt()
            {
                this.shouldSerialize["start_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetEndAt()
            {
                this.shouldSerialize["end_at"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> FloatNumberRange. </returns>
            public FloatNumberRange Build()
            {
                return new FloatNumberRange(shouldSerialize, this.startAt, this.endAt);
            }
        }
    }
}
