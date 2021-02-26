
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
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// Determines the billing cadence of a [Subscription](#type-Subscription)
        /// </summary>
        [JsonProperty("cadence")]
        public string Cadence { get; }

        /// <summary>
        /// The number of `cadence`s the phase lasts. If not set, the phase never ends. Only the last phase can be indefinite. This field cannot be changed after a `SubscriptionPhase` is created.
        /// </summary>
        [JsonProperty("periods", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty("ordinal", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ordinal { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SubscriptionPhase : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Uid = {(Uid == null ? "null" : Uid == string.Empty ? "" : Uid)}");
            toStringOutput.Add($"Cadence = {(Cadence == null ? "null" : Cadence.ToString())}");
            toStringOutput.Add($"Periods = {(Periods == null ? "null" : Periods.ToString())}");
            toStringOutput.Add($"RecurringPriceMoney = {(RecurringPriceMoney == null ? "null" : RecurringPriceMoney.ToString())}");
            toStringOutput.Add($"Ordinal = {(Ordinal == null ? "null" : Ordinal.ToString())}");
        }

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

            return obj is SubscriptionPhase other &&
                ((Uid == null && other.Uid == null) || (Uid?.Equals(other.Uid) == true)) &&
                ((Cadence == null && other.Cadence == null) || (Cadence?.Equals(other.Cadence) == true)) &&
                ((Periods == null && other.Periods == null) || (Periods?.Equals(other.Periods) == true)) &&
                ((RecurringPriceMoney == null && other.RecurringPriceMoney == null) || (RecurringPriceMoney?.Equals(other.RecurringPriceMoney) == true)) &&
                ((Ordinal == null && other.Ordinal == null) || (Ordinal?.Equals(other.Ordinal) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 718353637;

            if (Uid != null)
            {
               hashCode += Uid.GetHashCode();
            }

            if (Cadence != null)
            {
               hashCode += Cadence.GetHashCode();
            }

            if (Periods != null)
            {
               hashCode += Periods.GetHashCode();
            }

            if (RecurringPriceMoney != null)
            {
               hashCode += RecurringPriceMoney.GetHashCode();
            }

            if (Ordinal != null)
            {
               hashCode += Ordinal.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder Cadence(string cadence)
            {
                this.cadence = cadence;
                return this;
            }

            public Builder RecurringPriceMoney(Models.Money recurringPriceMoney)
            {
                this.recurringPriceMoney = recurringPriceMoney;
                return this;
            }

            public Builder Uid(string uid)
            {
                this.uid = uid;
                return this;
            }

            public Builder Periods(int? periods)
            {
                this.periods = periods;
                return this;
            }

            public Builder Ordinal(long? ordinal)
            {
                this.ordinal = ordinal;
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