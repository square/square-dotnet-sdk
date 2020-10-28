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
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The employee's first name.
        /// </summary>
        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; }

        /// <summary>
        /// The employee's last name.
        /// </summary>
        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; }

        /// <summary>
        /// The employee's email address
        /// </summary>
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; }

        /// <summary>
        /// The employee's phone number in E.164 format, i.e. "+12125554250"
        /// </summary>
        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; }

        /// <summary>
        /// A list of location IDs where this employee has access to.
        /// </summary>
        [JsonProperty("location_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// The status of the Employee being retrieved.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// Whether this employee is the owner of the merchant. Each merchant
        /// has one owner employee, and that employee has full authority over
        /// the account.
        /// </summary>
        [JsonProperty("is_owner", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsOwner { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
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
            private IList<string> locationIds;
            private string status;
            private bool? isOwner;
            private string createdAt;
            private string updatedAt;



            public Builder Id(string id)
            {
                this.id = id;
                return this;
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

            public Builder Email(string email)
            {
                this.email = email;
                return this;
            }

            public Builder PhoneNumber(string phoneNumber)
            {
                this.phoneNumber = phoneNumber;
                return this;
            }

            public Builder LocationIds(IList<string> locationIds)
            {
                this.locationIds = locationIds;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
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