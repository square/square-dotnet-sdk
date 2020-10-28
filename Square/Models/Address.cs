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
    public class Address 
    {
        public Address(string addressLine1 = null,
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
            Organization = organization;
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

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AddressLine1(AddressLine1)
                .AddressLine2(AddressLine2)
                .AddressLine3(AddressLine3)
                .Locality(Locality)
                .Sublocality(Sublocality)
                .Sublocality2(Sublocality2)
                .Sublocality3(Sublocality3)
                .AdministrativeDistrictLevel1(AdministrativeDistrictLevel1)
                .AdministrativeDistrictLevel2(AdministrativeDistrictLevel2)
                .AdministrativeDistrictLevel3(AdministrativeDistrictLevel3)
                .PostalCode(PostalCode)
                .Country(Country)
                .FirstName(FirstName)
                .LastName(LastName)
                .Organization(Organization);
            return builder;
        }

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



            public Builder AddressLine1(string addressLine1)
            {
                this.addressLine1 = addressLine1;
                return this;
            }

            public Builder AddressLine2(string addressLine2)
            {
                this.addressLine2 = addressLine2;
                return this;
            }

            public Builder AddressLine3(string addressLine3)
            {
                this.addressLine3 = addressLine3;
                return this;
            }

            public Builder Locality(string locality)
            {
                this.locality = locality;
                return this;
            }

            public Builder Sublocality(string sublocality)
            {
                this.sublocality = sublocality;
                return this;
            }

            public Builder Sublocality2(string sublocality2)
            {
                this.sublocality2 = sublocality2;
                return this;
            }

            public Builder Sublocality3(string sublocality3)
            {
                this.sublocality3 = sublocality3;
                return this;
            }

            public Builder AdministrativeDistrictLevel1(string administrativeDistrictLevel1)
            {
                this.administrativeDistrictLevel1 = administrativeDistrictLevel1;
                return this;
            }

            public Builder AdministrativeDistrictLevel2(string administrativeDistrictLevel2)
            {
                this.administrativeDistrictLevel2 = administrativeDistrictLevel2;
                return this;
            }

            public Builder AdministrativeDistrictLevel3(string administrativeDistrictLevel3)
            {
                this.administrativeDistrictLevel3 = administrativeDistrictLevel3;
                return this;
            }

            public Builder PostalCode(string postalCode)
            {
                this.postalCode = postalCode;
                return this;
            }

            public Builder Country(string country)
            {
                this.country = country;
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

            public Builder Organization(string organization)
            {
                this.organization = organization;
                return this;
            }

            public Address Build()
            {
                return new Address(addressLine1,
                    addressLine2,
                    addressLine3,
                    locality,
                    sublocality,
                    sublocality2,
                    sublocality3,
                    administrativeDistrictLevel1,
                    administrativeDistrictLevel2,
                    administrativeDistrictLevel3,
                    postalCode,
                    country,
                    firstName,
                    lastName,
                    organization);
            }
        }
    }
}