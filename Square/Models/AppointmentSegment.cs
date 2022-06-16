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
    /// AppointmentSegment.
    /// </summary>
    public class AppointmentSegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentSegment"/> class.
        /// </summary>
        /// <param name="teamMemberId">team_member_id.</param>
        /// <param name="durationMinutes">duration_minutes.</param>
        /// <param name="serviceVariationId">service_variation_id.</param>
        /// <param name="serviceVariationVersion">service_variation_version.</param>
        /// <param name="intermissionMinutes">intermission_minutes.</param>
        /// <param name="anyTeamMember">any_team_member.</param>
        /// <param name="resourceIds">resource_ids.</param>
        public AppointmentSegment(
            string teamMemberId,
            int? durationMinutes = null,
            string serviceVariationId = null,
            long? serviceVariationVersion = null,
            int? intermissionMinutes = null,
            bool? anyTeamMember = null,
            IList<string> resourceIds = null)
        {
            this.DurationMinutes = durationMinutes;
            this.ServiceVariationId = serviceVariationId;
            this.TeamMemberId = teamMemberId;
            this.ServiceVariationVersion = serviceVariationVersion;
            this.IntermissionMinutes = intermissionMinutes;
            this.AnyTeamMember = anyTeamMember;
            this.ResourceIds = resourceIds;
        }

        /// <summary>
        /// The time span in minutes of an appointment segment.
        /// </summary>
        [JsonProperty("duration_minutes", NullValueHandling = NullValueHandling.Ignore)]
        public int? DurationMinutes { get; }

        /// <summary>
        /// The ID of the [CatalogItemVariation]($m/CatalogItemVariation) object representing the service booked in this segment.
        /// </summary>
        [JsonProperty("service_variation_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ServiceVariationId { get; }

        /// <summary>
        /// The ID of the [TeamMember]($m/TeamMember) object representing the team member booked in this segment.
        /// </summary>
        [JsonProperty("team_member_id")]
        public string TeamMemberId { get; }

        /// <summary>
        /// The current version of the item variation representing the service booked in this segment.
        /// </summary>
        [JsonProperty("service_variation_version", NullValueHandling = NullValueHandling.Ignore)]
        public long? ServiceVariationVersion { get; }

        /// <summary>
        /// Time between the end of this segment and the beginning of the subsequent segment.
        /// </summary>
        [JsonProperty("intermission_minutes", NullValueHandling = NullValueHandling.Ignore)]
        public int? IntermissionMinutes { get; }

        /// <summary>
        /// Whether the customer accepts any team member, instead of a specific one, to serve this segment.
        /// </summary>
        [JsonProperty("any_team_member", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AnyTeamMember { get; }

        /// <summary>
        /// The IDs of the seller-accessible resources used for this appointment segment.
        /// </summary>
        [JsonProperty("resource_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> ResourceIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AppointmentSegment : ({string.Join(", ", toStringOutput)})";
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

            return obj is AppointmentSegment other &&
                ((this.DurationMinutes == null && other.DurationMinutes == null) || (this.DurationMinutes?.Equals(other.DurationMinutes) == true)) &&
                ((this.ServiceVariationId == null && other.ServiceVariationId == null) || (this.ServiceVariationId?.Equals(other.ServiceVariationId) == true)) &&
                ((this.TeamMemberId == null && other.TeamMemberId == null) || (this.TeamMemberId?.Equals(other.TeamMemberId) == true)) &&
                ((this.ServiceVariationVersion == null && other.ServiceVariationVersion == null) || (this.ServiceVariationVersion?.Equals(other.ServiceVariationVersion) == true)) &&
                ((this.IntermissionMinutes == null && other.IntermissionMinutes == null) || (this.IntermissionMinutes?.Equals(other.IntermissionMinutes) == true)) &&
                ((this.AnyTeamMember == null && other.AnyTeamMember == null) || (this.AnyTeamMember?.Equals(other.AnyTeamMember) == true)) &&
                ((this.ResourceIds == null && other.ResourceIds == null) || (this.ResourceIds?.Equals(other.ResourceIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -489097029;
            hashCode = HashCode.Combine(this.DurationMinutes, this.ServiceVariationId, this.TeamMemberId, this.ServiceVariationVersion, this.IntermissionMinutes, this.AnyTeamMember, this.ResourceIds);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DurationMinutes = {(this.DurationMinutes == null ? "null" : this.DurationMinutes.ToString())}");
            toStringOutput.Add($"this.ServiceVariationId = {(this.ServiceVariationId == null ? "null" : this.ServiceVariationId == string.Empty ? "" : this.ServiceVariationId)}");
            toStringOutput.Add($"this.TeamMemberId = {(this.TeamMemberId == null ? "null" : this.TeamMemberId == string.Empty ? "" : this.TeamMemberId)}");
            toStringOutput.Add($"this.ServiceVariationVersion = {(this.ServiceVariationVersion == null ? "null" : this.ServiceVariationVersion.ToString())}");
            toStringOutput.Add($"this.IntermissionMinutes = {(this.IntermissionMinutes == null ? "null" : this.IntermissionMinutes.ToString())}");
            toStringOutput.Add($"this.AnyTeamMember = {(this.AnyTeamMember == null ? "null" : this.AnyTeamMember.ToString())}");
            toStringOutput.Add($"this.ResourceIds = {(this.ResourceIds == null ? "null" : $"[{string.Join(", ", this.ResourceIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.TeamMemberId)
                .DurationMinutes(this.DurationMinutes)
                .ServiceVariationId(this.ServiceVariationId)
                .ServiceVariationVersion(this.ServiceVariationVersion)
                .IntermissionMinutes(this.IntermissionMinutes)
                .AnyTeamMember(this.AnyTeamMember)
                .ResourceIds(this.ResourceIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string teamMemberId;
            private int? durationMinutes;
            private string serviceVariationId;
            private long? serviceVariationVersion;
            private int? intermissionMinutes;
            private bool? anyTeamMember;
            private IList<string> resourceIds;

            public Builder(
                string teamMemberId)
            {
                this.teamMemberId = teamMemberId;
            }

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
             /// DurationMinutes.
             /// </summary>
             /// <param name="durationMinutes"> durationMinutes. </param>
             /// <returns> Builder. </returns>
            public Builder DurationMinutes(int? durationMinutes)
            {
                this.durationMinutes = durationMinutes;
                return this;
            }

             /// <summary>
             /// ServiceVariationId.
             /// </summary>
             /// <param name="serviceVariationId"> serviceVariationId. </param>
             /// <returns> Builder. </returns>
            public Builder ServiceVariationId(string serviceVariationId)
            {
                this.serviceVariationId = serviceVariationId;
                return this;
            }

             /// <summary>
             /// ServiceVariationVersion.
             /// </summary>
             /// <param name="serviceVariationVersion"> serviceVariationVersion. </param>
             /// <returns> Builder. </returns>
            public Builder ServiceVariationVersion(long? serviceVariationVersion)
            {
                this.serviceVariationVersion = serviceVariationVersion;
                return this;
            }

             /// <summary>
             /// IntermissionMinutes.
             /// </summary>
             /// <param name="intermissionMinutes"> intermissionMinutes. </param>
             /// <returns> Builder. </returns>
            public Builder IntermissionMinutes(int? intermissionMinutes)
            {
                this.intermissionMinutes = intermissionMinutes;
                return this;
            }

             /// <summary>
             /// AnyTeamMember.
             /// </summary>
             /// <param name="anyTeamMember"> anyTeamMember. </param>
             /// <returns> Builder. </returns>
            public Builder AnyTeamMember(bool? anyTeamMember)
            {
                this.anyTeamMember = anyTeamMember;
                return this;
            }

             /// <summary>
             /// ResourceIds.
             /// </summary>
             /// <param name="resourceIds"> resourceIds. </param>
             /// <returns> Builder. </returns>
            public Builder ResourceIds(IList<string> resourceIds)
            {
                this.resourceIds = resourceIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> AppointmentSegment. </returns>
            public AppointmentSegment Build()
            {
                return new AppointmentSegment(
                    this.teamMemberId,
                    this.durationMinutes,
                    this.serviceVariationId,
                    this.serviceVariationVersion,
                    this.intermissionMinutes,
                    this.anyTeamMember,
                    this.resourceIds);
            }
        }
    }
}