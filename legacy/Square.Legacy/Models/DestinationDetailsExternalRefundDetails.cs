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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// DestinationDetailsExternalRefundDetails.
    /// </summary>
    public class DestinationDetailsExternalRefundDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="DestinationDetailsExternalRefundDetails"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="source">source.</param>
        /// <param name="sourceId">source_id.</param>
        public DestinationDetailsExternalRefundDetails(
            string type,
            string source,
            string sourceId = null
        )
        {
            shouldSerialize = new Dictionary<string, bool> { { "source_id", false } };
            this.Type = type;
            this.Source = source;

            if (sourceId != null)
            {
                shouldSerialize["source_id"] = true;
                this.SourceId = sourceId;
            }
        }

        internal DestinationDetailsExternalRefundDetails(
            Dictionary<string, bool> shouldSerialize,
            string type,
            string source,
            string sourceId = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Type = type;
            Source = source;
            SourceId = sourceId;
        }

        /// <summary>
        /// The type of external refund the seller paid to the buyer. It can be one of the
        /// following:
        /// - CHECK - Refunded using a physical check.
        /// - BANK_TRANSFER - Refunded using external bank transfer.
        /// - OTHER\_GIFT\_CARD - Refunded using a non-Square gift card.
        /// - CRYPTO - Refunded using a crypto currency.
        /// - SQUARE_CASH - Refunded using Square Cash App.
        /// - SOCIAL - Refunded using peer-to-peer payment applications.
        /// - EXTERNAL - A third-party application gathered this refund outside of Square.Legacy.
        /// - EMONEY - Refunded using an E-money provider.
        /// - CARD - A credit or debit card that Square does not support.
        /// - STORED_BALANCE - Use for house accounts, store credit, and so forth.
        /// - FOOD_VOUCHER - Restaurant voucher provided by employers to employees to pay for meals
        /// - OTHER - A type not listed here.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// A description of the external refund source. For example,
        /// "Food Delivery Service".
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; }

        /// <summary>
        /// An ID to associate the refund to its originating source.
        /// </summary>
        [JsonProperty("source_id")]
        public string SourceId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"DestinationDetailsExternalRefundDetails : ({string.Join(", ", toStringOutput)})";
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
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is DestinationDetailsExternalRefundDetails other
                && (
                    this.Type == null && other.Type == null || this.Type?.Equals(other.Type) == true
                )
                && (
                    this.Source == null && other.Source == null
                    || this.Source?.Equals(other.Source) == true
                )
                && (
                    this.SourceId == null && other.SourceId == null
                    || this.SourceId?.Equals(other.SourceId) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -687379938;
            hashCode = HashCode.Combine(hashCode, this.Type, this.Source, this.SourceId);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {this.Type ?? "null"}");
            toStringOutput.Add($"this.Source = {this.Source ?? "null"}");
            toStringOutput.Add($"this.SourceId = {this.SourceId ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Type, this.Source).SourceId(this.SourceId);
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

            /// <summary>
            /// Initialize Builder for DestinationDetailsExternalRefundDetails.
            /// </summary>
            /// <param name="type"> type. </param>
            /// <param name="source"> source. </param>
            public Builder(string type, string source)
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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetSourceId()
            {
                this.shouldSerialize["source_id"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DestinationDetailsExternalRefundDetails. </returns>
            public DestinationDetailsExternalRefundDetails Build()
            {
                return new DestinationDetailsExternalRefundDetails(
                    shouldSerialize,
                    this.type,
                    this.source,
                    this.sourceId
                );
            }
        }
    }
}
