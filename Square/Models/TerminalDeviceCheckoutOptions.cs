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
    using Square.Utilities;

    /// <summary>
    /// TerminalDeviceCheckoutOptions.
    /// </summary>
    public class TerminalDeviceCheckoutOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalDeviceCheckoutOptions"/> class.
        /// </summary>
        /// <param name="skipReceiptScreen">skip_receipt_screen.</param>
        /// <param name="tipSettings">tip_settings.</param>
        public TerminalDeviceCheckoutOptions(
            bool? skipReceiptScreen = null,
            Models.TipSettings tipSettings = null)
        {
            this.SkipReceiptScreen = skipReceiptScreen;
            this.TipSettings = tipSettings;
        }

        /// <summary>
        /// Instructs the device to skip the receipt screen. Defaults to false.
        /// </summary>
        [JsonProperty("skip_receipt_screen", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SkipReceiptScreen { get; }

        /// <summary>
        /// Gets or sets TipSettings.
        /// </summary>
        [JsonProperty("tip_settings", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TipSettings TipSettings { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TerminalDeviceCheckoutOptions : ({string.Join(", ", toStringOutput)})";
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

            return obj is TerminalDeviceCheckoutOptions other &&
                ((this.SkipReceiptScreen == null && other.SkipReceiptScreen == null) || (this.SkipReceiptScreen?.Equals(other.SkipReceiptScreen) == true)) &&
                ((this.TipSettings == null && other.TipSettings == null) || (this.TipSettings?.Equals(other.TipSettings) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 919909611;

            if (this.SkipReceiptScreen != null)
            {
               hashCode += this.SkipReceiptScreen.GetHashCode();
            }

            if (this.TipSettings != null)
            {
               hashCode += this.TipSettings.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SkipReceiptScreen = {(this.SkipReceiptScreen == null ? "null" : this.SkipReceiptScreen.ToString())}");
            toStringOutput.Add($"this.TipSettings = {(this.TipSettings == null ? "null" : this.TipSettings.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .SkipReceiptScreen(this.SkipReceiptScreen)
                .TipSettings(this.TipSettings);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private bool? skipReceiptScreen;
            private Models.TipSettings tipSettings;

             /// <summary>
             /// SkipReceiptScreen.
             /// </summary>
             /// <param name="skipReceiptScreen"> skipReceiptScreen. </param>
             /// <returns> Builder. </returns>
            public Builder SkipReceiptScreen(bool? skipReceiptScreen)
            {
                this.skipReceiptScreen = skipReceiptScreen;
                return this;
            }

             /// <summary>
             /// TipSettings.
             /// </summary>
             /// <param name="tipSettings"> tipSettings. </param>
             /// <returns> Builder. </returns>
            public Builder TipSettings(Models.TipSettings tipSettings)
            {
                this.tipSettings = tipSettings;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TerminalDeviceCheckoutOptions. </returns>
            public TerminalDeviceCheckoutOptions Build()
            {
                return new TerminalDeviceCheckoutOptions(
                    this.skipReceiptScreen,
                    this.tipSettings);
            }
        }
    }
}