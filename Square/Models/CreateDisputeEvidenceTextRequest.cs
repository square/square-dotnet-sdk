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
    public class CreateDisputeEvidenceTextRequest 
    {
        public CreateDisputeEvidenceTextRequest(string idempotencyKey,
            string evidenceText,
            string evidenceType = null)
        {
            IdempotencyKey = idempotencyKey;
            EvidenceType = evidenceType;
            EvidenceText = evidenceText;
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
        /// The evidence string.
        /// </summary>
        [JsonProperty("evidence_text")]
        public string EvidenceText { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(IdempotencyKey,
                EvidenceText)
                .EvidenceType(EvidenceType);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;
            private string evidenceText;
            private string evidenceType;

            public Builder(string idempotencyKey,
                string evidenceText)
            {
                this.idempotencyKey = idempotencyKey;
                this.evidenceText = evidenceText;
            }
            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public Builder EvidenceText(string value)
            {
                evidenceText = value;
                return this;
            }

            public Builder EvidenceType(string value)
            {
                evidenceType = value;
                return this;
            }

            public CreateDisputeEvidenceTextRequest Build()
            {
                return new CreateDisputeEvidenceTextRequest(idempotencyKey,
                    evidenceText,
                    evidenceType);
            }
        }
    }
}