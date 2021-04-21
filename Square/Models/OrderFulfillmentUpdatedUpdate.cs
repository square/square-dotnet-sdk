namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// OrderFulfillmentUpdatedUpdate.
    /// </summary>
    public class OrderFulfillmentUpdatedUpdate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFulfillmentUpdatedUpdate"/> class.
        /// </summary>
        /// <param name="fulfillmentUid">fulfillment_uid.</param>
        /// <param name="oldState">old_state.</param>
        /// <param name="newState">new_state.</param>
        public OrderFulfillmentUpdatedUpdate(
            string fulfillmentUid = null,
            string oldState = null,
            string newState = null)
        {
            this.FulfillmentUid = fulfillmentUid;
            this.OldState = oldState;
            this.NewState = newState;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderFulfillmentUpdatedUpdate : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
                ((this.FulfillmentUid == null && other.FulfillmentUid == null) || (this.FulfillmentUid?.Equals(other.FulfillmentUid) == true)) &&
                ((this.OldState == null && other.OldState == null) || (this.OldState?.Equals(other.OldState) == true)) &&
                ((this.NewState == null && other.NewState == null) || (this.NewState?.Equals(other.NewState) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1020384167;

            if (this.FulfillmentUid != null)
            {
               hashCode += this.FulfillmentUid.GetHashCode();
            }

            if (this.OldState != null)
            {
               hashCode += this.OldState.GetHashCode();
            }

            if (this.NewState != null)
            {
               hashCode += this.NewState.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.FulfillmentUid = {(this.FulfillmentUid == null ? "null" : this.FulfillmentUid == string.Empty ? "" : this.FulfillmentUid)}");
            toStringOutput.Add($"this.OldState = {(this.OldState == null ? "null" : this.OldState.ToString())}");
            toStringOutput.Add($"this.NewState = {(this.NewState == null ? "null" : this.NewState.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .FulfillmentUid(this.FulfillmentUid)
                .OldState(this.OldState)
                .NewState(this.NewState);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string fulfillmentUid;
            private string oldState;
            private string newState;

             /// <summary>
             /// FulfillmentUid.
             /// </summary>
             /// <param name="fulfillmentUid"> fulfillmentUid. </param>
             /// <returns> Builder. </returns>
            public Builder FulfillmentUid(string fulfillmentUid)
            {
                this.fulfillmentUid = fulfillmentUid;
                return this;
            }

             /// <summary>
             /// OldState.
             /// </summary>
             /// <param name="oldState"> oldState. </param>
             /// <returns> Builder. </returns>
            public Builder OldState(string oldState)
            {
                this.oldState = oldState;
                return this;
            }

             /// <summary>
             /// NewState.
             /// </summary>
             /// <param name="newState"> newState. </param>
             /// <returns> Builder. </returns>
            public Builder NewState(string newState)
            {
                this.newState = newState;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderFulfillmentUpdatedUpdate. </returns>
            public OrderFulfillmentUpdatedUpdate Build()
            {
                return new OrderFulfillmentUpdatedUpdate(
                    this.fulfillmentUid,
                    this.oldState,
                    this.newState);
            }
        }
    }
}