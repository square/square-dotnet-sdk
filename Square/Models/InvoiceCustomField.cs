
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
    public class InvoiceCustomField 
    {
        public InvoiceCustomField(string label = null,
            string mValue = null,
            string placement = null)
        {
            Label = label;
            MValue = mValue;
            Placement = placement;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InvoiceCustomField : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Label = {(Label == null ? "null" : Label == string.Empty ? "" : Label)}");
            toStringOutput.Add($"MValue = {(MValue == null ? "null" : MValue == string.Empty ? "" : MValue)}");
            toStringOutput.Add($"Placement = {(Placement == null ? "null" : Placement.ToString())}");
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

            return obj is InvoiceCustomField other &&
                ((Label == null && other.Label == null) || (Label?.Equals(other.Label) == true)) &&
                ((MValue == null && other.MValue == null) || (MValue?.Equals(other.MValue) == true)) &&
                ((Placement == null && other.Placement == null) || (Placement?.Equals(other.Placement) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -295655815;

            if (Label != null)
            {
               hashCode += Label.GetHashCode();
            }

            if (MValue != null)
            {
               hashCode += MValue.GetHashCode();
            }

            if (Placement != null)
            {
               hashCode += Placement.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Label(Label)
                .MValue(MValue)
                .Placement(Placement);
            return builder;
        }

        public class Builder
        {
            private string label;
            private string mValue;
            private string placement;



            public Builder Label(string label)
            {
                this.label = label;
                return this;
            }

            public Builder MValue(string mValue)
            {
                this.mValue = mValue;
                return this;
            }

            public Builder Placement(string placement)
            {
                this.placement = placement;
                return this;
            }

            public InvoiceCustomField Build()
            {
                return new InvoiceCustomField(label,
                    mValue,
                    placement);
            }
        }
    }
}