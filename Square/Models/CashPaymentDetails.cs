
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
    public class CashPaymentDetails 
    {
        public CashPaymentDetails(Models.Money buyerSuppliedMoney,
            Models.Money changeBackMoney = null)
        {
            BuyerSuppliedMoney = buyerSuppliedMoney;
            ChangeBackMoney = changeBackMoney;
        }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("buyer_supplied_money")]
        public Models.Money BuyerSuppliedMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("change_back_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money ChangeBackMoney { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CashPaymentDetails : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"BuyerSuppliedMoney = {(BuyerSuppliedMoney == null ? "null" : BuyerSuppliedMoney.ToString())}");
            toStringOutput.Add($"ChangeBackMoney = {(ChangeBackMoney == null ? "null" : ChangeBackMoney.ToString())}");
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

            return obj is CashPaymentDetails other &&
                ((BuyerSuppliedMoney == null && other.BuyerSuppliedMoney == null) || (BuyerSuppliedMoney?.Equals(other.BuyerSuppliedMoney) == true)) &&
                ((ChangeBackMoney == null && other.ChangeBackMoney == null) || (ChangeBackMoney?.Equals(other.ChangeBackMoney) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1355903831;

            if (BuyerSuppliedMoney != null)
            {
               hashCode += BuyerSuppliedMoney.GetHashCode();
            }

            if (ChangeBackMoney != null)
            {
               hashCode += ChangeBackMoney.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(BuyerSuppliedMoney)
                .ChangeBackMoney(ChangeBackMoney);
            return builder;
        }

        public class Builder
        {
            private Models.Money buyerSuppliedMoney;
            private Models.Money changeBackMoney;

            public Builder(Models.Money buyerSuppliedMoney)
            {
                this.buyerSuppliedMoney = buyerSuppliedMoney;
            }

            public Builder BuyerSuppliedMoney(Models.Money buyerSuppliedMoney)
            {
                this.buyerSuppliedMoney = buyerSuppliedMoney;
                return this;
            }

            public Builder ChangeBackMoney(Models.Money changeBackMoney)
            {
                this.changeBackMoney = changeBackMoney;
                return this;
            }

            public CashPaymentDetails Build()
            {
                return new CashPaymentDetails(buyerSuppliedMoney,
                    changeBackMoney);
            }
        }
    }
}