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
    public class Availability 
    {
        public Availability(string startAt = null,
            string locationId = null,
            IList<Models.AppointmentSegment> appointmentSegments = null)
        {
            StartAt = startAt;
            LocationId = locationId;
            AppointmentSegments = appointmentSegments;
        }

        /// <summary>
        /// The RFC-3339 timestamp specifying the beginning time of the slot available for booking.
        /// </summary>
        [JsonProperty("start_at", NullValueHandling = NullValueHandling.Ignore)]
        public string StartAt { get; }

        /// <summary>
        /// The ID of the location available for booking.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The list of appointment segments available for booking
        /// </summary>
        [JsonProperty("appointment_segments", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.AppointmentSegment> AppointmentSegments { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .StartAt(StartAt)
                .LocationId(LocationId)
                .AppointmentSegments(AppointmentSegments);
            return builder;
        }

        public class Builder
        {
            private string startAt;
            private string locationId;
            private IList<Models.AppointmentSegment> appointmentSegments;



            public Builder StartAt(string startAt)
            {
                this.startAt = startAt;
                return this;
            }

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public Builder AppointmentSegments(IList<Models.AppointmentSegment> appointmentSegments)
            {
                this.appointmentSegments = appointmentSegments;
                return this;
            }

            public Availability Build()
            {
                return new Availability(startAt,
                    locationId,
                    appointmentSegments);
            }
        }
    }
}