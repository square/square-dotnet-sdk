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
    /// VendorContact.
    /// </summary>
    public class VendorContact
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VendorContact"/> class.
        /// </summary>
        /// <param name="ordinal">ordinal.</param>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="emailAddress">email_address.</param>
        /// <param name="phoneNumber">phone_number.</param>
        /// <param name="removed">removed.</param>
        public VendorContact(
            int ordinal,
            string id = null,
            string name = null,
            string emailAddress = null,
            string phoneNumber = null,
            bool? removed = null)
        {
            this.Id = id;
            this.Name = name;
            this.EmailAddress = emailAddress;
            this.PhoneNumber = phoneNumber;
            this.Removed = removed;
            this.Ordinal = ordinal;
        }

        /// <summary>
        /// A unique Square-generated ID for the [VendorContact]($m/VendorContact).
        /// This field is required when attempting to update a [VendorContact]($m/VendorContact).
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The name of the [VendorContact]($m/VendorContact).
        /// This field is required when attempting to create a [Vendor]($m/Vendor).
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// The email address of the [VendorContact]($m/VendorContact).
        /// </summary>
        [JsonProperty("email_address", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; }

        /// <summary>
        /// The phone number of the [VendorContact]($m/VendorContact).
        /// </summary>
        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; }

        /// <summary>
        /// The state of the [VendorContact]($m/VendorContact).
        /// </summary>
        [JsonProperty("removed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Removed { get; }

        /// <summary>
        /// The ordinal of the [VendorContact]($m/VendorContact).
        /// </summary>
        [JsonProperty("ordinal")]
        public int Ordinal { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"VendorContact : ({string.Join(", ", toStringOutput)})";
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

            return obj is VendorContact other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.EmailAddress == null && other.EmailAddress == null) || (this.EmailAddress?.Equals(other.EmailAddress) == true)) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true)) &&
                ((this.Removed == null && other.Removed == null) || (this.Removed?.Equals(other.Removed) == true)) &&
                this.Ordinal.Equals(other.Ordinal);
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 156233878;
            hashCode = HashCode.Combine(this.Id, this.Name, this.EmailAddress, this.PhoneNumber, this.Removed, this.Ordinal);

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
            toStringOutput.Add($"this.EmailAddress = {(this.EmailAddress == null ? "null" : this.EmailAddress == string.Empty ? "" : this.EmailAddress)}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber == string.Empty ? "" : this.PhoneNumber)}");
            toStringOutput.Add($"this.Removed = {(this.Removed == null ? "null" : this.Removed.ToString())}");
            toStringOutput.Add($"this.Ordinal = {this.Ordinal}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Ordinal)
                .Id(this.Id)
                .Name(this.Name)
                .EmailAddress(this.EmailAddress)
                .PhoneNumber(this.PhoneNumber)
                .Removed(this.Removed);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private int ordinal;
            private string id;
            private string name;
            private string emailAddress;
            private string phoneNumber;
            private bool? removed;

            public Builder(
                int ordinal)
            {
                this.ordinal = ordinal;
            }

             /// <summary>
             /// Ordinal.
             /// </summary>
             /// <param name="ordinal"> ordinal. </param>
             /// <returns> Builder. </returns>
            public Builder Ordinal(int ordinal)
            {
                this.ordinal = ordinal;
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
             /// EmailAddress.
             /// </summary>
             /// <param name="emailAddress"> emailAddress. </param>
             /// <returns> Builder. </returns>
            public Builder EmailAddress(string emailAddress)
            {
                this.emailAddress = emailAddress;
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
             /// Removed.
             /// </summary>
             /// <param name="removed"> removed. </param>
             /// <returns> Builder. </returns>
            public Builder Removed(bool? removed)
            {
                this.removed = removed;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> VendorContact. </returns>
            public VendorContact Build()
            {
                return new VendorContact(
                    this.ordinal,
                    this.id,
                    this.name,
                    this.emailAddress,
                    this.phoneNumber,
                    this.removed);
            }
        }
    }
}