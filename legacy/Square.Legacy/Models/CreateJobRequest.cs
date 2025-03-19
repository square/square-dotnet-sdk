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
    /// CreateJobRequest.
    /// </summary>
    public class CreateJobRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateJobRequest"/> class.
        /// </summary>
        /// <param name="job">job.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public CreateJobRequest(Models.Job job, string idempotencyKey)
        {
            this.Job = job;
            this.IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// Represents a job that can be assigned to [team members]($m/TeamMember). This object defines the
        /// job's title and tip eligibility. Compensation is defined in a [job assignment]($m/JobAssignment)
        /// in a team member's wage setting.
        /// </summary>
        [JsonProperty("job")]
        public Models.Job Job { get; }

        /// <summary>
        /// A unique identifier for the `CreateJob` request. Keys can be any valid string,
        /// but must be unique for each request. For more information, see
        /// [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CreateJobRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CreateJobRequest other
                && (this.Job == null && other.Job == null || this.Job?.Equals(other.Job) == true)
                && (
                    this.IdempotencyKey == null && other.IdempotencyKey == null
                    || this.IdempotencyKey?.Equals(other.IdempotencyKey) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -425740042;
            hashCode = HashCode.Combine(hashCode, this.Job, this.IdempotencyKey);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Job = {(this.Job == null ? "null" : this.Job.ToString())}");
            toStringOutput.Add($"this.IdempotencyKey = {this.IdempotencyKey ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Job, this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Job job;
            private string idempotencyKey;

            /// <summary>
            /// Initialize Builder for CreateJobRequest.
            /// </summary>
            /// <param name="job"> job. </param>
            /// <param name="idempotencyKey"> idempotencyKey. </param>
            public Builder(Models.Job job, string idempotencyKey)
            {
                this.job = job;
                this.idempotencyKey = idempotencyKey;
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
            /// IdempotencyKey.
            /// </summary>
            /// <param name="idempotencyKey"> idempotencyKey. </param>
            /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateJobRequest. </returns>
            public CreateJobRequest Build()
            {
                return new CreateJobRequest(this.job, this.idempotencyKey);
            }
        }
    }
}
