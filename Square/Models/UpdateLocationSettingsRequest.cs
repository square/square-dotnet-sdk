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
    using Square.Utilities;

    /// <summary>
    /// UpdateLocationSettingsRequest.
    /// </summary>
    public class UpdateLocationSettingsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateLocationSettingsRequest"/> class.
        /// </summary>
        /// <param name="locationSettings">location_settings.</param>
        public UpdateLocationSettingsRequest(
            Models.CheckoutLocationSettings locationSettings)
        {
            this.LocationSettings = locationSettings;
        }

        /// <summary>
        /// Gets or sets LocationSettings.
        /// </summary>
        [JsonProperty("location_settings")]
        public Models.CheckoutLocationSettings LocationSettings { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateLocationSettingsRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is UpdateLocationSettingsRequest other &&                ((this.LocationSettings == null && other.LocationSettings == null) || (this.LocationSettings?.Equals(other.LocationSettings) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 741365165;
            hashCode = HashCode.Combine(this.LocationSettings);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationSettings = {(this.LocationSettings == null ? "null" : this.LocationSettings.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LocationSettings);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.CheckoutLocationSettings locationSettings;

            public Builder(
                Models.CheckoutLocationSettings locationSettings)
            {
                this.locationSettings = locationSettings;
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
            /// <returns> UpdateLocationSettingsRequest. </returns>
            public UpdateLocationSettingsRequest Build()
            {
                return new UpdateLocationSettingsRequest(
                    this.locationSettings);
            }
        }
    }
}