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
    /// LoyaltyPromotion.
    /// </summary>
    public class LoyaltyPromotion
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyPromotion"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="incentive">incentive.</param>
        /// <param name="availableTime">available_time.</param>
        /// <param name="id">id.</param>
        /// <param name="triggerLimit">trigger_limit.</param>
        /// <param name="status">status.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="canceledAt">canceled_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="loyaltyProgramId">loyalty_program_id.</param>
        /// <param name="minimumSpendAmountMoney">minimum_spend_amount_money.</param>
        /// <param name="qualifyingItemVariationIds">qualifying_item_variation_ids.</param>
        /// <param name="qualifyingCategoryIds">qualifying_category_ids.</param>
        public LoyaltyPromotion(
            string name,
            Models.LoyaltyPromotionIncentive incentive,
            Models.LoyaltyPromotionAvailableTimeData availableTime,
            string id = null,
            Models.LoyaltyPromotionTriggerLimit triggerLimit = null,
            string status = null,
            string createdAt = null,
            string canceledAt = null,
            string updatedAt = null,
            string loyaltyProgramId = null,
            Models.Money minimumSpendAmountMoney = null,
            IList<string> qualifyingItemVariationIds = null,
            IList<string> qualifyingCategoryIds = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "qualifying_item_variation_ids", false },
                { "qualifying_category_ids", false }
            };

            this.Id = id;
            this.Name = name;
            this.Incentive = incentive;
            this.AvailableTime = availableTime;
            this.TriggerLimit = triggerLimit;
            this.Status = status;
            this.CreatedAt = createdAt;
            this.CanceledAt = canceledAt;
            this.UpdatedAt = updatedAt;
            this.LoyaltyProgramId = loyaltyProgramId;
            this.MinimumSpendAmountMoney = minimumSpendAmountMoney;
            if (qualifyingItemVariationIds != null)
            {
                shouldSerialize["qualifying_item_variation_ids"] = true;
                this.QualifyingItemVariationIds = qualifyingItemVariationIds;
            }

            if (qualifyingCategoryIds != null)
            {
                shouldSerialize["qualifying_category_ids"] = true;
                this.QualifyingCategoryIds = qualifyingCategoryIds;
            }

        }
        internal LoyaltyPromotion(Dictionary<string, bool> shouldSerialize,
            string name,
            Models.LoyaltyPromotionIncentive incentive,
            Models.LoyaltyPromotionAvailableTimeData availableTime,
            string id = null,
            Models.LoyaltyPromotionTriggerLimit triggerLimit = null,
            string status = null,
            string createdAt = null,
            string canceledAt = null,
            string updatedAt = null,
            string loyaltyProgramId = null,
            Models.Money minimumSpendAmountMoney = null,
            IList<string> qualifyingItemVariationIds = null,
            IList<string> qualifyingCategoryIds = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            Name = name;
            Incentive = incentive;
            AvailableTime = availableTime;
            TriggerLimit = triggerLimit;
            Status = status;
            CreatedAt = createdAt;
            CanceledAt = canceledAt;
            UpdatedAt = updatedAt;
            LoyaltyProgramId = loyaltyProgramId;
            MinimumSpendAmountMoney = minimumSpendAmountMoney;
            QualifyingItemVariationIds = qualifyingItemVariationIds;
            QualifyingCategoryIds = qualifyingCategoryIds;
        }

        /// <summary>
        /// The Square-assigned ID of the promotion.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The name of the promotion.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Represents how points for a [loyalty promotion]($m/LoyaltyPromotion) are calculated,
        /// either by multiplying the points earned from the base program or by adding a specified number
        /// of points to the points earned from the base program.
        /// </summary>
        [JsonProperty("incentive")]
        public Models.LoyaltyPromotionIncentive Incentive { get; }

        /// <summary>
        /// Represents scheduling information that determines when purchases can qualify to earn points
        /// from a [loyalty promotion]($m/LoyaltyPromotion).
        /// </summary>
        [JsonProperty("available_time")]
        public Models.LoyaltyPromotionAvailableTimeData AvailableTime { get; }

        /// <summary>
        /// Represents the number of times a buyer can earn points during a [loyalty promotion]($m/LoyaltyPromotion).
        /// If this field is not set, buyers can trigger the promotion an unlimited number of times to earn points during
        /// the time that the promotion is available.
        /// A purchase that is disqualified from earning points because of this limit might qualify for another active promotion.
        /// </summary>
        [JsonProperty("trigger_limit", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyPromotionTriggerLimit TriggerLimit { get; }

        /// <summary>
        /// Indicates the status of a [loyalty promotion]($m/LoyaltyPromotion).
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// The timestamp of when the promotion was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp of when the promotion was canceled, in RFC 3339 format.
        /// </summary>
        [JsonProperty("canceled_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CanceledAt { get; }

        /// <summary>
        /// The timestamp when the promotion was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The ID of the [loyalty program](entity:LoyaltyProgram) associated with the promotion.
        /// </summary>
        [JsonProperty("loyalty_program_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LoyaltyProgramId { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("minimum_spend_amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money MinimumSpendAmountMoney { get; }

        /// <summary>
        /// The IDs of any qualifying `ITEM_VARIATION` [catalog objects](entity:CatalogObject). If specified,
        /// the purchase must include at least one of these items to qualify for the promotion.
        /// This option is valid only if the base loyalty program uses a `VISIT` or `SPEND` accrual rule.
        /// With `SPEND` accrual rules, make sure that qualifying promotional items are not excluded.
        /// You can specify `qualifying_item_variation_ids` or `qualifying_category_ids` for a given promotion, but not both.
        /// </summary>
        [JsonProperty("qualifying_item_variation_ids")]
        public IList<string> QualifyingItemVariationIds { get; }

        /// <summary>
        /// The IDs of any qualifying `CATEGORY` [catalog objects](entity:CatalogObject). If specified,
        /// the purchase must include at least one item from one of these categories to qualify for the promotion.
        /// This option is valid only if the base loyalty program uses a `VISIT` or `SPEND` accrual rule.
        /// With `SPEND` accrual rules, make sure that qualifying promotional items are not excluded.
        /// You can specify `qualifying_category_ids` or `qualifying_item_variation_ids` for a promotion, but not both.
        /// </summary>
        [JsonProperty("qualifying_category_ids")]
        public IList<string> QualifyingCategoryIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyPromotion : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeQualifyingItemVariationIds()
        {
            return this.shouldSerialize["qualifying_item_variation_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeQualifyingCategoryIds()
        {
            return this.shouldSerialize["qualifying_category_ids"];
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
            return obj is LoyaltyPromotion other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Incentive == null && other.Incentive == null) || (this.Incentive?.Equals(other.Incentive) == true)) &&
                ((this.AvailableTime == null && other.AvailableTime == null) || (this.AvailableTime?.Equals(other.AvailableTime) == true)) &&
                ((this.TriggerLimit == null && other.TriggerLimit == null) || (this.TriggerLimit?.Equals(other.TriggerLimit) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.CanceledAt == null && other.CanceledAt == null) || (this.CanceledAt?.Equals(other.CanceledAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.LoyaltyProgramId == null && other.LoyaltyProgramId == null) || (this.LoyaltyProgramId?.Equals(other.LoyaltyProgramId) == true)) &&
                ((this.MinimumSpendAmountMoney == null && other.MinimumSpendAmountMoney == null) || (this.MinimumSpendAmountMoney?.Equals(other.MinimumSpendAmountMoney) == true)) &&
                ((this.QualifyingItemVariationIds == null && other.QualifyingItemVariationIds == null) || (this.QualifyingItemVariationIds?.Equals(other.QualifyingItemVariationIds) == true)) &&
                ((this.QualifyingCategoryIds == null && other.QualifyingCategoryIds == null) || (this.QualifyingCategoryIds?.Equals(other.QualifyingCategoryIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -2086043308;
            hashCode = HashCode.Combine(this.Id, this.Name, this.Incentive, this.AvailableTime, this.TriggerLimit, this.Status, this.CreatedAt);

            hashCode = HashCode.Combine(hashCode, this.CanceledAt, this.UpdatedAt, this.LoyaltyProgramId, this.MinimumSpendAmountMoney, this.QualifyingItemVariationIds, this.QualifyingCategoryIds);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.Incentive = {(this.Incentive == null ? "null" : this.Incentive.ToString())}");
            toStringOutput.Add($"this.AvailableTime = {(this.AvailableTime == null ? "null" : this.AvailableTime.ToString())}");
            toStringOutput.Add($"this.TriggerLimit = {(this.TriggerLimit == null ? "null" : this.TriggerLimit.ToString())}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt)}");
            toStringOutput.Add($"this.CanceledAt = {(this.CanceledAt == null ? "null" : this.CanceledAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt)}");
            toStringOutput.Add($"this.LoyaltyProgramId = {(this.LoyaltyProgramId == null ? "null" : this.LoyaltyProgramId)}");
            toStringOutput.Add($"this.MinimumSpendAmountMoney = {(this.MinimumSpendAmountMoney == null ? "null" : this.MinimumSpendAmountMoney.ToString())}");
            toStringOutput.Add($"this.QualifyingItemVariationIds = {(this.QualifyingItemVariationIds == null ? "null" : $"[{string.Join(", ", this.QualifyingItemVariationIds)} ]")}");
            toStringOutput.Add($"this.QualifyingCategoryIds = {(this.QualifyingCategoryIds == null ? "null" : $"[{string.Join(", ", this.QualifyingCategoryIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Name,
                this.Incentive,
                this.AvailableTime)
                .Id(this.Id)
                .TriggerLimit(this.TriggerLimit)
                .Status(this.Status)
                .CreatedAt(this.CreatedAt)
                .CanceledAt(this.CanceledAt)
                .UpdatedAt(this.UpdatedAt)
                .LoyaltyProgramId(this.LoyaltyProgramId)
                .MinimumSpendAmountMoney(this.MinimumSpendAmountMoney)
                .QualifyingItemVariationIds(this.QualifyingItemVariationIds)
                .QualifyingCategoryIds(this.QualifyingCategoryIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "qualifying_item_variation_ids", false },
                { "qualifying_category_ids", false },
            };

            private string name;
            private Models.LoyaltyPromotionIncentive incentive;
            private Models.LoyaltyPromotionAvailableTimeData availableTime;
            private string id;
            private Models.LoyaltyPromotionTriggerLimit triggerLimit;
            private string status;
            private string createdAt;
            private string canceledAt;
            private string updatedAt;
            private string loyaltyProgramId;
            private Models.Money minimumSpendAmountMoney;
            private IList<string> qualifyingItemVariationIds;
            private IList<string> qualifyingCategoryIds;

            /// <summary>
            /// Initialize Builder for LoyaltyPromotion.
            /// </summary>
            /// <param name="name"> name. </param>
            /// <param name="incentive"> incentive. </param>
            /// <param name="availableTime"> availableTime. </param>
            public Builder(
                string name,
                Models.LoyaltyPromotionIncentive incentive,
                Models.LoyaltyPromotionAvailableTimeData availableTime)
            {
                this.name = name;
                this.incentive = incentive;
                this.availableTime = availableTime;
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
             /// Incentive.
             /// </summary>
             /// <param name="incentive"> incentive. </param>
             /// <returns> Builder. </returns>
            public Builder Incentive(Models.LoyaltyPromotionIncentive incentive)
            {
                this.incentive = incentive;
                return this;
            }

             /// <summary>
             /// AvailableTime.
             /// </summary>
             /// <param name="availableTime"> availableTime. </param>
             /// <returns> Builder. </returns>
            public Builder AvailableTime(Models.LoyaltyPromotionAvailableTimeData availableTime)
            {
                this.availableTime = availableTime;
                return this;
            }

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// TriggerLimit.
             /// </summary>
             /// <param name="triggerLimit"> triggerLimit. </param>
             /// <returns> Builder. </returns>
            public Builder TriggerLimit(Models.LoyaltyPromotionTriggerLimit triggerLimit)
            {
                this.triggerLimit = triggerLimit;
                return this;
            }

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// CanceledAt.
             /// </summary>
             /// <param name="canceledAt"> canceledAt. </param>
             /// <returns> Builder. </returns>
            public Builder CanceledAt(string canceledAt)
            {
                this.canceledAt = canceledAt;
                return this;
            }

             /// <summary>
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

             /// <summary>
             /// LoyaltyProgramId.
             /// </summary>
             /// <param name="loyaltyProgramId"> loyaltyProgramId. </param>
             /// <returns> Builder. </returns>
            public Builder LoyaltyProgramId(string loyaltyProgramId)
            {
                this.loyaltyProgramId = loyaltyProgramId;
                return this;
            }

             /// <summary>
             /// MinimumSpendAmountMoney.
             /// </summary>
             /// <param name="minimumSpendAmountMoney"> minimumSpendAmountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder MinimumSpendAmountMoney(Models.Money minimumSpendAmountMoney)
            {
                this.minimumSpendAmountMoney = minimumSpendAmountMoney;
                return this;
            }

             /// <summary>
             /// QualifyingItemVariationIds.
             /// </summary>
             /// <param name="qualifyingItemVariationIds"> qualifyingItemVariationIds. </param>
             /// <returns> Builder. </returns>
            public Builder QualifyingItemVariationIds(IList<string> qualifyingItemVariationIds)
            {
                shouldSerialize["qualifying_item_variation_ids"] = true;
                this.qualifyingItemVariationIds = qualifyingItemVariationIds;
                return this;
            }

             /// <summary>
             /// QualifyingCategoryIds.
             /// </summary>
             /// <param name="qualifyingCategoryIds"> qualifyingCategoryIds. </param>
             /// <returns> Builder. </returns>
            public Builder QualifyingCategoryIds(IList<string> qualifyingCategoryIds)
            {
                shouldSerialize["qualifying_category_ids"] = true;
                this.qualifyingCategoryIds = qualifyingCategoryIds;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetQualifyingItemVariationIds()
            {
                this.shouldSerialize["qualifying_item_variation_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetQualifyingCategoryIds()
            {
                this.shouldSerialize["qualifying_category_ids"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyPromotion. </returns>
            public LoyaltyPromotion Build()
            {
                return new LoyaltyPromotion(shouldSerialize,
                    this.name,
                    this.incentive,
                    this.availableTime,
                    this.id,
                    this.triggerLimit,
                    this.status,
                    this.createdAt,
                    this.canceledAt,
                    this.updatedAt,
                    this.loyaltyProgramId,
                    this.minimumSpendAmountMoney,
                    this.qualifyingItemVariationIds,
                    this.qualifyingCategoryIds);
            }
        }
    }
}