using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// OrderFulfillmentUpdatedUpdate.
    /// </summary>
    public class OrderFulfillmentUpdatedUpdate
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFulfillmentUpdatedUpdate"/> class.
        /// </summary>
        /// <param name="fulfillmentUid">fulfillment_uid.</param>
        /// <param name="oldState">old_state.</param>
        /// <param name="newState">new_state.</param>
        public OrderFulfillmentUpdatedUpdate(
            string fulfillmentUid = null,
            string oldState = null,
            string newState = null
        )
        {
            shouldSerialize = new Dictionary<string, bool> { { "fulfillment_uid", false } };

            if (fulfillmentUid != null)
            {
                shouldSerialize["fulfillment_uid"] = true;
                this.FulfillmentUid = fulfillmentUid;
            }
            this.OldState = oldState;
            this.NewState = newState;
        }

        internal OrderFulfillmentUpdatedUpdate(
            Dictionary<string, bool> shouldSerialize,
            string fulfillmentUid = null,
            string oldState = null,
            string newState = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            FulfillmentUid = fulfillmentUid;
            OldState = oldState;
            NewState = newState;
        }

        /// <summary>
        /// A unique ID that identifies the fulfillment only within this order.
        /// </summary>
        [JsonProperty("fulfillment_uid")]
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

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFulfillmentUid()
        {
            return this.shouldSerialize["fulfillment_uid"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is OrderFulfillmentUpdatedUpdate other
                && (
                    this.FulfillmentUid == null && other.FulfillmentUid == null
                    || this.FulfillmentUid?.Equals(other.FulfillmentUid) == true
                )
                && (
                    this.OldState == null && other.OldState == null
                    || this.OldState?.Equals(other.OldState) == true
                )
                && (
                    this.NewState == null && other.NewState == null
                    || this.NewState?.Equals(other.NewState) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1020384167;
            hashCode = HashCode.Combine(
                hashCode,
                this.FulfillmentUid,
                this.OldState,
                this.NewState
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.FulfillmentUid = {this.FulfillmentUid ?? "null"}");
            toStringOutput.Add(
                $"this.OldState = {(this.OldState == null ? "null" : this.OldState.ToString())}"
            );
            toStringOutput.Add(
                $"this.NewState = {(this.NewState == null ? "null" : this.NewState.ToString())}"
            );
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "fulfillment_uid", false },
            };

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
                shouldSerialize["fulfillment_uid"] = true;
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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetFulfillmentUid()
            {
                this.shouldSerialize["fulfillment_uid"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderFulfillmentUpdatedUpdate. </returns>
            public OrderFulfillmentUpdatedUpdate Build()
            {
                return new OrderFulfillmentUpdatedUpdate(
                    shouldSerialize,
                    this.fulfillmentUid,
                    this.oldState,
                    this.newState
                );
            }
        }
    }
}
