
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
            bool? customTipField = null,
            IList<int> tipPercentages = null,
            bool? smartTipping = null)
        {
            AllowTipping = allowTipping;
            SeparateTipScreen = separateTipScreen;
            CustomTipField = customTipField;
            TipPercentages = tipPercentages;
            SmartTipping = smartTipping;
        }

        /// <summary>
        /// Indicates whether tipping is enabled for this checkout. Defaults to false.
        /// </summary>
        [JsonProperty("allow_tipping", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowTipping { get; }

        /// <summary>
        /// Indicates whether tip options should be presented on the screen before presenting
        /// the signature screen during card payment. Defaults to false.
        /// </summary>
        [JsonProperty("separate_tip_screen", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SeparateTipScreen { get; }

        /// <summary>
        /// Indicates whether custom tip amounts are allowed during the checkout flow. Defaults to false.
        /// </summary>
        [JsonProperty("custom_tip_field", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CustomTipField { get; }

        /// <summary>
        /// A list of tip percentages that should be presented during the checkout flow, specified as
        /// up to 3 non-negative integers from 0 to 100 (inclusive). Defaults to 15, 20, and 25.
        /// </summary>
        [JsonProperty("tip_percentages", NullValueHandling = NullValueHandling.Ignore)]
        public IList<int> TipPercentages { get; }

        /// <summary>
        /// Enables the "Smart Tip Amounts" behavior.
        /// Exact tipping options depend on the region in which the Square seller is active.
        /// In the United States and Canada, tipping options are presented in whole dollar amounts for
        /// payments under $10 USD/CAD respectively.
        /// If set to true, the `tip_percentages` settings is ignored.
        /// Defaults to false.
        /// To learn more about smart tipping, see [Accept Tips with the Square App](https://squareup.com/help/us/en/article/5069-accept-tips-with-the-square-app).
        /// </summary>
        [JsonProperty("smart_tipping", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SmartTipping { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TipSettings : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AllowTipping = {(AllowTipping == null ? "null" : AllowTipping.ToString())}");
            toStringOutput.Add($"SeparateTipScreen = {(SeparateTipScreen == null ? "null" : SeparateTipScreen.ToString())}");
            toStringOutput.Add($"CustomTipField = {(CustomTipField == null ? "null" : CustomTipField.ToString())}");
            toStringOutput.Add($"TipPercentages = {(TipPercentages == null ? "null" : $"[{ string.Join(", ", TipPercentages)} ]")}");
            toStringOutput.Add($"SmartTipping = {(SmartTipping == null ? "null" : SmartTipping.ToString())}");
        }

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

            return obj is TipSettings other &&
                ((AllowTipping == null && other.AllowTipping == null) || (AllowTipping?.Equals(other.AllowTipping) == true)) &&
                ((SeparateTipScreen == null && other.SeparateTipScreen == null) || (SeparateTipScreen?.Equals(other.SeparateTipScreen) == true)) &&
                ((CustomTipField == null && other.CustomTipField == null) || (CustomTipField?.Equals(other.CustomTipField) == true)) &&
                ((TipPercentages == null && other.TipPercentages == null) || (TipPercentages?.Equals(other.TipPercentages) == true)) &&
                ((SmartTipping == null && other.SmartTipping == null) || (SmartTipping?.Equals(other.SmartTipping) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 464455539;

            if (AllowTipping != null)
            {
               hashCode += AllowTipping.GetHashCode();
            }

            if (SeparateTipScreen != null)
            {
               hashCode += SeparateTipScreen.GetHashCode();
            }

            if (CustomTipField != null)
            {
               hashCode += CustomTipField.GetHashCode();
            }

            if (TipPercentages != null)
            {
               hashCode += TipPercentages.GetHashCode();
            }

            if (SmartTipping != null)
            {
               hashCode += SmartTipping.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AllowTipping(AllowTipping)
                .SeparateTipScreen(SeparateTipScreen)
                .CustomTipField(CustomTipField)
                .TipPercentages(TipPercentages)
                .SmartTipping(SmartTipping);
            return builder;
        }

        public class Builder
        {
            private bool? allowTipping;
            private bool? separateTipScreen;
            private bool? customTipField;
            private IList<int> tipPercentages;
            private bool? smartTipping;



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

            public Builder TipPercentages(IList<int> tipPercentages)
            {
                this.tipPercentages = tipPercentages;
                return this;
            }

            public Builder SmartTipping(bool? smartTipping)
            {
                this.smartTipping = smartTipping;
                return this;
            }

            public TipSettings Build()
            {
                return new TipSettings(allowTipping,
                    separateTipScreen,
                    customTipField,
                    tipPercentages,
                    smartTipping);
            }
        }
    }
}