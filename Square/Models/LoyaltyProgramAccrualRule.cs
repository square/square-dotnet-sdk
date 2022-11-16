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
    /// LoyaltyProgramAccrualRule.
    /// </summary>
    public class LoyaltyProgramAccrualRule
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyProgramAccrualRule"/> class.
        /// </summary>
        /// <param name="accrualType">accrual_type.</param>
        /// <param name="points">points.</param>
        /// <param name="visitData">visit_data.</param>
        /// <param name="spendData">spend_data.</param>
        /// <param name="itemVariationData">item_variation_data.</param>
        /// <param name="categoryData">category_data.</param>
        public LoyaltyProgramAccrualRule(
            string accrualType,
            int? points = null,
            Models.LoyaltyProgramAccrualRuleVisitData visitData = null,
            Models.LoyaltyProgramAccrualRuleSpendData spendData = null,
            Models.LoyaltyProgramAccrualRuleItemVariationData itemVariationData = null,
            Models.LoyaltyProgramAccrualRuleCategoryData categoryData = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "points", false }
            };

            this.AccrualType = accrualType;
            if (points != null)
            {
                shouldSerialize["points"] = true;
                this.Points = points;
            }

            this.VisitData = visitData;
            this.SpendData = spendData;
            this.ItemVariationData = itemVariationData;
            this.CategoryData = categoryData;
        }
        internal LoyaltyProgramAccrualRule(Dictionary<string, bool> shouldSerialize,
            string accrualType,
            int? points = null,
            Models.LoyaltyProgramAccrualRuleVisitData visitData = null,
            Models.LoyaltyProgramAccrualRuleSpendData spendData = null,
            Models.LoyaltyProgramAccrualRuleItemVariationData itemVariationData = null,
            Models.LoyaltyProgramAccrualRuleCategoryData categoryData = null)
        {
            this.shouldSerialize = shouldSerialize;
            AccrualType = accrualType;
            Points = points;
            VisitData = visitData;
            SpendData = spendData;
            ItemVariationData = itemVariationData;
            CategoryData = categoryData;
        }

        /// <summary>
        /// The type of the accrual rule that defines how buyers can earn points.
        /// </summary>
        [JsonProperty("accrual_type")]
        public string AccrualType { get; }

        /// <summary>
        /// The number of points that
        /// buyers earn based on the `accrual_type`.
        /// </summary>
        [JsonProperty("points")]
        public int? Points { get; }

        /// <summary>
        /// Represents additional data for rules with the `VISIT` accrual type.
        /// </summary>
        [JsonProperty("visit_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyProgramAccrualRuleVisitData VisitData { get; }

        /// <summary>
        /// Represents additional data for rules with the `SPEND` accrual type.
        /// </summary>
        [JsonProperty("spend_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyProgramAccrualRuleSpendData SpendData { get; }

        /// <summary>
        /// Represents additional data for rules with the `ITEM_VARIATION` accrual type.
        /// </summary>
        [JsonProperty("item_variation_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyProgramAccrualRuleItemVariationData ItemVariationData { get; }

        /// <summary>
        /// Represents additional data for rules with the `CATEGORY` accrual type.
        /// </summary>
        [JsonProperty("category_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyProgramAccrualRuleCategoryData CategoryData { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyProgramAccrualRule : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePoints()
        {
            return this.shouldSerialize["points"];
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

            return obj is LoyaltyProgramAccrualRule other &&
                ((this.AccrualType == null && other.AccrualType == null) || (this.AccrualType?.Equals(other.AccrualType) == true)) &&
                ((this.Points == null && other.Points == null) || (this.Points?.Equals(other.Points) == true)) &&
                ((this.VisitData == null && other.VisitData == null) || (this.VisitData?.Equals(other.VisitData) == true)) &&
                ((this.SpendData == null && other.SpendData == null) || (this.SpendData?.Equals(other.SpendData) == true)) &&
                ((this.ItemVariationData == null && other.ItemVariationData == null) || (this.ItemVariationData?.Equals(other.ItemVariationData) == true)) &&
                ((this.CategoryData == null && other.CategoryData == null) || (this.CategoryData?.Equals(other.CategoryData) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1357142668;
            hashCode = HashCode.Combine(this.AccrualType, this.Points, this.VisitData, this.SpendData, this.ItemVariationData, this.CategoryData);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AccrualType = {(this.AccrualType == null ? "null" : this.AccrualType.ToString())}");
            toStringOutput.Add($"this.Points = {(this.Points == null ? "null" : this.Points.ToString())}");
            toStringOutput.Add($"this.VisitData = {(this.VisitData == null ? "null" : this.VisitData.ToString())}");
            toStringOutput.Add($"this.SpendData = {(this.SpendData == null ? "null" : this.SpendData.ToString())}");
            toStringOutput.Add($"this.ItemVariationData = {(this.ItemVariationData == null ? "null" : this.ItemVariationData.ToString())}");
            toStringOutput.Add($"this.CategoryData = {(this.CategoryData == null ? "null" : this.CategoryData.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.AccrualType)
                .Points(this.Points)
                .VisitData(this.VisitData)
                .SpendData(this.SpendData)
                .ItemVariationData(this.ItemVariationData)
                .CategoryData(this.CategoryData);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "points", false },
            };

            private string accrualType;
            private int? points;
            private Models.LoyaltyProgramAccrualRuleVisitData visitData;
            private Models.LoyaltyProgramAccrualRuleSpendData spendData;
            private Models.LoyaltyProgramAccrualRuleItemVariationData itemVariationData;
            private Models.LoyaltyProgramAccrualRuleCategoryData categoryData;

            public Builder(
                string accrualType)
            {
                this.accrualType = accrualType;
            }

             /// <summary>
             /// AccrualType.
             /// </summary>
             /// <param name="accrualType"> accrualType. </param>
             /// <returns> Builder. </returns>
            public Builder AccrualType(string accrualType)
            {
                this.accrualType = accrualType;
                return this;
            }

             /// <summary>
             /// Points.
             /// </summary>
             /// <param name="points"> points. </param>
             /// <returns> Builder. </returns>
            public Builder Points(int? points)
            {
                shouldSerialize["points"] = true;
                this.points = points;
                return this;
            }

             /// <summary>
             /// VisitData.
             /// </summary>
             /// <param name="visitData"> visitData. </param>
             /// <returns> Builder. </returns>
            public Builder VisitData(Models.LoyaltyProgramAccrualRuleVisitData visitData)
            {
                this.visitData = visitData;
                return this;
            }

             /// <summary>
             /// SpendData.
             /// </summary>
             /// <param name="spendData"> spendData. </param>
             /// <returns> Builder. </returns>
            public Builder SpendData(Models.LoyaltyProgramAccrualRuleSpendData spendData)
            {
                this.spendData = spendData;
                return this;
            }

             /// <summary>
             /// ItemVariationData.
             /// </summary>
             /// <param name="itemVariationData"> itemVariationData. </param>
             /// <returns> Builder. </returns>
            public Builder ItemVariationData(Models.LoyaltyProgramAccrualRuleItemVariationData itemVariationData)
            {
                this.itemVariationData = itemVariationData;
                return this;
            }

             /// <summary>
             /// CategoryData.
             /// </summary>
             /// <param name="categoryData"> categoryData. </param>
             /// <returns> Builder. </returns>
            public Builder CategoryData(Models.LoyaltyProgramAccrualRuleCategoryData categoryData)
            {
                this.categoryData = categoryData;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPoints()
            {
                this.shouldSerialize["points"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyProgramAccrualRule. </returns>
            public LoyaltyProgramAccrualRule Build()
            {
                return new LoyaltyProgramAccrualRule(shouldSerialize,
                    this.accrualType,
                    this.points,
                    this.visitData,
                    this.spendData,
                    this.itemVariationData,
                    this.categoryData);
            }
        }
    }
}