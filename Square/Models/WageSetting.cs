namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// WageSetting.
    /// </summary>
    public class WageSetting
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WageSetting"/> class.
        /// </summary>
        /// <param name="teamMemberId">team_member_id.</param>
        /// <param name="jobAssignments">job_assignments.</param>
        /// <param name="isOvertimeExempt">is_overtime_exempt.</param>
        /// <param name="version">version.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        public WageSetting(
            string teamMemberId = null,
            IList<Models.JobAssignment> jobAssignments = null,
            bool? isOvertimeExempt = null,
            int? version = null,
            string createdAt = null,
            string updatedAt = null)
        {
            this.TeamMemberId = teamMemberId;
            this.JobAssignments = jobAssignments;
            this.IsOvertimeExempt = isOvertimeExempt;
            this.Version = version;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// The unique ID of the `TeamMember` whom this wage setting describes.
        /// </summary>
        [JsonProperty("team_member_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamMemberId { get; }

        /// <summary>
        /// <b>Required</b> The ordered list of jobs that the team member is assigned to.
        /// The first job assignment is considered the team member's "Primary Job".
        /// <br>
        /// <b>Min Length 1    Max Length 12</b>
        /// </summary>
        [JsonProperty("job_assignments", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.JobAssignment> JobAssignments { get; }

        /// <summary>
        /// Whether the team member is exempt from the overtime rules of the seller country.
        /// </summary>
        [JsonProperty("is_overtime_exempt", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsOvertimeExempt { get; }

        /// <summary>
        /// Used for resolving concurrency issues; request will fail if version
        /// provided does not match server version at time of request. If not provided,
        /// Square executes a blind write, potentially overwriting data from another write. Read
        /// about [optimistic concurrency](https://developer.squareup.com/docs/working-with-apis/optimistic-concurrency)
        /// in Square APIs for more information.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// The timestamp in RFC 3339 format describing when the wage setting object was created.
        /// Ex: "2018-10-04T04:00:00-07:00" or "2019-02-05T12:00:00Z"
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp in RFC 3339 format describing when the wage setting object was last updated.
        /// Ex: "2018-10-04T04:00:00-07:00" or "2019-02-05T12:00:00Z"
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"WageSetting : ({string.Join(", ", toStringOutput)})";
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

            return obj is WageSetting other &&
                ((this.TeamMemberId == null && other.TeamMemberId == null) || (this.TeamMemberId?.Equals(other.TeamMemberId) == true)) &&
                ((this.JobAssignments == null && other.JobAssignments == null) || (this.JobAssignments?.Equals(other.JobAssignments) == true)) &&
                ((this.IsOvertimeExempt == null && other.IsOvertimeExempt == null) || (this.IsOvertimeExempt?.Equals(other.IsOvertimeExempt) == true)) &&
                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -742786902;

            if (this.TeamMemberId != null)
            {
               hashCode += this.TeamMemberId.GetHashCode();
            }

            if (this.JobAssignments != null)
            {
               hashCode += this.JobAssignments.GetHashCode();
            }

            if (this.IsOvertimeExempt != null)
            {
               hashCode += this.IsOvertimeExempt.GetHashCode();
            }

            if (this.Version != null)
            {
               hashCode += this.Version.GetHashCode();
            }

            if (this.CreatedAt != null)
            {
               hashCode += this.CreatedAt.GetHashCode();
            }

            if (this.UpdatedAt != null)
            {
               hashCode += this.UpdatedAt.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TeamMemberId = {(this.TeamMemberId == null ? "null" : this.TeamMemberId == string.Empty ? "" : this.TeamMemberId)}");
            toStringOutput.Add($"this.JobAssignments = {(this.JobAssignments == null ? "null" : $"[{string.Join(", ", this.JobAssignments)} ]")}");
            toStringOutput.Add($"this.IsOvertimeExempt = {(this.IsOvertimeExempt == null ? "null" : this.IsOvertimeExempt.ToString())}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMemberId(this.TeamMemberId)
                .JobAssignments(this.JobAssignments)
                .IsOvertimeExempt(this.IsOvertimeExempt)
                .Version(this.Version)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string teamMemberId;
            private IList<Models.JobAssignment> jobAssignments;
            private bool? isOvertimeExempt;
            private int? version;
            private string createdAt;
            private string updatedAt;

             /// <summary>
             /// TeamMemberId.
             /// </summary>
             /// <param name="teamMemberId"> teamMemberId. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberId(string teamMemberId)
            {
                this.teamMemberId = teamMemberId;
                return this;
            }

             /// <summary>
             /// JobAssignments.
             /// </summary>
             /// <param name="jobAssignments"> jobAssignments. </param>
             /// <returns> Builder. </returns>
            public Builder JobAssignments(IList<Models.JobAssignment> jobAssignments)
            {
                this.jobAssignments = jobAssignments;
                return this;
            }

             /// <summary>
             /// IsOvertimeExempt.
             /// </summary>
             /// <param name="isOvertimeExempt"> isOvertimeExempt. </param>
             /// <returns> Builder. </returns>
            public Builder IsOvertimeExempt(bool? isOvertimeExempt)
            {
                this.isOvertimeExempt = isOvertimeExempt;
                return this;
            }

             /// <summary>
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(int? version)
            {
                this.version = version;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> WageSetting. </returns>
            public WageSetting Build()
            {
                return new WageSetting(
                    this.teamMemberId,
                    this.jobAssignments,
                    this.isOvertimeExempt,
                    this.version,
                    this.createdAt,
                    this.updatedAt);
            }
        }
    }
}