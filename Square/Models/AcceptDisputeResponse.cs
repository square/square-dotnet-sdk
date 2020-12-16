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
    public class AcceptDisputeResponse 
    {
        public AcceptDisputeResponse(IList<Models.Error> errors = null,
            Models.Dispute dispute = null)
        {
            Errors = errors;
            Dispute = dispute;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a dispute a cardholder initiated with their bank.
        /// </summary>
        [JsonProperty("dispute", NullValueHandling = NullValueHandling.Ignore)]
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
            private IList<Models.Error> errors;
            private Models.Dispute dispute;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Dispute(Models.Dispute dispute)
            {
                this.dispute = dispute;
                return this;
            }

            public AcceptDisputeResponse Build()
            {
                return new AcceptDisputeResponse(errors,
                    dispute);
            }
        }
    }
}