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