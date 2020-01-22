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
    public class UpsertCatalogObjectRequest 
    {
        public UpsertCatalogObjectRequest(string idempotencyKey,
            Models.CatalogObject mObject)
        {
            IdempotencyKey = idempotencyKey;
            MObject = mObject;
        }

        /// <summary>
        /// A value you specify that uniquely identifies this
        /// request among all your requests. A common way to create
        /// a valid idempotency key is to use a Universally unique
        /// identifier (UUID).
        /// If you're unsure whether a particular request was successful,
        /// you can reattempt it with the same idempotency key without
        /// worrying about creating duplicate objects.
        /// See [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Getter for object
        /// </summary>
        [JsonProperty("object")]
        public Models.CatalogObject MObject { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(IdempotencyKey,
                MObject);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;
            private Models.CatalogObject mObject;

            public Builder(string idempotencyKey,
                Models.CatalogObject mObject)
            {
                this.idempotencyKey = idempotencyKey;
                this.mObject = mObject;
            }
            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public Builder MObject(Models.CatalogObject value)
            {
                mObject = value;
                return this;
            }

            public UpsertCatalogObjectRequest Build()
            {
                return new UpsertCatalogObjectRequest(idempotencyKey,
                    mObject);
            }
        }
    }
}