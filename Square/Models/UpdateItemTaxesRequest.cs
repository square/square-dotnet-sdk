
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
    public class UpdateItemTaxesRequest 
    {
        public UpdateItemTaxesRequest(IList<string> itemIds,
            IList<string> taxesToEnable = null,
            IList<string> taxesToDisable = null)
        {
            ItemIds = itemIds;
            TaxesToEnable = taxesToEnable;
            TaxesToDisable = taxesToDisable;
        }

        /// <summary>
        /// IDs for the CatalogItems associated with the CatalogTax objects being updated.
        /// </summary>
        [JsonProperty("item_ids")]
        public IList<string> ItemIds { get; }

        /// <summary>
        /// IDs of the CatalogTax objects to enable.
        /// </summary>
        [JsonProperty("taxes_to_enable", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> TaxesToEnable { get; }

        /// <summary>
        /// IDs of the CatalogTax objects to disable.
        /// </summary>
        [JsonProperty("taxes_to_disable", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> TaxesToDisable { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateItemTaxesRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ItemIds = {(ItemIds == null ? "null" : $"[{ string.Join(", ", ItemIds)} ]")}");
            toStringOutput.Add($"TaxesToEnable = {(TaxesToEnable == null ? "null" : $"[{ string.Join(", ", TaxesToEnable)} ]")}");
            toStringOutput.Add($"TaxesToDisable = {(TaxesToDisable == null ? "null" : $"[{ string.Join(", ", TaxesToDisable)} ]")}");
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

            return obj is UpdateItemTaxesRequest other &&
                ((ItemIds == null && other.ItemIds == null) || (ItemIds?.Equals(other.ItemIds) == true)) &&
                ((TaxesToEnable == null && other.TaxesToEnable == null) || (TaxesToEnable?.Equals(other.TaxesToEnable) == true)) &&
                ((TaxesToDisable == null && other.TaxesToDisable == null) || (TaxesToDisable?.Equals(other.TaxesToDisable) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 651000777;

            if (ItemIds != null)
            {
               hashCode += ItemIds.GetHashCode();
            }

            if (TaxesToEnable != null)
            {
               hashCode += TaxesToEnable.GetHashCode();
            }

            if (TaxesToDisable != null)
            {
               hashCode += TaxesToDisable.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(ItemIds)
                .TaxesToEnable(TaxesToEnable)
                .TaxesToDisable(TaxesToDisable);
            return builder;
        }

        public class Builder
        {
            private IList<string> itemIds;
            private IList<string> taxesToEnable;
            private IList<string> taxesToDisable;

            public Builder(IList<string> itemIds)
            {
                this.itemIds = itemIds;
            }

            public Builder ItemIds(IList<string> itemIds)
            {
                this.itemIds = itemIds;
                return this;
            }

            public Builder TaxesToEnable(IList<string> taxesToEnable)
            {
                this.taxesToEnable = taxesToEnable;
                return this;
            }

            public Builder TaxesToDisable(IList<string> taxesToDisable)
            {
                this.taxesToDisable = taxesToDisable;
                return this;
            }

            public UpdateItemTaxesRequest Build()
            {
                return new UpdateItemTaxesRequest(itemIds,
                    taxesToEnable,
                    taxesToDisable);
            }
        }
    }
}