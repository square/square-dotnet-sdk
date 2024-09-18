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
    /// InvoiceRecipientTaxIds.
    /// </summary>
    public class InvoiceRecipientTaxIds
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceRecipientTaxIds"/> class.
        /// </summary>
        /// <param name="euVat">eu_vat.</param>
        public InvoiceRecipientTaxIds(
            string euVat = null)
        {
            this.EuVat = euVat;
        }

        /// <summary>
        /// The EU VAT identification number for the invoice recipient. For example, `IE3426675K`.
        /// </summary>
        [JsonProperty("eu_vat", NullValueHandling = NullValueHandling.Ignore)]
        public string EuVat { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InvoiceRecipientTaxIds : ({string.Join(", ", toStringOutput)})";
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
            return obj is InvoiceRecipientTaxIds other &&                ((this.EuVat == null && other.EuVat == null) || (this.EuVat?.Equals(other.EuVat) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 631412968;
            hashCode = HashCode.Combine(this.EuVat);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EuVat = {(this.EuVat == null ? "null" : this.EuVat)}");
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
            private string euVat;

             /// <summary>
             /// EuVat.
             /// </summary>
             /// <param name="euVat"> euVat. </param>
             /// <returns> Builder. </returns>
            public Builder EuVat(string euVat)
            {
                this.euVat = euVat;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> InvoiceRecipientTaxIds. </returns>
            public InvoiceRecipientTaxIds Build()
            {
                return new InvoiceRecipientTaxIds(
                    this.euVat);
            }
        }
    }
}