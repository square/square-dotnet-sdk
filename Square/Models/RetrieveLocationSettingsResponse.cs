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
    /// RetrieveLocationSettingsResponse.
    /// </summary>
    public class RetrieveLocationSettingsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveLocationSettingsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="locationSettings">location_settings.</param>
        public RetrieveLocationSettingsResponse(
            IList<Models.Error> errors = null,
            Models.CheckoutLocationSettings locationSettings = null)
        {
            this.Errors = errors;
            this.LocationSettings = locationSettings;
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
        /// Gets or sets LocationSettings.
        /// </summary>
        [JsonProperty("location_settings", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CheckoutLocationSettings LocationSettings { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveLocationSettingsResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is RetrieveLocationSettingsResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.LocationSettings == null && other.LocationSettings == null) || (this.LocationSettings?.Equals(other.LocationSettings) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 412627738;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.LocationSettings);

            return hashCode;
        }
        internal RetrieveLocationSettingsResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.LocationSettings = {(this.LocationSettings == null ? "null" : this.LocationSettings.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .LocationSettings(this.LocationSettings);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.CheckoutLocationSettings locationSettings;

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
             /// LocationSettings.
             /// </summary>
             /// <param name="locationSettings"> locationSettings. </param>
             /// <returns> Builder. </returns>
            public Builder LocationSettings(Models.CheckoutLocationSettings locationSettings)
            {
                this.locationSettings = locationSettings;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveLocationSettingsResponse. </returns>
            public RetrieveLocationSettingsResponse Build()
            {
                return new RetrieveLocationSettingsResponse(
                    this.errors,
                    this.locationSettings);
            }
        }
    }
}