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
    /// ListCatalogRequest.
    /// </summary>
    public class ListCatalogRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ListCatalogRequest"/> class.
        /// </summary>
        /// <param name="cursor">cursor.</param>
        /// <param name="types">types.</param>
        /// <param name="catalogVersion">catalog_version.</param>
        public ListCatalogRequest(
            string cursor = null,
            string types = null,
            long? catalogVersion = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "cursor", false },
                { "types", false },
                { "catalog_version", false }
            };

            if (cursor != null)
            {
                shouldSerialize["cursor"] = true;
                this.Cursor = cursor;
            }

            if (types != null)
            {
                shouldSerialize["types"] = true;
                this.Types = types;
            }

            if (catalogVersion != null)
            {
                shouldSerialize["catalog_version"] = true;
                this.CatalogVersion = catalogVersion;
            }

        }
        internal ListCatalogRequest(Dictionary<string, bool> shouldSerialize,
            string cursor = null,
            string types = null,
            long? catalogVersion = null)
        {
            this.shouldSerialize = shouldSerialize;
            Cursor = cursor;
            Types = types;
            CatalogVersion = catalogVersion;
        }

        /// <summary>
        /// The pagination cursor returned in the previous response. Leave unset for an initial request.
        /// The page size is currently set to be 100.
        /// See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// An optional case-insensitive, comma-separated list of object types to retrieve.
        /// The valid values are defined in the [CatalogObjectType](entity:CatalogObjectType) enum, for example,
        /// `ITEM`, `ITEM_VARIATION`, `CATEGORY`, `DISCOUNT`, `TAX`,
        /// `MODIFIER`, `MODIFIER_LIST`, `IMAGE`, etc.
        /// If this is unspecified, the operation returns objects of all the top level types at the version
        /// of the Square API used to make the request. Object types that are nested onto other object types
        /// are not included in the defaults.
        /// At the current API version the default object types are:
        /// ITEM, CATEGORY, TAX, DISCOUNT, MODIFIER_LIST,
        /// PRICING_RULE, PRODUCT_SET, TIME_PERIOD, MEASUREMENT_UNIT,
        /// SUBSCRIPTION_PLAN, ITEM_OPTION, CUSTOM_ATTRIBUTE_DEFINITION, QUICK_AMOUNT_SETTINGS.
        /// </summary>
        [JsonProperty("types")]
        public string Types { get; }

        /// <summary>
        /// The specific version of the catalog objects to be included in the response.
        /// This allows you to retrieve historical versions of objects. The specified version value is matched against
        /// the [CatalogObject]($m/CatalogObject)s' `version` attribute.  If not included, results will be from the
        /// current version of the catalog.
        /// </summary>
        [JsonProperty("catalog_version")]
        public long? CatalogVersion { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListCatalogRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCursor()
        {
            return this.shouldSerialize["cursor"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTypes()
        {
            return this.shouldSerialize["types"];
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
            return obj is ListCatalogRequest other &&                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Types == null && other.Types == null) || (this.Types?.Equals(other.Types) == true)) &&
                ((this.CatalogVersion == null && other.CatalogVersion == null) || (this.CatalogVersion?.Equals(other.CatalogVersion) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1348170902;
            hashCode = HashCode.Combine(this.Cursor, this.Types, this.CatalogVersion);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor)}");
            toStringOutput.Add($"this.Types = {(this.Types == null ? "null" : this.Types)}");
            toStringOutput.Add($"this.CatalogVersion = {(this.CatalogVersion == null ? "null" : this.CatalogVersion.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(this.Cursor)
                .Types(this.Types)
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
                { "cursor", false },
                { "types", false },
                { "catalog_version", false },
            };

            private string cursor;
            private string types;
            private long? catalogVersion;

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                shouldSerialize["cursor"] = true;
                this.cursor = cursor;
                return this;
            }

             /// <summary>
             /// Types.
             /// </summary>
             /// <param name="types"> types. </param>
             /// <returns> Builder. </returns>
            public Builder Types(string types)
            {
                shouldSerialize["types"] = true;
                this.types = types;
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
            public void UnsetCursor()
            {
                this.shouldSerialize["cursor"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTypes()
            {
                this.shouldSerialize["types"] = false;
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
            /// <returns> ListCatalogRequest. </returns>
            public ListCatalogRequest Build()
            {
                return new ListCatalogRequest(shouldSerialize,
                    this.cursor,
                    this.types,
                    this.catalogVersion);
            }
        }
    }
}