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
    public class CatalogDiscount 
    {
        public CatalogDiscount(string name = null,
            string discountType = null,
            string percentage = null,
            Models.Money amountMoney = null,
            bool? pinRequired = null,
            string labelColor = null,
            string modifyTaxBasis = null)
        {
            Name = name;
            DiscountType = discountType;
            Percentage = percentage;
            AmountMoney = amountMoney;
            PinRequired = pinRequired;
            LabelColor = labelColor;
            ModifyTaxBasis = modifyTaxBasis;
        }

        /// <summary>
        /// The discount name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// How to apply a CatalogDiscount to a CatalogItem.
        /// </summary>
        [JsonProperty("discount_type")]
        public string DiscountType { get; }

        /// <summary>
        /// The percentage of the discount as a string representation of a decimal number, using a `.` as the decimal
        /// separator and without a `%` sign. A value of `7.5` corresponds to `7.5%`. Specify a percentage of `0` if `discount_type`
        /// is `VARIABLE_PERCENTAGE`.
        /// Do not use this field for amount-based or variable discounts.
        /// </summary>
        [JsonProperty("percentage")]
        public string Percentage { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("amount_money")]
        public Models.Money AmountMoney { get; }

        /// <summary>
        /// Indicates whether a mobile staff member needs to enter their PIN to apply the
        /// discount to a payment in the Square Point of Sale app.
        /// </summary>
        [JsonProperty("pin_required")]
        public bool? PinRequired { get; }

        /// <summary>
        /// The color of the discount display label in the Square Point of Sale app. This must be a valid hex color code.
        /// </summary>
        [JsonProperty("label_color")]
        public string LabelColor { get; }

        /// <summary>
        /// Getter for modify_tax_basis
        /// </summary>
        [JsonProperty("modify_tax_basis")]
        public string ModifyTaxBasis { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name)
                .DiscountType(DiscountType)
                .Percentage(Percentage)
                .AmountMoney(AmountMoney)
                .PinRequired(PinRequired)
                .LabelColor(LabelColor)
                .ModifyTaxBasis(ModifyTaxBasis);
            return builder;
        }

        public class Builder
        {
            private string name;
            private string discountType;
            private string percentage;
            private Models.Money amountMoney;
            private bool? pinRequired;
            private string labelColor;
            private string modifyTaxBasis;

            public Builder() { }
            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder DiscountType(string value)
            {
                discountType = value;
                return this;
            }

            public Builder Percentage(string value)
            {
                percentage = value;
                return this;
            }

            public Builder AmountMoney(Models.Money value)
            {
                amountMoney = value;
                return this;
            }

            public Builder PinRequired(bool? value)
            {
                pinRequired = value;
                return this;
            }

            public Builder LabelColor(string value)
            {
                labelColor = value;
                return this;
            }

            public Builder ModifyTaxBasis(string value)
            {
                modifyTaxBasis = value;
                return this;
            }

            public CatalogDiscount Build()
            {
                return new CatalogDiscount(name,
                    discountType,
                    percentage,
                    amountMoney,
                    pinRequired,
                    labelColor,
                    modifyTaxBasis);
            }
        }
    }
}