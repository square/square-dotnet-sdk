
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
    public class CreateTerminalRefundRequest 
    {
        public CreateTerminalRefundRequest(string idempotencyKey,
            Models.TerminalRefund refund = null)
        {
            IdempotencyKey = idempotencyKey;
            Refund = refund;
        }

        /// <summary>
        /// A unique string that identifies this `CreateRefund` request. Keys can be any valid string but
        /// must be unique for every `CreateRefund` request.
        /// See [Idempotency keys](https://developer.squareup.com/docs/basics/api101/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Getter for refund
        /// </summary>
        [JsonProperty("refund", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalRefund Refund { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateTerminalRefundRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
            toStringOutput.Add($"Refund = {(Refund == null ? "null" : Refund.ToString())}");
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

            return obj is CreateTerminalRefundRequest other &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((Refund == null && other.Refund == null) || (Refund?.Equals(other.Refund) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -475578715;

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            if (Refund != null)
            {
               hashCode += Refund.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(IdempotencyKey)
                .Refund(Refund);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;
            private Models.TerminalRefund refund;

            public Builder(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
            }

            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public Builder Refund(Models.TerminalRefund refund)
            {
                this.refund = refund;
                return this;
            }

            public CreateTerminalRefundRequest Build()
            {
                return new CreateTerminalRefundRequest(idempotencyKey,
                    refund);
            }
        }
    }
}