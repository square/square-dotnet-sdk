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
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyProgramAccrualRule"/> class.
        /// </summary>
        /// <param name="accrualType">accrual_type.</param>
        /// <param name="points">points.</param>
        /// <param name="visitMinimumAmountMoney">visit_minimum_amount_money.</param>
        /// <param name="spendAmountMoney">spend_amount_money.</param>
        /// <param name="catalogObjectId">catalog_object_id.</param>
        public LoyaltyProgramAccrualRule(
            string accrualType,
            int? points = null,
            Models.Money visitMinimumAmountMoney = null,
            Models.Money spendAmountMoney = null,
            string catalogObjectId = null)
        {
            this.AccrualType = accrualType;
            this.Points = points;
            this.VisitMinimumAmountMoney = visitMinimumAmountMoney;
            this.SpendAmountMoney = spendAmountMoney;
            this.CatalogObjectId = catalogObjectId;
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
        [JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
        public int? Points { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("visit_minimum_amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money VisitMinimumAmountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("spend_amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money SpendAmountMoney { get; }

        /// <summary>
        /// The ID of the [catalog object]($m/CatalogObject) to purchase to earn the number of points defined by the
        /// rule. This is either an item variation or a category, depending on the type. This is defined on
        /// `ITEM_VARIATION` rules and `CATEGORY` rules.
        /// </summary>
        [JsonProperty("catalog_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CatalogObjectId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyProgramAccrualRule : ({string.Join(", ", toStringOutput)})";
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
                ((this.VisitMinimumAmountMoney == null && other.VisitMinimumAmountMoney == null) || (this.VisitMinimumAmountMoney?.Equals(other.VisitMinimumAmountMoney) == true)) &&
                ((this.SpendAmountMoney == null && other.SpendAmountMoney == null) || (this.SpendAmountMoney?.Equals(other.SpendAmountMoney) == true)) &&
                ((this.CatalogObjectId == null && other.CatalogObjectId == null) || (this.CatalogObjectId?.Equals(other.CatalogObjectId) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -765894953;

            if (this.AccrualType != null)
            {
               hashCode += this.AccrualType.GetHashCode();
            }

            if (this.Points != null)
            {
               hashCode += this.Points.GetHashCode();
            }

            if (this.VisitMinimumAmountMoney != null)
            {
               hashCode += this.VisitMinimumAmountMoney.GetHashCode();
            }

            if (this.SpendAmountMoney != null)
            {
               hashCode += this.SpendAmountMoney.GetHashCode();
            }

            if (this.CatalogObjectId != null)
            {
               hashCode += this.CatalogObjectId.GetHashCode();
            }

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
            toStringOutput.Add($"this.VisitMinimumAmountMoney = {(this.VisitMinimumAmountMoney == null ? "null" : this.VisitMinimumAmountMoney.ToString())}");
            toStringOutput.Add($"this.SpendAmountMoney = {(this.SpendAmountMoney == null ? "null" : this.SpendAmountMoney.ToString())}");
            toStringOutput.Add($"this.CatalogObjectId = {(this.CatalogObjectId == null ? "null" : this.CatalogObjectId == string.Empty ? "" : this.CatalogObjectId)}");
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
                .VisitMinimumAmountMoney(this.VisitMinimumAmountMoney)
                .SpendAmountMoney(this.SpendAmountMoney)
                .CatalogObjectId(this.CatalogObjectId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string accrualType;
            private int? points;
            private Models.Money visitMinimumAmountMoney;
            private Models.Money spendAmountMoney;
            private string catalogObjectId;

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
                this.points = points;
                return this;
            }

             /// <summary>
             /// VisitMinimumAmountMoney.
             /// </summary>
             /// <param name="visitMinimumAmountMoney"> visitMinimumAmountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder VisitMinimumAmountMoney(Models.Money visitMinimumAmountMoney)
            {
                this.visitMinimumAmountMoney = visitMinimumAmountMoney;
                return this;
            }

             /// <summary>
             /// SpendAmountMoney.
             /// </summary>
             /// <param name="spendAmountMoney"> spendAmountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder SpendAmountMoney(Models.Money spendAmountMoney)
            {
                this.spendAmountMoney = spendAmountMoney;
                return this;
            }

             /// <summary>
             /// CatalogObjectId.
             /// </summary>
             /// <param name="catalogObjectId"> catalogObjectId. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogObjectId(string catalogObjectId)
            {
                this.catalogObjectId = catalogObjectId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyProgramAccrualRule. </returns>
            public LoyaltyProgramAccrualRule Build()
            {
                return new LoyaltyProgramAccrualRule(
                    this.accrualType,
                    this.points,
                    this.visitMinimumAmountMoney,
                    this.spendAmountMoney,
                    this.catalogObjectId);
            }
        }
    }
}