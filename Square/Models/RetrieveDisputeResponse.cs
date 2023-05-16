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
    /// RetrieveDisputeResponse.
    /// </summary>
    public class RetrieveDisputeResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveDisputeResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="dispute">dispute.</param>
        public RetrieveDisputeResponse(
            IList<Models.Error> errors = null,
            Models.Dispute dispute = null)
        {
            this.Errors = errors;
            this.Dispute = dispute;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a [dispute](https://developer.squareup.com/docs/disputes-api/overview) a cardholder initiated with their bank.
        /// </summary>
        [JsonProperty("dispute", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Dispute Dispute { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveDisputeResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is RetrieveDisputeResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Dispute == null && other.Dispute == null) || (this.Dispute?.Equals(other.Dispute) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1313306059;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.Dispute);

            return hashCode;
        }
        internal RetrieveDisputeResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Dispute = {(this.Dispute == null ? "null" : this.Dispute.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Dispute(this.Dispute);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.Dispute dispute;

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
             /// Dispute.
             /// </summary>
             /// <param name="dispute"> dispute. </param>
             /// <returns> Builder. </returns>
            public Builder Dispute(Models.Dispute dispute)
            {
                this.dispute = dispute;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveDisputeResponse. </returns>
            public RetrieveDisputeResponse Build()
            {
                return new RetrieveDisputeResponse(
                    this.errors,
                    this.dispute);
            }
        }
    }
}