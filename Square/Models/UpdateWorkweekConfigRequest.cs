namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// UpdateWorkweekConfigRequest.
    /// </summary>
    public class UpdateWorkweekConfigRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWorkweekConfigRequest"/> class.
        /// </summary>
        /// <param name="workweekConfig">workweek_config.</param>
        public UpdateWorkweekConfigRequest(
            Models.WorkweekConfig workweekConfig)
        {
            this.WorkweekConfig = workweekConfig;
        }

        /// <summary>
        /// Sets the day of the week and hour of the day that a business starts a
        /// workweek. This is used to calculate overtime pay.
        /// </summary>
        [JsonProperty("workweek_config")]
        public Models.WorkweekConfig WorkweekConfig { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateWorkweekConfigRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
            return obj is UpdateWorkweekConfigRequest other &&                ((this.WorkweekConfig == null && other.WorkweekConfig == null) || (this.WorkweekConfig?.Equals(other.WorkweekConfig) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -161126356;
            hashCode = HashCode.Combine(this.WorkweekConfig);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.WorkweekConfig = {(this.WorkweekConfig == null ? "null" : this.WorkweekConfig.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.WorkweekConfig);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.WorkweekConfig workweekConfig;

            /// <summary>
            /// Initialize Builder for UpdateWorkweekConfigRequest.
            /// </summary>
            /// <param name="workweekConfig"> workweekConfig. </param>
            public Builder(
                Models.WorkweekConfig workweekConfig)
            {
                this.workweekConfig = workweekConfig;
            }

             /// <summary>
             /// WorkweekConfig.
             /// </summary>
             /// <param name="workweekConfig"> workweekConfig. </param>
             /// <returns> Builder. </returns>
            public Builder WorkweekConfig(Models.WorkweekConfig workweekConfig)
            {
                this.workweekConfig = workweekConfig;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateWorkweekConfigRequest. </returns>
            public UpdateWorkweekConfigRequest Build()
            {
                return new UpdateWorkweekConfigRequest(
                    this.workweekConfig);
            }
        }
    }
}