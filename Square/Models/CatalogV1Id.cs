
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
    public class CatalogV1Id 
    {
        public CatalogV1Id(string catalogV1IdProp = null,
            string locationId = null)
        {
            CatalogV1IdProp = catalogV1IdProp;
            LocationId = locationId;
        }

        /// <summary>
        /// The ID for an object used in the Square API V1, if the object ID differs from the Square API V2 object ID.
        /// </summary>
        [JsonProperty("catalog_v1_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CatalogV1IdProp { get; }

        /// <summary>
        /// The ID of the `Location` this Connect V1 ID is associated with.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogV1Id : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"CatalogV1IdProp = {(CatalogV1IdProp == null ? "null" : CatalogV1IdProp == string.Empty ? "" : CatalogV1IdProp)}");
            toStringOutput.Add($"LocationId = {(LocationId == null ? "null" : LocationId == string.Empty ? "" : LocationId)}");
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

            return obj is CatalogV1Id other &&
                ((CatalogV1IdProp == null && other.CatalogV1IdProp == null) || (CatalogV1IdProp?.Equals(other.CatalogV1IdProp) == true)) &&
                ((LocationId == null && other.LocationId == null) || (LocationId?.Equals(other.LocationId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -908281753;

            if (CatalogV1IdProp != null)
            {
               hashCode += CatalogV1IdProp.GetHashCode();
            }

            if (LocationId != null)
            {
               hashCode += LocationId.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CatalogV1IdProp(CatalogV1IdProp)
                .LocationId(LocationId);
            return builder;
        }

        public class Builder
        {
            private string catalogV1IdProp;
            private string locationId;



            public Builder CatalogV1IdProp(string catalogV1IdProp)
            {
                this.catalogV1IdProp = catalogV1IdProp;
                return this;
            }

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public CatalogV1Id Build()
            {
                return new CatalogV1Id(catalogV1IdProp,
                    locationId);
            }
        }
    }
}