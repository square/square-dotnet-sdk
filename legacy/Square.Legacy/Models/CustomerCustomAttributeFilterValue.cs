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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// CustomerCustomAttributeFilterValue.
    /// </summary>
    public class CustomerCustomAttributeFilterValue
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCustomAttributeFilterValue"/> class.
        /// </summary>
        /// <param name="email">email.</param>
        /// <param name="phone">phone.</param>
        /// <param name="text">text.</param>
        /// <param name="selection">selection.</param>
        /// <param name="date">date.</param>
        /// <param name="number">number.</param>
        /// <param name="boolean">boolean.</param>
        /// <param name="address">address.</param>
        public CustomerCustomAttributeFilterValue(
            Models.CustomerTextFilter email = null,
            Models.CustomerTextFilter phone = null,
            Models.CustomerTextFilter text = null,
            Models.FilterValue selection = null,
            Models.TimeRange date = null,
            Models.FloatNumberRange number = null,
            bool? boolean = null,
            Models.CustomerAddressFilter address = null
        )
        {
            shouldSerialize = new Dictionary<string, bool> { { "boolean", false } };
            this.Email = email;
            this.Phone = phone;
            this.Text = text;
            this.Selection = selection;
            this.Date = date;
            this.Number = number;

            if (boolean != null)
            {
                shouldSerialize["boolean"] = true;
                this.Boolean = boolean;
            }
            this.Address = address;
        }

        internal CustomerCustomAttributeFilterValue(
            Dictionary<string, bool> shouldSerialize,
            Models.CustomerTextFilter email = null,
            Models.CustomerTextFilter phone = null,
            Models.CustomerTextFilter text = null,
            Models.FilterValue selection = null,
            Models.TimeRange date = null,
            Models.FloatNumberRange number = null,
            bool? boolean = null,
            Models.CustomerAddressFilter address = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Email = email;
            Phone = phone;
            Text = text;
            Selection = selection;
            Date = date;
            Number = number;
            Boolean = boolean;
            Address = address;
        }

        /// <summary>
        /// A filter to select customers based on exact or fuzzy matching of
        /// customer attributes against a specified query. Depending on the customer attributes,
        /// the filter can be case-sensitive. This filter can be exact or fuzzy, but it cannot be both.
        /// </summary>
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerTextFilter Email { get; }

        /// <summary>
        /// A filter to select customers based on exact or fuzzy matching of
        /// customer attributes against a specified query. Depending on the customer attributes,
        /// the filter can be case-sensitive. This filter can be exact or fuzzy, but it cannot be both.
        /// </summary>
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerTextFilter Phone { get; }

        /// <summary>
        /// A filter to select customers based on exact or fuzzy matching of
        /// customer attributes against a specified query. Depending on the customer attributes,
        /// the filter can be case-sensitive. This filter can be exact or fuzzy, but it cannot be both.
        /// </summary>
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerTextFilter Text { get; }

        /// <summary>
        /// A filter to select resources based on an exact field value. For any given
        /// value, the value can only be in one property. Depending on the field, either
        /// all properties can be set or only a subset will be available.
        /// Refer to the documentation of the field.
        /// </summary>
        [JsonProperty("selection", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FilterValue Selection { get; }

        /// <summary>
        /// Represents a generic time range. The start and end values are
        /// represented in RFC 3339 format. Time ranges are customized to be
        /// inclusive or exclusive based on the needs of a particular endpoint.
        /// Refer to the relevant endpoint-specific documentation to determine
        /// how time ranges are handled.
        /// </summary>
        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TimeRange Date { get; }

        /// <summary>
        /// Specifies a decimal number range.
        /// </summary>
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FloatNumberRange Number { get; }

        /// <summary>
        /// A filter for a query based on the value of a `Boolean`-type custom attribute.
        /// </summary>
        [JsonProperty("boolean")]
        public bool? Boolean { get; }

        /// <summary>
        /// The customer address filter. This filter is used in a [CustomerCustomAttributeFilterValue]($m/CustomerCustomAttributeFilterValue) filter when
        /// searching by an `Address`-type custom attribute.
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerAddressFilter Address { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CustomerCustomAttributeFilterValue : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBoolean()
        {
            return this.shouldSerialize["boolean"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CustomerCustomAttributeFilterValue other
                && (
                    this.Email == null && other.Email == null
                    || this.Email?.Equals(other.Email) == true
                )
                && (
                    this.Phone == null && other.Phone == null
                    || this.Phone?.Equals(other.Phone) == true
                )
                && (
                    this.Text == null && other.Text == null || this.Text?.Equals(other.Text) == true
                )
                && (
                    this.Selection == null && other.Selection == null
                    || this.Selection?.Equals(other.Selection) == true
                )
                && (
                    this.Date == null && other.Date == null || this.Date?.Equals(other.Date) == true
                )
                && (
                    this.Number == null && other.Number == null
                    || this.Number?.Equals(other.Number) == true
                )
                && (
                    this.Boolean == null && other.Boolean == null
                    || this.Boolean?.Equals(other.Boolean) == true
                )
                && (
                    this.Address == null && other.Address == null
                    || this.Address?.Equals(other.Address) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -907077881;
            hashCode = HashCode.Combine(
                hashCode,
                this.Email,
                this.Phone,
                this.Text,
                this.Selection,
                this.Date,
                this.Number,
                this.Boolean
            );

            hashCode = HashCode.Combine(hashCode, this.Address);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Email = {(this.Email == null ? "null" : this.Email.ToString())}"
            );
            toStringOutput.Add(
                $"this.Phone = {(this.Phone == null ? "null" : this.Phone.ToString())}"
            );
            toStringOutput.Add(
                $"this.Text = {(this.Text == null ? "null" : this.Text.ToString())}"
            );
            toStringOutput.Add(
                $"this.Selection = {(this.Selection == null ? "null" : this.Selection.ToString())}"
            );
            toStringOutput.Add(
                $"this.Date = {(this.Date == null ? "null" : this.Date.ToString())}"
            );
            toStringOutput.Add(
                $"this.Number = {(this.Number == null ? "null" : this.Number.ToString())}"
            );
            toStringOutput.Add(
                $"this.Boolean = {(this.Boolean == null ? "null" : this.Boolean.ToString())}"
            );
            toStringOutput.Add(
                $"this.Address = {(this.Address == null ? "null" : this.Address.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Email(this.Email)
                .Phone(this.Phone)
                .Text(this.Text)
                .Selection(this.Selection)
                .Date(this.Date)
                .Number(this.Number)
                .Boolean(this.Boolean)
                .Address(this.Address);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "boolean", false },
            };

            private Models.CustomerTextFilter email;
            private Models.CustomerTextFilter phone;
            private Models.CustomerTextFilter text;
            private Models.FilterValue selection;
            private Models.TimeRange date;
            private Models.FloatNumberRange number;
            private bool? boolean;
            private Models.CustomerAddressFilter address;

            /// <summary>
            /// Email.
            /// </summary>
            /// <param name="email"> email. </param>
            /// <returns> Builder. </returns>
            public Builder Email(Models.CustomerTextFilter email)
            {
                this.email = email;
                return this;
            }

            /// <summary>
            /// Phone.
            /// </summary>
            /// <param name="phone"> phone. </param>
            /// <returns> Builder. </returns>
            public Builder Phone(Models.CustomerTextFilter phone)
            {
                this.phone = phone;
                return this;
            }

            /// <summary>
            /// Text.
            /// </summary>
            /// <param name="text"> text. </param>
            /// <returns> Builder. </returns>
            public Builder Text(Models.CustomerTextFilter text)
            {
                this.text = text;
                return this;
            }

            /// <summary>
            /// Selection.
            /// </summary>
            /// <param name="selection"> selection. </param>
            /// <returns> Builder. </returns>
            public Builder Selection(Models.FilterValue selection)
            {
                this.selection = selection;
                return this;
            }

            /// <summary>
            /// Date.
            /// </summary>
            /// <param name="date"> date. </param>
            /// <returns> Builder. </returns>
            public Builder Date(Models.TimeRange date)
            {
                this.date = date;
                return this;
            }

            /// <summary>
            /// Number.
            /// </summary>
            /// <param name="number"> number. </param>
            /// <returns> Builder. </returns>
            public Builder Number(Models.FloatNumberRange number)
            {
                this.number = number;
                return this;
            }

            /// <summary>
            /// Boolean.
            /// </summary>
            /// <param name="boolean"> boolean. </param>
            /// <returns> Builder. </returns>
            public Builder Boolean(bool? boolean)
            {
                shouldSerialize["boolean"] = true;
                this.boolean = boolean;
                return this;
            }

            /// <summary>
            /// Address.
            /// </summary>
            /// <param name="address"> address. </param>
            /// <returns> Builder. </returns>
            public Builder Address(Models.CustomerAddressFilter address)
            {
                this.address = address;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetBoolean()
            {
                this.shouldSerialize["boolean"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CustomerCustomAttributeFilterValue. </returns>
            public CustomerCustomAttributeFilterValue Build()
            {
                return new CustomerCustomAttributeFilterValue(
                    shouldSerialize,
                    this.email,
                    this.phone,
                    this.text,
                    this.selection,
                    this.date,
                    this.number,
                    this.boolean,
                    this.address
                );
            }
        }
    }
}
