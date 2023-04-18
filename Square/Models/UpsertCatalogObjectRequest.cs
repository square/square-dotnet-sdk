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
    /// UpsertCatalogObjectRequest.
    /// </summary>
    public class UpsertCatalogObjectRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpsertCatalogObjectRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="mObject">object.</param>
        public UpsertCatalogObjectRequest(
            string idempotencyKey,
            Models.CatalogObject mObject)
        {
            this.IdempotencyKey = idempotencyKey;
            this.MObject = mObject;
        }

        /// <summary>
        /// A value you specify that uniquely identifies this
        /// request among all your requests. A common way to create
        /// a valid idempotency key is to use a Universally unique
        /// identifier (UUID).
        /// If you're unsure whether a particular request was successful,
        /// you can reattempt it with the same idempotency key without
        /// worrying about creating duplicate objects.
        /// See [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The wrapper object for the catalog entries of a given object type.
        /// Depending on the `type` attribute value, a `CatalogObject` instance assumes a type-specific data to yield the corresponding type of catalog object.
        /// For example, if `type=ITEM`, the `CatalogObject` instance must have the ITEM-specific data set on the `item_data` attribute. The resulting `CatalogObject` instance is also a `CatalogItem` instance.
        /// In general, if `type=<OBJECT_TYPE>`, the `CatalogObject` instance must have the `<OBJECT_TYPE>`-specific data set on the `<object_type>_data` attribute. The resulting `CatalogObject` instance is also a `Catalog<ObjectType>` instance.
        /// For a more detailed discussion of the Catalog data model, please see the
        /// [Design a Catalog](https://developer.squareup.com/docs/catalog-api/design-a-catalog) guide.
        /// </summary>
        [JsonProperty("object")]
        public Models.CatalogObject MObject { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpsertCatalogObjectRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is UpsertCatalogObjectRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.MObject == null && other.MObject == null) || (this.MObject?.Equals(other.MObject) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -153717407;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.MObject);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.MObject = {(this.MObject == null ? "null" : this.MObject.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey,
                this.MObject);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private Models.CatalogObject mObject;

            public Builder(
                string idempotencyKey,
                Models.CatalogObject mObject)
            {
                this.idempotencyKey = idempotencyKey;
                this.mObject = mObject;
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
             /// MObject.
             /// </summary>
             /// <param name="mObject"> mObject. </param>
             /// <returns> Builder. </returns>
            public Builder MObject(Models.CatalogObject mObject)
            {
                this.mObject = mObject;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpsertCatalogObjectRequest. </returns>
            public UpsertCatalogObjectRequest Build()
            {
                return new UpsertCatalogObjectRequest(
                    this.idempotencyKey,
                    this.mObject);
            }
        }
    }
}