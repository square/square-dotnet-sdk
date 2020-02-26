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
    public class CreateDisputeEvidenceFileResponse 
    {
        public CreateDisputeEvidenceFileResponse(IList<Models.Error> errors = null,
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
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Getter for evidence
        /// </summary>
        [JsonProperty("evidence")]
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
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.DisputeEvidence evidence;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Evidence(Models.DisputeEvidence value)
            {
                evidence = value;
                return this;
            }

            public CreateDisputeEvidenceFileResponse Build()
            {
                return new CreateDisputeEvidenceFileResponse(errors,
                    evidence);
            }
        }
    }
}