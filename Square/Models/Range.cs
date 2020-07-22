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
        [JsonProperty("min")]
        public string Min { get; }

        /// <summary>
        /// The upper bound of the number range.
        /// </summary>
        [JsonProperty("max")]
        public string Max { get; }

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

            public Builder() { }
            public Builder Min(string value)
            {
                min = value;
                return this;
            }

            public Builder Max(string value)
            {
                max = value;
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