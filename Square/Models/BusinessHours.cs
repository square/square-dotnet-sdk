
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
    public class BusinessHours 
    {
        public BusinessHours(IList<Models.BusinessHoursPeriod> periods = null)
        {
            Periods = periods;
        }

        /// <summary>
        /// The list of time periods during which the business is open. There may be at most 10
        /// periods per day.
        /// </summary>
        [JsonProperty("periods", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.BusinessHoursPeriod> Periods { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BusinessHours : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Periods = {(Periods == null ? "null" : $"[{ string.Join(", ", Periods)} ]")}");
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

            return obj is BusinessHours other &&
                ((Periods == null && other.Periods == null) || (Periods?.Equals(other.Periods) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1271827402;

            if (Periods != null)
            {
               hashCode += Periods.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Periods(Periods);
            return builder;
        }

        public class Builder
        {
            private IList<Models.BusinessHoursPeriod> periods;



            public Builder Periods(IList<Models.BusinessHoursPeriod> periods)
            {
                this.periods = periods;
                return this;
            }

            public BusinessHours Build()
            {
                return new BusinessHours(periods);
            }
        }
    }
}