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
    public class SearchAvailabilityFilter 
    {
        public SearchAvailabilityFilter(Models.TimeRange startAtRange,
            string locationId = null,
            IList<Models.SegmentFilter> segmentFilters = null,
            string bookingId = null)
        {
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

        public Builder ToBuilder()
        {
            var builder = new Builder(StartAtRange)
                .LocationId(LocationId)
                .SegmentFilters(SegmentFilters)
                .BookingId(BookingId);
            return builder;
        }

        public class Builder
        {
            private Models.TimeRange startAtRange;
            private string locationId;
            private IList<Models.SegmentFilter> segmentFilters;
            private string bookingId;

            public Builder(Models.TimeRange startAtRange)
            {
                this.startAtRange = startAtRange;
            }

            public Builder StartAtRange(Models.TimeRange startAtRange)
            {
                this.startAtRange = startAtRange;
                return this;
            }

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public Builder SegmentFilters(IList<Models.SegmentFilter> segmentFilters)
            {
                this.segmentFilters = segmentFilters;
                return this;
            }

            public Builder BookingId(string bookingId)
            {
                this.bookingId = bookingId;
                return this;
            }

            public SearchAvailabilityFilter Build()
            {
                return new SearchAvailabilityFilter(startAtRange,
                    locationId,
                    segmentFilters,
                    bookingId);
            }
        }
    }
}