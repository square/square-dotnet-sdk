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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// UpsertCatalogObjectResponse.
    /// </summary>
    public class UpsertCatalogObjectResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpsertCatalogObjectResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="catalogObject">catalog_object.</param>
        /// <param name="idMappings">id_mappings.</param>
        public UpsertCatalogObjectResponse(
            IList<Models.Error> errors = null,
            Models.CatalogObject catalogObject = null,
            IList<Models.CatalogIdMapping> idMappings = null)
        {
            this.Errors = errors;
            this.CatalogObject = catalogObject;
            this.IdMappings = idMappings;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The wrapper object for the catalog entries of a given object type.
        /// Depending on the `type` attribute value, a `CatalogObject` instance assumes a type-specific data to yield the corresponding type of catalog object.
        /// For example, if `type=ITEM`, the `CatalogObject` instance must have the ITEM-specific data set on the `item_data` attribute. The resulting `CatalogObject` instance is also a `CatalogItem` instance.
        /// In general, if `type=<OBJECT_TYPE>`, the `CatalogObject` instance must have the `<OBJECT_TYPE>`-specific data set on the `<object_type>_data` attribute. The resulting `CatalogObject` instance is also a `Catalog<ObjectType>` instance.
        /// For a more detailed discussion of the Catalog data model, please see the
        /// [Design a Catalog](https://developer.squareup.com/docs/catalog-api/design-a-catalog) guide.
        /// </summary>
        [JsonProperty("catalog_object", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogObject CatalogObject { get; }

        /// <summary>
        /// The mapping between client and server IDs for this upsert.
        /// </summary>
        [JsonProperty("id_mappings", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogIdMapping> IdMappings { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpsertCatalogObjectResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is UpsertCatalogObjectResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.CatalogObject == null && other.CatalogObject == null) || (this.CatalogObject?.Equals(other.CatalogObject) == true)) &&
                ((this.IdMappings == null && other.IdMappings == null) || (this.IdMappings?.Equals(other.IdMappings) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -133578961;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.CatalogObject, this.IdMappings);

            return hashCode;
        }
        internal UpsertCatalogObjectResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.CatalogObject = {(this.CatalogObject == null ? "null" : this.CatalogObject.ToString())}");
            toStringOutput.Add($"this.IdMappings = {(this.IdMappings == null ? "null" : $"[{string.Join(", ", this.IdMappings)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .CatalogObject(this.CatalogObject)
                .IdMappings(this.IdMappings);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.CatalogObject catalogObject;
            private IList<Models.CatalogIdMapping> idMappings;

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

             /// <summary>
             /// CatalogObject.
             /// </summary>
             /// <param name="catalogObject"> catalogObject. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogObject(Models.CatalogObject catalogObject)
            {
                this.catalogObject = catalogObject;
                return this;
            }

             /// <summary>
             /// IdMappings.
             /// </summary>
             /// <param name="idMappings"> idMappings. </param>
             /// <returns> Builder. </returns>
            public Builder IdMappings(IList<Models.CatalogIdMapping> idMappings)
            {
                this.idMappings = idMappings;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpsertCatalogObjectResponse. </returns>
            public UpsertCatalogObjectResponse Build()
            {
                return new UpsertCatalogObjectResponse(
                    this.errors,
                    this.catalogObject,
                    this.idMappings);
            }
        }
    }
}