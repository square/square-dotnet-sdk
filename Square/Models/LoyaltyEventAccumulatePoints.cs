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
    /// LoyaltyEventAccumulatePoints.
    /// </summary>
    public class LoyaltyEventAccumulatePoints
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyEventAccumulatePoints"/> class.
        /// </summary>
        /// <param name="loyaltyProgramId">loyalty_program_id.</param>
        /// <param name="points">points.</param>
        /// <param name="orderId">order_id.</param>
        public LoyaltyEventAccumulatePoints(
            string loyaltyProgramId = null,
            int? points = null,
            string orderId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "points", false },
                { "order_id", false }
            };

            this.LoyaltyProgramId = loyaltyProgramId;
            if (points != null)
            {
                shouldSerialize["points"] = true;
                this.Points = points;
            }

            if (orderId != null)
            {
                shouldSerialize["order_id"] = true;
                this.OrderId = orderId;
            }

        }
        internal LoyaltyEventAccumulatePoints(Dictionary<string, bool> shouldSerialize,
            string loyaltyProgramId = null,
            int? points = null,
            string orderId = null)
        {
            this.shouldSerialize = shouldSerialize;
            LoyaltyProgramId = loyaltyProgramId;
            Points = points;
            OrderId = orderId;
        }

        /// <summary>
        /// The ID of the [loyalty program](entity:LoyaltyProgram).
        /// </summary>
        [JsonProperty("loyalty_program_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LoyaltyProgramId { get; }

        /// <summary>
        /// The number of points accumulated by the event.
        /// </summary>
        [JsonProperty("points")]
        public int? Points { get; }

        /// <summary>
        /// The ID of the [order](entity:Order) for which the buyer accumulated the points.
        /// This field is returned only if the Orders API is used to process orders.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventAccumulatePoints : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePoints()
        {
            return this.shouldSerialize["points"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrderId()
        {
            return this.shouldSerialize["order_id"];
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
            return obj is LoyaltyEventAccumulatePoints other &&                ((this.LoyaltyProgramId == null && other.LoyaltyProgramId == null) || (this.LoyaltyProgramId?.Equals(other.LoyaltyProgramId) == true)) &&
                ((this.Points == null && other.Points == null) || (this.Points?.Equals(other.Points) == true)) &&
                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 893046875;
            hashCode = HashCode.Combine(this.LoyaltyProgramId, this.Points, this.OrderId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LoyaltyProgramId = {(this.LoyaltyProgramId == null ? "null" : this.LoyaltyProgramId == string.Empty ? "" : this.LoyaltyProgramId)}");
            toStringOutput.Add($"this.Points = {(this.Points == null ? "null" : this.Points.ToString())}");
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId == string.Empty ? "" : this.OrderId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LoyaltyProgramId(this.LoyaltyProgramId)
                .Points(this.Points)
                .OrderId(this.OrderId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "points", false },
                { "order_id", false },
            };

            private string loyaltyProgramId;
            private int? points;
            private string orderId;

             /// <summary>
             /// LoyaltyProgramId.
             /// </summary>
             /// <param name="loyaltyProgramId"> loyaltyProgramId. </param>
             /// <returns> Builder. </returns>
            public Builder LoyaltyProgramId(string loyaltyProgramId)
            {
                this.loyaltyProgramId = loyaltyProgramId;
                return this;
            }

             /// <summary>
             /// Points.
             /// </summary>
             /// <param name="points"> points. </param>
             /// <returns> Builder. </returns>
            public Builder Points(int? points)
            {
                shouldSerialize["points"] = true;
                this.points = points;
                return this;
            }

             /// <summary>
             /// OrderId.
             /// </summary>
             /// <param name="orderId"> orderId. </param>
             /// <returns> Builder. </returns>
            public Builder OrderId(string orderId)
            {
                shouldSerialize["order_id"] = true;
                this.orderId = orderId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPoints()
            {
                this.shouldSerialize["points"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetOrderId()
            {
                this.shouldSerialize["order_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyEventAccumulatePoints. </returns>
            public LoyaltyEventAccumulatePoints Build()
            {
                return new LoyaltyEventAccumulatePoints(shouldSerialize,
                    this.loyaltyProgramId,
                    this.points,
                    this.orderId);
            }
        }
    }
}