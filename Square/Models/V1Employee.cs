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
        [JsonProperty("id")]
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
        [JsonProperty("role_ids")]
        public IList<string> RoleIds { get; }

        /// <summary>
        /// The IDs of the locations the employee is allowed to clock in at.
        /// </summary>
        [JsonProperty("authorized_location_ids")]
        public IList<string> AuthorizedLocationIds { get; }

        /// <summary>
        /// The employee's email address.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; }

        /// <summary>
        /// Getter for status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// An ID the merchant can set to associate the employee with an entity in another system.
        /// </summary>
        [JsonProperty("external_id")]
        public string ExternalId { get; }

        /// <summary>
        /// The time when the employee entity was created, in ISO 8601 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// The time when the employee entity was most recently updated, in ISO 8601 format.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; }

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
            private IList<string> roleIds = new List<string>();
            private IList<string> authorizedLocationIds = new List<string>();
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
            public Builder FirstName(string value)
            {
                firstName = value;
                return this;
            }

            public Builder LastName(string value)
            {
                lastName = value;
                return this;
            }

            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder RoleIds(IList<string> value)
            {
                roleIds = value;
                return this;
            }

            public Builder AuthorizedLocationIds(IList<string> value)
            {
                authorizedLocationIds = value;
                return this;
            }

            public Builder Email(string value)
            {
                email = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder ExternalId(string value)
            {
                externalId = value;
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