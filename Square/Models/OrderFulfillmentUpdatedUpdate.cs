using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class OrderFulfillmentUpdatedUpdate 
    {
        public OrderFulfillmentUpdatedUpdate(string fulfillmentUid = null,
            string oldState = null,
            string newState = null)
        {
            FulfillmentUid = fulfillmentUid;
            OldState = oldState;
            NewState = newState;
        }

        /// <summary>
        /// Unique ID that identifies the fulfillment only within this order.
        /// </summary>
        [JsonProperty("fulfillment_uid")]
        public string FulfillmentUid { get; }

        /// <summary>
        /// The current state of this fulfillment.
        /// </summary>
        [JsonProperty("old_state")]
        public string OldState { get; }

        /// <summary>
        /// The current state of this fulfillment.
        /// </summary>
        [JsonProperty("new_state")]
        public string NewState { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .FulfillmentUid(FulfillmentUid)
                .OldState(OldState)
                .NewState(NewState);
            return builder;
        }

        public class Builder
        {
            private string fulfillmentUid;
            private string oldState;
            private string newState;

            public Builder() { }
            public Builder FulfillmentUid(string value)
            {
                fulfillmentUid = value;
                return this;
            }

            public Builder OldState(string value)
            {
                oldState = value;
                return this;
            }

            public Builder NewState(string value)
            {
                newState = value;
                return this;
            }

            public OrderFulfillmentUpdatedUpdate Build()
            {
                return new OrderFulfillmentUpdatedUpdate(fulfillmentUid,
                    oldState,
                    newState);
            }
        }
    }
}