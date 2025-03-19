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
    /// ListLoyaltyPromotionsResponse.
    /// </summary>
    public class ListLoyaltyPromotionsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListLoyaltyPromotionsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="loyaltyPromotions">loyalty_promotions.</param>
        /// <param name="cursor">cursor.</param>
        public ListLoyaltyPromotionsResponse(
            IList<Models.Error> errors = null,
            IList<Models.LoyaltyPromotion> loyaltyPromotions = null,
            string cursor = null
        )
        {
            this.Errors = errors;
            this.LoyaltyPromotions = loyaltyPromotions;
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
        /// The retrieved loyalty promotions.
        /// </summary>
        [JsonProperty("loyalty_promotions", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.LoyaltyPromotion> LoyaltyPromotions { get; }

        /// <summary>
        /// The cursor to use in your next call to this endpoint to retrieve the next page of results
        /// for your original request. This field is present only if the request succeeded and additional
        /// results are available. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ListLoyaltyPromotionsResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is ListLoyaltyPromotionsResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.LoyaltyPromotions == null && other.LoyaltyPromotions == null
                    || this.LoyaltyPromotions?.Equals(other.LoyaltyPromotions) == true
                )
                && (
                    this.Cursor == null && other.Cursor == null
                    || this.Cursor?.Equals(other.Cursor) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1202863333;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.LoyaltyPromotions, this.Cursor);

            return hashCode;
        }

        internal ListLoyaltyPromotionsResponse ContextSetter(HttpContext context)
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
                $"this.LoyaltyPromotions = {(this.LoyaltyPromotions == null ? "null" : $"[{string.Join(", ", this.LoyaltyPromotions)} ]")}"
            );
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .LoyaltyPromotions(this.LoyaltyPromotions)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.LoyaltyPromotion> loyaltyPromotions;
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
            /// LoyaltyPromotions.
            /// </summary>
            /// <param name="loyaltyPromotions"> loyaltyPromotions. </param>
            /// <returns> Builder. </returns>
            public Builder LoyaltyPromotions(IList<Models.LoyaltyPromotion> loyaltyPromotions)
            {
                this.loyaltyPromotions = loyaltyPromotions;
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
            /// <returns> ListLoyaltyPromotionsResponse. </returns>
            public ListLoyaltyPromotionsResponse Build()
            {
                return new ListLoyaltyPromotionsResponse(
                    this.errors,
                    this.loyaltyPromotions,
                    this.cursor
                );
            }
        }
    }
}
