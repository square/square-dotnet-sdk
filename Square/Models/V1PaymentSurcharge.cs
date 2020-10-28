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
    public class V1PaymentSurcharge 
    {
        public V1PaymentSurcharge(string name = null,
            Models.V1Money appliedMoney = null,
            string rate = null,
            Models.V1Money amountMoney = null,
            string type = null,
            bool? taxable = null,
            IList<Models.V1PaymentTax> taxes = null,
            string surchargeId = null)
        {
            Name = name;
            AppliedMoney = appliedMoney;
            Rate = rate;
            AmountMoney = amountMoney;
            Type = type;
            Taxable = taxable;
            Taxes = taxes;
            SurchargeId = surchargeId;
        }

        /// <summary>
        /// The name of the surcharge.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// Getter for applied_money
        /// </summary>
        [JsonProperty("applied_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money AppliedMoney { get; }

        /// <summary>
        /// The amount of the surcharge as a percentage. The percentage is provided as a string representing the decimal equivalent of the percentage. For example, "0.7" corresponds to a 7% surcharge. Exactly one of rate or amount_money should be set.
        /// </summary>
        [JsonProperty("rate", NullValueHandling = NullValueHandling.Ignore)]
        public string Rate { get; }

        /// <summary>
        /// Getter for amount_money
        /// </summary>
        [JsonProperty("amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money AmountMoney { get; }

        /// <summary>
        /// Getter for type
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

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name)
                .AppliedMoney(AppliedMoney)
                .Rate(Rate)
                .AmountMoney(AmountMoney)
                .Type(Type)
                .Taxable(Taxable)
                .Taxes(Taxes)
                .SurchargeId(SurchargeId);
            return builder;
        }

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



            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder AppliedMoney(Models.V1Money appliedMoney)
            {
                this.appliedMoney = appliedMoney;
                return this;
            }

            public Builder Rate(string rate)
            {
                this.rate = rate;
                return this;
            }

            public Builder AmountMoney(Models.V1Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

            public Builder Taxable(bool? taxable)
            {
                this.taxable = taxable;
                return this;
            }

            public Builder Taxes(IList<Models.V1PaymentTax> taxes)
            {
                this.taxes = taxes;
                return this;
            }

            public Builder SurchargeId(string surchargeId)
            {
                this.surchargeId = surchargeId;
                return this;
            }

            public V1PaymentSurcharge Build()
            {
                return new V1PaymentSurcharge(name,
                    appliedMoney,
                    rate,
                    amountMoney,
                    type,
                    taxable,
                    taxes,
                    surchargeId);
            }
        }
    }
}