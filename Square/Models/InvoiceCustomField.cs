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
            this.Label = label;
            this.MValue = mValue;
            this.Placement = placement;
        }

        /// <summary>
        /// The label or title of the custom field. This field is required for a custom field.
        /// </summary>
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; }

        /// <summary>
        /// The text of the custom field. If omitted, only the label is rendered.
        /// </summary>
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
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

            if (this.Label != null)
            {
               hashCode += this.Label.GetHashCode();
            }

            if (this.MValue != null)
            {
               hashCode += this.MValue.GetHashCode();
            }

            if (this.Placement != null)
            {
               hashCode += this.Placement.GetHashCode();
            }

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
            /// Builds class object.
            /// </summary>
            /// <returns> InvoiceCustomField. </returns>
            public InvoiceCustomField Build()
            {
                return new InvoiceCustomField(
                    this.label,
                    this.mValue,
                    this.placement);
            }
        }
    }
}