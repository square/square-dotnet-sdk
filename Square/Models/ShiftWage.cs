
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
    public class ShiftWage 
    {
        public ShiftWage(string title = null,
            Models.Money hourlyRate = null)
        {
            Title = title;
            HourlyRate = hourlyRate;
        }

        /// <summary>
        /// The name of the job performed during this shift. Square
        /// labor-reporting UIs may group shifts together by title.
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("hourly_rate", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money HourlyRate { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ShiftWage : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Title = {(Title == null ? "null" : Title == string.Empty ? "" : Title)}");
            toStringOutput.Add($"HourlyRate = {(HourlyRate == null ? "null" : HourlyRate.ToString())}");
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

            return obj is ShiftWage other &&
                ((Title == null && other.Title == null) || (Title?.Equals(other.Title) == true)) &&
                ((HourlyRate == null && other.HourlyRate == null) || (HourlyRate?.Equals(other.HourlyRate) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1598945307;

            if (Title != null)
            {
               hashCode += Title.GetHashCode();
            }

            if (HourlyRate != null)
            {
               hashCode += HourlyRate.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Title(Title)
                .HourlyRate(HourlyRate);
            return builder;
        }

        public class Builder
        {
            private string title;
            private Models.Money hourlyRate;



            public Builder Title(string title)
            {
                this.title = title;
                return this;
            }

            public Builder HourlyRate(Models.Money hourlyRate)
            {
                this.hourlyRate = hourlyRate;
                return this;
            }

            public ShiftWage Build()
            {
                return new ShiftWage(title,
                    hourlyRate);
            }
        }
    }
}