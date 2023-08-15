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
    /// CatalogObjectReference.
    /// </summary>
    public class CatalogObjectReference
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogObjectReference"/> class.
        /// </summary>
        /// <param name="objectId">object_id.</param>
        /// <param name="catalogVersion">catalog_version.</param>
        public CatalogObjectReference(
            string objectId = null,
            long? catalogVersion = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "object_id", false },
                { "catalog_version", false }
            };

            if (objectId != null)
            {
                shouldSerialize["object_id"] = true;
                this.ObjectId = objectId;
            }

            if (catalogVersion != null)
            {
                shouldSerialize["catalog_version"] = true;
                this.CatalogVersion = catalogVersion;
            }

        }
        internal CatalogObjectReference(Dictionary<string, bool> shouldSerialize,
            string objectId = null,
            long? catalogVersion = null)
        {
            this.shouldSerialize = shouldSerialize;
            ObjectId = objectId;
            CatalogVersion = catalogVersion;
        }

        /// <summary>
        /// The ID of the referenced object.
        /// </summary>
        [JsonProperty("object_id")]
        public string ObjectId { get; }

        /// <summary>
        /// The version of the object.
        /// </summary>
        [JsonProperty("catalog_version")]
        public long? CatalogVersion { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogObjectReference : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeObjectId()
        {
            return this.shouldSerialize["object_id"];
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
            return obj is CatalogObjectReference other &&                ((this.ObjectId == null && other.ObjectId == null) || (this.ObjectId?.Equals(other.ObjectId) == true)) &&
                ((this.CatalogVersion == null && other.CatalogVersion == null) || (this.CatalogVersion?.Equals(other.CatalogVersion) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -703569584;
            hashCode = HashCode.Combine(this.ObjectId, this.CatalogVersion);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ObjectId = {(this.ObjectId == null ? "null" : this.ObjectId)}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "object_id", false },
                { "catalog_version", false },
            };

            private string objectId;
            private long? catalogVersion;

             /// <summary>
             /// ObjectId.
             /// </summary>
             /// <param name="objectId"> objectId. </param>
             /// <returns> Builder. </returns>
            public Builder ObjectId(string objectId)
            {
                shouldSerialize["object_id"] = true;
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
                shouldSerialize["catalog_version"] = true;
                this.catalogVersion = catalogVersion;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetObjectId()
            {
                this.shouldSerialize["object_id"] = false;
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
            /// <returns> CatalogObjectReference. </returns>
            public CatalogObjectReference Build()
            {
                return new CatalogObjectReference(shouldSerialize,
                    this.objectId,
                    this.catalogVersion);
            }
        }
    }
}