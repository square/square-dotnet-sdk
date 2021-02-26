
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
        /// The evidence string.
        /// </summary>
        [JsonProperty("evidence_text")]
        public string EvidenceText { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateDisputeEvidenceTextRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
            toStringOutput.Add($"EvidenceType = {(EvidenceType == null ? "null" : EvidenceType.ToString())}");
            toStringOutput.Add($"EvidenceText = {(EvidenceText == null ? "null" : EvidenceText == string.Empty ? "" : EvidenceText)}");
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

            return obj is CreateDisputeEvidenceTextRequest other &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((EvidenceType == null && other.EvidenceType == null) || (EvidenceType?.Equals(other.EvidenceType) == true)) &&
                ((EvidenceText == null && other.EvidenceText == null) || (EvidenceText?.Equals(other.EvidenceText) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 814624770;

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            if (EvidenceType != null)
            {
               hashCode += EvidenceType.GetHashCode();
            }

            if (EvidenceText != null)
            {
               hashCode += EvidenceText.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public Builder EvidenceText(string evidenceText)
            {
                this.evidenceText = evidenceText;
                return this;
            }

            public Builder EvidenceType(string evidenceType)
            {
                this.evidenceType = evidenceType;
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