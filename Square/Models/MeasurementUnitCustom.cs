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
    public class MeasurementUnitCustom 
    {
        public MeasurementUnitCustom(string name,
            string abbreviation)
        {
            Name = name;
            Abbreviation = abbreviation;
        }

        /// <summary>
        /// The name of the custom unit, for example "bushel".
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The abbreviation of the custom unit, such as "bsh" (bushel). This appears
        /// in the cart for the Point of Sale app, and in reports.
        /// </summary>
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Name,
                Abbreviation);
            return builder;
        }

        public class Builder
        {
            private string name;
            private string abbreviation;

            public Builder(string name,
                string abbreviation)
            {
                this.name = name;
                this.abbreviation = abbreviation;
            }
            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder Abbreviation(string value)
            {
                abbreviation = value;
                return this;
            }

            public MeasurementUnitCustom Build()
            {
                return new MeasurementUnitCustom(name,
                    abbreviation);
            }
        }
    }
}