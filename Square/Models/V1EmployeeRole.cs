
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
    public class V1EmployeeRole 
    {
        public V1EmployeeRole(string name,
            IList<string> permissions,
            string id = null,
            bool? isOwner = null,
            string createdAt = null,
            string updatedAt = null)
        {
            Id = id;
            Name = name;
            Permissions = permissions;
            IsOwner = isOwner;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The role's unique ID, Can only be set by Square.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The role's merchant-defined name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The role's permissions.
        /// See [V1EmployeeRolePermissions](#type-v1employeerolepermissions) for possible values
        /// </summary>
        [JsonProperty("permissions")]
        public IList<string> Permissions { get; }

        /// <summary>
        /// If true, employees with this role have all permissions, regardless of the values indicated in permissions.
        /// </summary>
        [JsonProperty("is_owner", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsOwner { get; }

        /// <summary>
        /// The time when the employee entity was created, in ISO 8601 format. Is set by Square when the Role is created.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The time when the employee entity was most recently updated, in ISO 8601 format. Is set by Square when the Role updated.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1EmployeeRole : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
            toStringOutput.Add($"Permissions = {(Permissions == null ? "null" : $"[{ string.Join(", ", Permissions)} ]")}");
            toStringOutput.Add($"IsOwner = {(IsOwner == null ? "null" : IsOwner.ToString())}");
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

            return obj is V1EmployeeRole other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true)) &&
                ((Permissions == null && other.Permissions == null) || (Permissions?.Equals(other.Permissions) == true)) &&
                ((IsOwner == null && other.IsOwner == null) || (IsOwner?.Equals(other.IsOwner) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((UpdatedAt == null && other.UpdatedAt == null) || (UpdatedAt?.Equals(other.UpdatedAt) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1766900605;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            if (Permissions != null)
            {
               hashCode += Permissions.GetHashCode();
            }

            if (IsOwner != null)
            {
               hashCode += IsOwner.GetHashCode();
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
            var builder = new Builder(Name,
                Permissions)
                .Id(Id)
                .IsOwner(IsOwner)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt);
            return builder;
        }

        public class Builder
        {
            private string name;
            private IList<string> permissions;
            private string id;
            private bool? isOwner;
            private string createdAt;
            private string updatedAt;

            public Builder(string name,
                IList<string> permissions)
            {
                this.name = name;
                this.permissions = permissions;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder Permissions(IList<string> permissions)
            {
                this.permissions = permissions;
                return this;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder IsOwner(bool? isOwner)
            {
                this.isOwner = isOwner;
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

            public V1EmployeeRole Build()
            {
                return new V1EmployeeRole(name,
                    permissions,
                    id,
                    isOwner,
                    createdAt,
                    updatedAt);
            }
        }
    }
}