
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
    public class ChargeRequestAdditionalRecipient 
    {
        public ChargeRequestAdditionalRecipient(string locationId,
            string description,
            Models.Money amountMoney)
        {
            LocationId = locationId;
            Description = description;
            AmountMoney = amountMoney;
        }

        /// <summary>
        /// The location ID for a recipient (other than the merchant) receiving a portion of the tender.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The description of the additional recipient.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("amount_money")]
        public Models.Money AmountMoney { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ChargeRequestAdditionalRecipient : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LocationId = {(LocationId == null ? "null" : LocationId == string.Empty ? "" : LocationId)}");
            toStringOutput.Add($"Description = {(Description == null ? "null" : Description == string.Empty ? "" : Description)}");
            toStringOutput.Add($"AmountMoney = {(AmountMoney == null ? "null" : AmountMoney.ToString())}");
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

            return obj is ChargeRequestAdditionalRecipient other &&
                ((LocationId == null && other.LocationId == null) || (LocationId?.Equals(other.LocationId) == true)) &&
                ((Description == null && other.Description == null) || (Description?.Equals(other.Description) == true)) &&
                ((AmountMoney == null && other.AmountMoney == null) || (AmountMoney?.Equals(other.AmountMoney) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1552949827;

            if (LocationId != null)
            {
               hashCode += LocationId.GetHashCode();
            }

            if (Description != null)
            {
               hashCode += Description.GetHashCode();
            }

            if (AmountMoney != null)
            {
               hashCode += AmountMoney.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(LocationId,
                Description,
                AmountMoney);
            return builder;
        }

        public class Builder
        {
            private string locationId;
            private string description;
            private Models.Money amountMoney;

            public Builder(string locationId,
                string description,
                Models.Money amountMoney)
            {
                this.locationId = locationId;
                this.description = description;
                this.amountMoney = amountMoney;
            }

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public Builder Description(string description)
            {
                this.description = description;
                return this;
            }

            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

            public ChargeRequestAdditionalRecipient Build()
            {
                return new ChargeRequestAdditionalRecipient(locationId,
                    description,
                    amountMoney);
            }
        }
    }
}