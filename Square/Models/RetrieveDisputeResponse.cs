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
    public class RetrieveDisputeResponse 
    {
        public RetrieveDisputeResponse(IList<Models.Error> errors = null,
            Models.Dispute dispute = null)
        {
            Errors = errors;
            Dispute = dispute;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a dispute a cardholder initiated with their bank.
        /// </summary>
        [JsonProperty("dispute")]
        public Models.Dispute Dispute { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Dispute(Dispute);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.Dispute dispute;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Dispute(Models.Dispute value)
            {
                dispute = value;
                return this;
            }

            public RetrieveDisputeResponse Build()
            {
                return new RetrieveDisputeResponse(errors,
                    dispute);
            }
        }
    }
}