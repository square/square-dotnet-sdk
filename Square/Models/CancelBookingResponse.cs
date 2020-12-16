using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class CancelBookingResponse 
    {
        public CancelBookingResponse(Models.Booking booking = null,
            IList<Models.Error> errors = null)
        {
            Booking = booking;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Represents a booking as a time-bound service contract for a seller's staff member to provide a specified service
        /// at a given location to a requesting customer in one or more appointment segments.
        /// </summary>
        [JsonProperty("booking", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Booking Booking { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Booking(Booking)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private Models.Booking booking;
            private IList<Models.Error> errors;



            public Builder Booking(Models.Booking booking)
            {
                this.booking = booking;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public CancelBookingResponse Build()
            {
                return new CancelBookingResponse(booking,
                    errors);
            }
        }
    }
}