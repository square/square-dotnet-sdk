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
    /// CatalogDiscount.
    /// </summary>
    public class CatalogDiscount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogDiscount"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="discountType">discount_type.</param>
        /// <param name="percentage">percentage.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="pinRequired">pin_required.</param>
        /// <param name="labelColor">label_color.</param>
        /// <param name="modifyTaxBasis">modify_tax_basis.</param>
        public CatalogDiscount(
            string name = null,
            string discountType = null,
            string percentage = null,
            Models.Money amountMoney = null,
            bool? pinRequired = null,
            string labelColor = null,
            string modifyTaxBasis = null)
        {
            this.Name = name;
            this.DiscountType = discountType;
            this.Percentage = percentage;
            this.AmountMoney = amountMoney;
            this.PinRequired = pinRequired;
            this.LabelColor = labelColor;
            this.ModifyTaxBasis = modifyTaxBasis;
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
        /// Gets or sets ModifyTaxBasis.
        /// </summary>
        [JsonProperty("modify_tax_basis", NullValueHandling = NullValueHandling.Ignore)]
        public string ModifyTaxBasis { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogDiscount : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogDiscount other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.DiscountType == null && other.DiscountType == null) || (this.DiscountType?.Equals(other.DiscountType) == true)) &&
                ((this.Percentage == null && other.Percentage == null) || (this.Percentage?.Equals(other.Percentage) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.PinRequired == null && other.PinRequired == null) || (this.PinRequired?.Equals(other.PinRequired) == true)) &&
                ((this.LabelColor == null && other.LabelColor == null) || (this.LabelColor?.Equals(other.LabelColor) == true)) &&
                ((this.ModifyTaxBasis == null && other.ModifyTaxBasis == null) || (this.ModifyTaxBasis?.Equals(other.ModifyTaxBasis) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -419430818;
            hashCode = HashCode.Combine(this.Name, this.DiscountType, this.Percentage, this.AmountMoney, this.PinRequired, this.LabelColor, this.ModifyTaxBasis);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.DiscountType = {(this.DiscountType == null ? "null" : this.DiscountType.ToString())}");
            toStringOutput.Add($"this.Percentage = {(this.Percentage == null ? "null" : this.Percentage == string.Empty ? "" : this.Percentage)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.PinRequired = {(this.PinRequired == null ? "null" : this.PinRequired.ToString())}");
            toStringOutput.Add($"this.LabelColor = {(this.LabelColor == null ? "null" : this.LabelColor == string.Empty ? "" : this.LabelColor)}");
            toStringOutput.Add($"this.ModifyTaxBasis = {(this.ModifyTaxBasis == null ? "null" : this.ModifyTaxBasis.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name)
                .DiscountType(this.DiscountType)
                .Percentage(this.Percentage)
                .AmountMoney(this.AmountMoney)
                .PinRequired(this.PinRequired)
                .LabelColor(this.LabelColor)
                .ModifyTaxBasis(this.ModifyTaxBasis);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string name;
            private string discountType;
            private string percentage;
            private Models.Money amountMoney;
            private bool? pinRequired;
            private string labelColor;
            private string modifyTaxBasis;

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
             /// DiscountType.
             /// </summary>
             /// <param name="discountType"> discountType. </param>
             /// <returns> Builder. </returns>
            public Builder DiscountType(string discountType)
            {
                this.discountType = discountType;
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
             /// PinRequired.
             /// </summary>
             /// <param name="pinRequired"> pinRequired. </param>
             /// <returns> Builder. </returns>
            public Builder PinRequired(bool? pinRequired)
            {
                this.pinRequired = pinRequired;
                return this;
            }

             /// <summary>
             /// LabelColor.
             /// </summary>
             /// <param name="labelColor"> labelColor. </param>
             /// <returns> Builder. </returns>
            public Builder LabelColor(string labelColor)
            {
                this.labelColor = labelColor;
                return this;
            }

             /// <summary>
             /// ModifyTaxBasis.
             /// </summary>
             /// <param name="modifyTaxBasis"> modifyTaxBasis. </param>
             /// <returns> Builder. </returns>
            public Builder ModifyTaxBasis(string modifyTaxBasis)
            {
                this.modifyTaxBasis = modifyTaxBasis;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogDiscount. </returns>
            public CatalogDiscount Build()
            {
                return new CatalogDiscount(
                    this.name,
                    this.discountType,
                    this.percentage,
                    this.amountMoney,
                    this.pinRequired,
                    this.labelColor,
                    this.modifyTaxBasis);
            }
        }
    }
}