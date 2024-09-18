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
    /// SearchAvailabilityFilter.
    /// </summary>
    public class SearchAvailabilityFilter
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchAvailabilityFilter"/> class.
        /// </summary>
        /// <param name="startAtRange">start_at_range.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="segmentFilters">segment_filters.</param>
        /// <param name="bookingId">booking_id.</param>
        public SearchAvailabilityFilter(
            Models.TimeRange startAtRange,
            string locationId = null,
            IList<Models.SegmentFilter> segmentFilters = null,
            string bookingId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "location_id", false },
                { "segment_filters", false },
                { "booking_id", false }
            };

            this.StartAtRange = startAtRange;
            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

            if (segmentFilters != null)
            {
                shouldSerialize["segment_filters"] = true;
                this.SegmentFilters = segmentFilters;
            }

            if (bookingId != null)
            {
                shouldSerialize["booking_id"] = true;
                this.BookingId = bookingId;
            }

        }
        internal SearchAvailabilityFilter(Dictionary<string, bool> shouldSerialize,
            Models.TimeRange startAtRange,
            string locationId = null,
            IList<Models.SegmentFilter> segmentFilters = null,
            string bookingId = null)
        {
            this.shouldSerialize = shouldSerialize;
            StartAtRange = startAtRange;
            LocationId = locationId;
            SegmentFilters = segmentFilters;
            BookingId = bookingId;
        }

        /// <summary>
        /// Represents a generic time range. The start and end values are
        /// represented in RFC 3339 format. Time ranges are customized to be
        /// inclusive or exclusive based on the needs of a particular endpoint.
        /// Refer to the relevant endpoint-specific documentation to determine
        /// how time ranges are handled.
        /// </summary>
        [JsonProperty("start_at_range")]
        public Models.TimeRange StartAtRange { get; }

        /// <summary>
        /// The query expression to search for buyer-accessible availabilities with their location IDs matching the specified location ID.
        /// This query expression cannot be set if `booking_id` is set.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The query expression to search for buyer-accessible availabilities matching the specified list of segment filters.
        /// If the size of the `segment_filters` list is `n`, the search returns availabilities with `n` segments per availability.
        /// This query expression cannot be set if `booking_id` is set.
        /// </summary>
        [JsonProperty("segment_filters")]
        public IList<Models.SegmentFilter> SegmentFilters { get; }

        /// <summary>
        /// The query expression to search for buyer-accessible availabilities for an existing booking by matching the specified `booking_id` value.
        /// This is commonly used to reschedule an appointment.
        /// If this expression is set, the `location_id` and `segment_filters` expressions cannot be set.
        /// </summary>
        [JsonProperty("booking_id")]
        public string BookingId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchAvailabilityFilter : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeSegmentFilters()
        {
            return this.shouldSerialize["segment_filters"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBookingId()
        {
            return this.shouldSerialize["booking_id"];
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
            return obj is SearchAvailabilityFilter other &&                ((this.StartAtRange == null && other.StartAtRange == null) || (this.StartAtRange?.Equals(other.StartAtRange) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.SegmentFilters == null && other.SegmentFilters == null) || (this.SegmentFilters?.Equals(other.SegmentFilters) == true)) &&
                ((this.BookingId == null && other.BookingId == null) || (this.BookingId?.Equals(other.BookingId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -735515174;
            hashCode = HashCode.Combine(this.StartAtRange, this.LocationId, this.SegmentFilters, this.BookingId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.StartAtRange = {(this.StartAtRange == null ? "null" : this.StartAtRange.ToString())}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.SegmentFilters = {(this.SegmentFilters == null ? "null" : $"[{string.Join(", ", this.SegmentFilters)} ]")}");
            toStringOutput.Add($"this.BookingId = {(this.BookingId == null ? "null" : this.BookingId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.StartAtRange)
                .LocationId(this.LocationId)
                .SegmentFilters(this.SegmentFilters)
                .BookingId(this.BookingId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "location_id", false },
                { "segment_filters", false },
                { "booking_id", false },
            };

            private Models.TimeRange startAtRange;
            private string locationId;
            private IList<Models.SegmentFilter> segmentFilters;
            private string bookingId;

            /// <summary>
            /// Initialize Builder for SearchAvailabilityFilter.
            /// </summary>
            /// <param name="startAtRange"> startAtRange. </param>
            public Builder(
                Models.TimeRange startAtRange)
            {
                this.startAtRange = startAtRange;
            }

             /// <summary>
             /// StartAtRange.
             /// </summary>
             /// <param name="startAtRange"> startAtRange. </param>
             /// <returns> Builder. </returns>
            public Builder StartAtRange(Models.TimeRange startAtRange)
            {
                this.startAtRange = startAtRange;
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
             /// SegmentFilters.
             /// </summary>
             /// <param name="segmentFilters"> segmentFilters. </param>
             /// <returns> Builder. </returns>
            public Builder SegmentFilters(IList<Models.SegmentFilter> segmentFilters)
            {
                shouldSerialize["segment_filters"] = true;
                this.segmentFilters = segmentFilters;
                return this;
            }

             /// <summary>
             /// BookingId.
             /// </summary>
             /// <param name="bookingId"> bookingId. </param>
             /// <returns> Builder. </returns>
            public Builder BookingId(string bookingId)
            {
                shouldSerialize["booking_id"] = true;
                this.bookingId = bookingId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSegmentFilters()
            {
                this.shouldSerialize["segment_filters"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBookingId()
            {
                this.shouldSerialize["booking_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchAvailabilityFilter. </returns>
            public SearchAvailabilityFilter Build()
            {
                return new SearchAvailabilityFilter(shouldSerialize,
                    this.startAtRange,
                    this.locationId,
                    this.segmentFilters,
                    this.bookingId);
            }
        }
    }
}