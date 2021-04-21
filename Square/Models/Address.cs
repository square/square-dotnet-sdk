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
        /// <param name="sublocality2">sublocality_2.</param>
        /// <param name="sublocality3">sublocality_3.</param>
        /// <param name="administrativeDistrictLevel1">administrative_district_level_1.</param>
        /// <param name="administrativeDistrictLevel2">administrative_district_level_2.</param>
        /// <param name="administrativeDistrictLevel3">administrative_district_level_3.</param>
        /// <param name="postalCode">postal_code.</param>
        /// <param name="country">country.</param>
        /// <param name="firstName">first_name.</param>
        /// <param name="lastName">last_name.</param>
        /// <param name="organization">organization.</param>
        public Address(
            string addressLine1 = null,
            string addressLine2 = null,
            string addressLine3 = null,
            string locality = null,
            string sublocality = null,
            string sublocality2 = null,
            string sublocality3 = null,
            string administrativeDistrictLevel1 = null,
            string administrativeDistrictLevel2 = null,
            string administrativeDistrictLevel3 = null,
            string postalCode = null,
            string country = null,
            string firstName = null,
            string lastName = null,
            string organization = null)
        {
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.AddressLine3 = addressLine3;
            this.Locality = locality;
            this.Sublocality = sublocality;
            this.Sublocality2 = sublocality2;
            this.Sublocality3 = sublocality3;
            this.AdministrativeDistrictLevel1 = administrativeDistrictLevel1;
            this.AdministrativeDistrictLevel2 = administrativeDistrictLevel2;
            this.AdministrativeDistrictLevel3 = administrativeDistrictLevel3;
            this.PostalCode = postalCode;
            this.Country = country;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Organization = organization;
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
        /// The city or town of the address.
        /// </summary>
        [JsonProperty("locality", NullValueHandling = NullValueHandling.Ignore)]
        public string Locality { get; }

        /// <summary>
        /// A civil region within the address's `locality`, if any.
        /// </summary>
        [JsonProperty("sublocality", NullValueHandling = NullValueHandling.Ignore)]
        public string Sublocality { get; }

        /// <summary>
        /// A civil region within the address's `sublocality`, if any.
        /// </summary>
        [JsonProperty("sublocality_2", NullValueHandling = NullValueHandling.Ignore)]
        public string Sublocality2 { get; }

        /// <summary>
        /// A civil region within the address's `sublocality_2`, if any.
        /// </summary>
        [JsonProperty("sublocality_3", NullValueHandling = NullValueHandling.Ignore)]
        public string Sublocality3 { get; }

        /// <summary>
        /// A civil entity within the address's country. In the US, this
        /// is the state.
        /// </summary>
        [JsonProperty("administrative_district_level_1", NullValueHandling = NullValueHandling.Ignore)]
        public string AdministrativeDistrictLevel1 { get; }

        /// <summary>
        /// A civil entity within the address's `administrative_district_level_1`.
        /// In the US, this is the county.
        /// </summary>
        [JsonProperty("administrative_district_level_2", NullValueHandling = NullValueHandling.Ignore)]
        public string AdministrativeDistrictLevel2 { get; }

        /// <summary>
        /// A civil entity within the address's `administrative_district_level_2`,
        /// if any.
        /// </summary>
        [JsonProperty("administrative_district_level_3", NullValueHandling = NullValueHandling.Ignore)]
        public string AdministrativeDistrictLevel3 { get; }

        /// <summary>
        /// The address's postal code.
        /// </summary>
        [JsonProperty("postal_code", NullValueHandling = NullValueHandling.Ignore)]
        public string PostalCode { get; }

        /// <summary>
        /// Indicates the country associated with another entity, such as a business.
        /// Values are in [ISO 3166-1-alpha-2 format](http://www.iso.org/iso/home/standards/country_codes.htm).
        /// </summary>
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; }

        /// <summary>
        /// Optional first name when it's representing recipient.
        /// </summary>
        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; }

        /// <summary>
        /// Optional last name when it's representing recipient.
        /// </summary>
        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; }

        /// <summary>
        /// Optional organization name when it's representing recipient.
        /// </summary>
        [JsonProperty("organization", NullValueHandling = NullValueHandling.Ignore)]
        public string Organization { get; }

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
                ((this.Sublocality2 == null && other.Sublocality2 == null) || (this.Sublocality2?.Equals(other.Sublocality2) == true)) &&
                ((this.Sublocality3 == null && other.Sublocality3 == null) || (this.Sublocality3?.Equals(other.Sublocality3) == true)) &&
                ((this.AdministrativeDistrictLevel1 == null && other.AdministrativeDistrictLevel1 == null) || (this.AdministrativeDistrictLevel1?.Equals(other.AdministrativeDistrictLevel1) == true)) &&
                ((this.AdministrativeDistrictLevel2 == null && other.AdministrativeDistrictLevel2 == null) || (this.AdministrativeDistrictLevel2?.Equals(other.AdministrativeDistrictLevel2) == true)) &&
                ((this.AdministrativeDistrictLevel3 == null && other.AdministrativeDistrictLevel3 == null) || (this.AdministrativeDistrictLevel3?.Equals(other.AdministrativeDistrictLevel3) == true)) &&
                ((this.PostalCode == null && other.PostalCode == null) || (this.PostalCode?.Equals(other.PostalCode) == true)) &&
                ((this.Country == null && other.Country == null) || (this.Country?.Equals(other.Country) == true)) &&
                ((this.FirstName == null && other.FirstName == null) || (this.FirstName?.Equals(other.FirstName) == true)) &&
                ((this.LastName == null && other.LastName == null) || (this.LastName?.Equals(other.LastName) == true)) &&
                ((this.Organization == null && other.Organization == null) || (this.Organization?.Equals(other.Organization) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1623438759;

            if (this.AddressLine1 != null)
            {
               hashCode += this.AddressLine1.GetHashCode();
            }

            if (this.AddressLine2 != null)
            {
               hashCode += this.AddressLine2.GetHashCode();
            }

            if (this.AddressLine3 != null)
            {
               hashCode += this.AddressLine3.GetHashCode();
            }

            if (this.Locality != null)
            {
               hashCode += this.Locality.GetHashCode();
            }

            if (this.Sublocality != null)
            {
               hashCode += this.Sublocality.GetHashCode();
            }

            if (this.Sublocality2 != null)
            {
               hashCode += this.Sublocality2.GetHashCode();
            }

            if (this.Sublocality3 != null)
            {
               hashCode += this.Sublocality3.GetHashCode();
            }

            if (this.AdministrativeDistrictLevel1 != null)
            {
               hashCode += this.AdministrativeDistrictLevel1.GetHashCode();
            }

            if (this.AdministrativeDistrictLevel2 != null)
            {
               hashCode += this.AdministrativeDistrictLevel2.GetHashCode();
            }

            if (this.AdministrativeDistrictLevel3 != null)
            {
               hashCode += this.AdministrativeDistrictLevel3.GetHashCode();
            }

            if (this.PostalCode != null)
            {
               hashCode += this.PostalCode.GetHashCode();
            }

            if (this.Country != null)
            {
               hashCode += this.Country.GetHashCode();
            }

            if (this.FirstName != null)
            {
               hashCode += this.FirstName.GetHashCode();
            }

            if (this.LastName != null)
            {
               hashCode += this.LastName.GetHashCode();
            }

            if (this.Organization != null)
            {
               hashCode += this.Organization.GetHashCode();
            }

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
            toStringOutput.Add($"this.Sublocality2 = {(this.Sublocality2 == null ? "null" : this.Sublocality2 == string.Empty ? "" : this.Sublocality2)}");
            toStringOutput.Add($"this.Sublocality3 = {(this.Sublocality3 == null ? "null" : this.Sublocality3 == string.Empty ? "" : this.Sublocality3)}");
            toStringOutput.Add($"this.AdministrativeDistrictLevel1 = {(this.AdministrativeDistrictLevel1 == null ? "null" : this.AdministrativeDistrictLevel1 == string.Empty ? "" : this.AdministrativeDistrictLevel1)}");
            toStringOutput.Add($"this.AdministrativeDistrictLevel2 = {(this.AdministrativeDistrictLevel2 == null ? "null" : this.AdministrativeDistrictLevel2 == string.Empty ? "" : this.AdministrativeDistrictLevel2)}");
            toStringOutput.Add($"this.AdministrativeDistrictLevel3 = {(this.AdministrativeDistrictLevel3 == null ? "null" : this.AdministrativeDistrictLevel3 == string.Empty ? "" : this.AdministrativeDistrictLevel3)}");
            toStringOutput.Add($"this.PostalCode = {(this.PostalCode == null ? "null" : this.PostalCode == string.Empty ? "" : this.PostalCode)}");
            toStringOutput.Add($"this.Country = {(this.Country == null ? "null" : this.Country.ToString())}");
            toStringOutput.Add($"this.FirstName = {(this.FirstName == null ? "null" : this.FirstName == string.Empty ? "" : this.FirstName)}");
            toStringOutput.Add($"this.LastName = {(this.LastName == null ? "null" : this.LastName == string.Empty ? "" : this.LastName)}");
            toStringOutput.Add($"this.Organization = {(this.Organization == null ? "null" : this.Organization == string.Empty ? "" : this.Organization)}");
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
                .Sublocality2(this.Sublocality2)
                .Sublocality3(this.Sublocality3)
                .AdministrativeDistrictLevel1(this.AdministrativeDistrictLevel1)
                .AdministrativeDistrictLevel2(this.AdministrativeDistrictLevel2)
                .AdministrativeDistrictLevel3(this.AdministrativeDistrictLevel3)
                .PostalCode(this.PostalCode)
                .Country(this.Country)
                .FirstName(this.FirstName)
                .LastName(this.LastName)
                .Organization(this.Organization);
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
            private string sublocality2;
            private string sublocality3;
            private string administrativeDistrictLevel1;
            private string administrativeDistrictLevel2;
            private string administrativeDistrictLevel3;
            private string postalCode;
            private string country;
            private string firstName;
            private string lastName;
            private string organization;

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
             /// Sublocality2.
             /// </summary>
             /// <param name="sublocality2"> sublocality2. </param>
             /// <returns> Builder. </returns>
            public Builder Sublocality2(string sublocality2)
            {
                this.sublocality2 = sublocality2;
                return this;
            }

             /// <summary>
             /// Sublocality3.
             /// </summary>
             /// <param name="sublocality3"> sublocality3. </param>
             /// <returns> Builder. </returns>
            public Builder Sublocality3(string sublocality3)
            {
                this.sublocality3 = sublocality3;
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
             /// AdministrativeDistrictLevel2.
             /// </summary>
             /// <param name="administrativeDistrictLevel2"> administrativeDistrictLevel2. </param>
             /// <returns> Builder. </returns>
            public Builder AdministrativeDistrictLevel2(string administrativeDistrictLevel2)
            {
                this.administrativeDistrictLevel2 = administrativeDistrictLevel2;
                return this;
            }

             /// <summary>
             /// AdministrativeDistrictLevel3.
             /// </summary>
             /// <param name="administrativeDistrictLevel3"> administrativeDistrictLevel3. </param>
             /// <returns> Builder. </returns>
            public Builder AdministrativeDistrictLevel3(string administrativeDistrictLevel3)
            {
                this.administrativeDistrictLevel3 = administrativeDistrictLevel3;
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
             /// Organization.
             /// </summary>
             /// <param name="organization"> organization. </param>
             /// <returns> Builder. </returns>
            public Builder Organization(string organization)
            {
                this.organization = organization;
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
                    this.sublocality2,
                    this.sublocality3,
                    this.administrativeDistrictLevel1,
                    this.administrativeDistrictLevel2,
                    this.administrativeDistrictLevel3,
                    this.postalCode,
                    this.country,
                    this.firstName,
                    this.lastName,
                    this.organization);
            }
        }
    }
}