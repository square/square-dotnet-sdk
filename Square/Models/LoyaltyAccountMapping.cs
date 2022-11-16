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
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyAccountMapping"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="phoneNumber">phone_number.</param>
        public LoyaltyAccountMapping(
            string id = null,
            string createdAt = null,
            string phoneNumber = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "phone_number", false }
            };

            this.Id = id;
            this.CreatedAt = createdAt;
            if (phoneNumber != null)
            {
                shouldSerialize["phone_number"] = true;
                this.PhoneNumber = phoneNumber;
            }

        }
        internal LoyaltyAccountMapping(Dictionary<string, bool> shouldSerialize,
            string id = null,
            string createdAt = null,
            string phoneNumber = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            CreatedAt = createdAt;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// The Square-assigned ID of the mapping.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The timestamp when the mapping was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The phone number of the buyer, in E.164 format. For example, "+14155551111".
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyAccountMapping : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePhoneNumber()
        {
            return this.shouldSerialize["phone_number"];
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
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.PhoneNumber == null && other.PhoneNumber == null) || (this.PhoneNumber?.Equals(other.PhoneNumber) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -516821165;
            hashCode = HashCode.Combine(this.Id, this.CreatedAt, this.PhoneNumber);

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
                .CreatedAt(this.CreatedAt)
                .PhoneNumber(this.PhoneNumber);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "phone_number", false },
            };

            private string id;
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
                shouldSerialize["phone_number"] = true;
                this.phoneNumber = phoneNumber;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPhoneNumber()
            {
                this.shouldSerialize["phone_number"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyAccountMapping. </returns>
            public LoyaltyAccountMapping Build()
            {
                return new LoyaltyAccountMapping(shouldSerialize,
                    this.id,
                    this.createdAt,
                    this.phoneNumber);
            }
        }
    }
}