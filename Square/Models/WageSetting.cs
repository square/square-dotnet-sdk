
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
    public class WageSetting 
    {
        public WageSetting(string teamMemberId = null,
            IList<Models.JobAssignment> jobAssignments = null,
            bool? isOvertimeExempt = null,
            int? version = null,
            string createdAt = null,
            string updatedAt = null)
        {
            TeamMemberId = teamMemberId;
            JobAssignments = jobAssignments;
            IsOvertimeExempt = isOvertimeExempt;
            Version = version;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"WageSetting : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"TeamMemberId = {(TeamMemberId == null ? "null" : TeamMemberId == string.Empty ? "" : TeamMemberId)}");
            toStringOutput.Add($"JobAssignments = {(JobAssignments == null ? "null" : $"[{ string.Join(", ", JobAssignments)} ]")}");
            toStringOutput.Add($"IsOvertimeExempt = {(IsOvertimeExempt == null ? "null" : IsOvertimeExempt.ToString())}");
            toStringOutput.Add($"Version = {(Version == null ? "null" : Version.ToString())}");
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
            toStringOutput.Add($"UpdatedAt = {(UpdatedAt == null ? "null" : UpdatedAt == string.Empty ? "" : UpdatedAt)}");
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

            return obj is WageSetting other &&
                ((TeamMemberId == null && other.TeamMemberId == null) || (TeamMemberId?.Equals(other.TeamMemberId) == true)) &&
                ((JobAssignments == null && other.JobAssignments == null) || (JobAssignments?.Equals(other.JobAssignments) == true)) &&
                ((IsOvertimeExempt == null && other.IsOvertimeExempt == null) || (IsOvertimeExempt?.Equals(other.IsOvertimeExempt) == true)) &&
                ((Version == null && other.Version == null) || (Version?.Equals(other.Version) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((UpdatedAt == null && other.UpdatedAt == null) || (UpdatedAt?.Equals(other.UpdatedAt) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -742786902;

            if (TeamMemberId != null)
            {
               hashCode += TeamMemberId.GetHashCode();
            }

            if (JobAssignments != null)
            {
               hashCode += JobAssignments.GetHashCode();
            }

            if (IsOvertimeExempt != null)
            {
               hashCode += IsOvertimeExempt.GetHashCode();
            }

            if (Version != null)
            {
               hashCode += Version.GetHashCode();
            }

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            if (UpdatedAt != null)
            {
               hashCode += UpdatedAt.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMemberId(TeamMemberId)
                .JobAssignments(JobAssignments)
                .IsOvertimeExempt(IsOvertimeExempt)
                .Version(Version)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt);
            return builder;
        }

        public class Builder
        {
            private string teamMemberId;
            private IList<Models.JobAssignment> jobAssignments;
            private bool? isOvertimeExempt;
            private int? version;
            private string createdAt;
            private string updatedAt;



            public Builder TeamMemberId(string teamMemberId)
            {
                this.teamMemberId = teamMemberId;
                return this;
            }

            public Builder JobAssignments(IList<Models.JobAssignment> jobAssignments)
            {
                this.jobAssignments = jobAssignments;
                return this;
            }

            public Builder IsOvertimeExempt(bool? isOvertimeExempt)
            {
                this.isOvertimeExempt = isOvertimeExempt;
                return this;
            }

            public Builder Version(int? version)
            {
                this.version = version;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            public WageSetting Build()
            {
                return new WageSetting(teamMemberId,
                    jobAssignments,
                    isOvertimeExempt,
                    version,
                    createdAt,
                    updatedAt);
            }
        }
    }
}