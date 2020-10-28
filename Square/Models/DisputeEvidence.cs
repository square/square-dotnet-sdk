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
        [JsonProperty("evidence_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EvidenceId { get; }

        /// <summary>
        /// The ID of the dispute the evidence is associated with.
        /// </summary>
        [JsonProperty("dispute_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DisputeId { get; }

        /// <summary>
        /// The time when the next action is due, in RFC 3339 format.
        /// </summary>
        [JsonProperty("uploaded_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UploadedAt { get; }

        /// <summary>
        /// Type of the dispute evidence.
        /// </summary>
        [JsonProperty("evidence_type", NullValueHandling = NullValueHandling.Ignore)]
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



            public Builder EvidenceId(string evidenceId)
            {
                this.evidenceId = evidenceId;
                return this;
            }

            public Builder DisputeId(string disputeId)
            {
                this.disputeId = disputeId;
                return this;
            }

            public Builder UploadedAt(string uploadedAt)
            {
                this.uploadedAt = uploadedAt;
                return this;
            }

            public Builder EvidenceType(string evidenceType)
            {
                this.evidenceType = evidenceType;
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