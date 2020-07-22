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
    public class UpdateBreakTypeResponse 
    {
        public UpdateBreakTypeResponse(Models.BreakType breakType = null,
            IList<Models.Error> errors = null)
        {
            BreakType = breakType;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A defined break template that sets an expectation for possible `Break`
        /// instances on a `Shift`.
        /// </summary>
        [JsonProperty("break_type")]
        public Models.BreakType BreakType { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BreakType(BreakType)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private Models.BreakType breakType;
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder BreakType(Models.BreakType value)
            {
                breakType = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public UpdateBreakTypeResponse Build()
            {
                return new UpdateBreakTypeResponse(breakType,
                    errors);
            }
        }
    }
}