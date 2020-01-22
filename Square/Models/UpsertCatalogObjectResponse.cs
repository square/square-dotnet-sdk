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
    public class UpsertCatalogObjectResponse 
    {
        public UpsertCatalogObjectResponse(IList<Models.Error> errors = null,
            Models.CatalogObject catalogObject = null,
            IList<Models.CatalogIdMapping> idMappings = null)
        {
            Errors = errors;
            CatalogObject = catalogObject;
            IdMappings = idMappings;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on any errors encountered.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Getter for catalog_object
        /// </summary>
        [JsonProperty("catalog_object")]
        public Models.CatalogObject CatalogObject { get; }

        /// <summary>
        /// The mapping between client and server IDs for this upsert.
        /// </summary>
        [JsonProperty("id_mappings")]
        public IList<Models.CatalogIdMapping> IdMappings { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .CatalogObject(CatalogObject)
                .IdMappings(IdMappings);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.CatalogObject catalogObject;
            private IList<Models.CatalogIdMapping> idMappings = new List<Models.CatalogIdMapping>();

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder CatalogObject(Models.CatalogObject value)
            {
                catalogObject = value;
                return this;
            }

            public Builder IdMappings(IList<Models.CatalogIdMapping> value)
            {
                idMappings = value;
                return this;
            }

            public UpsertCatalogObjectResponse Build()
            {
                return new UpsertCatalogObjectResponse(errors,
                    catalogObject,
                    idMappings);
            }
        }
    }
}