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
using Square.Legacy;
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// UpdateLocationSettingsResponse.
    /// </summary>
    public class UpdateLocationSettingsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateLocationSettingsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="locationSettings">location_settings.</param>
        public UpdateLocationSettingsResponse(
            IList<Models.Error> errors = null,
            Models.CheckoutLocationSettings locationSettings = null
        )
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
        /// Any errors that occurred when updating the location settings.
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
            return $"UpdateLocationSettingsResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is UpdateLocationSettingsResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.LocationSettings == null && other.LocationSettings == null
                    || this.LocationSettings?.Equals(other.LocationSettings) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -946865123;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.LocationSettings);

            return hashCode;
        }

        internal UpdateLocationSettingsResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
            toStringOutput.Add(
                $"this.LocationSettings = {(this.LocationSettings == null ? "null" : this.LocationSettings.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Errors(this.Errors).LocationSettings(this.LocationSettings);
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
            /// <returns> UpdateLocationSettingsResponse. </returns>
            public UpdateLocationSettingsResponse Build()
            {
                return new UpdateLocationSettingsResponse(this.errors, this.locationSettings);
            }
        }
    }
}
