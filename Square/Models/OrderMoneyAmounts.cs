
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
    public class OrderMoneyAmounts 
    {
        public OrderMoneyAmounts(Models.Money totalMoney = null,
            Models.Money taxMoney = null,
            Models.Money discountMoney = null,
            Models.Money tipMoney = null,
            Models.Money serviceChargeMoney = null)
        {
            TotalMoney = totalMoney;
            TaxMoney = taxMoney;
            DiscountMoney = discountMoney;
            TipMoney = tipMoney;
            ServiceChargeMoney = serviceChargeMoney;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderMoneyAmounts : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"TotalMoney = {(TotalMoney == null ? "null" : TotalMoney.ToString())}");
            toStringOutput.Add($"TaxMoney = {(TaxMoney == null ? "null" : TaxMoney.ToString())}");
            toStringOutput.Add($"DiscountMoney = {(DiscountMoney == null ? "null" : DiscountMoney.ToString())}");
            toStringOutput.Add($"TipMoney = {(TipMoney == null ? "null" : TipMoney.ToString())}");
            toStringOutput.Add($"ServiceChargeMoney = {(ServiceChargeMoney == null ? "null" : ServiceChargeMoney.ToString())}");
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

            return obj is OrderMoneyAmounts other &&
                ((TotalMoney == null && other.TotalMoney == null) || (TotalMoney?.Equals(other.TotalMoney) == true)) &&
                ((TaxMoney == null && other.TaxMoney == null) || (TaxMoney?.Equals(other.TaxMoney) == true)) &&
                ((DiscountMoney == null && other.DiscountMoney == null) || (DiscountMoney?.Equals(other.DiscountMoney) == true)) &&
                ((TipMoney == null && other.TipMoney == null) || (TipMoney?.Equals(other.TipMoney) == true)) &&
                ((ServiceChargeMoney == null && other.ServiceChargeMoney == null) || (ServiceChargeMoney?.Equals(other.ServiceChargeMoney) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -685311361;

            if (TotalMoney != null)
            {
               hashCode += TotalMoney.GetHashCode();
            }

            if (TaxMoney != null)
            {
               hashCode += TaxMoney.GetHashCode();
            }

            if (DiscountMoney != null)
            {
               hashCode += DiscountMoney.GetHashCode();
            }

            if (TipMoney != null)
            {
               hashCode += TipMoney.GetHashCode();
            }

            if (ServiceChargeMoney != null)
            {
               hashCode += ServiceChargeMoney.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TotalMoney(TotalMoney)
                .TaxMoney(TaxMoney)
                .DiscountMoney(DiscountMoney)
                .TipMoney(TipMoney)
                .ServiceChargeMoney(ServiceChargeMoney);
            return builder;
        }

        public class Builder
        {
            private Models.Money totalMoney;
            private Models.Money taxMoney;
            private Models.Money discountMoney;
            private Models.Money tipMoney;
            private Models.Money serviceChargeMoney;



            public Builder TotalMoney(Models.Money totalMoney)
            {
                this.totalMoney = totalMoney;
                return this;
            }

            public Builder TaxMoney(Models.Money taxMoney)
            {
                this.taxMoney = taxMoney;
                return this;
            }

            public Builder DiscountMoney(Models.Money discountMoney)
            {
                this.discountMoney = discountMoney;
                return this;
            }

            public Builder TipMoney(Models.Money tipMoney)
            {
                this.tipMoney = tipMoney;
                return this;
            }

            public Builder ServiceChargeMoney(Models.Money serviceChargeMoney)
            {
                this.serviceChargeMoney = serviceChargeMoney;
                return this;
            }

            public OrderMoneyAmounts Build()
            {
                return new OrderMoneyAmounts(totalMoney,
                    taxMoney,
                    discountMoney,
                    tipMoney,
                    serviceChargeMoney);
            }
        }
    }
}