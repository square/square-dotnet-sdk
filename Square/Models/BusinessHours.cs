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
        [JsonProperty("periods")]
        public IList<Models.BusinessHoursPeriod> Periods { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Periods(Periods);
            return builder;
        }

        public class Builder
        {
            private IList<Models.BusinessHoursPeriod> periods = new List<Models.BusinessHoursPeriod>();

            public Builder() { }
            public Builder Periods(IList<Models.BusinessHoursPeriod> value)
            {
                periods = value;
                return this;
            }

            public BusinessHours Build()
            {
                return new BusinessHours(periods);
            }
        }
    }
}