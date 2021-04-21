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
    /// RetrieveInventoryAdjustmentResponse.
    /// </summary>
    public class RetrieveInventoryAdjustmentResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveInventoryAdjustmentResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="adjustment">adjustment.</param>
        public RetrieveInventoryAdjustmentResponse(
            IList<Models.Error> errors = null,
            Models.InventoryAdjustment adjustment = null)
        {
            this.Errors = errors;
            this.Adjustment = adjustment;
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
        /// Represents a change in state or quantity of product inventory at a
        /// particular time and location.
        /// </summary>
        [JsonProperty("adjustment", NullValueHandling = NullValueHandling.Ignore)]
        public Models.InventoryAdjustment Adjustment { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveInventoryAdjustmentResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is RetrieveInventoryAdjustmentResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Adjustment == null && other.Adjustment == null) || (this.Adjustment?.Equals(other.Adjustment) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 277601890;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }

            if (this.Errors != null)
            {
               hashCode += this.Errors.GetHashCode();
            }

            if (this.Adjustment != null)
            {
               hashCode += this.Adjustment.GetHashCode();
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
            toStringOutput.Add($"this.Adjustment = {(this.Adjustment == null ? "null" : this.Adjustment.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Adjustment(this.Adjustment);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.InventoryAdjustment adjustment;

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
             /// Adjustment.
             /// </summary>
             /// <param name="adjustment"> adjustment. </param>
             /// <returns> Builder. </returns>
            public Builder Adjustment(Models.InventoryAdjustment adjustment)
            {
                this.adjustment = adjustment;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveInventoryAdjustmentResponse. </returns>
            public RetrieveInventoryAdjustmentResponse Build()
            {
                return new RetrieveInventoryAdjustmentResponse(
                    this.errors,
                    this.adjustment);
            }
        }
    }
}