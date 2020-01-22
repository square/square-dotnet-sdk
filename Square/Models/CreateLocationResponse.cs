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
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Getter for location
        /// </summary>
        [JsonProperty("location")]
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
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.Location location;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Location(Models.Location value)
            {
                location = value;
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