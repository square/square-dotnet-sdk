
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
    public class AppointmentSegment 
    {
        public AppointmentSegment(int durationMinutes,
            string serviceVariationId,
            string teamMemberId,
            long serviceVariationVersion)
        {
            DurationMinutes = durationMinutes;
            ServiceVariationId = serviceVariationId;
            TeamMemberId = teamMemberId;
            ServiceVariationVersion = serviceVariationVersion;
        }

        /// <summary>
        /// The time span in minutes of an appointment segment.
        /// </summary>
        [JsonProperty("duration_minutes")]
        public int DurationMinutes { get; }

        /// <summary>
        /// The ID of the [CatalogItemVariation](#type-CatalogItemVariation) object representing the service booked in this segment.
        /// </summary>
        [JsonProperty("service_variation_id")]
        public string ServiceVariationId { get; }

        /// <summary>
        /// The ID of the [TeamMember](#type-TeamMember) object representing the team member booked in this segment.
        /// </summary>
        [JsonProperty("team_member_id")]
        public string TeamMemberId { get; }

        /// <summary>
        /// The current version of the item variation representing the service booked in this segment.
        /// </summary>
        [JsonProperty("service_variation_version")]
        public long ServiceVariationVersion { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AppointmentSegment : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"DurationMinutes = {DurationMinutes}");
            toStringOutput.Add($"ServiceVariationId = {(ServiceVariationId == null ? "null" : ServiceVariationId == string.Empty ? "" : ServiceVariationId)}");
            toStringOutput.Add($"TeamMemberId = {(TeamMemberId == null ? "null" : TeamMemberId == string.Empty ? "" : TeamMemberId)}");
            toStringOutput.Add($"ServiceVariationVersion = {ServiceVariationVersion}");
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

            return obj is AppointmentSegment other &&
                DurationMinutes.Equals(other.DurationMinutes) &&
                ((ServiceVariationId == null && other.ServiceVariationId == null) || (ServiceVariationId?.Equals(other.ServiceVariationId) == true)) &&
                ((TeamMemberId == null && other.TeamMemberId == null) || (TeamMemberId?.Equals(other.TeamMemberId) == true)) &&
                ServiceVariationVersion.Equals(other.ServiceVariationVersion);
        }

        public override int GetHashCode()
        {
            int hashCode = -1009100920;
            hashCode += DurationMinutes.GetHashCode();

            if (ServiceVariationId != null)
            {
               hashCode += ServiceVariationId.GetHashCode();
            }

            if (TeamMemberId != null)
            {
               hashCode += TeamMemberId.GetHashCode();
            }
            hashCode += ServiceVariationVersion.GetHashCode();

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(DurationMinutes,
                ServiceVariationId,
                TeamMemberId,
                ServiceVariationVersion);
            return builder;
        }

        public class Builder
        {
            private int durationMinutes;
            private string serviceVariationId;
            private string teamMemberId;
            private long serviceVariationVersion;

            public Builder(int durationMinutes,
                string serviceVariationId,
                string teamMemberId,
                long serviceVariationVersion)
            {
                this.durationMinutes = durationMinutes;
                this.serviceVariationId = serviceVariationId;
                this.teamMemberId = teamMemberId;
                this.serviceVariationVersion = serviceVariationVersion;
            }

            public Builder DurationMinutes(int durationMinutes)
            {
                this.durationMinutes = durationMinutes;
                return this;
            }

            public Builder ServiceVariationId(string serviceVariationId)
            {
                this.serviceVariationId = serviceVariationId;
                return this;
            }

            public Builder TeamMemberId(string teamMemberId)
            {
                this.teamMemberId = teamMemberId;
                return this;
            }

            public Builder ServiceVariationVersion(long serviceVariationVersion)
            {
                this.serviceVariationVersion = serviceVariationVersion;
                return this;
            }

            public AppointmentSegment Build()
            {
                return new AppointmentSegment(durationMinutes,
                    serviceVariationId,
                    teamMemberId,
                    serviceVariationVersion);
            }
        }
    }
}