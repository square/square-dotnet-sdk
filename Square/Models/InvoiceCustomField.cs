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
    /// InvoiceCustomField.
    /// </summary>
    public class InvoiceCustomField
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceCustomField"/> class.
        /// </summary>
        /// <param name="label">label.</param>
        /// <param name="mValue">value.</param>
        /// <param name="placement">placement.</param>
        public InvoiceCustomField(
            string label = null,
            string mValue = null,
            string placement = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "label", false },
                { "value", false }
            };

            if (label != null)
            {
                shouldSerialize["label"] = true;
                this.Label = label;
            }

            if (mValue != null)
            {
                shouldSerialize["value"] = true;
                this.MValue = mValue;
            }

            this.Placement = placement;
        }
        internal InvoiceCustomField(Dictionary<string, bool> shouldSerialize,
            string label = null,
            string mValue = null,
            string placement = null)
        {
            this.shouldSerialize = shouldSerialize;
            Label = label;
            MValue = mValue;
            Placement = placement;
        }

        /// <summary>
        /// The label or title of the custom field. This field is required for a custom field.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; }

        /// <summary>
        /// The text of the custom field. If omitted, only the label is rendered.
        /// </summary>
        [JsonProperty("value")]
        public string MValue { get; }

        /// <summary>
        /// Indicates where to render a custom field on the Square-hosted invoice page and in emailed or PDF
        /// copies of the invoice.
        /// </summary>
        [JsonProperty("placement", NullValueHandling = NullValueHandling.Ignore)]
        public string Placement { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InvoiceCustomField : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLabel()
        {
            return this.shouldSerialize["label"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMValue()
        {
            return this.shouldSerialize["value"];
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

            return obj is InvoiceCustomField other &&
                ((this.Label == null && other.Label == null) || (this.Label?.Equals(other.Label) == true)) &&
                ((this.MValue == null && other.MValue == null) || (this.MValue?.Equals(other.MValue) == true)) &&
                ((this.Placement == null && other.Placement == null) || (this.Placement?.Equals(other.Placement) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -295655815;
            hashCode = HashCode.Combine(this.Label, this.MValue, this.Placement);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Label = {(this.Label == null ? "null" : this.Label == string.Empty ? "" : this.Label)}");
            toStringOutput.Add($"this.MValue = {(this.MValue == null ? "null" : this.MValue == string.Empty ? "" : this.MValue)}");
            toStringOutput.Add($"this.Placement = {(this.Placement == null ? "null" : this.Placement.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Label(this.Label)
                .MValue(this.MValue)
                .Placement(this.Placement);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "label", false },
                { "value", false },
            };

            private string label;
            private string mValue;
            private string placement;

             /// <summary>
             /// Label.
             /// </summary>
             /// <param name="label"> label. </param>
             /// <returns> Builder. </returns>
            public Builder Label(string label)
            {
                shouldSerialize["label"] = true;
                this.label = label;
                return this;
            }

             /// <summary>
             /// MValue.
             /// </summary>
             /// <param name="mValue"> mValue. </param>
             /// <returns> Builder. </returns>
            public Builder MValue(string mValue)
            {
                shouldSerialize["value"] = true;
                this.mValue = mValue;
                return this;
            }

             /// <summary>
             /// Placement.
             /// </summary>
             /// <param name="placement"> placement. </param>
             /// <returns> Builder. </returns>
            public Builder Placement(string placement)
            {
                this.placement = placement;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLabel()
            {
                this.shouldSerialize["label"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMValue()
            {
                this.shouldSerialize["value"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> InvoiceCustomField. </returns>
            public InvoiceCustomField Build()
            {
                return new InvoiceCustomField(shouldSerialize,
                    this.label,
                    this.mValue,
                    this.placement);
            }
        }
    }
}