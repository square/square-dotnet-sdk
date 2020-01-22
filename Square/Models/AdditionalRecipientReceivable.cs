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
    public class AdditionalRecipientReceivable 
    {
        public AdditionalRecipientReceivable(string id,
            string transactionId,
            string transactionLocationId,
            Models.Money amountMoney,
            string createdAt = null,
            IList<Models.AdditionalRecipientReceivableRefund> refunds = null)
        {
            Id = id;
            TransactionId = transactionId;
            TransactionLocationId = transactionLocationId;
            AmountMoney = amountMoney;
            CreatedAt = createdAt;
            Refunds = refunds;
        }

        /// <summary>
        /// The additional recipient receivable's unique ID, issued by Square payments servers.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The ID of the transaction that the additional recipient receivable was applied to.
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; }

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
        /// The time when the additional recipient receivable was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// Any refunds of the receivable that have been applied.
        /// </summary>
        [JsonProperty("refunds")]
        public IList<Models.AdditionalRecipientReceivableRefund> Refunds { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Id,
                TransactionId,
                TransactionLocationId,
                AmountMoney)
                .CreatedAt(CreatedAt)
                .Refunds(Refunds);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string transactionId;
            private string transactionLocationId;
            private Models.Money amountMoney;
            private string createdAt;
            private IList<Models.AdditionalRecipientReceivableRefund> refunds = new List<Models.AdditionalRecipientReceivableRefund>();

            public Builder(string id,
                string transactionId,
                string transactionLocationId,
                Models.Money amountMoney)
            {
                this.id = id;
                this.transactionId = transactionId;
                this.transactionLocationId = transactionLocationId;
                this.amountMoney = amountMoney;
            }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder TransactionId(string value)
            {
                transactionId = value;
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

            public Builder Refunds(IList<Models.AdditionalRecipientReceivableRefund> value)
            {
                refunds = value;
                return this;
            }

            public AdditionalRecipientReceivable Build()
            {
                return new AdditionalRecipientReceivable(id,
                    transactionId,
                    transactionLocationId,
                    amountMoney,
                    createdAt,
                    refunds);
            }
        }
    }
}