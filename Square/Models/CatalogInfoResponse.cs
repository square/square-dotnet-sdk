namespace Square.Models
{
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

    /// <summary>
    /// CatalogInfoResponse.
    /// </summary>
    public class CatalogInfoResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogInfoResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="limits">limits.</param>
        /// <param name="standardUnitDescriptionGroup">standard_unit_description_group.</param>
        public CatalogInfoResponse(
            IList<Models.Error> errors = null,
            Models.CatalogInfoResponseLimits limits = null,
            Models.StandardUnitDescriptionGroup standardUnitDescriptionGroup = null)
        {
            this.Errors = errors;
            this.Limits = limits;
            this.StandardUnitDescriptionGroup = standardUnitDescriptionGroup;
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
        /// Gets or sets Limits.
        /// </summary>
        [JsonProperty("limits", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogInfoResponseLimits Limits { get; }

        /// <summary>
        /// Group of standard measurement units.
        /// </summary>
        [JsonProperty("standard_unit_description_group", NullValueHandling = NullValueHandling.Ignore)]
        public Models.StandardUnitDescriptionGroup StandardUnitDescriptionGroup { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogInfoResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is CatalogInfoResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Limits == null && other.Limits == null) || (this.Limits?.Equals(other.Limits) == true)) &&
                ((this.StandardUnitDescriptionGroup == null && other.StandardUnitDescriptionGroup == null) || (this.StandardUnitDescriptionGroup?.Equals(other.StandardUnitDescriptionGroup) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -614027011;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.Limits, this.StandardUnitDescriptionGroup);

            return hashCode;
        }
        internal CatalogInfoResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Limits = {(this.Limits == null ? "null" : this.Limits.ToString())}");
            toStringOutput.Add($"this.StandardUnitDescriptionGroup = {(this.StandardUnitDescriptionGroup == null ? "null" : this.StandardUnitDescriptionGroup.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Limits(this.Limits)
                .StandardUnitDescriptionGroup(this.StandardUnitDescriptionGroup);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.CatalogInfoResponseLimits limits;
            private Models.StandardUnitDescriptionGroup standardUnitDescriptionGroup;

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
             /// Limits.
             /// </summary>
             /// <param name="limits"> limits. </param>
             /// <returns> Builder. </returns>
            public Builder Limits(Models.CatalogInfoResponseLimits limits)
            {
                this.limits = limits;
                return this;
            }

             /// <summary>
             /// StandardUnitDescriptionGroup.
             /// </summary>
             /// <param name="standardUnitDescriptionGroup"> standardUnitDescriptionGroup. </param>
             /// <returns> Builder. </returns>
            public Builder StandardUnitDescriptionGroup(Models.StandardUnitDescriptionGroup standardUnitDescriptionGroup)
            {
                this.standardUnitDescriptionGroup = standardUnitDescriptionGroup;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogInfoResponse. </returns>
            public CatalogInfoResponse Build()
            {
                return new CatalogInfoResponse(
                    this.errors,
                    this.limits,
                    this.standardUnitDescriptionGroup);
            }
        }
    }
}