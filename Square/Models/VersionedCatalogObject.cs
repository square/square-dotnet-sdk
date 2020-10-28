using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class VersionedCatalogObject 
    {
        public VersionedCatalogObject(string objectId = null,
            long? catalogVersion = null)
        {
            ObjectId = objectId;
            CatalogVersion = catalogVersion;
        }

        /// <summary>
        /// The ID of the referenced object.
        /// </summary>
        [JsonProperty("object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectId { get; }

        /// <summary>
        /// The version of the object.
        /// </summary>
        [JsonProperty("catalog_version", NullValueHandling = NullValueHandling.Ignore)]
        public long? CatalogVersion { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ObjectId(ObjectId)
                .CatalogVersion(CatalogVersion);
            return builder;
        }

        public class Builder
        {
            private string objectId;
            private long? catalogVersion;



            public Builder ObjectId(string objectId)
            {
                this.objectId = objectId;
                return this;
            }

            public Builder CatalogVersion(long? catalogVersion)
            {
                this.catalogVersion = catalogVersion;
                return this;
            }

            public VersionedCatalogObject Build()
            {
                return new VersionedCatalogObject(objectId,
                    catalogVersion);
            }
        }
    }
}