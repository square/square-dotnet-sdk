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
        public CatalogV1Id(string catalogV1Id = null,
            string locationId = null)
        {
            CatalogV1IdProp = catalogV1Id;
            LocationId = locationId;
        }

        /// <summary>
        /// The ID for an object in Connect V1, if different from its Connect V2 ID.
        /// </summary>
        [JsonProperty("catalog_v1_id")]
        public string CatalogV1IdProp { get; }

        /// <summary>
        /// The ID of the `Location` this Connect V1 ID is associated with.
        /// </summary>
        [JsonProperty("location_id")]
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
            private string catalogV1Id;
            private string locationId;

            public Builder() { }
            public Builder CatalogV1IdProp(string value)
            {
                catalogV1Id = value;
                return this;
            }

            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public CatalogV1Id Build()
            {
                return new CatalogV1Id(catalogV1Id,
                    locationId);
            }
        }
    }
} 