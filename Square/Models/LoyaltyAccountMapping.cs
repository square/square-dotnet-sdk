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
    /// LoyaltyAccountMapping.
    /// </summary>
    public class LoyaltyAccountMapping
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyAccountMapping"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="type">type.</param>
        /// <param name="mValue">value.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="phoneNumber">phone_number.</param>
        public LoyaltyAccountMapping(
            string id = null,
            string type = null,
            string mValue = null,
            string createdAt = null,
            string phoneNumber = null)
        {
            this.Id = id;
            this.Type = type;
            this.MValue = mValue;
            this.CreatedAt = createdAt;
            this.PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// The Square-assigned ID of the mapping.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The type of mapping.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// The mapping value, which is used with `type` to represent a phone number mapping. The value can be a phone number in E.164 format. For example, "+14155551111".
        /// When specifying a mapping, the `phone_number` field is preferred to using `type` and `value`.
        /// </summary>
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string MValue { get; }

        /// <summary>
        /// The timestamp when the mapping was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The phone number of the buyer, in E.164 format. For example, "+14155551111".
        /// When specifying a mapping, this `phone_number` field is preferred to using `type` and `value`.
        /// </summary>
        [JsonProperty("phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyAccountMapping : ({string.Join(", ", toStringOutput)})";
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

            return obj is LoyaltyAccountMapping other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.MValue == null && other.MValue == null) || (this.MValue?.Equals(other.MValue) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1236695962;

            if (this.Id != null)
            {
               hashCode += this.Id.GetHashCode();
            }

            if (this.Type != null)
            {
               hashCode += this.Type.GetHashCode();
            }

            if (this.MValue != null)
            {
               hashCode += this.MValue.GetHashCode();
            }

            if (this.CreatedAt != null)
            {
               hashCode += this.CreatedAt.GetHashCode();
            }

            if (this.PhoneNumber != null)
            {
               hashCode += this.PhoneNumber.GetHashCode();
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
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.MValue = {(this.MValue == null ? "null" : this.MValue == string.Empty ? "" : this.MValue)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.PhoneNumber = {(this.PhoneNumber == null ? "null" : this.PhoneNumber == string.Empty ? "" : this.PhoneNumber)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .Type(this.Type)
                .MValue(this.MValue)
                .CreatedAt(this.CreatedAt)
                .PhoneNumber(this.PhoneNumber);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string id;
            private string type;
            private string mValue;
            private string createdAt;
            private string phoneNumber;

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
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// MValue.
             /// </summary>
             /// <param name="mValue"> mValue. </param>
             /// <returns> Builder. </returns>
            public Builder MValue(string mValue)
            {
                this.mValue = mValue;
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
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyAccountMapping. </returns>
            public LoyaltyAccountMapping Build()
            {
                return new LoyaltyAccountMapping(
                    this.id,
                    this.type,
                    this.mValue,
                    this.createdAt,
                    this.phoneNumber);
            }
        }
    }
}