namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// OrderLineItemPricingBlocklists.
    /// </summary>
    public class OrderLineItemPricingBlocklists
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLineItemPricingBlocklists"/> class.
        /// </summary>
        /// <param name="blockedDiscounts">blocked_discounts.</param>
        /// <param name="blockedTaxes">blocked_taxes.</param>
        public OrderLineItemPricingBlocklists(
            IList<Models.OrderLineItemPricingBlocklistsBlockedDiscount> blockedDiscounts = null,
            IList<Models.OrderLineItemPricingBlocklistsBlockedTax> blockedTaxes = null)
        {
            this.BlockedDiscounts = blockedDiscounts;
            this.BlockedTaxes = blockedTaxes;
        }

        /// <summary>
        /// A list of discounts blocked from applying to the line item.
        /// Discounts can be blocked by the `discount_uid` (for ad hoc discounts) or
        /// the `discount_catalog_object_id` (for catalog discounts).
        /// </summary>
        [JsonProperty("blocked_discounts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderLineItemPricingBlocklistsBlockedDiscount> BlockedDiscounts { get; }

        /// <summary>
        /// A list of taxes blocked from applying to the line item.
        /// Taxes can be blocked by the `tax_uid` (for ad hoc taxes) or
        /// the `tax_catalog_object_id` (for catalog taxes).
        /// </summary>
        [JsonProperty("blocked_taxes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderLineItemPricingBlocklistsBlockedTax> BlockedTaxes { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderLineItemPricingBlocklists : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
                ((this.BlockedDiscounts == null && other.BlockedDiscounts == null) || (this.BlockedDiscounts?.Equals(other.BlockedDiscounts) == true)) &&
                ((this.BlockedTaxes == null && other.BlockedTaxes == null) || (this.BlockedTaxes?.Equals(other.BlockedTaxes) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 497511120;

            if (this.BlockedDiscounts != null)
            {
               hashCode += this.BlockedDiscounts.GetHashCode();
            }

            if (this.BlockedTaxes != null)
            {
               hashCode += this.BlockedTaxes.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BlockedDiscounts = {(this.BlockedDiscounts == null ? "null" : $"[{string.Join(", ", this.BlockedDiscounts)} ]")}");
            toStringOutput.Add($"this.BlockedTaxes = {(this.BlockedTaxes == null ? "null" : $"[{string.Join(", ", this.BlockedTaxes)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BlockedDiscounts(this.BlockedDiscounts)
                .BlockedTaxes(this.BlockedTaxes);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.OrderLineItemPricingBlocklistsBlockedDiscount> blockedDiscounts;
            private IList<Models.OrderLineItemPricingBlocklistsBlockedTax> blockedTaxes;

             /// <summary>
             /// BlockedDiscounts.
             /// </summary>
             /// <param name="blockedDiscounts"> blockedDiscounts. </param>
             /// <returns> Builder. </returns>
            public Builder BlockedDiscounts(IList<Models.OrderLineItemPricingBlocklistsBlockedDiscount> blockedDiscounts)
            {
                this.blockedDiscounts = blockedDiscounts;
                return this;
            }

             /// <summary>
             /// BlockedTaxes.
             /// </summary>
             /// <param name="blockedTaxes"> blockedTaxes. </param>
             /// <returns> Builder. </returns>
            public Builder BlockedTaxes(IList<Models.OrderLineItemPricingBlocklistsBlockedTax> blockedTaxes)
            {
                this.blockedTaxes = blockedTaxes;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderLineItemPricingBlocklists. </returns>
            public OrderLineItemPricingBlocklists Build()
            {
                return new OrderLineItemPricingBlocklists(
                    this.blockedDiscounts,
                    this.blockedTaxes);
            }
        }
    }
}