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
    /// UpdateCustomerGroupResponse.
    /// </summary>
    public class UpdateCustomerGroupResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCustomerGroupResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="mGroup">group.</param>
        public UpdateCustomerGroupResponse(
            IList<Models.Error> errors = null,
            Models.CustomerGroup mGroup = null)
        {
            this.Errors = errors;
            this.MGroup = mGroup;
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
        /// Represents a group of customer profiles.
        /// Customer groups can be created, be modified, and have their membership defined using
        /// the Customers API or within the Customer Directory in the Square Seller Dashboard or Point of Sale.
        /// </summary>
        [JsonProperty("group", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerGroup MGroup { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateCustomerGroupResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is UpdateCustomerGroupResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.MGroup == null && other.MGroup == null) || (this.MGroup?.Equals(other.MGroup) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 242231367;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }

            if (this.Errors != null)
            {
               hashCode += this.Errors.GetHashCode();
            }

            if (this.MGroup != null)
            {
               hashCode += this.MGroup.GetHashCode();
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
            toStringOutput.Add($"this.MGroup = {(this.MGroup == null ? "null" : this.MGroup.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .MGroup(this.MGroup);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.CustomerGroup mGroup;

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
             /// MGroup.
             /// </summary>
             /// <param name="mGroup"> mGroup. </param>
             /// <returns> Builder. </returns>
            public Builder MGroup(Models.CustomerGroup mGroup)
            {
                this.mGroup = mGroup;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateCustomerGroupResponse. </returns>
            public UpdateCustomerGroupResponse Build()
            {
                return new UpdateCustomerGroupResponse(
                    this.errors,
                    this.mGroup);
            }
        }
    }
}