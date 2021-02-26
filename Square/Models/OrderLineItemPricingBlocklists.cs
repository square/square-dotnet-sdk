
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
    public class OrderLineItemPricingBlocklists 
    {
        public OrderLineItemPricingBlocklists(IList<Models.OrderLineItemPricingBlocklistsBlockedDiscount> blockedDiscounts = null,
            IList<Models.OrderLineItemPricingBlocklistsBlockedTax> blockedTaxes = null)
        {
            BlockedDiscounts = blockedDiscounts;
            BlockedTaxes = blockedTaxes;
        }

        /// <summary>
        /// A list of discounts blocked from applying to the line item. 
        /// Discounts can be blocked by the `discount_uid` (for ad-hoc discounts) or 
        /// the `discount_catalog_object_id` (for catalog discounts).
        /// </summary>
        [JsonProperty("blocked_discounts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderLineItemPricingBlocklistsBlockedDiscount> BlockedDiscounts { get; }

        /// <summary>
        /// A list of taxes blocked from applying to the line item. 
        /// Taxes can be blocked by the `tax_uid` (for ad-hoc taxes) or 
        /// the `tax_catalog_object_id` (for catalog taxes).
        /// </summary>
        [JsonProperty("blocked_taxes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderLineItemPricingBlocklistsBlockedTax> BlockedTaxes { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderLineItemPricingBlocklists : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"BlockedDiscounts = {(BlockedDiscounts == null ? "null" : $"[{ string.Join(", ", BlockedDiscounts)} ]")}");
            toStringOutput.Add($"BlockedTaxes = {(BlockedTaxes == null ? "null" : $"[{ string.Join(", ", BlockedTaxes)} ]")}");
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

            return obj is OrderLineItemPricingBlocklists other &&
                ((BlockedDiscounts == null && other.BlockedDiscounts == null) || (BlockedDiscounts?.Equals(other.BlockedDiscounts) == true)) &&
                ((BlockedTaxes == null && other.BlockedTaxes == null) || (BlockedTaxes?.Equals(other.BlockedTaxes) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 497511120;

            if (BlockedDiscounts != null)
            {
               hashCode += BlockedDiscounts.GetHashCode();
            }

            if (BlockedTaxes != null)
            {
               hashCode += BlockedTaxes.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BlockedDiscounts(BlockedDiscounts)
                .BlockedTaxes(BlockedTaxes);
            return builder;
        }

        public class Builder
        {
            private IList<Models.OrderLineItemPricingBlocklistsBlockedDiscount> blockedDiscounts;
            private IList<Models.OrderLineItemPricingBlocklistsBlockedTax> blockedTaxes;



            public Builder BlockedDiscounts(IList<Models.OrderLineItemPricingBlocklistsBlockedDiscount> blockedDiscounts)
            {
                this.blockedDiscounts = blockedDiscounts;
                return this;
            }

            public Builder BlockedTaxes(IList<Models.OrderLineItemPricingBlocklistsBlockedTax> blockedTaxes)
            {
                this.blockedTaxes = blockedTaxes;
                return this;
            }

            public OrderLineItemPricingBlocklists Build()
            {
                return new OrderLineItemPricingBlocklists(blockedDiscounts,
                    blockedTaxes);
            }
        }
    }
}