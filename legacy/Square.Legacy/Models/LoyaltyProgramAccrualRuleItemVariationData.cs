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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// LoyaltyProgramAccrualRuleItemVariationData.
    /// </summary>
    public class LoyaltyProgramAccrualRuleItemVariationData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyProgramAccrualRuleItemVariationData"/> class.
        /// </summary>
        /// <param name="itemVariationId">item_variation_id.</param>
        public LoyaltyProgramAccrualRuleItemVariationData(string itemVariationId)
        {
            this.ItemVariationId = itemVariationId;
        }

        /// <summary>
        /// The ID of the `ITEM_VARIATION` [catalog object](entity:CatalogObject) that buyers can purchase to earn
        /// points.
        /// </summary>
        [JsonProperty("item_variation_id")]
        public string ItemVariationId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"LoyaltyProgramAccrualRuleItemVariationData : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is LoyaltyProgramAccrualRuleItemVariationData other
                && (
                    this.ItemVariationId == null && other.ItemVariationId == null
                    || this.ItemVariationId?.Equals(other.ItemVariationId) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1885852735;
            hashCode = HashCode.Combine(hashCode, this.ItemVariationId);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ItemVariationId = {this.ItemVariationId ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.ItemVariationId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string itemVariationId;

            /// <summary>
            /// Initialize Builder for LoyaltyProgramAccrualRuleItemVariationData.
            /// </summary>
            /// <param name="itemVariationId"> itemVariationId. </param>
            public Builder(string itemVariationId)
            {
                this.itemVariationId = itemVariationId;
            }

            /// <summary>
            /// ItemVariationId.
            /// </summary>
            /// <param name="itemVariationId"> itemVariationId. </param>
            /// <returns> Builder. </returns>
            public Builder ItemVariationId(string itemVariationId)
            {
                this.itemVariationId = itemVariationId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyProgramAccrualRuleItemVariationData. </returns>
            public LoyaltyProgramAccrualRuleItemVariationData Build()
            {
                return new LoyaltyProgramAccrualRuleItemVariationData(this.itemVariationId);
            }
        }
    }
}
