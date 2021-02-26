
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
    public class CustomerCreationSourceFilter 
    {
        public CustomerCreationSourceFilter(IList<string> values = null,
            string rule = null)
        {
            Values = values;
            Rule = rule;
        }

        /// <summary>
        /// The list of creation sources used as filtering criteria.
        /// See [CustomerCreationSource](#type-customercreationsource) for possible values
        /// </summary>
        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Values { get; }

        /// <summary>
        /// Indicates whether customers should be included in, or excluded from,
        /// the result set when they match the filtering criteria.
        /// </summary>
        [JsonProperty("rule", NullValueHandling = NullValueHandling.Ignore)]
        public string Rule { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CustomerCreationSourceFilter : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Values = {(Values == null ? "null" : $"[{ string.Join(", ", Values)} ]")}");
            toStringOutput.Add($"Rule = {(Rule == null ? "null" : Rule.ToString())}");
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

            return obj is CustomerCreationSourceFilter other &&
                ((Values == null && other.Values == null) || (Values?.Equals(other.Values) == true)) &&
                ((Rule == null && other.Rule == null) || (Rule?.Equals(other.Rule) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 2051047657;

            if (Values != null)
            {
               hashCode += Values.GetHashCode();
            }

            if (Rule != null)
            {
               hashCode += Rule.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Values(Values)
                .Rule(Rule);
            return builder;
        }

        public class Builder
        {
            private IList<string> values;
            private string rule;



            public Builder Values(IList<string> values)
            {
                this.values = values;
                return this;
            }

            public Builder Rule(string rule)
            {
                this.rule = rule;
                return this;
            }

            public CustomerCreationSourceFilter Build()
            {
                return new CustomerCreationSourceFilter(values,
                    rule);
            }
        }
    }
}