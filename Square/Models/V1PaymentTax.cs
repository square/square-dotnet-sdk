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
    public class V1PaymentTax 
    {
        public V1PaymentTax(IList<Models.Error> errors = null,
            string name = null,
            Models.V1Money appliedMoney = null,
            string rate = null,
            string inclusionType = null,
            string feeId = null)
        {
            Errors = errors;
            Name = name;
            AppliedMoney = appliedMoney;
            Rate = rate;
            InclusionType = inclusionType;
            FeeId = feeId;
        }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The merchant-defined name of the tax.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Getter for applied_money
        /// </summary>
        [JsonProperty("applied_money")]
        public Models.V1Money AppliedMoney { get; }

        /// <summary>
        /// The rate of the tax, as a string representation of a decimal number. A value of 0.07 corresponds to a rate of 7%.
        /// </summary>
        [JsonProperty("rate")]
        public string Rate { get; }

        /// <summary>
        /// Getter for inclusion_type
        /// </summary>
        [JsonProperty("inclusion_type")]
        public string InclusionType { get; }

        /// <summary>
        /// The ID of the tax, if available. Taxes applied in older versions of Square Register might not have an ID.
        /// </summary>
        [JsonProperty("fee_id")]
        public string FeeId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Name(Name)
                .AppliedMoney(AppliedMoney)
                .Rate(Rate)
                .InclusionType(InclusionType)
                .FeeId(FeeId);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private string name;
            private Models.V1Money appliedMoney;
            private string rate;
            private string inclusionType;
            private string feeId;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder AppliedMoney(Models.V1Money value)
            {
                appliedMoney = value;
                return this;
            }

            public Builder Rate(string value)
            {
                rate = value;
                return this;
            }

            public Builder InclusionType(string value)
            {
                inclusionType = value;
                return this;
            }

            public Builder FeeId(string value)
            {
                feeId = value;
                return this;
            }

            public V1PaymentTax Build()
            {
                return new V1PaymentTax(errors,
                    name,
                    appliedMoney,
                    rate,
                    inclusionType,
                    feeId);
            }
        }
    }
}