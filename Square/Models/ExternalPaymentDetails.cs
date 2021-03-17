
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
        /// The type of external payment the seller received. It can be one of the following:
        /// - CHECK - Paid using a physical check.
        /// - BANK_TRANSFER - Paid using ACH or another bank transfer.
        /// - OTHER\_GIFT\_CARD - Paid using a non-Square gift card.
        /// - CRYPTO - Paid using a crypto currency.
        /// - SQUARE_CASH - Paid using Square Cash App.
        /// - SOCIAL - Paid using peer-to-peer payment applications.
        /// - EXTERNAL - A third-party application gathered this payment outside of Square.
        /// - EMONEY - Paid using an E-money provider.
        /// - CARD - A credit or debit card that Square does not support.
        /// - STORED_BALANCE - Use for house accounts, store credit, and so forth.
        /// - OTHER - A type not listed here.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// A description of the external payment source. For example, 
        /// "Food Delivery Service".
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; }

        /// <summary>
        /// An ID to associate the payment to its originating source.
        /// </summary>
        [JsonProperty("source_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceId { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("source_fee_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money SourceFeeMoney { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ExternalPaymentDetails : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Type = {(Type == null ? "null" : Type == string.Empty ? "" : Type)}");
            toStringOutput.Add($"Source = {(Source == null ? "null" : Source == string.Empty ? "" : Source)}");
            toStringOutput.Add($"SourceId = {(SourceId == null ? "null" : SourceId == string.Empty ? "" : SourceId)}");
            toStringOutput.Add($"SourceFeeMoney = {(SourceFeeMoney == null ? "null" : SourceFeeMoney.ToString())}");
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

            return obj is ExternalPaymentDetails other &&
                ((Type == null && other.Type == null) || (Type?.Equals(other.Type) == true)) &&
                ((Source == null && other.Source == null) || (Source?.Equals(other.Source) == true)) &&
                ((SourceId == null && other.SourceId == null) || (SourceId?.Equals(other.SourceId) == true)) &&
                ((SourceFeeMoney == null && other.SourceFeeMoney == null) || (SourceFeeMoney?.Equals(other.SourceFeeMoney) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 2146282005;

            if (Type != null)
            {
               hashCode += Type.GetHashCode();
            }

            if (Source != null)
            {
               hashCode += Source.GetHashCode();
            }

            if (SourceId != null)
            {
               hashCode += SourceId.GetHashCode();
            }

            if (SourceFeeMoney != null)
            {
               hashCode += SourceFeeMoney.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

            public Builder Source(string source)
            {
                this.source = source;
                return this;
            }

            public Builder SourceId(string sourceId)
            {
                this.sourceId = sourceId;
                return this;
            }

            public Builder SourceFeeMoney(Models.Money sourceFeeMoney)
            {
                this.sourceFeeMoney = sourceFeeMoney;
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