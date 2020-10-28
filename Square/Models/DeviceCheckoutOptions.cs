using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class DeviceCheckoutOptions 
    {
        public DeviceCheckoutOptions(string deviceId,
            bool? skipReceiptScreen = null,
            Models.TipSettings tipSettings = null)
        {
            DeviceId = deviceId;
            SkipReceiptScreen = skipReceiptScreen;
            TipSettings = tipSettings;
        }

        /// <summary>
        /// The unique ID of the device intended for this `TerminalCheckout`.
        /// A list of `DeviceCode` objects can be retrieved from the /v2/devices/codes endpoint.
        /// Match a `DeviceCode.device_id` value with `device_id` to get the associated device code.
        /// </summary>
        [JsonProperty("device_id")]
        public string DeviceId { get; }

        /// <summary>
        /// Instruct the device to skip the receipt screen. Defaults to false.
        /// </summary>
        [JsonProperty("skip_receipt_screen", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SkipReceiptScreen { get; }

        /// <summary>
        /// Getter for tip_settings
        /// </summary>
        [JsonProperty("tip_settings", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TipSettings TipSettings { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(DeviceId)
                .SkipReceiptScreen(SkipReceiptScreen)
                .TipSettings(TipSettings);
            return builder;
        }

        public class Builder
        {
            private string deviceId;
            private bool? skipReceiptScreen;
            private Models.TipSettings tipSettings;

            public Builder(string deviceId)
            {
                this.deviceId = deviceId;
            }

            public Builder DeviceId(string deviceId)
            {
                this.deviceId = deviceId;
                return this;
            }

            public Builder SkipReceiptScreen(bool? skipReceiptScreen)
            {
                this.skipReceiptScreen = skipReceiptScreen;
                return this;
            }

            public Builder TipSettings(Models.TipSettings tipSettings)
            {
                this.tipSettings = tipSettings;
                return this;
            }

            public DeviceCheckoutOptions Build()
            {
                return new DeviceCheckoutOptions(deviceId,
                    skipReceiptScreen,
                    tipSettings);
            }
        }
    }
}