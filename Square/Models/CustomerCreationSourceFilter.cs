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
        [JsonProperty("values")]
        public IList<string> Values { get; }

        /// <summary>
        /// Indicates whether customers should be included in, or excluded from,
        /// the result set when they match the filtering criteria.
        /// </summary>
        [JsonProperty("rule")]
        public string Rule { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Values(Values)
                .Rule(Rule);
            return builder;
        }

        public class Builder
        {
            private IList<string> values = new List<string>();
            private string rule;

            public Builder() { }
            public Builder Values(IList<string> value)
            {
                values = value;
                return this;
            }

            public Builder Rule(string value)
            {
                rule = value;
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