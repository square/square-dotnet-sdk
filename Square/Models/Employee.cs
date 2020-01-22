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
    public class Employee 
    {
        public Employee(string id = null,
            string firstName = null,
            string lastName = null,
            string email = null,
            string phoneNumber = null,
            IList<string> locationIds = null,
            string status = null,
            bool? isOwner = null,
            string createdAt = null,
            string updatedAt = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            LocationIds = locationIds;
            Status = status;
            IsOwner = isOwner;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// UUID for this object.
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
        /// The employee's email address
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; }

        /// <summary>
        /// The employee's phone number in E.164 format, i.e. "+12125554250"
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; }

        /// <summary>
        /// A list of location IDs where this employee has access to.
        /// </summary>
        [JsonProperty("location_ids")]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// The status of the Employee being retrieved.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// Whether this employee is the owner of the merchant. Each merchant
        /// has one owner employee, and that employee has full authority over
        /// the account.
        /// </summary>
        [JsonProperty("is_owner")]
        public bool? IsOwner { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .FirstName(FirstName)
                .LastName(LastName)
                .Email(Email)
                .PhoneNumber(PhoneNumber)
                .LocationIds(LocationIds)
                .Status(Status)
                .IsOwner(IsOwner)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string firstName;
            private string lastName;
            private string email;
            private string phoneNumber;
            private IList<string> locationIds = new List<string>();
            private string status;
            private bool? isOwner;
            private string createdAt;
            private string updatedAt;

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
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

            public Builder Email(string value)
            {
                email = value;
                return this;
            }

            public Builder PhoneNumber(string value)
            {
                phoneNumber = value;
                return this;
            }

            public Builder LocationIds(IList<string> value)
            {
                locationIds = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
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

            public Employee Build()
            {
                return new Employee(id,
                    firstName,
                    lastName,
                    email,
                    phoneNumber,
                    locationIds,
                    status,
                    isOwner,
                    createdAt,
                    updatedAt);
            }
        }
    }
}