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
    /// BatchChangeInventoryResponse.
    /// </summary>
    public class BatchChangeInventoryResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchChangeInventoryResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="counts">counts.</param>
        public BatchChangeInventoryResponse(
            IList<Models.Error> errors = null,
            IList<Models.InventoryCount> counts = null)
        {
            this.Errors = errors;
            this.Counts = counts;
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
        /// The current counts for all objects referenced in the request.
        /// </summary>
        [JsonProperty("counts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.InventoryCount> Counts { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BatchChangeInventoryResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is BatchChangeInventoryResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Counts == null && other.Counts == null) || (this.Counts?.Equals(other.Counts) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -2037694583;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }

            if (this.Errors != null)
            {
               hashCode += this.Errors.GetHashCode();
            }

            if (this.Counts != null)
            {
               hashCode += this.Counts.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Counts = {(this.Counts == null ? "null" : $"[{string.Join(", ", this.Counts)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Counts(this.Counts);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.InventoryCount> counts;

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
             /// Counts.
             /// </summary>
             /// <param name="counts"> counts. </param>
             /// <returns> Builder. </returns>
            public Builder Counts(IList<Models.InventoryCount> counts)
            {
                this.counts = counts;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BatchChangeInventoryResponse. </returns>
            public BatchChangeInventoryResponse Build()
            {
                return new BatchChangeInventoryResponse(
                    this.errors,
                    this.counts);
            }
        }
    }
}