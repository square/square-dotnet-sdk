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
    /// CatalogSubscriptionPlan.
    /// </summary>
    public class CatalogSubscriptionPlan
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogSubscriptionPlan"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="phases">phases.</param>
        /// <param name="subscriptionPlanVariations">subscription_plan_variations.</param>
        /// <param name="eligibleItemIds">eligible_item_ids.</param>
        /// <param name="eligibleCategoryIds">eligible_category_ids.</param>
        /// <param name="allItems">all_items.</param>
        public CatalogSubscriptionPlan(
            string name,
            IList<Models.SubscriptionPhase> phases = null,
            IList<Models.CatalogObject> subscriptionPlanVariations = null,
            IList<string> eligibleItemIds = null,
            IList<string> eligibleCategoryIds = null,
            bool? allItems = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "phases", false },
                { "subscription_plan_variations", false },
                { "eligible_item_ids", false },
                { "eligible_category_ids", false },
                { "all_items", false }
            };

            this.Name = name;
            if (phases != null)
            {
                shouldSerialize["phases"] = true;
                this.Phases = phases;
            }

            if (subscriptionPlanVariations != null)
            {
                shouldSerialize["subscription_plan_variations"] = true;
                this.SubscriptionPlanVariations = subscriptionPlanVariations;
            }

            if (eligibleItemIds != null)
            {
                shouldSerialize["eligible_item_ids"] = true;
                this.EligibleItemIds = eligibleItemIds;
            }

            if (eligibleCategoryIds != null)
            {
                shouldSerialize["eligible_category_ids"] = true;
                this.EligibleCategoryIds = eligibleCategoryIds;
            }

            if (allItems != null)
            {
                shouldSerialize["all_items"] = true;
                this.AllItems = allItems;
            }

        }
        internal CatalogSubscriptionPlan(Dictionary<string, bool> shouldSerialize,
            string name,
            IList<Models.SubscriptionPhase> phases = null,
            IList<Models.CatalogObject> subscriptionPlanVariations = null,
            IList<string> eligibleItemIds = null,
            IList<string> eligibleCategoryIds = null,
            bool? allItems = null)
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
            Phases = phases;
            SubscriptionPlanVariations = subscriptionPlanVariations;
            EligibleItemIds = eligibleItemIds;
            EligibleCategoryIds = eligibleCategoryIds;
            AllItems = allItems;
        }

        /// <summary>
        /// The name of the plan.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// A list of SubscriptionPhase containing the [SubscriptionPhase](entity:SubscriptionPhase) for this plan.
        /// This field it required. Not including this field will throw a REQUIRED_FIELD_MISSING error
        /// </summary>
        [JsonProperty("phases")]
        public IList<Models.SubscriptionPhase> Phases { get; }

        /// <summary>
        /// The list of subscription plan variations available for this product
        /// </summary>
        [JsonProperty("subscription_plan_variations")]
        public IList<Models.CatalogObject> SubscriptionPlanVariations { get; }

        /// <summary>
        /// The list of IDs of `CatalogItems` that are eligible for subscription by this SubscriptionPlan's variations.
        /// </summary>
        [JsonProperty("eligible_item_ids")]
        public IList<string> EligibleItemIds { get; }

        /// <summary>
        /// The list of IDs of `CatalogCategory` that are eligible for subscription by this SubscriptionPlan's variations.
        /// </summary>
        [JsonProperty("eligible_category_ids")]
        public IList<string> EligibleCategoryIds { get; }

        /// <summary>
        /// If true, all items in the merchant's catalog are subscribable by this SubscriptionPlan.
        /// </summary>
        [JsonProperty("all_items")]
        public bool? AllItems { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogSubscriptionPlan : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePhases()
        {
            return this.shouldSerialize["phases"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSubscriptionPlanVariations()
        {
            return this.shouldSerialize["subscription_plan_variations"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEligibleItemIds()
        {
            return this.shouldSerialize["eligible_item_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEligibleCategoryIds()
        {
            return this.shouldSerialize["eligible_category_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAllItems()
        {
            return this.shouldSerialize["all_items"];
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
            return obj is CatalogSubscriptionPlan other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Phases == null && other.Phases == null) || (this.Phases?.Equals(other.Phases) == true)) &&
                ((this.SubscriptionPlanVariations == null && other.SubscriptionPlanVariations == null) || (this.SubscriptionPlanVariations?.Equals(other.SubscriptionPlanVariations) == true)) &&
                ((this.EligibleItemIds == null && other.EligibleItemIds == null) || (this.EligibleItemIds?.Equals(other.EligibleItemIds) == true)) &&
                ((this.EligibleCategoryIds == null && other.EligibleCategoryIds == null) || (this.EligibleCategoryIds?.Equals(other.EligibleCategoryIds) == true)) &&
                ((this.AllItems == null && other.AllItems == null) || (this.AllItems?.Equals(other.AllItems) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1680873033;
            hashCode = HashCode.Combine(this.Name, this.Phases, this.SubscriptionPlanVariations, this.EligibleItemIds, this.EligibleCategoryIds, this.AllItems);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.Phases = {(this.Phases == null ? "null" : $"[{string.Join(", ", this.Phases)} ]")}");
            toStringOutput.Add($"this.SubscriptionPlanVariations = {(this.SubscriptionPlanVariations == null ? "null" : $"[{string.Join(", ", this.SubscriptionPlanVariations)} ]")}");
            toStringOutput.Add($"this.EligibleItemIds = {(this.EligibleItemIds == null ? "null" : $"[{string.Join(", ", this.EligibleItemIds)} ]")}");
            toStringOutput.Add($"this.EligibleCategoryIds = {(this.EligibleCategoryIds == null ? "null" : $"[{string.Join(", ", this.EligibleCategoryIds)} ]")}");
            toStringOutput.Add($"this.AllItems = {(this.AllItems == null ? "null" : this.AllItems.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Name)
                .Phases(this.Phases)
                .SubscriptionPlanVariations(this.SubscriptionPlanVariations)
                .EligibleItemIds(this.EligibleItemIds)
                .EligibleCategoryIds(this.EligibleCategoryIds)
                .AllItems(this.AllItems);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "phases", false },
                { "subscription_plan_variations", false },
                { "eligible_item_ids", false },
                { "eligible_category_ids", false },
                { "all_items", false },
            };

            private string name;
            private IList<Models.SubscriptionPhase> phases;
            private IList<Models.CatalogObject> subscriptionPlanVariations;
            private IList<string> eligibleItemIds;
            private IList<string> eligibleCategoryIds;
            private bool? allItems;

            /// <summary>
            /// Initialize Builder for CatalogSubscriptionPlan.
            /// </summary>
            /// <param name="name"> name. </param>
            public Builder(
                string name)
            {
                this.name = name;
            }

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

             /// <summary>
             /// Phases.
             /// </summary>
             /// <param name="phases"> phases. </param>
             /// <returns> Builder. </returns>
            public Builder Phases(IList<Models.SubscriptionPhase> phases)
            {
                shouldSerialize["phases"] = true;
                this.phases = phases;
                return this;
            }

             /// <summary>
             /// SubscriptionPlanVariations.
             /// </summary>
             /// <param name="subscriptionPlanVariations"> subscriptionPlanVariations. </param>
             /// <returns> Builder. </returns>
            public Builder SubscriptionPlanVariations(IList<Models.CatalogObject> subscriptionPlanVariations)
            {
                shouldSerialize["subscription_plan_variations"] = true;
                this.subscriptionPlanVariations = subscriptionPlanVariations;
                return this;
            }

             /// <summary>
             /// EligibleItemIds.
             /// </summary>
             /// <param name="eligibleItemIds"> eligibleItemIds. </param>
             /// <returns> Builder. </returns>
            public Builder EligibleItemIds(IList<string> eligibleItemIds)
            {
                shouldSerialize["eligible_item_ids"] = true;
                this.eligibleItemIds = eligibleItemIds;
                return this;
            }

             /// <summary>
             /// EligibleCategoryIds.
             /// </summary>
             /// <param name="eligibleCategoryIds"> eligibleCategoryIds. </param>
             /// <returns> Builder. </returns>
            public Builder EligibleCategoryIds(IList<string> eligibleCategoryIds)
            {
                shouldSerialize["eligible_category_ids"] = true;
                this.eligibleCategoryIds = eligibleCategoryIds;
                return this;
            }

             /// <summary>
             /// AllItems.
             /// </summary>
             /// <param name="allItems"> allItems. </param>
             /// <returns> Builder. </returns>
            public Builder AllItems(bool? allItems)
            {
                shouldSerialize["all_items"] = true;
                this.allItems = allItems;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPhases()
            {
                this.shouldSerialize["phases"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSubscriptionPlanVariations()
            {
                this.shouldSerialize["subscription_plan_variations"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEligibleItemIds()
            {
                this.shouldSerialize["eligible_item_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEligibleCategoryIds()
            {
                this.shouldSerialize["eligible_category_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAllItems()
            {
                this.shouldSerialize["all_items"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogSubscriptionPlan. </returns>
            public CatalogSubscriptionPlan Build()
            {
                return new CatalogSubscriptionPlan(shouldSerialize,
                    this.name,
                    this.phases,
                    this.subscriptionPlanVariations,
                    this.eligibleItemIds,
                    this.eligibleCategoryIds,
                    this.allItems);
            }
        }
    }
}