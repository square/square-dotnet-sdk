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
    public class RetrieveCatalogObjectRequest 
    {
        public RetrieveCatalogObjectRequest(bool? includeRelatedObjects = null,
            long? catalogVersion = null)
        {
            IncludeRelatedObjects = includeRelatedObjects;
            CatalogVersion = catalogVersion;
        }

        /// <summary>
        /// If `true`, the response will include additional objects that are related to the
        /// requested object, as follows:
        /// If the `object` field of the response contains a `CatalogItem`, its associated
        /// `CatalogCategory`, `CatalogTax`, `CatalogImage` and `CatalogModifierList` objects will
        /// be returned in the `related_objects` field of the response. If the `object` field of
        /// the response contains a `CatalogItemVariation`, its parent `CatalogItem` will be returned
        /// in the `related_objects` field of the response.
        /// Default value: `false`
        /// </summary>
        [JsonProperty("include_related_objects", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeRelatedObjects { get; }

        /// <summary>
        /// Requests objects as of a specific version of the catalog. This allows you to retrieve historical
        /// versions of objects. The value to retrieve a specific version of an object can be found
        /// in the version field of [CatalogObject](#type-catalogobject)s.
        /// </summary>
        [JsonProperty("catalog_version", NullValueHandling = NullValueHandling.Ignore)]
        public long? CatalogVersion { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .IncludeRelatedObjects(IncludeRelatedObjects)
                .CatalogVersion(CatalogVersion);
            return builder;
        }

        public class Builder
        {
            private bool? includeRelatedObjects;
            private long? catalogVersion;



            public Builder IncludeRelatedObjects(bool? includeRelatedObjects)
            {
                this.includeRelatedObjects = includeRelatedObjects;
                return this;
            }

            public Builder CatalogVersion(long? catalogVersion)
            {
                this.catalogVersion = catalogVersion;
                return this;
            }

            public RetrieveCatalogObjectRequest Build()
            {
                return new RetrieveCatalogObjectRequest(includeRelatedObjects,
                    catalogVersion);
            }
        }
    }
}