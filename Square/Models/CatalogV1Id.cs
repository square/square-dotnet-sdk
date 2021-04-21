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
    /// CatalogV1Id.
    /// </summary>
    public class CatalogV1Id
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogV1Id"/> class.
        /// </summary>
        /// <param name="catalogV1IdProp">catalog_v1_id.</param>
        /// <param name="locationId">location_id.</param>
        public CatalogV1Id(
            string catalogV1IdProp = null,
            string locationId = null)
        {
            this.CatalogV1IdProp = catalogV1IdProp;
            this.LocationId = locationId;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogV1Id : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogV1Id other &&
                ((this.CatalogV1IdProp == null && other.CatalogV1IdProp == null) || (this.CatalogV1IdProp?.Equals(other.CatalogV1IdProp) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -908281753;

            if (this.CatalogV1IdProp != null)
            {
               hashCode += this.CatalogV1IdProp.GetHashCode();
            }

            if (this.LocationId != null)
            {
               hashCode += this.LocationId.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CatalogV1IdProp = {(this.CatalogV1IdProp == null ? "null" : this.CatalogV1IdProp == string.Empty ? "" : this.CatalogV1IdProp)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CatalogV1IdProp(this.CatalogV1IdProp)
                .LocationId(this.LocationId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string catalogV1IdProp;
            private string locationId;

             /// <summary>
             /// CatalogV1IdProp.
             /// </summary>
             /// <param name="catalogV1IdProp"> catalogV1IdProp. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogV1IdProp(string catalogV1IdProp)
            {
                this.catalogV1IdProp = catalogV1IdProp;
                return this;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogV1Id. </returns>
            public CatalogV1Id Build()
            {
                return new CatalogV1Id(
                    this.catalogV1IdProp,
                    this.locationId);
            }
        }
    }
}