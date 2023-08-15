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
    /// OrderMoneyAmounts.
    /// </summary>
    public class OrderMoneyAmounts
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderMoneyAmounts"/> class.
        /// </summary>
        /// <param name="totalMoney">total_money.</param>
        /// <param name="taxMoney">tax_money.</param>
        /// <param name="discountMoney">discount_money.</param>
        /// <param name="tipMoney">tip_money.</param>
        /// <param name="serviceChargeMoney">service_charge_money.</param>
        public OrderMoneyAmounts(
            Models.Money totalMoney = null,
            Models.Money taxMoney = null,
            Models.Money discountMoney = null,
            Models.Money tipMoney = null,
            Models.Money serviceChargeMoney = null)
        {
            this.TotalMoney = totalMoney;
            this.TaxMoney = taxMoney;
            this.DiscountMoney = discountMoney;
            this.TipMoney = tipMoney;
            this.ServiceChargeMoney = serviceChargeMoney;
        }

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
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("tax_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TaxMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("discount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money DiscountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("tip_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TipMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("service_charge_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money ServiceChargeMoney { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderMoneyAmounts : ({string.Join(", ", toStringOutput)})";
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
            return obj is OrderMoneyAmounts other &&                ((this.TotalMoney == null && other.TotalMoney == null) || (this.TotalMoney?.Equals(other.TotalMoney) == true)) &&
                ((this.TaxMoney == null && other.TaxMoney == null) || (this.TaxMoney?.Equals(other.TaxMoney) == true)) &&
                ((this.DiscountMoney == null && other.DiscountMoney == null) || (this.DiscountMoney?.Equals(other.DiscountMoney) == true)) &&
                ((this.TipMoney == null && other.TipMoney == null) || (this.TipMoney?.Equals(other.TipMoney) == true)) &&
                ((this.ServiceChargeMoney == null && other.ServiceChargeMoney == null) || (this.ServiceChargeMoney?.Equals(other.ServiceChargeMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -685311361;
            hashCode = HashCode.Combine(this.TotalMoney, this.TaxMoney, this.DiscountMoney, this.TipMoney, this.ServiceChargeMoney);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TotalMoney = {(this.TotalMoney == null ? "null" : this.TotalMoney.ToString())}");
            toStringOutput.Add($"this.TaxMoney = {(this.TaxMoney == null ? "null" : this.TaxMoney.ToString())}");
            toStringOutput.Add($"this.DiscountMoney = {(this.DiscountMoney == null ? "null" : this.DiscountMoney.ToString())}");
            toStringOutput.Add($"this.TipMoney = {(this.TipMoney == null ? "null" : this.TipMoney.ToString())}");
            toStringOutput.Add($"this.ServiceChargeMoney = {(this.ServiceChargeMoney == null ? "null" : this.ServiceChargeMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TotalMoney(this.TotalMoney)
                .TaxMoney(this.TaxMoney)
                .DiscountMoney(this.DiscountMoney)
                .TipMoney(this.TipMoney)
                .ServiceChargeMoney(this.ServiceChargeMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Money totalMoney;
            private Models.Money taxMoney;
            private Models.Money discountMoney;
            private Models.Money tipMoney;
            private Models.Money serviceChargeMoney;

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
             /// TaxMoney.
             /// </summary>
             /// <param name="taxMoney"> taxMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TaxMoney(Models.Money taxMoney)
            {
                this.taxMoney = taxMoney;
                return this;
            }

             /// <summary>
             /// DiscountMoney.
             /// </summary>
             /// <param name="discountMoney"> discountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder DiscountMoney(Models.Money discountMoney)
            {
                this.discountMoney = discountMoney;
                return this;
            }

             /// <summary>
             /// TipMoney.
             /// </summary>
             /// <param name="tipMoney"> tipMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TipMoney(Models.Money tipMoney)
            {
                this.tipMoney = tipMoney;
                return this;
            }

             /// <summary>
             /// ServiceChargeMoney.
             /// </summary>
             /// <param name="serviceChargeMoney"> serviceChargeMoney. </param>
             /// <returns> Builder. </returns>
            public Builder ServiceChargeMoney(Models.Money serviceChargeMoney)
            {
                this.serviceChargeMoney = serviceChargeMoney;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderMoneyAmounts. </returns>
            public OrderMoneyAmounts Build()
            {
                return new OrderMoneyAmounts(
                    this.totalMoney,
                    this.taxMoney,
                    this.discountMoney,
                    this.tipMoney,
                    this.serviceChargeMoney);
            }
        }
    }
}