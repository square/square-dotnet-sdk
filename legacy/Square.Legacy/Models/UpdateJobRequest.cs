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
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// UpdateJobRequest.
    /// </summary>
    public class UpdateJobRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateJobRequest"/> class.
        /// </summary>
        /// <param name="job">job.</param>
        public UpdateJobRequest(Models.Job job)
        {
            this.Job = job;
        }

        /// <summary>
        /// Represents a job that can be assigned to [team members]($m/TeamMember). This object defines the
        /// job's title and tip eligibility. Compensation is defined in a [job assignment]($m/JobAssignment)
        /// in a team member's wage setting.
        /// </summary>
        [JsonProperty("job")]
        public Models.Job Job { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"UpdateJobRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is UpdateJobRequest other
                && (this.Job == null && other.Job == null || this.Job?.Equals(other.Job) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1981879675;
            hashCode = HashCode.Combine(hashCode, this.Job);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Job = {(this.Job == null ? "null" : this.Job.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Job);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Job job;

            /// <summary>
            /// Initialize Builder for UpdateJobRequest.
            /// </summary>
            /// <param name="job"> job. </param>
            public Builder(Models.Job job)
            {
                this.job = job;
            }

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
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateJobRequest. </returns>
            public UpdateJobRequest Build()
            {
                return new UpdateJobRequest(this.job);
            }
        }
    }
}
