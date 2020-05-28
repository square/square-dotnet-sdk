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
    public class SearchLoyaltyEventsResponse 
    {
        public SearchLoyaltyEventsResponse(IList<Models.Error> errors = null,
            IList<Models.LoyaltyEvent> events = null,
            string cursor = null)
        {
            Errors = errors;
            Events = events;
            Cursor = cursor;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The loyalty events that satisfy the search criteria.
        /// </summary>
        [JsonProperty("events")]
        public IList<Models.LoyaltyEvent> Events { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent 
        /// request. If empty, this is the final response. 
        /// For more information, 
        /// see [Pagination](https://developer.squareup.com/docs/docs/basics/api101/pagination).
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Events(Events)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.LoyaltyEvent> events = new List<Models.LoyaltyEvent>();
            private string cursor;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Events(IList<Models.LoyaltyEvent> value)
            {
                events = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public SearchLoyaltyEventsResponse Build()
            {
                return new SearchLoyaltyEventsResponse(errors,
                    events,
                    cursor);
            }
        }
    }
}