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
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalCheckoutQueryFilter Filter { get; }

        /// <summary>
        /// Getter for sort
        /// </summary>
        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
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



            public Builder Filter(Models.TerminalCheckoutQueryFilter filter)
            {
                this.filter = filter;
                return this;
            }

            public Builder Sort(Models.TerminalCheckoutQuerySort sort)
            {
                this.sort = sort;
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