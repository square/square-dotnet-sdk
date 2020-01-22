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
            public Builder CallingCode(string value)
            {
                callingCode = value;
                return this;
            }

            public Builder Number(string value)
            {
                number = value;
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