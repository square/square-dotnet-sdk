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
    public class SearchSubscriptionsResponse 
    {
        public SearchSubscriptionsResponse(IList<Models.Error> errors = null,
            IList<Models.Subscription> subscriptions = null,
            string cursor = null)
        {
            Errors = errors;
            Subscriptions = subscriptions;
            Cursor = cursor;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The search result.
        /// </summary>
        [JsonProperty("subscriptions", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Subscription> Subscriptions { get; }

        /// <summary>
        /// When a response is truncated, it includes a cursor that you can 
        /// use in a subsequent request to fetch the next set of subscriptions. 
        /// If empty, this is the final response.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Subscriptions(Subscriptions)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.Subscription> subscriptions;
            private string cursor;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Subscriptions(IList<Models.Subscription> subscriptions)
            {
                this.subscriptions = subscriptions;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public SearchSubscriptionsResponse Build()
            {
                return new SearchSubscriptionsResponse(errors,
                    subscriptions,
                    cursor);
            }
        }
    }
}