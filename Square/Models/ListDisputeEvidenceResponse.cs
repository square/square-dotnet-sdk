
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
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListDisputeEvidenceResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Evidence = {(Evidence == null ? "null" : $"[{ string.Join(", ", Evidence)} ]")}");
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
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

            return obj is ListDisputeEvidenceResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Evidence == null && other.Evidence == null) || (Evidence?.Equals(other.Evidence) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 529802035;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Evidence != null)
            {
               hashCode += Evidence.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            return hashCode;
        }

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