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
    public class RetrieveSubscriptionResponse 
    {
        public RetrieveSubscriptionResponse(IList<Models.Error> errors = null,
            Models.Subscription subscription = null)
        {
            Errors = errors;
            Subscription = subscription;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a customer subscription to a subscription plan.
        /// For an overview of the `Subscription` type, see 
        /// [Subscription object](https://developer.squareup.com/docs/docs/subscriptions-api/overview#subscription-object-overview).
        /// </summary>
        [JsonProperty("subscription", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Subscription Subscription { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Subscription(Subscription);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.Subscription subscription;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Subscription(Models.Subscription subscription)
            {
                this.subscription = subscription;
                return this;
            }

            public RetrieveSubscriptionResponse Build()
            {
                return new RetrieveSubscriptionResponse(errors,
                    subscription);
            }
        }
    }
}