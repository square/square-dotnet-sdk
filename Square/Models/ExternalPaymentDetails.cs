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
    public class ExternalPaymentDetails 
    {
        public ExternalPaymentDetails(string type,
            string source,
            string sourceId = null,
            Models.Money sourceFeeMoney = null)
        {
            Type = type;
            Source = source;
            SourceId = sourceId;
            SourceFeeMoney = sourceFeeMoney;
        }

        /// <summary>
        /// The type of External payment which can be one of:
        /// CHECK - Paid by a physical check
        /// BANK_TRANSFER - Paid by ACH or other bank transfer
        /// OTHER_GIFT_CARD - Paid by a non-square gift card
        /// CRYPTO - Paid via a crypto currency
        /// SQUARE_CASH - Paid via Square Cash app
        /// SOCIAL - Venmo, WeChatPay, AliPay, etc.
        /// EXTERNAL - A 3rd party application gathered this payment outside of Square
        /// EMONEY - A Japanese e-money brand Square doesn’t support
        /// CREDIT/DEBIT - A credit/debit card Square doesn’t support
        /// OTHER - A type not listed here
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// A description of the source of the external payment, e.g. “Uber Eats”, “Stripe”, “Shopify”.
        /// Limit 255 characters
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; }

        /// <summary>
        /// An ID to associate this payment to its originating source
        /// Limit 255 characters.
        /// </summary>
        [JsonProperty("source_id")]
        public string SourceId { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("source_fee_money")]
        public Models.Money SourceFeeMoney { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Type,
                Source)
                .SourceId(SourceId)
                .SourceFeeMoney(SourceFeeMoney);
            return builder;
        }

        public class Builder
        {
            private string type;
            private string source;
            private string sourceId;
            private Models.Money sourceFeeMoney;

            public Builder(string type,
                string source)
            {
                this.type = type;
                this.source = source;
            }
            public Builder Type(string value)
            {
                type = value;
                return this;
            }

            public Builder Source(string value)
            {
                source = value;
                return this;
            }

            public Builder SourceId(string value)
            {
                sourceId = value;
                return this;
            }

            public Builder SourceFeeMoney(Models.Money value)
            {
                sourceFeeMoney = value;
                return this;
            }

            public ExternalPaymentDetails Build()
            {
                return new ExternalPaymentDetails(type,
                    source,
                    sourceId,
                    sourceFeeMoney);
            }
        }
    }
}