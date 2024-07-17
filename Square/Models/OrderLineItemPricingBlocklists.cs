namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// OrderLineItemPricingBlocklists.
    /// </summary>
    public class OrderLineItemPricingBlocklists
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLineItemPricingBlocklists"/> class.
        /// </summary>
        /// <param name="blockedDiscounts">blocked_discounts.</param>
        /// <param name="blockedTaxes">blocked_taxes.</param>
        public OrderLineItemPricingBlocklists(
            IList<Models.OrderLineItemPricingBlocklistsBlockedDiscount> blockedDiscounts = null,
            IList<Models.OrderLineItemPricingBlocklistsBlockedTax> blockedTaxes = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "blocked_discounts", false },
                { "blocked_taxes", false }
            };

            if (blockedDiscounts != null)
            {
                shouldSerialize["blocked_discounts"] = true;
                this.BlockedDiscounts = blockedDiscounts;
            }

            if (blockedTaxes != null)
            {
                shouldSerialize["blocked_taxes"] = true;
                this.BlockedTaxes = blockedTaxes;
            }

        }
        internal OrderLineItemPricingBlocklists(Dictionary<string, bool> shouldSerialize,
            IList<Models.OrderLineItemPricingBlocklistsBlockedDiscount> blockedDiscounts = null,
            IList<Models.OrderLineItemPricingBlocklistsBlockedTax> blockedTaxes = null)
        {
            this.shouldSerialize = shouldSerialize;
            BlockedDiscounts = blockedDiscounts;
            BlockedTaxes = blockedTaxes;
        }

        /// <summary>
        /// A list of discounts blocked from applying to the line item.
        /// Discounts can be blocked by the `discount_uid` (for ad hoc discounts) or
        /// the `discount_catalog_object_id` (for catalog discounts).
        /// </summary>
        [JsonProperty("blocked_discounts")]
        public IList<Models.OrderLineItemPricingBlocklistsBlockedDiscount> BlockedDiscounts { get; }

        /// <summary>
        /// A list of taxes blocked from applying to the line item.
        /// Taxes can be blocked by the `tax_uid` (for ad hoc taxes) or
        /// the `tax_catalog_object_id` (for catalog taxes).
        /// </summary>
        [JsonProperty("blocked_taxes")]
        public IList<Models.OrderLineItemPricingBlocklistsBlockedTax> BlockedTaxes { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderLineItemPricingBlocklists : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBlockedDiscounts()
        {
            return this.shouldSerialize["blocked_discounts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBlockedTaxes()
        {
            return this.shouldSerialize["blocked_taxes"];
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
            return obj is OrderLineItemPricingBlocklists other &&                ((this.BlockedDiscounts == null && other.BlockedDiscounts == null) || (this.BlockedDiscounts?.Equals(other.BlockedDiscounts) == true)) &&
                ((this.BlockedTaxes == null && other.BlockedTaxes == null) || (this.BlockedTaxes?.Equals(other.BlockedTaxes) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 497511120;
            hashCode = HashCode.Combine(this.BlockedDiscounts, this.BlockedTaxes);

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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "blocked_discounts", false },
                { "blocked_taxes", false },
            };

            private IList<Models.OrderLineItemPricingBlocklistsBlockedDiscount> blockedDiscounts;
            private IList<Models.OrderLineItemPricingBlocklistsBlockedTax> blockedTaxes;

             /// <summary>
             /// BlockedDiscounts.
             /// </summary>
             /// <param name="blockedDiscounts"> blockedDiscounts. </param>
             /// <returns> Builder. </returns>
            public Builder BlockedDiscounts(IList<Models.OrderLineItemPricingBlocklistsBlockedDiscount> blockedDiscounts)
            {
                shouldSerialize["blocked_discounts"] = true;
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
                shouldSerialize["blocked_taxes"] = true;
                this.blockedTaxes = blockedTaxes;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBlockedDiscounts()
            {
                this.shouldSerialize["blocked_discounts"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBlockedTaxes()
            {
                this.shouldSerialize["blocked_taxes"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderLineItemPricingBlocklists. </returns>
            public OrderLineItemPricingBlocklists Build()
            {
                return new OrderLineItemPricingBlocklists(shouldSerialize,
                    this.blockedDiscounts,
                    this.blockedTaxes);
            }
        }
    }
}