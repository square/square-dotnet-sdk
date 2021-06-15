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
    /// ListGiftCardsResponse.
    /// </summary>
    public class ListGiftCardsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListGiftCardsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="giftCards">gift_cards.</param>
        /// <param name="cursor">cursor.</param>
        public ListGiftCardsResponse(
            IList<Models.Error> errors = null,
            IList<Models.GiftCard> giftCards = null,
            string cursor = null)
        {
            this.Errors = errors;
            this.GiftCards = giftCards;
            this.Cursor = cursor;
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
        /// Gift cards retrieved.
        /// </summary>
        [JsonProperty("gift_cards", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.GiftCard> GiftCards { get; }

        /// <summary>
        /// When a response is truncated, it includes a cursor that you can use in a
        /// subsequent request to fetch the next set of gift cards. If empty, this is
        /// the final response.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListGiftCardsResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is ListGiftCardsResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.GiftCards == null && other.GiftCards == null) || (this.GiftCards?.Equals(other.GiftCards) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1242527470;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }

            if (this.Errors != null)
            {
               hashCode += this.Errors.GetHashCode();
            }

            if (this.GiftCards != null)
            {
               hashCode += this.GiftCards.GetHashCode();
            }

            if (this.Cursor != null)
            {
               hashCode += this.Cursor.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.GiftCards = {(this.GiftCards == null ? "null" : $"[{string.Join(", ", this.GiftCards)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .GiftCards(this.GiftCards)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.GiftCard> giftCards;
            private string cursor;

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
             /// GiftCards.
             /// </summary>
             /// <param name="giftCards"> giftCards. </param>
             /// <returns> Builder. </returns>
            public Builder GiftCards(IList<Models.GiftCard> giftCards)
            {
                this.giftCards = giftCards;
                return this;
            }

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListGiftCardsResponse. </returns>
            public ListGiftCardsResponse Build()
            {
                return new ListGiftCardsResponse(
                    this.errors,
                    this.giftCards,
                    this.cursor);
            }
        }
    }
}