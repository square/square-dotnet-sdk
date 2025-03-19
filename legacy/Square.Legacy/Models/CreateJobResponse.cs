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
using Square.Legacy;
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// CreateJobResponse.
    /// </summary>
    public class CreateJobResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateJobResponse"/> class.
        /// </summary>
        /// <param name="job">job.</param>
        /// <param name="errors">errors.</param>
        public CreateJobResponse(Models.Job job = null, IList<Models.Error> errors = null)
        {
            this.Job = job;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Represents a job that can be assigned to [team members]($m/TeamMember). This object defines the
        /// job's title and tip eligibility. Compensation is defined in a [job assignment]($m/JobAssignment)
        /// in a team member's wage setting.
        /// </summary>
        [JsonProperty("job", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Job Job { get; }

        /// <summary>
        /// The errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CreateJobResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CreateJobResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (this.Job == null && other.Job == null || this.Job?.Equals(other.Job) == true)
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -284245088;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Job, this.Errors);

            return hashCode;
        }

        internal CreateJobResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Job = {(this.Job == null ? "null" : this.Job.ToString())}");
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Job(this.Job).Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Job job;
            private IList<Models.Error> errors;

            /// <summary>
            /// Job.
            /// </summary>
            /// <param name="job"> job. </param>
            /// <returns> Builder. </returns>
            public Builder Job(Models.Job job)
            {
                this.job = job;
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
            /// <returns> CreateJobResponse. </returns>
            public CreateJobResponse Build()
            {
                return new CreateJobResponse(this.job, this.errors);
            }
        }
    }
}
