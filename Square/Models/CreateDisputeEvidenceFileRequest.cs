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
        /// Unique ID. For more information,
        /// see [Idempotency](https://developer.squareup.com/docs/docs/working-with-apis/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Type of the dispute evidence.
        /// </summary>
        [JsonProperty("evidence_type")]
        public string EvidenceType { get; }

        /// <summary>
        /// The MIME type of the uploaded file.
        /// One of image/heic, image/heif, image/jpeg, application/pdf,  image/png, image/tiff.
        /// </summary>
        [JsonProperty("content_type")]
        public string ContentType { get; }

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
            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public Builder EvidenceType(string value)
            {
                evidenceType = value;
                return this;
            }

            public Builder ContentType(string value)
            {
                contentType = value;
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