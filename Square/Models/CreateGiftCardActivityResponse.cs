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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// CreateGiftCardActivityResponse.
    /// </summary>
    public class CreateGiftCardActivityResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateGiftCardActivityResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="giftCardActivity">gift_card_activity.</param>
        public CreateGiftCardActivityResponse(
            IList<Models.Error> errors = null,
            Models.GiftCardActivity giftCardActivity = null)
        {
            this.Errors = errors;
            this.GiftCardActivity = giftCardActivity;
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
        /// Represents an action performed on a [gift card]($m/GiftCard) that affects its state or balance.
        /// A gift card activity contains information about a specific activity type. For example, a `REDEEM` activity
        /// includes a `redeem_activity_details` field that contains information about the redemption.
        /// </summary>
        [JsonProperty("gift_card_activity", NullValueHandling = NullValueHandling.Ignore)]
        public Models.GiftCardActivity GiftCardActivity { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateGiftCardActivityResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is CreateGiftCardActivityResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.GiftCardActivity == null && other.GiftCardActivity == null) || (this.GiftCardActivity?.Equals(other.GiftCardActivity) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -49918806;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.GiftCardActivity);

            return hashCode;
        }
        internal CreateGiftCardActivityResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.GiftCardActivity = {(this.GiftCardActivity == null ? "null" : this.GiftCardActivity.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .GiftCardActivity(this.GiftCardActivity);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.GiftCardActivity giftCardActivity;

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
            /// <returns> CreateGiftCardActivityResponse. </returns>
            public CreateGiftCardActivityResponse Build()
            {
                return new CreateGiftCardActivityResponse(
                    this.errors,
                    this.giftCardActivity);
            }
        }
    }
}