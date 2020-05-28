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
    public class CustomerTextFilter 
    {
        public CustomerTextFilter(string exact = null,
            string fuzzy = null)
        {
            Exact = exact;
            Fuzzy = fuzzy;
        }

        /// <summary>
        /// Use the exact filter to select customers whose attributes match exactly the specified query.
        /// </summary>
        [JsonProperty("exact")]
        public string Exact { get; }

        /// <summary>
        /// Use the fuzzy filter to select customers whose attributes match the specified query 
        /// in a fuzzy manner. When the fuzzy option is used, search queries are tokenized, and then 
        /// each query token must be matched somewhere in the searched attribute. For single token queries, 
        /// this is effectively the same behavior as a partial match operation.
        /// </summary>
        [JsonProperty("fuzzy")]
        public string Fuzzy { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Exact(Exact)
                .Fuzzy(Fuzzy);
            return builder;
        }

        public class Builder
        {
            private string exact;
            private string fuzzy;

            public Builder() { }
            public Builder Exact(string value)
            {
                exact = value;
                return this;
            }

            public Builder Fuzzy(string value)
            {
                fuzzy = value;
                return this;
            }

            public CustomerTextFilter Build()
            {
                return new CustomerTextFilter(exact,
                    fuzzy);
            }
        }
    }
}