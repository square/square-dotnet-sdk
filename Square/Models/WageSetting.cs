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
        [JsonProperty("team_member_id")]
        public string TeamMemberId { get; }

        /// <summary>
        /// <b>Required</b> The ordered list of jobs that the team member is assigned to.
        /// The first job assignment is considered the team member's "Primary Job".
        /// <br>
        /// <b>Min Length 1    Max Length 12</b>
        /// </summary>
        [JsonProperty("job_assignments")]
        public IList<Models.JobAssignment> JobAssignments { get; }

        /// <summary>
        /// Whether the team member is exempt from the overtime rules of the seller country.
        /// </summary>
        [JsonProperty("is_overtime_exempt")]
        public bool? IsOvertimeExempt { get; }

        /// <summary>
        /// Used for resolving concurrency issues; request will fail if version
        /// provided does not match server version at time of request. If not provided,
        /// Square executes a blind write, potentially overwriting data from another write. Read
        /// about [optimistic concurrency](https://developer.squareup.com/docs/docs/working-with-apis/optimistic-concurrency)
        /// in Square APIs for more information.
        /// </summary>
        [JsonProperty("version")]
        public int? Version { get; }

        /// <summary>
        /// The timestamp in RFC 3339 format describing when the wage setting object was created.
        /// Ex: "2018-10-04T04:00:00-07:00" or "2019-02-05T12:00:00Z"
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp in RFC 3339 format describing when the wage setting object was last updated.
        /// Ex: "2018-10-04T04:00:00-07:00" or "2019-02-05T12:00:00Z"
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; }

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
            private IList<Models.JobAssignment> jobAssignments = new List<Models.JobAssignment>();
            private bool? isOvertimeExempt;
            private int? version;
            private string createdAt;
            private string updatedAt;

            public Builder() { }
            public Builder TeamMemberId(string value)
            {
                teamMemberId = value;
                return this;
            }

            public Builder JobAssignments(IList<Models.JobAssignment> value)
            {
                jobAssignments = value;
                return this;
            }

            public Builder IsOvertimeExempt(bool? value)
            {
                isOvertimeExempt = value;
                return this;
            }

            public Builder Version(int? value)
            {
                version = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public Builder UpdatedAt(string value)
            {
                updatedAt = value;
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