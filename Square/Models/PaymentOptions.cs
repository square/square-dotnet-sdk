
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
        /// `COMPLETED` or left in an `APPROVED` state for later modification.
        /// </summary>
        [JsonProperty("autocomplete", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Autocomplete { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaymentOptions : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Autocomplete = {(Autocomplete == null ? "null" : Autocomplete.ToString())}");
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

            return obj is PaymentOptions other &&
                ((Autocomplete == null && other.Autocomplete == null) || (Autocomplete?.Equals(other.Autocomplete) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 449968409;

            if (Autocomplete != null)
            {
               hashCode += Autocomplete.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Autocomplete(Autocomplete);
            return builder;
        }

        public class Builder
        {
            private bool? autocomplete;



            public Builder Autocomplete(bool? autocomplete)
            {
                this.autocomplete = autocomplete;
                return this;
            }

            public PaymentOptions Build()
            {
                return new PaymentOptions(autocomplete);
            }
        }
    }
}