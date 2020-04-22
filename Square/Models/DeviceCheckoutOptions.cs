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
        /// The unique Id of the device intended for this `TerminalCheckout`.
        /// The Id can be retrieved from /v2/devices api.
        /// </summary>
        [JsonProperty("device_id")]
        public string DeviceId { get; }

        /// <summary>
        /// Instruct the device to skip the receipt screen. Defaults to false.
        /// </summary>
        [JsonProperty("skip_receipt_screen")]
        public bool? SkipReceiptScreen { get; }

        /// <summary>
        /// Getter for tip_settings
        /// </summary>
        [JsonProperty("tip_settings")]
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
            public Builder DeviceId(string value)
            {
                deviceId = value;
                return this;
            }

            public Builder SkipReceiptScreen(bool? value)
            {
                skipReceiptScreen = value;
                return this;
            }

            public Builder TipSettings(Models.TipSettings value)
            {
                tipSettings = value;
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