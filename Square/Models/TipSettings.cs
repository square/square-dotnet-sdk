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
    public class TipSettings 
    {
        public TipSettings(bool? allowTipping = null,
            bool? separateTipScreen = null,
            bool? customTipField = null)
        {
            AllowTipping = allowTipping;
            SeparateTipScreen = separateTipScreen;
            CustomTipField = customTipField;
        }

        /// <summary>
        /// Indicates whether tipping is enabled for this checkout. Defaults to false.
        /// </summary>
        [JsonProperty("allow_tipping", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowTipping { get; }

        /// <summary>
        /// Indicates whether tip options should be presented on their own screen before presenting
        /// the signature screen during card payment. Defaults to false.
        /// </summary>
        [JsonProperty("separate_tip_screen", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SeparateTipScreen { get; }

        /// <summary>
        /// Indicates whether custom tip amounts are allowed during the checkout flow. Defaults to false.
        /// </summary>
        [JsonProperty("custom_tip_field", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CustomTipField { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AllowTipping(AllowTipping)
                .SeparateTipScreen(SeparateTipScreen)
                .CustomTipField(CustomTipField);
            return builder;
        }

        public class Builder
        {
            private bool? allowTipping;
            private bool? separateTipScreen;
            private bool? customTipField;



            public Builder AllowTipping(bool? allowTipping)
            {
                this.allowTipping = allowTipping;
                return this;
            }

            public Builder SeparateTipScreen(bool? separateTipScreen)
            {
                this.separateTipScreen = separateTipScreen;
                return this;
            }

            public Builder CustomTipField(bool? customTipField)
            {
                this.customTipField = customTipField;
                return this;
            }

            public TipSettings Build()
            {
                return new TipSettings(allowTipping,
                    separateTipScreen,
                    customTipField);
            }
        }
    }
}