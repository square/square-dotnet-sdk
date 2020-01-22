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
    public class CreateRefundRequest 
    {
        public CreateRefundRequest(string idempotencyKey,
            string tenderId,
            Models.Money amountMoney,
            string reason = null)
        {
            IdempotencyKey = idempotencyKey;
            TenderId = tenderId;
            Reason = reason;
            AmountMoney = amountMoney;
        }

        /// <summary>
        /// A value you specify that uniquely identifies this
        /// refund among refunds you've created for the tender.
        /// If you're unsure whether a particular refund succeeded,
        /// you can reattempt it with the same idempotency key without
        /// worrying about duplicating the refund.
        /// See [Idempotency keys](#idempotencykeys) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The ID of the tender to refund.
        /// A [`Transaction`](#type-transaction) has one or more `tenders` (i.e., methods
        /// of payment) associated with it, and you refund each tender separately with
        /// the Connect API.
        /// </summary>
        [JsonProperty("tender_id")]
        public string TenderId { get; }

        /// <summary>
        /// A description of the reason for the refund.
        /// Default value: `Refund via API`
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; }

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

        public Builder ToBuilder()
        {
            var builder = new Builder(IdempotencyKey,
                TenderId,
                AmountMoney)
                .Reason(Reason);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;
            private string tenderId;
            private Models.Money amountMoney;
            private string reason;

            public Builder(string idempotencyKey,
                string tenderId,
                Models.Money amountMoney)
            {
                this.idempotencyKey = idempotencyKey;
                this.tenderId = tenderId;
                this.amountMoney = amountMoney;
            }
            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public Builder TenderId(string value)
            {
                tenderId = value;
                return this;
            }

            public Builder AmountMoney(Models.Money value)
            {
                amountMoney = value;
                return this;
            }

            public Builder Reason(string value)
            {
                reason = value;
                return this;
            }

            public CreateRefundRequest Build()
            {
                return new CreateRefundRequest(idempotencyKey,
                    tenderId,
                    amountMoney,
                    reason);
            }
        }
    }
}