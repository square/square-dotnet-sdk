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
    /// CustomerTaxIds.
    /// </summary>
    public class CustomerTaxIds
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerTaxIds"/> class.
        /// </summary>
        /// <param name="euVat">eu_vat.</param>
        public CustomerTaxIds(
            string euVat = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "eu_vat", false }
            };

            if (euVat != null)
            {
                shouldSerialize["eu_vat"] = true;
                this.EuVat = euVat;
            }
        }

        internal CustomerTaxIds(
            Dictionary<string, bool> shouldSerialize,
            string euVat = null)
        {
            this.shouldSerialize = shouldSerialize;
            EuVat = euVat;
        }

        /// <summary>
        /// The EU VAT identification number for the customer. For example, `IE3426675K`. The ID can contain alphanumeric characters only.
        /// </summary>
        [JsonProperty("eu_vat")]
        public string EuVat { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CustomerTaxIds : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEuVat()
        {
            return this.shouldSerialize["eu_vat"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CustomerTaxIds other &&
                (this.EuVat == null && other.EuVat == null ||
                 this.EuVat?.Equals(other.EuVat) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1102894926;
            hashCode = HashCode.Combine(hashCode, this.EuVat);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EuVat = {this.EuVat ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EuVat(this.EuVat);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "eu_vat", false },
            };

            private string euVat;

             /// <summary>
             /// EuVat.
             /// </summary>
             /// <param name="euVat"> euVat. </param>
             /// <returns> Builder. </returns>
            public Builder EuVat(string euVat)
            {
                shouldSerialize["eu_vat"] = true;
                this.euVat = euVat;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetEuVat()
            {
                this.shouldSerialize["eu_vat"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CustomerTaxIds. </returns>
            public CustomerTaxIds Build()
            {
                return new CustomerTaxIds(
                    shouldSerialize,
                    this.euVat);
            }
        }
    }
}