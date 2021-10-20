namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// BatchRetrieveCatalogObjectsRequest.
    /// </summary>
    public class BatchRetrieveCatalogObjectsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchRetrieveCatalogObjectsRequest"/> class.
        /// </summary>
        /// <param name="objectIds">object_ids.</param>
        /// <param name="includeRelatedObjects">include_related_objects.</param>
        /// <param name="catalogVersion">catalog_version.</param>
        public BatchRetrieveCatalogObjectsRequest(
            IList<string> objectIds,
            bool? includeRelatedObjects = null,
            long? catalogVersion = null)
        {
            this.ObjectIds = objectIds;
            this.IncludeRelatedObjects = includeRelatedObjects;
            this.CatalogVersion = catalogVersion;
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

        /// <summary>
        /// The specific version of the catalog objects to be included in the response.
        /// This allows you to retrieve historical versions of objects. The specified version value is matched against
        /// the [CatalogObject]($m/CatalogObject)s' `version` attribute.
        /// </summary>
        [JsonProperty("catalog_version", NullValueHandling = NullValueHandling.Ignore)]
        public long? CatalogVersion { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BatchRetrieveCatalogObjectsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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

            return obj is BatchRetrieveCatalogObjectsRequest other &&
                ((this.ObjectIds == null && other.ObjectIds == null) || (this.ObjectIds?.Equals(other.ObjectIds) == true)) &&
                ((this.IncludeRelatedObjects == null && other.IncludeRelatedObjects == null) || (this.IncludeRelatedObjects?.Equals(other.IncludeRelatedObjects) == true)) &&
                ((this.CatalogVersion == null && other.CatalogVersion == null) || (this.CatalogVersion?.Equals(other.CatalogVersion) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 664426275;
            hashCode = HashCode.Combine(this.ObjectIds, this.IncludeRelatedObjects, this.CatalogVersion);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ObjectIds = {(this.ObjectIds == null ? "null" : $"[{string.Join(", ", this.ObjectIds)} ]")}");
            toStringOutput.Add($"this.IncludeRelatedObjects = {(this.IncludeRelatedObjects == null ? "null" : this.IncludeRelatedObjects.ToString())}");
            toStringOutput.Add($"this.CatalogVersion = {(this.CatalogVersion == null ? "null" : this.CatalogVersion.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.ObjectIds)
                .IncludeRelatedObjects(this.IncludeRelatedObjects)
                .CatalogVersion(this.CatalogVersion);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> objectIds;
            private bool? includeRelatedObjects;
            private long? catalogVersion;

            public Builder(
                IList<string> objectIds)
            {
                this.objectIds = objectIds;
            }

             /// <summary>
             /// ObjectIds.
             /// </summary>
             /// <param name="objectIds"> objectIds. </param>
             /// <returns> Builder. </returns>
            public Builder ObjectIds(IList<string> objectIds)
            {
                this.objectIds = objectIds;
                return this;
            }

             /// <summary>
             /// IncludeRelatedObjects.
             /// </summary>
             /// <param name="includeRelatedObjects"> includeRelatedObjects. </param>
             /// <returns> Builder. </returns>
            public Builder IncludeRelatedObjects(bool? includeRelatedObjects)
            {
                this.includeRelatedObjects = includeRelatedObjects;
                return this;
            }

             /// <summary>
             /// CatalogVersion.
             /// </summary>
             /// <param name="catalogVersion"> catalogVersion. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogVersion(long? catalogVersion)
            {
                this.catalogVersion = catalogVersion;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BatchRetrieveCatalogObjectsRequest. </returns>
            public BatchRetrieveCatalogObjectsRequest Build()
            {
                return new BatchRetrieveCatalogObjectsRequest(
                    this.objectIds,
                    this.includeRelatedObjects,
                    this.catalogVersion);
            }
        }
    }
}