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
    /// CreatePaymentLinkResponse.
    /// </summary>
    public class CreatePaymentLinkResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePaymentLinkResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="paymentLink">payment_link.</param>
        /// <param name="relatedResources">related_resources.</param>
        public CreatePaymentLinkResponse(
            IList<Models.Error> errors = null,
            Models.PaymentLink paymentLink = null,
            Models.PaymentLinkRelatedResources relatedResources = null)
        {
            this.Errors = errors;
            this.PaymentLink = paymentLink;
            this.RelatedResources = relatedResources;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Gets or sets PaymentLink.
        /// </summary>
        [JsonProperty("payment_link", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentLink PaymentLink { get; }

        /// <summary>
        /// Gets or sets RelatedResources.
        /// </summary>
        [JsonProperty("related_resources", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaymentLinkRelatedResources RelatedResources { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreatePaymentLinkResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreatePaymentLinkResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.PaymentLink == null && other.PaymentLink == null) || (this.PaymentLink?.Equals(other.PaymentLink) == true)) &&
                ((this.RelatedResources == null && other.RelatedResources == null) || (this.RelatedResources?.Equals(other.RelatedResources) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 383213681;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.PaymentLink, this.RelatedResources);

            return hashCode;
        }
        internal CreatePaymentLinkResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.PaymentLink = {(this.PaymentLink == null ? "null" : this.PaymentLink.ToString())}");
            toStringOutput.Add($"this.RelatedResources = {(this.RelatedResources == null ? "null" : this.RelatedResources.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .PaymentLink(this.PaymentLink)
                .RelatedResources(this.RelatedResources);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.PaymentLink paymentLink;
            private Models.PaymentLinkRelatedResources relatedResources;

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
             /// PaymentLink.
             /// </summary>
             /// <param name="paymentLink"> paymentLink. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentLink(Models.PaymentLink paymentLink)
            {
                this.paymentLink = paymentLink;
                return this;
            }

             /// <summary>
             /// RelatedResources.
             /// </summary>
             /// <param name="relatedResources"> relatedResources. </param>
             /// <returns> Builder. </returns>
            public Builder RelatedResources(Models.PaymentLinkRelatedResources relatedResources)
            {
                this.relatedResources = relatedResources;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreatePaymentLinkResponse. </returns>
            public CreatePaymentLinkResponse Build()
            {
                return new CreatePaymentLinkResponse(
                    this.errors,
                    this.paymentLink,
                    this.relatedResources);
            }
        }
    }
}