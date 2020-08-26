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
    public class SubscriptionPhase 
    {
        public SubscriptionPhase(string cadence,
            Models.Money recurringPriceMoney,
            string uid = null,
            int? periods = null,
            long? ordinal = null)
        {
            Uid = uid;
            Cadence = cadence;
            Periods = periods;
            RecurringPriceMoney = recurringPriceMoney;
            Ordinal = ordinal;
        }

        /// <summary>
        /// The Square-assigned ID of the subscription phase. This field cannot be changed after a `SubscriptionPhase` is created.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// Determines the billing cadence of a [Subscription](#type-Subscription)
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
        [JsonProperty("recurring_price_money")]
        public Models.Money RecurringPriceMoney { get; }

        /// <summary>
        /// The position this phase appears in the sequence of phases defined for the plan, indexed from 0. This field cannot be changed after a `SubscriptionPhase` is created.
        /// </summary>
        [JsonProperty("ordinal")]
        public long? Ordinal { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Cadence,
                RecurringPriceMoney)
                .Uid(Uid)
                .Periods(Periods)
                .Ordinal(Ordinal);
            return builder;
        }

        public class Builder
        {
            private string cadence;
            private Models.Money recurringPriceMoney;
            private string uid;
            private int? periods;
            private long? ordinal;

            public Builder(string cadence,
                Models.Money recurringPriceMoney)
            {
                this.cadence = cadence;
                this.recurringPriceMoney = recurringPriceMoney;
            }
            public Builder Cadence(string value)
            {
                cadence = value;
                return this;
            }

            public Builder RecurringPriceMoney(Models.Money value)
            {
                recurringPriceMoney = value;
                return this;
            }

            public Builder Uid(string value)
            {
                uid = value;
                return this;
            }

            public Builder Periods(int? value)
            {
                periods = value;
                return this;
            }

            public Builder Ordinal(long? value)
            {
                ordinal = value;
                return this;
            }

            public SubscriptionPhase Build()
            {
                return new SubscriptionPhase(cadence,
                    recurringPriceMoney,
                    uid,
                    periods,
                    ordinal);
            }
        }
    }
}