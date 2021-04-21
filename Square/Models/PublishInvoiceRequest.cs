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
    /// PublishInvoiceRequest.
    /// </summary>
    public class PublishInvoiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PublishInvoiceRequest"/> class.
        /// </summary>
        /// <param name="version">version.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public PublishInvoiceRequest(
            int version,
            string idempotencyKey = null)
        {
            this.Version = version;
            this.IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// The version of the [invoice]($m/Invoice) to publish.
        /// This must match the current version of the invoice; otherwise, the request is rejected.
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; }

        /// <summary>
        /// A unique string that identifies the `PublishInvoice` request. If you do not
        /// provide `idempotency_key` (or provide an empty string as the value), the endpoint
        /// treats each request as independent.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PublishInvoiceRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is PublishInvoiceRequest other &&
                this.Version.Equals(other.Version) &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1055593006;
            hashCode += this.Version.GetHashCode();

            if (this.IdempotencyKey != null)
            {
               hashCode += this.IdempotencyKey.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Version = {this.Version}");
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Version)
                .IdempotencyKey(this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private int version;
            private string idempotencyKey;

            public Builder(
                int version)
            {
                this.version = version;
            }

             /// <summary>
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(int version)
            {
                this.version = version;
                return this;
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
            /// Builds class object.
            /// </summary>
            /// <returns> PublishInvoiceRequest. </returns>
            public PublishInvoiceRequest Build()
            {
                return new PublishInvoiceRequest(
                    this.version,
                    this.idempotencyKey);
            }
        }
    }
}