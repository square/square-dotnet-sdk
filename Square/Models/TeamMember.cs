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