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
    /// ChargeRequestAdditionalRecipient.
    /// </summary>
    public class ChargeRequestAdditionalRecipient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChargeRequestAdditionalRecipient"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="description">description.</param>
        /// <param name="amountMoney">amount_money.</param>
        public ChargeRequestAdditionalRecipient(
            string locationId,
            string description,
            Models.Money amountMoney
        )
        {
            this.LocationId = locationId;
            this.Description = description;
            this.AmountMoney = amountMoney;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ChargeRequestAdditionalRecipient : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is ChargeRequestAdditionalRecipient other
                && (
                    this.LocationId == null && other.LocationId == null
                    || this.LocationId?.Equals(other.LocationId) == true
                )
                && (
                    this.Description == null && other.Description == null
                    || this.Description?.Equals(other.Description) == true
                )
                && (
                    this.AmountMoney == null && other.AmountMoney == null
                    || this.AmountMoney?.Equals(other.AmountMoney) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1552949827;
            hashCode = HashCode.Combine(
                hashCode,
                this.LocationId,
                this.Description,
                this.AmountMoney
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {this.LocationId ?? "null"}");
            toStringOutput.Add($"this.Description = {this.Description ?? "null"}");
            toStringOutput.Add(
                $"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.LocationId, this.Description, this.AmountMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string locationId;
            private string description;
            private Models.Money amountMoney;

            /// <summary>
            /// Initialize Builder for ChargeRequestAdditionalRecipient.
            /// </summary>
            /// <param name="locationId"> locationId. </param>
            /// <param name="description"> description. </param>
            /// <param name="amountMoney"> amountMoney. </param>
            public Builder(string locationId, string description, Models.Money amountMoney)
            {
                this.locationId = locationId;
                this.description = description;
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
            /// Description.
            /// </summary>
            /// <param name="description"> description. </param>
            /// <returns> Builder. </returns>
            public Builder Description(string description)
            {
                this.description = description;
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
            /// Builds class object.
            /// </summary>
            /// <returns> ChargeRequestAdditionalRecipient. </returns>
            public ChargeRequestAdditionalRecipient Build()
            {
                return new ChargeRequestAdditionalRecipient(
                    this.locationId,
                    this.description,
                    this.amountMoney
                );
            }
        }
    }
}
