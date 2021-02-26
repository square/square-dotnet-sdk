
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
    public class Range 
    {
        public Range(string min = null,
            string max = null)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// The lower bound of the number range.
        /// </summary>
        [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
        public string Min { get; }

        /// <summary>
        /// The upper bound of the number range.
        /// </summary>
        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        public string Max { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Range : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Min = {(Min == null ? "null" : Min == string.Empty ? "" : Min)}");
            toStringOutput.Add($"Max = {(Max == null ? "null" : Max == string.Empty ? "" : Max)}");
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

            return obj is Range other &&
                ((Min == null && other.Min == null) || (Min?.Equals(other.Min) == true)) &&
                ((Max == null && other.Max == null) || (Max?.Equals(other.Max) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1130495975;

            if (Min != null)
            {
               hashCode += Min.GetHashCode();
            }

            if (Max != null)
            {
               hashCode += Max.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Min(Min)
                .Max(Max);
            return builder;
        }

        public class Builder
        {
            private string min;
            private string max;



            public Builder Min(string min)
            {
                this.min = min;
                return this;
            }

            public Builder Max(string max)
            {
                this.max = max;
                return this;
            }

            public Range Build()
            {
                return new Range(min,
                    max);
            }
        }
    }
}