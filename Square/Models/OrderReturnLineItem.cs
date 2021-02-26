
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class OrderReturnLineItem 
    {
        public OrderReturnLineItem(string quantity,
            string uid = null,
            string sourceLineItemUid = null,
            string name = null,
            Models.OrderQuantityUnit quantityUnit = null,
            string note = null,
            string catalogObjectId = null,
            string variationName = null,
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
            Uid = uid;
            SourceLineItemUid = sourceLineItemUid;
            Name = name;
            Quantity = quantity;
            QuantityUnit = quantityUnit;
            Note = note;
            CatalogObjectId = catalogObjectId;
            VariationName = variationName;
            ReturnModifiers = returnModifiers;
            AppliedTaxes = appliedTaxes;
            AppliedDiscounts = appliedDiscounts;
            BasePriceMoney = basePriceMoney;
            VariationTotalPriceMoney = variationTotalPriceMoney;
            GrossReturnMoney = grossReturnMoney;
            TotalTaxMoney = totalTaxMoney;
            TotalDiscountMoney = totalDiscountMoney;
            TotalMoney = totalMoney;
        }

        /// <summary>
        /// Unique identifier for this return line item entry.
        /// </summary>
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// `uid` of the LineItem in the original sale Order.
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
        /// For example: `"3"`.
        /// Line items with a `quantity_unit` can have non-integer quantities.
        /// For example: `"1.70000"`.
        /// </summary>
        [JsonProperty("quantity")]
        public string Quantity { get; }

        /// <summary>
        /// Contains the measurement unit for a quantity and a precision which
        /// specifies the number of digits after the decimal point for decimal quantities.
        /// </summary>
        [JsonProperty("quantity_unit", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderQuantityUnit QuantityUnit { get; }

        /// <summary>
        /// The note of the returned line item.
        /// </summary>
        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; }

        /// <summary>
        /// The [CatalogItemVariation](#type-catalogitemvariation) id applied to this returned line item.
        /// </summary>
        [JsonProperty("catalog_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The name of the variation applied to this returned line item.
        /// </summary>
        [JsonProperty("variation_name", NullValueHandling = NullValueHandling.Ignore)]
        public string VariationName { get; }

        /// <summary>
        /// The [CatalogModifier](#type-catalogmodifier)s applied to this line item.
        /// </summary>
        [JsonProperty("return_modifiers", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderReturnLineItemModifier> ReturnModifiers { get; }

        /// <summary>
        /// The list of references to `OrderReturnTax` entities applied to the returned line item. Each
        /// `OrderLineItemAppliedTax` has a `tax_uid` that references the `uid` of a top-level
        /// `OrderReturnTax` applied to the returned line item. On reads, the amount applied
        /// is populated.
        /// </summary>
        [JsonProperty("applied_taxes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderLineItemAppliedTax> AppliedTaxes { get; }

        /// <summary>
        /// The list of references to `OrderReturnDiscount` entities applied to the returned line item. Each
        /// `OrderLineItemAppliedDiscount` has a `discount_uid` that references the `uid` of a top-level
        /// `OrderReturnDiscount` applied to the returned line item. On reads, the amount
        /// applied is populated.
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderReturnLineItem : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Uid = {(Uid == null ? "null" : Uid == string.Empty ? "" : Uid)}");
            toStringOutput.Add($"SourceLineItemUid = {(SourceLineItemUid == null ? "null" : SourceLineItemUid == string.Empty ? "" : SourceLineItemUid)}");
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
            toStringOutput.Add($"Quantity = {(Quantity == null ? "null" : Quantity == string.Empty ? "" : Quantity)}");
            toStringOutput.Add($"QuantityUnit = {(QuantityUnit == null ? "null" : QuantityUnit.ToString())}");
            toStringOutput.Add($"Note = {(Note == null ? "null" : Note == string.Empty ? "" : Note)}");
            toStringOutput.Add($"CatalogObjectId = {(CatalogObjectId == null ? "null" : CatalogObjectId == string.Empty ? "" : CatalogObjectId)}");
            toStringOutput.Add($"VariationName = {(VariationName == null ? "null" : VariationName == string.Empty ? "" : VariationName)}");
            toStringOutput.Add($"ReturnModifiers = {(ReturnModifiers == null ? "null" : $"[{ string.Join(", ", ReturnModifiers)} ]")}");
            toStringOutput.Add($"AppliedTaxes = {(AppliedTaxes == null ? "null" : $"[{ string.Join(", ", AppliedTaxes)} ]")}");
            toStringOutput.Add($"AppliedDiscounts = {(AppliedDiscounts == null ? "null" : $"[{ string.Join(", ", AppliedDiscounts)} ]")}");
            toStringOutput.Add($"BasePriceMoney = {(BasePriceMoney == null ? "null" : BasePriceMoney.ToString())}");
            toStringOutput.Add($"VariationTotalPriceMoney = {(VariationTotalPriceMoney == null ? "null" : VariationTotalPriceMoney.ToString())}");
            toStringOutput.Add($"GrossReturnMoney = {(GrossReturnMoney == null ? "null" : GrossReturnMoney.ToString())}");
            toStringOutput.Add($"TotalTaxMoney = {(TotalTaxMoney == null ? "null" : TotalTaxMoney.ToString())}");
            toStringOutput.Add($"TotalDiscountMoney = {(TotalDiscountMoney == null ? "null" : TotalDiscountMoney.ToString())}");
            toStringOutput.Add($"TotalMoney = {(TotalMoney == null ? "null" : TotalMoney.ToString())}");
        }

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
                ((Uid == null && other.Uid == null) || (Uid?.Equals(other.Uid) == true)) &&
                ((SourceLineItemUid == null && other.SourceLineItemUid == null) || (SourceLineItemUid?.Equals(other.SourceLineItemUid) == true)) &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true)) &&
                ((Quantity == null && other.Quantity == null) || (Quantity?.Equals(other.Quantity) == true)) &&
                ((QuantityUnit == null && other.QuantityUnit == null) || (QuantityUnit?.Equals(other.QuantityUnit) == true)) &&
                ((Note == null && other.Note == null) || (Note?.Equals(other.Note) == true)) &&
                ((CatalogObjectId == null && other.CatalogObjectId == null) || (CatalogObjectId?.Equals(other.CatalogObjectId) == true)) &&
                ((VariationName == null && other.VariationName == null) || (VariationName?.Equals(other.VariationName) == true)) &&
                ((ReturnModifiers == null && other.ReturnModifiers == null) || (ReturnModifiers?.Equals(other.ReturnModifiers) == true)) &&
                ((AppliedTaxes == null && other.AppliedTaxes == null) || (AppliedTaxes?.Equals(other.AppliedTaxes) == true)) &&
                ((AppliedDiscounts == null && other.AppliedDiscounts == null) || (AppliedDiscounts?.Equals(other.AppliedDiscounts) == true)) &&
                ((BasePriceMoney == null && other.BasePriceMoney == null) || (BasePriceMoney?.Equals(other.BasePriceMoney) == true)) &&
                ((VariationTotalPriceMoney == null && other.VariationTotalPriceMoney == null) || (VariationTotalPriceMoney?.Equals(other.VariationTotalPriceMoney) == true)) &&
                ((GrossReturnMoney == null && other.GrossReturnMoney == null) || (GrossReturnMoney?.Equals(other.GrossReturnMoney) == true)) &&
                ((TotalTaxMoney == null && other.TotalTaxMoney == null) || (TotalTaxMoney?.Equals(other.TotalTaxMoney) == true)) &&
                ((TotalDiscountMoney == null && other.TotalDiscountMoney == null) || (TotalDiscountMoney?.Equals(other.TotalDiscountMoney) == true)) &&
                ((TotalMoney == null && other.TotalMoney == null) || (TotalMoney?.Equals(other.TotalMoney) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1299728447;

            if (Uid != null)
            {
               hashCode += Uid.GetHashCode();
            }

            if (SourceLineItemUid != null)
            {
               hashCode += SourceLineItemUid.GetHashCode();
            }

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            if (Quantity != null)
            {
               hashCode += Quantity.GetHashCode();
            }

            if (QuantityUnit != null)
            {
               hashCode += QuantityUnit.GetHashCode();
            }

            if (Note != null)
            {
               hashCode += Note.GetHashCode();
            }

            if (CatalogObjectId != null)
            {
               hashCode += CatalogObjectId.GetHashCode();
            }

            if (VariationName != null)
            {
               hashCode += VariationName.GetHashCode();
            }

            if (ReturnModifiers != null)
            {
               hashCode += ReturnModifiers.GetHashCode();
            }

            if (AppliedTaxes != null)
            {
               hashCode += AppliedTaxes.GetHashCode();
            }

            if (AppliedDiscounts != null)
            {
               hashCode += AppliedDiscounts.GetHashCode();
            }

            if (BasePriceMoney != null)
            {
               hashCode += BasePriceMoney.GetHashCode();
            }

            if (VariationTotalPriceMoney != null)
            {
               hashCode += VariationTotalPriceMoney.GetHashCode();
            }

            if (GrossReturnMoney != null)
            {
               hashCode += GrossReturnMoney.GetHashCode();
            }

            if (TotalTaxMoney != null)
            {
               hashCode += TotalTaxMoney.GetHashCode();
            }

            if (TotalDiscountMoney != null)
            {
               hashCode += TotalDiscountMoney.GetHashCode();
            }

            if (TotalMoney != null)
            {
               hashCode += TotalMoney.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Quantity)
                .Uid(Uid)
                .SourceLineItemUid(SourceLineItemUid)
                .Name(Name)
                .QuantityUnit(QuantityUnit)
                .Note(Note)
                .CatalogObjectId(CatalogObjectId)
                .VariationName(VariationName)
                .ReturnModifiers(ReturnModifiers)
                .AppliedTaxes(AppliedTaxes)
                .AppliedDiscounts(AppliedDiscounts)
                .BasePriceMoney(BasePriceMoney)
                .VariationTotalPriceMoney(VariationTotalPriceMoney)
                .GrossReturnMoney(GrossReturnMoney)
                .TotalTaxMoney(TotalTaxMoney)
                .TotalDiscountMoney(TotalDiscountMoney)
                .TotalMoney(TotalMoney);
            return builder;
        }

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
            private IList<Models.OrderReturnLineItemModifier> returnModifiers;
            private IList<Models.OrderLineItemAppliedTax> appliedTaxes;
            private IList<Models.OrderLineItemAppliedDiscount> appliedDiscounts;
            private Models.Money basePriceMoney;
            private Models.Money variationTotalPriceMoney;
            private Models.Money grossReturnMoney;
            private Models.Money totalTaxMoney;
            private Models.Money totalDiscountMoney;
            private Models.Money totalMoney;

            public Builder(string quantity)
            {
                this.quantity = quantity;
            }

            public Builder Quantity(string quantity)
            {
                this.quantity = quantity;
                return this;
            }

            public Builder Uid(string uid)
            {
                this.uid = uid;
                return this;
            }

            public Builder SourceLineItemUid(string sourceLineItemUid)
            {
                this.sourceLineItemUid = sourceLineItemUid;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder QuantityUnit(Models.OrderQuantityUnit quantityUnit)
            {
                this.quantityUnit = quantityUnit;
                return this;
            }

            public Builder Note(string note)
            {
                this.note = note;
                return this;
            }

            public Builder CatalogObjectId(string catalogObjectId)
            {
                this.catalogObjectId = catalogObjectId;
                return this;
            }

            public Builder VariationName(string variationName)
            {
                this.variationName = variationName;
                return this;
            }

            public Builder ReturnModifiers(IList<Models.OrderReturnLineItemModifier> returnModifiers)
            {
                this.returnModifiers = returnModifiers;
                return this;
            }

            public Builder AppliedTaxes(IList<Models.OrderLineItemAppliedTax> appliedTaxes)
            {
                this.appliedTaxes = appliedTaxes;
                return this;
            }

            public Builder AppliedDiscounts(IList<Models.OrderLineItemAppliedDiscount> appliedDiscounts)
            {
                this.appliedDiscounts = appliedDiscounts;
                return this;
            }

            public Builder BasePriceMoney(Models.Money basePriceMoney)
            {
                this.basePriceMoney = basePriceMoney;
                return this;
            }

            public Builder VariationTotalPriceMoney(Models.Money variationTotalPriceMoney)
            {
                this.variationTotalPriceMoney = variationTotalPriceMoney;
                return this;
            }

            public Builder GrossReturnMoney(Models.Money grossReturnMoney)
            {
                this.grossReturnMoney = grossReturnMoney;
                return this;
            }

            public Builder TotalTaxMoney(Models.Money totalTaxMoney)
            {
                this.totalTaxMoney = totalTaxMoney;
                return this;
            }

            public Builder TotalDiscountMoney(Models.Money totalDiscountMoney)
            {
                this.totalDiscountMoney = totalDiscountMoney;
                return this;
            }

            public Builder TotalMoney(Models.Money totalMoney)
            {
                this.totalMoney = totalMoney;
                return this;
            }

            public OrderReturnLineItem Build()
            {
                return new OrderReturnLineItem(quantity,
                    uid,
                    sourceLineItemUid,
                    name,
                    quantityUnit,
                    note,
                    catalogObjectId,
                    variationName,
                    returnModifiers,
                    appliedTaxes,
                    appliedDiscounts,
                    basePriceMoney,
                    variationTotalPriceMoney,
                    grossReturnMoney,
                    totalTaxMoney,
                    totalDiscountMoney,
                    totalMoney);
            }
        }
    }
}