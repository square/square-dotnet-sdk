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
        [JsonProperty("loyalty_program_id")]
        public string LoyaltyProgramId { get; }

        /// <summary>
        /// The number of points accumulated by the event.
        /// </summary>
        [JsonProperty("points")]
        public int? Points { get; }

        /// <summary>
        /// The ID of the [order](#type-Order) for which the buyer accumulated the points.
        /// This field is returned only if the Orders API is used to process orders.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

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

            public Builder() { }
            public Builder LoyaltyProgramId(string value)
            {
                loyaltyProgramId = value;
                return this;
            }

            public Builder Points(int? value)
            {
                points = value;
                return this;
            }

            public Builder OrderId(string value)
            {
                orderId = value;
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