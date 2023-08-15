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
    /// Address.
    /// </summary>
    public class Address
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
            string lastName = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "address_line_1", false },
                { "address_line_2", false },
                { "address_line_3", false },
                { "locality", false },
                { "sublocality", false },
                { "sublocality_2", false },
                { "sublocality_3", false },
                { "administrative_district_level_1", false },
                { "administrative_district_level_2", false },
                { "administrative_district_level_3", false },
                { "postal_code", false },
                { "first_name", false },
                { "last_name", false }
            };

            if (addressLine1 != null)
            {
                shouldSerialize["address_line_1"] = true;
                this.AddressLine1 = addressLine1;
            }

            if (addressLine2 != null)
            {
                shouldSerialize["address_line_2"] = true;
                this.AddressLine2 = addressLine2;
            }

            if (addressLine3 != null)
            {
                shouldSerialize["address_line_3"] = true;
                this.AddressLine3 = addressLine3;
            }

            if (locality != null)
            {
                shouldSerialize["locality"] = true;
                this.Locality = locality;
            }

            if (sublocality != null)
            {
                shouldSerialize["sublocality"] = true;
                this.Sublocality = sublocality;
            }

            if (sublocality2 != null)
            {
                shouldSerialize["sublocality_2"] = true;
                this.Sublocality2 = sublocality2;
            }

            if (sublocality3 != null)
            {
                shouldSerialize["sublocality_3"] = true;
                this.Sublocality3 = sublocality3;
            }

            if (administrativeDistrictLevel1 != null)
            {
                shouldSerialize["administrative_district_level_1"] = true;
                this.AdministrativeDistrictLevel1 = administrativeDistrictLevel1;
            }

            if (administrativeDistrictLevel2 != null)
            {
                shouldSerialize["administrative_district_level_2"] = true;
                this.AdministrativeDistrictLevel2 = administrativeDistrictLevel2;
            }

            if (administrativeDistrictLevel3 != null)
            {
                shouldSerialize["administrative_district_level_3"] = true;
                this.AdministrativeDistrictLevel3 = administrativeDistrictLevel3;
            }

            if (postalCode != null)
            {
                shouldSerialize["postal_code"] = true;
                this.PostalCode = postalCode;
            }

            this.Country = country;
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

        }
        internal Address(Dictionary<string, bool> shouldSerialize,
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
            string lastName = null)
        {
            this.shouldSerialize = shouldSerialize;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            AddressLine3 = addressLine3;
            Locality = locality;
            Sublocality = sublocality;
            Sublocality2 = sublocality2;
            Sublocality3 = sublocality3;
            AdministrativeDistrictLevel1 = administrativeDistrictLevel1;
            AdministrativeDistrictLevel2 = administrativeDistrictLevel2;
            AdministrativeDistrictLevel3 = administrativeDistrictLevel3;
            PostalCode = postalCode;
            Country = country;
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// The first line of the address.
        /// Fields that start with `address_line` provide the address's most specific
        /// details, like street number, street name, and building name. They do *not*
        /// provide less specific details like city, state/province, or country (these
        /// details are provided in other fields).
        /// </summary>
        [JsonProperty("address_line_1")]
        public string AddressLine1 { get; }

        /// <summary>
        /// The second line of the address, if any.
        /// </summary>
        [JsonProperty("address_line_2")]
        public string AddressLine2 { get; }

        /// <summary>
        /// The third line of the address, if any.
        /// </summary>
        [JsonProperty("address_line_3")]
        public string AddressLine3 { get; }

        /// <summary>
        /// The city or town of the address. For a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        /// </summary>
        [JsonProperty("locality")]
        public string Locality { get; }

        /// <summary>
        /// A civil region within the address's `locality`, if any.
        /// </summary>
        [JsonProperty("sublocality")]
        public string Sublocality { get; }

        /// <summary>
        /// A civil region within the address's `sublocality`, if any.
        /// </summary>
        [JsonProperty("sublocality_2")]
        public string Sublocality2 { get; }

        /// <summary>
        /// A civil region within the address's `sublocality_2`, if any.
        /// </summary>
        [JsonProperty("sublocality_3")]
        public string Sublocality3 { get; }

        /// <summary>
        /// A civil entity within the address's country. In the US, this
        /// is the state. For a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        /// </summary>
        [JsonProperty("administrative_district_level_1")]
        public string AdministrativeDistrictLevel1 { get; }

        /// <summary>
        /// A civil entity within the address's `administrative_district_level_1`.
        /// In the US, this is the county.
        /// </summary>
        [JsonProperty("administrative_district_level_2")]
        public string AdministrativeDistrictLevel2 { get; }

        /// <summary>
        /// A civil entity within the address's `administrative_district_level_2`,
        /// if any.
        /// </summary>
        [JsonProperty("administrative_district_level_3")]
        public string AdministrativeDistrictLevel3 { get; }

        /// <summary>
        /// The address's postal code. For a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        /// </summary>
        [JsonProperty("postal_code")]
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
        [JsonProperty("first_name")]
        public string FirstName { get; }

        /// <summary>
        /// Optional last name when it's representing recipient.
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Address : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAddressLine1()
        {
            return this.shouldSerialize["address_line_1"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAddressLine2()
        {
            return this.shouldSerialize["address_line_2"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAddressLine3()
        {
            return this.shouldSerialize["address_line_3"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocality()
        {
            return this.shouldSerialize["locality"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSublocality()
        {
            return this.shouldSerialize["sublocality"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSublocality2()
        {
            return this.shouldSerialize["sublocality_2"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSublocality3()
        {
            return this.shouldSerialize["sublocality_3"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAdministrativeDistrictLevel1()
        {
            return this.shouldSerialize["administrative_district_level_1"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAdministrativeDistrictLevel2()
        {
            return this.shouldSerialize["administrative_district_level_2"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAdministrativeDistrictLevel3()
        {
            return this.shouldSerialize["administrative_district_level_3"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePostalCode()
        {
            return this.shouldSerialize["postal_code"];
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
            return obj is Address other &&                ((this.AddressLine1 == null && other.AddressLine1 == null) || (this.AddressLine1?.Equals(other.AddressLine1) == true)) &&
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
                ((this.LastName == null && other.LastName == null) || (this.LastName?.Equals(other.LastName) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1866796447;
            hashCode = HashCode.Combine(this.AddressLine1, this.AddressLine2, this.AddressLine3, this.Locality, this.Sublocality, this.Sublocality2, this.Sublocality3);

            hashCode = HashCode.Combine(hashCode, this.AdministrativeDistrictLevel1, this.AdministrativeDistrictLevel2, this.AdministrativeDistrictLevel3, this.PostalCode, this.Country, this.FirstName, this.LastName);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AddressLine1 = {(this.AddressLine1 == null ? "null" : this.AddressLine1)}");
            toStringOutput.Add($"this.AddressLine2 = {(this.AddressLine2 == null ? "null" : this.AddressLine2)}");
            toStringOutput.Add($"this.AddressLine3 = {(this.AddressLine3 == null ? "null" : this.AddressLine3)}");
            toStringOutput.Add($"this.Locality = {(this.Locality == null ? "null" : this.Locality)}");
            toStringOutput.Add($"this.Sublocality = {(this.Sublocality == null ? "null" : this.Sublocality)}");
            toStringOutput.Add($"this.Sublocality2 = {(this.Sublocality2 == null ? "null" : this.Sublocality2)}");
            toStringOutput.Add($"this.Sublocality3 = {(this.Sublocality3 == null ? "null" : this.Sublocality3)}");
            toStringOutput.Add($"this.AdministrativeDistrictLevel1 = {(this.AdministrativeDistrictLevel1 == null ? "null" : this.AdministrativeDistrictLevel1)}");
            toStringOutput.Add($"this.AdministrativeDistrictLevel2 = {(this.AdministrativeDistrictLevel2 == null ? "null" : this.AdministrativeDistrictLevel2)}");
            toStringOutput.Add($"this.AdministrativeDistrictLevel3 = {(this.AdministrativeDistrictLevel3 == null ? "null" : this.AdministrativeDistrictLevel3)}");
            toStringOutput.Add($"this.PostalCode = {(this.PostalCode == null ? "null" : this.PostalCode)}");
            toStringOutput.Add($"this.Country = {(this.Country == null ? "null" : this.Country.ToString())}");
            toStringOutput.Add($"this.FirstName = {(this.FirstName == null ? "null" : this.FirstName)}");
            toStringOutput.Add($"this.LastName = {(this.LastName == null ? "null" : this.LastName)}");
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
                .LastName(this.LastName);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "address_line_1", false },
                { "address_line_2", false },
                { "address_line_3", false },
                { "locality", false },
                { "sublocality", false },
                { "sublocality_2", false },
                { "sublocality_3", false },
                { "administrative_district_level_1", false },
                { "administrative_district_level_2", false },
                { "administrative_district_level_3", false },
                { "postal_code", false },
                { "first_name", false },
                { "last_name", false },
            };

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

             /// <summary>
             /// AddressLine1.
             /// </summary>
             /// <param name="addressLine1"> addressLine1. </param>
             /// <returns> Builder. </returns>
            public Builder AddressLine1(string addressLine1)
            {
                shouldSerialize["address_line_1"] = true;
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
                shouldSerialize["address_line_2"] = true;
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
                shouldSerialize["address_line_3"] = true;
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
                shouldSerialize["locality"] = true;
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
                shouldSerialize["sublocality"] = true;
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
                shouldSerialize["sublocality_2"] = true;
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
                shouldSerialize["sublocality_3"] = true;
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
                shouldSerialize["administrative_district_level_1"] = true;
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
                shouldSerialize["administrative_district_level_2"] = true;
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
                shouldSerialize["administrative_district_level_3"] = true;
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
                shouldSerialize["postal_code"] = true;
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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAddressLine1()
            {
                this.shouldSerialize["address_line_1"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAddressLine2()
            {
                this.shouldSerialize["address_line_2"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAddressLine3()
            {
                this.shouldSerialize["address_line_3"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocality()
            {
                this.shouldSerialize["locality"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSublocality()
            {
                this.shouldSerialize["sublocality"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSublocality2()
            {
                this.shouldSerialize["sublocality_2"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSublocality3()
            {
                this.shouldSerialize["sublocality_3"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAdministrativeDistrictLevel1()
            {
                this.shouldSerialize["administrative_district_level_1"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAdministrativeDistrictLevel2()
            {
                this.shouldSerialize["administrative_district_level_2"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAdministrativeDistrictLevel3()
            {
                this.shouldSerialize["administrative_district_level_3"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPostalCode()
            {
                this.shouldSerialize["postal_code"] = false;
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
            /// Builds class object.
            /// </summary>
            /// <returns> Address. </returns>
            public Address Build()
            {
                return new Address(shouldSerialize,
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
                    this.lastName);
            }
        }
    }
}