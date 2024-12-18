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
    /// RetrieveInventoryTransferResponse.
    /// </summary>
    public class RetrieveInventoryTransferResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveInventoryTransferResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="transfer">transfer.</param>
        public RetrieveInventoryTransferResponse(
            IList<Models.Error> errors = null,
            Models.InventoryTransfer transfer = null)
        {
            this.Errors = errors;
            this.Transfer = transfer;
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
        /// Represents the transfer of a quantity of product inventory at a
        /// particular time from one location to another.
        /// </summary>
        [JsonProperty("transfer", NullValueHandling = NullValueHandling.Ignore)]
        public Models.InventoryTransfer Transfer { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"RetrieveInventoryTransferResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is RetrieveInventoryTransferResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true) &&
                (this.Transfer == null && other.Transfer == null ||
                 this.Transfer?.Equals(other.Transfer) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1482325954;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Transfer);

            return hashCode;
        }

        internal RetrieveInventoryTransferResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Transfer = {(this.Transfer == null ? "null" : this.Transfer.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Transfer(this.Transfer);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.InventoryTransfer transfer;

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
             /// Transfer.
             /// </summary>
             /// <param name="transfer"> transfer. </param>
             /// <returns> Builder. </returns>
            public Builder Transfer(Models.InventoryTransfer transfer)
            {
                this.transfer = transfer;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveInventoryTransferResponse. </returns>
            public RetrieveInventoryTransferResponse Build()
            {
                return new RetrieveInventoryTransferResponse(
                    this.errors,
                    this.transfer);
            }
        }
    }
}