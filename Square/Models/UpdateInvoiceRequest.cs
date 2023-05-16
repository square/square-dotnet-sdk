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
    /// UpdateInvoiceRequest.
    /// </summary>
    public class UpdateInvoiceRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateInvoiceRequest"/> class.
        /// </summary>
        /// <param name="invoice">invoice.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="fieldsToClear">fields_to_clear.</param>
        public UpdateInvoiceRequest(
            Models.Invoice invoice,
            string idempotencyKey = null,
            IList<string> fieldsToClear = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "idempotency_key", false },
                { "fields_to_clear", false }
            };

            this.Invoice = invoice;
            if (idempotencyKey != null)
            {
                shouldSerialize["idempotency_key"] = true;
                this.IdempotencyKey = idempotencyKey;
            }

            if (fieldsToClear != null)
            {
                shouldSerialize["fields_to_clear"] = true;
                this.FieldsToClear = fieldsToClear;
            }

        }
        internal UpdateInvoiceRequest(Dictionary<string, bool> shouldSerialize,
            Models.Invoice invoice,
            string idempotencyKey = null,
            IList<string> fieldsToClear = null)
        {
            this.shouldSerialize = shouldSerialize;
            Invoice = invoice;
            IdempotencyKey = idempotencyKey;
            FieldsToClear = fieldsToClear;
        }

        /// <summary>
        /// Stores information about an invoice. You use the Invoices API to create and manage
        /// invoices. For more information, see [Invoices API Overview](https://developer.squareup.com/docs/invoices-api/overview).
        /// </summary>
        [JsonProperty("invoice")]
        public Models.Invoice Invoice { get; }

        /// <summary>
        /// A unique string that identifies the `UpdateInvoice` request. If you do not
        /// provide `idempotency_key` (or provide an empty string as the value), the endpoint
        /// treats each request as independent.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The list of fields to clear.
        /// For examples, see [Update an Invoice](https://developer.squareup.com/docs/invoices-api/update-invoices).
        /// </summary>
        [JsonProperty("fields_to_clear")]
        public IList<string> FieldsToClear { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateInvoiceRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIdempotencyKey()
        {
            return this.shouldSerialize["idempotency_key"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFieldsToClear()
        {
            return this.shouldSerialize["fields_to_clear"];
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
            return obj is UpdateInvoiceRequest other &&                ((this.Invoice == null && other.Invoice == null) || (this.Invoice?.Equals(other.Invoice) == true)) &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.FieldsToClear == null && other.FieldsToClear == null) || (this.FieldsToClear?.Equals(other.FieldsToClear) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -281586426;
            hashCode = HashCode.Combine(this.Invoice, this.IdempotencyKey, this.FieldsToClear);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Invoice = {(this.Invoice == null ? "null" : this.Invoice.ToString())}");
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.FieldsToClear = {(this.FieldsToClear == null ? "null" : $"[{string.Join(", ", this.FieldsToClear)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Invoice)
                .IdempotencyKey(this.IdempotencyKey)
                .FieldsToClear(this.FieldsToClear);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "idempotency_key", false },
                { "fields_to_clear", false },
            };

            private Models.Invoice invoice;
            private string idempotencyKey;
            private IList<string> fieldsToClear;

            public Builder(
                Models.Invoice invoice)
            {
                this.invoice = invoice;
            }

             /// <summary>
             /// Invoice.
             /// </summary>
             /// <param name="invoice"> invoice. </param>
             /// <returns> Builder. </returns>
            public Builder Invoice(Models.Invoice invoice)
            {
                this.invoice = invoice;
                return this;
            }

             /// <summary>
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                shouldSerialize["idempotency_key"] = true;
                this.idempotencyKey = idempotencyKey;
                return this;
            }

             /// <summary>
             /// FieldsToClear.
             /// </summary>
             /// <param name="fieldsToClear"> fieldsToClear. </param>
             /// <returns> Builder. </returns>
            public Builder FieldsToClear(IList<string> fieldsToClear)
            {
                shouldSerialize["fields_to_clear"] = true;
                this.fieldsToClear = fieldsToClear;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIdempotencyKey()
            {
                this.shouldSerialize["idempotency_key"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetFieldsToClear()
            {
                this.shouldSerialize["fields_to_clear"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateInvoiceRequest. </returns>
            public UpdateInvoiceRequest Build()
            {
                return new UpdateInvoiceRequest(shouldSerialize,
                    this.invoice,
                    this.idempotencyKey,
                    this.fieldsToClear);
            }
        }
    }
}