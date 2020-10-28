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
    public class BatchUpsertCatalogObjectsResponse 
    {
        public BatchUpsertCatalogObjectsResponse(IList<Models.Error> errors = null,
            IList<Models.CatalogObject> objects = null,
            string updatedAt = null,
            IList<Models.CatalogIdMapping> idMappings = null)
        {
            Errors = errors;
            Objects = objects;
            UpdatedAt = updatedAt;
            IdMappings = idMappings;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The created successfully created CatalogObjects.
        /// </summary>
        [JsonProperty("objects", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogObject> Objects { get; }

        /// <summary>
        /// The database [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates) of this update in RFC 3339 format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The mapping between client and server IDs for this upsert.
        /// </summary>
        [JsonProperty("id_mappings", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogIdMapping> IdMappings { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Objects(Objects)
                .UpdatedAt(UpdatedAt)
                .IdMappings(IdMappings);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.CatalogObject> objects;
            private string updatedAt;
            private IList<Models.CatalogIdMapping> idMappings;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Objects(IList<Models.CatalogObject> objects)
            {
                this.objects = objects;
                return this;
            }

            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            public Builder IdMappings(IList<Models.CatalogIdMapping> idMappings)
            {
                this.idMappings = idMappings;
                return this;
            }

            public BatchUpsertCatalogObjectsResponse Build()
            {
                return new BatchUpsertCatalogObjectsResponse(errors,
                    objects,
                    updatedAt,
                    idMappings);
            }
        }
    }
}