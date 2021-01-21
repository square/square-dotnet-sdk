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
    public class OnboardAppointmentsResponse 
    {
        public OnboardAppointmentsResponse(IList<Models.Error> errors = null)
        {
            Errors = errors;
        }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public OnboardAppointmentsResponse Build()
            {
                return new OnboardAppointmentsResponse(errors);
            }
        }
    }
}