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
    /// V1PaymentSurcharge.
    /// </summary>
    public class V1PaymentSurcharge
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1PaymentSurcharge"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="appliedMoney">applied_money.</param>
        /// <param name="rate">rate.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="type">type.</param>
        /// <param name="taxable">taxable.</param>
        /// <param name="taxes">taxes.</param>
        /// <param name="surchargeId">surcharge_id.</param>
        public V1PaymentSurcharge(
            string name = null,
            Models.V1Money appliedMoney = null,
            string rate = null,
            Models.V1Money amountMoney = null,
            string type = null,
            bool? taxable = null,
            IList<Models.V1PaymentTax> taxes = null,
            string surchargeId = null)
        {
            this.Name = name;
            this.AppliedMoney = appliedMoney;
            this.Rate = rate;
            this.AmountMoney = amountMoney;
            this.Type = type;
            this.Taxable = taxable;
            this.Taxes = taxes;
            this.SurchargeId = surchargeId;
        }

        /// <summary>
        /// The name of the surcharge.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// Gets or sets AppliedMoney.
        /// </summary>
        [JsonProperty("applied_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money AppliedMoney { get; }

        /// <summary>
        /// The amount of the surcharge as a percentage. The percentage is provided as a string representing the decimal equivalent of the percentage. For example, "0.7" corresponds to a 7% surcharge. Exactly one of rate or amount_money should be set.
        /// </summary>
        [JsonProperty("rate", NullValueHandling = NullValueHandling.Ignore)]
        public string Rate { get; }

        /// <summary>
        /// Gets or sets AmountMoney.
        /// </summary>
        [JsonProperty("amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money AmountMoney { get; }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// Indicates whether the surcharge is taxable.
        /// </summary>
        [JsonProperty("taxable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Taxable { get; }

        /// <summary>
        /// The list of taxes that should be applied to the surcharge.
        /// </summary>
        [JsonProperty("taxes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1PaymentTax> Taxes { get; }

        /// <summary>
        /// A Square-issued unique identifier associated with the surcharge.
        /// </summary>
        [JsonProperty("surcharge_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SurchargeId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1PaymentSurcharge : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1PaymentSurcharge other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.AppliedMoney == null && other.AppliedMoney == null) || (this.AppliedMoney?.Equals(other.AppliedMoney) == true)) &&
                ((this.Rate == null && other.Rate == null) || (this.Rate?.Equals(other.Rate) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Taxable == null && other.Taxable == null) || (this.Taxable?.Equals(other.Taxable) == true)) &&
                ((this.Taxes == null && other.Taxes == null) || (this.Taxes?.Equals(other.Taxes) == true)) &&
                ((this.SurchargeId == null && other.SurchargeId == null) || (this.SurchargeId?.Equals(other.SurchargeId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -446593569;
            hashCode = HashCode.Combine(this.Name, this.AppliedMoney, this.Rate, this.AmountMoney, this.Type, this.Taxable, this.Taxes);

            hashCode = HashCode.Combine(hashCode, this.SurchargeId);

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
            toStringOutput.Add($"this.Rate = {(this.Rate == null ? "null" : this.Rate == string.Empty ? "" : this.Rate)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.Taxable = {(this.Taxable == null ? "null" : this.Taxable.ToString())}");
            toStringOutput.Add($"this.Taxes = {(this.Taxes == null ? "null" : $"[{string.Join(", ", this.Taxes)} ]")}");
            toStringOutput.Add($"this.SurchargeId = {(this.SurchargeId == null ? "null" : this.SurchargeId == string.Empty ? "" : this.SurchargeId)}");
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
                .Rate(this.Rate)
                .AmountMoney(this.AmountMoney)
                .Type(this.Type)
                .Taxable(this.Taxable)
                .Taxes(this.Taxes)
                .SurchargeId(this.SurchargeId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string name;
            private Models.V1Money appliedMoney;
            private string rate;
            private Models.V1Money amountMoney;
            private string type;
            private bool? taxable;
            private IList<Models.V1PaymentTax> taxes;
            private string surchargeId;

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
             /// Rate.
             /// </summary>
             /// <param name="rate"> rate. </param>
             /// <returns> Builder. </returns>
            public Builder Rate(string rate)
            {
                this.rate = rate;
                return this;
            }

             /// <summary>
             /// AmountMoney.
             /// </summary>
             /// <param name="amountMoney"> amountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AmountMoney(Models.V1Money amountMoney)
            {
                this.amountMoney = amountMoney;
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
             /// Taxable.
             /// </summary>
             /// <param name="taxable"> taxable. </param>
             /// <returns> Builder. </returns>
            public Builder Taxable(bool? taxable)
            {
                this.taxable = taxable;
                return this;
            }

             /// <summary>
             /// Taxes.
             /// </summary>
             /// <param name="taxes"> taxes. </param>
             /// <returns> Builder. </returns>
            public Builder Taxes(IList<Models.V1PaymentTax> taxes)
            {
                this.taxes = taxes;
                return this;
            }

             /// <summary>
             /// SurchargeId.
             /// </summary>
             /// <param name="surchargeId"> surchargeId. </param>
             /// <returns> Builder. </returns>
            public Builder SurchargeId(string surchargeId)
            {
                this.surchargeId = surchargeId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1PaymentSurcharge. </returns>
            public V1PaymentSurcharge Build()
            {
                return new V1PaymentSurcharge(
                    this.name,
                    this.appliedMoney,
                    this.rate,
                    this.amountMoney,
                    this.type,
                    this.taxable,
                    this.taxes,
                    this.surchargeId);
            }
        }
    }
}