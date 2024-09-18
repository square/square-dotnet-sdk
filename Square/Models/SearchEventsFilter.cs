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

namespace Square.Models
{
    /// <summary>
    /// SearchEventsFilter.
    /// </summary>
    public class SearchEventsFilter
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchEventsFilter"/> class.
        /// </summary>
        /// <param name="eventTypes">event_types.</param>
        /// <param name="merchantIds">merchant_ids.</param>
        /// <param name="locationIds">location_ids.</param>
        /// <param name="createdAt">created_at.</param>
        public SearchEventsFilter(
            IList<string> eventTypes = null,
            IList<string> merchantIds = null,
            IList<string> locationIds = null,
            Models.TimeRange createdAt = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "event_types", false },
                { "merchant_ids", false },
                { "location_ids", false }
            };

            if (eventTypes != null)
            {
                shouldSerialize["event_types"] = true;
                this.EventTypes = eventTypes;
            }

            if (merchantIds != null)
            {
                shouldSerialize["merchant_ids"] = true;
                this.MerchantIds = merchantIds;
            }

            if (locationIds != null)
            {
                shouldSerialize["location_ids"] = true;
                this.LocationIds = locationIds;
            }

            this.CreatedAt = createdAt;
        }
        internal SearchEventsFilter(Dictionary<string, bool> shouldSerialize,
            IList<string> eventTypes = null,
            IList<string> merchantIds = null,
            IList<string> locationIds = null,
            Models.TimeRange createdAt = null)
        {
            this.shouldSerialize = shouldSerialize;
            EventTypes = eventTypes;
            MerchantIds = merchantIds;
            LocationIds = locationIds;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// Filter events by event types.
        /// </summary>
        [JsonProperty("event_types")]
        public IList<string> EventTypes { get; }

        /// <summary>
        /// Filter events by merchant.
        /// </summary>
        [JsonProperty("merchant_ids")]
        public IList<string> MerchantIds { get; }

        /// <summary>
        /// Filter events by location.
        /// </summary>
        [JsonProperty("location_ids")]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// Represents a generic time range. The start and end values are
        /// represented in RFC 3339 format. Time ranges are customized to be
        /// inclusive or exclusive based on the needs of a particular endpoint.
        /// Refer to the relevant endpoint-specific documentation to determine
        /// how time ranges are handled.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TimeRange CreatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchEventsFilter : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEventTypes()
        {
            return this.shouldSerialize["event_types"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMerchantIds()
        {
            return this.shouldSerialize["merchant_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationIds()
        {
            return this.shouldSerialize["location_ids"];
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
            return obj is SearchEventsFilter other &&                ((this.EventTypes == null && other.EventTypes == null) || (this.EventTypes?.Equals(other.EventTypes) == true)) &&
                ((this.MerchantIds == null && other.MerchantIds == null) || (this.MerchantIds?.Equals(other.MerchantIds) == true)) &&
                ((this.LocationIds == null && other.LocationIds == null) || (this.LocationIds?.Equals(other.LocationIds) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1776946700;
            hashCode = HashCode.Combine(this.EventTypes, this.MerchantIds, this.LocationIds, this.CreatedAt);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EventTypes = {(this.EventTypes == null ? "null" : $"[{string.Join(", ", this.EventTypes)} ]")}");
            toStringOutput.Add($"this.MerchantIds = {(this.MerchantIds == null ? "null" : $"[{string.Join(", ", this.MerchantIds)} ]")}");
            toStringOutput.Add($"this.LocationIds = {(this.LocationIds == null ? "null" : $"[{string.Join(", ", this.LocationIds)} ]")}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EventTypes(this.EventTypes)
                .MerchantIds(this.MerchantIds)
                .LocationIds(this.LocationIds)
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
                { "event_types", false },
                { "merchant_ids", false },
                { "location_ids", false },
            };

            private IList<string> eventTypes;
            private IList<string> merchantIds;
            private IList<string> locationIds;
            private Models.TimeRange createdAt;

             /// <summary>
             /// EventTypes.
             /// </summary>
             /// <param name="eventTypes"> eventTypes. </param>
             /// <returns> Builder. </returns>
            public Builder EventTypes(IList<string> eventTypes)
            {
                shouldSerialize["event_types"] = true;
                this.eventTypes = eventTypes;
                return this;
            }

             /// <summary>
             /// MerchantIds.
             /// </summary>
             /// <param name="merchantIds"> merchantIds. </param>
             /// <returns> Builder. </returns>
            public Builder MerchantIds(IList<string> merchantIds)
            {
                shouldSerialize["merchant_ids"] = true;
                this.merchantIds = merchantIds;
                return this;
            }

             /// <summary>
             /// LocationIds.
             /// </summary>
             /// <param name="locationIds"> locationIds. </param>
             /// <returns> Builder. </returns>
            public Builder LocationIds(IList<string> locationIds)
            {
                shouldSerialize["location_ids"] = true;
                this.locationIds = locationIds;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(Models.TimeRange createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEventTypes()
            {
                this.shouldSerialize["event_types"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMerchantIds()
            {
                this.shouldSerialize["merchant_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocationIds()
            {
                this.shouldSerialize["location_ids"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchEventsFilter. </returns>
            public SearchEventsFilter Build()
            {
                return new SearchEventsFilter(shouldSerialize,
                    this.eventTypes,
                    this.merchantIds,
                    this.locationIds,
                    this.createdAt);
            }
        }
    }
}