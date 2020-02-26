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
    public class DisputeEvidence 
    {
        public DisputeEvidence(string evidenceId = null,
            string disputeId = null,
            string uploadedAt = null,
            string evidenceType = null)
        {
            EvidenceId = evidenceId;
            DisputeId = disputeId;
            UploadedAt = uploadedAt;
            EvidenceType = evidenceType;
        }

        /// <summary>
        /// The Square-generated ID of the evidence.
        /// </summary>
        [JsonProperty("evidence_id")]
        public string EvidenceId { get; }

        /// <summary>
        /// The ID of the dispute the evidence is associated with.
        /// </summary>
        [JsonProperty("dispute_id")]
        public string DisputeId { get; }

        /// <summary>
        /// The time when the next action is due, in RFC 3339 format.
        /// </summary>
        [JsonProperty("uploaded_at")]
        public string UploadedAt { get; }

        /// <summary>
        /// Type of the dispute evidence.
        /// </summary>
        [JsonProperty("evidence_type")]
        public string EvidenceType { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EvidenceId(EvidenceId)
                .DisputeId(DisputeId)
                .UploadedAt(UploadedAt)
                .EvidenceType(EvidenceType);
            return builder;
        }

        public class Builder
        {
            private string evidenceId;
            private string disputeId;
            private string uploadedAt;
            private string evidenceType;

            public Builder() { }
            public Builder EvidenceId(string value)
            {
                evidenceId = value;
                return this;
            }

            public Builder DisputeId(string value)
            {
                disputeId = value;
                return this;
            }

            public Builder UploadedAt(string value)
            {
                uploadedAt = value;
                return this;
            }

            public Builder EvidenceType(string value)
            {
                evidenceType = value;
                return this;
            }

            public DisputeEvidence Build()
            {
                return new DisputeEvidence(evidenceId,
                    disputeId,
                    uploadedAt,
                    evidenceType);
            }
        }
    }
}