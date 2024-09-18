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

namespace Square.Models
{
    /// <summary>
    /// CheckoutLocationSettingsTipping.
    /// </summary>
    public class CheckoutLocationSettingsTipping
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutLocationSettingsTipping"/> class.
        /// </summary>
        /// <param name="percentages">percentages.</param>
        /// <param name="smartTippingEnabled">smart_tipping_enabled.</param>
        /// <param name="defaultPercent">default_percent.</param>
        /// <param name="smartTips">smart_tips.</param>
        /// <param name="defaultSmartTip">default_smart_tip.</param>
        public CheckoutLocationSettingsTipping(
            IList<int> percentages = null,
            bool? smartTippingEnabled = null,
            int? defaultPercent = null,
            IList<Models.Money> smartTips = null,
            Models.Money defaultSmartTip = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "percentages", false },
                { "smart_tipping_enabled", false },
                { "default_percent", false },
                { "smart_tips", false }
            };

            if (percentages != null)
            {
                shouldSerialize["percentages"] = true;
                this.Percentages = percentages;
            }

            if (smartTippingEnabled != null)
            {
                shouldSerialize["smart_tipping_enabled"] = true;
                this.SmartTippingEnabled = smartTippingEnabled;
            }

            if (defaultPercent != null)
            {
                shouldSerialize["default_percent"] = true;
                this.DefaultPercent = defaultPercent;
            }

            if (smartTips != null)
            {
                shouldSerialize["smart_tips"] = true;
                this.SmartTips = smartTips;
            }

            this.DefaultSmartTip = defaultSmartTip;
        }
        internal CheckoutLocationSettingsTipping(Dictionary<string, bool> shouldSerialize,
            IList<int> percentages = null,
            bool? smartTippingEnabled = null,
            int? defaultPercent = null,
            IList<Models.Money> smartTips = null,
            Models.Money defaultSmartTip = null)
        {
            this.shouldSerialize = shouldSerialize;
            Percentages = percentages;
            SmartTippingEnabled = smartTippingEnabled;
            DefaultPercent = defaultPercent;
            SmartTips = smartTips;
            DefaultSmartTip = defaultSmartTip;
        }

        /// <summary>
        /// Set three custom percentage amounts that buyers can select at checkout. If Smart Tip is enabled, this only applies to transactions totaling $10 or more.
        /// </summary>
        [JsonProperty("percentages")]
        public IList<int> Percentages { get; }

        /// <summary>
        /// Enables Smart Tip Amounts. If Smart Tip Amounts is enabled, tipping works as follows:
        /// If a transaction is less than $10, the available tipping options include No Tip, $1, $2, or $3.
        /// If a transaction is $10 or more, the available tipping options include No Tip, 15%, 20%, or 25%.
        /// You can set custom percentage amounts with the `percentages` field.
        /// </summary>
        [JsonProperty("smart_tipping_enabled")]
        public bool? SmartTippingEnabled { get; }

        /// <summary>
        /// Set the pre-selected percentage amounts that appear at checkout. If Smart Tip is enabled, this only applies to transactions totaling $10 or more.
        /// </summary>
        [JsonProperty("default_percent")]
        public int? DefaultPercent { get; }

        /// <summary>
        /// Show the Smart Tip Amounts for this location.
        /// </summary>
        [JsonProperty("smart_tips")]
        public IList<Models.Money> SmartTips { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("default_smart_tip", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money DefaultSmartTip { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CheckoutLocationSettingsTipping : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePercentages()
        {
            return this.shouldSerialize["percentages"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSmartTippingEnabled()
        {
            return this.shouldSerialize["smart_tipping_enabled"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDefaultPercent()
        {
            return this.shouldSerialize["default_percent"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSmartTips()
        {
            return this.shouldSerialize["smart_tips"];
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
            return obj is CheckoutLocationSettingsTipping other &&                ((this.Percentages == null && other.Percentages == null) || (this.Percentages?.Equals(other.Percentages) == true)) &&
                ((this.SmartTippingEnabled == null && other.SmartTippingEnabled == null) || (this.SmartTippingEnabled?.Equals(other.SmartTippingEnabled) == true)) &&
                ((this.DefaultPercent == null && other.DefaultPercent == null) || (this.DefaultPercent?.Equals(other.DefaultPercent) == true)) &&
                ((this.SmartTips == null && other.SmartTips == null) || (this.SmartTips?.Equals(other.SmartTips) == true)) &&
                ((this.DefaultSmartTip == null && other.DefaultSmartTip == null) || (this.DefaultSmartTip?.Equals(other.DefaultSmartTip) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1257901161;
            hashCode = HashCode.Combine(this.Percentages, this.SmartTippingEnabled, this.DefaultPercent, this.SmartTips, this.DefaultSmartTip);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Percentages = {(this.Percentages == null ? "null" : $"[{string.Join(", ", this.Percentages)} ]")}");
            toStringOutput.Add($"this.SmartTippingEnabled = {(this.SmartTippingEnabled == null ? "null" : this.SmartTippingEnabled.ToString())}");
            toStringOutput.Add($"this.DefaultPercent = {(this.DefaultPercent == null ? "null" : this.DefaultPercent.ToString())}");
            toStringOutput.Add($"this.SmartTips = {(this.SmartTips == null ? "null" : $"[{string.Join(", ", this.SmartTips)} ]")}");
            toStringOutput.Add($"this.DefaultSmartTip = {(this.DefaultSmartTip == null ? "null" : this.DefaultSmartTip.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Percentages(this.Percentages)
                .SmartTippingEnabled(this.SmartTippingEnabled)
                .DefaultPercent(this.DefaultPercent)
                .SmartTips(this.SmartTips)
                .DefaultSmartTip(this.DefaultSmartTip);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "percentages", false },
                { "smart_tipping_enabled", false },
                { "default_percent", false },
                { "smart_tips", false },
            };

            private IList<int> percentages;
            private bool? smartTippingEnabled;
            private int? defaultPercent;
            private IList<Models.Money> smartTips;
            private Models.Money defaultSmartTip;

             /// <summary>
             /// Percentages.
             /// </summary>
             /// <param name="percentages"> percentages. </param>
             /// <returns> Builder. </returns>
            public Builder Percentages(IList<int> percentages)
            {
                shouldSerialize["percentages"] = true;
                this.percentages = percentages;
                return this;
            }

             /// <summary>
             /// SmartTippingEnabled.
             /// </summary>
             /// <param name="smartTippingEnabled"> smartTippingEnabled. </param>
             /// <returns> Builder. </returns>
            public Builder SmartTippingEnabled(bool? smartTippingEnabled)
            {
                shouldSerialize["smart_tipping_enabled"] = true;
                this.smartTippingEnabled = smartTippingEnabled;
                return this;
            }

             /// <summary>
             /// DefaultPercent.
             /// </summary>
             /// <param name="defaultPercent"> defaultPercent. </param>
             /// <returns> Builder. </returns>
            public Builder DefaultPercent(int? defaultPercent)
            {
                shouldSerialize["default_percent"] = true;
                this.defaultPercent = defaultPercent;
                return this;
            }

             /// <summary>
             /// SmartTips.
             /// </summary>
             /// <param name="smartTips"> smartTips. </param>
             /// <returns> Builder. </returns>
            public Builder SmartTips(IList<Models.Money> smartTips)
            {
                shouldSerialize["smart_tips"] = true;
                this.smartTips = smartTips;
                return this;
            }

             /// <summary>
             /// DefaultSmartTip.
             /// </summary>
             /// <param name="defaultSmartTip"> defaultSmartTip. </param>
             /// <returns> Builder. </returns>
            public Builder DefaultSmartTip(Models.Money defaultSmartTip)
            {
                this.defaultSmartTip = defaultSmartTip;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPercentages()
            {
                this.shouldSerialize["percentages"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSmartTippingEnabled()
            {
                this.shouldSerialize["smart_tipping_enabled"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDefaultPercent()
            {
                this.shouldSerialize["default_percent"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSmartTips()
            {
                this.shouldSerialize["smart_tips"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CheckoutLocationSettingsTipping. </returns>
            public CheckoutLocationSettingsTipping Build()
            {
                return new CheckoutLocationSettingsTipping(shouldSerialize,
                    this.percentages,
                    this.smartTippingEnabled,
                    this.defaultPercent,
                    this.smartTips,
                    this.defaultSmartTip);
            }
        }
    }
}