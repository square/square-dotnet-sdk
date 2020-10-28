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