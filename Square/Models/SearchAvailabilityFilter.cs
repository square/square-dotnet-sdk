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
    /// SearchAvailabilityFilter.
    /// </summary>
    public class SearchAvailabilityFilter
    {
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
            this.StartAtRange = startAtRange;
            this.LocationId = locationId;
            this.SegmentFilters = segmentFilters;
            this.BookingId = bookingId;
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
        /// The query expression to search for availabilities matching the specified seller location IDs.
        /// This query expression is not applicable when `booking_id` is present.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The list of segment filters to apply. A query with `n` segment filters returns availabilities with `n` segments per
        /// availability. It is not applicable when `booking_id` is present.
        /// </summary>
        [JsonProperty("segment_filters", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.SegmentFilter> SegmentFilters { get; }

        /// <summary>
        /// The query expression to search for availabilities for an existing booking by matching the specified `booking_id` value.
        /// This is commonly used to reschedule an appointment.
        /// If this expression is specified, the `location_id` and `segment_filters` expressions are not allowed.
        /// </summary>
        [JsonProperty("booking_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BookingId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchAvailabilityFilter : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchAvailabilityFilter other &&
                ((this.StartAtRange == null && other.StartAtRange == null) || (this.StartAtRange?.Equals(other.StartAtRange) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.SegmentFilters == null && other.SegmentFilters == null) || (this.SegmentFilters?.Equals(other.SegmentFilters) == true)) &&
                ((this.BookingId == null && other.BookingId == null) || (this.BookingId?.Equals(other.BookingId) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -735515174;

            if (this.StartAtRange != null)
            {
               hashCode += this.StartAtRange.GetHashCode();
            }

            if (this.LocationId != null)
            {
               hashCode += this.LocationId.GetHashCode();
            }

            if (this.SegmentFilters != null)
            {
               hashCode += this.SegmentFilters.GetHashCode();
            }

            if (this.BookingId != null)
            {
               hashCode += this.BookingId.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.StartAtRange = {(this.StartAtRange == null ? "null" : this.StartAtRange.ToString())}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.SegmentFilters = {(this.SegmentFilters == null ? "null" : $"[{string.Join(", ", this.SegmentFilters)} ]")}");
            toStringOutput.Add($"this.BookingId = {(this.BookingId == null ? "null" : this.BookingId == string.Empty ? "" : this.BookingId)}");
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
            private Models.TimeRange startAtRange;
            private string locationId;
            private IList<Models.SegmentFilter> segmentFilters;
            private string bookingId;

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
                this.bookingId = bookingId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchAvailabilityFilter. </returns>
            public SearchAvailabilityFilter Build()
            {
                return new SearchAvailabilityFilter(
                    this.startAtRange,
                    this.locationId,
                    this.segmentFilters,
                    this.bookingId);
            }
        }
    }
}