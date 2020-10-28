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
    public class TerminalRefundQuery 
    {
        public TerminalRefundQuery(Models.TerminalRefundQueryFilter filter = null,
            Models.TerminalRefundQuerySort sort = null)
        {
            Filter = filter;
            Sort = sort;
        }

        /// <summary>
        /// Getter for filter
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalRefundQueryFilter Filter { get; }

        /// <summary>
        /// Getter for sort
        /// </summary>
        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalRefundQuerySort Sort { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Filter(Filter)
                .Sort(Sort);
            return builder;
        }

        public class Builder
        {
            private Models.TerminalRefundQueryFilter filter;
            private Models.TerminalRefundQuerySort sort;



            public Builder Filter(Models.TerminalRefundQueryFilter filter)
            {
                this.filter = filter;
                return this;
            }

            public Builder Sort(Models.TerminalRefundQuerySort sort)
            {
                this.sort = sort;
                return this;
            }

            public TerminalRefundQuery Build()
            {
                return new TerminalRefundQuery(filter,
                    sort);
            }
        }
    }
}