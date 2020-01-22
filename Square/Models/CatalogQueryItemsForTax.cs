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
    public class CatalogQueryItemsForTax 
    {
        public CatalogQueryItemsForTax(IList<string> taxIds)
        {
            TaxIds = taxIds;
        }

        /// <summary>
        /// A set of `CatalogTax` IDs to be used to find associated `CatalogItem`s.
        /// </summary>
        [JsonProperty("tax_ids")]
        public IList<string> TaxIds { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(TaxIds);
            return builder;
        }

        public class Builder
        {
            private IList<string> taxIds;

            public Builder(IList<string> taxIds)
            {
                this.taxIds = taxIds;
            }
            public Builder TaxIds(IList<string> value)
            {
                taxIds = value;
                return this;
            }

            public CatalogQueryItemsForTax Build()
            {
                return new CatalogQueryItemsForTax(taxIds);
            }
        }
    }
}