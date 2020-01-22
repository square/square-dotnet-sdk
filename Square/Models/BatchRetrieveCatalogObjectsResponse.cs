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
    public class BatchRetrieveCatalogObjectsResponse 
    {
        public BatchRetrieveCatalogObjectsResponse(IList<Models.Error> errors = null,
            IList<Models.CatalogObject> objects = null,
            IList<Models.CatalogObject> relatedObjects = null)
        {
            Errors = errors;
            Objects = objects;
            RelatedObjects = relatedObjects;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The set of [Error](#type-error)s encountered.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// A list of [CatalogObject](#type-catalogobject)s returned.
        /// </summary>
        [JsonProperty("objects")]
        public IList<Models.CatalogObject> Objects { get; }

        /// <summary>
        /// A list of [CatalogObject](#type-catalogobject)s referenced by the object in the `objects` field.
        /// </summary>
        [JsonProperty("related_objects")]
        public IList<Models.CatalogObject> RelatedObjects { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Objects(Objects)
                .RelatedObjects(RelatedObjects);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.CatalogObject> objects = new List<Models.CatalogObject>();
            private IList<Models.CatalogObject> relatedObjects = new List<Models.CatalogObject>();

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Objects(IList<Models.CatalogObject> value)
            {
                objects = value;
                return this;
            }

            public Builder RelatedObjects(IList<Models.CatalogObject> value)
            {
                relatedObjects = value;
                return this;
            }

            public BatchRetrieveCatalogObjectsResponse Build()
            {
                return new BatchRetrieveCatalogObjectsResponse(errors,
                    objects,
                    relatedObjects);
            }
        }
    }
}