using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class ListDisputeEvidenceResponse 
    {
        public ListDisputeEvidenceResponse(IList<Models.DisputeEvidence> evidence = null,
            IList<Models.Error> errors = null)
        {
            Evidence = evidence;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The list of evidence previously uploaded to the specified dispute.
        /// </summary>
        [JsonProperty("evidence")]
        public IList<Models.DisputeEvidence> Evidence { get; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Evidence(Evidence)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.DisputeEvidence> evidence = new List<Models.DisputeEvidence>();
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder Evidence(IList<Models.DisputeEvidence> value)
            {
                evidence = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public ListDisputeEvidenceResponse Build()
            {
                return new ListDisputeEvidenceResponse(evidence,
                    errors);
            }
        }
    }
}