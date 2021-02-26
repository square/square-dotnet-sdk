
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQueryItemsForTax : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"TaxIds = {(TaxIds == null ? "null" : $"[{ string.Join(", ", TaxIds)} ]")}");
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

            return obj is CatalogQueryItemsForTax other &&
                ((TaxIds == null && other.TaxIds == null) || (TaxIds?.Equals(other.TaxIds) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 507867183;

            if (TaxIds != null)
            {
               hashCode += TaxIds.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder TaxIds(IList<string> taxIds)
            {
                this.taxIds = taxIds;
                return this;
            }

            public CatalogQueryItemsForTax Build()
            {
                return new CatalogQueryItemsForTax(taxIds);
            }
        }
    }
}