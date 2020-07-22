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
    public class PublishInvoiceRequest 
    {
        public PublishInvoiceRequest(int version,
            string idempotencyKey = null)
        {
            Version = version;
            IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// The version of the [Invoice](#type-invoice) to publish.
        /// This must match the current version of the invoice,
        /// otherwise the request is rejected.
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; }

        /// <summary>
        /// A unique string that identifies the `PublishInvoice` request. If you do not 
        /// provide `idempotency_key` (or provide an empty string as the value), the endpoint 
        /// treats each request as independent.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/docs/working-with-apis/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Version)
                .IdempotencyKey(IdempotencyKey);
            return builder;
        }

        public class Builder
        {
            private int version;
            private string idempotencyKey;

            public Builder(int version)
            {
                this.version = version;
            }
            public Builder Version(int value)
            {
                version = value;
                return this;
            }

            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public PublishInvoiceRequest Build()
            {
                return new PublishInvoiceRequest(version,
                    idempotencyKey);
            }
        }
    }
}