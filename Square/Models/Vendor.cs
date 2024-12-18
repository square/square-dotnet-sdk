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

namespace Square.Models
{
    /// <summary>
    /// Vendor.
    /// </summary>
    public class Vendor
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "contacts", false },
                { "account_number", false },
                { "note", false }
            };
            this.Id = id;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }
            this.Address = address;

            if (contacts != null)
            {
                shouldSerialize["contacts"] = true;
                this.Contacts = contacts;
            }

            if (accountNumber != null)
            {
                shouldSerialize["account_number"] = true;
                this.AccountNumber = accountNumber;
            }

            if (note != null)
            {
                shouldSerialize["note"] = true;
                this.Note = note;
            }
            this.Version = version;
            this.Status = status;
        }

        internal Vendor(
            Dictionary<string, bool> shouldSerialize,
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
            this.shouldSerialize = shouldSerialize;
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Name = name;
            Address = address;
            Contacts = contacts;
            AccountNumber = accountNumber;
            Note = note;
            Version = version;
            Status = status;
        }

        /// <summary>
        /// A unique Square-generated ID for the [Vendor](entity:Vendor).
        /// This field is required when attempting to update a [Vendor](entity:Vendor).
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// An RFC 3339-formatted timestamp that indicates when the
        /// [Vendor](entity:Vendor) was created.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// An RFC 3339-formatted timestamp that indicates when the
        /// [Vendor](entity:Vendor) was last updated.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The name of the [Vendor](entity:Vendor).
        /// This field is required when attempting to create or update a [Vendor](entity:Vendor).
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Represents a postal address in a country.
        /// For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address Address { get; }

        /// <summary>
        /// The contacts of the [Vendor](entity:Vendor).
        /// </summary>
        [JsonProperty("contacts")]
        public IList<Models.VendorContact> Contacts { get; }

        /// <summary>
        /// The account number of the [Vendor](entity:Vendor).
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber { get; }

        /// <summary>
        /// A note detailing information about the [Vendor](entity:Vendor).
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; }

        /// <summary>
        /// The version of the [Vendor](entity:Vendor).
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

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeContacts()
        {
            return this.shouldSerialize["contacts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAccountNumber()
        {
            return this.shouldSerialize["account_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNote()
        {
            return this.shouldSerialize["note"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Vendor other &&
                (this.Id == null && other.Id == null ||
                 this.Id?.Equals(other.Id) == true) &&
                (this.CreatedAt == null && other.CreatedAt == null ||
                 this.CreatedAt?.Equals(other.CreatedAt) == true) &&
                (this.UpdatedAt == null && other.UpdatedAt == null ||
                 this.UpdatedAt?.Equals(other.UpdatedAt) == true) &&
                (this.Name == null && other.Name == null ||
                 this.Name?.Equals(other.Name) == true) &&
                (this.Address == null && other.Address == null ||
                 this.Address?.Equals(other.Address) == true) &&
                (this.Contacts == null && other.Contacts == null ||
                 this.Contacts?.Equals(other.Contacts) == true) &&
                (this.AccountNumber == null && other.AccountNumber == null ||
                 this.AccountNumber?.Equals(other.AccountNumber) == true) &&
                (this.Note == null && other.Note == null ||
                 this.Note?.Equals(other.Note) == true) &&
                (this.Version == null && other.Version == null ||
                 this.Version?.Equals(other.Version) == true) &&
                (this.Status == null && other.Status == null ||
                 this.Status?.Equals(other.Status) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 686602991;
            hashCode = HashCode.Combine(hashCode, this.Id, this.CreatedAt, this.UpdatedAt, this.Name, this.Address, this.Contacts, this.AccountNumber);

            hashCode = HashCode.Combine(hashCode, this.Note, this.Version, this.Status);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id ?? "null"}");
            toStringOutput.Add($"this.CreatedAt = {this.CreatedAt ?? "null"}");
            toStringOutput.Add($"this.UpdatedAt = {this.UpdatedAt ?? "null"}");
            toStringOutput.Add($"this.Name = {this.Name ?? "null"}");
            toStringOutput.Add($"this.Address = {(this.Address == null ? "null" : this.Address.ToString())}");
            toStringOutput.Add($"this.Contacts = {(this.Contacts == null ? "null" : $"[{string.Join(", ", this.Contacts)} ]")}");
            toStringOutput.Add($"this.AccountNumber = {this.AccountNumber ?? "null"}");
            toStringOutput.Add($"this.Note = {this.Note ?? "null"}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "contacts", false },
                { "account_number", false },
                { "note", false },
            };

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
                shouldSerialize["name"] = true;
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
                shouldSerialize["contacts"] = true;
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
                shouldSerialize["account_number"] = true;
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
                shouldSerialize["note"] = true;
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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetContacts()
            {
                this.shouldSerialize["contacts"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetAccountNumber()
            {
                this.shouldSerialize["account_number"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetNote()
            {
                this.shouldSerialize["note"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Vendor. </returns>
            public Vendor Build()
            {
                return new Vendor(
                    shouldSerialize,
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