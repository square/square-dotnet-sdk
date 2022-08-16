namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// FloatNumberRange.
    /// </summary>
    public class FloatNumberRange
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FloatNumberRange"/> class.
        /// </summary>
        /// <param name="startAt">start_at.</param>
        /// <param name="endAt">end_at.</param>
        public FloatNumberRange(
            string startAt = null,
            string endAt = null)
        {
            this.StartAt = startAt;
            this.EndAt = endAt;
        }

        /// <summary>
        /// A decimal value indicating where the range starts.
        /// </summary>
        [JsonProperty("start_at", NullValueHandling = NullValueHandling.Ignore)]
        public string StartAt { get; }

        /// <summary>
        /// A decimal value indicating where the range ends.
        /// </summary>
        [JsonProperty("end_at", NullValueHandling = NullValueHandling.Ignore)]
        public string EndAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FloatNumberRange : ({string.Join(", ", toStringOutput)})";
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

            return obj is FloatNumberRange other &&
                ((this.StartAt == null && other.StartAt == null) || (this.StartAt?.Equals(other.StartAt) == true)) &&
                ((this.EndAt == null && other.EndAt == null) || (this.EndAt?.Equals(other.EndAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1801913165;
            hashCode = HashCode.Combine(this.StartAt, this.EndAt);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.StartAt = {(this.StartAt == null ? "null" : this.StartAt == string.Empty ? "" : this.StartAt)}");
            toStringOutput.Add($"this.EndAt = {(this.EndAt == null ? "null" : this.EndAt == string.Empty ? "" : this.EndAt)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .StartAt(this.StartAt)
                .EndAt(this.EndAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string startAt;
            private string endAt;

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
             /// EndAt.
             /// </summary>
             /// <param name="endAt"> endAt. </param>
             /// <returns> Builder. </returns>
            public Builder EndAt(string endAt)
            {
                this.endAt = endAt;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> FloatNumberRange. </returns>
            public FloatNumberRange Build()
            {
                return new FloatNumberRange(
                    this.startAt,
                    this.endAt);
            }
        }
    }
}