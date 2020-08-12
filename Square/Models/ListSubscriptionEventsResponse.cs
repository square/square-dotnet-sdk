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
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The `SubscriptionEvents` retrieved.
        /// </summary>
        [JsonProperty("subscription_events")]
        public IList<Models.SubscriptionEvent> SubscriptionEvents { get; }

        /// <summary>
        /// When a response is truncated, it includes a cursor that you can 
        /// use in a subsequent request to fetch the next set of events. 
        /// If empty, this is the final response.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("cursor")]
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
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.SubscriptionEvent> subscriptionEvents = new List<Models.SubscriptionEvent>();
            private string cursor;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder SubscriptionEvents(IList<Models.SubscriptionEvent> value)
            {
                subscriptionEvents = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
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