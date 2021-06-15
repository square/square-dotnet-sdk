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
    /// OrderReturnLineItem.
    /// </summary>
    public class OrderReturnLineItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderReturnLineItem"/> class.
        /// </summary>
        /// <param name="quantity">quantity.</param>
        /// <param name="uid">uid.</param>
        /// <param name="sourceLineItemUid">source_line_item_uid.</param>
        /// <param name="name">name.</param>
        /// <param name="quantityUnit">quantity_unit.</param>
        /// <param name="note">note.</param>
        /// <param name="catalogObjectId">catalog_object_id.</param>
        /// <param name="variationName">variation_name.</param>
        /// <param name="itemType">item_type.</param>
        /// <param name="returnModifiers">return_modifiers.</param>
        /// <param name="appliedTaxes">applied_taxes.</param>
        /// <param name="appliedDiscounts">applied_discounts.</param>
        /// <param name="basePriceMoney">base_price_money.</param>
        /// <param name="variationTotalPriceMoney">variation_total_price_money.</param>
        /// <param name="grossReturnMoney">gross_return_money.</param>
        /// <param name="totalTaxMoney">total_tax_money.</param>
        /// <param name="totalDiscountMoney">total_discount_money.</param>
        /// <param name="totalMoney">total_money.</param>
        public OrderReturnLineItem(
            string quantity,
            string uid = null,
            string sourceLineItemUid = null,
            string name = null,
            Models.OrderQuantityUnit quantityUnit = null,
            string note = null,
            string catalogObjectId = null,
            string variationName = null,
            string itemType = null,
            IList<Models.OrderReturnLineItemModifier> returnModifiers = null,
            IList<Models.OrderLineItemAppliedTax> appliedTaxes = null,
            IList<Models.OrderLineItemAppliedDiscount> appliedDiscounts = null,
            Models.Money basePriceMoney = null,
            Models.Money variationTotalPriceMoney = null,
            Models.Money grossReturnMoney = null,
            Models.Money totalTaxMoney = null,
            Models.Money totalDiscountMoney = null,
            Models.Money totalMoney = null)
        {
            this.Uid = uid;
            this.SourceLineItemUid = sourceLineItemUid;
            this.Name = name;
            this.Quantity = quantity;
            this.QuantityUnit = quantityUnit;
            this.Note = note;
            this.CatalogObjectId = catalogObjectId;
            this.VariationName = variationName;
            this.ItemType = itemType;
            this.ReturnModifiers = returnModifiers;
            this.AppliedTaxes = appliedTaxes;
            this.AppliedDiscounts = appliedDiscounts;
            this.BasePriceMoney = basePriceMoney;
            this.VariationTotalPriceMoney = variationTotalPriceMoney;
            this.GrossReturnMoney = grossReturnMoney;
            this.TotalTaxMoney = totalTaxMoney;
            this.TotalDiscountMoney = totalDiscountMoney;
            this.TotalMoney = totalMoney;
        }

        /// <summary>
        /// A unique ID for this return line-item entry.
        /// </summary>
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// The `uid` of the line item in the original sale order.
        /// </summary>
        [JsonProperty("source_line_item_uid", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceLineItemUid { get; }

        /// <summary>
        /// The name of the line item.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// The quantity returned, formatted as a decimal number.
        /// For example, `"3"`.
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
        /// The note of the return line item.
        /// </summary>
        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; }

        /// <summary>
        /// The [CatalogItemVariation]($m/CatalogItemVariation) ID applied to this return line item.
        /// </summary>
        [JsonProperty("catalog_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The name of the variation applied to this return line item.
        /// </summary>
        [JsonProperty("variation_name", NullValueHandling = NullValueHandling.Ignore)]
        public string VariationName { get; }

        /// <summary>
        /// Represents the line item type.
        /// </summary>
        [JsonProperty("item_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemType { get; }

        /// <summary>
        /// The [CatalogModifier]($m/CatalogModifier)s applied to this line item.
        /// </summary>
        [JsonProperty("return_modifiers", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderReturnLineItemModifier> ReturnModifiers { get; }

        /// <summary>
        /// The list of references to `OrderReturnTax` entities applied to the return line item. Each
        /// `OrderLineItemAppliedTax` has a `tax_uid` that references the `uid` of a top-level
        /// `OrderReturnTax` applied to the return line item. On reads, the applied amount
        /// is populated.
        /// </summary>
        [JsonProperty("applied_taxes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderLineItemAppliedTax> AppliedTaxes { get; }

        /// <summary>
        /// The list of references to `OrderReturnDiscount` entities applied to the return line item. Each
        /// `OrderLineItemAppliedDiscount` has a `discount_uid` that references the `uid` of a top-level
        /// `OrderReturnDiscount` applied to the return line item. On reads, the applied amount
        /// is populated.
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
        [JsonProperty("gross_return_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money GrossReturnMoney { get; }

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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderReturnLineItem : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderReturnLineItem other &&
                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.SourceLineItemUid == null && other.SourceLineItemUid == null) || (this.SourceLineItemUid?.Equals(other.SourceLineItemUid) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Quantity == null && other.Quantity == null) || (this.Quantity?.Equals(other.Quantity) == true)) &&
                ((this.QuantityUnit == null && other.QuantityUnit == null) || (this.QuantityUnit?.Equals(other.QuantityUnit) == true)) &&
                ((this.Note == null && other.Note == null) || (this.Note?.Equals(other.Note) == true)) &&
                ((this.CatalogObjectId == null && other.CatalogObjectId == null) || (this.CatalogObjectId?.Equals(other.CatalogObjectId) == true)) &&
                ((this.VariationName == null && other.VariationName == null) || (this.VariationName?.Equals(other.VariationName) == true)) &&
                ((this.ItemType == null && other.ItemType == null) || (this.ItemType?.Equals(other.ItemType) == true)) &&
                ((this.ReturnModifiers == null && other.ReturnModifiers == null) || (this.ReturnModifiers?.Equals(other.ReturnModifiers) == true)) &&
                ((this.AppliedTaxes == null && other.AppliedTaxes == null) || (this.AppliedTaxes?.Equals(other.AppliedTaxes) == true)) &&
                ((this.AppliedDiscounts == null && other.AppliedDiscounts == null) || (this.AppliedDiscounts?.Equals(other.AppliedDiscounts) == true)) &&
                ((this.BasePriceMoney == null && other.BasePriceMoney == null) || (this.BasePriceMoney?.Equals(other.BasePriceMoney) == true)) &&
                ((this.VariationTotalPriceMoney == null && other.VariationTotalPriceMoney == null) || (this.VariationTotalPriceMoney?.Equals(other.VariationTotalPriceMoney) == true)) &&
                ((this.GrossReturnMoney == null && other.GrossReturnMoney == null) || (this.GrossReturnMoney?.Equals(other.GrossReturnMoney) == true)) &&
                ((this.TotalTaxMoney == null && other.TotalTaxMoney == null) || (this.TotalTaxMoney?.Equals(other.TotalTaxMoney) == true)) &&
                ((this.TotalDiscountMoney == null && other.TotalDiscountMoney == null) || (this.TotalDiscountMoney?.Equals(other.TotalDiscountMoney) == true)) &&
                ((this.TotalMoney == null && other.TotalMoney == null) || (this.TotalMoney?.Equals(other.TotalMoney) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -196630176;

            if (this.Uid != null)
            {
               hashCode += this.Uid.GetHashCode();
            }

            if (this.SourceLineItemUid != null)
            {
               hashCode += this.SourceLineItemUid.GetHashCode();
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

            if (this.ItemType != null)
            {
               hashCode += this.ItemType.GetHashCode();
            }

            if (this.ReturnModifiers != null)
            {
               hashCode += this.ReturnModifiers.GetHashCode();
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

            if (this.GrossReturnMoney != null)
            {
               hashCode += this.GrossReturnMoney.GetHashCode();
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

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {(this.Uid == null ? "null" : this.Uid == string.Empty ? "" : this.Uid)}");
            toStringOutput.Add($"this.SourceLineItemUid = {(this.SourceLineItemUid == null ? "null" : this.SourceLineItemUid == string.Empty ? "" : this.SourceLineItemUid)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Quantity = {(this.Quantity == null ? "null" : this.Quantity == string.Empty ? "" : this.Quantity)}");
            toStringOutput.Add($"this.QuantityUnit = {(this.QuantityUnit == null ? "null" : this.QuantityUnit.ToString())}");
            toStringOutput.Add($"this.Note = {(this.Note == null ? "null" : this.Note == string.Empty ? "" : this.Note)}");
            toStringOutput.Add($"this.CatalogObjectId = {(this.CatalogObjectId == null ? "null" : this.CatalogObjectId == string.Empty ? "" : this.CatalogObjectId)}");
            toStringOutput.Add($"this.VariationName = {(this.VariationName == null ? "null" : this.VariationName == string.Empty ? "" : this.VariationName)}");
            toStringOutput.Add($"this.ItemType = {(this.ItemType == null ? "null" : this.ItemType.ToString())}");
            toStringOutput.Add($"this.ReturnModifiers = {(this.ReturnModifiers == null ? "null" : $"[{string.Join(", ", this.ReturnModifiers)} ]")}");
            toStringOutput.Add($"this.AppliedTaxes = {(this.AppliedTaxes == null ? "null" : $"[{string.Join(", ", this.AppliedTaxes)} ]")}");
            toStringOutput.Add($"this.AppliedDiscounts = {(this.AppliedDiscounts == null ? "null" : $"[{string.Join(", ", this.AppliedDiscounts)} ]")}");
            toStringOutput.Add($"this.BasePriceMoney = {(this.BasePriceMoney == null ? "null" : this.BasePriceMoney.ToString())}");
            toStringOutput.Add($"this.VariationTotalPriceMoney = {(this.VariationTotalPriceMoney == null ? "null" : this.VariationTotalPriceMoney.ToString())}");
            toStringOutput.Add($"this.GrossReturnMoney = {(this.GrossReturnMoney == null ? "null" : this.GrossReturnMoney.ToString())}");
            toStringOutput.Add($"this.TotalTaxMoney = {(this.TotalTaxMoney == null ? "null" : this.TotalTaxMoney.ToString())}");
            toStringOutput.Add($"this.TotalDiscountMoney = {(this.TotalDiscountMoney == null ? "null" : this.TotalDiscountMoney.ToString())}");
            toStringOutput.Add($"this.TotalMoney = {(this.TotalMoney == null ? "null" : this.TotalMoney.ToString())}");
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
                .SourceLineItemUid(this.SourceLineItemUid)
                .Name(this.Name)
                .QuantityUnit(this.QuantityUnit)
                .Note(this.Note)
                .CatalogObjectId(this.CatalogObjectId)
                .VariationName(this.VariationName)
                .ItemType(this.ItemType)
                .ReturnModifiers(this.ReturnModifiers)
                .AppliedTaxes(this.AppliedTaxes)
                .AppliedDiscounts(this.AppliedDiscounts)
                .BasePriceMoney(this.BasePriceMoney)
                .VariationTotalPriceMoney(this.VariationTotalPriceMoney)
                .GrossReturnMoney(this.GrossReturnMoney)
                .TotalTaxMoney(this.TotalTaxMoney)
                .TotalDiscountMoney(this.TotalDiscountMoney)
                .TotalMoney(this.TotalMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string quantity;
            private string uid;
            private string sourceLineItemUid;
            private string name;
            private Models.OrderQuantityUnit quantityUnit;
            private string note;
            private string catalogObjectId;
            private string variationName;
            private string itemType;
            private IList<Models.OrderReturnLineItemModifier> returnModifiers;
            private IList<Models.OrderLineItemAppliedTax> appliedTaxes;
            private IList<Models.OrderLineItemAppliedDiscount> appliedDiscounts;
            private Models.Money basePriceMoney;
            private Models.Money variationTotalPriceMoney;
            private Models.Money grossReturnMoney;
            private Models.Money totalTaxMoney;
            private Models.Money totalDiscountMoney;
            private Models.Money totalMoney;

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
             /// SourceLineItemUid.
             /// </summary>
             /// <param name="sourceLineItemUid"> sourceLineItemUid. </param>
             /// <returns> Builder. </returns>
            public Builder SourceLineItemUid(string sourceLineItemUid)
            {
                this.sourceLineItemUid = sourceLineItemUid;
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
             /// ItemType.
             /// </summary>
             /// <param name="itemType"> itemType. </param>
             /// <returns> Builder. </returns>
            public Builder ItemType(string itemType)
            {
                this.itemType = itemType;
                return this;
            }

             /// <summary>
             /// ReturnModifiers.
             /// </summary>
             /// <param name="returnModifiers"> returnModifiers. </param>
             /// <returns> Builder. </returns>
            public Builder ReturnModifiers(IList<Models.OrderReturnLineItemModifier> returnModifiers)
            {
                this.returnModifiers = returnModifiers;
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
             /// GrossReturnMoney.
             /// </summary>
             /// <param name="grossReturnMoney"> grossReturnMoney. </param>
             /// <returns> Builder. </returns>
            public Builder GrossReturnMoney(Models.Money grossReturnMoney)
            {
                this.grossReturnMoney = grossReturnMoney;
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
            /// Builds class object.
            /// </summary>
            /// <returns> OrderReturnLineItem. </returns>
            public OrderReturnLineItem Build()
            {
                return new OrderReturnLineItem(
                    this.quantity,
                    this.uid,
                    this.sourceLineItemUid,
                    this.name,
                    this.quantityUnit,
                    this.note,
                    this.catalogObjectId,
                    this.variationName,
                    this.itemType,
                    this.returnModifiers,
                    this.appliedTaxes,
                    this.appliedDiscounts,
                    this.basePriceMoney,
                    this.variationTotalPriceMoney,
                    this.grossReturnMoney,
                    this.totalTaxMoney,
                    this.totalDiscountMoney,
                    this.totalMoney);
            }
        }
    }
}