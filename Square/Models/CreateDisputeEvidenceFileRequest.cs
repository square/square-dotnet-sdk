
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
    public class CreateDisputeEvidenceFileRequest 
    {
        public CreateDisputeEvidenceFileRequest(string idempotencyKey,
            string evidenceType = null,
            string contentType = null)
        {
            IdempotencyKey = idempotencyKey;
            EvidenceType = evidenceType;
            ContentType = contentType;
        }

        /// <summary>
        /// The Unique ID. For more information, see [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency).
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateDisputeEvidenceFileRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
            toStringOutput.Add($"EvidenceType = {(EvidenceType == null ? "null" : EvidenceType.ToString())}");
            toStringOutput.Add($"ContentType = {(ContentType == null ? "null" : ContentType == string.Empty ? "" : ContentType)}");
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

            return obj is CreateDisputeEvidenceFileRequest other &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((EvidenceType == null && other.EvidenceType == null) || (EvidenceType?.Equals(other.EvidenceType) == true)) &&
                ((ContentType == null && other.ContentType == null) || (ContentType?.Equals(other.ContentType) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 52028208;

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            if (EvidenceType != null)
            {
               hashCode += EvidenceType.GetHashCode();
            }

            if (ContentType != null)
            {
               hashCode += ContentType.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(IdempotencyKey)
                .EvidenceType(EvidenceType)
                .ContentType(ContentType);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;
            private string evidenceType;
            private string contentType;

            public Builder(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
            }

            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public Builder EvidenceType(string evidenceType)
            {
                this.evidenceType = evidenceType;
                return this;
            }

            public Builder ContentType(string contentType)
            {
                this.contentType = contentType;
                return this;
            }

            public CreateDisputeEvidenceFileRequest Build()
            {
                return new CreateDisputeEvidenceFileRequest(idempotencyKey,
                    evidenceType,
                    contentType);
            }
        }
    }
}