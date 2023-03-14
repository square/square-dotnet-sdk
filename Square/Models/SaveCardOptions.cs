namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// SaveCardOptions.
    /// </summary>
    public class SaveCardOptions
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="SaveCardOptions"/> class.
        /// </summary>
        /// <param name="customerId">customer_id.</param>
        /// <param name="cardId">card_id.</param>
        /// <param name="referenceId">reference_id.</param>
        public SaveCardOptions(
            string customerId,
            string cardId = null,
            string referenceId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "reference_id", false }
            };

            this.CustomerId = customerId;
            this.CardId = cardId;
            if (referenceId != null)
            {
                shouldSerialize["reference_id"] = true;
                this.ReferenceId = referenceId;
            }

        }
        internal SaveCardOptions(Dictionary<string, bool> shouldSerialize,
            string customerId,
            string cardId = null,
            string referenceId = null)
        {
            this.shouldSerialize = shouldSerialize;
            CustomerId = customerId;
            CardId = cardId;
            ReferenceId = referenceId;
        }

        /// <summary>
        /// The square-assigned ID of the customer linked to the saved card.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <summary>
        /// The id of the created card-on-file.
        /// </summary>
        [JsonProperty("card_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CardId { get; }

        /// <summary>
        /// An optional user-defined reference ID that can be used to associate
        /// this `Card` to another entity in an external system. For example, a customer
        /// ID generated by a third-party system.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SaveCardOptions : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReferenceId()
        {
            return this.shouldSerialize["reference_id"];
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

            return obj is SaveCardOptions other &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.CardId == null && other.CardId == null) || (this.CardId?.Equals(other.CardId) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1521790821;
            hashCode = HashCode.Combine(this.CustomerId, this.CardId, this.ReferenceId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId == string.Empty ? "" : this.CustomerId)}");
            toStringOutput.Add($"this.CardId = {(this.CardId == null ? "null" : this.CardId == string.Empty ? "" : this.CardId)}");
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId == string.Empty ? "" : this.ReferenceId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.CustomerId)
                .CardId(this.CardId)
                .ReferenceId(this.ReferenceId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "reference_id", false },
            };

            private string customerId;
            private string cardId;
            private string referenceId;

            public Builder(
                string customerId)
            {
                this.customerId = customerId;
            }

             /// <summary>
             /// CustomerId.
             /// </summary>
             /// <param name="customerId"> customerId. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerId(string customerId)
            {
                this.customerId = customerId;
                return this;
            }

             /// <summary>
             /// CardId.
             /// </summary>
             /// <param name="cardId"> cardId. </param>
             /// <returns> Builder. </returns>
            public Builder CardId(string cardId)
            {
                this.cardId = cardId;
                return this;
            }

             /// <summary>
             /// ReferenceId.
             /// </summary>
             /// <param name="referenceId"> referenceId. </param>
             /// <returns> Builder. </returns>
            public Builder ReferenceId(string referenceId)
            {
                shouldSerialize["reference_id"] = true;
                this.referenceId = referenceId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetReferenceId()
            {
                this.shouldSerialize["reference_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SaveCardOptions. </returns>
            public SaveCardOptions Build()
            {
                return new SaveCardOptions(shouldSerialize,
                    this.customerId,
                    this.cardId,
                    this.referenceId);
            }
        }
    }
}