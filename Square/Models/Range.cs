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
    /// Range.
    /// </summary>
    public class Range
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Range"/> class.
        /// </summary>
        /// <param name="min">min.</param>
        /// <param name="max">max.</param>
        public Range(
            string min = null,
            string max = null)
        {
            this.Min = min;
            this.Max = max;
        }

        /// <summary>
        /// The lower bound of the number range. At least one of `min` or `max` must be specified.
        /// If unspecified, the results will have no minimum value.
        /// </summary>
        [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
        public string Min { get; }

        /// <summary>
        /// The upper bound of the number range. At least one of `min` or `max` must be specified.
        /// If unspecified, the results will have no maximum value.
        /// </summary>
        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        public string Max { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Range : ({string.Join(", ", toStringOutput)})";
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

            return obj is Range other &&
                ((this.Min == null && other.Min == null) || (this.Min?.Equals(other.Min) == true)) &&
                ((this.Max == null && other.Max == null) || (this.Max?.Equals(other.Max) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1130495975;
            hashCode = HashCode.Combine(this.Min, this.Max);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Min = {(this.Min == null ? "null" : this.Min == string.Empty ? "" : this.Min)}");
            toStringOutput.Add($"this.Max = {(this.Max == null ? "null" : this.Max == string.Empty ? "" : this.Max)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Min(this.Min)
                .Max(this.Max);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string min;
            private string max;

             /// <summary>
             /// Min.
             /// </summary>
             /// <param name="min"> min. </param>
             /// <returns> Builder. </returns>
            public Builder Min(string min)
            {
                this.min = min;
                return this;
            }

             /// <summary>
             /// Max.
             /// </summary>
             /// <param name="max"> max. </param>
             /// <returns> Builder. </returns>
            public Builder Max(string max)
            {
                this.max = max;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Range. </returns>
            public Range Build()
            {
                return new Range(
                    this.min,
                    this.max);
            }
        }
    }
}