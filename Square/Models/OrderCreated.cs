namespace Square.Models
{
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
    using Square;
    using Square.Utilities;

    /// <summary>
    /// OrderCreated.
    /// </summary>
    public class OrderCreated
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderCreated"/> class.
        /// </summary>
        /// <param name="orderId">order_id.</param>
        /// <param name="version">version.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="state">state.</param>
        /// <param name="createdAt">created_at.</param>
        public OrderCreated(
            string orderId = null,
            int? version = null,
            string locationId = null,
            string state = null,
            string createdAt = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "order_id", false },
                { "location_id", false }
            };

            if (orderId != null)
            {
                shouldSerialize["order_id"] = true;
                this.OrderId = orderId;
            }

            this.Version = version;
            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

            this.State = state;
            this.CreatedAt = createdAt;
        }
        internal OrderCreated(Dictionary<string, bool> shouldSerialize,
            string orderId = null,
            int? version = null,
            string locationId = null,
            string state = null,
            string createdAt = null)
        {
            this.shouldSerialize = shouldSerialize;
            OrderId = orderId;
            Version = version;
            LocationId = locationId;
            State = state;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// The order's unique ID.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <summary>
        /// The version number, which is incremented each time an update is committed to the order.
        /// Orders that were not created through the API do not include a version number and
        /// therefore cannot be updated.
        /// [Read more about working with versions.](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders)
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// The ID of the seller location that this order is associated with.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The state of the order.
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; }

        /// <summary>
        /// The timestamp for when the order was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderCreated : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrderId()
        {
            return this.shouldSerialize["order_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
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
            return obj is OrderCreated other &&                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true)) &&
                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.State == null && other.State == null) || (this.State?.Equals(other.State) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1605817888;
            hashCode = HashCode.Combine(this.OrderId, this.Version, this.LocationId, this.State, this.CreatedAt);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId)}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.State = {(this.State == null ? "null" : this.State.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderId(this.OrderId)
                .Version(this.Version)
                .LocationId(this.LocationId)
                .State(this.State)
                .CreatedAt(this.CreatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "order_id", false },
                { "location_id", false },
            };

            private string orderId;
            private int? version;
            private string locationId;
            private string state;
            private string createdAt;

             /// <summary>
             /// OrderId.
             /// </summary>
             /// <param name="orderId"> orderId. </param>
             /// <returns> Builder. </returns>
            public Builder OrderId(string orderId)
            {
                shouldSerialize["order_id"] = true;
                this.orderId = orderId;
                return this;
            }

             /// <summary>
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(int? version)
            {
                this.version = version;
                return this;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                shouldSerialize["location_id"] = true;
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// State.
             /// </summary>
             /// <param name="state"> state. </param>
             /// <returns> Builder. </returns>
            public Builder State(string state)
            {
                this.state = state;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetOrderId()
            {
                this.shouldSerialize["order_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderCreated. </returns>
            public OrderCreated Build()
            {
                return new OrderCreated(shouldSerialize,
                    this.orderId,
                    this.version,
                    this.locationId,
                    this.state,
                    this.createdAt);
            }
        }
    }
}