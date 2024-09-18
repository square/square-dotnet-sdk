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

namespace Square.Models
{
    /// <summary>
    /// CalculateLoyaltyPointsResponse.
    /// </summary>
    public class CalculateLoyaltyPointsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculateLoyaltyPointsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="points">points.</param>
        /// <param name="promotionPoints">promotion_points.</param>
        public CalculateLoyaltyPointsResponse(
            IList<Models.Error> errors = null,
            int? points = null,
            int? promotionPoints = null)
        {
            this.Errors = errors;
            this.Points = points;
            this.PromotionPoints = promotionPoints;
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
        /// The number of points that the buyer can earn from the base loyalty program.
        /// </summary>
        [JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
        public int? Points { get; }

        /// <summary>
        /// The number of points that the buyer can earn from a loyalty promotion. To be eligible
        /// to earn promotion points, the purchase must first qualify for program points. When `order_id`
        /// is not provided in the request, this value is always 0.
        /// </summary>
        [JsonProperty("promotion_points", NullValueHandling = NullValueHandling.Ignore)]
        public int? PromotionPoints { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CalculateLoyaltyPointsResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is CalculateLoyaltyPointsResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Points == null && other.Points == null) || (this.Points?.Equals(other.Points) == true)) &&
                ((this.PromotionPoints == null && other.PromotionPoints == null) || (this.PromotionPoints?.Equals(other.PromotionPoints) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1658359664;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.Points, this.PromotionPoints);

            return hashCode;
        }
        internal CalculateLoyaltyPointsResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Points = {(this.Points == null ? "null" : this.Points.ToString())}");
            toStringOutput.Add($"this.PromotionPoints = {(this.PromotionPoints == null ? "null" : this.PromotionPoints.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Points(this.Points)
                .PromotionPoints(this.PromotionPoints);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private int? points;
            private int? promotionPoints;

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
             /// Points.
             /// </summary>
             /// <param name="points"> points. </param>
             /// <returns> Builder. </returns>
            public Builder Points(int? points)
            {
                this.points = points;
                return this;
            }

             /// <summary>
             /// PromotionPoints.
             /// </summary>
             /// <param name="promotionPoints"> promotionPoints. </param>
             /// <returns> Builder. </returns>
            public Builder PromotionPoints(int? promotionPoints)
            {
                this.promotionPoints = promotionPoints;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CalculateLoyaltyPointsResponse. </returns>
            public CalculateLoyaltyPointsResponse Build()
            {
                return new CalculateLoyaltyPointsResponse(
                    this.errors,
                    this.points,
                    this.promotionPoints);
            }
        }
    }
}