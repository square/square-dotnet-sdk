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

namespace Square.Models
{
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
        /// <param name="includeCategoryPathToRoot">include_category_path_to_root.</param>
        public BatchRetrieveCatalogObjectsRequest(
            IList<string> objectIds,
            bool? includeRelatedObjects = null,
            long? catalogVersion = null,
            bool? includeDeletedObjects = null,
            bool? includeCategoryPathToRoot = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "include_related_objects", false },
                { "catalog_version", false },
                { "include_deleted_objects", false },
                { "include_category_path_to_root", false }
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

            if (includeCategoryPathToRoot != null)
            {
                shouldSerialize["include_category_path_to_root"] = true;
                this.IncludeCategoryPathToRoot = includeCategoryPathToRoot;
            }
        }

        internal BatchRetrieveCatalogObjectsRequest(
            Dictionary<string, bool> shouldSerialize,
            IList<string> objectIds,
            bool? includeRelatedObjects = null,
            long? catalogVersion = null,
            bool? includeDeletedObjects = null,
            bool? includeCategoryPathToRoot = null)
        {
            this.shouldSerialize = shouldSerialize;
            ObjectIds = objectIds;
            IncludeRelatedObjects = includeRelatedObjects;
            CatalogVersion = catalogVersion;
            IncludeDeletedObjects = includeDeletedObjects;
            IncludeCategoryPathToRoot = includeCategoryPathToRoot;
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

        /// <summary>
        /// Specifies whether or not to include the `path_to_root` list for each returned category instance. The `path_to_root` list consists
        /// of `CategoryPathToRootNode` objects and specifies the path that starts with the immediate parent category of the returned category
        /// and ends with its root category. If the returned category is a top-level category, the `path_to_root` list is empty and is not returned
        /// in the response payload.
        /// </summary>
        [JsonProperty("include_category_path_to_root")]
        public bool? IncludeCategoryPathToRoot { get; }

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

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIncludeCategoryPathToRoot()
        {
            return this.shouldSerialize["include_category_path_to_root"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is BatchRetrieveCatalogObjectsRequest other &&
                (this.ObjectIds == null && other.ObjectIds == null ||
                 this.ObjectIds?.Equals(other.ObjectIds) == true) &&
                (this.IncludeRelatedObjects == null && other.IncludeRelatedObjects == null ||
                 this.IncludeRelatedObjects?.Equals(other.IncludeRelatedObjects) == true) &&
                (this.CatalogVersion == null && other.CatalogVersion == null ||
                 this.CatalogVersion?.Equals(other.CatalogVersion) == true) &&
                (this.IncludeDeletedObjects == null && other.IncludeDeletedObjects == null ||
                 this.IncludeDeletedObjects?.Equals(other.IncludeDeletedObjects) == true) &&
                (this.IncludeCategoryPathToRoot == null && other.IncludeCategoryPathToRoot == null ||
                 this.IncludeCategoryPathToRoot?.Equals(other.IncludeCategoryPathToRoot) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 10343946;
            hashCode = HashCode.Combine(hashCode, this.ObjectIds, this.IncludeRelatedObjects, this.CatalogVersion, this.IncludeDeletedObjects, this.IncludeCategoryPathToRoot);

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
            toStringOutput.Add($"this.IncludeCategoryPathToRoot = {(this.IncludeCategoryPathToRoot == null ? "null" : this.IncludeCategoryPathToRoot.ToString())}");
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
                .IncludeDeletedObjects(this.IncludeDeletedObjects)
                .IncludeCategoryPathToRoot(this.IncludeCategoryPathToRoot);
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
                { "include_category_path_to_root", false },
            };

            private IList<string> objectIds;
            private bool? includeRelatedObjects;
            private long? catalogVersion;
            private bool? includeDeletedObjects;
            private bool? includeCategoryPathToRoot;

            /// <summary>
            /// Initialize Builder for BatchRetrieveCatalogObjectsRequest.
            /// </summary>
            /// <param name="objectIds"> objectIds. </param>
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
             /// IncludeCategoryPathToRoot.
             /// </summary>
             /// <param name="includeCategoryPathToRoot"> includeCategoryPathToRoot. </param>
             /// <returns> Builder. </returns>
            public Builder IncludeCategoryPathToRoot(bool? includeCategoryPathToRoot)
            {
                shouldSerialize["include_category_path_to_root"] = true;
                this.includeCategoryPathToRoot = includeCategoryPathToRoot;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetIncludeRelatedObjects()
            {
                this.shouldSerialize["include_related_objects"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCatalogVersion()
            {
                this.shouldSerialize["catalog_version"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetIncludeDeletedObjects()
            {
                this.shouldSerialize["include_deleted_objects"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetIncludeCategoryPathToRoot()
            {
                this.shouldSerialize["include_category_path_to_root"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BatchRetrieveCatalogObjectsRequest. </returns>
            public BatchRetrieveCatalogObjectsRequest Build()
            {
                return new BatchRetrieveCatalogObjectsRequest(
                    shouldSerialize,
                    this.objectIds,
                    this.includeRelatedObjects,
                    this.catalogVersion,
                    this.includeDeletedObjects,
                    this.includeCategoryPathToRoot);
            }
        }
    }
}