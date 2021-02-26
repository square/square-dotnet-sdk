
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
    public class MeasurementUnit 
    {
        public MeasurementUnit(Models.MeasurementUnitCustom customUnit = null,
            string areaUnit = null,
            string lengthUnit = null,
            string volumeUnit = null,
            string weightUnit = null,
            string genericUnit = null,
            string timeUnit = null,
            string type = null)
        {
            CustomUnit = customUnit;
            AreaUnit = areaUnit;
            LengthUnit = lengthUnit;
            VolumeUnit = volumeUnit;
            WeightUnit = weightUnit;
            GenericUnit = genericUnit;
            TimeUnit = timeUnit;
            Type = type;
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
        /// Getter for generic_unit
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"MeasurementUnit : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"CustomUnit = {(CustomUnit == null ? "null" : CustomUnit.ToString())}");
            toStringOutput.Add($"AreaUnit = {(AreaUnit == null ? "null" : AreaUnit.ToString())}");
            toStringOutput.Add($"LengthUnit = {(LengthUnit == null ? "null" : LengthUnit.ToString())}");
            toStringOutput.Add($"VolumeUnit = {(VolumeUnit == null ? "null" : VolumeUnit.ToString())}");
            toStringOutput.Add($"WeightUnit = {(WeightUnit == null ? "null" : WeightUnit.ToString())}");
            toStringOutput.Add($"GenericUnit = {(GenericUnit == null ? "null" : GenericUnit.ToString())}");
            toStringOutput.Add($"TimeUnit = {(TimeUnit == null ? "null" : TimeUnit.ToString())}");
            toStringOutput.Add($"Type = {(Type == null ? "null" : Type.ToString())}");
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

            return obj is MeasurementUnit other &&
                ((CustomUnit == null && other.CustomUnit == null) || (CustomUnit?.Equals(other.CustomUnit) == true)) &&
                ((AreaUnit == null && other.AreaUnit == null) || (AreaUnit?.Equals(other.AreaUnit) == true)) &&
                ((LengthUnit == null && other.LengthUnit == null) || (LengthUnit?.Equals(other.LengthUnit) == true)) &&
                ((VolumeUnit == null && other.VolumeUnit == null) || (VolumeUnit?.Equals(other.VolumeUnit) == true)) &&
                ((WeightUnit == null && other.WeightUnit == null) || (WeightUnit?.Equals(other.WeightUnit) == true)) &&
                ((GenericUnit == null && other.GenericUnit == null) || (GenericUnit?.Equals(other.GenericUnit) == true)) &&
                ((TimeUnit == null && other.TimeUnit == null) || (TimeUnit?.Equals(other.TimeUnit) == true)) &&
                ((Type == null && other.Type == null) || (Type?.Equals(other.Type) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1167462471;

            if (CustomUnit != null)
            {
               hashCode += CustomUnit.GetHashCode();
            }

            if (AreaUnit != null)
            {
               hashCode += AreaUnit.GetHashCode();
            }

            if (LengthUnit != null)
            {
               hashCode += LengthUnit.GetHashCode();
            }

            if (VolumeUnit != null)
            {
               hashCode += VolumeUnit.GetHashCode();
            }

            if (WeightUnit != null)
            {
               hashCode += WeightUnit.GetHashCode();
            }

            if (GenericUnit != null)
            {
               hashCode += GenericUnit.GetHashCode();
            }

            if (TimeUnit != null)
            {
               hashCode += TimeUnit.GetHashCode();
            }

            if (Type != null)
            {
               hashCode += Type.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CustomUnit(CustomUnit)
                .AreaUnit(AreaUnit)
                .LengthUnit(LengthUnit)
                .VolumeUnit(VolumeUnit)
                .WeightUnit(WeightUnit)
                .GenericUnit(GenericUnit)
                .TimeUnit(TimeUnit)
                .Type(Type);
            return builder;
        }

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



            public Builder CustomUnit(Models.MeasurementUnitCustom customUnit)
            {
                this.customUnit = customUnit;
                return this;
            }

            public Builder AreaUnit(string areaUnit)
            {
                this.areaUnit = areaUnit;
                return this;
            }

            public Builder LengthUnit(string lengthUnit)
            {
                this.lengthUnit = lengthUnit;
                return this;
            }

            public Builder VolumeUnit(string volumeUnit)
            {
                this.volumeUnit = volumeUnit;
                return this;
            }

            public Builder WeightUnit(string weightUnit)
            {
                this.weightUnit = weightUnit;
                return this;
            }

            public Builder GenericUnit(string genericUnit)
            {
                this.genericUnit = genericUnit;
                return this;
            }

            public Builder TimeUnit(string timeUnit)
            {
                this.timeUnit = timeUnit;
                return this;
            }

            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

            public MeasurementUnit Build()
            {
                return new MeasurementUnit(customUnit,
                    areaUnit,
                    lengthUnit,
                    volumeUnit,
                    weightUnit,
                    genericUnit,
                    timeUnit,
                    type);
            }
        }
    }
}