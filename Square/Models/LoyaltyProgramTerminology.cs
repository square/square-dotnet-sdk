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
    public class LoyaltyProgramTerminology 
    {
        public LoyaltyProgramTerminology(string one,
            string other)
        {
            One = one;
            Other = other;
        }

        /// <summary>
        /// A singular unit for a point (for example, 1 point is called 1 star).
        /// </summary>
        [JsonProperty("one")]
        public string One { get; }

        /// <summary>
        /// A plural unit for point (for example, 10 points is called 10 stars).
        /// </summary>
        [JsonProperty("other")]
        public string Other { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(One,
                Other);
            return builder;
        }

        public class Builder
        {
            private string one;
            private string other;

            public Builder(string one,
                string other)
            {
                this.one = one;
                this.other = other;
            }
            public Builder One(string value)
            {
                one = value;
                return this;
            }

            public Builder Other(string value)
            {
                other = value;
                return this;
            }

            public LoyaltyProgramTerminology Build()
            {
                return new LoyaltyProgramTerminology(one,
                    other);
            }
        }
    }
}