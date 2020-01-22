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
        [JsonProperty("total_money")]
        public Models.Money TotalMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("tax_money")]
        public Models.Money TaxMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("discount_money")]
        public Models.Money DiscountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("tip_money")]
        public Models.Money TipMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("service_charge_money")]
        public Models.Money ServiceChargeMoney { get; }

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

            public Builder() { }
            public Builder TotalMoney(Models.Money value)
            {
                totalMoney = value;
                return this;
            }

            public Builder TaxMoney(Models.Money value)
            {
                taxMoney = value;
                return this;
            }

            public Builder DiscountMoney(Models.Money value)
            {
                discountMoney = value;
                return this;
            }

            public Builder TipMoney(Models.Money value)
            {
                tipMoney = value;
                return this;
            }

            public Builder ServiceChargeMoney(Models.Money value)
            {
                serviceChargeMoney = value;
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