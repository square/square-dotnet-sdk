
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
    public class V1PhoneNumber 
    {
        public V1PhoneNumber(string callingCode,
            string number)
        {
            CallingCode = callingCode;
            Number = number;
        }

        /// <summary>
        /// The phone number's international calling code. For US phone numbers, this value is +1.
        /// </summary>
        [JsonProperty("calling_code")]
        public string CallingCode { get; }

        /// <summary>
        /// The phone number.
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1PhoneNumber : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"CallingCode = {(CallingCode == null ? "null" : CallingCode == string.Empty ? "" : CallingCode)}");
            toStringOutput.Add($"Number = {(Number == null ? "null" : Number == string.Empty ? "" : Number)}");
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

            return obj is V1PhoneNumber other &&
                ((CallingCode == null && other.CallingCode == null) || (CallingCode?.Equals(other.CallingCode) == true)) &&
                ((Number == null && other.Number == null) || (Number?.Equals(other.Number) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 343986405;

            if (CallingCode != null)
            {
               hashCode += CallingCode.GetHashCode();
            }

            if (Number != null)
            {
               hashCode += Number.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(CallingCode,
                Number);
            return builder;
        }

        public class Builder
        {
            private string callingCode;
            private string number;

            public Builder(string callingCode,
                string number)
            {
                this.callingCode = callingCode;
                this.number = number;
            }

            public Builder CallingCode(string callingCode)
            {
                this.callingCode = callingCode;
                return this;
            }

            public Builder Number(string number)
            {
                this.number = number;
                return this;
            }

            public V1PhoneNumber Build()
            {
                return new V1PhoneNumber(callingCode,
                    number);
            }
        }
    }
}