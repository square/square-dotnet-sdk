
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
    public class V1PaymentItemization 
    {
        public V1PaymentItemization(string name = null,
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
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// The quantity of the item purchased. This can be a decimal value.
        /// </summary>
        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public double? Quantity { get; }

        /// <summary>
        /// Getter for itemization_type
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
        [JsonProperty("notes", NullValueHandling = NullValueHandling.Ignore)]
        public string Notes { get; }

        /// <summary>
        /// The name of the item variation purchased, if any.
        /// </summary>
        [JsonProperty("item_variation_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemVariationName { get; }

        /// <summary>
        /// Getter for total_money
        /// </summary>
        [JsonProperty("total_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TotalMoney { get; }

        /// <summary>
        /// Getter for single_quantity_money
        /// </summary>
        [JsonProperty("single_quantity_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money SingleQuantityMoney { get; }

        /// <summary>
        /// Getter for gross_sales_money
        /// </summary>
        [JsonProperty("gross_sales_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money GrossSalesMoney { get; }

        /// <summary>
        /// Getter for discount_money
        /// </summary>
        [JsonProperty("discount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money DiscountMoney { get; }

        /// <summary>
        /// Getter for net_sales_money
        /// </summary>
        [JsonProperty("net_sales_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money NetSalesMoney { get; }

        /// <summary>
        /// All taxes applied to this itemization.
        /// </summary>
        [JsonProperty("taxes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1PaymentTax> Taxes { get; }

        /// <summary>
        /// All discounts applied to this itemization.
        /// </summary>
        [JsonProperty("discounts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1PaymentDiscount> Discounts { get; }

        /// <summary>
        /// All modifier options applied to this itemization.
        /// </summary>
        [JsonProperty("modifiers", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1PaymentModifier> Modifiers { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1PaymentItemization : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
            toStringOutput.Add($"Quantity = {(Quantity == null ? "null" : Quantity.ToString())}");
            toStringOutput.Add($"ItemizationType = {(ItemizationType == null ? "null" : ItemizationType.ToString())}");
            toStringOutput.Add($"ItemDetail = {(ItemDetail == null ? "null" : ItemDetail.ToString())}");
            toStringOutput.Add($"Notes = {(Notes == null ? "null" : Notes == string.Empty ? "" : Notes)}");
            toStringOutput.Add($"ItemVariationName = {(ItemVariationName == null ? "null" : ItemVariationName == string.Empty ? "" : ItemVariationName)}");
            toStringOutput.Add($"TotalMoney = {(TotalMoney == null ? "null" : TotalMoney.ToString())}");
            toStringOutput.Add($"SingleQuantityMoney = {(SingleQuantityMoney == null ? "null" : SingleQuantityMoney.ToString())}");
            toStringOutput.Add($"GrossSalesMoney = {(GrossSalesMoney == null ? "null" : GrossSalesMoney.ToString())}");
            toStringOutput.Add($"DiscountMoney = {(DiscountMoney == null ? "null" : DiscountMoney.ToString())}");
            toStringOutput.Add($"NetSalesMoney = {(NetSalesMoney == null ? "null" : NetSalesMoney.ToString())}");
            toStringOutput.Add($"Taxes = {(Taxes == null ? "null" : $"[{ string.Join(", ", Taxes)} ]")}");
            toStringOutput.Add($"Discounts = {(Discounts == null ? "null" : $"[{ string.Join(", ", Discounts)} ]")}");
            toStringOutput.Add($"Modifiers = {(Modifiers == null ? "null" : $"[{ string.Join(", ", Modifiers)} ]")}");
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

            return obj is V1PaymentItemization other &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true)) &&
                ((Quantity == null && other.Quantity == null) || (Quantity?.Equals(other.Quantity) == true)) &&
                ((ItemizationType == null && other.ItemizationType == null) || (ItemizationType?.Equals(other.ItemizationType) == true)) &&
                ((ItemDetail == null && other.ItemDetail == null) || (ItemDetail?.Equals(other.ItemDetail) == true)) &&
                ((Notes == null && other.Notes == null) || (Notes?.Equals(other.Notes) == true)) &&
                ((ItemVariationName == null && other.ItemVariationName == null) || (ItemVariationName?.Equals(other.ItemVariationName) == true)) &&
                ((TotalMoney == null && other.TotalMoney == null) || (TotalMoney?.Equals(other.TotalMoney) == true)) &&
                ((SingleQuantityMoney == null && other.SingleQuantityMoney == null) || (SingleQuantityMoney?.Equals(other.SingleQuantityMoney) == true)) &&
                ((GrossSalesMoney == null && other.GrossSalesMoney == null) || (GrossSalesMoney?.Equals(other.GrossSalesMoney) == true)) &&
                ((DiscountMoney == null && other.DiscountMoney == null) || (DiscountMoney?.Equals(other.DiscountMoney) == true)) &&
                ((NetSalesMoney == null && other.NetSalesMoney == null) || (NetSalesMoney?.Equals(other.NetSalesMoney) == true)) &&
                ((Taxes == null && other.Taxes == null) || (Taxes?.Equals(other.Taxes) == true)) &&
                ((Discounts == null && other.Discounts == null) || (Discounts?.Equals(other.Discounts) == true)) &&
                ((Modifiers == null && other.Modifiers == null) || (Modifiers?.Equals(other.Modifiers) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1047875174;

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            if (Quantity != null)
            {
               hashCode += Quantity.GetHashCode();
            }

            if (ItemizationType != null)
            {
               hashCode += ItemizationType.GetHashCode();
            }

            if (ItemDetail != null)
            {
               hashCode += ItemDetail.GetHashCode();
            }

            if (Notes != null)
            {
               hashCode += Notes.GetHashCode();
            }

            if (ItemVariationName != null)
            {
               hashCode += ItemVariationName.GetHashCode();
            }

            if (TotalMoney != null)
            {
               hashCode += TotalMoney.GetHashCode();
            }

            if (SingleQuantityMoney != null)
            {
               hashCode += SingleQuantityMoney.GetHashCode();
            }

            if (GrossSalesMoney != null)
            {
               hashCode += GrossSalesMoney.GetHashCode();
            }

            if (DiscountMoney != null)
            {
               hashCode += DiscountMoney.GetHashCode();
            }

            if (NetSalesMoney != null)
            {
               hashCode += NetSalesMoney.GetHashCode();
            }

            if (Taxes != null)
            {
               hashCode += Taxes.GetHashCode();
            }

            if (Discounts != null)
            {
               hashCode += Discounts.GetHashCode();
            }

            if (Modifiers != null)
            {
               hashCode += Modifiers.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name)
                .Quantity(Quantity)
                .ItemizationType(ItemizationType)
                .ItemDetail(ItemDetail)
                .Notes(Notes)
                .ItemVariationName(ItemVariationName)
                .TotalMoney(TotalMoney)
                .SingleQuantityMoney(SingleQuantityMoney)
                .GrossSalesMoney(GrossSalesMoney)
                .DiscountMoney(DiscountMoney)
                .NetSalesMoney(NetSalesMoney)
                .Taxes(Taxes)
                .Discounts(Discounts)
                .Modifiers(Modifiers);
            return builder;
        }

        public class Builder
        {
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



            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder Quantity(double? quantity)
            {
                this.quantity = quantity;
                return this;
            }

            public Builder ItemizationType(string itemizationType)
            {
                this.itemizationType = itemizationType;
                return this;
            }

            public Builder ItemDetail(Models.V1PaymentItemDetail itemDetail)
            {
                this.itemDetail = itemDetail;
                return this;
            }

            public Builder Notes(string notes)
            {
                this.notes = notes;
                return this;
            }

            public Builder ItemVariationName(string itemVariationName)
            {
                this.itemVariationName = itemVariationName;
                return this;
            }

            public Builder TotalMoney(Models.V1Money totalMoney)
            {
                this.totalMoney = totalMoney;
                return this;
            }

            public Builder SingleQuantityMoney(Models.V1Money singleQuantityMoney)
            {
                this.singleQuantityMoney = singleQuantityMoney;
                return this;
            }

            public Builder GrossSalesMoney(Models.V1Money grossSalesMoney)
            {
                this.grossSalesMoney = grossSalesMoney;
                return this;
            }

            public Builder DiscountMoney(Models.V1Money discountMoney)
            {
                this.discountMoney = discountMoney;
                return this;
            }

            public Builder NetSalesMoney(Models.V1Money netSalesMoney)
            {
                this.netSalesMoney = netSalesMoney;
                return this;
            }

            public Builder Taxes(IList<Models.V1PaymentTax> taxes)
            {
                this.taxes = taxes;
                return this;
            }

            public Builder Discounts(IList<Models.V1PaymentDiscount> discounts)
            {
                this.discounts = discounts;
                return this;
            }

            public Builder Modifiers(IList<Models.V1PaymentModifier> modifiers)
            {
                this.modifiers = modifiers;
                return this;
            }

            public V1PaymentItemization Build()
            {
                return new V1PaymentItemization(name,
                    quantity,
                    itemizationType,
                    itemDetail,
                    notes,
                    itemVariationName,
                    totalMoney,
                    singleQuantityMoney,
                    grossSalesMoney,
                    discountMoney,
                    netSalesMoney,
                    taxes,
                    discounts,
                    modifiers);
            }
        }
    }
}