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
    /// DeletePaymentLinkResponse.
    /// </summary>
    public class DeletePaymentLinkResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeletePaymentLinkResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="id">id.</param>
        /// <param name="cancelledOrderId">cancelled_order_id.</param>
        public DeletePaymentLinkResponse(
            IList<Models.Error> errors = null,
            string id = null,
            string cancelledOrderId = null)
        {
            this.Errors = errors;
            this.Id = id;
            this.CancelledOrderId = cancelledOrderId;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Gets or sets Errors.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The ID of the link that is deleted.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The ID of the order that is canceled. When a payment link is deleted, Square updates the
        /// the `state` (of the order that the checkout link created) to CANCELED.
        /// </summary>
        [JsonProperty("cancelled_order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CancelledOrderId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DeletePaymentLinkResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is DeletePaymentLinkResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.CancelledOrderId == null && other.CancelledOrderId == null) || (this.CancelledOrderId?.Equals(other.CancelledOrderId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1625392411;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.Id, this.CancelledOrderId);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.CancelledOrderId = {(this.CancelledOrderId == null ? "null" : this.CancelledOrderId == string.Empty ? "" : this.CancelledOrderId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Id(this.Id)
                .CancelledOrderId(this.CancelledOrderId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private string id;
            private string cancelledOrderId;

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
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// CancelledOrderId.
             /// </summary>
             /// <param name="cancelledOrderId"> cancelledOrderId. </param>
             /// <returns> Builder. </returns>
            public Builder CancelledOrderId(string cancelledOrderId)
            {
                this.cancelledOrderId = cancelledOrderId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DeletePaymentLinkResponse. </returns>
            public DeletePaymentLinkResponse Build()
            {
                return new DeletePaymentLinkResponse(
                    this.errors,
                    this.id,
                    this.cancelledOrderId);
            }
        }
    }
}