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
    /// CreateCatalogImageRequest.
    /// </summary>
    public class CreateCatalogImageRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCatalogImageRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="image">image.</param>
        /// <param name="objectId">object_id.</param>
        public CreateCatalogImageRequest(
            string idempotencyKey,
            Models.CatalogObject image,
            string objectId = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.ObjectId = objectId;
            this.Image = image;
        }

        /// <summary>
        /// A unique string that identifies this CreateCatalogImage request.
        /// Keys can be any valid string but must be unique for every CreateCatalogImage request.
        /// See [Idempotency keys](https://developer.squareup.com/docs/basics/api101/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Unique ID of the `CatalogObject` to attach to this `CatalogImage`. Leave this
        /// field empty to create unattached images, for example if you are building an integration
        /// where these images can be attached to catalog items at a later time.
        /// </summary>
        [JsonProperty("object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectId { get; }

        /// <summary>
        /// The wrapper object for the catalog entries of a given object type.
        /// Depending on the `type` attribute value, a `CatalogObject` instance assumes a type-specific data to yield the corresponding type of catalog object.
        /// For example, if `type=ITEM`, the `CatalogObject` instance must have the ITEM-specific data set on the `item_data` attribute. The resulting `CatalogObject` instance is also a `CatalogItem` instance.
        /// In general, if `type=<OBJECT_TYPE>`, the `CatalogObject` instance must have the `<OBJECT_TYPE>`-specific data set on the `<object_type>_data` attribute. The resulting `CatalogObject` instance is also a `Catalog<ObjectType>` instance.
        /// For a more detailed discussion of the Catalog data model, please see the
        /// [Design a Catalog](https://developer.squareup.com/docs/catalog-api/design-a-catalog) guide.
        /// </summary>
        [JsonProperty("image")]
        public Models.CatalogObject Image { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateCatalogImageRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateCatalogImageRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.ObjectId == null && other.ObjectId == null) || (this.ObjectId?.Equals(other.ObjectId) == true)) &&
                ((this.Image == null && other.Image == null) || (this.Image?.Equals(other.Image) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1867152760;

            if (this.IdempotencyKey != null)
            {
               hashCode += this.IdempotencyKey.GetHashCode();
            }

            if (this.ObjectId != null)
            {
               hashCode += this.ObjectId.GetHashCode();
            }

            if (this.Image != null)
            {
               hashCode += this.Image.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.ObjectId = {(this.ObjectId == null ? "null" : this.ObjectId == string.Empty ? "" : this.ObjectId)}");
            toStringOutput.Add($"this.Image = {(this.Image == null ? "null" : this.Image.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey,
                this.Image)
                .ObjectId(this.ObjectId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private Models.CatalogObject image;
            private string objectId;

            public Builder(
                string idempotencyKey,
                Models.CatalogObject image)
            {
                this.idempotencyKey = idempotencyKey;
                this.image = image;
            }

             /// <summary>
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

             /// <summary>
             /// Image.
             /// </summary>
             /// <param name="image"> image. </param>
             /// <returns> Builder. </returns>
            public Builder Image(Models.CatalogObject image)
            {
                this.image = image;
                return this;
            }

             /// <summary>
             /// ObjectId.
             /// </summary>
             /// <param name="objectId"> objectId. </param>
             /// <returns> Builder. </returns>
            public Builder ObjectId(string objectId)
            {
                this.objectId = objectId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateCatalogImageRequest. </returns>
            public CreateCatalogImageRequest Build()
            {
                return new CreateCatalogImageRequest(
                    this.idempotencyKey,
                    this.image,
                    this.objectId);
            }
        }
    }
}