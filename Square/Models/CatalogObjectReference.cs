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
    /// CatalogObjectReference.
    /// </summary>
    public class CatalogObjectReference
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogObjectReference"/> class.
        /// </summary>
        /// <param name="objectId">object_id.</param>
        /// <param name="catalogVersion">catalog_version.</param>
        public CatalogObjectReference(
            string objectId = null,
            long? catalogVersion = null)
        {
            this.ObjectId = objectId;
            this.CatalogVersion = catalogVersion;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogObjectReference : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogObjectReference other &&
                ((this.ObjectId == null && other.ObjectId == null) || (this.ObjectId?.Equals(other.ObjectId) == true)) &&
                ((this.CatalogVersion == null && other.CatalogVersion == null) || (this.CatalogVersion?.Equals(other.CatalogVersion) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -703569584;

            if (this.ObjectId != null)
            {
               hashCode += this.ObjectId.GetHashCode();
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
            toStringOutput.Add($"this.ObjectId = {(this.ObjectId == null ? "null" : this.ObjectId == string.Empty ? "" : this.ObjectId)}");
            toStringOutput.Add($"this.CatalogVersion = {(this.CatalogVersion == null ? "null" : this.CatalogVersion.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ObjectId(this.ObjectId)
                .CatalogVersion(this.CatalogVersion);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string objectId;
            private long? catalogVersion;

             /// <summary>
             /// ObjectId.
             /// </summary>
             /// <param name="objectId"> objectId. </param>
             /// <returns> Builder. </returns>
            public Builder ObjectId(string objectId)
            {
                this.objectId = objectId;
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
            /// <returns> CatalogObjectReference. </returns>
            public CatalogObjectReference Build()
            {
                return new CatalogObjectReference(
                    this.objectId,
                    this.catalogVersion);
            }
        }
    }
}