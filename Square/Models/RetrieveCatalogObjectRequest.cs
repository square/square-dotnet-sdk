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
    public class RetrieveCatalogObjectRequest 
    {
        public RetrieveCatalogObjectRequest(bool? includeRelatedObjects = null)
        {
            IncludeRelatedObjects = includeRelatedObjects;
        }

        /// <summary>
        /// If `true`, the response will include additional objects that are related to the
        /// requested object, as follows:
        /// If the `object` field of the response contains a CatalogItem,
        /// its associated CatalogCategory, CatalogTax objects,
        /// CatalogImages and CatalogModifierLists
        /// will be returned in the `related_objects` field of the response. If the `object`
        /// field of the response contains a CatalogItemVariation,
        /// its parent CatalogItem will be returned in the `related_objects` field of
        /// the response.
        /// Default value: `false`
        /// </summary>
        [JsonProperty("include_related_objects")]
        public bool? IncludeRelatedObjects { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .IncludeRelatedObjects(IncludeRelatedObjects);
            return builder;
        }

        public class Builder
        {
            private bool? includeRelatedObjects;

            public Builder() { }
            public Builder IncludeRelatedObjects(bool? value)
            {
                includeRelatedObjects = value;
                return this;
            }

            public RetrieveCatalogObjectRequest Build()
            {
                return new RetrieveCatalogObjectRequest(includeRelatedObjects);
            }
        }
    }
}