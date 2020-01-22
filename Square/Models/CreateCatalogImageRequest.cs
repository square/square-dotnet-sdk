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
    public class CreateCatalogImageRequest 
    {
        public CreateCatalogImageRequest(string idempotencyKey,
            string objectId = null,
            Models.CatalogObject image = null)
        {
            IdempotencyKey = idempotencyKey;
            ObjectId = objectId;
            Image = image;
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
        [JsonProperty("object_id")]
        public string ObjectId { get; }

        /// <summary>
        /// Getter for image
        /// </summary>
        [JsonProperty("image")]
        public Models.CatalogObject Image { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(IdempotencyKey)
                .ObjectId(ObjectId)
                .Image(Image);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;
            private string objectId;
            private Models.CatalogObject image;

            public Builder(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
            }
            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public Builder ObjectId(string value)
            {
                objectId = value;
                return this;
            }

            public Builder Image(Models.CatalogObject value)
            {
                image = value;
                return this;
            }

            public CreateCatalogImageRequest Build()
            {
                return new CreateCatalogImageRequest(idempotencyKey,
                    objectId,
                    image);
            }
        }
    }
}