
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
    public class TeamMemberBookingProfile 
    {
        public TeamMemberBookingProfile(string teamMemberId = null,
            string description = null,
            string displayName = null,
            bool? isBookable = null,
            string profileImageUrl = null)
        {
            TeamMemberId = teamMemberId;
            Description = description;
            DisplayName = displayName;
            IsBookable = isBookable;
            ProfileImageUrl = profileImageUrl;
        }

        /// <summary>
        /// The ID of the [TeamMember](#type-TeamMember) object for the team member associated with the booking profile.
        /// </summary>
        [JsonProperty("team_member_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamMemberId { get; }

        /// <summary>
        /// The description of the team member.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; }

        /// <summary>
        /// The display name of the team member.
        /// </summary>
        [JsonProperty("display_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; }

        /// <summary>
        /// Indicates whether the team member can be booked through the Bookings API or the seller's online booking channel or site (`true) or not (`false`).
        /// </summary>
        [JsonProperty("is_bookable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsBookable { get; }

        /// <summary>
        /// The URL of the team member's image for the bookings profile.
        /// </summary>
        [JsonProperty("profile_image_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ProfileImageUrl { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TeamMemberBookingProfile : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"TeamMemberId = {(TeamMemberId == null ? "null" : TeamMemberId == string.Empty ? "" : TeamMemberId)}");
            toStringOutput.Add($"Description = {(Description == null ? "null" : Description == string.Empty ? "" : Description)}");
            toStringOutput.Add($"DisplayName = {(DisplayName == null ? "null" : DisplayName == string.Empty ? "" : DisplayName)}");
            toStringOutput.Add($"IsBookable = {(IsBookable == null ? "null" : IsBookable.ToString())}");
            toStringOutput.Add($"ProfileImageUrl = {(ProfileImageUrl == null ? "null" : ProfileImageUrl == string.Empty ? "" : ProfileImageUrl)}");
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

            return obj is TeamMemberBookingProfile other &&
                ((TeamMemberId == null && other.TeamMemberId == null) || (TeamMemberId?.Equals(other.TeamMemberId) == true)) &&
                ((Description == null && other.Description == null) || (Description?.Equals(other.Description) == true)) &&
                ((DisplayName == null && other.DisplayName == null) || (DisplayName?.Equals(other.DisplayName) == true)) &&
                ((IsBookable == null && other.IsBookable == null) || (IsBookable?.Equals(other.IsBookable) == true)) &&
                ((ProfileImageUrl == null && other.ProfileImageUrl == null) || (ProfileImageUrl?.Equals(other.ProfileImageUrl) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1821243729;

            if (TeamMemberId != null)
            {
               hashCode += TeamMemberId.GetHashCode();
            }

            if (Description != null)
            {
               hashCode += Description.GetHashCode();
            }

            if (DisplayName != null)
            {
               hashCode += DisplayName.GetHashCode();
            }

            if (IsBookable != null)
            {
               hashCode += IsBookable.GetHashCode();
            }

            if (ProfileImageUrl != null)
            {
               hashCode += ProfileImageUrl.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMemberId(TeamMemberId)
                .Description(Description)
                .DisplayName(DisplayName)
                .IsBookable(IsBookable)
                .ProfileImageUrl(ProfileImageUrl);
            return builder;
        }

        public class Builder
        {
            private string teamMemberId;
            private string description;
            private string displayName;
            private bool? isBookable;
            private string profileImageUrl;



            public Builder TeamMemberId(string teamMemberId)
            {
                this.teamMemberId = teamMemberId;
                return this;
            }

            public Builder Description(string description)
            {
                this.description = description;
                return this;
            }

            public Builder DisplayName(string displayName)
            {
                this.displayName = displayName;
                return this;
            }

            public Builder IsBookable(bool? isBookable)
            {
                this.isBookable = isBookable;
                return this;
            }

            public Builder ProfileImageUrl(string profileImageUrl)
            {
                this.profileImageUrl = profileImageUrl;
                return this;
            }

            public TeamMemberBookingProfile Build()
            {
                return new TeamMemberBookingProfile(teamMemberId,
                    description,
                    displayName,
                    isBookable,
                    profileImageUrl);
            }
        }
    }
}