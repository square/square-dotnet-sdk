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
    /// CreateGiftCardActivityRequest.
    /// </summary>
    public class CreateGiftCardActivityRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateGiftCardActivityRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="giftCardActivity">gift_card_activity.</param>
        public CreateGiftCardActivityRequest(
            string idempotencyKey,
            Models.GiftCardActivity giftCardActivity)
        {
            this.IdempotencyKey = idempotencyKey;
            this.GiftCardActivity = giftCardActivity;
        }

        /// <summary>
        /// A unique string that identifies the `CreateGiftCardActivity` request.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Represents an action performed on a [gift card]($m/GiftCard) that affects its state or balance.
        /// A gift card activity contains information about a specific activity type. For example, a `REDEEM` activity
        /// includes a `redeem_activity_details` field that contains information about the redemption.
        /// </summary>
        [JsonProperty("gift_card_activity")]
        public Models.GiftCardActivity GiftCardActivity { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateGiftCardActivityRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is CreateGiftCardActivityRequest other &&                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.GiftCardActivity == null && other.GiftCardActivity == null) || (this.GiftCardActivity?.Equals(other.GiftCardActivity) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -51582836;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.GiftCardActivity);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.GiftCardActivity = {(this.GiftCardActivity == null ? "null" : this.GiftCardActivity.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey,
                this.GiftCardActivity);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private Models.GiftCardActivity giftCardActivity;

            /// <summary>
            /// Initialize Builder for CreateGiftCardActivityRequest.
            /// </summary>
            /// <param name="idempotencyKey"> idempotencyKey. </param>
            /// <param name="giftCardActivity"> giftCardActivity. </param>
            public Builder(
                string idempotencyKey,
                Models.GiftCardActivity giftCardActivity)
            {
                this.idempotencyKey = idempotencyKey;
                this.giftCardActivity = giftCardActivity;
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
             /// GiftCardActivity.
             /// </summary>
             /// <param name="giftCardActivity"> giftCardActivity. </param>
             /// <returns> Builder. </returns>
            public Builder GiftCardActivity(Models.GiftCardActivity giftCardActivity)
            {
                this.giftCardActivity = giftCardActivity;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateGiftCardActivityRequest. </returns>
            public CreateGiftCardActivityRequest Build()
            {
                return new CreateGiftCardActivityRequest(
                    this.idempotencyKey,
                    this.giftCardActivity);
            }
        }
    }
}