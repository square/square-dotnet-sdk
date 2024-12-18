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
    /// ChangeBillingAnchorDateRequest.
    /// </summary>
    public class ChangeBillingAnchorDateRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeBillingAnchorDateRequest"/> class.
        /// </summary>
        /// <param name="monthlyBillingAnchorDate">monthly_billing_anchor_date.</param>
        /// <param name="effectiveDate">effective_date.</param>
        public ChangeBillingAnchorDateRequest(
            int? monthlyBillingAnchorDate = null,
            string effectiveDate = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "monthly_billing_anchor_date", false },
                { "effective_date", false }
            };

            if (monthlyBillingAnchorDate != null)
            {
                shouldSerialize["monthly_billing_anchor_date"] = true;
                this.MonthlyBillingAnchorDate = monthlyBillingAnchorDate;
            }

            if (effectiveDate != null)
            {
                shouldSerialize["effective_date"] = true;
                this.EffectiveDate = effectiveDate;
            }
        }

        internal ChangeBillingAnchorDateRequest(
            Dictionary<string, bool> shouldSerialize,
            int? monthlyBillingAnchorDate = null,
            string effectiveDate = null)
        {
            this.shouldSerialize = shouldSerialize;
            MonthlyBillingAnchorDate = monthlyBillingAnchorDate;
            EffectiveDate = effectiveDate;
        }

        /// <summary>
        /// The anchor day for the billing cycle.
        /// </summary>
        [JsonProperty("monthly_billing_anchor_date")]
        public int? MonthlyBillingAnchorDate { get; }

        /// <summary>
        /// The `YYYY-MM-DD`-formatted date when the scheduled `BILLING_ANCHOR_CHANGE` action takes
        /// place on the subscription.
        /// When this date is unspecified or falls within the current billing cycle, the billing anchor date
        /// is changed immediately.
        /// </summary>
        [JsonProperty("effective_date")]
        public string EffectiveDate { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ChangeBillingAnchorDateRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMonthlyBillingAnchorDate()
        {
            return this.shouldSerialize["monthly_billing_anchor_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEffectiveDate()
        {
            return this.shouldSerialize["effective_date"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ChangeBillingAnchorDateRequest other &&
                (this.MonthlyBillingAnchorDate == null && other.MonthlyBillingAnchorDate == null ||
                 this.MonthlyBillingAnchorDate?.Equals(other.MonthlyBillingAnchorDate) == true) &&
                (this.EffectiveDate == null && other.EffectiveDate == null ||
                 this.EffectiveDate?.Equals(other.EffectiveDate) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 849567670;
            hashCode = HashCode.Combine(hashCode, this.MonthlyBillingAnchorDate, this.EffectiveDate);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MonthlyBillingAnchorDate = {(this.MonthlyBillingAnchorDate == null ? "null" : this.MonthlyBillingAnchorDate.ToString())}");
            toStringOutput.Add($"this.EffectiveDate = {this.EffectiveDate ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .MonthlyBillingAnchorDate(this.MonthlyBillingAnchorDate)
                .EffectiveDate(this.EffectiveDate);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "monthly_billing_anchor_date", false },
                { "effective_date", false },
            };

            private int? monthlyBillingAnchorDate;
            private string effectiveDate;

             /// <summary>
             /// MonthlyBillingAnchorDate.
             /// </summary>
             /// <param name="monthlyBillingAnchorDate"> monthlyBillingAnchorDate. </param>
             /// <returns> Builder. </returns>
            public Builder MonthlyBillingAnchorDate(int? monthlyBillingAnchorDate)
            {
                shouldSerialize["monthly_billing_anchor_date"] = true;
                this.monthlyBillingAnchorDate = monthlyBillingAnchorDate;
                return this;
            }

             /// <summary>
             /// EffectiveDate.
             /// </summary>
             /// <param name="effectiveDate"> effectiveDate. </param>
             /// <returns> Builder. </returns>
            public Builder EffectiveDate(string effectiveDate)
            {
                shouldSerialize["effective_date"] = true;
                this.effectiveDate = effectiveDate;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetMonthlyBillingAnchorDate()
            {
                this.shouldSerialize["monthly_billing_anchor_date"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetEffectiveDate()
            {
                this.shouldSerialize["effective_date"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ChangeBillingAnchorDateRequest. </returns>
            public ChangeBillingAnchorDateRequest Build()
            {
                return new ChangeBillingAnchorDateRequest(
                    shouldSerialize,
                    this.monthlyBillingAnchorDate,
                    this.effectiveDate);
            }
        }
    }
}