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
    /// LoyaltyProgramAccrualRuleVisitData.
    /// </summary>
    public class LoyaltyProgramAccrualRuleVisitData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyProgramAccrualRuleVisitData"/> class.
        /// </summary>
        /// <param name="taxMode">tax_mode.</param>
        /// <param name="minimumAmountMoney">minimum_amount_money.</param>
        public LoyaltyProgramAccrualRuleVisitData(
            string taxMode,
            Models.Money minimumAmountMoney = null)
        {
            this.MinimumAmountMoney = minimumAmountMoney;
            this.TaxMode = taxMode;
        }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("minimum_amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money MinimumAmountMoney { get; }

        /// <summary>
        /// Indicates how taxes should be treated when calculating the purchase amount used for loyalty points accrual.
        /// This setting applies only to `SPEND` accrual rules or `VISIT` accrual rules that have a minimum spend requirement.
        /// </summary>
        [JsonProperty("tax_mode")]
        public string TaxMode { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyProgramAccrualRuleVisitData : ({string.Join(", ", toStringOutput)})";
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
            return obj is LoyaltyProgramAccrualRuleVisitData other &&                ((this.MinimumAmountMoney == null && other.MinimumAmountMoney == null) || (this.MinimumAmountMoney?.Equals(other.MinimumAmountMoney) == true)) &&
                ((this.TaxMode == null && other.TaxMode == null) || (this.TaxMode?.Equals(other.TaxMode) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 768112372;
            hashCode = HashCode.Combine(this.MinimumAmountMoney, this.TaxMode);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MinimumAmountMoney = {(this.MinimumAmountMoney == null ? "null" : this.MinimumAmountMoney.ToString())}");
            toStringOutput.Add($"this.TaxMode = {(this.TaxMode == null ? "null" : this.TaxMode.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.TaxMode)
                .MinimumAmountMoney(this.MinimumAmountMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string taxMode;
            private Models.Money minimumAmountMoney;

            /// <summary>
            /// Initialize Builder for LoyaltyProgramAccrualRuleVisitData.
            /// </summary>
            /// <param name="taxMode"> taxMode. </param>
            public Builder(
                string taxMode)
            {
                this.taxMode = taxMode;
            }

             /// <summary>
             /// TaxMode.
             /// </summary>
             /// <param name="taxMode"> taxMode. </param>
             /// <returns> Builder. </returns>
            public Builder TaxMode(string taxMode)
            {
                this.taxMode = taxMode;
                return this;
            }

             /// <summary>
             /// MinimumAmountMoney.
             /// </summary>
             /// <param name="minimumAmountMoney"> minimumAmountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder MinimumAmountMoney(Models.Money minimumAmountMoney)
            {
                this.minimumAmountMoney = minimumAmountMoney;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyProgramAccrualRuleVisitData. </returns>
            public LoyaltyProgramAccrualRuleVisitData Build()
            {
                return new LoyaltyProgramAccrualRuleVisitData(
                    this.taxMode,
                    this.minimumAmountMoney);
            }
        }
    }
}