
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateWorkweekConfigRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"WorkweekConfig = {(WorkweekConfig == null ? "null" : WorkweekConfig.ToString())}");
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

            return obj is UpdateWorkweekConfigRequest other &&
                ((WorkweekConfig == null && other.WorkweekConfig == null) || (WorkweekConfig?.Equals(other.WorkweekConfig) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -161126356;

            if (WorkweekConfig != null)
            {
               hashCode += WorkweekConfig.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder WorkweekConfig(Models.WorkweekConfig workweekConfig)
            {
                this.workweekConfig = workweekConfig;
                return this;
            }

            public UpdateWorkweekConfigRequest Build()
            {
                return new UpdateWorkweekConfigRequest(workweekConfig);
            }
        }
    }
}