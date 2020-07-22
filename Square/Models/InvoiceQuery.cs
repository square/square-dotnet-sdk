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
    public class InvoiceQuery 
    {
        public InvoiceQuery(Models.InvoiceFilter filter,
            Models.InvoiceSort sort = null)
        {
            Filter = filter;
            Sort = sort;
        }

        /// <summary>
        /// Describes query filters to apply.
        /// </summary>
        [JsonProperty("filter")]
        public Models.InvoiceFilter Filter { get; }

        /// <summary>
        /// Identifies the  sort field and sort order.
        /// </summary>
        [JsonProperty("sort")]
        public Models.InvoiceSort Sort { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Filter)
                .Sort(Sort);
            return builder;
        }

        public class Builder
        {
            private Models.InvoiceFilter filter;
            private Models.InvoiceSort sort;

            public Builder(Models.InvoiceFilter filter)
            {
                this.filter = filter;
            }
            public Builder Filter(Models.InvoiceFilter value)
            {
                filter = value;
                return this;
            }

            public Builder Sort(Models.InvoiceSort value)
            {
                sort = value;
                return this;
            }

            public InvoiceQuery Build()
            {
                return new InvoiceQuery(filter,
                    sort);
            }
        }
    }
}