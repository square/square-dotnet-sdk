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
    /// CheckoutLocationSettingsBranding.
    /// </summary>
    public class CheckoutLocationSettingsBranding
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutLocationSettingsBranding"/> class.
        /// </summary>
        /// <param name="headerType">header_type.</param>
        /// <param name="buttonColor">button_color.</param>
        /// <param name="buttonShape">button_shape.</param>
        public CheckoutLocationSettingsBranding(
            string headerType = null,
            string buttonColor = null,
            string buttonShape = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "button_color", false }
            };

            this.HeaderType = headerType;
            if (buttonColor != null)
            {
                shouldSerialize["button_color"] = true;
                this.ButtonColor = buttonColor;
            }

            this.ButtonShape = buttonShape;
        }
        internal CheckoutLocationSettingsBranding(Dictionary<string, bool> shouldSerialize,
            string headerType = null,
            string buttonColor = null,
            string buttonShape = null)
        {
            this.shouldSerialize = shouldSerialize;
            HeaderType = headerType;
            ButtonColor = buttonColor;
            ButtonShape = buttonShape;
        }

        /// <summary>
        /// Gets or sets HeaderType.
        /// </summary>
        [JsonProperty("header_type", NullValueHandling = NullValueHandling.Ignore)]
        public string HeaderType { get; }

        /// <summary>
        /// The HTML-supported hex color for the button on the checkout page (for example, "#FFFFFF").
        /// </summary>
        [JsonProperty("button_color")]
        public string ButtonColor { get; }

        /// <summary>
        /// Gets or sets ButtonShape.
        /// </summary>
        [JsonProperty("button_shape", NullValueHandling = NullValueHandling.Ignore)]
        public string ButtonShape { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CheckoutLocationSettingsBranding : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeButtonColor()
        {
            return this.shouldSerialize["button_color"];
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
            return obj is CheckoutLocationSettingsBranding other &&                ((this.HeaderType == null && other.HeaderType == null) || (this.HeaderType?.Equals(other.HeaderType) == true)) &&
                ((this.ButtonColor == null && other.ButtonColor == null) || (this.ButtonColor?.Equals(other.ButtonColor) == true)) &&
                ((this.ButtonShape == null && other.ButtonShape == null) || (this.ButtonShape?.Equals(other.ButtonShape) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1434657644;
            hashCode = HashCode.Combine(this.HeaderType, this.ButtonColor, this.ButtonShape);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.HeaderType = {(this.HeaderType == null ? "null" : this.HeaderType.ToString())}");
            toStringOutput.Add($"this.ButtonColor = {(this.ButtonColor == null ? "null" : this.ButtonColor)}");
            toStringOutput.Add($"this.ButtonShape = {(this.ButtonShape == null ? "null" : this.ButtonShape.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .HeaderType(this.HeaderType)
                .ButtonColor(this.ButtonColor)
                .ButtonShape(this.ButtonShape);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "button_color", false },
            };

            private string headerType;
            private string buttonColor;
            private string buttonShape;

             /// <summary>
             /// HeaderType.
             /// </summary>
             /// <param name="headerType"> headerType. </param>
             /// <returns> Builder. </returns>
            public Builder HeaderType(string headerType)
            {
                this.headerType = headerType;
                return this;
            }

             /// <summary>
             /// ButtonColor.
             /// </summary>
             /// <param name="buttonColor"> buttonColor. </param>
             /// <returns> Builder. </returns>
            public Builder ButtonColor(string buttonColor)
            {
                shouldSerialize["button_color"] = true;
                this.buttonColor = buttonColor;
                return this;
            }

             /// <summary>
             /// ButtonShape.
             /// </summary>
             /// <param name="buttonShape"> buttonShape. </param>
             /// <returns> Builder. </returns>
            public Builder ButtonShape(string buttonShape)
            {
                this.buttonShape = buttonShape;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetButtonColor()
            {
                this.shouldSerialize["button_color"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CheckoutLocationSettingsBranding. </returns>
            public CheckoutLocationSettingsBranding Build()
            {
                return new CheckoutLocationSettingsBranding(shouldSerialize,
                    this.headerType,
                    this.buttonColor,
                    this.buttonShape);
            }
        }
    }
}