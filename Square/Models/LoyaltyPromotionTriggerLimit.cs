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
    /// LoyaltyPromotionTriggerLimit.
    /// </summary>
    public class LoyaltyPromotionTriggerLimit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyPromotionTriggerLimit"/> class.
        /// </summary>
        /// <param name="times">times.</param>
        /// <param name="interval">interval.</param>
        public LoyaltyPromotionTriggerLimit(
            int times,
            string interval = null)
        {
            this.Times = times;
            this.Interval = interval;
        }

        /// <summary>
        /// The maximum number of times a buyer can trigger the promotion during the specified `interval`.
        /// </summary>
        [JsonProperty("times")]
        public int Times { get; }

        /// <summary>
        /// Indicates the time period that the [trigger limit]($m/LoyaltyPromotionTriggerLimit) applies to,
        /// which is used to determine the number of times a buyer can earn points for a [loyalty promotion]($m/LoyaltyPromotion).
        /// </summary>
        [JsonProperty("interval", NullValueHandling = NullValueHandling.Ignore)]
        public string Interval { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"LoyaltyPromotionTriggerLimit : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is LoyaltyPromotionTriggerLimit other &&
                (this.Times.Equals(other.Times)) &&
                (this.Interval == null && other.Interval == null ||
                 this.Interval?.Equals(other.Interval) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1850238463;
            hashCode = HashCode.Combine(hashCode, this.Times, this.Interval);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Times = {this.Times}");
            toStringOutput.Add($"this.Interval = {(this.Interval == null ? "null" : this.Interval.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Times)
                .Interval(this.Interval);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private int times;
            private string interval;

            /// <summary>
            /// Initialize Builder for LoyaltyPromotionTriggerLimit.
            /// </summary>
            /// <param name="times"> times. </param>
            public Builder(
                int times)
            {
                this.times = times;
            }

             /// <summary>
             /// Times.
             /// </summary>
             /// <param name="times"> times. </param>
             /// <returns> Builder. </returns>
            public Builder Times(int times)
            {
                this.times = times;
                return this;
            }

             /// <summary>
             /// Interval.
             /// </summary>
             /// <param name="interval"> interval. </param>
             /// <returns> Builder. </returns>
            public Builder Interval(string interval)
            {
                this.interval = interval;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyPromotionTriggerLimit. </returns>
            public LoyaltyPromotionTriggerLimit Build()
            {
                return new LoyaltyPromotionTriggerLimit(
                    this.times,
                    this.interval);
            }
        }
    }
}