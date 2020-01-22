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
    public class CancelPaymentByIdempotencyKeyRequest 
    {
        public CancelPaymentByIdempotencyKeyRequest(string idempotencyKey)
        {
            IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// `idempotency_key` identifying the payment to be canceled.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(IdempotencyKey);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;

            public Builder(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
            }
            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public CancelPaymentByIdempotencyKeyRequest Build()
            {
                return new CancelPaymentByIdempotencyKeyRequest(idempotencyKey);
            }
        }
    }
}