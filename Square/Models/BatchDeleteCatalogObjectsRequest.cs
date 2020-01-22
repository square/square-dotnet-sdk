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
    public class BatchDeleteCatalogObjectsRequest 
    {
        public BatchDeleteCatalogObjectsRequest(IList<string> objectIds = null)
        {
            ObjectIds = objectIds;
        }

        /// <summary>
        /// The IDs of the CatalogObjects to be deleted. When an object is deleted, other objects
        /// in the graph that depend on that object will be deleted as well (for example, deleting a
        /// CatalogItem will delete its CatalogItemVariation.
        /// </summary>
        [JsonProperty("object_ids")]
        public IList<string> ObjectIds { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ObjectIds(ObjectIds);
            return builder;
        }

        public class Builder
        {
            private IList<string> objectIds = new List<string>();

            public Builder() { }
            public Builder ObjectIds(IList<string> value)
            {
                objectIds = value;
                return this;
            }

            public BatchDeleteCatalogObjectsRequest Build()
            {
                return new BatchDeleteCatalogObjectsRequest(objectIds);
            }
        }
    }
}