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
    public class AdditionalRecipientReceivableRefund 
    {
        public AdditionalRecipientReceivableRefund(string id,
            string receivableId,
            string refundId,
            string transactionLocationId,
            Models.Money amountMoney,
            string createdAt = null)
        {
            Id = id;
            ReceivableId = receivableId;
            RefundId = refundId;
            TransactionLocationId = transactionLocationId;
            AmountMoney = amountMoney;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// The receivable refund's unique ID, issued by Square payments servers.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The ID of the receivable that the refund was applied to.
        /// </summary>
        [JsonProperty("receivable_id")]
        public string ReceivableId { get; }

        /// <summary>
        /// The ID of the refund that is associated to this receivable refund.
        /// </summary>
        [JsonProperty("refund_id")]
        public string RefundId { get; }

        /// <summary>
        /// The ID of the location that created the receivable. This is the location ID on the associated transaction.
        /// </summary>
        [JsonProperty("transaction_location_id")]
        public string TransactionLocationId { get; }

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
        /// The time when the refund was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Id,
                ReceivableId,
                RefundId,
                TransactionLocationId,
                AmountMoney)
                .CreatedAt(CreatedAt);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string receivableId;
            private string refundId;
            private string transactionLocationId;
            private Models.Money amountMoney;
            private string createdAt;

            public Builder(string id,
                string receivableId,
                string refundId,
                string transactionLocationId,
                Models.Money amountMoney)
            {
                this.id = id;
                this.receivableId = receivableId;
                this.refundId = refundId;
                this.transactionLocationId = transactionLocationId;
                this.amountMoney = amountMoney;
            }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder ReceivableId(string value)
            {
                receivableId = value;
                return this;
            }

            public Builder RefundId(string value)
            {
                refundId = value;
                return this;
            }

            public Builder TransactionLocationId(string value)
            {
                transactionLocationId = value;
                return this;
            }

            public Builder AmountMoney(Models.Money value)
            {
                amountMoney = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public AdditionalRecipientReceivableRefund Build()
            {
                return new AdditionalRecipientReceivableRefund(id,
                    receivableId,
                    refundId,
                    transactionLocationId,
                    amountMoney,
                    createdAt);
            }
        }
    }
}