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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// V1PhoneNumber.
    /// </summary>
    public class V1PhoneNumber
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1PhoneNumber"/> class.
        /// </summary>
        /// <param name="callingCode">calling_code.</param>
        /// <param name="number">number.</param>
        public V1PhoneNumber(string callingCode, string number)
        {
            this.CallingCode = callingCode;
            this.Number = number;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"V1PhoneNumber : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is V1PhoneNumber other
                && (
                    this.CallingCode == null && other.CallingCode == null
                    || this.CallingCode?.Equals(other.CallingCode) == true
                )
                && (
                    this.Number == null && other.Number == null
                    || this.Number?.Equals(other.Number) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 343986405;
            hashCode = HashCode.Combine(hashCode, this.CallingCode, this.Number);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CallingCode = {this.CallingCode ?? "null"}");
            toStringOutput.Add($"this.Number = {this.Number ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.CallingCode, this.Number);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string callingCode;
            private string number;

            /// <summary>
            /// Initialize Builder for V1PhoneNumber.
            /// </summary>
            /// <param name="callingCode"> callingCode. </param>
            /// <param name="number"> number. </param>
            public Builder(string callingCode, string number)
            {
                this.callingCode = callingCode;
                this.number = number;
            }

            /// <summary>
            /// CallingCode.
            /// </summary>
            /// <param name="callingCode"> callingCode. </param>
            /// <returns> Builder. </returns>
            public Builder CallingCode(string callingCode)
            {
                this.callingCode = callingCode;
                return this;
            }

            /// <summary>
            /// Number.
            /// </summary>
            /// <param name="number"> number. </param>
            /// <returns> Builder. </returns>
            public Builder Number(string number)
            {
                this.number = number;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1PhoneNumber. </returns>
            public V1PhoneNumber Build()
            {
                return new V1PhoneNumber(this.callingCode, this.number);
            }
        }
    }
}
