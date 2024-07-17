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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// UpdateWorkweekConfigResponse.
    /// </summary>
    public class UpdateWorkweekConfigResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWorkweekConfigResponse"/> class.
        /// </summary>
        /// <param name="workweekConfig">workweek_config.</param>
        /// <param name="errors">errors.</param>
        public UpdateWorkweekConfigResponse(
            Models.WorkweekConfig workweekConfig = null,
            IList<Models.Error> errors = null)
        {
            this.WorkweekConfig = workweekConfig;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Sets the day of the week and hour of the day that a business starts a
        /// workweek. This is used to calculate overtime pay.
        /// </summary>
        [JsonProperty("workweek_config", NullValueHandling = NullValueHandling.Ignore)]
        public Models.WorkweekConfig WorkweekConfig { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateWorkweekConfigResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is UpdateWorkweekConfigResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.WorkweekConfig == null && other.WorkweekConfig == null) || (this.WorkweekConfig?.Equals(other.WorkweekConfig) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1302552646;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.WorkweekConfig, this.Errors);

            return hashCode;
        }
        internal UpdateWorkweekConfigResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.WorkweekConfig = {(this.WorkweekConfig == null ? "null" : this.WorkweekConfig.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .WorkweekConfig(this.WorkweekConfig)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.WorkweekConfig workweekConfig;
            private IList<Models.Error> errors;

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
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateWorkweekConfigResponse. </returns>
            public UpdateWorkweekConfigResponse Build()
            {
                return new UpdateWorkweekConfigResponse(
                    this.workweekConfig,
                    this.errors);
            }
        }
    }
}