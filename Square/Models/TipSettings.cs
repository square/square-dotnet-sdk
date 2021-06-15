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
    /// TipSettings.
    /// </summary>
    public class TipSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TipSettings"/> class.
        /// </summary>
        /// <param name="allowTipping">allow_tipping.</param>
        /// <param name="separateTipScreen">separate_tip_screen.</param>
        /// <param name="customTipField">custom_tip_field.</param>
        /// <param name="tipPercentages">tip_percentages.</param>
        /// <param name="smartTipping">smart_tipping.</param>
        public TipSettings(
            bool? allowTipping = null,
            bool? separateTipScreen = null,
            bool? customTipField = null,
            IList<int> tipPercentages = null,
            bool? smartTipping = null)
        {
            this.AllowTipping = allowTipping;
            this.SeparateTipScreen = separateTipScreen;
            this.CustomTipField = customTipField;
            this.TipPercentages = tipPercentages;
            this.SmartTipping = smartTipping;
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
        /// For payments under 10.00, in the Australia, Canada, Ireland, United Kingdom, and United States, tipping options are presented as no tip, .50, 1.00 or 2.00.
        /// For payment amounts of 10.00 or greater, tipping options are presented as the following percentages: 0%, 5%, 10%, 15%.
        /// If set to true, the `tip_percentages` settings is ignored.
        /// Defaults to false.
        /// To learn more about smart tipping, see [Accept Tips with the Square App](https://squareup.com/help/us/en/article/5069-accept-tips-with-the-square-app).
        /// </summary>
        [JsonProperty("smart_tipping", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SmartTipping { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TipSettings : ({string.Join(", ", toStringOutput)})";
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

            return obj is TipSettings other &&
                ((this.AllowTipping == null && other.AllowTipping == null) || (this.AllowTipping?.Equals(other.AllowTipping) == true)) &&
                ((this.SeparateTipScreen == null && other.SeparateTipScreen == null) || (this.SeparateTipScreen?.Equals(other.SeparateTipScreen) == true)) &&
                ((this.CustomTipField == null && other.CustomTipField == null) || (this.CustomTipField?.Equals(other.CustomTipField) == true)) &&
                ((this.TipPercentages == null && other.TipPercentages == null) || (this.TipPercentages?.Equals(other.TipPercentages) == true)) &&
                ((this.SmartTipping == null && other.SmartTipping == null) || (this.SmartTipping?.Equals(other.SmartTipping) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 464455539;

            if (this.AllowTipping != null)
            {
               hashCode += this.AllowTipping.GetHashCode();
            }

            if (this.SeparateTipScreen != null)
            {
               hashCode += this.SeparateTipScreen.GetHashCode();
            }

            if (this.CustomTipField != null)
            {
               hashCode += this.CustomTipField.GetHashCode();
            }

            if (this.TipPercentages != null)
            {
               hashCode += this.TipPercentages.GetHashCode();
            }

            if (this.SmartTipping != null)
            {
               hashCode += this.SmartTipping.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AllowTipping = {(this.AllowTipping == null ? "null" : this.AllowTipping.ToString())}");
            toStringOutput.Add($"this.SeparateTipScreen = {(this.SeparateTipScreen == null ? "null" : this.SeparateTipScreen.ToString())}");
            toStringOutput.Add($"this.CustomTipField = {(this.CustomTipField == null ? "null" : this.CustomTipField.ToString())}");
            toStringOutput.Add($"this.TipPercentages = {(this.TipPercentages == null ? "null" : $"[{string.Join(", ", this.TipPercentages)} ]")}");
            toStringOutput.Add($"this.SmartTipping = {(this.SmartTipping == null ? "null" : this.SmartTipping.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AllowTipping(this.AllowTipping)
                .SeparateTipScreen(this.SeparateTipScreen)
                .CustomTipField(this.CustomTipField)
                .TipPercentages(this.TipPercentages)
                .SmartTipping(this.SmartTipping);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private bool? allowTipping;
            private bool? separateTipScreen;
            private bool? customTipField;
            private IList<int> tipPercentages;
            private bool? smartTipping;

             /// <summary>
             /// AllowTipping.
             /// </summary>
             /// <param name="allowTipping"> allowTipping. </param>
             /// <returns> Builder. </returns>
            public Builder AllowTipping(bool? allowTipping)
            {
                this.allowTipping = allowTipping;
                return this;
            }

             /// <summary>
             /// SeparateTipScreen.
             /// </summary>
             /// <param name="separateTipScreen"> separateTipScreen. </param>
             /// <returns> Builder. </returns>
            public Builder SeparateTipScreen(bool? separateTipScreen)
            {
                this.separateTipScreen = separateTipScreen;
                return this;
            }

             /// <summary>
             /// CustomTipField.
             /// </summary>
             /// <param name="customTipField"> customTipField. </param>
             /// <returns> Builder. </returns>
            public Builder CustomTipField(bool? customTipField)
            {
                this.customTipField = customTipField;
                return this;
            }

             /// <summary>
             /// TipPercentages.
             /// </summary>
             /// <param name="tipPercentages"> tipPercentages. </param>
             /// <returns> Builder. </returns>
            public Builder TipPercentages(IList<int> tipPercentages)
            {
                this.tipPercentages = tipPercentages;
                return this;
            }

             /// <summary>
             /// SmartTipping.
             /// </summary>
             /// <param name="smartTipping"> smartTipping. </param>
             /// <returns> Builder. </returns>
            public Builder SmartTipping(bool? smartTipping)
            {
                this.smartTipping = smartTipping;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TipSettings. </returns>
            public TipSettings Build()
            {
                return new TipSettings(
                    this.allowTipping,
                    this.separateTipScreen,
                    this.customTipField,
                    this.tipPercentages,
                    this.smartTipping);
            }
        }
    }
}