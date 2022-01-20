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
    /// Address.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="addressLine1">address_line_1.</param>
        /// <param name="addressLine2">address_line_2.</param>
        /// <param name="addressLine3">address_line_3.</param>
        /// <param name="locality">locality.</param>
        /// <param name="sublocality">sublocality.</param>
        /// <param name="administrativeDistrictLevel1">administrative_district_level_1.</param>
        /// <param name="postalCode">postal_code.</param>
        /// <param name="country">country.</param>
        public Address(
            string addressLine1 = null,
            string addressLine2 = null,
            string addressLine3 = null,
            string locality = null,
            string sublocality = null,
            string administrativeDistrictLevel1 = null,
            string postalCode = null,
            string country = null)
        {
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.AddressLine3 = addressLine3;
            this.Locality = locality;
            this.Sublocality = sublocality;
            this.AdministrativeDistrictLevel1 = administrativeDistrictLevel1;
            this.PostalCode = postalCode;
            this.Country = country;
        }

        /// <summary>
        /// The first line of the address.
        /// Fields that start with `address_line` provide the address's most specific
        /// details, like street number, street name, and building name. They do *not*
        /// provide less specific details like city, state/province, or country (these
        /// details are provided in other fields).
        /// </summary>
        [JsonProperty("address_line_1", NullValueHandling = NullValueHandling.Ignore)]
        public string AddressLine1 { get; }

        /// <summary>
        /// The second line of the address, if any.
        /// </summary>
        [JsonProperty("address_line_2", NullValueHandling = NullValueHandling.Ignore)]
        public string AddressLine2 { get; }

        /// <summary>
        /// The third line of the address, if any.
        /// </summary>
        [JsonProperty("address_line_3", NullValueHandling = NullValueHandling.Ignore)]
        public string AddressLine3 { get; }

        /// <summary>
        /// The city or town of the address. For a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        /// </summary>
        [JsonProperty("locality", NullValueHandling = NullValueHandling.Ignore)]
        public string Locality { get; }

        /// <summary>
        /// A civil region within the address's `locality`, if any.
        /// </summary>
        [JsonProperty("sublocality", NullValueHandling = NullValueHandling.Ignore)]
        public string Sublocality { get; }

        /// <summary>
        /// A civil entity within the address's country. In the US, this
        /// is the state. For a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        /// </summary>
        [JsonProperty("administrative_district_level_1", NullValueHandling = NullValueHandling.Ignore)]
        public string AdministrativeDistrictLevel1 { get; }

        /// <summary>
        /// The address's postal code. For a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        /// </summary>
        [JsonProperty("postal_code", NullValueHandling = NullValueHandling.Ignore)]
        public string PostalCode { get; }

        /// <summary>
        /// Indicates the country associated with another entity, such as a business.
        /// Values are in [ISO 3166-1-alpha-2 format](http://www.iso.org/iso/home/standards/country_codes.htm).
        /// </summary>
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Address : ({string.Join(", ", toStringOutput)})";
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

            return obj is Address other &&
                ((this.AddressLine1 == null && other.AddressLine1 == null) || (this.AddressLine1?.Equals(other.AddressLine1) == true)) &&
                ((this.AddressLine2 == null && other.AddressLine2 == null) || (this.AddressLine2?.Equals(other.AddressLine2) == true)) &&
                ((this.AddressLine3 == null && other.AddressLine3 == null) || (this.AddressLine3?.Equals(other.AddressLine3) == true)) &&
                ((this.Locality == null && other.Locality == null) || (this.Locality?.Equals(other.Locality) == true)) &&
                ((this.Sublocality == null && other.Sublocality == null) || (this.Sublocality?.Equals(other.Sublocality) == true)) &&
                ((this.AdministrativeDistrictLevel1 == null && other.AdministrativeDistrictLevel1 == null) || (this.AdministrativeDistrictLevel1?.Equals(other.AdministrativeDistrictLevel1) == true)) &&
                ((this.PostalCode == null && other.PostalCode == null) || (this.PostalCode?.Equals(other.PostalCode) == true)) &&
                ((this.Country == null && other.Country == null) || (this.Country?.Equals(other.Country) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1686660835;
            hashCode = HashCode.Combine(this.AddressLine1, this.AddressLine2, this.AddressLine3, this.Locality, this.Sublocality, this.AdministrativeDistrictLevel1, this.PostalCode);

            hashCode = HashCode.Combine(hashCode, this.Country);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AddressLine1 = {(this.AddressLine1 == null ? "null" : this.AddressLine1 == string.Empty ? "" : this.AddressLine1)}");
            toStringOutput.Add($"this.AddressLine2 = {(this.AddressLine2 == null ? "null" : this.AddressLine2 == string.Empty ? "" : this.AddressLine2)}");
            toStringOutput.Add($"this.AddressLine3 = {(this.AddressLine3 == null ? "null" : this.AddressLine3 == string.Empty ? "" : this.AddressLine3)}");
            toStringOutput.Add($"this.Locality = {(this.Locality == null ? "null" : this.Locality == string.Empty ? "" : this.Locality)}");
            toStringOutput.Add($"this.Sublocality = {(this.Sublocality == null ? "null" : this.Sublocality == string.Empty ? "" : this.Sublocality)}");
            toStringOutput.Add($"this.AdministrativeDistrictLevel1 = {(this.AdministrativeDistrictLevel1 == null ? "null" : this.AdministrativeDistrictLevel1 == string.Empty ? "" : this.AdministrativeDistrictLevel1)}");
            toStringOutput.Add($"this.PostalCode = {(this.PostalCode == null ? "null" : this.PostalCode == string.Empty ? "" : this.PostalCode)}");
            toStringOutput.Add($"this.Country = {(this.Country == null ? "null" : this.Country.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AddressLine1(this.AddressLine1)
                .AddressLine2(this.AddressLine2)
                .AddressLine3(this.AddressLine3)
                .Locality(this.Locality)
                .Sublocality(this.Sublocality)
                .AdministrativeDistrictLevel1(this.AdministrativeDistrictLevel1)
                .PostalCode(this.PostalCode)
                .Country(this.Country);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string addressLine1;
            private string addressLine2;
            private string addressLine3;
            private string locality;
            private string sublocality;
            private string administrativeDistrictLevel1;
            private string postalCode;
            private string country;

             /// <summary>
             /// AddressLine1.
             /// </summary>
             /// <param name="addressLine1"> addressLine1. </param>
             /// <returns> Builder. </returns>
            public Builder AddressLine1(string addressLine1)
            {
                this.addressLine1 = addressLine1;
                return this;
            }

             /// <summary>
             /// AddressLine2.
             /// </summary>
             /// <param name="addressLine2"> addressLine2. </param>
             /// <returns> Builder. </returns>
            public Builder AddressLine2(string addressLine2)
            {
                this.addressLine2 = addressLine2;
                return this;
            }

             /// <summary>
             /// AddressLine3.
             /// </summary>
             /// <param name="addressLine3"> addressLine3. </param>
             /// <returns> Builder. </returns>
            public Builder AddressLine3(string addressLine3)
            {
                this.addressLine3 = addressLine3;
                return this;
            }

             /// <summary>
             /// Locality.
             /// </summary>
             /// <param name="locality"> locality. </param>
             /// <returns> Builder. </returns>
            public Builder Locality(string locality)
            {
                this.locality = locality;
                return this;
            }

             /// <summary>
             /// Sublocality.
             /// </summary>
             /// <param name="sublocality"> sublocality. </param>
             /// <returns> Builder. </returns>
            public Builder Sublocality(string sublocality)
            {
                this.sublocality = sublocality;
                return this;
            }

             /// <summary>
             /// AdministrativeDistrictLevel1.
             /// </summary>
             /// <param name="administrativeDistrictLevel1"> administrativeDistrictLevel1. </param>
             /// <returns> Builder. </returns>
            public Builder AdministrativeDistrictLevel1(string administrativeDistrictLevel1)
            {
                this.administrativeDistrictLevel1 = administrativeDistrictLevel1;
                return this;
            }

             /// <summary>
             /// PostalCode.
             /// </summary>
             /// <param name="postalCode"> postalCode. </param>
             /// <returns> Builder. </returns>
            public Builder PostalCode(string postalCode)
            {
                this.postalCode = postalCode;
                return this;
            }

             /// <summary>
             /// Country.
             /// </summary>
             /// <param name="country"> country. </param>
             /// <returns> Builder. </returns>
            public Builder Country(string country)
            {
                this.country = country;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Address. </returns>
            public Address Build()
            {
                return new Address(
                    this.addressLine1,
                    this.addressLine2,
                    this.addressLine3,
                    this.locality,
                    this.sublocality,
                    this.administrativeDistrictLevel1,
                    this.postalCode,
                    this.country);
            }
        }
    }
}