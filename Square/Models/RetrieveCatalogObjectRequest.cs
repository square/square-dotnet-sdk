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
    /// RetrieveCatalogObjectRequest.
    /// </summary>
    public class RetrieveCatalogObjectRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveCatalogObjectRequest"/> class.
        /// </summary>
        /// <param name="includeRelatedObjects">include_related_objects.</param>
        /// <param name="catalogVersion">catalog_version.</param>
        public RetrieveCatalogObjectRequest(
            bool? includeRelatedObjects = null,
            long? catalogVersion = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "include_related_objects", false },
                { "catalog_version", false }
            };

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

        }
        internal RetrieveCatalogObjectRequest(Dictionary<string, bool> shouldSerialize,
            bool? includeRelatedObjects = null,
            long? catalogVersion = null)
        {
            this.shouldSerialize = shouldSerialize;
            IncludeRelatedObjects = includeRelatedObjects;
            CatalogVersion = catalogVersion;
        }

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
        /// Requests objects as of a specific version of the catalog. This allows you to retrieve historical
        /// versions of objects. The value to retrieve a specific version of an object can be found
        /// in the version field of [CatalogObject]($m/CatalogObject)s. If not included, results will
        /// be from the current version of the catalog.
        /// </summary>
        [JsonProperty("catalog_version")]
        public long? CatalogVersion { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveCatalogObjectRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is RetrieveCatalogObjectRequest other &&
                ((this.IncludeRelatedObjects == null && other.IncludeRelatedObjects == null) || (this.IncludeRelatedObjects?.Equals(other.IncludeRelatedObjects) == true)) &&
                ((this.CatalogVersion == null && other.CatalogVersion == null) || (this.CatalogVersion?.Equals(other.CatalogVersion) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -126608082;
            hashCode = HashCode.Combine(this.IncludeRelatedObjects, this.CatalogVersion);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IncludeRelatedObjects = {(this.IncludeRelatedObjects == null ? "null" : this.IncludeRelatedObjects.ToString())}");
            toStringOutput.Add($"this.CatalogVersion = {(this.CatalogVersion == null ? "null" : this.CatalogVersion.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .IncludeRelatedObjects(this.IncludeRelatedObjects)
                .CatalogVersion(this.CatalogVersion);
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
            };

            private bool? includeRelatedObjects;
            private long? catalogVersion;

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
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveCatalogObjectRequest. </returns>
            public RetrieveCatalogObjectRequest Build()
            {
                return new RetrieveCatalogObjectRequest(shouldSerialize,
                    this.includeRelatedObjects,
                    this.catalogVersion);
            }
        }
    }
}