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
    /// MeasurementUnit.
    /// </summary>
    public class MeasurementUnit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeasurementUnit"/> class.
        /// </summary>
        /// <param name="customUnit">custom_unit.</param>
        /// <param name="areaUnit">area_unit.</param>
        /// <param name="lengthUnit">length_unit.</param>
        /// <param name="volumeUnit">volume_unit.</param>
        /// <param name="weightUnit">weight_unit.</param>
        /// <param name="genericUnit">generic_unit.</param>
        /// <param name="timeUnit">time_unit.</param>
        /// <param name="type">type.</param>
        public MeasurementUnit(
            Models.MeasurementUnitCustom customUnit = null,
            string areaUnit = null,
            string lengthUnit = null,
            string volumeUnit = null,
            string weightUnit = null,
            string genericUnit = null,
            string timeUnit = null,
            string type = null)
        {
            this.CustomUnit = customUnit;
            this.AreaUnit = areaUnit;
            this.LengthUnit = lengthUnit;
            this.VolumeUnit = volumeUnit;
            this.WeightUnit = weightUnit;
            this.GenericUnit = genericUnit;
            this.TimeUnit = timeUnit;
            this.Type = type;
        }

        /// <summary>
        /// The information needed to define a custom unit, provided by the seller.
        /// </summary>
        [JsonProperty("custom_unit", NullValueHandling = NullValueHandling.Ignore)]
        public Models.MeasurementUnitCustom CustomUnit { get; }

        /// <summary>
        /// Unit of area used to measure a quantity.
        /// </summary>
        [JsonProperty("area_unit", NullValueHandling = NullValueHandling.Ignore)]
        public string AreaUnit { get; }

        /// <summary>
        /// The unit of length used to measure a quantity.
        /// </summary>
        [JsonProperty("length_unit", NullValueHandling = NullValueHandling.Ignore)]
        public string LengthUnit { get; }

        /// <summary>
        /// The unit of volume used to measure a quantity.
        /// </summary>
        [JsonProperty("volume_unit", NullValueHandling = NullValueHandling.Ignore)]
        public string VolumeUnit { get; }

        /// <summary>
        /// Unit of weight used to measure a quantity.
        /// </summary>
        [JsonProperty("weight_unit", NullValueHandling = NullValueHandling.Ignore)]
        public string WeightUnit { get; }

        /// <summary>
        /// Gets or sets GenericUnit.
        /// </summary>
        [JsonProperty("generic_unit", NullValueHandling = NullValueHandling.Ignore)]
        public string GenericUnit { get; }

        /// <summary>
        /// Unit of time used to measure a quantity (a duration).
        /// </summary>
        [JsonProperty("time_unit", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeUnit { get; }

        /// <summary>
        /// Describes the type of this unit and indicates which field contains the unit information. This is an ‘open’ enum.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"MeasurementUnit : ({string.Join(", ", toStringOutput)})";
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
            return obj is MeasurementUnit other &&                ((this.CustomUnit == null && other.CustomUnit == null) || (this.CustomUnit?.Equals(other.CustomUnit) == true)) &&
                ((this.AreaUnit == null && other.AreaUnit == null) || (this.AreaUnit?.Equals(other.AreaUnit) == true)) &&
                ((this.LengthUnit == null && other.LengthUnit == null) || (this.LengthUnit?.Equals(other.LengthUnit) == true)) &&
                ((this.VolumeUnit == null && other.VolumeUnit == null) || (this.VolumeUnit?.Equals(other.VolumeUnit) == true)) &&
                ((this.WeightUnit == null && other.WeightUnit == null) || (this.WeightUnit?.Equals(other.WeightUnit) == true)) &&
                ((this.GenericUnit == null && other.GenericUnit == null) || (this.GenericUnit?.Equals(other.GenericUnit) == true)) &&
                ((this.TimeUnit == null && other.TimeUnit == null) || (this.TimeUnit?.Equals(other.TimeUnit) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1167462471;
            hashCode = HashCode.Combine(this.CustomUnit, this.AreaUnit, this.LengthUnit, this.VolumeUnit, this.WeightUnit, this.GenericUnit, this.TimeUnit);

            hashCode = HashCode.Combine(hashCode, this.Type);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CustomUnit = {(this.CustomUnit == null ? "null" : this.CustomUnit.ToString())}");
            toStringOutput.Add($"this.AreaUnit = {(this.AreaUnit == null ? "null" : this.AreaUnit.ToString())}");
            toStringOutput.Add($"this.LengthUnit = {(this.LengthUnit == null ? "null" : this.LengthUnit.ToString())}");
            toStringOutput.Add($"this.VolumeUnit = {(this.VolumeUnit == null ? "null" : this.VolumeUnit.ToString())}");
            toStringOutput.Add($"this.WeightUnit = {(this.WeightUnit == null ? "null" : this.WeightUnit.ToString())}");
            toStringOutput.Add($"this.GenericUnit = {(this.GenericUnit == null ? "null" : this.GenericUnit.ToString())}");
            toStringOutput.Add($"this.TimeUnit = {(this.TimeUnit == null ? "null" : this.TimeUnit.ToString())}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CustomUnit(this.CustomUnit)
                .AreaUnit(this.AreaUnit)
                .LengthUnit(this.LengthUnit)
                .VolumeUnit(this.VolumeUnit)
                .WeightUnit(this.WeightUnit)
                .GenericUnit(this.GenericUnit)
                .TimeUnit(this.TimeUnit)
                .Type(this.Type);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.MeasurementUnitCustom customUnit;
            private string areaUnit;
            private string lengthUnit;
            private string volumeUnit;
            private string weightUnit;
            private string genericUnit;
            private string timeUnit;
            private string type;

             /// <summary>
             /// CustomUnit.
             /// </summary>
             /// <param name="customUnit"> customUnit. </param>
             /// <returns> Builder. </returns>
            public Builder CustomUnit(Models.MeasurementUnitCustom customUnit)
            {
                this.customUnit = customUnit;
                return this;
            }

             /// <summary>
             /// AreaUnit.
             /// </summary>
             /// <param name="areaUnit"> areaUnit. </param>
             /// <returns> Builder. </returns>
            public Builder AreaUnit(string areaUnit)
            {
                this.areaUnit = areaUnit;
                return this;
            }

             /// <summary>
             /// LengthUnit.
             /// </summary>
             /// <param name="lengthUnit"> lengthUnit. </param>
             /// <returns> Builder. </returns>
            public Builder LengthUnit(string lengthUnit)
            {
                this.lengthUnit = lengthUnit;
                return this;
            }

             /// <summary>
             /// VolumeUnit.
             /// </summary>
             /// <param name="volumeUnit"> volumeUnit. </param>
             /// <returns> Builder. </returns>
            public Builder VolumeUnit(string volumeUnit)
            {
                this.volumeUnit = volumeUnit;
                return this;
            }

             /// <summary>
             /// WeightUnit.
             /// </summary>
             /// <param name="weightUnit"> weightUnit. </param>
             /// <returns> Builder. </returns>
            public Builder WeightUnit(string weightUnit)
            {
                this.weightUnit = weightUnit;
                return this;
            }

             /// <summary>
             /// GenericUnit.
             /// </summary>
             /// <param name="genericUnit"> genericUnit. </param>
             /// <returns> Builder. </returns>
            public Builder GenericUnit(string genericUnit)
            {
                this.genericUnit = genericUnit;
                return this;
            }

             /// <summary>
             /// TimeUnit.
             /// </summary>
             /// <param name="timeUnit"> timeUnit. </param>
             /// <returns> Builder. </returns>
            public Builder TimeUnit(string timeUnit)
            {
                this.timeUnit = timeUnit;
                return this;
            }

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
            /// Builds class object.
            /// </summary>
            /// <returns> MeasurementUnit. </returns>
            public MeasurementUnit Build()
            {
                return new MeasurementUnit(
                    this.customUnit,
                    this.areaUnit,
                    this.lengthUnit,
                    this.volumeUnit,
                    this.weightUnit,
                    this.genericUnit,
                    this.timeUnit,
                    this.type);
            }
        }
    }
}