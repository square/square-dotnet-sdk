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
            this.Name = name;
            this.AppliedMoney = appliedMoney;
            this.DiscountId = discountId;
        }

        /// <summary>
        /// The discount's name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// Gets or sets AppliedMoney.
        /// </summary>
        [JsonProperty("applied_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money AppliedMoney { get; }

        /// <summary>
        /// The ID of the applied discount, if available. Discounts applied in older versions of Square Register might not have an ID.
        /// </summary>
        [JsonProperty("discount_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DiscountId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1PaymentDiscount : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1PaymentDiscount other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.AppliedMoney == null && other.AppliedMoney == null) || (this.AppliedMoney?.Equals(other.AppliedMoney) == true)) &&
                ((this.DiscountId == null && other.DiscountId == null) || (this.DiscountId?.Equals(other.DiscountId) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1602240589;

            if (this.Name != null)
            {
               hashCode += this.Name.GetHashCode();
            }

            if (this.AppliedMoney != null)
            {
               hashCode += this.AppliedMoney.GetHashCode();
            }

            if (this.DiscountId != null)
            {
               hashCode += this.DiscountId.GetHashCode();
            }

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
                this.discountId = discountId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1PaymentDiscount. </returns>
            public V1PaymentDiscount Build()
            {
                return new V1PaymentDiscount(
                    this.name,
                    this.appliedMoney,
                    this.discountId);
            }
        }
    }
}