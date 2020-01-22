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
            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public Builder Description(string value)
            {
                description = value;
                return this;
            }

            public Builder AmountMoney(Models.Money value)
            {
                amountMoney = value;
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