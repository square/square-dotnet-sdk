
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
        [JsonProperty("fulfillment_uid", NullValueHandling = NullValueHandling.Ignore)]
        public string FulfillmentUid { get; }

        /// <summary>
        /// The current state of this fulfillment.
        /// </summary>
        [JsonProperty("old_state", NullValueHandling = NullValueHandling.Ignore)]
        public string OldState { get; }

        /// <summary>
        /// The current state of this fulfillment.
        /// </summary>
        [JsonProperty("new_state", NullValueHandling = NullValueHandling.Ignore)]
        public string NewState { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderFulfillmentUpdatedUpdate : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"FulfillmentUid = {(FulfillmentUid == null ? "null" : FulfillmentUid == string.Empty ? "" : FulfillmentUid)}");
            toStringOutput.Add($"OldState = {(OldState == null ? "null" : OldState.ToString())}");
            toStringOutput.Add($"NewState = {(NewState == null ? "null" : NewState.ToString())}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is OrderFulfillmentUpdatedUpdate other &&
                ((FulfillmentUid == null && other.FulfillmentUid == null) || (FulfillmentUid?.Equals(other.FulfillmentUid) == true)) &&
                ((OldState == null && other.OldState == null) || (OldState?.Equals(other.OldState) == true)) &&
                ((NewState == null && other.NewState == null) || (NewState?.Equals(other.NewState) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1020384167;

            if (FulfillmentUid != null)
            {
               hashCode += FulfillmentUid.GetHashCode();
            }

            if (OldState != null)
            {
               hashCode += OldState.GetHashCode();
            }

            if (NewState != null)
            {
               hashCode += NewState.GetHashCode();
            }

            return hashCode;
        }

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



            public Builder FulfillmentUid(string fulfillmentUid)
            {
                this.fulfillmentUid = fulfillmentUid;
                return this;
            }

            public Builder OldState(string oldState)
            {
                this.oldState = oldState;
                return this;
            }

            public Builder NewState(string newState)
            {
                this.newState = newState;
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