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
    public class ListSubscriptionEventsResponse 
    {
        public ListSubscriptionEventsResponse(IList<Models.Error> errors = null,
            IList<Models.SubscriptionEvent> subscriptionEvents = null,
            string cursor = null)
        {
            Errors = errors;
            SubscriptionEvents = subscriptionEvents;
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
        /// The `SubscriptionEvents` retrieved.
        /// </summary>
        [JsonProperty("subscription_events", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.SubscriptionEvent> SubscriptionEvents { get; }

        /// <summary>
        /// When a response is truncated, it includes a cursor that you can 
        /// use in a subsequent request to fetch the next set of events. 
        /// If empty, this is the final response.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .SubscriptionEvents(SubscriptionEvents)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.SubscriptionEvent> subscriptionEvents;
            private string cursor;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder SubscriptionEvents(IList<Models.SubscriptionEvent> subscriptionEvents)
            {
                this.subscriptionEvents = subscriptionEvents;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public ListSubscriptionEventsResponse Build()
            {
                return new ListSubscriptionEventsResponse(errors,
                    subscriptionEvents,
                    cursor);
            }
        }
    }
}