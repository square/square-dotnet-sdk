
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
        [JsonProperty("object_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> ObjectIds { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BatchDeleteCatalogObjectsRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ObjectIds = {(ObjectIds == null ? "null" : $"[{ string.Join(", ", ObjectIds)} ]")}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is BatchDeleteCatalogObjectsRequest other &&
                ((ObjectIds == null && other.ObjectIds == null) || (ObjectIds?.Equals(other.ObjectIds) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1606600759;

            if (ObjectIds != null)
            {
               hashCode += ObjectIds.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ObjectIds(ObjectIds);
            return builder;
        }

        public class Builder
        {
            private IList<string> objectIds;



            public Builder ObjectIds(IList<string> objectIds)
            {
                this.objectIds = objectIds;
                return this;
            }

            public BatchDeleteCatalogObjectsRequest Build()
            {
                return new BatchDeleteCatalogObjectsRequest(objectIds);
            }
        }
    }
}