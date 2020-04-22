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
    public class TerminalCheckoutQuery 
    {
        public TerminalCheckoutQuery(Models.TerminalCheckoutQueryFilter filter = null,
            Models.TerminalCheckoutQuerySort sort = null)
        {
            Filter = filter;
            Sort = sort;
        }

        /// <summary>
        /// Getter for filter
        /// </summary>
        [JsonProperty("filter")]
        public Models.TerminalCheckoutQueryFilter Filter { get; }

        /// <summary>
        /// Getter for sort
        /// </summary>
        [JsonProperty("sort")]
        public Models.TerminalCheckoutQuerySort Sort { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Filter(Filter)
                .Sort(Sort);
            return builder;
        }

        public class Builder
        {
            private Models.TerminalCheckoutQueryFilter filter;
            private Models.TerminalCheckoutQuerySort sort;

            public Builder() { }
            public Builder Filter(Models.TerminalCheckoutQueryFilter value)
            {
                filter = value;
                return this;
            }

            public Builder Sort(Models.TerminalCheckoutQuerySort value)
            {
                sort = value;
                return this;
            }

            public TerminalCheckoutQuery Build()
            {
                return new TerminalCheckoutQuery(filter,
                    sort);
            }
        }
    }
}