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
    /// BookingCreatorDetails.
    /// </summary>
    public class BookingCreatorDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingCreatorDetails"/> class.
        /// </summary>
        /// <param name="creatorType">creator_type.</param>
        /// <param name="teamMemberId">team_member_id.</param>
        /// <param name="customerId">customer_id.</param>
        public BookingCreatorDetails(
            string creatorType = null,
            string teamMemberId = null,
            string customerId = null)
        {
            this.CreatorType = creatorType;
            this.TeamMemberId = teamMemberId;
            this.CustomerId = customerId;
        }

        /// <summary>
        /// Supported types of a booking creator.
        /// </summary>
        [JsonProperty("creator_type", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatorType { get; }

        /// <summary>
        /// The ID of the team member who created the booking, when the booking creator is of the `TEAM_MEMBER` type.
        /// Access to this field requires seller-level permissions.
        /// </summary>
        [JsonProperty("team_member_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamMemberId { get; }

        /// <summary>
        /// The ID of the customer who created the booking, when the booking creator is of the `CUSTOMER` type.
        /// Access to this field requires seller-level permissions.
        /// </summary>
        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BookingCreatorDetails : ({string.Join(", ", toStringOutput)})";
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

            return obj is BookingCreatorDetails other &&
                ((this.CreatorType == null && other.CreatorType == null) || (this.CreatorType?.Equals(other.CreatorType) == true)) &&
                ((this.TeamMemberId == null && other.TeamMemberId == null) || (this.TeamMemberId?.Equals(other.TeamMemberId) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -829674343;
            hashCode = HashCode.Combine(this.CreatorType, this.TeamMemberId, this.CustomerId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CreatorType = {(this.CreatorType == null ? "null" : this.CreatorType.ToString())}");
            toStringOutput.Add($"this.TeamMemberId = {(this.TeamMemberId == null ? "null" : this.TeamMemberId == string.Empty ? "" : this.TeamMemberId)}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId == string.Empty ? "" : this.CustomerId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CreatorType(this.CreatorType)
                .TeamMemberId(this.TeamMemberId)
                .CustomerId(this.CustomerId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string creatorType;
            private string teamMemberId;
            private string customerId;

             /// <summary>
             /// CreatorType.
             /// </summary>
             /// <param name="creatorType"> creatorType. </param>
             /// <returns> Builder. </returns>
            public Builder CreatorType(string creatorType)
            {
                this.creatorType = creatorType;
                return this;
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
             /// CustomerId.
             /// </summary>
             /// <param name="customerId"> customerId. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerId(string customerId)
            {
                this.customerId = customerId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BookingCreatorDetails. </returns>
            public BookingCreatorDetails Build()
            {
                return new BookingCreatorDetails(
                    this.creatorType,
                    this.teamMemberId,
                    this.customerId);
            }
        }
    }
}