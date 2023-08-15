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
    /// InventoryChange.
    /// </summary>
    public class InventoryChange
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryChange"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="physicalCount">physical_count.</param>
        /// <param name="adjustment">adjustment.</param>
        /// <param name="transfer">transfer.</param>
        /// <param name="measurementUnit">measurement_unit.</param>
        /// <param name="measurementUnitId">measurement_unit_id.</param>
        public InventoryChange(
            string type = null,
            Models.InventoryPhysicalCount physicalCount = null,
            Models.InventoryAdjustment adjustment = null,
            Models.InventoryTransfer transfer = null,
            Models.CatalogMeasurementUnit measurementUnit = null,
            string measurementUnitId = null)
        {
            this.Type = type;
            this.PhysicalCount = physicalCount;
            this.Adjustment = adjustment;
            this.Transfer = transfer;
            this.MeasurementUnit = measurementUnit;
            this.MeasurementUnitId = measurementUnitId;
        }

        /// <summary>
        /// Indicates how the inventory change was applied to a tracked product quantity.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// Represents the quantity of an item variation that is physically present
        /// at a specific location, verified by a seller or a seller's employee. For example,
        /// a physical count might come from an employee counting the item variations on
        /// hand or from syncing with an external system.
        /// </summary>
        [JsonProperty("physical_count", NullValueHandling = NullValueHandling.Ignore)]
        public Models.InventoryPhysicalCount PhysicalCount { get; }

        /// <summary>
        /// Represents a change in state or quantity of product inventory at a
        /// particular time and location.
        /// </summary>
        [JsonProperty("adjustment", NullValueHandling = NullValueHandling.Ignore)]
        public Models.InventoryAdjustment Adjustment { get; }

        /// <summary>
        /// Represents the transfer of a quantity of product inventory at a
        /// particular time from one location to another.
        /// </summary>
        [JsonProperty("transfer", NullValueHandling = NullValueHandling.Ignore)]
        public Models.InventoryTransfer Transfer { get; }

        /// <summary>
        /// Represents the unit used to measure a `CatalogItemVariation` and
        /// specifies the precision for decimal quantities.
        /// </summary>
        [JsonProperty("measurement_unit", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogMeasurementUnit MeasurementUnit { get; }

        /// <summary>
        /// The ID of the [CatalogMeasurementUnit](entity:CatalogMeasurementUnit) object representing the catalog measurement unit associated with the inventory change.
        /// </summary>
        [JsonProperty("measurement_unit_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MeasurementUnitId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InventoryChange : ({string.Join(", ", toStringOutput)})";
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
            return obj is InventoryChange other &&                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.PhysicalCount == null && other.PhysicalCount == null) || (this.PhysicalCount?.Equals(other.PhysicalCount) == true)) &&
                ((this.Adjustment == null && other.Adjustment == null) || (this.Adjustment?.Equals(other.Adjustment) == true)) &&
                ((this.Transfer == null && other.Transfer == null) || (this.Transfer?.Equals(other.Transfer) == true)) &&
                ((this.MeasurementUnit == null && other.MeasurementUnit == null) || (this.MeasurementUnit?.Equals(other.MeasurementUnit) == true)) &&
                ((this.MeasurementUnitId == null && other.MeasurementUnitId == null) || (this.MeasurementUnitId?.Equals(other.MeasurementUnitId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1147135160;
            hashCode = HashCode.Combine(this.Type, this.PhysicalCount, this.Adjustment, this.Transfer, this.MeasurementUnit, this.MeasurementUnitId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.PhysicalCount = {(this.PhysicalCount == null ? "null" : this.PhysicalCount.ToString())}");
            toStringOutput.Add($"this.Adjustment = {(this.Adjustment == null ? "null" : this.Adjustment.ToString())}");
            toStringOutput.Add($"this.Transfer = {(this.Transfer == null ? "null" : this.Transfer.ToString())}");
            toStringOutput.Add($"this.MeasurementUnit = {(this.MeasurementUnit == null ? "null" : this.MeasurementUnit.ToString())}");
            toStringOutput.Add($"this.MeasurementUnitId = {(this.MeasurementUnitId == null ? "null" : this.MeasurementUnitId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Type(this.Type)
                .PhysicalCount(this.PhysicalCount)
                .Adjustment(this.Adjustment)
                .Transfer(this.Transfer)
                .MeasurementUnit(this.MeasurementUnit)
                .MeasurementUnitId(this.MeasurementUnitId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string type;
            private Models.InventoryPhysicalCount physicalCount;
            private Models.InventoryAdjustment adjustment;
            private Models.InventoryTransfer transfer;
            private Models.CatalogMeasurementUnit measurementUnit;
            private string measurementUnitId;

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// PhysicalCount.
             /// </summary>
             /// <param name="physicalCount"> physicalCount. </param>
             /// <returns> Builder. </returns>
            public Builder PhysicalCount(Models.InventoryPhysicalCount physicalCount)
            {
                this.physicalCount = physicalCount;
                return this;
            }

             /// <summary>
             /// Adjustment.
             /// </summary>
             /// <param name="adjustment"> adjustment. </param>
             /// <returns> Builder. </returns>
            public Builder Adjustment(Models.InventoryAdjustment adjustment)
            {
                this.adjustment = adjustment;
                return this;
            }

             /// <summary>
             /// Transfer.
             /// </summary>
             /// <param name="transfer"> transfer. </param>
             /// <returns> Builder. </returns>
            public Builder Transfer(Models.InventoryTransfer transfer)
            {
                this.transfer = transfer;
                return this;
            }

             /// <summary>
             /// MeasurementUnit.
             /// </summary>
             /// <param name="measurementUnit"> measurementUnit. </param>
             /// <returns> Builder. </returns>
            public Builder MeasurementUnit(Models.CatalogMeasurementUnit measurementUnit)
            {
                this.measurementUnit = measurementUnit;
                return this;
            }

             /// <summary>
             /// MeasurementUnitId.
             /// </summary>
             /// <param name="measurementUnitId"> measurementUnitId. </param>
             /// <returns> Builder. </returns>
            public Builder MeasurementUnitId(string measurementUnitId)
            {
                this.measurementUnitId = measurementUnitId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> InventoryChange. </returns>
            public InventoryChange Build()
            {
                return new InventoryChange(
                    this.type,
                    this.physicalCount,
                    this.adjustment,
                    this.transfer,
                    this.measurementUnit,
                    this.measurementUnitId);
            }
        }
    }
}