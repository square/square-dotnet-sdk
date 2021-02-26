
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
    public class CatalogObjectReference 
    {
        public CatalogObjectReference(string objectId = null,
            long? catalogVersion = null)
        {
            ObjectId = objectId;
            CatalogVersion = catalogVersion;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogObjectReference : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ObjectId = {(ObjectId == null ? "null" : ObjectId == string.Empty ? "" : ObjectId)}");
            toStringOutput.Add($"CatalogVersion = {(CatalogVersion == null ? "null" : CatalogVersion.ToString())}");
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

            return obj is CatalogObjectReference other &&
                ((ObjectId == null && other.ObjectId == null) || (ObjectId?.Equals(other.ObjectId) == true)) &&
                ((CatalogVersion == null && other.CatalogVersion == null) || (CatalogVersion?.Equals(other.CatalogVersion) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -703569584;

            if (ObjectId != null)
            {
               hashCode += ObjectId.GetHashCode();
            }

            if (CatalogVersion != null)
            {
               hashCode += CatalogVersion.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ObjectId(ObjectId)
                .CatalogVersion(CatalogVersion);
            return builder;
        }

        public class Builder
        {
            private string objectId;
            private long? catalogVersion;



            public Builder ObjectId(string objectId)
            {
                this.objectId = objectId;
                return this;
            }

            public Builder CatalogVersion(long? catalogVersion)
            {
                this.catalogVersion = catalogVersion;
                return this;
            }

            public CatalogObjectReference Build()
            {
                return new CatalogObjectReference(objectId,
                    catalogVersion);
            }
        }
    }
}