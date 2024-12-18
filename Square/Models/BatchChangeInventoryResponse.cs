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
    /// BatchChangeInventoryResponse.
    /// </summary>
    public class BatchChangeInventoryResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchChangeInventoryResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="counts">counts.</param>
        /// <param name="changes">changes.</param>
        public BatchChangeInventoryResponse(
            IList<Models.Error> errors = null,
            IList<Models.InventoryCount> counts = null,
            IList<Models.InventoryChange> changes = null)
        {
            this.Errors = errors;
            this.Counts = counts;
            this.Changes = changes;
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

        /// <summary>
        /// Changes created for the request.
        /// </summary>
        [JsonProperty("changes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.InventoryChange> Changes { get; }

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
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is BatchChangeInventoryResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true) &&
                (this.Counts == null && other.Counts == null ||
                 this.Counts?.Equals(other.Counts) == true) &&
                (this.Changes == null && other.Changes == null ||
                 this.Changes?.Equals(other.Changes) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1837136071;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Counts, this.Changes);

            return hashCode;
        }

        internal BatchChangeInventoryResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Counts = {(this.Counts == null ? "null" : $"[{string.Join(", ", this.Counts)} ]")}");
            toStringOutput.Add($"this.Changes = {(this.Changes == null ? "null" : $"[{string.Join(", ", this.Changes)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Counts(this.Counts)
                .Changes(this.Changes);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.InventoryCount> counts;
            private IList<Models.InventoryChange> changes;

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
             /// Changes.
             /// </summary>
             /// <param name="changes"> changes. </param>
             /// <returns> Builder. </returns>
            public Builder Changes(IList<Models.InventoryChange> changes)
            {
                this.changes = changes;
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
                    this.counts,
                    this.changes);
            }
        }
    }
}