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
    /// Vendor.
    /// </summary>
    public class Vendor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vendor"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="name">name.</param>
        /// <param name="address">address.</param>
        /// <param name="contacts">contacts.</param>
        /// <param name="accountNumber">account_number.</param>
        /// <param name="note">note.</param>
        /// <param name="version">version.</param>
        /// <param name="status">status.</param>
        public Vendor(
            string id = null,
            string createdAt = null,
            string updatedAt = null,
            string name = null,
            Models.Address address = null,
            IList<Models.VendorContact> contacts = null,
            string accountNumber = null,
            string note = null,
            int? version = null,
            string status = null)
        {
            this.Id = id;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.Name = name;
            this.Address = address;
            this.Contacts = contacts;
            this.AccountNumber = accountNumber;
            this.Note = note;
            this.Version = version;
            this.Status = status;
        }

        /// <summary>
        /// A unique Square-generated ID for the [Vendor]($m/Vendor).
        /// This field is required when attempting to update a [Vendor]($m/Vendor).
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// An RFC 3339-formatted timestamp that indicates when the
        /// [Vendor]($m/Vendor) was created.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// An RFC 3339-formatted timestamp that indicates when the
        /// [Vendor]($m/Vendor) was last updated.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The name of the [Vendor]($m/Vendor).
        /// This field is required when attempting to create or update a [Vendor]($m/Vendor).
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// Represents a postal address in a country.
        /// For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address Address { get; }

        /// <summary>
        /// The contacts of the [Vendor]($m/Vendor).
        /// </summary>
        [JsonProperty("contacts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.VendorContact> Contacts { get; }

        /// <summary>
        /// The account number of the [Vendor]($m/Vendor).
        /// </summary>
        [JsonProperty("account_number", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountNumber { get; }

        /// <summary>
        /// A note detailing information about the [Vendor]($m/Vendor).
        /// </summary>
        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; }

        /// <summary>
        /// The version of the [Vendor]($m/Vendor).
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// The status of the [Vendor]($m/Vendor),
        /// whether a [Vendor]($m/Vendor) is active or inactive.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Vendor : ({string.Join(", ", toStringOutput)})";
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

            return obj is Vendor other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Address == null && other.Address == null) || (this.Address?.Equals(other.Address) == true)) &&
                ((this.Contacts == null && other.Contacts == null) || (this.Contacts?.Equals(other.Contacts) == true)) &&
                ((this.AccountNumber == null && other.AccountNumber == null) || (this.AccountNumber?.Equals(other.AccountNumber) == true)) &&
                ((this.Note == null && other.Note == null) || (this.Note?.Equals(other.Note) == true)) &&
                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 686602991;
            hashCode = HashCode.Combine(this.Id, this.CreatedAt, this.UpdatedAt, this.Name, this.Address, this.Contacts, this.AccountNumber);

            hashCode = HashCode.Combine(hashCode, this.Note, this.Version, this.Status);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Address = {(this.Address == null ? "null" : this.Address.ToString())}");
            toStringOutput.Add($"this.Contacts = {(this.Contacts == null ? "null" : $"[{string.Join(", ", this.Contacts)} ]")}");
            toStringOutput.Add($"this.AccountNumber = {(this.AccountNumber == null ? "null" : this.AccountNumber == string.Empty ? "" : this.AccountNumber)}");
            toStringOutput.Add($"this.Note = {(this.Note == null ? "null" : this.Note == string.Empty ? "" : this.Note)}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .Name(this.Name)
                .Address(this.Address)
                .Contacts(this.Contacts)
                .AccountNumber(this.AccountNumber)
                .Note(this.Note)
                .Version(this.Version)
                .Status(this.Status);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string id;
            private string createdAt;
            private string updatedAt;
            private string name;
            private Models.Address address;
            private IList<Models.VendorContact> contacts;
            private string accountNumber;
            private string note;
            private int? version;
            private string status;

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
             /// Address.
             /// </summary>
             /// <param name="address"> address. </param>
             /// <returns> Builder. </returns>
            public Builder Address(Models.Address address)
            {
                this.address = address;
                return this;
            }

             /// <summary>
             /// Contacts.
             /// </summary>
             /// <param name="contacts"> contacts. </param>
             /// <returns> Builder. </returns>
            public Builder Contacts(IList<Models.VendorContact> contacts)
            {
                this.contacts = contacts;
                return this;
            }

             /// <summary>
             /// AccountNumber.
             /// </summary>
             /// <param name="accountNumber"> accountNumber. </param>
             /// <returns> Builder. </returns>
            public Builder AccountNumber(string accountNumber)
            {
                this.accountNumber = accountNumber;
                return this;
            }

             /// <summary>
             /// Note.
             /// </summary>
             /// <param name="note"> note. </param>
             /// <returns> Builder. </returns>
            public Builder Note(string note)
            {
                this.note = note;
                return this;
            }

             /// <summary>
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(int? version)
            {
                this.version = version;
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
            /// Builds class object.
            /// </summary>
            /// <returns> Vendor. </returns>
            public Vendor Build()
            {
                return new Vendor(
                    this.id,
                    this.createdAt,
                    this.updatedAt,
                    this.name,
                    this.address,
                    this.contacts,
                    this.accountNumber,
                    this.note,
                    this.version,
                    this.status);
            }
        }
    }
}