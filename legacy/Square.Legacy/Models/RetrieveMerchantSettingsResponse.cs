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
    /// RetrieveMerchantSettingsResponse.
    /// </summary>
    public class RetrieveMerchantSettingsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveMerchantSettingsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="merchantSettings">merchant_settings.</param>
        public RetrieveMerchantSettingsResponse(
            IList<Models.Error> errors = null,
            Models.CheckoutMerchantSettings merchantSettings = null
        )
        {
            this.Errors = errors;
            this.MerchantSettings = merchantSettings;
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
        /// Gets or sets MerchantSettings.
        /// </summary>
        [JsonProperty("merchant_settings", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CheckoutMerchantSettings MerchantSettings { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"RetrieveMerchantSettingsResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is RetrieveMerchantSettingsResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.MerchantSettings == null && other.MerchantSettings == null
                    || this.MerchantSettings?.Equals(other.MerchantSettings) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1424022745;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.MerchantSettings);

            return hashCode;
        }

        internal RetrieveMerchantSettingsResponse ContextSetter(HttpContext context)
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
                $"this.MerchantSettings = {(this.MerchantSettings == null ? "null" : this.MerchantSettings.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Errors(this.Errors).MerchantSettings(this.MerchantSettings);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.CheckoutMerchantSettings merchantSettings;

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
            /// <returns> RetrieveMerchantSettingsResponse. </returns>
            public RetrieveMerchantSettingsResponse Build()
            {
                return new RetrieveMerchantSettingsResponse(this.errors, this.merchantSettings);
            }
        }
    }
}
