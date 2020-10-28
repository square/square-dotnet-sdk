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
    public class RetrieveDisputeEvidenceResponse 
    {
        public RetrieveDisputeEvidenceResponse(IList<Models.Error> errors = null,
            Models.DisputeEvidence evidence = null)
        {
            Errors = errors;
            Evidence = evidence;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Getter for evidence
        /// </summary>
        [JsonProperty("evidence", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DisputeEvidence Evidence { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Evidence(Evidence);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.DisputeEvidence evidence;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Evidence(Models.DisputeEvidence evidence)
            {
                this.evidence = evidence;
                return this;
            }

            public RetrieveDisputeEvidenceResponse Build()
            {
                return new RetrieveDisputeEvidenceResponse(errors,
                    evidence);
            }
        }
    }
}