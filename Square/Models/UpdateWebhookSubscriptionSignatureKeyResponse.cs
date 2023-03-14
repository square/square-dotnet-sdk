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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// UpdateWebhookSubscriptionSignatureKeyResponse.
    /// </summary>
    public class UpdateWebhookSubscriptionSignatureKeyResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWebhookSubscriptionSignatureKeyResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="signatureKey">signature_key.</param>
        public UpdateWebhookSubscriptionSignatureKeyResponse(
            IList<Models.Error> errors = null,
            string signatureKey = null)
        {
            this.Errors = errors;
            this.SignatureKey = signatureKey;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The new Square-generated signature key used to validate the origin of the webhook event.
        /// </summary>
        [JsonProperty("signature_key", NullValueHandling = NullValueHandling.Ignore)]
        public string SignatureKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateWebhookSubscriptionSignatureKeyResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is UpdateWebhookSubscriptionSignatureKeyResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.SignatureKey == null && other.SignatureKey == null) || (this.SignatureKey?.Equals(other.SignatureKey) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1669055292;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.SignatureKey);

            return hashCode;
        }
        internal UpdateWebhookSubscriptionSignatureKeyResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.SignatureKey = {(this.SignatureKey == null ? "null" : this.SignatureKey == string.Empty ? "" : this.SignatureKey)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .SignatureKey(this.SignatureKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private string signatureKey;

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

             /// <summary>
             /// SignatureKey.
             /// </summary>
             /// <param name="signatureKey"> signatureKey. </param>
             /// <returns> Builder. </returns>
            public Builder SignatureKey(string signatureKey)
            {
                this.signatureKey = signatureKey;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateWebhookSubscriptionSignatureKeyResponse. </returns>
            public UpdateWebhookSubscriptionSignatureKeyResponse Build()
            {
                return new UpdateWebhookSubscriptionSignatureKeyResponse(
                    this.errors,
                    this.signatureKey);
            }
        }
    }
}