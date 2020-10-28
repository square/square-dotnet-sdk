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