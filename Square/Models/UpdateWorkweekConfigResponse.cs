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
    public class UpdateWorkweekConfigResponse 
    {
        public UpdateWorkweekConfigResponse(Models.WorkweekConfig workweekConfig = null,
            IList<Models.Error> errors = null)
        {
            WorkweekConfig = workweekConfig;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Sets the Day of the week and hour of the day that a business starts a
        /// work week. Used for the calculation of overtime pay.
        /// </summary>
        [JsonProperty("workweek_config")]
        public Models.WorkweekConfig WorkweekConfig { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .WorkweekConfig(WorkweekConfig)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private Models.WorkweekConfig workweekConfig;
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder WorkweekConfig(Models.WorkweekConfig value)
            {
                workweekConfig = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public UpdateWorkweekConfigResponse Build()
            {
                return new UpdateWorkweekConfigResponse(workweekConfig,
                    errors);
            }
        }
    }
}