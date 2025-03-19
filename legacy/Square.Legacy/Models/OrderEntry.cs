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
    /// OrderEntry.
    /// </summary>
    public class OrderEntry
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderEntry"/> class.
        /// </summary>
        /// <param name="orderId">order_id.</param>
        /// <param name="version">version.</param>
        /// <param name="locationId">location_id.</param>
        public OrderEntry(string orderId = null, int? version = null, string locationId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "order_id", false },
                { "location_id", false },
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
        }

        internal OrderEntry(
            Dictionary<string, bool> shouldSerialize,
            string orderId = null,
            int? version = null,
            string locationId = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            OrderId = orderId;
            Version = version;
            LocationId = locationId;
        }

        /// <summary>
        /// The ID of the order.
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
        /// The location ID the order belongs to.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"OrderEntry : ({string.Join(", ", toStringOutput)})";
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
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is OrderEntry other
                && (
                    this.OrderId == null && other.OrderId == null
                    || this.OrderId?.Equals(other.OrderId) == true
                )
                && (
                    this.Version == null && other.Version == null
                    || this.Version?.Equals(other.Version) == true
                )
                && (
                    this.LocationId == null && other.LocationId == null
                    || this.LocationId?.Equals(other.LocationId) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1818630263;
            hashCode = HashCode.Combine(hashCode, this.OrderId, this.Version, this.LocationId);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.OrderId = {this.OrderId ?? "null"}");
            toStringOutput.Add(
                $"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}"
            );
            toStringOutput.Add($"this.LocationId = {this.LocationId ?? "null"}");
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
                .LocationId(this.LocationId);
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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetOrderId()
            {
                this.shouldSerialize["order_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderEntry. </returns>
            public OrderEntry Build()
            {
                return new OrderEntry(shouldSerialize, this.orderId, this.version, this.locationId);
            }
        }
    }
}
