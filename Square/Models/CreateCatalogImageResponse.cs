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
    public class CreateCatalogImageResponse 
    {
        public CreateCatalogImageResponse(IList<Models.Error> errors = null,
            Models.CatalogObject image = null)
        {
            Errors = errors;
            Image = image;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on any errors encountered.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Getter for image
        /// </summary>
        [JsonProperty("image")]
        public Models.CatalogObject Image { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Image(Image);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.CatalogObject image;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Image(Models.CatalogObject value)
            {
                image = value;
                return this;
            }

            public CreateCatalogImageResponse Build()
            {
                return new CreateCatalogImageResponse(errors,
                    image);
            }
        }
    }
}