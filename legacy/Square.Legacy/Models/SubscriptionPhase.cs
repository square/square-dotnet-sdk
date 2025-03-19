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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// SubscriptionPhase.
    /// </summary>
    public class SubscriptionPhase
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionPhase"/> class.
        /// </summary>
        /// <param name="cadence">cadence.</param>
        /// <param name="uid">uid.</param>
        /// <param name="periods">periods.</param>
        /// <param name="recurringPriceMoney">recurring_price_money.</param>
        /// <param name="ordinal">ordinal.</param>
        /// <param name="pricing">pricing.</param>
        public SubscriptionPhase(
            string cadence,
            string uid = null,
            int? periods = null,
            Models.Money recurringPriceMoney = null,
            long? ordinal = null,
            Models.SubscriptionPricing pricing = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "periods", false },
                { "ordinal", false },
            };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }
            this.Cadence = cadence;

            if (periods != null)
            {
                shouldSerialize["periods"] = true;
                this.Periods = periods;
            }
            this.RecurringPriceMoney = recurringPriceMoney;

            if (ordinal != null)
            {
                shouldSerialize["ordinal"] = true;
                this.Ordinal = ordinal;
            }
            this.Pricing = pricing;
        }

        internal SubscriptionPhase(
            Dictionary<string, bool> shouldSerialize,
            string cadence,
            string uid = null,
            int? periods = null,
            Models.Money recurringPriceMoney = null,
            long? ordinal = null,
            Models.SubscriptionPricing pricing = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            Cadence = cadence;
            Periods = periods;
            RecurringPriceMoney = recurringPriceMoney;
            Ordinal = ordinal;
            Pricing = pricing;
        }

        /// <summary>
        /// The Square-assigned ID of the subscription phase. This field cannot be changed after a `SubscriptionPhase` is created.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// Determines the billing cadence of a [Subscription]($m/Subscription)
        /// </summary>
        [JsonProperty("cadence")]
        public string Cadence { get; }

        /// <summary>
        /// The number of `cadence`s the phase lasts. If not set, the phase never ends. Only the last phase can be indefinite. This field cannot be changed after a `SubscriptionPhase` is created.
        /// </summary>
        [JsonProperty("periods")]
        public int? Periods { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("recurring_price_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money RecurringPriceMoney { get; }

        /// <summary>
        /// The position this phase appears in the sequence of phases defined for the plan, indexed from 0. This field cannot be changed after a `SubscriptionPhase` is created.
        /// </summary>
        [JsonProperty("ordinal")]
        public long? Ordinal { get; }

        /// <summary>
        /// Describes the pricing for the subscription.
        /// </summary>
        [JsonProperty("pricing", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SubscriptionPricing Pricing { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SubscriptionPhase : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUid()
        {
            return this.shouldSerialize["uid"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePeriods()
        {
            return this.shouldSerialize["periods"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrdinal()
        {
            return this.shouldSerialize["ordinal"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is SubscriptionPhase other
                && (this.Uid == null && other.Uid == null || this.Uid?.Equals(other.Uid) == true)
                && (
                    this.Cadence == null && other.Cadence == null
                    || this.Cadence?.Equals(other.Cadence) == true
                )
                && (
                    this.Periods == null && other.Periods == null
                    || this.Periods?.Equals(other.Periods) == true
                )
                && (
                    this.RecurringPriceMoney == null && other.RecurringPriceMoney == null
                    || this.RecurringPriceMoney?.Equals(other.RecurringPriceMoney) == true
                )
                && (
                    this.Ordinal == null && other.Ordinal == null
                    || this.Ordinal?.Equals(other.Ordinal) == true
                )
                && (
                    this.Pricing == null && other.Pricing == null
                    || this.Pricing?.Equals(other.Pricing) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1288354424;
            hashCode = HashCode.Combine(
                hashCode,
                this.Uid,
                this.Cadence,
                this.Periods,
                this.RecurringPriceMoney,
                this.Ordinal,
                this.Pricing
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {this.Uid ?? "null"}");
            toStringOutput.Add(
                $"this.Cadence = {(this.Cadence == null ? "null" : this.Cadence.ToString())}"
            );
            toStringOutput.Add(
                $"this.Periods = {(this.Periods == null ? "null" : this.Periods.ToString())}"
            );
            toStringOutput.Add(
                $"this.RecurringPriceMoney = {(this.RecurringPriceMoney == null ? "null" : this.RecurringPriceMoney.ToString())}"
            );
            toStringOutput.Add(
                $"this.Ordinal = {(this.Ordinal == null ? "null" : this.Ordinal.ToString())}"
            );
            toStringOutput.Add(
                $"this.Pricing = {(this.Pricing == null ? "null" : this.Pricing.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Cadence)
                .Uid(this.Uid)
                .Periods(this.Periods)
                .RecurringPriceMoney(this.RecurringPriceMoney)
                .Ordinal(this.Ordinal)
                .Pricing(this.Pricing);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "periods", false },
                { "ordinal", false },
            };

            private string cadence;
            private string uid;
            private int? periods;
            private Models.Money recurringPriceMoney;
            private long? ordinal;
            private Models.SubscriptionPricing pricing;

            /// <summary>
            /// Initialize Builder for SubscriptionPhase.
            /// </summary>
            /// <param name="cadence"> cadence. </param>
            public Builder(string cadence)
            {
                this.cadence = cadence;
            }

            /// <summary>
            /// Cadence.
            /// </summary>
            /// <param name="cadence"> cadence. </param>
            /// <returns> Builder. </returns>
            public Builder Cadence(string cadence)
            {
                this.cadence = cadence;
                return this;
            }

            /// <summary>
            /// Uid.
            /// </summary>
            /// <param name="uid"> uid. </param>
            /// <returns> Builder. </returns>
            public Builder Uid(string uid)
            {
                shouldSerialize["uid"] = true;
                this.uid = uid;
                return this;
            }

            /// <summary>
            /// Periods.
            /// </summary>
            /// <param name="periods"> periods. </param>
            /// <returns> Builder. </returns>
            public Builder Periods(int? periods)
            {
                shouldSerialize["periods"] = true;
                this.periods = periods;
                return this;
            }

            /// <summary>
            /// RecurringPriceMoney.
            /// </summary>
            /// <param name="recurringPriceMoney"> recurringPriceMoney. </param>
            /// <returns> Builder. </returns>
            public Builder RecurringPriceMoney(Models.Money recurringPriceMoney)
            {
                this.recurringPriceMoney = recurringPriceMoney;
                return this;
            }

            /// <summary>
            /// Ordinal.
            /// </summary>
            /// <param name="ordinal"> ordinal. </param>
            /// <returns> Builder. </returns>
            public Builder Ordinal(long? ordinal)
            {
                shouldSerialize["ordinal"] = true;
                this.ordinal = ordinal;
                return this;
            }

            /// <summary>
            /// Pricing.
            /// </summary>
            /// <param name="pricing"> pricing. </param>
            /// <returns> Builder. </returns>
            public Builder Pricing(Models.SubscriptionPricing pricing)
            {
                this.pricing = pricing;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetUid()
            {
                this.shouldSerialize["uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetPeriods()
            {
                this.shouldSerialize["periods"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetOrdinal()
            {
                this.shouldSerialize["ordinal"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SubscriptionPhase. </returns>
            public SubscriptionPhase Build()
            {
                return new SubscriptionPhase(
                    shouldSerialize,
                    this.cadence,
                    this.uid,
                    this.periods,
                    this.recurringPriceMoney,
                    this.ordinal,
                    this.pricing
                );
            }
        }
    }
}
