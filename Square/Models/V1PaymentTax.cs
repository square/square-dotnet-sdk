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
    /// V1PaymentTax.
    /// </summary>
    public class V1PaymentTax
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="V1PaymentTax"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="name">name.</param>
        /// <param name="appliedMoney">applied_money.</param>
        /// <param name="rate">rate.</param>
        /// <param name="inclusionType">inclusion_type.</param>
        /// <param name="feeId">fee_id.</param>
        public V1PaymentTax(
            IList<Models.Error> errors = null,
            string name = null,
            Models.V1Money appliedMoney = null,
            string rate = null,
            string inclusionType = null,
            string feeId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "errors", false },
                { "name", false },
                { "rate", false },
                { "fee_id", false }
            };

            if (errors != null)
            {
                shouldSerialize["errors"] = true;
                this.Errors = errors;
            }

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            this.AppliedMoney = appliedMoney;
            if (rate != null)
            {
                shouldSerialize["rate"] = true;
                this.Rate = rate;
            }

            this.InclusionType = inclusionType;
            if (feeId != null)
            {
                shouldSerialize["fee_id"] = true;
                this.FeeId = feeId;
            }

        }
        internal V1PaymentTax(Dictionary<string, bool> shouldSerialize,
            IList<Models.Error> errors = null,
            string name = null,
            Models.V1Money appliedMoney = null,
            string rate = null,
            string inclusionType = null,
            string feeId = null)
        {
            this.shouldSerialize = shouldSerialize;
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
        /// Gets or sets AppliedMoney.
        /// </summary>
        [JsonProperty("applied_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money AppliedMoney { get; }

        /// <summary>
        /// The rate of the tax, as a string representation of a decimal number. A value of 0.07 corresponds to a rate of 7%.
        /// </summary>
        [JsonProperty("rate")]
        public string Rate { get; }

        /// <summary>
        /// Gets or sets InclusionType.
        /// </summary>
        [JsonProperty("inclusion_type", NullValueHandling = NullValueHandling.Ignore)]
        public string InclusionType { get; }

        /// <summary>
        /// The ID of the tax, if available. Taxes applied in older versions of Square Register might not have an ID.
        /// </summary>
        [JsonProperty("fee_id")]
        public string FeeId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1PaymentTax : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeErrors()
        {
            return this.shouldSerialize["errors"];
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
        public bool ShouldSerializeRate()
        {
            return this.shouldSerialize["rate"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFeeId()
        {
            return this.shouldSerialize["fee_id"];
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

            return obj is V1PaymentTax other &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.AppliedMoney == null && other.AppliedMoney == null) || (this.AppliedMoney?.Equals(other.AppliedMoney) == true)) &&
                ((this.Rate == null && other.Rate == null) || (this.Rate?.Equals(other.Rate) == true)) &&
                ((this.InclusionType == null && other.InclusionType == null) || (this.InclusionType?.Equals(other.InclusionType) == true)) &&
                ((this.FeeId == null && other.FeeId == null) || (this.FeeId?.Equals(other.FeeId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 2123751229;
            hashCode = HashCode.Combine(this.Errors, this.Name, this.AppliedMoney, this.Rate, this.InclusionType, this.FeeId);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.AppliedMoney = {(this.AppliedMoney == null ? "null" : this.AppliedMoney.ToString())}");
            toStringOutput.Add($"this.Rate = {(this.Rate == null ? "null" : this.Rate == string.Empty ? "" : this.Rate)}");
            toStringOutput.Add($"this.InclusionType = {(this.InclusionType == null ? "null" : this.InclusionType.ToString())}");
            toStringOutput.Add($"this.FeeId = {(this.FeeId == null ? "null" : this.FeeId == string.Empty ? "" : this.FeeId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Name(this.Name)
                .AppliedMoney(this.AppliedMoney)
                .Rate(this.Rate)
                .InclusionType(this.InclusionType)
                .FeeId(this.FeeId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "errors", false },
                { "name", false },
                { "rate", false },
                { "fee_id", false },
            };

            private IList<Models.Error> errors;
            private string name;
            private Models.V1Money appliedMoney;
            private string rate;
            private string inclusionType;
            private string feeId;

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                shouldSerialize["errors"] = true;
                this.errors = errors;
                return this;
            }

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
             /// Rate.
             /// </summary>
             /// <param name="rate"> rate. </param>
             /// <returns> Builder. </returns>
            public Builder Rate(string rate)
            {
                shouldSerialize["rate"] = true;
                this.rate = rate;
                return this;
            }

             /// <summary>
             /// InclusionType.
             /// </summary>
             /// <param name="inclusionType"> inclusionType. </param>
             /// <returns> Builder. </returns>
            public Builder InclusionType(string inclusionType)
            {
                this.inclusionType = inclusionType;
                return this;
            }

             /// <summary>
             /// FeeId.
             /// </summary>
             /// <param name="feeId"> feeId. </param>
             /// <returns> Builder. </returns>
            public Builder FeeId(string feeId)
            {
                shouldSerialize["fee_id"] = true;
                this.feeId = feeId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetErrors()
            {
                this.shouldSerialize["errors"] = false;
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
            public void UnsetRate()
            {
                this.shouldSerialize["rate"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetFeeId()
            {
                this.shouldSerialize["fee_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1PaymentTax. </returns>
            public V1PaymentTax Build()
            {
                return new V1PaymentTax(shouldSerialize,
                    this.errors,
                    this.name,
                    this.appliedMoney,
                    this.rate,
                    this.inclusionType,
                    this.feeId);
            }
        }
    }
}