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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// V1EmployeeRole.
    /// </summary>
    public class V1EmployeeRole
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1EmployeeRole"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="permissions">permissions.</param>
        /// <param name="id">id.</param>
        /// <param name="isOwner">is_owner.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        public V1EmployeeRole(
            string name,
            IList<string> permissions,
            string id = null,
            bool? isOwner = null,
            string createdAt = null,
            string updatedAt = null)
        {
            this.Id = id;
            this.Name = name;
            this.Permissions = permissions;
            this.IsOwner = isOwner;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1EmployeeRole : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1EmployeeRole other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Permissions == null && other.Permissions == null) || (this.Permissions?.Equals(other.Permissions) == true)) &&
                ((this.IsOwner == null && other.IsOwner == null) || (this.IsOwner?.Equals(other.IsOwner) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1766900605;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }

            if (this.Id != null)
            {
               hashCode += this.Id.GetHashCode();
            }

            if (this.Name != null)
            {
               hashCode += this.Name.GetHashCode();
            }

            if (this.Permissions != null)
            {
               hashCode += this.Permissions.GetHashCode();
            }

            if (this.IsOwner != null)
            {
               hashCode += this.IsOwner.GetHashCode();
            }

            if (this.CreatedAt != null)
            {
               hashCode += this.CreatedAt.GetHashCode();
            }

            if (this.UpdatedAt != null)
            {
               hashCode += this.UpdatedAt.GetHashCode();
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
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Permissions = {(this.Permissions == null ? "null" : $"[{string.Join(", ", this.Permissions)} ]")}");
            toStringOutput.Add($"this.IsOwner = {(this.IsOwner == null ? "null" : this.IsOwner.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Name,
                this.Permissions)
                .Id(this.Id)
                .IsOwner(this.IsOwner)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string name;
            private IList<string> permissions;
            private string id;
            private bool? isOwner;
            private string createdAt;
            private string updatedAt;

            public Builder(
                string name,
                IList<string> permissions)
            {
                this.name = name;
                this.permissions = permissions;
            }

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

             /// <summary>
             /// Permissions.
             /// </summary>
             /// <param name="permissions"> permissions. </param>
             /// <returns> Builder. </returns>
            public Builder Permissions(IList<string> permissions)
            {
                this.permissions = permissions;
                return this;
            }

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
            /// Builds class object.
            /// </summary>
            /// <returns> V1EmployeeRole. </returns>
            public V1EmployeeRole Build()
            {
                return new V1EmployeeRole(
                    this.name,
                    this.permissions,
                    this.id,
                    this.isOwner,
                    this.createdAt,
                    this.updatedAt);
            }
        }
    }
}