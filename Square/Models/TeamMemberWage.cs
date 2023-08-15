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
    /// TeamMemberWage.
    /// </summary>
    public class TeamMemberWage
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamMemberWage"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="teamMemberId">team_member_id.</param>
        /// <param name="title">title.</param>
        /// <param name="hourlyRate">hourly_rate.</param>
        /// <param name="jobId">job_id.</param>
        public TeamMemberWage(
            string id = null,
            string teamMemberId = null,
            string title = null,
            Models.Money hourlyRate = null,
            string jobId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "team_member_id", false },
                { "title", false },
                { "job_id", false }
            };

            this.Id = id;
            if (teamMemberId != null)
            {
                shouldSerialize["team_member_id"] = true;
                this.TeamMemberId = teamMemberId;
            }

            if (title != null)
            {
                shouldSerialize["title"] = true;
                this.Title = title;
            }

            this.HourlyRate = hourlyRate;
            if (jobId != null)
            {
                shouldSerialize["job_id"] = true;
                this.JobId = jobId;
            }

        }
        internal TeamMemberWage(Dictionary<string, bool> shouldSerialize,
            string id = null,
            string teamMemberId = null,
            string title = null,
            Models.Money hourlyRate = null,
            string jobId = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            TeamMemberId = teamMemberId;
            Title = title;
            HourlyRate = hourlyRate;
            JobId = jobId;
        }

        /// <summary>
        /// The UUID for this object.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The `TeamMember` that this wage is assigned to.
        /// </summary>
        [JsonProperty("team_member_id")]
        public string TeamMemberId { get; }

        /// <summary>
        /// The job title that this wage relates to.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("hourly_rate", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money HourlyRate { get; }

        /// <summary>
        /// An identifier for the job that this wage relates to. This cannot be
        /// used to retrieve the job.
        /// </summary>
        [JsonProperty("job_id")]
        public string JobId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TeamMemberWage : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTeamMemberId()
        {
            return this.shouldSerialize["team_member_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTitle()
        {
            return this.shouldSerialize["title"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeJobId()
        {
            return this.shouldSerialize["job_id"];
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
            return obj is TeamMemberWage other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.TeamMemberId == null && other.TeamMemberId == null) || (this.TeamMemberId?.Equals(other.TeamMemberId) == true)) &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.HourlyRate == null && other.HourlyRate == null) || (this.HourlyRate?.Equals(other.HourlyRate) == true)) &&
                ((this.JobId == null && other.JobId == null) || (this.JobId?.Equals(other.JobId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1846697817;
            hashCode = HashCode.Combine(this.Id, this.TeamMemberId, this.Title, this.HourlyRate, this.JobId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.TeamMemberId = {(this.TeamMemberId == null ? "null" : this.TeamMemberId)}");
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
            toStringOutput.Add($"this.HourlyRate = {(this.HourlyRate == null ? "null" : this.HourlyRate.ToString())}");
            toStringOutput.Add($"this.JobId = {(this.JobId == null ? "null" : this.JobId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .TeamMemberId(this.TeamMemberId)
                .Title(this.Title)
                .HourlyRate(this.HourlyRate)
                .JobId(this.JobId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "team_member_id", false },
                { "title", false },
                { "job_id", false },
            };

            private string id;
            private string teamMemberId;
            private string title;
            private Models.Money hourlyRate;
            private string jobId;

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// TeamMemberId.
             /// </summary>
             /// <param name="teamMemberId"> teamMemberId. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberId(string teamMemberId)
            {
                shouldSerialize["team_member_id"] = true;
                this.teamMemberId = teamMemberId;
                return this;
            }

             /// <summary>
             /// Title.
             /// </summary>
             /// <param name="title"> title. </param>
             /// <returns> Builder. </returns>
            public Builder Title(string title)
            {
                shouldSerialize["title"] = true;
                this.title = title;
                return this;
            }

             /// <summary>
             /// HourlyRate.
             /// </summary>
             /// <param name="hourlyRate"> hourlyRate. </param>
             /// <returns> Builder. </returns>
            public Builder HourlyRate(Models.Money hourlyRate)
            {
                this.hourlyRate = hourlyRate;
                return this;
            }

             /// <summary>
             /// JobId.
             /// </summary>
             /// <param name="jobId"> jobId. </param>
             /// <returns> Builder. </returns>
            public Builder JobId(string jobId)
            {
                shouldSerialize["job_id"] = true;
                this.jobId = jobId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTeamMemberId()
            {
                this.shouldSerialize["team_member_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTitle()
            {
                this.shouldSerialize["title"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetJobId()
            {
                this.shouldSerialize["job_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TeamMemberWage. </returns>
            public TeamMemberWage Build()
            {
                return new TeamMemberWage(shouldSerialize,
                    this.id,
                    this.teamMemberId,
                    this.title,
                    this.hourlyRate,
                    this.jobId);
            }
        }
    }
}