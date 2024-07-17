namespace Square.Models
{
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

    /// <summary>
    /// AdditionalRecipient.
    /// </summary>
    public class AdditionalRecipient
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionalRecipient"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="description">description.</param>
        /// <param name="receivableId">receivable_id.</param>
        public AdditionalRecipient(
            string locationId,
            Models.Money amountMoney,
            string description = null,
            string receivableId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "description", false },
                { "receivable_id", false }
            };

            this.LocationId = locationId;
            if (description != null)
            {
                shouldSerialize["description"] = true;
                this.Description = description;
            }

            this.AmountMoney = amountMoney;
            if (receivableId != null)
            {
                shouldSerialize["receivable_id"] = true;
                this.ReceivableId = receivableId;
            }

        }
        internal AdditionalRecipient(Dictionary<string, bool> shouldSerialize,
            string locationId,
            Models.Money amountMoney,
            string description = null,
            string receivableId = null)
        {
            this.shouldSerialize = shouldSerialize;
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
        /// The unique ID for the RETIRED `AdditionalRecipientReceivable` object. This field should be empty for any `AdditionalRecipient` objects created after the retirement.
        /// </summary>
        [JsonProperty("receivable_id")]
        public string ReceivableId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AdditionalRecipient : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDescription()
        {
            return this.shouldSerialize["description"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReceivableId()
        {
            return this.shouldSerialize["receivable_id"];
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
            return obj is AdditionalRecipient other &&                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.ReceivableId == null && other.ReceivableId == null) || (this.ReceivableId?.Equals(other.ReceivableId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1717136415;
            hashCode = HashCode.Combine(this.LocationId, this.Description, this.AmountMoney, this.ReceivableId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.ReceivableId = {(this.ReceivableId == null ? "null" : this.ReceivableId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LocationId,
                this.AmountMoney)
                .Description(this.Description)
                .ReceivableId(this.ReceivableId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "description", false },
                { "receivable_id", false },
            };

            private string locationId;
            private Models.Money amountMoney;
            private string description;
            private string receivableId;

            /// <summary>
            /// Initialize Builder for AdditionalRecipient.
            /// </summary>
            /// <param name="locationId"> locationId. </param>
            /// <param name="amountMoney"> amountMoney. </param>
            public Builder(
                string locationId,
                Models.Money amountMoney)
            {
                this.locationId = locationId;
                this.amountMoney = amountMoney;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// AmountMoney.
             /// </summary>
             /// <param name="amountMoney"> amountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

             /// <summary>
             /// Description.
             /// </summary>
             /// <param name="description"> description. </param>
             /// <returns> Builder. </returns>
            public Builder Description(string description)
            {
                shouldSerialize["description"] = true;
                this.description = description;
                return this;
            }

             /// <summary>
             /// ReceivableId.
             /// </summary>
             /// <param name="receivableId"> receivableId. </param>
             /// <returns> Builder. </returns>
            public Builder ReceivableId(string receivableId)
            {
                shouldSerialize["receivable_id"] = true;
                this.receivableId = receivableId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDescription()
            {
                this.shouldSerialize["description"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetReceivableId()
            {
                this.shouldSerialize["receivable_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> AdditionalRecipient. </returns>
            public AdditionalRecipient Build()
            {
                return new AdditionalRecipient(shouldSerialize,
                    this.locationId,
                    this.amountMoney,
                    this.description,
                    this.receivableId);
            }
        }
    }
}