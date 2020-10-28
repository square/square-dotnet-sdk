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
    public class ListRefundsResponse 
    {
        public ListRefundsResponse(IList<Models.Error> errors = null,
            IList<Models.Refund> refunds = null,
            string cursor = null)
        {
            Errors = errors;
            Refunds = refunds;
            Cursor = cursor;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// An array of refunds that match your query.
        /// </summary>
        [JsonProperty("refunds", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Refund> Refunds { get; }

        /// <summary>
        /// A pagination cursor for retrieving the next set of results,
        /// if any remain. Provide this value as the `cursor` parameter in a subsequent
        /// request to this endpoint.
        /// See [Paginating results](#paginatingresults) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Refunds(Refunds)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.Refund> refunds;
            private string cursor;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Refunds(IList<Models.Refund> refunds)
            {
                this.refunds = refunds;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public ListRefundsResponse Build()
            {
                return new ListRefundsResponse(errors,
                    refunds,
                    cursor);
            }
        }
    }
}