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
    public class CalculateLoyaltyPointsRequest 
    {
        public CalculateLoyaltyPointsRequest(string orderId = null,
            Models.Money transactionAmountMoney = null)
        {
            OrderId = orderId;
            TransactionAmountMoney = transactionAmountMoney;
        }

        /// <summary>
        /// The [order](#type-Order) ID for which to calculate the points.
        /// Specify this field if your application uses the Orders API to process orders.
        /// Otherwise, specify the `transaction_amount`.
        /// </summary>
        [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("transaction_amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TransactionAmountMoney { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderId(OrderId)
                .TransactionAmountMoney(TransactionAmountMoney);
            return builder;
        }

        public class Builder
        {
            private string orderId;
            private Models.Money transactionAmountMoney;



            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
                return this;
            }

            public Builder TransactionAmountMoney(Models.Money transactionAmountMoney)
            {
                this.transactionAmountMoney = transactionAmountMoney;
                return this;
            }

            public CalculateLoyaltyPointsRequest Build()
            {
                return new CalculateLoyaltyPointsRequest(orderId,
                    transactionAmountMoney);
            }
        }
    }
}