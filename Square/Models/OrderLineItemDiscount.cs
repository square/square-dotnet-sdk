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
    /// OrderLineItemDiscount.
    /// </summary>
    public class OrderLineItemDiscount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLineItemDiscount"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="catalogObjectId">catalog_object_id.</param>
        /// <param name="name">name.</param>
        /// <param name="type">type.</param>
        /// <param name="percentage">percentage.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="appliedMoney">applied_money.</param>
        /// <param name="metadata">metadata.</param>
        /// <param name="scope">scope.</param>
        /// <param name="rewardIds">reward_ids.</param>
        /// <param name="pricingRuleId">pricing_rule_id.</param>
        public OrderLineItemDiscount(
            string uid = null,
            string catalogObjectId = null,
            string name = null,
            string type = null,
            string percentage = null,
            Models.Money amountMoney = null,
            Models.Money appliedMoney = null,
            IDictionary<string, string> metadata = null,
            string scope = null,
            IList<string> rewardIds = null,
            string pricingRuleId = null)
        {
            this.Uid = uid;
            this.CatalogObjectId = catalogObjectId;
            this.Name = name;
            this.Type = type;
            this.Percentage = percentage;
            this.AmountMoney = amountMoney;
            this.AppliedMoney = appliedMoney;
            this.Metadata = metadata;
            this.Scope = scope;
            this.RewardIds = rewardIds;
            this.PricingRuleId = pricingRuleId;
        }

        /// <summary>
        /// A unique ID that identifies the discount only within this order.
        /// </summary>
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// The catalog object ID referencing [CatalogDiscount]($m/CatalogDiscount).
        /// </summary>
        [JsonProperty("catalog_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The discount's name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// Indicates how the discount is applied to the associated line item or order.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// The percentage of the discount, as a string representation of a decimal number.
        /// A value of `7.25` corresponds to a percentage of 7.25%.
        /// `percentage` is not set for amount-based discounts.
        /// </summary>
        [JsonProperty("percentage", NullValueHandling = NullValueHandling.Ignore)]
        public string Percentage { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AmountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("applied_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AppliedMoney { get; }

        /// <summary>
        /// Application-defined data attached to this discount. Metadata fields are intended
        /// to store descriptive references or associations with an entity in another system or store brief
        /// information about the object. Square does not process this field; it only stores and returns it
        /// in relevant API calls. Do not use metadata to store any sensitive information (such as personally
        /// identifiable information or card details).
        /// Keys written by applications must be 60 characters or less and must be in the character set
        /// `[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed
        /// with a namespace, separated from the key with a ':' character.
        /// Values have a maximum length of 255 characters.
        /// An application can have up to 10 entries per metadata field.
        /// Entries written by applications are private and can only be read or modified by the same
        /// application.
        /// For more information, see [Metadata](https://developer.squareup.com/docs/build-basics/metadata).
        /// </summary>
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, string> Metadata { get; }

        /// <summary>
        /// Indicates whether this is a line-item or order-level discount.
        /// </summary>
        [JsonProperty("scope", NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; }

        /// <summary>
        /// The reward IDs corresponding to this discount. The application and
        /// specification of discounts that have `reward_ids` are completely controlled by the backing
        /// criteria corresponding to the reward tiers of the rewards that are added to the order
        /// through the Loyalty API. To manually unapply discounts that are the result of added rewards,
        /// the rewards must be removed from the order through the Loyalty API.
        /// </summary>
        [JsonProperty("reward_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> RewardIds { get; }

        /// <summary>
        /// The object ID of a [pricing rule]($m/CatalogPricingRule) to be applied
        /// automatically to this discount. The specification and application of the discounts, to
        /// which a `pricing_rule_id` is assigned, are completely controlled by the corresponding
        /// pricing rule.
        /// </summary>
        [JsonProperty("pricing_rule_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PricingRuleId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderLineItemDiscount : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderLineItemDiscount other &&
                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.CatalogObjectId == null && other.CatalogObjectId == null) || (this.CatalogObjectId?.Equals(other.CatalogObjectId) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Percentage == null && other.Percentage == null) || (this.Percentage?.Equals(other.Percentage) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.AppliedMoney == null && other.AppliedMoney == null) || (this.AppliedMoney?.Equals(other.AppliedMoney) == true)) &&
                ((this.Metadata == null && other.Metadata == null) || (this.Metadata?.Equals(other.Metadata) == true)) &&
                ((this.Scope == null && other.Scope == null) || (this.Scope?.Equals(other.Scope) == true)) &&
                ((this.RewardIds == null && other.RewardIds == null) || (this.RewardIds?.Equals(other.RewardIds) == true)) &&
                ((this.PricingRuleId == null && other.PricingRuleId == null) || (this.PricingRuleId?.Equals(other.PricingRuleId) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1963841269;

            if (this.Uid != null)
            {
               hashCode += this.Uid.GetHashCode();
            }

            if (this.CatalogObjectId != null)
            {
               hashCode += this.CatalogObjectId.GetHashCode();
            }

            if (this.Name != null)
            {
               hashCode += this.Name.GetHashCode();
            }

            if (this.Type != null)
            {
               hashCode += this.Type.GetHashCode();
            }

            if (this.Percentage != null)
            {
               hashCode += this.Percentage.GetHashCode();
            }

            if (this.AmountMoney != null)
            {
               hashCode += this.AmountMoney.GetHashCode();
            }

            if (this.AppliedMoney != null)
            {
               hashCode += this.AppliedMoney.GetHashCode();
            }

            if (this.Metadata != null)
            {
               hashCode += this.Metadata.GetHashCode();
            }

            if (this.Scope != null)
            {
               hashCode += this.Scope.GetHashCode();
            }

            if (this.RewardIds != null)
            {
               hashCode += this.RewardIds.GetHashCode();
            }

            if (this.PricingRuleId != null)
            {
               hashCode += this.PricingRuleId.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {(this.Uid == null ? "null" : this.Uid == string.Empty ? "" : this.Uid)}");
            toStringOutput.Add($"this.CatalogObjectId = {(this.CatalogObjectId == null ? "null" : this.CatalogObjectId == string.Empty ? "" : this.CatalogObjectId)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.Percentage = {(this.Percentage == null ? "null" : this.Percentage == string.Empty ? "" : this.Percentage)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.AppliedMoney = {(this.AppliedMoney == null ? "null" : this.AppliedMoney.ToString())}");
            toStringOutput.Add($"Metadata = {(this.Metadata == null ? "null" : this.Metadata.ToString())}");
            toStringOutput.Add($"this.Scope = {(this.Scope == null ? "null" : this.Scope.ToString())}");
            toStringOutput.Add($"this.RewardIds = {(this.RewardIds == null ? "null" : $"[{string.Join(", ", this.RewardIds)} ]")}");
            toStringOutput.Add($"this.PricingRuleId = {(this.PricingRuleId == null ? "null" : this.PricingRuleId == string.Empty ? "" : this.PricingRuleId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(this.Uid)
                .CatalogObjectId(this.CatalogObjectId)
                .Name(this.Name)
                .Type(this.Type)
                .Percentage(this.Percentage)
                .AmountMoney(this.AmountMoney)
                .AppliedMoney(this.AppliedMoney)
                .Metadata(this.Metadata)
                .Scope(this.Scope)
                .RewardIds(this.RewardIds)
                .PricingRuleId(this.PricingRuleId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string uid;
            private string catalogObjectId;
            private string name;
            private string type;
            private string percentage;
            private Models.Money amountMoney;
            private Models.Money appliedMoney;
            private IDictionary<string, string> metadata;
            private string scope;
            private IList<string> rewardIds;
            private string pricingRuleId;

             /// <summary>
             /// Uid.
             /// </summary>
             /// <param name="uid"> uid. </param>
             /// <returns> Builder. </returns>
            public Builder Uid(string uid)
            {
                this.uid = uid;
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
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// Percentage.
             /// </summary>
             /// <param name="percentage"> percentage. </param>
             /// <returns> Builder. </returns>
            public Builder Percentage(string percentage)
            {
                this.percentage = percentage;
                return this;
            }

             /// <summary>
             /// AmountMoney.
             /// </summary>
             /// <param name="amountMoney"> amountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

             /// <summary>
             /// AppliedMoney.
             /// </summary>
             /// <param name="appliedMoney"> appliedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AppliedMoney(Models.Money appliedMoney)
            {
                this.appliedMoney = appliedMoney;
                return this;
            }

             /// <summary>
             /// Metadata.
             /// </summary>
             /// <param name="metadata"> metadata. </param>
             /// <returns> Builder. </returns>
            public Builder Metadata(IDictionary<string, string> metadata)
            {
                this.metadata = metadata;
                return this;
            }

             /// <summary>
             /// Scope.
             /// </summary>
             /// <param name="scope"> scope. </param>
             /// <returns> Builder. </returns>
            public Builder Scope(string scope)
            {
                this.scope = scope;
                return this;
            }

             /// <summary>
             /// RewardIds.
             /// </summary>
             /// <param name="rewardIds"> rewardIds. </param>
             /// <returns> Builder. </returns>
            public Builder RewardIds(IList<string> rewardIds)
            {
                this.rewardIds = rewardIds;
                return this;
            }

             /// <summary>
             /// PricingRuleId.
             /// </summary>
             /// <param name="pricingRuleId"> pricingRuleId. </param>
             /// <returns> Builder. </returns>
            public Builder PricingRuleId(string pricingRuleId)
            {
                this.pricingRuleId = pricingRuleId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderLineItemDiscount. </returns>
            public OrderLineItemDiscount Build()
            {
                return new OrderLineItemDiscount(
                    this.uid,
                    this.catalogObjectId,
                    this.name,
                    this.type,
                    this.percentage,
                    this.amountMoney,
                    this.appliedMoney,
                    this.metadata,
                    this.scope,
                    this.rewardIds,
                    this.pricingRuleId);
            }
        }
    }
}