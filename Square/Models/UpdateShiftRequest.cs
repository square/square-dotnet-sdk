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
    public class UpdateShiftRequest 
    {
        public UpdateShiftRequest(Models.Shift shift)
        {
            Shift = shift;
        }

        /// <summary>
        /// A record of the hourly rate, start, and end times for a single work shift
        /// for an employee. May include a record of the start and end times for breaks
        /// taken during the shift.
        /// </summary>
        [JsonProperty("shift")]
        public Models.Shift Shift { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Shift);
            return builder;
        }

        public class Builder
        {
            private Models.Shift shift;

            public Builder(Models.Shift shift)
            {
                this.shift = shift;
            }
            public Builder Shift(Models.Shift value)
            {
                shift = value;
                return this;
            }

            public UpdateShiftRequest Build()
            {
                return new UpdateShiftRequest(shift);
            }
        }
    }
}