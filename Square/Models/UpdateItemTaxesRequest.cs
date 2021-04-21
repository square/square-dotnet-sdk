namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// UpdateItemTaxesRequest.
    /// </summary>
    public class UpdateItemTaxesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateItemTaxesRequest"/> class.
        /// </summary>
        /// <param name="itemIds">item_ids.</param>
        /// <param name="taxesToEnable">taxes_to_enable.</param>
        /// <param name="taxesToDisable">taxes_to_disable.</param>
        public UpdateItemTaxesRequest(
            IList<string> itemIds,
            IList<string> taxesToEnable = null,
            IList<string> taxesToDisable = null)
        {
            this.ItemIds = itemIds;
            this.TaxesToEnable = taxesToEnable;
            this.TaxesToDisable = taxesToDisable;
        }

        /// <summary>
        /// IDs for the CatalogItems associated with the CatalogTax objects being updated.
        /// </summary>
        [JsonProperty("item_ids")]
        public IList<string> ItemIds { get; }

        /// <summary>
        /// IDs of the CatalogTax objects to enable.
        /// </summary>
        [JsonProperty("taxes_to_enable", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> TaxesToEnable { get; }

        /// <summary>
        /// IDs of the CatalogTax objects to disable.
        /// </summary>
        [JsonProperty("taxes_to_disable", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> TaxesToDisable { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateItemTaxesRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is UpdateItemTaxesRequest other &&
                ((this.ItemIds == null && other.ItemIds == null) || (this.ItemIds?.Equals(other.ItemIds) == true)) &&
                ((this.TaxesToEnable == null && other.TaxesToEnable == null) || (this.TaxesToEnable?.Equals(other.TaxesToEnable) == true)) &&
                ((this.TaxesToDisable == null && other.TaxesToDisable == null) || (this.TaxesToDisable?.Equals(other.TaxesToDisable) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 651000777;

            if (this.ItemIds != null)
            {
               hashCode += this.ItemIds.GetHashCode();
            }

            if (this.TaxesToEnable != null)
            {
               hashCode += this.TaxesToEnable.GetHashCode();
            }

            if (this.TaxesToDisable != null)
            {
               hashCode += this.TaxesToDisable.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ItemIds = {(this.ItemIds == null ? "null" : $"[{string.Join(", ", this.ItemIds)} ]")}");
            toStringOutput.Add($"this.TaxesToEnable = {(this.TaxesToEnable == null ? "null" : $"[{string.Join(", ", this.TaxesToEnable)} ]")}");
            toStringOutput.Add($"this.TaxesToDisable = {(this.TaxesToDisable == null ? "null" : $"[{string.Join(", ", this.TaxesToDisable)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.ItemIds)
                .TaxesToEnable(this.TaxesToEnable)
                .TaxesToDisable(this.TaxesToDisable);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> itemIds;
            private IList<string> taxesToEnable;
            private IList<string> taxesToDisable;

            public Builder(
                IList<string> itemIds)
            {
                this.itemIds = itemIds;
            }

             /// <summary>
             /// ItemIds.
             /// </summary>
             /// <param name="itemIds"> itemIds. </param>
             /// <returns> Builder. </returns>
            public Builder ItemIds(IList<string> itemIds)
            {
                this.itemIds = itemIds;
                return this;
            }

             /// <summary>
             /// TaxesToEnable.
             /// </summary>
             /// <param name="taxesToEnable"> taxesToEnable. </param>
             /// <returns> Builder. </returns>
            public Builder TaxesToEnable(IList<string> taxesToEnable)
            {
                this.taxesToEnable = taxesToEnable;
                return this;
            }

             /// <summary>
             /// TaxesToDisable.
             /// </summary>
             /// <param name="taxesToDisable"> taxesToDisable. </param>
             /// <returns> Builder. </returns>
            public Builder TaxesToDisable(IList<string> taxesToDisable)
            {
                this.taxesToDisable = taxesToDisable;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateItemTaxesRequest. </returns>
            public UpdateItemTaxesRequest Build()
            {
                return new UpdateItemTaxesRequest(
                    this.itemIds,
                    this.taxesToEnable,
                    this.taxesToDisable);
            }
        }
    }
}