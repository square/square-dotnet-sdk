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
    public class RedeemLoyaltyRewardResponse 
    {
        public RedeemLoyaltyRewardResponse(IList<Models.Error> errors = null,
            Models.LoyaltyEvent mEvent = null)
        {
            Errors = errors;
            MEvent = mEvent;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Provides information about a loyalty event. 
        /// For more information, see [Loyalty events](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-events).
        /// </summary>
        [JsonProperty("event", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyEvent MEvent { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .MEvent(MEvent);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.LoyaltyEvent mEvent;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder MEvent(Models.LoyaltyEvent mEvent)
            {
                this.mEvent = mEvent;
                return this;
            }

            public RedeemLoyaltyRewardResponse Build()
            {
                return new RedeemLoyaltyRewardResponse(errors,
                    mEvent);
            }
        }
    }
}