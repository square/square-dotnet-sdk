
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
        /// The `idempotency_key` identifying the payment to be canceled.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CancelPaymentByIdempotencyKeyRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
        }

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

            return obj is CancelPaymentByIdempotencyKeyRequest other &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1646474822;

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public CancelPaymentByIdempotencyKeyRequest Build()
            {
                return new CancelPaymentByIdempotencyKeyRequest(idempotencyKey);
            }
        }
    }
}