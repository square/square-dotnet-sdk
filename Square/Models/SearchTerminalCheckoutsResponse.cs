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
    public class SearchTerminalCheckoutsResponse 
    {
        public SearchTerminalCheckoutsResponse(IList<Models.Error> errors = null,
            IList<Models.TerminalCheckout> checkouts = null,
            string cursor = null)
        {
            Errors = errors;
            Checkouts = checkouts;
            Cursor = cursor;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The requested search result of `TerminalCheckout`s.
        /// </summary>
        [JsonProperty("checkouts")]
        public IList<Models.TerminalCheckout> Checkouts { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent request. If empty,
        /// this is the final response.
        /// See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Checkouts(Checkouts)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.TerminalCheckout> checkouts = new List<Models.TerminalCheckout>();
            private string cursor;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Checkouts(IList<Models.TerminalCheckout> value)
            {
                checkouts = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public SearchTerminalCheckoutsResponse Build()
            {
                return new SearchTerminalCheckoutsResponse(errors,
                    checkouts,
                    cursor);
            }
        }
    }
}