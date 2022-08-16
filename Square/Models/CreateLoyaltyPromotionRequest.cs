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
    /// CreateLoyaltyPromotionRequest.
    /// </summary>
    public class CreateLoyaltyPromotionRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLoyaltyPromotionRequest"/> class.
        /// </summary>
        /// <param name="loyaltyPromotion">loyalty_promotion.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public CreateLoyaltyPromotionRequest(
            Models.LoyaltyPromotion loyaltyPromotion,
            string idempotencyKey)
        {
            this.LoyaltyPromotion = loyaltyPromotion;
            this.IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// Represents a promotion for a [loyalty program]($m/LoyaltyProgram). Loyalty promotions enable buyers
        /// to earn extra points on top of those earned from the base program.
        /// A loyalty program can have a maximum of 10 loyalty promotions with an `ACTIVE` or `SCHEDULED` status.
        /// </summary>
        [JsonProperty("loyalty_promotion")]
        public Models.LoyaltyPromotion LoyaltyPromotion { get; }

        /// <summary>
        /// A unique identifier for this request, which is used to ensure idempotency. For more information,
        /// see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateLoyaltyPromotionRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateLoyaltyPromotionRequest other &&
                ((this.LoyaltyPromotion == null && other.LoyaltyPromotion == null) || (this.LoyaltyPromotion?.Equals(other.LoyaltyPromotion) == true)) &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1974663227;
            hashCode = HashCode.Combine(this.LoyaltyPromotion, this.IdempotencyKey);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LoyaltyPromotion = {(this.LoyaltyPromotion == null ? "null" : this.LoyaltyPromotion.ToString())}");
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LoyaltyPromotion,
                this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.LoyaltyPromotion loyaltyPromotion;
            private string idempotencyKey;

            public Builder(
                Models.LoyaltyPromotion loyaltyPromotion,
                string idempotencyKey)
            {
                this.loyaltyPromotion = loyaltyPromotion;
                this.idempotencyKey = idempotencyKey;
            }

             /// <summary>
             /// LoyaltyPromotion.
             /// </summary>
             /// <param name="loyaltyPromotion"> loyaltyPromotion. </param>
             /// <returns> Builder. </returns>
            public Builder LoyaltyPromotion(Models.LoyaltyPromotion loyaltyPromotion)
            {
                this.loyaltyPromotion = loyaltyPromotion;
                return this;
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
            /// Builds class object.
            /// </summary>
            /// <returns> CreateLoyaltyPromotionRequest. </returns>
            public CreateLoyaltyPromotionRequest Build()
            {
                return new CreateLoyaltyPromotionRequest(
                    this.loyaltyPromotion,
                    this.idempotencyKey);
            }
        }
    }
}