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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// TeamMember.
    /// </summary>
    public class TeamMember
    {
        private readonly Dictionary<string, bool> shouldSerialize;

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
        /// <param name="wageSetting">wage_setting.</param>
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
            Models.TeamMemberAssignedLocations assignedLocations = null,
            Models.WageSetting wageSetting = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "reference_id", false },
                { "given_name", false },
                { "family_name", false },
                { "email_address", false },
                { "phone_number", false },
            };
            this.Id = id;

            if (referenceId != null)
            {
                shouldSerialize["reference_id"] = true;
                this.ReferenceId = referenceId;
            }
            this.IsOwner = isOwner;
            this.Status = status;

            if (givenName != null)
            {
                shouldSerialize["given_name"] = true;
                this.GivenName = givenName;
            }

            if (familyName != null)
            {
                shouldSerialize["family_name"] = true;
                this.FamilyName = familyName;
            }

            if (emailAddress != null)
            {
                shouldSerialize["email_address"] = true;
                this.EmailAddress = emailAddress;
            }

            if (phoneNumber != null)
            {
                shouldSerialize["phone_number"] = true;
                this.PhoneNumber = phoneNumber;
            }
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.AssignedLocations = assignedLocations;
            this.WageSetting = wageSetting;
        }

        internal TeamMember(
            Dictionary<string, bool> shouldSerialize,
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
            Models.TeamMemberAssignedLocations assignedLocations = null,
            Models.WageSetting wageSetting = null
        )
        {
            this.shouldSerialize = shouldSerialize;
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
            WageSetting = wageSetting;
        }

        /// <summary>
        /// The unique ID for the team member.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// A second ID used to associate the team member with an entity in another system.
        /// </summary>
        [JsonProperty("reference_id")]
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
        /// The given name (that is, the first name) associated with the team member.
        /// </summary>
        [JsonProperty("given_name")]
        public string GivenName { get; }

        /// <summary>
        /// The family name (that is, the last name) associated with the team member.
        /// </summary>
        [JsonProperty("family_name")]
        public string FamilyName { get; }

        /// <summary>
        /// The email address associated with the team member. After accepting the invitation
        /// from Square, only the team member can change this value.
        /// </summary>
        [JsonProperty("email_address")]
        public string EmailAddress { get; }

        /// <summary>
        /// The team member's phone number, in E.164 format. For example:
        /// +14155552671 - the country code is 1 for US
        /// +551155256325 - the country code is 55 for BR
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; }

        /// <summary>
        /// The timestamp when the team member was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the team member was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// An object that represents a team member's assignment to locations.
        /// </summary>
        [JsonProperty("assigned_locations", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TeamMemberAssignedLocations AssignedLocations { get; }

        /// <summary>
        /// Represents information about the overtime exemption status, job assignments, and compensation
        /// for a [team member]($m/TeamMember).
        /// </summary>
        [JsonProperty("wage_setting", NullValueHandling = NullValueHandling.Ignore)]
        public Models.WageSetting WageSetting { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"TeamMember : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReferenceId()
        {
            return this.shouldSerialize["reference_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeGivenName()
        {
            return this.shouldSerialize["given_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFamilyName()
        {
            return this.shouldSerialize["family_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmailAddress()
        {
            return this.shouldSerialize["email_address"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePhoneNumber()
        {
            return this.shouldSerialize["phone_number"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is TeamMember other
                && (this.Id == null && other.Id == null || this.Id?.Equals(other.Id) == true)
                && (
                    this.ReferenceId == null && other.ReferenceId == null
                    || this.ReferenceId?.Equals(other.ReferenceId) == true
                )
                && (
                    this.IsOwner == null && other.IsOwner == null
                    || this.IsOwner?.Equals(other.IsOwner) == true
                )
                && (
                    this.Status == null && other.Status == null
                    || this.Status?.Equals(other.Status) == true
                )
                && (
                    this.GivenName == null && other.GivenName == null
                    || this.GivenName?.Equals(other.GivenName) == true
                )
                && (
                    this.FamilyName == null && other.FamilyName == null
                    || this.FamilyName?.Equals(other.FamilyName) == true
                )
                && (
                    this.EmailAddress == null && other.EmailAddress == null
                    || this.EmailAddress?.Equals(other.EmailAddress) == true
                )
                && (
                    this.PhoneNumber == null && other.PhoneNumber == null
                    || this.PhoneNumber?.Equals(other.PhoneNumber) == true
                )
                && (
                    this.CreatedAt == null && other.CreatedAt == null
                    || this.CreatedAt?.Equals(other.CreatedAt) == true
                )
                && (
                    this.UpdatedAt == null && other.UpdatedAt == null
                    || this.UpdatedAt?.Equals(other.UpdatedAt) == true
                )
                && (
                    this.AssignedLocations == null && other.AssignedLocations == null
                    || this.AssignedLocations?.Equals(other.AssignedLocations) == true
                )
                && (
                    this.WageSetting == null && other.WageSetting == null
                    || this.WageSetting?.Equals(other.WageSetting) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 116363009;
            hashCode = HashCode.Combine(
                hashCode,
                this.Id,
                this.ReferenceId,
                this.IsOwner,
                this.Status,
                this.GivenName,
                this.FamilyName,
                this.EmailAddress
            );

            hashCode = HashCode.Combine(
                hashCode,
                this.PhoneNumber,
                this.CreatedAt,
                this.UpdatedAt,
                this.AssignedLocations,
                this.WageSetting
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id ?? "null"}");
            toStringOutput.Add($"this.ReferenceId = {this.ReferenceId ?? "null"}");
            toStringOutput.Add(
                $"this.IsOwner = {(this.IsOwner == null ? "null" : this.IsOwner.ToString())}"
            );
            toStringOutput.Add(
                $"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}"
            );
            toStringOutput.Add($"this.GivenName = {this.GivenName ?? "null"}");
            toStringOutput.Add($"this.FamilyName = {this.FamilyName ?? "null"}");
            toStringOutput.Add($"this.EmailAddress = {this.EmailAddress ?? "null"}");
            toStringOutput.Add($"this.PhoneNumber = {this.PhoneNumber ?? "null"}");
            toStringOutput.Add($"this.CreatedAt = {this.CreatedAt ?? "null"}");
            toStringOutput.Add($"this.UpdatedAt = {this.UpdatedAt ?? "null"}");
            toStringOutput.Add(
                $"this.AssignedLocations = {(this.AssignedLocations == null ? "null" : this.AssignedLocations.ToString())}"
            );
            toStringOutput.Add(
                $"this.WageSetting = {(this.WageSetting == null ? "null" : this.WageSetting.ToString())}"
            );
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
                .AssignedLocations(this.AssignedLocations)
                .WageSetting(this.WageSetting);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "reference_id", false },
                { "given_name", false },
                { "family_name", false },
                { "email_address", false },
                { "phone_number", false },
            };

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
            private Models.WageSetting wageSetting;

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
                shouldSerialize["reference_id"] = true;
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
                shouldSerialize["given_name"] = true;
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
                shouldSerialize["family_name"] = true;
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
                shouldSerialize["email_address"] = true;
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
                shouldSerialize["phone_number"] = true;
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
            /// WageSetting.
            /// </summary>
            /// <param name="wageSetting"> wageSetting. </param>
            /// <returns> Builder. </returns>
            public Builder WageSetting(Models.WageSetting wageSetting)
            {
                this.wageSetting = wageSetting;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetReferenceId()
            {
                this.shouldSerialize["reference_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetGivenName()
            {
                this.shouldSerialize["given_name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetFamilyName()
            {
                this.shouldSerialize["family_name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetEmailAddress()
            {
                this.shouldSerialize["email_address"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetPhoneNumber()
            {
                this.shouldSerialize["phone_number"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TeamMember. </returns>
            public TeamMember Build()
            {
                return new TeamMember(
                    shouldSerialize,
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
                    this.assignedLocations,
                    this.wageSetting
                );
            }
        }
    }
}
