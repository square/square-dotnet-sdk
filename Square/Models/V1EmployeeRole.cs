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
        [JsonProperty("id")]
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
        [JsonProperty("is_owner")]
        public bool? IsOwner { get; }

        /// <summary>
        /// The time when the employee entity was created, in ISO 8601 format. Is set by Square when the Role is created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// The time when the employee entity was most recently updated, in ISO 8601 format. Is set by Square when the Role updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; }

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
            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder Permissions(IList<string> value)
            {
                permissions = value;
                return this;
            }

            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder IsOwner(bool? value)
            {
                isOwner = value;
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