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
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The quantity of the item purchased. This can be a decimal value.
        /// </summary>
        [JsonProperty("quantity")]
        public double? Quantity { get; }

        /// <summary>
        /// Getter for itemization_type
        /// </summary>
        [JsonProperty("itemization_type")]
        public string ItemizationType { get; }

        /// <summary>
        /// V1PaymentItemDetail
        /// </summary>
        [JsonProperty("item_detail")]
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
        /// Getter for total_money
        /// </summary>
        [JsonProperty("total_money")]
        public Models.V1Money TotalMoney { get; }

        /// <summary>
        /// Getter for single_quantity_money
        /// </summary>
        [JsonProperty("single_quantity_money")]
        public Models.V1Money SingleQuantityMoney { get; }

        /// <summary>
        /// Getter for gross_sales_money
        /// </summary>
        [JsonProperty("gross_sales_money")]
        public Models.V1Money GrossSalesMoney { get; }

        /// <summary>
        /// Getter for discount_money
        /// </summary>
        [JsonProperty("discount_money")]
        public Models.V1Money DiscountMoney { get; }

        /// <summary>
        /// Getter for net_sales_money
        /// </summary>
        [JsonProperty("net_sales_money")]
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
            private IList<Models.V1PaymentTax> taxes = new List<Models.V1PaymentTax>();
            private IList<Models.V1PaymentDiscount> discounts = new List<Models.V1PaymentDiscount>();
            private IList<Models.V1PaymentModifier> modifiers = new List<Models.V1PaymentModifier>();

            public Builder() { }
            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder Quantity(double? value)
            {
                quantity = value;
                return this;
            }

            public Builder ItemizationType(string value)
            {
                itemizationType = value;
                return this;
            }

            public Builder ItemDetail(Models.V1PaymentItemDetail value)
            {
                itemDetail = value;
                return this;
            }

            public Builder Notes(string value)
            {
                notes = value;
                return this;
            }

            public Builder ItemVariationName(string value)
            {
                itemVariationName = value;
                return this;
            }

            public Builder TotalMoney(Models.V1Money value)
            {
                totalMoney = value;
                return this;
            }

            public Builder SingleQuantityMoney(Models.V1Money value)
            {
                singleQuantityMoney = value;
                return this;
            }

            public Builder GrossSalesMoney(Models.V1Money value)
            {
                grossSalesMoney = value;
                return this;
            }

            public Builder DiscountMoney(Models.V1Money value)
            {
                discountMoney = value;
                return this;
            }

            public Builder NetSalesMoney(Models.V1Money value)
            {
                netSalesMoney = value;
                return this;
            }

            public Builder Taxes(IList<Models.V1PaymentTax> value)
            {
                taxes = value;
                return this;
            }

            public Builder Discounts(IList<Models.V1PaymentDiscount> value)
            {
                discounts = value;
                return this;
            }

            public Builder Modifiers(IList<Models.V1PaymentModifier> value)
            {
                modifiers = value;
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