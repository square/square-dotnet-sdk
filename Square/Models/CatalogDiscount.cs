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

namespace Square.Models
{
    /// <summary>
    /// CatalogDiscount.
    /// </summary>
    public class CatalogDiscount
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
        /// <param name="maximumAmountMoney">maximum_amount_money.</param>
        public CatalogDiscount(
            string name = null,
            string discountType = null,
            string percentage = null,
            Models.Money amountMoney = null,
            bool? pinRequired = null,
            string labelColor = null,
            string modifyTaxBasis = null,
            Models.Money maximumAmountMoney = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "percentage", false },
                { "pin_required", false },
                { "label_color", false }
            };

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            this.DiscountType = discountType;
            if (percentage != null)
            {
                shouldSerialize["percentage"] = true;
                this.Percentage = percentage;
            }

            this.AmountMoney = amountMoney;
            if (pinRequired != null)
            {
                shouldSerialize["pin_required"] = true;
                this.PinRequired = pinRequired;
            }

            if (labelColor != null)
            {
                shouldSerialize["label_color"] = true;
                this.LabelColor = labelColor;
            }

            this.ModifyTaxBasis = modifyTaxBasis;
            this.MaximumAmountMoney = maximumAmountMoney;
        }
        internal CatalogDiscount(Dictionary<string, bool> shouldSerialize,
            string name = null,
            string discountType = null,
            string percentage = null,
            Models.Money amountMoney = null,
            bool? pinRequired = null,
            string labelColor = null,
            string modifyTaxBasis = null,
            Models.Money maximumAmountMoney = null)
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
            DiscountType = discountType;
            Percentage = percentage;
            AmountMoney = amountMoney;
            PinRequired = pinRequired;
            LabelColor = labelColor;
            ModifyTaxBasis = modifyTaxBasis;
            MaximumAmountMoney = maximumAmountMoney;
        }

        /// <summary>
        /// The discount name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("name")]
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
        [JsonProperty("amount_money", NullValueHandling = NullValueHandling.Ignore)]
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
        /// Gets or sets ModifyTaxBasis.
        /// </summary>
        [JsonProperty("modify_tax_basis", NullValueHandling = NullValueHandling.Ignore)]
        public string ModifyTaxBasis { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("maximum_amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money MaximumAmountMoney { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogDiscount : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializePercentage()
        {
            return this.shouldSerialize["percentage"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePinRequired()
        {
            return this.shouldSerialize["pin_required"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLabelColor()
        {
            return this.shouldSerialize["label_color"];
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
            return obj is CatalogDiscount other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.DiscountType == null && other.DiscountType == null) || (this.DiscountType?.Equals(other.DiscountType) == true)) &&
                ((this.Percentage == null && other.Percentage == null) || (this.Percentage?.Equals(other.Percentage) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.PinRequired == null && other.PinRequired == null) || (this.PinRequired?.Equals(other.PinRequired) == true)) &&
                ((this.LabelColor == null && other.LabelColor == null) || (this.LabelColor?.Equals(other.LabelColor) == true)) &&
                ((this.ModifyTaxBasis == null && other.ModifyTaxBasis == null) || (this.ModifyTaxBasis?.Equals(other.ModifyTaxBasis) == true)) &&
                ((this.MaximumAmountMoney == null && other.MaximumAmountMoney == null) || (this.MaximumAmountMoney?.Equals(other.MaximumAmountMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1315753358;
            hashCode = HashCode.Combine(this.Name, this.DiscountType, this.Percentage, this.AmountMoney, this.PinRequired, this.LabelColor, this.ModifyTaxBasis);

            hashCode = HashCode.Combine(hashCode, this.MaximumAmountMoney);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.DiscountType = {(this.DiscountType == null ? "null" : this.DiscountType.ToString())}");
            toStringOutput.Add($"this.Percentage = {(this.Percentage == null ? "null" : this.Percentage)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.PinRequired = {(this.PinRequired == null ? "null" : this.PinRequired.ToString())}");
            toStringOutput.Add($"this.LabelColor = {(this.LabelColor == null ? "null" : this.LabelColor)}");
            toStringOutput.Add($"this.ModifyTaxBasis = {(this.ModifyTaxBasis == null ? "null" : this.ModifyTaxBasis.ToString())}");
            toStringOutput.Add($"this.MaximumAmountMoney = {(this.MaximumAmountMoney == null ? "null" : this.MaximumAmountMoney.ToString())}");
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
                .ModifyTaxBasis(this.ModifyTaxBasis)
                .MaximumAmountMoney(this.MaximumAmountMoney);
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
                { "percentage", false },
                { "pin_required", false },
                { "label_color", false },
            };

            private string name;
            private string discountType;
            private string percentage;
            private Models.Money amountMoney;
            private bool? pinRequired;
            private string labelColor;
            private string modifyTaxBasis;
            private Models.Money maximumAmountMoney;

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
                shouldSerialize["percentage"] = true;
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
                shouldSerialize["pin_required"] = true;
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
                shouldSerialize["label_color"] = true;
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
             /// MaximumAmountMoney.
             /// </summary>
             /// <param name="maximumAmountMoney"> maximumAmountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder MaximumAmountMoney(Models.Money maximumAmountMoney)
            {
                this.maximumAmountMoney = maximumAmountMoney;
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
            public void UnsetPercentage()
            {
                this.shouldSerialize["percentage"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPinRequired()
            {
                this.shouldSerialize["pin_required"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLabelColor()
            {
                this.shouldSerialize["label_color"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogDiscount. </returns>
            public CatalogDiscount Build()
            {
                return new CatalogDiscount(shouldSerialize,
                    this.name,
                    this.discountType,
                    this.percentage,
                    this.amountMoney,
                    this.pinRequired,
                    this.labelColor,
                    this.modifyTaxBasis,
                    this.maximumAmountMoney);
            }
        }
    }
}