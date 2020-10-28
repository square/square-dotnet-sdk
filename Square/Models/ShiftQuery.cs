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
    public class ShiftQuery 
    {
        public ShiftQuery(Models.ShiftFilter filter = null,
            Models.ShiftSort sort = null)
        {
            Filter = filter;
            Sort = sort;
        }

        /// <summary>
        /// Defines a filter used in a search for `Shift` records. `AND` logic is
        /// used by Square's servers to apply each filter property specified.
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ShiftFilter Filter { get; }

        /// <summary>
        /// Sets the sort order of search results.
        /// </summary>
        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ShiftSort Sort { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Filter(Filter)
                .Sort(Sort);
            return builder;
        }

        public class Builder
        {
            private Models.ShiftFilter filter;
            private Models.ShiftSort sort;



            public Builder Filter(Models.ShiftFilter filter)
            {
                this.filter = filter;
                return this;
            }

            public Builder Sort(Models.ShiftSort sort)
            {
                this.sort = sort;
                return this;
            }

            public ShiftQuery Build()
            {
                return new ShiftQuery(filter,
                    sort);
            }
        }
    }
}