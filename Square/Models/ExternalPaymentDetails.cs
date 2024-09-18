using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// ExternalPaymentDetails.
    /// </summary>
    public class ExternalPaymentDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalPaymentDetails"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="source">source.</param>
        /// <param name="sourceId">source_id.</param>
        /// <param name="sourceFeeMoney">source_fee_money.</param>
        public ExternalPaymentDetails(
            string type,
            string source,
            string sourceId = null,
            Models.Money sourceFeeMoney = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "source_id", false }
            };

            this.Type = type;
            this.Source = source;
            if (sourceId != null)
            {
                shouldSerialize["source_id"] = true;
                this.SourceId = sourceId;
            }

            this.SourceFeeMoney = sourceFeeMoney;
        }
        internal ExternalPaymentDetails(Dictionary<string, bool> shouldSerialize,
            string type,
            string source,
            string sourceId = null,
            Models.Money sourceFeeMoney = null)
        {
            this.shouldSerialize = shouldSerialize;
            Type = type;
            Source = source;
            SourceId = sourceId;
            SourceFeeMoney = sourceFeeMoney;
        }

        /// <summary>
        /// The type of external payment the seller received. It can be one of the following:
        /// - CHECK - Paid using a physical check.
        /// - BANK_TRANSFER - Paid using external bank transfer.
        /// - OTHER\_GIFT\_CARD - Paid using a non-Square gift card.
        /// - CRYPTO - Paid using a crypto currency.
        /// - SQUARE_CASH - Paid using Square Cash App.
        /// - SOCIAL - Paid using peer-to-peer payment applications.
        /// - EXTERNAL - A third-party application gathered this payment outside of Square.
        /// - EMONEY - Paid using an E-money provider.
        /// - CARD - A credit or debit card that Square does not support.
        /// - STORED_BALANCE - Use for house accounts, store credit, and so forth.
        /// - FOOD_VOUCHER - Restaurant voucher provided by employers to employees to pay for meals
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
        [JsonProperty("source_fee_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money SourceFeeMoney { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ExternalPaymentDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSourceId()
        {
            return this.shouldSerialize["source_id"];
        }

        /// <inheritdoc/>
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
            return obj is ExternalPaymentDetails other &&                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Source == null && other.Source == null) || (this.Source?.Equals(other.Source) == true)) &&
                ((this.SourceId == null && other.SourceId == null) || (this.SourceId?.Equals(other.SourceId) == true)) &&
                ((this.SourceFeeMoney == null && other.SourceFeeMoney == null) || (this.SourceFeeMoney?.Equals(other.SourceFeeMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 2146282005;
            hashCode = HashCode.Combine(this.Type, this.Source, this.SourceId, this.SourceFeeMoney);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type)}");
            toStringOutput.Add($"this.Source = {(this.Source == null ? "null" : this.Source)}");
            toStringOutput.Add($"this.SourceId = {(this.SourceId == null ? "null" : this.SourceId)}");
            toStringOutput.Add($"this.SourceFeeMoney = {(this.SourceFeeMoney == null ? "null" : this.SourceFeeMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Type,
                this.Source)
                .SourceId(this.SourceId)
                .SourceFeeMoney(this.SourceFeeMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "source_id", false },
            };

            private string type;
            private string source;
            private string sourceId;
            private Models.Money sourceFeeMoney;

            /// <summary>
            /// Initialize Builder for ExternalPaymentDetails.
            /// </summary>
            /// <param name="type"> type. </param>
            /// <param name="source"> source. </param>
            public Builder(
                string type,
                string source)
            {
                this.type = type;
                this.source = source;
            }

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// Source.
             /// </summary>
             /// <param name="source"> source. </param>
             /// <returns> Builder. </returns>
            public Builder Source(string source)
            {
                this.source = source;
                return this;
            }

             /// <summary>
             /// SourceId.
             /// </summary>
             /// <param name="sourceId"> sourceId. </param>
             /// <returns> Builder. </returns>
            public Builder SourceId(string sourceId)
            {
                shouldSerialize["source_id"] = true;
                this.sourceId = sourceId;
                return this;
            }

             /// <summary>
             /// SourceFeeMoney.
             /// </summary>
             /// <param name="sourceFeeMoney"> sourceFeeMoney. </param>
             /// <returns> Builder. </returns>
            public Builder SourceFeeMoney(Models.Money sourceFeeMoney)
            {
                this.sourceFeeMoney = sourceFeeMoney;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSourceId()
            {
                this.shouldSerialize["source_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ExternalPaymentDetails. </returns>
            public ExternalPaymentDetails Build()
            {
                return new ExternalPaymentDetails(shouldSerialize,
                    this.type,
                    this.source,
                    this.sourceId,
                    this.sourceFeeMoney);
            }
        }
    }
}