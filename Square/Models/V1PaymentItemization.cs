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
    /// V1PaymentItemization.
    /// </summary>
    public class V1PaymentItemization
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="V1PaymentItemization"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="quantity">quantity.</param>
        /// <param name="itemizationType">itemization_type.</param>
        /// <param name="itemDetail">item_detail.</param>
        /// <param name="notes">notes.</param>
        /// <param name="itemVariationName">item_variation_name.</param>
        /// <param name="totalMoney">total_money.</param>
        /// <param name="singleQuantityMoney">single_quantity_money.</param>
        /// <param name="grossSalesMoney">gross_sales_money.</param>
        /// <param name="discountMoney">discount_money.</param>
        /// <param name="netSalesMoney">net_sales_money.</param>
        /// <param name="taxes">taxes.</param>
        /// <param name="discounts">discounts.</param>
        /// <param name="modifiers">modifiers.</param>
        public V1PaymentItemization(
            string name = null,
            double? quantity = null,
            string itemizationType = null,
            Models.V1PaymentItemDetail itemDetail = null,
            string notes = null,
            string itemVariationName = null,
            Models.V1Money totalMoney = null,
            Models.V1Money singleQuantityMoney = null,
            Models.V1Money grossSalesMoney = null,
            Models.V1Money discountMoney = null,
            Models.V1Money netSalesMoney = null,
            IList<Models.V1PaymentTax> taxes = null,
            IList<Models.V1PaymentDiscount> discounts = null,
            IList<Models.V1PaymentModifier> modifiers = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "quantity", false },
                { "notes", false },
                { "item_variation_name", false },
                { "taxes", false },
                { "discounts", false },
                { "modifiers", false }
            };

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            if (quantity != null)
            {
                shouldSerialize["quantity"] = true;
                this.Quantity = quantity;
            }

            this.ItemizationType = itemizationType;
            this.ItemDetail = itemDetail;
            if (notes != null)
            {
                shouldSerialize["notes"] = true;
                this.Notes = notes;
            }

            if (itemVariationName != null)
            {
                shouldSerialize["item_variation_name"] = true;
                this.ItemVariationName = itemVariationName;
            }

            this.TotalMoney = totalMoney;
            this.SingleQuantityMoney = singleQuantityMoney;
            this.GrossSalesMoney = grossSalesMoney;
            this.DiscountMoney = discountMoney;
            this.NetSalesMoney = netSalesMoney;
            if (taxes != null)
            {
                shouldSerialize["taxes"] = true;
                this.Taxes = taxes;
            }

            if (discounts != null)
            {
                shouldSerialize["discounts"] = true;
                this.Discounts = discounts;
            }

            if (modifiers != null)
            {
                shouldSerialize["modifiers"] = true;
                this.Modifiers = modifiers;
            }

        }
        internal V1PaymentItemization(Dictionary<string, bool> shouldSerialize,
            string name = null,
            double? quantity = null,
            string itemizationType = null,
            Models.V1PaymentItemDetail itemDetail = null,
            string notes = null,
            string itemVariationName = null,
            Models.V1Money totalMoney = null,
            Models.V1Money singleQuantityMoney = null,
            Models.V1Money grossSalesMoney = null,
            Models.V1Money discountMoney = null,
            Models.V1Money netSalesMoney = null,
            IList<Models.V1PaymentTax> taxes = null,
            IList<Models.V1PaymentDiscount> discounts = null,
            IList<Models.V1PaymentModifier> modifiers = null)
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
            Quantity = quantity;
            ItemizationType = itemizationType;
            ItemDetail = itemDetail;
            Notes = notes;
            ItemVariationName = itemVariationName;
            TotalMoney = totalMoney;
            SingleQuantityMoney = singleQuantityMoney;
            GrossSalesMoney = grossSalesMoney;
            DiscountMoney = discountMoney;
            NetSalesMoney = netSalesMoney;
            Taxes = taxes;
            Discounts = discounts;
            Modifiers = modifiers;
        }

        /// <summary>
        /// The item's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The quantity of the item purchased. This can be a decimal value.
        /// </summary>
        [JsonProperty("quantity")]
        public double? Quantity { get; }

        /// <summary>
        /// Gets or sets ItemizationType.
        /// </summary>
        [JsonProperty("itemization_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemizationType { get; }

        /// <summary>
        /// V1PaymentItemDetail
        /// </summary>
        [JsonProperty("item_detail", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1PaymentItemDetail ItemDetail { get; }

        /// <summary>
        /// Notes entered by the merchant about the item at the time of payment, if any.
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; }

        /// <summary>
        /// The name of the item variation purchased, if any.
        /// </summary>
        [JsonProperty("item_variation_name")]
        public string ItemVariationName { get; }

        /// <summary>
        /// Gets or sets TotalMoney.
        /// </summary>
        [JsonProperty("total_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TotalMoney { get; }

        /// <summary>
        /// Gets or sets SingleQuantityMoney.
        /// </summary>
        [JsonProperty("single_quantity_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money SingleQuantityMoney { get; }

        /// <summary>
        /// Gets or sets GrossSalesMoney.
        /// </summary>
        [JsonProperty("gross_sales_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money GrossSalesMoney { get; }

        /// <summary>
        /// Gets or sets DiscountMoney.
        /// </summary>
        [JsonProperty("discount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money DiscountMoney { get; }

        /// <summary>
        /// Gets or sets NetSalesMoney.
        /// </summary>
        [JsonProperty("net_sales_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money NetSalesMoney { get; }

        /// <summary>
        /// All taxes applied to this itemization.
        /// </summary>
        [JsonProperty("taxes")]
        public IList<Models.V1PaymentTax> Taxes { get; }

        /// <summary>
        /// All discounts applied to this itemization.
        /// </summary>
        [JsonProperty("discounts")]
        public IList<Models.V1PaymentDiscount> Discounts { get; }

        /// <summary>
        /// All modifier options applied to this itemization.
        /// </summary>
        [JsonProperty("modifiers")]
        public IList<Models.V1PaymentModifier> Modifiers { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1PaymentItemization : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeQuantity()
        {
            return this.shouldSerialize["quantity"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNotes()
        {
            return this.shouldSerialize["notes"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeItemVariationName()
        {
            return this.shouldSerialize["item_variation_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTaxes()
        {
            return this.shouldSerialize["taxes"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDiscounts()
        {
            return this.shouldSerialize["discounts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModifiers()
        {
            return this.shouldSerialize["modifiers"];
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
            return obj is V1PaymentItemization other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Quantity == null && other.Quantity == null) || (this.Quantity?.Equals(other.Quantity) == true)) &&
                ((this.ItemizationType == null && other.ItemizationType == null) || (this.ItemizationType?.Equals(other.ItemizationType) == true)) &&
                ((this.ItemDetail == null && other.ItemDetail == null) || (this.ItemDetail?.Equals(other.ItemDetail) == true)) &&
                ((this.Notes == null && other.Notes == null) || (this.Notes?.Equals(other.Notes) == true)) &&
                ((this.ItemVariationName == null && other.ItemVariationName == null) || (this.ItemVariationName?.Equals(other.ItemVariationName) == true)) &&
                ((this.TotalMoney == null && other.TotalMoney == null) || (this.TotalMoney?.Equals(other.TotalMoney) == true)) &&
                ((this.SingleQuantityMoney == null && other.SingleQuantityMoney == null) || (this.SingleQuantityMoney?.Equals(other.SingleQuantityMoney) == true)) &&
                ((this.GrossSalesMoney == null && other.GrossSalesMoney == null) || (this.GrossSalesMoney?.Equals(other.GrossSalesMoney) == true)) &&
                ((this.DiscountMoney == null && other.DiscountMoney == null) || (this.DiscountMoney?.Equals(other.DiscountMoney) == true)) &&
                ((this.NetSalesMoney == null && other.NetSalesMoney == null) || (this.NetSalesMoney?.Equals(other.NetSalesMoney) == true)) &&
                ((this.Taxes == null && other.Taxes == null) || (this.Taxes?.Equals(other.Taxes) == true)) &&
                ((this.Discounts == null && other.Discounts == null) || (this.Discounts?.Equals(other.Discounts) == true)) &&
                ((this.Modifiers == null && other.Modifiers == null) || (this.Modifiers?.Equals(other.Modifiers) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1047875174;
            hashCode = HashCode.Combine(this.Name, this.Quantity, this.ItemizationType, this.ItemDetail, this.Notes, this.ItemVariationName, this.TotalMoney);

            hashCode = HashCode.Combine(hashCode, this.SingleQuantityMoney, this.GrossSalesMoney, this.DiscountMoney, this.NetSalesMoney, this.Taxes, this.Discounts, this.Modifiers);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Quantity = {(this.Quantity == null ? "null" : this.Quantity.ToString())}");
            toStringOutput.Add($"this.ItemizationType = {(this.ItemizationType == null ? "null" : this.ItemizationType.ToString())}");
            toStringOutput.Add($"this.ItemDetail = {(this.ItemDetail == null ? "null" : this.ItemDetail.ToString())}");
            toStringOutput.Add($"this.Notes = {(this.Notes == null ? "null" : this.Notes == string.Empty ? "" : this.Notes)}");
            toStringOutput.Add($"this.ItemVariationName = {(this.ItemVariationName == null ? "null" : this.ItemVariationName == string.Empty ? "" : this.ItemVariationName)}");
            toStringOutput.Add($"this.TotalMoney = {(this.TotalMoney == null ? "null" : this.TotalMoney.ToString())}");
            toStringOutput.Add($"this.SingleQuantityMoney = {(this.SingleQuantityMoney == null ? "null" : this.SingleQuantityMoney.ToString())}");
            toStringOutput.Add($"this.GrossSalesMoney = {(this.GrossSalesMoney == null ? "null" : this.GrossSalesMoney.ToString())}");
            toStringOutput.Add($"this.DiscountMoney = {(this.DiscountMoney == null ? "null" : this.DiscountMoney.ToString())}");
            toStringOutput.Add($"this.NetSalesMoney = {(this.NetSalesMoney == null ? "null" : this.NetSalesMoney.ToString())}");
            toStringOutput.Add($"this.Taxes = {(this.Taxes == null ? "null" : $"[{string.Join(", ", this.Taxes)} ]")}");
            toStringOutput.Add($"this.Discounts = {(this.Discounts == null ? "null" : $"[{string.Join(", ", this.Discounts)} ]")}");
            toStringOutput.Add($"this.Modifiers = {(this.Modifiers == null ? "null" : $"[{string.Join(", ", this.Modifiers)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name)
                .Quantity(this.Quantity)
                .ItemizationType(this.ItemizationType)
                .ItemDetail(this.ItemDetail)
                .Notes(this.Notes)
                .ItemVariationName(this.ItemVariationName)
                .TotalMoney(this.TotalMoney)
                .SingleQuantityMoney(this.SingleQuantityMoney)
                .GrossSalesMoney(this.GrossSalesMoney)
                .DiscountMoney(this.DiscountMoney)
                .NetSalesMoney(this.NetSalesMoney)
                .Taxes(this.Taxes)
                .Discounts(this.Discounts)
                .Modifiers(this.Modifiers);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "quantity", false },
                { "notes", false },
                { "item_variation_name", false },
                { "taxes", false },
                { "discounts", false },
                { "modifiers", false },
            };

            private string name;
            private double? quantity;
            private string itemizationType;
            private Models.V1PaymentItemDetail itemDetail;
            private string notes;
            private string itemVariationName;
            private Models.V1Money totalMoney;
            private Models.V1Money singleQuantityMoney;
            private Models.V1Money grossSalesMoney;
            private Models.V1Money discountMoney;
            private Models.V1Money netSalesMoney;
            private IList<Models.V1PaymentTax> taxes;
            private IList<Models.V1PaymentDiscount> discounts;
            private IList<Models.V1PaymentModifier> modifiers;

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
             /// Quantity.
             /// </summary>
             /// <param name="quantity"> quantity. </param>
             /// <returns> Builder. </returns>
            public Builder Quantity(double? quantity)
            {
                shouldSerialize["quantity"] = true;
                this.quantity = quantity;
                return this;
            }

             /// <summary>
             /// ItemizationType.
             /// </summary>
             /// <param name="itemizationType"> itemizationType. </param>
             /// <returns> Builder. </returns>
            public Builder ItemizationType(string itemizationType)
            {
                this.itemizationType = itemizationType;
                return this;
            }

             /// <summary>
             /// ItemDetail.
             /// </summary>
             /// <param name="itemDetail"> itemDetail. </param>
             /// <returns> Builder. </returns>
            public Builder ItemDetail(Models.V1PaymentItemDetail itemDetail)
            {
                this.itemDetail = itemDetail;
                return this;
            }

             /// <summary>
             /// Notes.
             /// </summary>
             /// <param name="notes"> notes. </param>
             /// <returns> Builder. </returns>
            public Builder Notes(string notes)
            {
                shouldSerialize["notes"] = true;
                this.notes = notes;
                return this;
            }

             /// <summary>
             /// ItemVariationName.
             /// </summary>
             /// <param name="itemVariationName"> itemVariationName. </param>
             /// <returns> Builder. </returns>
            public Builder ItemVariationName(string itemVariationName)
            {
                shouldSerialize["item_variation_name"] = true;
                this.itemVariationName = itemVariationName;
                return this;
            }

             /// <summary>
             /// TotalMoney.
             /// </summary>
             /// <param name="totalMoney"> totalMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalMoney(Models.V1Money totalMoney)
            {
                this.totalMoney = totalMoney;
                return this;
            }

             /// <summary>
             /// SingleQuantityMoney.
             /// </summary>
             /// <param name="singleQuantityMoney"> singleQuantityMoney. </param>
             /// <returns> Builder. </returns>
            public Builder SingleQuantityMoney(Models.V1Money singleQuantityMoney)
            {
                this.singleQuantityMoney = singleQuantityMoney;
                return this;
            }

             /// <summary>
             /// GrossSalesMoney.
             /// </summary>
             /// <param name="grossSalesMoney"> grossSalesMoney. </param>
             /// <returns> Builder. </returns>
            public Builder GrossSalesMoney(Models.V1Money grossSalesMoney)
            {
                this.grossSalesMoney = grossSalesMoney;
                return this;
            }

             /// <summary>
             /// DiscountMoney.
             /// </summary>
             /// <param name="discountMoney"> discountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder DiscountMoney(Models.V1Money discountMoney)
            {
                this.discountMoney = discountMoney;
                return this;
            }

             /// <summary>
             /// NetSalesMoney.
             /// </summary>
             /// <param name="netSalesMoney"> netSalesMoney. </param>
             /// <returns> Builder. </returns>
            public Builder NetSalesMoney(Models.V1Money netSalesMoney)
            {
                this.netSalesMoney = netSalesMoney;
                return this;
            }

             /// <summary>
             /// Taxes.
             /// </summary>
             /// <param name="taxes"> taxes. </param>
             /// <returns> Builder. </returns>
            public Builder Taxes(IList<Models.V1PaymentTax> taxes)
            {
                shouldSerialize["taxes"] = true;
                this.taxes = taxes;
                return this;
            }

             /// <summary>
             /// Discounts.
             /// </summary>
             /// <param name="discounts"> discounts. </param>
             /// <returns> Builder. </returns>
            public Builder Discounts(IList<Models.V1PaymentDiscount> discounts)
            {
                shouldSerialize["discounts"] = true;
                this.discounts = discounts;
                return this;
            }

             /// <summary>
             /// Modifiers.
             /// </summary>
             /// <param name="modifiers"> modifiers. </param>
             /// <returns> Builder. </returns>
            public Builder Modifiers(IList<Models.V1PaymentModifier> modifiers)
            {
                shouldSerialize["modifiers"] = true;
                this.modifiers = modifiers;
                return this;
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
            public void UnsetQuantity()
            {
                this.shouldSerialize["quantity"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetNotes()
            {
                this.shouldSerialize["notes"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetItemVariationName()
            {
                this.shouldSerialize["item_variation_name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTaxes()
            {
                this.shouldSerialize["taxes"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDiscounts()
            {
                this.shouldSerialize["discounts"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetModifiers()
            {
                this.shouldSerialize["modifiers"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1PaymentItemization. </returns>
            public V1PaymentItemization Build()
            {
                return new V1PaymentItemization(shouldSerialize,
                    this.name,
                    this.quantity,
                    this.itemizationType,
                    this.itemDetail,
                    this.notes,
                    this.itemVariationName,
                    this.totalMoney,
                    this.singleQuantityMoney,
                    this.grossSalesMoney,
                    this.discountMoney,
                    this.netSalesMoney,
                    this.taxes,
                    this.discounts,
                    this.modifiers);
            }
        }
    }
}