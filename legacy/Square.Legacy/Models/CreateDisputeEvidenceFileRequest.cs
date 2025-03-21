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
    /// CreateDisputeEvidenceFileRequest.
    /// </summary>
    public class CreateDisputeEvidenceFileRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateDisputeEvidenceFileRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="evidenceType">evidence_type.</param>
        /// <param name="contentType">content_type.</param>
        public CreateDisputeEvidenceFileRequest(
            string idempotencyKey,
            string evidenceType = null,
            string contentType = null
        )
        {
            this.IdempotencyKey = idempotencyKey;
            this.EvidenceType = evidenceType;
            this.ContentType = contentType;
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
        /// The MIME type of the uploaded file.
        /// The type can be image/heic, image/heif, image/jpeg, application/pdf, image/png, or image/tiff.
        /// </summary>
        [JsonProperty("content_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ContentType { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CreateDisputeEvidenceFileRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CreateDisputeEvidenceFileRequest other
                && (
                    this.IdempotencyKey == null && other.IdempotencyKey == null
                    || this.IdempotencyKey?.Equals(other.IdempotencyKey) == true
                )
                && (
                    this.EvidenceType == null && other.EvidenceType == null
                    || this.EvidenceType?.Equals(other.EvidenceType) == true
                )
                && (
                    this.ContentType == null && other.ContentType == null
                    || this.ContentType?.Equals(other.ContentType) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 52028208;
            hashCode = HashCode.Combine(
                hashCode,
                this.IdempotencyKey,
                this.EvidenceType,
                this.ContentType
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {this.IdempotencyKey ?? "null"}");
            toStringOutput.Add(
                $"this.EvidenceType = {(this.EvidenceType == null ? "null" : this.EvidenceType.ToString())}"
            );
            toStringOutput.Add($"this.ContentType = {this.ContentType ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.IdempotencyKey)
                .EvidenceType(this.EvidenceType)
                .ContentType(this.ContentType);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private string evidenceType;
            private string contentType;

            /// <summary>
            /// Initialize Builder for CreateDisputeEvidenceFileRequest.
            /// </summary>
            /// <param name="idempotencyKey"> idempotencyKey. </param>
            public Builder(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
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
            /// ContentType.
            /// </summary>
            /// <param name="contentType"> contentType. </param>
            /// <returns> Builder. </returns>
            public Builder ContentType(string contentType)
            {
                this.contentType = contentType;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateDisputeEvidenceFileRequest. </returns>
            public CreateDisputeEvidenceFileRequest Build()
            {
                return new CreateDisputeEvidenceFileRequest(
                    this.idempotencyKey,
                    this.evidenceType,
                    this.contentType
                );
            }
        }
    }
}
