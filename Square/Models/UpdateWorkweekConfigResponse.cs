
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateWorkweekConfigResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"WorkweekConfig = {(WorkweekConfig == null ? "null" : WorkweekConfig.ToString())}");
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is UpdateWorkweekConfigResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((WorkweekConfig == null && other.WorkweekConfig == null) || (WorkweekConfig?.Equals(other.WorkweekConfig) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1302552646;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (WorkweekConfig != null)
            {
               hashCode += WorkweekConfig.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            return hashCode;
        }

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