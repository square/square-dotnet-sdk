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
    /// RetrieveInventoryPhysicalCountResponse.
    /// </summary>
    public class RetrieveInventoryPhysicalCountResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveInventoryPhysicalCountResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="count">count.</param>
        public RetrieveInventoryPhysicalCountResponse(
            IList<Models.Error> errors = null,
            Models.InventoryPhysicalCount count = null)
        {
            this.Errors = errors;
            this.Count = count;
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
        /// Represents the quantity of an item variation that is physically present
        /// at a specific location, verified by a seller or a seller's employee. For example,
        /// a physical count might come from an employee counting the item variations on
        /// hand or from syncing with an external system.
        /// </summary>
        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public Models.InventoryPhysicalCount Count { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"RetrieveInventoryPhysicalCountResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is RetrieveInventoryPhysicalCountResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true) &&
                (this.Count == null && other.Count == null ||
                 this.Count?.Equals(other.Count) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1531237384;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Count);

            return hashCode;
        }

        internal RetrieveInventoryPhysicalCountResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Count = {(this.Count == null ? "null" : this.Count.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Count(this.Count);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.InventoryPhysicalCount count;

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
             /// Count.
             /// </summary>
             /// <param name="count"> count. </param>
             /// <returns> Builder. </returns>
            public Builder Count(Models.InventoryPhysicalCount count)
            {
                this.count = count;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveInventoryPhysicalCountResponse. </returns>
            public RetrieveInventoryPhysicalCountResponse Build()
            {
                return new RetrieveInventoryPhysicalCountResponse(
                    this.errors,
                    this.count);
            }
        }
    }
}