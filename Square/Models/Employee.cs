namespace Square.Models
{
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
    using Square;
    using Square.Utilities;

    /// <summary>
    /// Employee.
    /// </summary>
    public class Employee
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="firstName">first_name.</param>
        /// <param name="lastName">last_name.</param>
        /// <param name="email">email.</param>
        /// <param name="phoneNumber">phone_number.</param>
        /// <param name="locationIds">location_ids.</param>
        /// <param name="status">status.</param>
        /// <param name="isOwner">is_owner.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        public Employee(
            string id = null,
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "first_name", false },
                { "last_name", false },
                { "email", false },
                { "phone_number", false },
                { "location_ids", false },
                { "is_owner", false }
            };

            this.Id = id;
            if (firstName != null)
            {
                shouldSerialize["first_name"] = true;
                this.FirstName = firstName;
            }

            if (lastName != null)
            {
                shouldSerialize["last_name"] = true;
                this.LastName = lastName;
            }

            if (email != null)
            {
                shouldSerialize["email"] = true;
                this.Email = email;
            }

            if (phoneNumber != null)
            {
                shouldSerialize["phone_number"] = true;
                this.PhoneNumber = phoneNumber;
            }

            if (locationIds != null)
            {
                shouldSerialize["location_ids"] = true;
                this.LocationIds = locationIds;
            }

            this.Status = status;
            if (isOwner != null)
            {
                shouldSerialize["is_owner"] = true;
                this.IsOwner = isOwner;
            }

            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }
        internal Employee(Dictionary<string, bool> shouldSerialize,
            string id = null,
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
            this.shouldSerialize = shouldSerialize;
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
        /// DEPRECATED at version 2020-08-26. Replaced by [TeamMemberStatus](entity:TeamMemberStatus).
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Employee : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFirstName()
        {
            return this.shouldSerialize["first_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLastName()
        {
            return this.shouldSerialize["last_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmail()
        {
            return this.shouldSerialize["email"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePhoneNumber()
        {
            return this.shouldSerialize["phone_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationIds()
        {
            return this.shouldSerialize["location_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIsOwner()
        {
            return this.shouldSerialize["is_owner"];
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
            return obj is Employee other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.FirstName == null && other.FirstName == null) || (this.FirstName?.Equals(other.FirstName) == true)) &&
                ((this.LastName == null && other.LastName == null) || (this.LastName?.Equals(other.LastName) == true)) &&
                ((this.Email == null && other.Email == null) || (this.Email?.Equals(other.Email) == true)) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((this.LocationIds == null && other.LocationIds == null) || (this.LocationIds?.Equals(other.LocationIds) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.IsOwner == null && other.IsOwner == null) || (this.IsOwner?.Equals(other.IsOwner) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1607883077;
            hashCode = HashCode.Combine(this.Id, this.FirstName, this.LastName, this.Email, this.PhoneNumber, this.LocationIds, this.Status);

            hashCode = HashCode.Combine(hashCode, this.IsOwner, this.CreatedAt, this.UpdatedAt);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.FirstName = {(this.FirstName == null ? "null" : this.FirstName)}");
            toStringOutput.Add($"this.LastName = {(this.LastName == null ? "null" : this.LastName)}");
            toStringOutput.Add($"this.Email = {(this.Email == null ? "null" : this.Email)}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber)}");
            toStringOutput.Add($"this.LocationIds = {(this.LocationIds == null ? "null" : $"[{string.Join(", ", this.LocationIds)} ]")}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.IsOwner = {(this.IsOwner == null ? "null" : this.IsOwner.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .FirstName(this.FirstName)
                .LastName(this.LastName)
                .Email(this.Email)
                .PhoneNumber(this.PhoneNumber)
                .LocationIds(this.LocationIds)
                .Status(this.Status)
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "first_name", false },
                { "last_name", false },
                { "email", false },
                { "phone_number", false },
                { "location_ids", false },
                { "is_owner", false },
            };

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
             /// FirstName.
             /// </summary>
             /// <param name="firstName"> firstName. </param>
             /// <returns> Builder. </returns>
            public Builder FirstName(string firstName)
            {
                shouldSerialize["first_name"] = true;
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
                shouldSerialize["last_name"] = true;
                this.lastName = lastName;
                return this;
            }

             /// <summary>
             /// Email.
             /// </summary>
             /// <param name="email"> email. </param>
             /// <returns> Builder. </returns>
            public Builder Email(string email)
            {
                shouldSerialize["email"] = true;
                this.email = email;
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
             /// LocationIds.
             /// </summary>
             /// <param name="locationIds"> locationIds. </param>
             /// <returns> Builder. </returns>
            public Builder LocationIds(IList<string> locationIds)
            {
                shouldSerialize["location_ids"] = true;
                this.locationIds = locationIds;
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
             /// IsOwner.
             /// </summary>
             /// <param name="isOwner"> isOwner. </param>
             /// <returns> Builder. </returns>
            public Builder IsOwner(bool? isOwner)
            {
                shouldSerialize["is_owner"] = true;
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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetFirstName()
            {
                this.shouldSerialize["first_name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLastName()
            {
                this.shouldSerialize["last_name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEmail()
            {
                this.shouldSerialize["email"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPhoneNumber()
            {
                this.shouldSerialize["phone_number"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocationIds()
            {
                this.shouldSerialize["location_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIsOwner()
            {
                this.shouldSerialize["is_owner"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Employee. </returns>
            public Employee Build()
            {
                return new Employee(shouldSerialize,
                    this.id,
                    this.firstName,
                    this.lastName,
                    this.email,
                    this.phoneNumber,
                    this.locationIds,
                    this.status,
                    this.isOwner,
                    this.createdAt,
                    this.updatedAt);
            }
        }
    }
}