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
    public class AdditionalRecipient 
    {
        public AdditionalRecipient(string locationId,
            string description,
            Models.Money amountMoney,
            string receivableId = null)
        {
            LocationId = locationId;
            Description = description;
            AmountMoney = amountMoney;
            ReceivableId = receivableId;
        }

        /// <summary>
        /// The location ID for a recipient (other than the merchant) receiving a portion of this tender.
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

        /// <summary>
        /// The unique ID for this [AdditionalRecipientReceivable](#type-additionalrecipientreceivable), assigned by the server.
        /// </summary>
        [JsonProperty("receivable_id")]
        public string ReceivableId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(LocationId,
                Description,
                AmountMoney)
                .ReceivableId(ReceivableId);
            return builder;
        }

        public class Builder
        {
            private string locationId;
            private string description;
            private Models.Money amountMoney;
            private string receivableId;

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

            public Builder ReceivableId(string value)
            {
                receivableId = value;
                return this;
            }

            public AdditionalRecipient Build()
            {
                return new AdditionalRecipient(locationId,
                    description,
                    amountMoney,
                    receivableId);
            }
        }
    }
}