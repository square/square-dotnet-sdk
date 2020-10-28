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
    public class GetTerminalRefundResponse 
    {
        public GetTerminalRefundResponse(IList<Models.Error> errors = null,
            Models.TerminalRefund refund = null)
        {
            Errors = errors;
            Refund = refund;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Getter for refund
        /// </summary>
        [JsonProperty("refund", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalRefund Refund { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Refund(Refund);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.TerminalRefund refund;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Refund(Models.TerminalRefund refund)
            {
                this.refund = refund;
                return this;
            }

            public GetTerminalRefundResponse Build()
            {
                return new GetTerminalRefundResponse(errors,
                    refund);
            }
        }
    }
}