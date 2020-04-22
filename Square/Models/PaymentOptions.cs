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
    public class PaymentOptions 
    {
        public PaymentOptions(bool? autocomplete = null)
        {
            Autocomplete = autocomplete;
        }

        /// <summary>
        /// Indicates whether the Payment objects created from this `TerminalCheckout` will automatically be
        /// COMPLETED or left in an APPROVED state for later modification.
        /// </summary>
        [JsonProperty("autocomplete")]
        public bool? Autocomplete { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Autocomplete(Autocomplete);
            return builder;
        }

        public class Builder
        {
            private bool? autocomplete;

            public Builder() { }
            public Builder Autocomplete(bool? value)
            {
                autocomplete = value;
                return this;
            }

            public PaymentOptions Build()
            {
                return new PaymentOptions(autocomplete);
            }
        }
    }
}