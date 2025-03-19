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
    /// Event.
    /// </summary>
    public class Event
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <param name="merchantId">merchant_id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="type">type.</param>
        /// <param name="eventId">event_id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="data">data.</param>
        public Event(
            string merchantId = null,
            string locationId = null,
            string type = null,
            string eventId = null,
            string createdAt = null,
            Models.EventData data = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "merchant_id", false },
                { "location_id", false },
                { "type", false },
                { "event_id", false },
            };

            if (merchantId != null)
            {
                shouldSerialize["merchant_id"] = true;
                this.MerchantId = merchantId;
            }

            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

            if (type != null)
            {
                shouldSerialize["type"] = true;
                this.Type = type;
            }

            if (eventId != null)
            {
                shouldSerialize["event_id"] = true;
                this.EventId = eventId;
            }
            this.CreatedAt = createdAt;
            this.Data = data;
        }

        internal Event(
            Dictionary<string, bool> shouldSerialize,
            string merchantId = null,
            string locationId = null,
            string type = null,
            string eventId = null,
            string createdAt = null,
            Models.EventData data = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            MerchantId = merchantId;
            LocationId = locationId;
            Type = type;
            EventId = eventId;
            CreatedAt = createdAt;
            Data = data;
        }

        /// <summary>
        /// The ID of the target merchant associated with the event.
        /// </summary>
        [JsonProperty("merchant_id")]
        public string MerchantId { get; }

        /// <summary>
        /// The ID of the target location associated with the event.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The type of event this represents.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// A unique ID for the event.
        /// </summary>
        [JsonProperty("event_id")]
        public string EventId { get; }

        /// <summary>
        /// Timestamp of when the event was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// Gets or sets Data.
        /// </summary>
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.EventData Data { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"Event : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMerchantId()
        {
            return this.shouldSerialize["merchant_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeType()
        {
            return this.shouldSerialize["type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEventId()
        {
            return this.shouldSerialize["event_id"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is Event other
                && (
                    this.MerchantId == null && other.MerchantId == null
                    || this.MerchantId?.Equals(other.MerchantId) == true
                )
                && (
                    this.LocationId == null && other.LocationId == null
                    || this.LocationId?.Equals(other.LocationId) == true
                )
                && (
                    this.Type == null && other.Type == null || this.Type?.Equals(other.Type) == true
                )
                && (
                    this.EventId == null && other.EventId == null
                    || this.EventId?.Equals(other.EventId) == true
                )
                && (
                    this.CreatedAt == null && other.CreatedAt == null
                    || this.CreatedAt?.Equals(other.CreatedAt) == true
                )
                && (
                    this.Data == null && other.Data == null || this.Data?.Equals(other.Data) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1541969600;
            hashCode = HashCode.Combine(
                hashCode,
                this.MerchantId,
                this.LocationId,
                this.Type,
                this.EventId,
                this.CreatedAt,
                this.Data
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MerchantId = {this.MerchantId ?? "null"}");
            toStringOutput.Add($"this.LocationId = {this.LocationId ?? "null"}");
            toStringOutput.Add($"this.Type = {this.Type ?? "null"}");
            toStringOutput.Add($"this.EventId = {this.EventId ?? "null"}");
            toStringOutput.Add($"this.CreatedAt = {this.CreatedAt ?? "null"}");
            toStringOutput.Add(
                $"this.Data = {(this.Data == null ? "null" : this.Data.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .MerchantId(this.MerchantId)
                .LocationId(this.LocationId)
                .Type(this.Type)
                .EventId(this.EventId)
                .CreatedAt(this.CreatedAt)
                .Data(this.Data);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "merchant_id", false },
                { "location_id", false },
                { "type", false },
                { "event_id", false },
            };

            private string merchantId;
            private string locationId;
            private string type;
            private string eventId;
            private string createdAt;
            private Models.EventData data;

            /// <summary>
            /// MerchantId.
            /// </summary>
            /// <param name="merchantId"> merchantId. </param>
            /// <returns> Builder. </returns>
            public Builder MerchantId(string merchantId)
            {
                shouldSerialize["merchant_id"] = true;
                this.merchantId = merchantId;
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
            /// Type.
            /// </summary>
            /// <param name="type"> type. </param>
            /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                shouldSerialize["type"] = true;
                this.type = type;
                return this;
            }

            /// <summary>
            /// EventId.
            /// </summary>
            /// <param name="eventId"> eventId. </param>
            /// <returns> Builder. </returns>
            public Builder EventId(string eventId)
            {
                shouldSerialize["event_id"] = true;
                this.eventId = eventId;
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
            /// Data.
            /// </summary>
            /// <param name="data"> data. </param>
            /// <returns> Builder. </returns>
            public Builder Data(Models.EventData data)
            {
                this.data = data;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetMerchantId()
            {
                this.shouldSerialize["merchant_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetType()
            {
                this.shouldSerialize["type"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetEventId()
            {
                this.shouldSerialize["event_id"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Event. </returns>
            public Event Build()
            {
                return new Event(
                    shouldSerialize,
                    this.merchantId,
                    this.locationId,
                    this.type,
                    this.eventId,
                    this.createdAt,
                    this.data
                );
            }
        }
    }
}
