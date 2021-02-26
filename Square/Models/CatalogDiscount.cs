
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
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// How to apply a CatalogDiscount to a CatalogItem.
        /// </summary>
        [JsonProperty("discount_type", NullValueHandling = NullValueHandling.Ignore)]
        public string DiscountType { get; }

        /// <summary>
        /// The percentage of the discount as a string representation of a decimal number, using a `.` as the decimal
        /// separator and without a `%` sign. A value of `7.5` corresponds to `7.5%`. Specify a percentage of `0` if `discount_type`
        /// is `VARIABLE_PERCENTAGE`.
        /// Do not use this field for amount-based or variable discounts.
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
        /// Indicates whether a mobile staff member needs to enter their PIN to apply the
        /// discount to a payment in the Square Point of Sale app.
        /// </summary>
        [JsonProperty("pin_required", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PinRequired { get; }

        /// <summary>
        /// The color of the discount display label in the Square Point of Sale app. This must be a valid hex color code.
        /// </summary>
        [JsonProperty("label_color", NullValueHandling = NullValueHandling.Ignore)]
        public string LabelColor { get; }

        /// <summary>
        /// Getter for modify_tax_basis
        /// </summary>
        [JsonProperty("modify_tax_basis", NullValueHandling = NullValueHandling.Ignore)]
        public string ModifyTaxBasis { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogDiscount : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
            toStringOutput.Add($"DiscountType = {(DiscountType == null ? "null" : DiscountType.ToString())}");
            toStringOutput.Add($"Percentage = {(Percentage == null ? "null" : Percentage == string.Empty ? "" : Percentage)}");
            toStringOutput.Add($"AmountMoney = {(AmountMoney == null ? "null" : AmountMoney.ToString())}");
            toStringOutput.Add($"PinRequired = {(PinRequired == null ? "null" : PinRequired.ToString())}");
            toStringOutput.Add($"LabelColor = {(LabelColor == null ? "null" : LabelColor == string.Empty ? "" : LabelColor)}");
            toStringOutput.Add($"ModifyTaxBasis = {(ModifyTaxBasis == null ? "null" : ModifyTaxBasis.ToString())}");
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

            return obj is CatalogDiscount other &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true)) &&
                ((DiscountType == null && other.DiscountType == null) || (DiscountType?.Equals(other.DiscountType) == true)) &&
                ((Percentage == null && other.Percentage == null) || (Percentage?.Equals(other.Percentage) == true)) &&
                ((AmountMoney == null && other.AmountMoney == null) || (AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((PinRequired == null && other.PinRequired == null) || (PinRequired?.Equals(other.PinRequired) == true)) &&
                ((LabelColor == null && other.LabelColor == null) || (LabelColor?.Equals(other.LabelColor) == true)) &&
                ((ModifyTaxBasis == null && other.ModifyTaxBasis == null) || (ModifyTaxBasis?.Equals(other.ModifyTaxBasis) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -419430818;

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            if (DiscountType != null)
            {
               hashCode += DiscountType.GetHashCode();
            }

            if (Percentage != null)
            {
               hashCode += Percentage.GetHashCode();
            }

            if (AmountMoney != null)
            {
               hashCode += AmountMoney.GetHashCode();
            }

            if (PinRequired != null)
            {
               hashCode += PinRequired.GetHashCode();
            }

            if (LabelColor != null)
            {
               hashCode += LabelColor.GetHashCode();
            }

            if (ModifyTaxBasis != null)
            {
               hashCode += ModifyTaxBasis.GetHashCode();
            }

            return hashCode;
        }

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



            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder DiscountType(string discountType)
            {
                this.discountType = discountType;
                return this;
            }

            public Builder Percentage(string percentage)
            {
                this.percentage = percentage;
                return this;
            }

            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

            public Builder PinRequired(bool? pinRequired)
            {
                this.pinRequired = pinRequired;
                return this;
            }

            public Builder LabelColor(string labelColor)
            {
                this.labelColor = labelColor;
                return this;
            }

            public Builder ModifyTaxBasis(string modifyTaxBasis)
            {
                this.modifyTaxBasis = modifyTaxBasis;
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