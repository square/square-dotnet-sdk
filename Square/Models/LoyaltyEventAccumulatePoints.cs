
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class LoyaltyEventAccumulatePoints 
    {
        public LoyaltyEventAccumulatePoints(string loyaltyProgramId = null,
            int? points = null,
            string orderId = null)
        {
            LoyaltyProgramId = loyaltyProgramId;
            Points = points;
            OrderId = orderId;
        }

        /// <summary>
        /// The ID of the [loyalty program](#type-LoyaltyProgram).
        /// </summary>
        [JsonProperty("loyalty_program_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LoyaltyProgramId { get; }

        /// <summary>
        /// The number of points accumulated by the event.
        /// </summary>
        [JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
        public int? Points { get; }

        /// <summary>
        /// The ID of the [order](#type-Order) for which the buyer accumulated the points.
        /// This field is returned only if the Orders API is used to process orders.
        /// </summary>
        [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventAccumulatePoints : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LoyaltyProgramId = {(LoyaltyProgramId == null ? "null" : LoyaltyProgramId == string.Empty ? "" : LoyaltyProgramId)}");
            toStringOutput.Add($"Points = {(Points == null ? "null" : Points.ToString())}");
            toStringOutput.Add($"OrderId = {(OrderId == null ? "null" : OrderId == string.Empty ? "" : OrderId)}");
        }

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

            return obj is LoyaltyEventAccumulatePoints other &&
                ((LoyaltyProgramId == null && other.LoyaltyProgramId == null) || (LoyaltyProgramId?.Equals(other.LoyaltyProgramId) == true)) &&
                ((Points == null && other.Points == null) || (Points?.Equals(other.Points) == true)) &&
                ((OrderId == null && other.OrderId == null) || (OrderId?.Equals(other.OrderId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 893046875;

            if (LoyaltyProgramId != null)
            {
               hashCode += LoyaltyProgramId.GetHashCode();
            }

            if (Points != null)
            {
               hashCode += Points.GetHashCode();
            }

            if (OrderId != null)
            {
               hashCode += OrderId.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LoyaltyProgramId(LoyaltyProgramId)
                .Points(Points)
                .OrderId(OrderId);
            return builder;
        }

        public class Builder
        {
            private string loyaltyProgramId;
            private int? points;
            private string orderId;



            public Builder LoyaltyProgramId(string loyaltyProgramId)
            {
                this.loyaltyProgramId = loyaltyProgramId;
                return this;
            }

            public Builder Points(int? points)
            {
                this.points = points;
                return this;
            }

            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
                return this;
            }

            public LoyaltyEventAccumulatePoints Build()
            {
                return new LoyaltyEventAccumulatePoints(loyaltyProgramId,
                    points,
                    orderId);
            }
        }
    }
}