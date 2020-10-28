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
    public class CreateLocationResponse 
    {
        public CreateLocationResponse(IList<Models.Error> errors = null,
            Models.Location location = null)
        {
            Errors = errors;
            Location = location;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Getter for location
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Location Location { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Location(Location);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.Location location;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Location(Models.Location location)
            {
                this.location = location;
                return this;
            }

            public CreateLocationResponse Build()
            {
                return new CreateLocationResponse(errors,
                    location);
            }
        }
    }
}