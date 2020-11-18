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
    public class SearchAvailabilityResponse 
    {
        public SearchAvailabilityResponse(IList<Models.Availability> availabilities = null,
            IList<Models.Error> errors = null)
        {
            Availabilities = availabilities;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// List of slots available for booking.
        /// </summary>
        [JsonProperty("availabilities", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Availability> Availabilities { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Availabilities(Availabilities)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Availability> availabilities;
            private IList<Models.Error> errors;



            public Builder Availabilities(IList<Models.Availability> availabilities)
            {
                this.availabilities = availabilities;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public SearchAvailabilityResponse Build()
            {
                return new SearchAvailabilityResponse(availabilities,
                    errors);
            }
        }
    }
}