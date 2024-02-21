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
    /// OrderReturnLineItem.
    /// </summary>
    public class OrderReturnLineItem
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
        /// <param name="catalogVersion">catalog_version.</param>
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
        /// <param name="appliedServiceCharges">applied_service_charges.</param>
        /// <param name="totalServiceChargeMoney">total_service_charge_money.</param>
        public OrderReturnLineItem(
            string quantity,
            string uid = null,
            string sourceLineItemUid = null,
            string name = null,
            Models.OrderQuantityUnit quantityUnit = null,
            string note = null,
            string catalogObjectId = null,
            long? catalogVersion = null,
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
            Models.Money totalMoney = null,
            IList<Models.OrderLineItemAppliedServiceCharge> appliedServiceCharges = null,
            Models.Money totalServiceChargeMoney = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "source_line_item_uid", false },
                { "name", false },
                { "note", false },
                { "catalog_object_id", false },
                { "catalog_version", false },
                { "variation_name", false },
                { "return_modifiers", false },
                { "applied_taxes", false },
                { "applied_discounts", false },
                { "applied_service_charges", false }
            };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }

            if (sourceLineItemUid != null)
            {
                shouldSerialize["source_line_item_uid"] = true;
                this.SourceLineItemUid = sourceLineItemUid;
            }

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            this.Quantity = quantity;
            this.QuantityUnit = quantityUnit;
            if (note != null)
            {
                shouldSerialize["note"] = true;
                this.Note = note;
            }

            if (catalogObjectId != null)
            {
                shouldSerialize["catalog_object_id"] = true;
                this.CatalogObjectId = catalogObjectId;
            }

            if (catalogVersion != null)
            {
                shouldSerialize["catalog_version"] = true;
                this.CatalogVersion = catalogVersion;
            }

            if (variationName != null)
            {
                shouldSerialize["variation_name"] = true;
                this.VariationName = variationName;
            }

            this.ItemType = itemType;
            if (returnModifiers != null)
            {
                shouldSerialize["return_modifiers"] = true;
                this.ReturnModifiers = returnModifiers;
            }

            if (appliedTaxes != null)
            {
                shouldSerialize["applied_taxes"] = true;
                this.AppliedTaxes = appliedTaxes;
            }

            if (appliedDiscounts != null)
            {
                shouldSerialize["applied_discounts"] = true;
                this.AppliedDiscounts = appliedDiscounts;
            }

            this.BasePriceMoney = basePriceMoney;
            this.VariationTotalPriceMoney = variationTotalPriceMoney;
            this.GrossReturnMoney = grossReturnMoney;
            this.TotalTaxMoney = totalTaxMoney;
            this.TotalDiscountMoney = totalDiscountMoney;
            this.TotalMoney = totalMoney;
            if (appliedServiceCharges != null)
            {
                shouldSerialize["applied_service_charges"] = true;
                this.AppliedServiceCharges = appliedServiceCharges;
            }

            this.TotalServiceChargeMoney = totalServiceChargeMoney;
        }
        internal OrderReturnLineItem(Dictionary<string, bool> shouldSerialize,
            string quantity,
            string uid = null,
            string sourceLineItemUid = null,
            string name = null,
            Models.OrderQuantityUnit quantityUnit = null,
            string note = null,
            string catalogObjectId = null,
            long? catalogVersion = null,
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
            Models.Money totalMoney = null,
            IList<Models.OrderLineItemAppliedServiceCharge> appliedServiceCharges = null,
            Models.Money totalServiceChargeMoney = null)
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            SourceLineItemUid = sourceLineItemUid;
            Name = name;
            Quantity = quantity;
            QuantityUnit = quantityUnit;
            Note = note;
            CatalogObjectId = catalogObjectId;
            CatalogVersion = catalogVersion;
            VariationName = variationName;
            ItemType = itemType;
            ReturnModifiers = returnModifiers;
            AppliedTaxes = appliedTaxes;
            AppliedDiscounts = appliedDiscounts;
            BasePriceMoney = basePriceMoney;
            VariationTotalPriceMoney = variationTotalPriceMoney;
            GrossReturnMoney = grossReturnMoney;
            TotalTaxMoney = totalTaxMoney;
            TotalDiscountMoney = totalDiscountMoney;
            TotalMoney = totalMoney;
            AppliedServiceCharges = appliedServiceCharges;
            TotalServiceChargeMoney = totalServiceChargeMoney;
        }

        /// <summary>
        /// A unique ID for this return line-item entry.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The `uid` of the line item in the original sale order.
        /// </summary>
        [JsonProperty("source_line_item_uid")]
        public string SourceLineItemUid { get; }

        /// <summary>
        /// The name of the line item.
        /// </summary>
        [JsonProperty("name")]
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
        [JsonProperty("note")]
        public string Note { get; }

        /// <summary>
        /// The [CatalogItemVariation](entity:CatalogItemVariation) ID applied to this return line item.
        /// </summary>
        [JsonProperty("catalog_object_id")]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The version of the catalog object that this line item references.
        /// </summary>
        [JsonProperty("catalog_version")]
        public long? CatalogVersion { get; }

        /// <summary>
        /// The name of the variation applied to this return line item.
        /// </summary>
        [JsonProperty("variation_name")]
        public string VariationName { get; }

        /// <summary>
        /// Represents the line item type.
        /// </summary>
        [JsonProperty("item_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemType { get; }

        /// <summary>
        /// The [CatalogModifier](entity:CatalogModifier)s applied to this line item.
        /// </summary>
        [JsonProperty("return_modifiers")]
        public IList<Models.OrderReturnLineItemModifier> ReturnModifiers { get; }

        /// <summary>
        /// The list of references to `OrderReturnTax` entities applied to the return line item. Each
        /// `OrderLineItemAppliedTax` has a `tax_uid` that references the `uid` of a top-level
        /// `OrderReturnTax` applied to the return line item. On reads, the applied amount
        /// is populated.
        /// </summary>
        [JsonProperty("applied_taxes")]
        public IList<Models.OrderLineItemAppliedTax> AppliedTaxes { get; }

        /// <summary>
        /// The list of references to `OrderReturnDiscount` entities applied to the return line item. Each
        /// `OrderLineItemAppliedDiscount` has a `discount_uid` that references the `uid` of a top-level
        /// `OrderReturnDiscount` applied to the return line item. On reads, the applied amount
        /// is populated.
        /// </summary>
        [JsonProperty("applied_discounts")]
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

        /// <summary>
        /// The list of references to `OrderReturnServiceCharge` entities applied to the return
        /// line item. Each `OrderLineItemAppliedServiceCharge` has a `service_charge_uid` that
        /// references the `uid` of a top-level `OrderReturnServiceCharge` applied to the return line
        /// item. On reads, the applied amount is populated.
        /// </summary>
        [JsonProperty("applied_service_charges")]
        public IList<Models.OrderLineItemAppliedServiceCharge> AppliedServiceCharges { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_service_charge_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalServiceChargeMoney { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderReturnLineItem : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUid()
        {
            return this.shouldSerialize["uid"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSourceLineItemUid()
        {
            return this.shouldSerialize["source_line_item_uid"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNote()
        {
            return this.shouldSerialize["note"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCatalogObjectId()
        {
            return this.shouldSerialize["catalog_object_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCatalogVersion()
        {
            return this.shouldSerialize["catalog_version"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeVariationName()
        {
            return this.shouldSerialize["variation_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReturnModifiers()
        {
            return this.shouldSerialize["return_modifiers"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAppliedTaxes()
        {
            return this.shouldSerialize["applied_taxes"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAppliedDiscounts()
        {
            return this.shouldSerialize["applied_discounts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAppliedServiceCharges()
        {
            return this.shouldSerialize["applied_service_charges"];
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
            return obj is OrderReturnLineItem other &&                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.SourceLineItemUid == null && other.SourceLineItemUid == null) || (this.SourceLineItemUid?.Equals(other.SourceLineItemUid) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Quantity == null && other.Quantity == null) || (this.Quantity?.Equals(other.Quantity) == true)) &&
                ((this.QuantityUnit == null && other.QuantityUnit == null) || (this.QuantityUnit?.Equals(other.QuantityUnit) == true)) &&
                ((this.Note == null && other.Note == null) || (this.Note?.Equals(other.Note) == true)) &&
                ((this.CatalogObjectId == null && other.CatalogObjectId == null) || (this.CatalogObjectId?.Equals(other.CatalogObjectId) == true)) &&
                ((this.CatalogVersion == null && other.CatalogVersion == null) || (this.CatalogVersion?.Equals(other.CatalogVersion) == true)) &&
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
                ((this.TotalMoney == null && other.TotalMoney == null) || (this.TotalMoney?.Equals(other.TotalMoney) == true)) &&
                ((this.AppliedServiceCharges == null && other.AppliedServiceCharges == null) || (this.AppliedServiceCharges?.Equals(other.AppliedServiceCharges) == true)) &&
                ((this.TotalServiceChargeMoney == null && other.TotalServiceChargeMoney == null) || (this.TotalServiceChargeMoney?.Equals(other.TotalServiceChargeMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1245509498;
            hashCode = HashCode.Combine(this.Uid, this.SourceLineItemUid, this.Name, this.Quantity, this.QuantityUnit, this.Note, this.CatalogObjectId);

            hashCode = HashCode.Combine(hashCode, this.CatalogVersion, this.VariationName, this.ItemType, this.ReturnModifiers, this.AppliedTaxes, this.AppliedDiscounts, this.BasePriceMoney);

            hashCode = HashCode.Combine(hashCode, this.VariationTotalPriceMoney, this.GrossReturnMoney, this.TotalTaxMoney, this.TotalDiscountMoney, this.TotalMoney, this.AppliedServiceCharges, this.TotalServiceChargeMoney);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {(this.Uid == null ? "null" : this.Uid)}");
            toStringOutput.Add($"this.SourceLineItemUid = {(this.SourceLineItemUid == null ? "null" : this.SourceLineItemUid)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.Quantity = {(this.Quantity == null ? "null" : this.Quantity)}");
            toStringOutput.Add($"this.QuantityUnit = {(this.QuantityUnit == null ? "null" : this.QuantityUnit.ToString())}");
            toStringOutput.Add($"this.Note = {(this.Note == null ? "null" : this.Note)}");
            toStringOutput.Add($"this.CatalogObjectId = {(this.CatalogObjectId == null ? "null" : this.CatalogObjectId)}");
            toStringOutput.Add($"this.CatalogVersion = {(this.CatalogVersion == null ? "null" : this.CatalogVersion.ToString())}");
            toStringOutput.Add($"this.VariationName = {(this.VariationName == null ? "null" : this.VariationName)}");
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
            toStringOutput.Add($"this.AppliedServiceCharges = {(this.AppliedServiceCharges == null ? "null" : $"[{string.Join(", ", this.AppliedServiceCharges)} ]")}");
            toStringOutput.Add($"this.TotalServiceChargeMoney = {(this.TotalServiceChargeMoney == null ? "null" : this.TotalServiceChargeMoney.ToString())}");
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
                .CatalogVersion(this.CatalogVersion)
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
                .TotalMoney(this.TotalMoney)
                .AppliedServiceCharges(this.AppliedServiceCharges)
                .TotalServiceChargeMoney(this.TotalServiceChargeMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "source_line_item_uid", false },
                { "name", false },
                { "note", false },
                { "catalog_object_id", false },
                { "catalog_version", false },
                { "variation_name", false },
                { "return_modifiers", false },
                { "applied_taxes", false },
                { "applied_discounts", false },
                { "applied_service_charges", false },
            };

            private string quantity;
            private string uid;
            private string sourceLineItemUid;
            private string name;
            private Models.OrderQuantityUnit quantityUnit;
            private string note;
            private string catalogObjectId;
            private long? catalogVersion;
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
            private IList<Models.OrderLineItemAppliedServiceCharge> appliedServiceCharges;
            private Models.Money totalServiceChargeMoney;

            /// <summary>
            /// Initialize Builder for OrderReturnLineItem.
            /// </summary>
            /// <param name="quantity"> quantity. </param>
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
                shouldSerialize["uid"] = true;
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
                shouldSerialize["source_line_item_uid"] = true;
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
                shouldSerialize["name"] = true;
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
                shouldSerialize["note"] = true;
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
                shouldSerialize["catalog_object_id"] = true;
                this.catalogObjectId = catalogObjectId;
                return this;
            }

             /// <summary>
             /// CatalogVersion.
             /// </summary>
             /// <param name="catalogVersion"> catalogVersion. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogVersion(long? catalogVersion)
            {
                shouldSerialize["catalog_version"] = true;
                this.catalogVersion = catalogVersion;
                return this;
            }

             /// <summary>
             /// VariationName.
             /// </summary>
             /// <param name="variationName"> variationName. </param>
             /// <returns> Builder. </returns>
            public Builder VariationName(string variationName)
            {
                shouldSerialize["variation_name"] = true;
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
                shouldSerialize["return_modifiers"] = true;
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
                shouldSerialize["applied_taxes"] = true;
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
                shouldSerialize["applied_discounts"] = true;
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
             /// AppliedServiceCharges.
             /// </summary>
             /// <param name="appliedServiceCharges"> appliedServiceCharges. </param>
             /// <returns> Builder. </returns>
            public Builder AppliedServiceCharges(IList<Models.OrderLineItemAppliedServiceCharge> appliedServiceCharges)
            {
                shouldSerialize["applied_service_charges"] = true;
                this.appliedServiceCharges = appliedServiceCharges;
                return this;
            }

             /// <summary>
             /// TotalServiceChargeMoney.
             /// </summary>
             /// <param name="totalServiceChargeMoney"> totalServiceChargeMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalServiceChargeMoney(Models.Money totalServiceChargeMoney)
            {
                this.totalServiceChargeMoney = totalServiceChargeMoney;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetUid()
            {
                this.shouldSerialize["uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSourceLineItemUid()
            {
                this.shouldSerialize["source_line_item_uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetNote()
            {
                this.shouldSerialize["note"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCatalogObjectId()
            {
                this.shouldSerialize["catalog_object_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCatalogVersion()
            {
                this.shouldSerialize["catalog_version"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetVariationName()
            {
                this.shouldSerialize["variation_name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetReturnModifiers()
            {
                this.shouldSerialize["return_modifiers"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAppliedTaxes()
            {
                this.shouldSerialize["applied_taxes"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAppliedDiscounts()
            {
                this.shouldSerialize["applied_discounts"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAppliedServiceCharges()
            {
                this.shouldSerialize["applied_service_charges"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderReturnLineItem. </returns>
            public OrderReturnLineItem Build()
            {
                return new OrderReturnLineItem(shouldSerialize,
                    this.quantity,
                    this.uid,
                    this.sourceLineItemUid,
                    this.name,
                    this.quantityUnit,
                    this.note,
                    this.catalogObjectId,
                    this.catalogVersion,
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
                    this.totalMoney,
                    this.appliedServiceCharges,
                    this.totalServiceChargeMoney);
            }
        }
    }
}