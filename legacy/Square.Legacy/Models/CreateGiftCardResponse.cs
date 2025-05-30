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
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// CreateGiftCardResponse.
    /// </summary>
    public class CreateGiftCardResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateGiftCardResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="giftCard">gift_card.</param>
        public CreateGiftCardResponse(
            IList<Models.Error> errors = null,
            Models.GiftCard giftCard = null
        )
        {
            this.Errors = errors;
            this.GiftCard = giftCard;
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
        /// Represents a Square gift card.
        /// </summary>
        [JsonProperty("gift_card", NullValueHandling = NullValueHandling.Ignore)]
        public Models.GiftCard GiftCard { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CreateGiftCardResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CreateGiftCardResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.GiftCard == null && other.GiftCard == null
                    || this.GiftCard?.Equals(other.GiftCard) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1311680382;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.GiftCard);

            return hashCode;
        }

        internal CreateGiftCardResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
            toStringOutput.Add(
                $"this.GiftCard = {(this.GiftCard == null ? "null" : this.GiftCard.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Errors(this.Errors).GiftCard(this.GiftCard);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.GiftCard giftCard;

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
            /// <returns> CreateGiftCardResponse. </returns>
            public CreateGiftCardResponse Build()
            {
                return new CreateGiftCardResponse(this.errors, this.giftCard);
            }
        }
    }
}
