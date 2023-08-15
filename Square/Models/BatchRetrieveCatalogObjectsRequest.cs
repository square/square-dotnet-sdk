namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// BatchRetrieveCatalogObjectsRequest.
    /// </summary>
    public class BatchRetrieveCatalogObjectsRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchRetrieveCatalogObjectsRequest"/> class.
        /// </summary>
        /// <param name="objectIds">object_ids.</param>
        /// <param name="includeRelatedObjects">include_related_objects.</param>
        /// <param name="catalogVersion">catalog_version.</param>
        /// <param name="includeDeletedObjects">include_deleted_objects.</param>
        public BatchRetrieveCatalogObjectsRequest(
            IList<string> objectIds,
            bool? includeRelatedObjects = null,
            long? catalogVersion = null,
            bool? includeDeletedObjects = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "include_related_objects", false },
                { "catalog_version", false },
                { "include_deleted_objects", false }
            };

            this.ObjectIds = objectIds;
            if (includeRelatedObjects != null)
            {
                shouldSerialize["include_related_objects"] = true;
                this.IncludeRelatedObjects = includeRelatedObjects;
            }

            if (catalogVersion != null)
            {
                shouldSerialize["catalog_version"] = true;
                this.CatalogVersion = catalogVersion;
            }

            if (includeDeletedObjects != null)
            {
                shouldSerialize["include_deleted_objects"] = true;
                this.IncludeDeletedObjects = includeDeletedObjects;
            }

        }
        internal BatchRetrieveCatalogObjectsRequest(Dictionary<string, bool> shouldSerialize,
            IList<string> objectIds,
            bool? includeRelatedObjects = null,
            long? catalogVersion = null,
            bool? includeDeletedObjects = null)
        {
            this.shouldSerialize = shouldSerialize;
            ObjectIds = objectIds;
            IncludeRelatedObjects = includeRelatedObjects;
            CatalogVersion = catalogVersion;
            IncludeDeletedObjects = includeDeletedObjects;
        }

        /// <summary>
        /// The IDs of the CatalogObjects to be retrieved.
        /// </summary>
        [JsonProperty("object_ids")]
        public IList<string> ObjectIds { get; }

        /// <summary>
        /// If `true`, the response will include additional objects that are related to the
        /// requested objects. Related objects are defined as any objects referenced by ID by the results in the `objects` field
        /// of the response. These objects are put in the `related_objects` field. Setting this to `true` is
        /// helpful when the objects are needed for immediate display to a user.
        /// This process only goes one level deep. Objects referenced by the related objects will not be included. For example,
        /// if the `objects` field of the response contains a CatalogItem, its associated
        /// CatalogCategory objects, CatalogTax objects, CatalogImage objects and
        /// CatalogModifierLists will be returned in the `related_objects` field of the
        /// response. If the `objects` field of the response contains a CatalogItemVariation,
        /// its parent CatalogItem will be returned in the `related_objects` field of
        /// the response.
        /// Default value: `false`
        /// </summary>
        [JsonProperty("include_related_objects")]
        public bool? IncludeRelatedObjects { get; }

        /// <summary>
        /// The specific version of the catalog objects to be included in the response.
        /// This allows you to retrieve historical versions of objects. The specified version value is matched against
        /// the [CatalogObject]($m/CatalogObject)s' `version` attribute. If not included, results will
        /// be from the current version of the catalog.
        /// </summary>
        [JsonProperty("catalog_version")]
        public long? CatalogVersion { get; }

        /// <summary>
        /// Indicates whether to include (`true`) or not (`false`) in the response deleted objects, namely, those with the `is_deleted` attribute set to `true`.
        /// </summary>
        [JsonProperty("include_deleted_objects")]
        public bool? IncludeDeletedObjects { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BatchRetrieveCatalogObjectsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIncludeRelatedObjects()
        {
            return this.shouldSerialize["include_related_objects"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCatalogVersion()
        {
            return this.shouldSerialize["catalog_version"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIncludeDeletedObjects()
        {
            return this.shouldSerialize["include_deleted_objects"];
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
            return obj is BatchRetrieveCatalogObjectsRequest other &&                ((this.ObjectIds == null && other.ObjectIds == null) || (this.ObjectIds?.Equals(other.ObjectIds) == true)) &&
                ((this.IncludeRelatedObjects == null && other.IncludeRelatedObjects == null) || (this.IncludeRelatedObjects?.Equals(other.IncludeRelatedObjects) == true)) &&
                ((this.CatalogVersion == null && other.CatalogVersion == null) || (this.CatalogVersion?.Equals(other.CatalogVersion) == true)) &&
                ((this.IncludeDeletedObjects == null && other.IncludeDeletedObjects == null) || (this.IncludeDeletedObjects?.Equals(other.IncludeDeletedObjects) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1492875239;
            hashCode = HashCode.Combine(this.ObjectIds, this.IncludeRelatedObjects, this.CatalogVersion, this.IncludeDeletedObjects);

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
            toStringOutput.Add($"this.IncludeDeletedObjects = {(this.IncludeDeletedObjects == null ? "null" : this.IncludeDeletedObjects.ToString())}");
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
                .CatalogVersion(this.CatalogVersion)
                .IncludeDeletedObjects(this.IncludeDeletedObjects);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "include_related_objects", false },
                { "catalog_version", false },
                { "include_deleted_objects", false },
            };

            private IList<string> objectIds;
            private bool? includeRelatedObjects;
            private long? catalogVersion;
            private bool? includeDeletedObjects;

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
                shouldSerialize["include_related_objects"] = true;
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
                shouldSerialize["catalog_version"] = true;
                this.catalogVersion = catalogVersion;
                return this;
            }

             /// <summary>
             /// IncludeDeletedObjects.
             /// </summary>
             /// <param name="includeDeletedObjects"> includeDeletedObjects. </param>
             /// <returns> Builder. </returns>
            public Builder IncludeDeletedObjects(bool? includeDeletedObjects)
            {
                shouldSerialize["include_deleted_objects"] = true;
                this.includeDeletedObjects = includeDeletedObjects;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIncludeRelatedObjects()
            {
                this.shouldSerialize["include_related_objects"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCatalogVersion()
            {
                this.shouldSerialize["catalog_version"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIncludeDeletedObjects()
            {
                this.shouldSerialize["include_deleted_objects"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BatchRetrieveCatalogObjectsRequest. </returns>
            public BatchRetrieveCatalogObjectsRequest Build()
            {
                return new BatchRetrieveCatalogObjectsRequest(shouldSerialize,
                    this.objectIds,
                    this.includeRelatedObjects,
                    this.catalogVersion,
                    this.includeDeletedObjects);
            }
        }
    }
}