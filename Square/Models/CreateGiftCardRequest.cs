namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// CreateGiftCardRequest.
    /// </summary>
    public class CreateGiftCardRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateGiftCardRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="giftCard">gift_card.</param>
        public CreateGiftCardRequest(
            string idempotencyKey,
            string locationId,
            Models.GiftCard giftCard)
        {
            this.IdempotencyKey = idempotencyKey;
            this.LocationId = locationId;
            this.GiftCard = giftCard;
        }

        /// <summary>
        /// A unique string that identifies the `CreateGiftCard` request.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The location ID where the gift card that will be created should be registered.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// Represents a Square gift card.
        /// </summary>
        [JsonProperty("gift_card")]
        public Models.GiftCard GiftCard { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateGiftCardRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateGiftCardRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.GiftCard == null && other.GiftCard == null) || (this.GiftCard?.Equals(other.GiftCard) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -117711612;

            if (this.IdempotencyKey != null)
            {
               hashCode += this.IdempotencyKey.GetHashCode();
            }

            if (this.LocationId != null)
            {
               hashCode += this.LocationId.GetHashCode();
            }

            if (this.GiftCard != null)
            {
               hashCode += this.GiftCard.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.GiftCard = {(this.GiftCard == null ? "null" : this.GiftCard.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey,
                this.LocationId,
                this.GiftCard);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private string locationId;
            private Models.GiftCard giftCard;

            public Builder(
                string idempotencyKey,
                string locationId,
                Models.GiftCard giftCard)
            {
                this.idempotencyKey = idempotencyKey;
                this.locationId = locationId;
                this.giftCard = giftCard;
            }

             /// <summary>
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
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
             /// GiftCard.
             /// </summary>
             /// <param name="giftCard"> giftCard. </param>
             /// <returns> Builder. </returns>
            public Builder GiftCard(Models.GiftCard giftCard)
            {
                this.giftCard = giftCard;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateGiftCardRequest. </returns>
            public CreateGiftCardRequest Build()
            {
                return new CreateGiftCardRequest(
                    this.idempotencyKey,
                    this.locationId,
                    this.giftCard);
            }
        }
    }
}