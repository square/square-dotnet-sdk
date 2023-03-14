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
    /// TeamMemberBookingProfile.
    /// </summary>
    public class TeamMemberBookingProfile
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamMemberBookingProfile"/> class.
        /// </summary>
        /// <param name="teamMemberId">team_member_id.</param>
        /// <param name="description">description.</param>
        /// <param name="displayName">display_name.</param>
        /// <param name="isBookable">is_bookable.</param>
        /// <param name="profileImageUrl">profile_image_url.</param>
        public TeamMemberBookingProfile(
            string teamMemberId = null,
            string description = null,
            string displayName = null,
            bool? isBookable = null,
            string profileImageUrl = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "is_bookable", false }
            };

            this.TeamMemberId = teamMemberId;
            this.Description = description;
            this.DisplayName = displayName;
            if (isBookable != null)
            {
                shouldSerialize["is_bookable"] = true;
                this.IsBookable = isBookable;
            }

            this.ProfileImageUrl = profileImageUrl;
        }
        internal TeamMemberBookingProfile(Dictionary<string, bool> shouldSerialize,
            string teamMemberId = null,
            string description = null,
            string displayName = null,
            bool? isBookable = null,
            string profileImageUrl = null)
        {
            this.shouldSerialize = shouldSerialize;
            TeamMemberId = teamMemberId;
            Description = description;
            DisplayName = displayName;
            IsBookable = isBookable;
            ProfileImageUrl = profileImageUrl;
        }

        /// <summary>
        /// The ID of the [TeamMember]($m/TeamMember) object for the team member associated with the booking profile.
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
        [JsonProperty("is_bookable")]
        public bool? IsBookable { get; }

        /// <summary>
        /// The URL of the team member's image for the bookings profile.
        /// </summary>
        [JsonProperty("profile_image_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ProfileImageUrl { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TeamMemberBookingProfile : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIsBookable()
        {
            return this.shouldSerialize["is_bookable"];
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

            return obj is TeamMemberBookingProfile other &&
                ((this.TeamMemberId == null && other.TeamMemberId == null) || (this.TeamMemberId?.Equals(other.TeamMemberId) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.DisplayName == null && other.DisplayName == null) || (this.DisplayName?.Equals(other.DisplayName) == true)) &&
                ((this.IsBookable == null && other.IsBookable == null) || (this.IsBookable?.Equals(other.IsBookable) == true)) &&
                ((this.ProfileImageUrl == null && other.ProfileImageUrl == null) || (this.ProfileImageUrl?.Equals(other.ProfileImageUrl) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1821243729;
            hashCode = HashCode.Combine(this.TeamMemberId, this.Description, this.DisplayName, this.IsBookable, this.ProfileImageUrl);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TeamMemberId = {(this.TeamMemberId == null ? "null" : this.TeamMemberId == string.Empty ? "" : this.TeamMemberId)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.DisplayName = {(this.DisplayName == null ? "null" : this.DisplayName == string.Empty ? "" : this.DisplayName)}");
            toStringOutput.Add($"this.IsBookable = {(this.IsBookable == null ? "null" : this.IsBookable.ToString())}");
            toStringOutput.Add($"this.ProfileImageUrl = {(this.ProfileImageUrl == null ? "null" : this.ProfileImageUrl == string.Empty ? "" : this.ProfileImageUrl)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMemberId(this.TeamMemberId)
                .Description(this.Description)
                .DisplayName(this.DisplayName)
                .IsBookable(this.IsBookable)
                .ProfileImageUrl(this.ProfileImageUrl);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "is_bookable", false },
            };

            private string teamMemberId;
            private string description;
            private string displayName;
            private bool? isBookable;
            private string profileImageUrl;

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
             /// Description.
             /// </summary>
             /// <param name="description"> description. </param>
             /// <returns> Builder. </returns>
            public Builder Description(string description)
            {
                this.description = description;
                return this;
            }

             /// <summary>
             /// DisplayName.
             /// </summary>
             /// <param name="displayName"> displayName. </param>
             /// <returns> Builder. </returns>
            public Builder DisplayName(string displayName)
            {
                this.displayName = displayName;
                return this;
            }

             /// <summary>
             /// IsBookable.
             /// </summary>
             /// <param name="isBookable"> isBookable. </param>
             /// <returns> Builder. </returns>
            public Builder IsBookable(bool? isBookable)
            {
                shouldSerialize["is_bookable"] = true;
                this.isBookable = isBookable;
                return this;
            }

             /// <summary>
             /// ProfileImageUrl.
             /// </summary>
             /// <param name="profileImageUrl"> profileImageUrl. </param>
             /// <returns> Builder. </returns>
            public Builder ProfileImageUrl(string profileImageUrl)
            {
                this.profileImageUrl = profileImageUrl;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIsBookable()
            {
                this.shouldSerialize["is_bookable"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TeamMemberBookingProfile. </returns>
            public TeamMemberBookingProfile Build()
            {
                return new TeamMemberBookingProfile(shouldSerialize,
                    this.teamMemberId,
                    this.description,
                    this.displayName,
                    this.isBookable,
                    this.profileImageUrl);
            }
        }
    }
}