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
    /// V1Employee.
    /// </summary>
    public class V1Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1Employee"/> class.
        /// </summary>
        /// <param name="firstName">first_name.</param>
        /// <param name="lastName">last_name.</param>
        /// <param name="id">id.</param>
        /// <param name="roleIds">role_ids.</param>
        /// <param name="authorizedLocationIds">authorized_location_ids.</param>
        /// <param name="email">email.</param>
        /// <param name="status">status.</param>
        /// <param name="externalId">external_id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        public V1Employee(
            string firstName,
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
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.RoleIds = roleIds;
            this.AuthorizedLocationIds = authorizedLocationIds;
            this.Email = email;
            this.Status = status;
            this.ExternalId = externalId;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
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
        /// Gets or sets Status.
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1Employee : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1Employee other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.FirstName == null && other.FirstName == null) || (this.FirstName?.Equals(other.FirstName) == true)) &&
                ((this.LastName == null && other.LastName == null) || (this.LastName?.Equals(other.LastName) == true)) &&
                ((this.RoleIds == null && other.RoleIds == null) || (this.RoleIds?.Equals(other.RoleIds) == true)) &&
                ((this.AuthorizedLocationIds == null && other.AuthorizedLocationIds == null) || (this.AuthorizedLocationIds?.Equals(other.AuthorizedLocationIds) == true)) &&
                ((this.Email == null && other.Email == null) || (this.Email?.Equals(other.Email) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.ExternalId == null && other.ExternalId == null) || (this.ExternalId?.Equals(other.ExternalId) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1815713267;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }

            if (this.Id != null)
            {
               hashCode += this.Id.GetHashCode();
            }

            if (this.FirstName != null)
            {
               hashCode += this.FirstName.GetHashCode();
            }

            if (this.LastName != null)
            {
               hashCode += this.LastName.GetHashCode();
            }

            if (this.RoleIds != null)
            {
               hashCode += this.RoleIds.GetHashCode();
            }

            if (this.AuthorizedLocationIds != null)
            {
               hashCode += this.AuthorizedLocationIds.GetHashCode();
            }

            if (this.Email != null)
            {
               hashCode += this.Email.GetHashCode();
            }

            if (this.Status != null)
            {
               hashCode += this.Status.GetHashCode();
            }

            if (this.ExternalId != null)
            {
               hashCode += this.ExternalId.GetHashCode();
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
            toStringOutput.Add($"this.FirstName = {(this.FirstName == null ? "null" : this.FirstName == string.Empty ? "" : this.FirstName)}");
            toStringOutput.Add($"this.LastName = {(this.LastName == null ? "null" : this.LastName == string.Empty ? "" : this.LastName)}");
            toStringOutput.Add($"this.RoleIds = {(this.RoleIds == null ? "null" : $"[{string.Join(", ", this.RoleIds)} ]")}");
            toStringOutput.Add($"this.AuthorizedLocationIds = {(this.AuthorizedLocationIds == null ? "null" : $"[{string.Join(", ", this.AuthorizedLocationIds)} ]")}");
            toStringOutput.Add($"this.Email = {(this.Email == null ? "null" : this.Email == string.Empty ? "" : this.Email)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.ExternalId = {(this.ExternalId == null ? "null" : this.ExternalId == string.Empty ? "" : this.ExternalId)}");
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
                this.FirstName,
                this.LastName)
                .Id(this.Id)
                .RoleIds(this.RoleIds)
                .AuthorizedLocationIds(this.AuthorizedLocationIds)
                .Email(this.Email)
                .Status(this.Status)
                .ExternalId(this.ExternalId)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
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

            public Builder(
                string firstName,
                string lastName)
            {
                this.firstName = firstName;
                this.lastName = lastName;
            }

             /// <summary>
             /// FirstName.
             /// </summary>
             /// <param name="firstName"> firstName. </param>
             /// <returns> Builder. </returns>
            public Builder FirstName(string firstName)
            {
                this.firstName = firstName;
                return this;
            }

             /// <summary>
             /// LastName.
             /// </summary>
             /// <param name="lastName"> lastName. </param>
             /// <returns> Builder. </returns>
            public Builder LastName(string lastName)
            {
                this.lastName = lastName;
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
             /// RoleIds.
             /// </summary>
             /// <param name="roleIds"> roleIds. </param>
             /// <returns> Builder. </returns>
            public Builder RoleIds(IList<string> roleIds)
            {
                this.roleIds = roleIds;
                return this;
            }

             /// <summary>
             /// AuthorizedLocationIds.
             /// </summary>
             /// <param name="authorizedLocationIds"> authorizedLocationIds. </param>
             /// <returns> Builder. </returns>
            public Builder AuthorizedLocationIds(IList<string> authorizedLocationIds)
            {
                this.authorizedLocationIds = authorizedLocationIds;
                return this;
            }

             /// <summary>
             /// Email.
             /// </summary>
             /// <param name="email"> email. </param>
             /// <returns> Builder. </returns>
            public Builder Email(string email)
            {
                this.email = email;
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
             /// ExternalId.
             /// </summary>
             /// <param name="externalId"> externalId. </param>
             /// <returns> Builder. </returns>
            public Builder ExternalId(string externalId)
            {
                this.externalId = externalId;
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
            /// <returns> V1Employee. </returns>
            public V1Employee Build()
            {
                return new V1Employee(
                    this.firstName,
                    this.lastName,
                    this.id,
                    this.roleIds,
                    this.authorizedLocationIds,
                    this.email,
                    this.status,
                    this.externalId,
                    this.createdAt,
                    this.updatedAt);
            }
        }
    }
}