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
    /// V1PaymentDiscount.
    /// </summary>
    public class V1PaymentDiscount
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="V1PaymentDiscount"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="appliedMoney">applied_money.</param>
        /// <param name="discountId">discount_id.</param>
        public V1PaymentDiscount(
            string name = null,
            Models.V1Money appliedMoney = null,
            string discountId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "discount_id", false }
            };

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            this.AppliedMoney = appliedMoney;
            if (discountId != null)
            {
                shouldSerialize["discount_id"] = true;
                this.DiscountId = discountId;
            }

        }
        internal V1PaymentDiscount(Dictionary<string, bool> shouldSerialize,
            string name = null,
            Models.V1Money appliedMoney = null,
            string discountId = null)
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
            AppliedMoney = appliedMoney;
            DiscountId = discountId;
        }

        /// <summary>
        /// The discount's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Gets or sets AppliedMoney.
        /// </summary>
        [JsonProperty("applied_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money AppliedMoney { get; }

        /// <summary>
        /// The ID of the applied discount, if available. Discounts applied in older versions of Square Register might not have an ID.
        /// </summary>
        [JsonProperty("discount_id")]
        public string DiscountId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1PaymentDiscount : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeDiscountId()
        {
            return this.shouldSerialize["discount_id"];
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
            return obj is V1PaymentDiscount other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.AppliedMoney == null && other.AppliedMoney == null) || (this.AppliedMoney?.Equals(other.AppliedMoney) == true)) &&
                ((this.DiscountId == null && other.DiscountId == null) || (this.DiscountId?.Equals(other.DiscountId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1602240589;
            hashCode = HashCode.Combine(this.Name, this.AppliedMoney, this.DiscountId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.AppliedMoney = {(this.AppliedMoney == null ? "null" : this.AppliedMoney.ToString())}");
            toStringOutput.Add($"this.DiscountId = {(this.DiscountId == null ? "null" : this.DiscountId == string.Empty ? "" : this.DiscountId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name)
                .AppliedMoney(this.AppliedMoney)
                .DiscountId(this.DiscountId);
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
                { "discount_id", false },
            };

            private string name;
            private Models.V1Money appliedMoney;
            private string discountId;

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
             /// AppliedMoney.
             /// </summary>
             /// <param name="appliedMoney"> appliedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AppliedMoney(Models.V1Money appliedMoney)
            {
                this.appliedMoney = appliedMoney;
                return this;
            }

             /// <summary>
             /// DiscountId.
             /// </summary>
             /// <param name="discountId"> discountId. </param>
             /// <returns> Builder. </returns>
            public Builder DiscountId(string discountId)
            {
                shouldSerialize["discount_id"] = true;
                this.discountId = discountId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDiscountId()
            {
                this.shouldSerialize["discount_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1PaymentDiscount. </returns>
            public V1PaymentDiscount Build()
            {
                return new V1PaymentDiscount(shouldSerialize,
                    this.name,
                    this.appliedMoney,
                    this.discountId);
            }
        }
    }
}