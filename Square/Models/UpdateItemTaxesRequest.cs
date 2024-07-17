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
    /// UpdateItemTaxesRequest.
    /// </summary>
    public class UpdateItemTaxesRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "taxes_to_enable", false },
                { "taxes_to_disable", false }
            };

            this.ItemIds = itemIds;
            if (taxesToEnable != null)
            {
                shouldSerialize["taxes_to_enable"] = true;
                this.TaxesToEnable = taxesToEnable;
            }

            if (taxesToDisable != null)
            {
                shouldSerialize["taxes_to_disable"] = true;
                this.TaxesToDisable = taxesToDisable;
            }

        }
        internal UpdateItemTaxesRequest(Dictionary<string, bool> shouldSerialize,
            IList<string> itemIds,
            IList<string> taxesToEnable = null,
            IList<string> taxesToDisable = null)
        {
            this.shouldSerialize = shouldSerialize;
            ItemIds = itemIds;
            TaxesToEnable = taxesToEnable;
            TaxesToDisable = taxesToDisable;
        }

        /// <summary>
        /// IDs for the CatalogItems associated with the CatalogTax objects being updated.
        /// No more than 1,000 IDs may be provided.
        /// </summary>
        [JsonProperty("item_ids")]
        public IList<string> ItemIds { get; }

        /// <summary>
        /// IDs of the CatalogTax objects to enable.
        /// At least one of `taxes_to_enable` or `taxes_to_disable` must be specified.
        /// </summary>
        [JsonProperty("taxes_to_enable")]
        public IList<string> TaxesToEnable { get; }

        /// <summary>
        /// IDs of the CatalogTax objects to disable.
        /// At least one of `taxes_to_enable` or `taxes_to_disable` must be specified.
        /// </summary>
        [JsonProperty("taxes_to_disable")]
        public IList<string> TaxesToDisable { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateItemTaxesRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTaxesToEnable()
        {
            return this.shouldSerialize["taxes_to_enable"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTaxesToDisable()
        {
            return this.shouldSerialize["taxes_to_disable"];
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
            return obj is UpdateItemTaxesRequest other &&                ((this.ItemIds == null && other.ItemIds == null) || (this.ItemIds?.Equals(other.ItemIds) == true)) &&
                ((this.TaxesToEnable == null && other.TaxesToEnable == null) || (this.TaxesToEnable?.Equals(other.TaxesToEnable) == true)) &&
                ((this.TaxesToDisable == null && other.TaxesToDisable == null) || (this.TaxesToDisable?.Equals(other.TaxesToDisable) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 651000777;
            hashCode = HashCode.Combine(this.ItemIds, this.TaxesToEnable, this.TaxesToDisable);

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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "taxes_to_enable", false },
                { "taxes_to_disable", false },
            };

            private IList<string> itemIds;
            private IList<string> taxesToEnable;
            private IList<string> taxesToDisable;

            /// <summary>
            /// Initialize Builder for UpdateItemTaxesRequest.
            /// </summary>
            /// <param name="itemIds"> itemIds. </param>
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
                shouldSerialize["taxes_to_enable"] = true;
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
                shouldSerialize["taxes_to_disable"] = true;
                this.taxesToDisable = taxesToDisable;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTaxesToEnable()
            {
                this.shouldSerialize["taxes_to_enable"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTaxesToDisable()
            {
                this.shouldSerialize["taxes_to_disable"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateItemTaxesRequest. </returns>
            public UpdateItemTaxesRequest Build()
            {
                return new UpdateItemTaxesRequest(shouldSerialize,
                    this.itemIds,
                    this.taxesToEnable,
                    this.taxesToDisable);
            }
        }
    }
}