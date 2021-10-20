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
    /// DeviceCheckoutOptions.
    /// </summary>
    public class DeviceCheckoutOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceCheckoutOptions"/> class.
        /// </summary>
        /// <param name="deviceId">device_id.</param>
        /// <param name="skipReceiptScreen">skip_receipt_screen.</param>
        /// <param name="tipSettings">tip_settings.</param>
        public DeviceCheckoutOptions(
            string deviceId,
            bool? skipReceiptScreen = null,
            Models.TipSettings tipSettings = null)
        {
            this.DeviceId = deviceId;
            this.SkipReceiptScreen = skipReceiptScreen;
            this.TipSettings = tipSettings;
        }

        /// <summary>
        /// The unique ID of the device intended for this `TerminalCheckout`.
        /// A list of `DeviceCode` objects can be retrieved from the /v2/devices/codes endpoint.
        /// Match a `DeviceCode.device_id` value with `device_id` to get the associated device code.
        /// </summary>
        [JsonProperty("device_id")]
        public string DeviceId { get; }

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

            return $"DeviceCheckoutOptions : ({string.Join(", ", toStringOutput)})";
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

            return obj is DeviceCheckoutOptions other &&
                ((this.DeviceId == null && other.DeviceId == null) || (this.DeviceId?.Equals(other.DeviceId) == true)) &&
                ((this.SkipReceiptScreen == null && other.SkipReceiptScreen == null) || (this.SkipReceiptScreen?.Equals(other.SkipReceiptScreen) == true)) &&
                ((this.TipSettings == null && other.TipSettings == null) || (this.TipSettings?.Equals(other.TipSettings) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1796237610;
            hashCode = HashCode.Combine(this.DeviceId, this.SkipReceiptScreen, this.TipSettings);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DeviceId = {(this.DeviceId == null ? "null" : this.DeviceId == string.Empty ? "" : this.DeviceId)}");
            toStringOutput.Add($"this.SkipReceiptScreen = {(this.SkipReceiptScreen == null ? "null" : this.SkipReceiptScreen.ToString())}");
            toStringOutput.Add($"this.TipSettings = {(this.TipSettings == null ? "null" : this.TipSettings.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.DeviceId)
                .SkipReceiptScreen(this.SkipReceiptScreen)
                .TipSettings(this.TipSettings);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string deviceId;
            private bool? skipReceiptScreen;
            private Models.TipSettings tipSettings;

            public Builder(
                string deviceId)
            {
                this.deviceId = deviceId;
            }

             /// <summary>
             /// DeviceId.
             /// </summary>
             /// <param name="deviceId"> deviceId. </param>
             /// <returns> Builder. </returns>
            public Builder DeviceId(string deviceId)
            {
                this.deviceId = deviceId;
                return this;
            }

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
            /// <returns> DeviceCheckoutOptions. </returns>
            public DeviceCheckoutOptions Build()
            {
                return new DeviceCheckoutOptions(
                    this.deviceId,
                    this.skipReceiptScreen,
                    this.tipSettings);
            }
        }
    }
}