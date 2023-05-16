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
    /// CreateDisputeEvidenceTextRequest.
    /// </summary>
    public class CreateDisputeEvidenceTextRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateDisputeEvidenceTextRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="evidenceText">evidence_text.</param>
        /// <param name="evidenceType">evidence_type.</param>
        public CreateDisputeEvidenceTextRequest(
            string idempotencyKey,
            string evidenceText,
            string evidenceType = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.EvidenceType = evidenceType;
            this.EvidenceText = evidenceText;
        }

        /// <summary>
        /// A unique key identifying the request. For more information, see [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The type of the dispute evidence.
        /// </summary>
        [JsonProperty("evidence_type", NullValueHandling = NullValueHandling.Ignore)]
        public string EvidenceType { get; }

        /// <summary>
        /// The evidence string.
        /// </summary>
        [JsonProperty("evidence_text")]
        public string EvidenceText { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateDisputeEvidenceTextRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is CreateDisputeEvidenceTextRequest other &&                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.EvidenceType == null && other.EvidenceType == null) || (this.EvidenceType?.Equals(other.EvidenceType) == true)) &&
                ((this.EvidenceText == null && other.EvidenceText == null) || (this.EvidenceText?.Equals(other.EvidenceText) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 814624770;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.EvidenceType, this.EvidenceText);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.EvidenceType = {(this.EvidenceType == null ? "null" : this.EvidenceType.ToString())}");
            toStringOutput.Add($"this.EvidenceText = {(this.EvidenceText == null ? "null" : this.EvidenceText == string.Empty ? "" : this.EvidenceText)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey,
                this.EvidenceText)
                .EvidenceType(this.EvidenceType);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private string evidenceText;
            private string evidenceType;

            public Builder(
                string idempotencyKey,
                string evidenceText)
            {
                this.idempotencyKey = idempotencyKey;
                this.evidenceText = evidenceText;
            }

             /// <summary>
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

             /// <summary>
             /// EvidenceText.
             /// </summary>
             /// <param name="evidenceText"> evidenceText. </param>
             /// <returns> Builder. </returns>
            public Builder EvidenceText(string evidenceText)
            {
                this.evidenceText = evidenceText;
                return this;
            }

             /// <summary>
             /// EvidenceType.
             /// </summary>
             /// <param name="evidenceType"> evidenceType. </param>
             /// <returns> Builder. </returns>
            public Builder EvidenceType(string evidenceType)
            {
                this.evidenceType = evidenceType;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateDisputeEvidenceTextRequest. </returns>
            public CreateDisputeEvidenceTextRequest Build()
            {
                return new CreateDisputeEvidenceTextRequest(
                    this.idempotencyKey,
                    this.evidenceText,
                    this.evidenceType);
            }
        }
    }
}