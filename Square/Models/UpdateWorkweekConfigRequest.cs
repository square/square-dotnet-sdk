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
    public class UpdateWorkweekConfigRequest 
    {
        public UpdateWorkweekConfigRequest(Models.WorkweekConfig workweekConfig)
        {
            WorkweekConfig = workweekConfig;
        }

        /// <summary>
        /// Sets the Day of the week and hour of the day that a business starts a
        /// work week. Used for the calculation of overtime pay.
        /// </summary>
        [JsonProperty("workweek_config")]
        public Models.WorkweekConfig WorkweekConfig { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(WorkweekConfig);
            return builder;
        }

        public class Builder
        {
            private Models.WorkweekConfig workweekConfig;

            public Builder(Models.WorkweekConfig workweekConfig)
            {
                this.workweekConfig = workweekConfig;
            }
            public Builder WorkweekConfig(Models.WorkweekConfig value)
            {
                workweekConfig = value;
                return this;
            }

            public UpdateWorkweekConfigRequest Build()
            {
                return new UpdateWorkweekConfigRequest(workweekConfig);
            }
        }
    }
}