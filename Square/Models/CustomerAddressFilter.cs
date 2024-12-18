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
    /// CustomerAddressFilter.
    /// </summary>
    public class CustomerAddressFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAddressFilter"/> class.
        /// </summary>
        /// <param name="postalCode">postal_code.</param>
        /// <param name="country">country.</param>
        public CustomerAddressFilter(
            Models.CustomerTextFilter postalCode = null,
            string country = null)
        {
            this.PostalCode = postalCode;
            this.Country = country;
        }

        /// <summary>
        /// A filter to select customers based on exact or fuzzy matching of
        /// customer attributes against a specified query. Depending on the customer attributes,
        /// the filter can be case-sensitive. This filter can be exact or fuzzy, but it cannot be both.
        /// </summary>
        [JsonProperty("postal_code", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerTextFilter PostalCode { get; }

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
            return $"CustomerAddressFilter : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CustomerAddressFilter other &&
                (this.PostalCode == null && other.PostalCode == null ||
                 this.PostalCode?.Equals(other.PostalCode) == true) &&
                (this.Country == null && other.Country == null ||
                 this.Country?.Equals(other.Country) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1115755655;
            hashCode = HashCode.Combine(hashCode, this.PostalCode, this.Country);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PostalCode = {(this.PostalCode == null ? "null" : this.PostalCode.ToString())}");
            toStringOutput.Add($"this.Country = {(this.Country == null ? "null" : this.Country.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .PostalCode(this.PostalCode)
                .Country(this.Country);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.CustomerTextFilter postalCode;
            private string country;

             /// <summary>
             /// PostalCode.
             /// </summary>
             /// <param name="postalCode"> postalCode. </param>
             /// <returns> Builder. </returns>
            public Builder PostalCode(Models.CustomerTextFilter postalCode)
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
            /// <returns> CustomerAddressFilter. </returns>
            public CustomerAddressFilter Build()
            {
                return new CustomerAddressFilter(
                    this.postalCode,
                    this.country);
            }
        }
    }
}