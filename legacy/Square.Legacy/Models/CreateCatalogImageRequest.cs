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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
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
        /// <param name="isPrimary">is_primary.</param>
        public CreateCatalogImageRequest(
            string idempotencyKey,
            Models.CatalogObject image,
            string objectId = null,
            bool? isPrimary = null
        )
        {
            this.IdempotencyKey = idempotencyKey;
            this.ObjectId = objectId;
            this.Image = image;
            this.IsPrimary = isPrimary;
        }

        /// <summary>
        /// A unique string that identifies this CreateCatalogImage request.
        /// Keys can be any valid string but must be unique for every CreateCatalogImage request.
        /// See [Idempotency keys](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Unique ID of the `CatalogObject` to attach this `CatalogImage` object to. Leave this
        /// field empty to create unattached images, for example if you are building an integration
        /// where an image can be attached to catalog items at a later time.
        /// </summary>
        [JsonProperty("object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectId { get; }

        /// <summary>
        /// <![CDATA[
        /// The wrapper object for the catalog entries of a given object type.
        /// Depending on the `type` attribute value, a `CatalogObject` instance assumes a type-specific data to yield the corresponding type of catalog object.
        /// For example, if `type=ITEM`, the `CatalogObject` instance must have the ITEM-specific data set on the `item_data` attribute. The resulting `CatalogObject` instance is also a `CatalogItem` instance.
        /// In general, if `type=<OBJECT_TYPE>`, the `CatalogObject` instance must have the `<OBJECT_TYPE>`-specific data set on the `<object_type>_data` attribute. The resulting `CatalogObject` instance is also a `Catalog<ObjectType>` instance.
        /// For a more detailed discussion of the Catalog data model, please see the
        /// [Design a Catalog](https://developer.squareup.com/docs/catalog-api/design-a-catalog) guide.
        /// ]]>
        /// </summary>
        [JsonProperty("image")]
        public Models.CatalogObject Image { get; }

        /// <summary>
        /// If this is set to `true`, the image created will be the primary, or first image of the object referenced by `object_id`.
        /// If the `CatalogObject` already has a primary `CatalogImage`, setting this field to `true` will replace the primary image.
        /// If this is set to `false` and you use the Square API version 2021-12-15 or later, the image id will be appended to the list of `image_ids` on the object.
        /// With Square API version 2021-12-15 or later, the default value is `false`. Otherwise, the effective default value is `true`.
        /// </summary>
        [JsonProperty("is_primary", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPrimary { get; }

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
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CreateCatalogImageRequest other
                && (
                    this.IdempotencyKey == null && other.IdempotencyKey == null
                    || this.IdempotencyKey?.Equals(other.IdempotencyKey) == true
                )
                && (
                    this.ObjectId == null && other.ObjectId == null
                    || this.ObjectId?.Equals(other.ObjectId) == true
                )
                && (
                    this.Image == null && other.Image == null
                    || this.Image?.Equals(other.Image) == true
                )
                && (
                    this.IsPrimary == null && other.IsPrimary == null
                    || this.IsPrimary?.Equals(other.IsPrimary) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -432630368;
            hashCode = HashCode.Combine(
                hashCode,
                this.IdempotencyKey,
                this.ObjectId,
                this.Image,
                this.IsPrimary
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {this.IdempotencyKey ?? "null"}");
            toStringOutput.Add($"this.ObjectId = {this.ObjectId ?? "null"}");
            toStringOutput.Add(
                $"this.Image = {(this.Image == null ? "null" : this.Image.ToString())}"
            );
            toStringOutput.Add(
                $"this.IsPrimary = {(this.IsPrimary == null ? "null" : this.IsPrimary.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.IdempotencyKey, this.Image)
                .ObjectId(this.ObjectId)
                .IsPrimary(this.IsPrimary);
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
            private bool? isPrimary;

            /// <summary>
            /// Initialize Builder for CreateCatalogImageRequest.
            /// </summary>
            /// <param name="idempotencyKey"> idempotencyKey. </param>
            /// <param name="image"> image. </param>
            public Builder(string idempotencyKey, Models.CatalogObject image)
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
            /// IsPrimary.
            /// </summary>
            /// <param name="isPrimary"> isPrimary. </param>
            /// <returns> Builder. </returns>
            public Builder IsPrimary(bool? isPrimary)
            {
                this.isPrimary = isPrimary;
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
                    this.objectId,
                    this.isPrimary
                );
            }
        }
    }
}
