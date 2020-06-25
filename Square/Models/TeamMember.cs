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
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// A second ID used to associate the team member with an entity in another system.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// Whether the team member is the owner of the Square account.
        /// </summary>
        [JsonProperty("is_owner")]
        public bool? IsOwner { get; }

        /// <summary>
        /// Enumerates the possible statuses the team member can have within a business.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// The given (i.e., first) name associated with the team member.
        /// </summary>
        [JsonProperty("given_name")]
        public string GivenName { get; }

        /// <summary>
        /// The family (i.e., last) name associated with the team member.
        /// </summary>
        [JsonProperty("family_name")]
        public string FamilyName { get; }

        /// <summary>
        /// The email address associated with the team member.
        /// </summary>
        [JsonProperty("email_address")]
        public string EmailAddress { get; }

        /// <summary>
        /// The team member's phone number in E.164 format. Examples:
        /// +14155552671 - the country code is 1 for US
        /// +551155256325 - the country code is 55 for BR
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; }

        /// <summary>
        /// The timestamp in RFC 3339 format describing when the team member was created.
        /// Ex: "2018-10-04T04:00:00-07:00" or "2019-02-05T12:00:00Z"
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp in RFC 3339 format describing when the team member was last updated.
        /// Ex: "2018-10-04T04:00:00-07:00" or "2019-02-05T12:00:00Z"
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; }

        /// <summary>
        /// An object that represents a team member's assignment to locations.
        /// </summary>
        [JsonProperty("assigned_locations")]
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

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder ReferenceId(string value)
            {
                referenceId = value;
                return this;
            }

            public Builder IsOwner(bool? value)
            {
                isOwner = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder GivenName(string value)
            {
                givenName = value;
                return this;
            }

            public Builder FamilyName(string value)
            {
                familyName = value;
                return this;
            }

            public Builder EmailAddress(string value)
            {
                emailAddress = value;
                return this;
            }

            public Builder PhoneNumber(string value)
            {
                phoneNumber = value;
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

            public Builder AssignedLocations(Models.TeamMemberAssignedLocations value)
            {
                assignedLocations = value;
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