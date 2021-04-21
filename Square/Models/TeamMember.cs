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
    /// TeamMember.
    /// </summary>
    public class TeamMember
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamMember"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="isOwner">is_owner.</param>
        /// <param name="status">status.</param>
        /// <param name="givenName">given_name.</param>
        /// <param name="familyName">family_name.</param>
        /// <param name="emailAddress">email_address.</param>
        /// <param name="phoneNumber">phone_number.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="assignedLocations">assigned_locations.</param>
        public TeamMember(
            string id = null,
            string referenceId = null,
            bool? isOwner = null,
            string status = null,
            string givenName = null,
            string familyName = null,
            string emailAddress = null,
            string phoneNumber = null,
            string createdAt = null,
            string updatedAt = null,
            Models.TeamMemberAssignedLocations assignedLocations = null)
        {
            this.Id = id;
            this.ReferenceId = referenceId;
            this.IsOwner = isOwner;
            this.Status = status;
            this.GivenName = givenName;
            this.FamilyName = familyName;
            this.EmailAddress = emailAddress;
            this.PhoneNumber = phoneNumber;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.AssignedLocations = assignedLocations;
        }

        /// <summary>
        /// The unique ID for the team member.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// A second ID used to associate the team member with an entity in another system.
        /// </summary>
        [JsonProperty("reference_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceId { get; }

        /// <summary>
        /// Whether the team member is the owner of the Square account.
        /// </summary>
        [JsonProperty("is_owner", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsOwner { get; }

        /// <summary>
        /// Enumerates the possible statuses the team member can have within a business.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// The given (i.e., first) name associated with the team member.
        /// </summary>
        [JsonProperty("given_name", NullValueHandling = NullValueHandling.Ignore)]
        public string GivenName { get; }

        /// <summary>
        /// The family (i.e., last) name associated with the team member.
        /// </summary>
        [JsonProperty("family_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FamilyName { get; }

        /// <summary>
        /// The email address associated with the team member.
        /// </summary>
        [JsonProperty("email_address", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; }

        /// <summary>
        /// The team member's phone number in E.164 format. Examples:
        /// +14155552671 - the country code is 1 for US
        /// +551155256325 - the country code is 55 for BR
        /// </summary>
        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; }

        /// <summary>
        /// The timestamp in RFC 3339 format describing when the team member was created.
        /// Ex: "2018-10-04T04:00:00-07:00" or "2019-02-05T12:00:00Z"
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp in RFC 3339 format describing when the team member was last updated.
        /// Ex: "2018-10-04T04:00:00-07:00" or "2019-02-05T12:00:00Z"
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// An object that represents a team member's assignment to locations.
        /// </summary>
        [JsonProperty("assigned_locations", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TeamMemberAssignedLocations AssignedLocations { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TeamMember : ({string.Join(", ", toStringOutput)})";
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

            return obj is TeamMember other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((this.IsOwner == null && other.IsOwner == null) || (this.IsOwner?.Equals(other.IsOwner) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.GivenName == null && other.GivenName == null) || (this.GivenName?.Equals(other.GivenName) == true)) &&
                ((this.FamilyName == null && other.FamilyName == null) || (this.FamilyName?.Equals(other.FamilyName) == true)) &&
                ((this.EmailAddress == null && other.EmailAddress == null) || (this.EmailAddress?.Equals(other.EmailAddress) == true)) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.AssignedLocations == null && other.AssignedLocations == null) || (this.AssignedLocations?.Equals(other.AssignedLocations) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1084182002;

            if (this.Id != null)
            {
               hashCode += this.Id.GetHashCode();
            }

            if (this.ReferenceId != null)
            {
               hashCode += this.ReferenceId.GetHashCode();
            }

            if (this.IsOwner != null)
            {
               hashCode += this.IsOwner.GetHashCode();
            }

            if (this.Status != null)
            {
               hashCode += this.Status.GetHashCode();
            }

            if (this.GivenName != null)
            {
               hashCode += this.GivenName.GetHashCode();
            }

            if (this.FamilyName != null)
            {
               hashCode += this.FamilyName.GetHashCode();
            }

            if (this.EmailAddress != null)
            {
               hashCode += this.EmailAddress.GetHashCode();
            }

            if (this.PhoneNumber != null)
            {
               hashCode += this.PhoneNumber.GetHashCode();
            }

            if (this.CreatedAt != null)
            {
               hashCode += this.CreatedAt.GetHashCode();
            }

            if (this.UpdatedAt != null)
            {
               hashCode += this.UpdatedAt.GetHashCode();
            }

            if (this.AssignedLocations != null)
            {
               hashCode += this.AssignedLocations.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId == string.Empty ? "" : this.ReferenceId)}");
            toStringOutput.Add($"this.IsOwner = {(this.IsOwner == null ? "null" : this.IsOwner.ToString())}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.GivenName = {(this.GivenName == null ? "null" : this.GivenName == string.Empty ? "" : this.GivenName)}");
            toStringOutput.Add($"this.FamilyName = {(this.FamilyName == null ? "null" : this.FamilyName == string.Empty ? "" : this.FamilyName)}");
            toStringOutput.Add($"this.EmailAddress = {(this.EmailAddress == null ? "null" : this.EmailAddress == string.Empty ? "" : this.EmailAddress)}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber == string.Empty ? "" : this.PhoneNumber)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
            toStringOutput.Add($"this.AssignedLocations = {(this.AssignedLocations == null ? "null" : this.AssignedLocations.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .ReferenceId(this.ReferenceId)
                .IsOwner(this.IsOwner)
                .Status(this.Status)
                .GivenName(this.GivenName)
                .FamilyName(this.FamilyName)
                .EmailAddress(this.EmailAddress)
                .PhoneNumber(this.PhoneNumber)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .AssignedLocations(this.AssignedLocations);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string id;
            private string referenceId;
            private bool? isOwner;
            private string status;
            private string givenName;
            private string familyName;
            private string emailAddress;
            private string phoneNumber;
            private string createdAt;
            private string updatedAt;
            private Models.TeamMemberAssignedLocations assignedLocations;

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
             /// ReferenceId.
             /// </summary>
             /// <param name="referenceId"> referenceId. </param>
             /// <returns> Builder. </returns>
            public Builder ReferenceId(string referenceId)
            {
                this.referenceId = referenceId;
                return this;
            }

             /// <summary>
             /// IsOwner.
             /// </summary>
             /// <param name="isOwner"> isOwner. </param>
             /// <returns> Builder. </returns>
            public Builder IsOwner(bool? isOwner)
            {
                this.isOwner = isOwner;
                return this;
            }

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

             /// <summary>
             /// GivenName.
             /// </summary>
             /// <param name="givenName"> givenName. </param>
             /// <returns> Builder. </returns>
            public Builder GivenName(string givenName)
            {
                this.givenName = givenName;
                return this;
            }

             /// <summary>
             /// FamilyName.
             /// </summary>
             /// <param name="familyName"> familyName. </param>
             /// <returns> Builder. </returns>
            public Builder FamilyName(string familyName)
            {
                this.familyName = familyName;
                return this;
            }

             /// <summary>
             /// EmailAddress.
             /// </summary>
             /// <param name="emailAddress"> emailAddress. </param>
             /// <returns> Builder. </returns>
            public Builder EmailAddress(string emailAddress)
            {
                this.emailAddress = emailAddress;
                return this;
            }

             /// <summary>
             /// PhoneNumber.
             /// </summary>
             /// <param name="phoneNumber"> phoneNumber. </param>
             /// <returns> Builder. </returns>
            public Builder PhoneNumber(string phoneNumber)
            {
                this.phoneNumber = phoneNumber;
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
             /// AssignedLocations.
             /// </summary>
             /// <param name="assignedLocations"> assignedLocations. </param>
             /// <returns> Builder. </returns>
            public Builder AssignedLocations(Models.TeamMemberAssignedLocations assignedLocations)
            {
                this.assignedLocations = assignedLocations;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TeamMember. </returns>
            public TeamMember Build()
            {
                return new TeamMember(
                    this.id,
                    this.referenceId,
                    this.isOwner,
                    this.status,
                    this.givenName,
                    this.familyName,
                    this.emailAddress,
                    this.phoneNumber,
                    this.createdAt,
                    this.updatedAt,
                    this.assignedLocations);
            }
        }
    }
}