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
    public class RetrieveCatalogObjectResponse 
    {
        public RetrieveCatalogObjectResponse(IList<Models.Error> errors = null,
            Models.CatalogObject mObject = null,
            IList<Models.CatalogObject> relatedObjects = null)
        {
            Errors = errors;
            MObject = mObject;
            RelatedObjects = relatedObjects;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on any errors encountered.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Getter for object
        /// </summary>
        [JsonProperty("object")]
        public Models.CatalogObject MObject { get; }

        /// <summary>
        /// A list of CatalogObjects referenced by the object in the `object` field.
        /// </summary>
        [JsonProperty("related_objects")]
        public IList<Models.CatalogObject> RelatedObjects { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .MObject(MObject)
                .RelatedObjects(RelatedObjects);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.CatalogObject mObject;
            private IList<Models.CatalogObject> relatedObjects = new List<Models.CatalogObject>();

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder MObject(Models.CatalogObject value)
            {
                mObject = value;
                return this;
            }

            public Builder RelatedObjects(IList<Models.CatalogObject> value)
            {
                relatedObjects = value;
                return this;
            }

            public RetrieveCatalogObjectResponse Build()
            {
                return new RetrieveCatalogObjectResponse(errors,
                    mObject,
                    relatedObjects);
            }
        }
    }
}