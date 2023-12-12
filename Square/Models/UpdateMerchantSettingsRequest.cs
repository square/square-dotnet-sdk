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
    /// UpdateMerchantSettingsRequest.
    /// </summary>
    public class UpdateMerchantSettingsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMerchantSettingsRequest"/> class.
        /// </summary>
        /// <param name="merchantSettings">merchant_settings.</param>
        public UpdateMerchantSettingsRequest(
            Models.CheckoutMerchantSettings merchantSettings)
        {
            this.MerchantSettings = merchantSettings;
        }

        /// <summary>
        /// Gets or sets MerchantSettings.
        /// </summary>
        [JsonProperty("merchant_settings")]
        public Models.CheckoutMerchantSettings MerchantSettings { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateMerchantSettingsRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is UpdateMerchantSettingsRequest other &&                ((this.MerchantSettings == null && other.MerchantSettings == null) || (this.MerchantSettings?.Equals(other.MerchantSettings) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1936536872;
            hashCode = HashCode.Combine(this.MerchantSettings);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MerchantSettings = {(this.MerchantSettings == null ? "null" : this.MerchantSettings.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.MerchantSettings);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.CheckoutMerchantSettings merchantSettings;

            public Builder(
                Models.CheckoutMerchantSettings merchantSettings)
            {
                this.merchantSettings = merchantSettings;
            }

             /// <summary>
             /// MerchantSettings.
             /// </summary>
             /// <param name="merchantSettings"> merchantSettings. </param>
             /// <returns> Builder. </returns>
            public Builder MerchantSettings(Models.CheckoutMerchantSettings merchantSettings)
            {
                this.merchantSettings = merchantSettings;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateMerchantSettingsRequest. </returns>
            public UpdateMerchantSettingsRequest Build()
            {
                return new UpdateMerchantSettingsRequest(
                    this.merchantSettings);
            }
        }
    }
}