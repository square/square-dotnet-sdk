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
    public class ListCatalogRequest 
    {
        public ListCatalogRequest(string cursor = null,
            string types = null,
            long? catalogVersion = null)
        {
            Cursor = cursor;
            Types = types;
            CatalogVersion = catalogVersion;
        }

        /// <summary>
        /// The pagination cursor returned in the previous response. Leave unset for an initial request.
        /// See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// An optional case-insensitive, comma-separated list of object types to retrieve, for example
        /// `ITEM,ITEM_VARIATION,CATEGORY,IMAGE`.
        /// The legal values are taken from the CatalogObjectType enum:
        /// `ITEM`, `ITEM_VARIATION`, `CATEGORY`, `DISCOUNT`, `TAX`,
        /// `MODIFIER`, `MODIFIER_LIST`, or `IMAGE`.
        /// </summary>
        [JsonProperty("types", NullValueHandling = NullValueHandling.Ignore)]
        public string Types { get; }

        /// <summary>
        /// The specific version of the catalog objects to be included in the response. 
        /// This allows you to retrieve historical
        /// versions of objects. The specified version value is matched against
        /// the [CatalogObject](#type-catalogobject)s' `version` attribute.
        /// </summary>
        [JsonProperty("catalog_version", NullValueHandling = NullValueHandling.Ignore)]
        public long? CatalogVersion { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(Cursor)
                .Types(Types)
                .CatalogVersion(CatalogVersion);
            return builder;
        }

        public class Builder
        {
            private string cursor;
            private string types;
            private long? catalogVersion;



            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder Types(string types)
            {
                this.types = types;
                return this;
            }

            public Builder CatalogVersion(long? catalogVersion)
            {
                this.catalogVersion = catalogVersion;
                return this;
            }

            public ListCatalogRequest Build()
            {
                return new ListCatalogRequest(cursor,
                    types,
                    catalogVersion);
            }
        }
    }
}