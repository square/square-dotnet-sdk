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
    /// Range.
    /// </summary>
    public class Range
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="Range"/> class.
        /// </summary>
        /// <param name="min">min.</param>
        /// <param name="max">max.</param>
        public Range(string min = null, string max = null)
        {
            shouldSerialize = new Dictionary<string, bool> { { "min", false }, { "max", false } };

            if (min != null)
            {
                shouldSerialize["min"] = true;
                this.Min = min;
            }

            if (max != null)
            {
                shouldSerialize["max"] = true;
                this.Max = max;
            }
        }

        internal Range(
            Dictionary<string, bool> shouldSerialize,
            string min = null,
            string max = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Min = min;
            Max = max;
        }

        /// <summary>
        /// The lower bound of the number range. At least one of `min` or `max` must be specified.
        /// If unspecified, the results will have no minimum value.
        /// </summary>
        [JsonProperty("min")]
        public string Min { get; }

        /// <summary>
        /// The upper bound of the number range. At least one of `min` or `max` must be specified.
        /// If unspecified, the results will have no maximum value.
        /// </summary>
        [JsonProperty("max")]
        public string Max { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"Range : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMin()
        {
            return this.shouldSerialize["min"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMax()
        {
            return this.shouldSerialize["max"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is Range other
                && (this.Min == null && other.Min == null || this.Min?.Equals(other.Min) == true)
                && (this.Max == null && other.Max == null || this.Max?.Equals(other.Max) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1130495975;
            hashCode = HashCode.Combine(hashCode, this.Min, this.Max);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Min = {this.Min ?? "null"}");
            toStringOutput.Add($"this.Max = {this.Max ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Min(this.Min).Max(this.Max);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "min", false },
                { "max", false },
            };

            private string min;
            private string max;

            /// <summary>
            /// Min.
            /// </summary>
            /// <param name="min"> min. </param>
            /// <returns> Builder. </returns>
            public Builder Min(string min)
            {
                shouldSerialize["min"] = true;
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
                shouldSerialize["max"] = true;
                this.max = max;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetMin()
            {
                this.shouldSerialize["min"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetMax()
            {
                this.shouldSerialize["max"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Range. </returns>
            public Range Build()
            {
                return new Range(shouldSerialize, this.min, this.max);
            }
        }
    }
}
