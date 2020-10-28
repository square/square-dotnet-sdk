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
    public class ListDisputesResponse 
    {
        public ListDisputesResponse(IList<Models.Error> errors = null,
            IList<Models.Dispute> disputes = null,
            string cursor = null)
        {
            Errors = errors;
            Disputes = disputes;
            Cursor = cursor;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The list of Disputes.
        /// </summary>
        [JsonProperty("disputes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Dispute> Disputes { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent request.
        /// If unset, this is the final response.
        /// For more information, see [Paginating](https://developer.squareup.com/docs/basics/api101/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Disputes(Disputes)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.Dispute> disputes;
            private string cursor;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Disputes(IList<Models.Dispute> disputes)
            {
                this.disputes = disputes;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public ListDisputesResponse Build()
            {
                return new ListDisputesResponse(errors,
                    disputes,
                    cursor);
            }
        }
    }
}