
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
    public class TeamMember 
    {
        public TeamMember(string id = null,
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
            Id = id;
            ReferenceId = referenceId;
            IsOwner = isOwner;
            Status = status;
            GivenName = givenName;
            FamilyName = familyName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            AssignedLocations = assignedLocations;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TeamMember : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"ReferenceId = {(ReferenceId == null ? "null" : ReferenceId == string.Empty ? "" : ReferenceId)}");
            toStringOutput.Add($"IsOwner = {(IsOwner == null ? "null" : IsOwner.ToString())}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status.ToString())}");
            toStringOutput.Add($"GivenName = {(GivenName == null ? "null" : GivenName == string.Empty ? "" : GivenName)}");
            toStringOutput.Add($"FamilyName = {(FamilyName == null ? "null" : FamilyName == string.Empty ? "" : FamilyName)}");
            toStringOutput.Add($"EmailAddress = {(EmailAddress == null ? "null" : EmailAddress == string.Empty ? "" : EmailAddress)}");
            toStringOutput.Add($"PhoneNumber = {(PhoneNumber == null ? "null" : PhoneNumber == string.Empty ? "" : PhoneNumber)}");
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
            toStringOutput.Add($"UpdatedAt = {(UpdatedAt == null ? "null" : UpdatedAt == string.Empty ? "" : UpdatedAt)}");
            toStringOutput.Add($"AssignedLocations = {(AssignedLocations == null ? "null" : AssignedLocations.ToString())}");
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

            return obj is TeamMember other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((ReferenceId == null && other.ReferenceId == null) || (ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((IsOwner == null && other.IsOwner == null) || (IsOwner?.Equals(other.IsOwner) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true)) &&
                ((GivenName == null && other.GivenName == null) || (GivenName?.Equals(other.GivenName) == true)) &&
                ((FamilyName == null && other.FamilyName == null) || (FamilyName?.Equals(other.FamilyName) == true)) &&
                ((EmailAddress == null && other.EmailAddress == null) || (EmailAddress?.Equals(other.EmailAddress) == true)) &&
                ((PhoneNumber == null && other.PhoneNumber == null) || (PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((UpdatedAt == null && other.UpdatedAt == null) || (UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((AssignedLocations == null && other.AssignedLocations == null) || (AssignedLocations?.Equals(other.AssignedLocations) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1084182002;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (ReferenceId != null)
            {
               hashCode += ReferenceId.GetHashCode();
            }

            if (IsOwner != null)
            {
               hashCode += IsOwner.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }

            if (GivenName != null)
            {
               hashCode += GivenName.GetHashCode();
            }

            if (FamilyName != null)
            {
               hashCode += FamilyName.GetHashCode();
            }

            if (EmailAddress != null)
            {
               hashCode += EmailAddress.GetHashCode();
            }

            if (PhoneNumber != null)
            {
               hashCode += PhoneNumber.GetHashCode();
            }

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            if (UpdatedAt != null)
            {
               hashCode += UpdatedAt.GetHashCode();
            }

            if (AssignedLocations != null)
            {
               hashCode += AssignedLocations.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .ReferenceId(ReferenceId)
                .IsOwner(IsOwner)
                .Status(Status)
                .GivenName(GivenName)
                .FamilyName(FamilyName)
                .EmailAddress(EmailAddress)
                .PhoneNumber(PhoneNumber)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt)
                .AssignedLocations(AssignedLocations);
            return builder;
        }

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



            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder ReferenceId(string referenceId)
            {
                this.referenceId = referenceId;
                return this;
            }

            public Builder IsOwner(bool? isOwner)
            {
                this.isOwner = isOwner;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public Builder GivenName(string givenName)
            {
                this.givenName = givenName;
                return this;
            }

            public Builder FamilyName(string familyName)
            {
                this.familyName = familyName;
                return this;
            }

            public Builder EmailAddress(string emailAddress)
            {
                this.emailAddress = emailAddress;
                return this;
            }

            public Builder PhoneNumber(string phoneNumber)
            {
                this.phoneNumber = phoneNumber;
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

            public Builder AssignedLocations(Models.TeamMemberAssignedLocations assignedLocations)
            {
                this.assignedLocations = assignedLocations;
                return this;
            }

            public TeamMember Build()
            {
                return new TeamMember(id,
                    referenceId,
                    isOwner,
                    status,
                    givenName,
                    familyName,
                    emailAddress,
                    phoneNumber,
                    createdAt,
                    updatedAt,
                    assignedLocations);
            }
        }
    }
}