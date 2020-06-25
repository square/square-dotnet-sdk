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
    public class RefundPaymentRequest 
    {
        public RefundPaymentRequest(string idempotencyKey,
            Models.Money amountMoney,
            string paymentId,
            Models.Money appFeeMoney = null,
            string reason = null)
        {
            IdempotencyKey = idempotencyKey;
            AmountMoney = amountMoney;
            AppFeeMoney = appFeeMoney;
            PaymentId = paymentId;
            Reason = reason;
        }

        /// <summary>
        /// A unique string that identifies this RefundPayment request. Key can be any valid string
        /// but must be unique for every RefundPayment request.
        /// For more information, see [Idempotency keys](https://developer.squareup.com/docs/working-with-apis/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

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
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("app_fee_money")]
        public Models.Money AppFeeMoney { get; }

        /// <summary>
        /// Unique ID of the payment being refunded.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        /// <summary>
        /// A description of the reason for the refund.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(IdempotencyKey,
                AmountMoney,
                PaymentId)
                .AppFeeMoney(AppFeeMoney)
                .Reason(Reason);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;
            private Models.Money amountMoney;
            private string paymentId;
            private Models.Money appFeeMoney;
            private string reason;

            public Builder(string idempotencyKey,
                Models.Money amountMoney,
                string paymentId)
            {
                this.idempotencyKey = idempotencyKey;
                this.amountMoney = amountMoney;
                this.paymentId = paymentId;
            }
            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public Builder AmountMoney(Models.Money value)
            {
                amountMoney = value;
                return this;
            }

            public Builder PaymentId(string value)
            {
                paymentId = value;
                return this;
            }

            public Builder AppFeeMoney(Models.Money value)
            {
                appFeeMoney = value;
                return this;
            }

            public Builder Reason(string value)
            {
                reason = value;
                return this;
            }

            public RefundPaymentRequest Build()
            {
                return new RefundPaymentRequest(idempotencyKey,
                    amountMoney,
                    paymentId,
                    appFeeMoney,
                    reason);
            }
        }
    }
}