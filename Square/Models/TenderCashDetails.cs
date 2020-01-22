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
    public class TenderCashDetails 
    {
        public TenderCashDetails(Models.Money buyerTenderedMoney = null,
            Models.Money changeBackMoney = null)
        {
            BuyerTenderedMoney = buyerTenderedMoney;
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
        [JsonProperty("buyer_tendered_money")]
        public Models.Money BuyerTenderedMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("change_back_money")]
        public Models.Money ChangeBackMoney { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BuyerTenderedMoney(BuyerTenderedMoney)
                .ChangeBackMoney(ChangeBackMoney);
            return builder;
        }

        public class Builder
        {
            private Models.Money buyerTenderedMoney;
            private Models.Money changeBackMoney;

            public Builder() { }
            public Builder BuyerTenderedMoney(Models.Money value)
            {
                buyerTenderedMoney = value;
                return this;
            }

            public Builder ChangeBackMoney(Models.Money value)
            {
                changeBackMoney = value;
                return this;
            }

            public TenderCashDetails Build()
            {
                return new TenderCashDetails(buyerTenderedMoney,
                    changeBackMoney);
            }
        }
    }
}