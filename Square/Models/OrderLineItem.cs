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
    /// OrderLineItem.
    /// </summary>
    public class OrderLineItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLineItem"/> class.
        /// </summary>
        /// <param name="quantity">quantity.</param>
        /// <param name="uid">uid.</param>
        /// <param name="name">name.</param>
        /// <param name="quantityUnit">quantity_unit.</param>
        /// <param name="note">note.</param>
        /// <param name="catalogObjectId">catalog_object_id.</param>
        /// <param name="variationName">variation_name.</param>
        /// <param name="metadata">metadata.</param>
        /// <param name="modifiers">modifiers.</param>
        /// <param name="appliedTaxes">applied_taxes.</param>
        /// <param name="appliedDiscounts">applied_discounts.</param>
        /// <param name="basePriceMoney">base_price_money.</param>
        /// <param name="variationTotalPriceMoney">variation_total_price_money.</param>
        /// <param name="grossSalesMoney">gross_sales_money.</param>
        /// <param name="totalTaxMoney">total_tax_money.</param>
        /// <param name="totalDiscountMoney">total_discount_money.</param>
        /// <param name="totalMoney">total_money.</param>
        /// <param name="pricingBlocklists">pricing_blocklists.</param>
        public OrderLineItem(
            string quantity,
            string uid = null,
            string name = null,
            Models.OrderQuantityUnit quantityUnit = null,
            string note = null,
            string catalogObjectId = null,
            string variationName = null,
            IDictionary<string, string> metadata = null,
            IList<Models.OrderLineItemModifier> modifiers = null,
            IList<Models.OrderLineItemAppliedTax> appliedTaxes = null,
            IList<Models.OrderLineItemAppliedDiscount> appliedDiscounts = null,
            Models.Money basePriceMoney = null,
            Models.Money variationTotalPriceMoney = null,
            Models.Money grossSalesMoney = null,
            Models.Money totalTaxMoney = null,
            Models.Money totalDiscountMoney = null,
            Models.Money totalMoney = null,
            Models.OrderLineItemPricingBlocklists pricingBlocklists = null)
        {
            this.Uid = uid;
            this.Name = name;
            this.Quantity = quantity;
            this.QuantityUnit = quantityUnit;
            this.Note = note;
            this.CatalogObjectId = catalogObjectId;
            this.VariationName = variationName;
            this.Metadata = metadata;
            this.Modifiers = modifiers;
            this.AppliedTaxes = appliedTaxes;
            this.AppliedDiscounts = appliedDiscounts;
            this.BasePriceMoney = basePriceMoney;
            this.VariationTotalPriceMoney = variationTotalPriceMoney;
            this.GrossSalesMoney = grossSalesMoney;
            this.TotalTaxMoney = totalTaxMoney;
            this.TotalDiscountMoney = totalDiscountMoney;
            this.TotalMoney = totalMoney;
            this.PricingBlocklists = pricingBlocklists;
        }

        /// <summary>
        /// A unique ID that identifies the line item only within this order.
        /// </summary>
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// The name of the line item.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// The quantity purchased, formatted as a decimal number.
        /// For example, `"3"`.
        /// Line items with a quantity of `"0"` are automatically removed
        /// when paying for or otherwise completing the order.
        /// Line items with a `quantity_unit` can have non-integer quantities.
        /// For example, `"1.70000"`.
        /// </summary>
        [JsonProperty("quantity")]
        public string Quantity { get; }

        /// <summary>
        /// Contains the measurement unit for a quantity and a precision that
        /// specifies the number of digits after the decimal point for decimal quantities.
        /// </summary>
        [JsonProperty("quantity_unit", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderQuantityUnit QuantityUnit { get; }

        /// <summary>
        /// The note of the line item.
        /// </summary>
        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; }

        /// <summary>
        /// The [CatalogItemVariation]($m/CatalogItemVariation) ID applied to this line item.
        /// </summary>
        [JsonProperty("catalog_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The name of the variation applied to this line item.
        /// </summary>
        [JsonProperty("variation_name", NullValueHandling = NullValueHandling.Ignore)]
        public string VariationName { get; }

        /// <summary>
        /// Application-defined data attached to this line item. Metadata fields are intended
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
        /// The [CatalogModifier]($m/CatalogModifier)s applied to this line item.
        /// </summary>
        [JsonProperty("modifiers", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderLineItemModifier> Modifiers { get; }

        /// <summary>
        /// The list of references to taxes applied to this line item. Each
        /// `OrderLineItemAppliedTax` has a `tax_uid` that references the `uid` of a
        /// top-level `OrderLineItemTax` applied to the line item. On reads, the
        /// amount applied is populated.
        /// An `OrderLineItemAppliedTax` is automatically created on every line
        /// item for all `ORDER` scoped taxes added to the order. `OrderLineItemAppliedTax`
        /// records for `LINE_ITEM` scoped taxes must be added in requests for the tax
        /// to apply to any line items.
        /// To change the amount of a tax, modify the referenced top-level tax.
        /// </summary>
        [JsonProperty("applied_taxes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderLineItemAppliedTax> AppliedTaxes { get; }

        /// <summary>
        /// The list of references to discounts applied to this line item. Each
        /// `OrderLineItemAppliedDiscount` has a `discount_uid` that references the `uid` of a top-level
        /// `OrderLineItemDiscounts` applied to the line item. On reads, the amount
        /// applied is populated.
        /// An `OrderLineItemAppliedDiscount` is automatically created on every line item for all
        /// `ORDER` scoped discounts that are added to the order. `OrderLineItemAppliedDiscount` records
        /// for `LINE_ITEM` scoped discounts must be added in requests for the discount to apply to any
        /// line items.
        /// To change the amount of a discount, modify the referenced top-level discount.
        /// </summary>
        [JsonProperty("applied_discounts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderLineItemAppliedDiscount> AppliedDiscounts { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("base_price_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money BasePriceMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("variation_total_price_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money VariationTotalPriceMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("gross_sales_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money GrossSalesMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_tax_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalTaxMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_discount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalDiscountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalMoney { get; }

        /// <summary>
        /// Describes pricing adjustments that are blocked from manual and
        /// automatic application to a line item. For more information, see
        /// [Apply Taxes and Discounts](https://developer.squareup.com/docs/orders-api/apply-taxes-and-discounts).
        /// </summary>
        [JsonProperty("pricing_blocklists", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderLineItemPricingBlocklists PricingBlocklists { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderLineItem : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderLineItem other &&
                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Quantity == null && other.Quantity == null) || (this.Quantity?.Equals(other.Quantity) == true)) &&
                ((this.QuantityUnit == null && other.QuantityUnit == null) || (this.QuantityUnit?.Equals(other.QuantityUnit) == true)) &&
                ((this.Note == null && other.Note == null) || (this.Note?.Equals(other.Note) == true)) &&
                ((this.CatalogObjectId == null && other.CatalogObjectId == null) || (this.CatalogObjectId?.Equals(other.CatalogObjectId) == true)) &&
                ((this.VariationName == null && other.VariationName == null) || (this.VariationName?.Equals(other.VariationName) == true)) &&
                ((this.Metadata == null && other.Metadata == null) || (this.Metadata?.Equals(other.Metadata) == true)) &&
                ((this.Modifiers == null && other.Modifiers == null) || (this.Modifiers?.Equals(other.Modifiers) == true)) &&
                ((this.AppliedTaxes == null && other.AppliedTaxes == null) || (this.AppliedTaxes?.Equals(other.AppliedTaxes) == true)) &&
                ((this.AppliedDiscounts == null && other.AppliedDiscounts == null) || (this.AppliedDiscounts?.Equals(other.AppliedDiscounts) == true)) &&
                ((this.BasePriceMoney == null && other.BasePriceMoney == null) || (this.BasePriceMoney?.Equals(other.BasePriceMoney) == true)) &&
                ((this.VariationTotalPriceMoney == null && other.VariationTotalPriceMoney == null) || (this.VariationTotalPriceMoney?.Equals(other.VariationTotalPriceMoney) == true)) &&
                ((this.GrossSalesMoney == null && other.GrossSalesMoney == null) || (this.GrossSalesMoney?.Equals(other.GrossSalesMoney) == true)) &&
                ((this.TotalTaxMoney == null && other.TotalTaxMoney == null) || (this.TotalTaxMoney?.Equals(other.TotalTaxMoney) == true)) &&
                ((this.TotalDiscountMoney == null && other.TotalDiscountMoney == null) || (this.TotalDiscountMoney?.Equals(other.TotalDiscountMoney) == true)) &&
                ((this.TotalMoney == null && other.TotalMoney == null) || (this.TotalMoney?.Equals(other.TotalMoney) == true)) &&
                ((this.PricingBlocklists == null && other.PricingBlocklists == null) || (this.PricingBlocklists?.Equals(other.PricingBlocklists) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 441365892;

            if (this.Uid != null)
            {
               hashCode += this.Uid.GetHashCode();
            }

            if (this.Name != null)
            {
               hashCode += this.Name.GetHashCode();
            }

            if (this.Quantity != null)
            {
               hashCode += this.Quantity.GetHashCode();
            }

            if (this.QuantityUnit != null)
            {
               hashCode += this.QuantityUnit.GetHashCode();
            }

            if (this.Note != null)
            {
               hashCode += this.Note.GetHashCode();
            }

            if (this.CatalogObjectId != null)
            {
               hashCode += this.CatalogObjectId.GetHashCode();
            }

            if (this.VariationName != null)
            {
               hashCode += this.VariationName.GetHashCode();
            }

            if (this.Metadata != null)
            {
               hashCode += this.Metadata.GetHashCode();
            }

            if (this.Modifiers != null)
            {
               hashCode += this.Modifiers.GetHashCode();
            }

            if (this.AppliedTaxes != null)
            {
               hashCode += this.AppliedTaxes.GetHashCode();
            }

            if (this.AppliedDiscounts != null)
            {
               hashCode += this.AppliedDiscounts.GetHashCode();
            }

            if (this.BasePriceMoney != null)
            {
               hashCode += this.BasePriceMoney.GetHashCode();
            }

            if (this.VariationTotalPriceMoney != null)
            {
               hashCode += this.VariationTotalPriceMoney.GetHashCode();
            }

            if (this.GrossSalesMoney != null)
            {
               hashCode += this.GrossSalesMoney.GetHashCode();
            }

            if (this.TotalTaxMoney != null)
            {
               hashCode += this.TotalTaxMoney.GetHashCode();
            }

            if (this.TotalDiscountMoney != null)
            {
               hashCode += this.TotalDiscountMoney.GetHashCode();
            }

            if (this.TotalMoney != null)
            {
               hashCode += this.TotalMoney.GetHashCode();
            }

            if (this.PricingBlocklists != null)
            {
               hashCode += this.PricingBlocklists.GetHashCode();
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
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Quantity = {(this.Quantity == null ? "null" : this.Quantity == string.Empty ? "" : this.Quantity)}");
            toStringOutput.Add($"this.QuantityUnit = {(this.QuantityUnit == null ? "null" : this.QuantityUnit.ToString())}");
            toStringOutput.Add($"this.Note = {(this.Note == null ? "null" : this.Note == string.Empty ? "" : this.Note)}");
            toStringOutput.Add($"this.CatalogObjectId = {(this.CatalogObjectId == null ? "null" : this.CatalogObjectId == string.Empty ? "" : this.CatalogObjectId)}");
            toStringOutput.Add($"this.VariationName = {(this.VariationName == null ? "null" : this.VariationName == string.Empty ? "" : this.VariationName)}");
            toStringOutput.Add($"Metadata = {(this.Metadata == null ? "null" : this.Metadata.ToString())}");
            toStringOutput.Add($"this.Modifiers = {(this.Modifiers == null ? "null" : $"[{string.Join(", ", this.Modifiers)} ]")}");
            toStringOutput.Add($"this.AppliedTaxes = {(this.AppliedTaxes == null ? "null" : $"[{string.Join(", ", this.AppliedTaxes)} ]")}");
            toStringOutput.Add($"this.AppliedDiscounts = {(this.AppliedDiscounts == null ? "null" : $"[{string.Join(", ", this.AppliedDiscounts)} ]")}");
            toStringOutput.Add($"this.BasePriceMoney = {(this.BasePriceMoney == null ? "null" : this.BasePriceMoney.ToString())}");
            toStringOutput.Add($"this.VariationTotalPriceMoney = {(this.VariationTotalPriceMoney == null ? "null" : this.VariationTotalPriceMoney.ToString())}");
            toStringOutput.Add($"this.GrossSalesMoney = {(this.GrossSalesMoney == null ? "null" : this.GrossSalesMoney.ToString())}");
            toStringOutput.Add($"this.TotalTaxMoney = {(this.TotalTaxMoney == null ? "null" : this.TotalTaxMoney.ToString())}");
            toStringOutput.Add($"this.TotalDiscountMoney = {(this.TotalDiscountMoney == null ? "null" : this.TotalDiscountMoney.ToString())}");
            toStringOutput.Add($"this.TotalMoney = {(this.TotalMoney == null ? "null" : this.TotalMoney.ToString())}");
            toStringOutput.Add($"this.PricingBlocklists = {(this.PricingBlocklists == null ? "null" : this.PricingBlocklists.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Quantity)
                .Uid(this.Uid)
                .Name(this.Name)
                .QuantityUnit(this.QuantityUnit)
                .Note(this.Note)
                .CatalogObjectId(this.CatalogObjectId)
                .VariationName(this.VariationName)
                .Metadata(this.Metadata)
                .Modifiers(this.Modifiers)
                .AppliedTaxes(this.AppliedTaxes)
                .AppliedDiscounts(this.AppliedDiscounts)
                .BasePriceMoney(this.BasePriceMoney)
                .VariationTotalPriceMoney(this.VariationTotalPriceMoney)
                .GrossSalesMoney(this.GrossSalesMoney)
                .TotalTaxMoney(this.TotalTaxMoney)
                .TotalDiscountMoney(this.TotalDiscountMoney)
                .TotalMoney(this.TotalMoney)
                .PricingBlocklists(this.PricingBlocklists);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string quantity;
            private string uid;
            private string name;
            private Models.OrderQuantityUnit quantityUnit;
            private string note;
            private string catalogObjectId;
            private string variationName;
            private IDictionary<string, string> metadata;
            private IList<Models.OrderLineItemModifier> modifiers;
            private IList<Models.OrderLineItemAppliedTax> appliedTaxes;
            private IList<Models.OrderLineItemAppliedDiscount> appliedDiscounts;
            private Models.Money basePriceMoney;
            private Models.Money variationTotalPriceMoney;
            private Models.Money grossSalesMoney;
            private Models.Money totalTaxMoney;
            private Models.Money totalDiscountMoney;
            private Models.Money totalMoney;
            private Models.OrderLineItemPricingBlocklists pricingBlocklists;

            public Builder(
                string quantity)
            {
                this.quantity = quantity;
            }

             /// <summary>
             /// Quantity.
             /// </summary>
             /// <param name="quantity"> quantity. </param>
             /// <returns> Builder. </returns>
            public Builder Quantity(string quantity)
            {
                this.quantity = quantity;
                return this;
            }

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
             /// QuantityUnit.
             /// </summary>
             /// <param name="quantityUnit"> quantityUnit. </param>
             /// <returns> Builder. </returns>
            public Builder QuantityUnit(Models.OrderQuantityUnit quantityUnit)
            {
                this.quantityUnit = quantityUnit;
                return this;
            }

             /// <summary>
             /// Note.
             /// </summary>
             /// <param name="note"> note. </param>
             /// <returns> Builder. </returns>
            public Builder Note(string note)
            {
                this.note = note;
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
             /// VariationName.
             /// </summary>
             /// <param name="variationName"> variationName. </param>
             /// <returns> Builder. </returns>
            public Builder VariationName(string variationName)
            {
                this.variationName = variationName;
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
             /// Modifiers.
             /// </summary>
             /// <param name="modifiers"> modifiers. </param>
             /// <returns> Builder. </returns>
            public Builder Modifiers(IList<Models.OrderLineItemModifier> modifiers)
            {
                this.modifiers = modifiers;
                return this;
            }

             /// <summary>
             /// AppliedTaxes.
             /// </summary>
             /// <param name="appliedTaxes"> appliedTaxes. </param>
             /// <returns> Builder. </returns>
            public Builder AppliedTaxes(IList<Models.OrderLineItemAppliedTax> appliedTaxes)
            {
                this.appliedTaxes = appliedTaxes;
                return this;
            }

             /// <summary>
             /// AppliedDiscounts.
             /// </summary>
             /// <param name="appliedDiscounts"> appliedDiscounts. </param>
             /// <returns> Builder. </returns>
            public Builder AppliedDiscounts(IList<Models.OrderLineItemAppliedDiscount> appliedDiscounts)
            {
                this.appliedDiscounts = appliedDiscounts;
                return this;
            }

             /// <summary>
             /// BasePriceMoney.
             /// </summary>
             /// <param name="basePriceMoney"> basePriceMoney. </param>
             /// <returns> Builder. </returns>
            public Builder BasePriceMoney(Models.Money basePriceMoney)
            {
                this.basePriceMoney = basePriceMoney;
                return this;
            }

             /// <summary>
             /// VariationTotalPriceMoney.
             /// </summary>
             /// <param name="variationTotalPriceMoney"> variationTotalPriceMoney. </param>
             /// <returns> Builder. </returns>
            public Builder VariationTotalPriceMoney(Models.Money variationTotalPriceMoney)
            {
                this.variationTotalPriceMoney = variationTotalPriceMoney;
                return this;
            }

             /// <summary>
             /// GrossSalesMoney.
             /// </summary>
             /// <param name="grossSalesMoney"> grossSalesMoney. </param>
             /// <returns> Builder. </returns>
            public Builder GrossSalesMoney(Models.Money grossSalesMoney)
            {
                this.grossSalesMoney = grossSalesMoney;
                return this;
            }

             /// <summary>
             /// TotalTaxMoney.
             /// </summary>
             /// <param name="totalTaxMoney"> totalTaxMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalTaxMoney(Models.Money totalTaxMoney)
            {
                this.totalTaxMoney = totalTaxMoney;
                return this;
            }

             /// <summary>
             /// TotalDiscountMoney.
             /// </summary>
             /// <param name="totalDiscountMoney"> totalDiscountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalDiscountMoney(Models.Money totalDiscountMoney)
            {
                this.totalDiscountMoney = totalDiscountMoney;
                return this;
            }

             /// <summary>
             /// TotalMoney.
             /// </summary>
             /// <param name="totalMoney"> totalMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalMoney(Models.Money totalMoney)
            {
                this.totalMoney = totalMoney;
                return this;
            }

             /// <summary>
             /// PricingBlocklists.
             /// </summary>
             /// <param name="pricingBlocklists"> pricingBlocklists. </param>
             /// <returns> Builder. </returns>
            public Builder PricingBlocklists(Models.OrderLineItemPricingBlocklists pricingBlocklists)
            {
                this.pricingBlocklists = pricingBlocklists;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderLineItem. </returns>
            public OrderLineItem Build()
            {
                return new OrderLineItem(
                    this.quantity,
                    this.uid,
                    this.name,
                    this.quantityUnit,
                    this.note,
                    this.catalogObjectId,
                    this.variationName,
                    this.metadata,
                    this.modifiers,
                    this.appliedTaxes,
                    this.appliedDiscounts,
                    this.basePriceMoney,
                    this.variationTotalPriceMoney,
                    this.grossSalesMoney,
                    this.totalTaxMoney,
                    this.totalDiscountMoney,
                    this.totalMoney,
                    this.pricingBlocklists);
            }
        }
    }
}