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
        [JsonProperty("workweek_config", NullValueHandling = NullValueHandling.Ignore)]
        public Models.WorkweekConfig WorkweekConfig { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
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
            private IList<Models.Error> errors;



            public Builder WorkweekConfig(Models.WorkweekConfig workweekConfig)
            {
                this.workweekConfig = workweekConfig;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
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