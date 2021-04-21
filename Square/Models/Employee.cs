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
    using Square.Utilities;

    /// <summary>
    /// Employee.
    /// </summary>
    public class Employee
    {
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
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.LocationIds = locationIds;
            this.Status = status;
            this.IsOwner = isOwner;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Employee : ({string.Join(", ", toStringOutput)})";
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

            return obj is Employee other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
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

            if (this.Email != null)
            {
               hashCode += this.Email.GetHashCode();
            }

            if (this.PhoneNumber != null)
            {
               hashCode += this.PhoneNumber.GetHashCode();
            }

            if (this.LocationIds != null)
            {
               hashCode += this.LocationIds.GetHashCode();
            }

            if (this.Status != null)
            {
               hashCode += this.Status.GetHashCode();
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
            toStringOutput.Add($"this.FirstName = {(this.FirstName == null ? "null" : this.FirstName == string.Empty ? "" : this.FirstName)}");
            toStringOutput.Add($"this.LastName = {(this.LastName == null ? "null" : this.LastName == string.Empty ? "" : this.LastName)}");
            toStringOutput.Add($"this.Email = {(this.Email == null ? "null" : this.Email == string.Empty ? "" : this.Email)}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber == string.Empty ? "" : this.PhoneNumber)}");
            toStringOutput.Add($"this.LocationIds = {(this.LocationIds == null ? "null" : $"[{string.Join(", ", this.LocationIds)} ]")}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
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
             /// PhoneNumber.
             /// </summary>
             /// <param name="phoneNumber"> phoneNumber. </param>
             /// <returns> Builder. </returns>
            public Builder PhoneNumber(string phoneNumber)
            {
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
            /// <returns> Employee. </returns>
            public Employee Build()
            {
                return new Employee(
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