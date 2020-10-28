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
        [JsonProperty("evidence", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.DisputeEvidence> Evidence { get; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
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
            private IList<Models.DisputeEvidence> evidence;
            private IList<Models.Error> errors;



            public Builder Evidence(IList<Models.DisputeEvidence> evidence)
            {
                this.evidence = evidence;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
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