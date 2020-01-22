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
    public class ListLocationsResponse 
    {
        public ListLocationsResponse(IList<Models.Error> errors = null,
            IList<Models.Location> locations = null)
        {
            Errors = errors;
            Locations = locations;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The business locations.
        /// </summary>
        [JsonProperty("locations")]
        public IList<Models.Location> Locations { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Locations(Locations);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.Location> locations = new List<Models.Location>();

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Locations(IList<Models.Location> value)
            {
                locations = value;
                return this;
            }

            public ListLocationsResponse Build()
            {
                return new ListLocationsResponse(errors,
                    locations);
            }
        }
    }
}