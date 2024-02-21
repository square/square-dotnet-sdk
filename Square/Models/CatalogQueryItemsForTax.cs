namespace Square.Models
{
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

    /// <summary>
    /// CatalogQueryItemsForTax.
    /// </summary>
    public class CatalogQueryItemsForTax
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogQueryItemsForTax"/> class.
        /// </summary>
        /// <param name="taxIds">tax_ids.</param>
        public CatalogQueryItemsForTax(
            IList<string> taxIds)
        {
            this.TaxIds = taxIds;
        }

        /// <summary>
        /// A set of `CatalogTax` IDs to be used to find associated `CatalogItem`s.
        /// </summary>
        [JsonProperty("tax_ids")]
        public IList<string> TaxIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQueryItemsForTax : ({string.Join(", ", toStringOutput)})";
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
            return obj is CatalogQueryItemsForTax other &&                ((this.TaxIds == null && other.TaxIds == null) || (this.TaxIds?.Equals(other.TaxIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 507867183;
            hashCode = HashCode.Combine(this.TaxIds);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TaxIds = {(this.TaxIds == null ? "null" : $"[{string.Join(", ", this.TaxIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.TaxIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> taxIds;

            /// <summary>
            /// Initialize Builder for CatalogQueryItemsForTax.
            /// </summary>
            /// <param name="taxIds"> taxIds. </param>
            public Builder(
                IList<string> taxIds)
            {
                this.taxIds = taxIds;
            }

             /// <summary>
             /// TaxIds.
             /// </summary>
             /// <param name="taxIds"> taxIds. </param>
             /// <returns> Builder. </returns>
            public Builder TaxIds(IList<string> taxIds)
            {
                this.taxIds = taxIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogQueryItemsForTax. </returns>
            public CatalogQueryItemsForTax Build()
            {
                return new CatalogQueryItemsForTax(
                    this.taxIds);
            }
        }
    }
}