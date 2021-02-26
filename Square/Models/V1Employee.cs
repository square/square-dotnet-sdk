
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1Employee 
    {
        public V1Employee(string firstName,
            string lastName,
            string id = null,
            IList<string> roleIds = null,
            IList<string> authorizedLocationIds = null,
            string email = null,
            string status = null,
            string externalId = null,
            string createdAt = null,
            string updatedAt = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            RoleIds = roleIds;
            AuthorizedLocationIds = authorizedLocationIds;
            Email = email;
            Status = status;
            ExternalId = externalId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The employee's unique ID.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The employee's first name.
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; }

        /// <summary>
        /// The employee's last name.
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; }

        /// <summary>
        /// The ids of the employee's associated roles. Currently, you can specify only one or zero roles per employee.
        /// </summary>
        [JsonProperty("role_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> RoleIds { get; }

        /// <summary>
        /// The IDs of the locations the employee is allowed to clock in at.
        /// </summary>
        [JsonProperty("authorized_location_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> AuthorizedLocationIds { get; }

        /// <summary>
        /// The employee's email address.
        /// </summary>
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; }

        /// <summary>
        /// Getter for status
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// An ID the merchant can set to associate the employee with an entity in another system.
        /// </summary>
        [JsonProperty("external_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalId { get; }

        /// <summary>
        /// The time when the employee entity was created, in ISO 8601 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The time when the employee entity was most recently updated, in ISO 8601 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1Employee : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"FirstName = {(FirstName == null ? "null" : FirstName == string.Empty ? "" : FirstName)}");
            toStringOutput.Add($"LastName = {(LastName == null ? "null" : LastName == string.Empty ? "" : LastName)}");
            toStringOutput.Add($"RoleIds = {(RoleIds == null ? "null" : $"[{ string.Join(", ", RoleIds)} ]")}");
            toStringOutput.Add($"AuthorizedLocationIds = {(AuthorizedLocationIds == null ? "null" : $"[{ string.Join(", ", AuthorizedLocationIds)} ]")}");
            toStringOutput.Add($"Email = {(Email == null ? "null" : Email == string.Empty ? "" : Email)}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status.ToString())}");
            toStringOutput.Add($"ExternalId = {(ExternalId == null ? "null" : ExternalId == string.Empty ? "" : ExternalId)}");
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
            toStringOutput.Add($"UpdatedAt = {(UpdatedAt == null ? "null" : UpdatedAt == string.Empty ? "" : UpdatedAt)}");
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

            return obj is V1Employee other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((FirstName == null && other.FirstName == null) || (FirstName?.Equals(other.FirstName) == true)) &&
                ((LastName == null && other.LastName == null) || (LastName?.Equals(other.LastName) == true)) &&
                ((RoleIds == null && other.RoleIds == null) || (RoleIds?.Equals(other.RoleIds) == true)) &&
                ((AuthorizedLocationIds == null && other.AuthorizedLocationIds == null) || (AuthorizedLocationIds?.Equals(other.AuthorizedLocationIds) == true)) &&
                ((Email == null && other.Email == null) || (Email?.Equals(other.Email) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true)) &&
                ((ExternalId == null && other.ExternalId == null) || (ExternalId?.Equals(other.ExternalId) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((UpdatedAt == null && other.UpdatedAt == null) || (UpdatedAt?.Equals(other.UpdatedAt) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1815713267;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (FirstName != null)
            {
               hashCode += FirstName.GetHashCode();
            }

            if (LastName != null)
            {
               hashCode += LastName.GetHashCode();
            }

            if (RoleIds != null)
            {
               hashCode += RoleIds.GetHashCode();
            }

            if (AuthorizedLocationIds != null)
            {
               hashCode += AuthorizedLocationIds.GetHashCode();
            }

            if (Email != null)
            {
               hashCode += Email.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }

            if (ExternalId != null)
            {
               hashCode += ExternalId.GetHashCode();
            }

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            if (UpdatedAt != null)
            {
               hashCode += UpdatedAt.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(FirstName,
                LastName)
                .Id(Id)
                .RoleIds(RoleIds)
                .AuthorizedLocationIds(AuthorizedLocationIds)
                .Email(Email)
                .Status(Status)
                .ExternalId(ExternalId)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt);
            return builder;
        }

        public class Builder
        {
            private string firstName;
            private string lastName;
            private string id;
            private IList<string> roleIds;
            private IList<string> authorizedLocationIds;
            private string email;
            private string status;
            private string externalId;
            private string createdAt;
            private string updatedAt;

            public Builder(string firstName,
                string lastName)
            {
                this.firstName = firstName;
                this.lastName = lastName;
            }

            public Builder FirstName(string firstName)
            {
                this.firstName = firstName;
                return this;
            }

            public Builder LastName(string lastName)
            {
                this.lastName = lastName;
                return this;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder RoleIds(IList<string> roleIds)
            {
                this.roleIds = roleIds;
                return this;
            }

            public Builder AuthorizedLocationIds(IList<string> authorizedLocationIds)
            {
                this.authorizedLocationIds = authorizedLocationIds;
                return this;
            }

            public Builder Email(string email)
            {
                this.email = email;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public Builder ExternalId(string externalId)
            {
                this.externalId = externalId;
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

            public V1Employee Build()
            {
                return new V1Employee(firstName,
                    lastName,
                    id,
                    roleIds,
                    authorizedLocationIds,
                    email,
                    status,
                    externalId,
                    createdAt,
                    updatedAt);
            }
        }
    }
}