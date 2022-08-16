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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// CancelLoyaltyPromotionResponse.
    /// </summary>
    public class CancelLoyaltyPromotionResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelLoyaltyPromotionResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="loyaltyPromotion">loyalty_promotion.</param>
        public CancelLoyaltyPromotionResponse(
            IList<Models.Error> errors = null,
            Models.LoyaltyPromotion loyaltyPromotion = null)
        {
            this.Errors = errors;
            this.LoyaltyPromotion = loyaltyPromotion;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a promotion for a [loyalty program]($m/LoyaltyProgram). Loyalty promotions enable buyers
        /// to earn extra points on top of those earned from the base program.
        /// A loyalty program can have a maximum of 10 loyalty promotions with an `ACTIVE` or `SCHEDULED` status.
        /// </summary>
        [JsonProperty("loyalty_promotion", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyPromotion LoyaltyPromotion { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CancelLoyaltyPromotionResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is CancelLoyaltyPromotionResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.LoyaltyPromotion == null && other.LoyaltyPromotion == null) || (this.LoyaltyPromotion?.Equals(other.LoyaltyPromotion) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -784828495;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.LoyaltyPromotion);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.LoyaltyPromotion = {(this.LoyaltyPromotion == null ? "null" : this.LoyaltyPromotion.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .LoyaltyPromotion(this.LoyaltyPromotion);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.LoyaltyPromotion loyaltyPromotion;

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
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
            /// Builds class object.
            /// </summary>
            /// <returns> CancelLoyaltyPromotionResponse. </returns>
            public CancelLoyaltyPromotionResponse Build()
            {
                return new CancelLoyaltyPromotionResponse(
                    this.errors,
                    this.loyaltyPromotion);
            }
        }
    }
}