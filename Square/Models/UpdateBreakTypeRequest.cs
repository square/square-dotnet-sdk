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
    public class UpdateBreakTypeRequest 
    {
        public UpdateBreakTypeRequest(Models.BreakType breakType)
        {
            BreakType = breakType;
        }

        /// <summary>
        /// A defined break template that sets an expectation for possible `Break`
        /// instances on a `Shift`.
        /// </summary>
        [JsonProperty("break_type")]
        public Models.BreakType BreakType { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(BreakType);
            return builder;
        }

        public class Builder
        {
            private Models.BreakType breakType;

            public Builder(Models.BreakType breakType)
            {
                this.breakType = breakType;
            }
            public Builder BreakType(Models.BreakType value)
            {
                breakType = value;
                return this;
            }

            public UpdateBreakTypeRequest Build()
            {
                return new UpdateBreakTypeRequest(breakType);
            }
        }
    }
}