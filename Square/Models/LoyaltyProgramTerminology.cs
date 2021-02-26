
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyProgramTerminology : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"One = {(One == null ? "null" : One == string.Empty ? "" : One)}");
            toStringOutput.Add($"Other = {(Other == null ? "null" : Other == string.Empty ? "" : Other)}");
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

            return obj is LoyaltyProgramTerminology other &&
                ((One == null && other.One == null) || (One?.Equals(other.One) == true)) &&
                ((Other == null && other.Other == null) || (Other?.Equals(other.Other) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 951751095;

            if (One != null)
            {
               hashCode += One.GetHashCode();
            }

            if (Other != null)
            {
               hashCode += Other.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder One(string one)
            {
                this.one = one;
                return this;
            }

            public Builder Other(string other)
            {
                this.other = other;
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