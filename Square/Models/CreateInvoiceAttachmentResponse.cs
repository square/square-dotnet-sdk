using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Http.Client;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// CreateInvoiceAttachmentResponse.
    /// </summary>
    public class CreateInvoiceAttachmentResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateInvoiceAttachmentResponse"/> class.
        /// </summary>
        /// <param name="attachment">attachment.</param>
        /// <param name="errors">errors.</param>
        public CreateInvoiceAttachmentResponse(
            Models.InvoiceAttachment attachment = null,
            IList<Models.Error> errors = null)
        {
            this.Attachment = attachment;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Represents a file attached to an [invoice]($m/Invoice).
        /// </summary>
        [JsonProperty("attachment", NullValueHandling = NullValueHandling.Ignore)]
        public Models.InvoiceAttachment Attachment { get; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CreateInvoiceAttachmentResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CreateInvoiceAttachmentResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.Attachment == null && other.Attachment == null ||
                 this.Attachment?.Equals(other.Attachment) == true) &&
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1176431890;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Attachment, this.Errors);

            return hashCode;
        }

        internal CreateInvoiceAttachmentResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Attachment = {(this.Attachment == null ? "null" : this.Attachment.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Attachment(this.Attachment)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.InvoiceAttachment attachment;
            private IList<Models.Error> errors;

             /// <summary>
             /// Attachment.
             /// </summary>
             /// <param name="attachment"> attachment. </param>
             /// <returns> Builder. </returns>
            public Builder Attachment(Models.InvoiceAttachment attachment)
            {
                this.attachment = attachment;
                return this;
            }

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
            /// Builds class object.
            /// </summary>
            /// <returns> CreateInvoiceAttachmentResponse. </returns>
            public CreateInvoiceAttachmentResponse Build()
            {
                return new CreateInvoiceAttachmentResponse(
                    this.attachment,
                    this.errors);
            }
        }
    }
}