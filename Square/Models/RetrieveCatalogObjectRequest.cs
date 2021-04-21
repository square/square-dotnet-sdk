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
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveCatalogObjectRequest"/> class.
        /// </summary>
        /// <param name="includeRelatedObjects">include_related_objects.</param>
        /// <param name="catalogVersion">catalog_version.</param>
        public RetrieveCatalogObjectRequest(
            bool? includeRelatedObjects = null,
            long? catalogVersion = null)
        {
            this.IncludeRelatedObjects = includeRelatedObjects;
            this.CatalogVersion = catalogVersion;
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
        /// in the version field of [CatalogObject]($m/CatalogObject)s.
        /// </summary>
        [JsonProperty("catalog_version", NullValueHandling = NullValueHandling.Ignore)]
        public long? CatalogVersion { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveCatalogObjectRequest : ({string.Join(", ", toStringOutput)})";
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

            if (this.IncludeRelatedObjects != null)
            {
               hashCode += this.IncludeRelatedObjects.GetHashCode();
            }

            if (this.CatalogVersion != null)
            {
               hashCode += this.CatalogVersion.GetHashCode();
            }

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
            private bool? includeRelatedObjects;
            private long? catalogVersion;

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
            /// <returns> RetrieveCatalogObjectRequest. </returns>
            public RetrieveCatalogObjectRequest Build()
            {
                return new RetrieveCatalogObjectRequest(
                    this.includeRelatedObjects,
                    this.catalogVersion);
            }
        }
    }
}