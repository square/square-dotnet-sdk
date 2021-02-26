
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Employee : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"FirstName = {(FirstName == null ? "null" : FirstName == string.Empty ? "" : FirstName)}");
            toStringOutput.Add($"LastName = {(LastName == null ? "null" : LastName == string.Empty ? "" : LastName)}");
            toStringOutput.Add($"Email = {(Email == null ? "null" : Email == string.Empty ? "" : Email)}");
            toStringOutput.Add($"PhoneNumber = {(PhoneNumber == null ? "null" : PhoneNumber == string.Empty ? "" : PhoneNumber)}");
            toStringOutput.Add($"LocationIds = {(LocationIds == null ? "null" : $"[{ string.Join(", ", LocationIds)} ]")}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status.ToString())}");
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

            return obj is Employee other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((FirstName == null && other.FirstName == null) || (FirstName?.Equals(other.FirstName) == true)) &&
                ((LastName == null && other.LastName == null) || (LastName?.Equals(other.LastName) == true)) &&
                ((Email == null && other.Email == null) || (Email?.Equals(other.Email) == true)) &&
                ((PhoneNumber == null && other.PhoneNumber == null) || (PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((LocationIds == null && other.LocationIds == null) || (LocationIds?.Equals(other.LocationIds) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true)) &&
                ((IsOwner == null && other.IsOwner == null) || (IsOwner?.Equals(other.IsOwner) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((UpdatedAt == null && other.UpdatedAt == null) || (UpdatedAt?.Equals(other.UpdatedAt) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1607883077;

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

            if (Email != null)
            {
               hashCode += Email.GetHashCode();
            }

            if (PhoneNumber != null)
            {
               hashCode += PhoneNumber.GetHashCode();
            }

            if (LocationIds != null)
            {
               hashCode += LocationIds.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
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