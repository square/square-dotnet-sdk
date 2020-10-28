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
    public class BatchRetrieveCatalogObjectsRequest 
    {
        public BatchRetrieveCatalogObjectsRequest(IList<string> objectIds,
            bool? includeRelatedObjects = null)
        {
            ObjectIds = objectIds;
            IncludeRelatedObjects = includeRelatedObjects;
        }

        /// <summary>
        /// The IDs of the CatalogObjects to be retrieved.
        /// </summary>
        [JsonProperty("object_ids")]
        public IList<string> ObjectIds { get; }

        /// <summary>
        /// If `true`, the response will include additional objects that are related to the
        /// requested objects, as follows:
        /// If the `objects` field of the response contains a CatalogItem, its associated
        /// CatalogCategory objects, CatalogTax objects, CatalogImage objects and
        /// CatalogModifierLists will be returned in the `related_objects` field of the
        /// response. If the `objects` field of the response contains a CatalogItemVariation,
        /// its parent CatalogItem will be returned in the `related_objects` field of
        /// the response.
        /// </summary>
        [JsonProperty("include_related_objects", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeRelatedObjects { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(ObjectIds)
                .IncludeRelatedObjects(IncludeRelatedObjects);
            return builder;
        }

        public class Builder
        {
            private IList<string> objectIds;
            private bool? includeRelatedObjects;

            public Builder(IList<string> objectIds)
            {
                this.objectIds = objectIds;
            }

            public Builder ObjectIds(IList<string> objectIds)
            {
                this.objectIds = objectIds;
                return this;
            }

            public Builder IncludeRelatedObjects(bool? includeRelatedObjects)
            {
                this.includeRelatedObjects = includeRelatedObjects;
                return this;
            }

            public BatchRetrieveCatalogObjectsRequest Build()
            {
                return new BatchRetrieveCatalogObjectsRequest(objectIds,
                    includeRelatedObjects);
            }
        }
    }
}