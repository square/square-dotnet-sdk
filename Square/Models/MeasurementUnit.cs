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
        [JsonProperty("custom_unit")]
        public Models.MeasurementUnitCustom CustomUnit { get; }

        /// <summary>
        /// Unit of area used to measure a quantity.
        /// </summary>
        [JsonProperty("area_unit")]
        public string AreaUnit { get; }

        /// <summary>
        /// The unit of length used to measure a quantity.
        /// </summary>
        [JsonProperty("length_unit")]
        public string LengthUnit { get; }

        /// <summary>
        /// The unit of volume used to measure a quantity.
        /// </summary>
        [JsonProperty("volume_unit")]
        public string VolumeUnit { get; }

        /// <summary>
        /// Unit of weight used to measure a quantity.
        /// </summary>
        [JsonProperty("weight_unit")]
        public string WeightUnit { get; }

        /// <summary>
        /// Getter for generic_unit
        /// </summary>
        [JsonProperty("generic_unit")]
        public string GenericUnit { get; }

        /// <summary>
        /// Unit of time used to measure a quantity (a duration).
        /// </summary>
        [JsonProperty("time_unit")]
        public string TimeUnit { get; }

        /// <summary>
        /// Describes the type of this unit and indicates which field contains the unit information. This is an ‘open’ enum.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

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

            public Builder() { }
            public Builder CustomUnit(Models.MeasurementUnitCustom value)
            {
                customUnit = value;
                return this;
            }

            public Builder AreaUnit(string value)
            {
                areaUnit = value;
                return this;
            }

            public Builder LengthUnit(string value)
            {
                lengthUnit = value;
                return this;
            }

            public Builder VolumeUnit(string value)
            {
                volumeUnit = value;
                return this;
            }

            public Builder WeightUnit(string value)
            {
                weightUnit = value;
                return this;
            }

            public Builder GenericUnit(string value)
            {
                genericUnit = value;
                return this;
            }

            public Builder TimeUnit(string value)
            {
                timeUnit = value;
                return this;
            }

            public Builder Type(string value)
            {
                type = value;
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