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
    public class V1UpdateTimecardRequest 
    {
        public V1UpdateTimecardRequest(Models.V1Timecard body)
        {
            Body = body;
        }

        /// <summary>
        /// Represents a timecard for an employee.
        /// </summary>
        [JsonProperty("body")]
        public Models.V1Timecard Body { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Body);
            return builder;
        }

        public class Builder
        {
            private Models.V1Timecard body;

            public Builder(Models.V1Timecard body)
            {
                this.body = body;
            }
            public Builder Body(Models.V1Timecard value)
            {
                body = value;
                return this;
            }

            public V1UpdateTimecardRequest Build()
            {
                return new V1UpdateTimecardRequest(body);
            }
        }
    }
}