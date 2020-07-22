using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class CreateShiftResponse 
    {
        public CreateShiftResponse(Models.Shift shift = null,
            IList<Models.Error> errors = null)
        {
            Shift = shift;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A record of the hourly rate, start, and end times for a single work shift
        /// for an employee. May include a record of the start and end times for breaks
        /// taken during the shift.
        /// </summary>
        [JsonProperty("shift")]
        public Models.Shift Shift { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Shift(Shift)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private Models.Shift shift;
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder Shift(Models.Shift value)
            {
                shift = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public CreateShiftResponse Build()
            {
                return new CreateShiftResponse(shift,
                    errors);
            }
        }
    }
}