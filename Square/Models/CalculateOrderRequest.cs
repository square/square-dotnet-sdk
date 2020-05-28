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
    public class CalculateOrderRequest 
    {
        public CalculateOrderRequest(Models.Order order,
            IList<Models.OrderReward> proposedRewards = null)
        {
            Order = order;
            ProposedRewards = proposedRewards;
        }

        /// <summary>
        /// Contains all information related to a single order to process with Square,
        /// including line items that specify the products to purchase. Order objects also
        /// include information on any associated tenders, refunds, and returns.
        /// All Connect V2 Transactions have all been converted to Orders including all associated
        /// itemization data.
        /// </summary>
        [JsonProperty("order")]
        public Models.Order Order { get; }

        /// <summary>
        /// Identifies one or more loyalty reward tiers to apply during order calculation.
        /// The discounts defined by the reward tiers are added to the order only to preview the
        /// effect of applying the specified reward(s). The reward(s) do not correspond to actual
        /// redemptions, that is, no `reward`s are created. Therefore, the reward `id`s are
        /// random strings used only to reference the reward tier.
        /// </summary>
        [JsonProperty("proposed_rewards")]
        public IList<Models.OrderReward> ProposedRewards { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Order)
                .ProposedRewards(ProposedRewards);
            return builder;
        }

        public class Builder
        {
            private Models.Order order;
            private IList<Models.OrderReward> proposedRewards = new List<Models.OrderReward>();

            public Builder(Models.Order order)
            {
                this.order = order;
            }
            public Builder Order(Models.Order value)
            {
                order = value;
                return this;
            }

            public Builder ProposedRewards(IList<Models.OrderReward> value)
            {
                proposedRewards = value;
                return this;
            }

            public CalculateOrderRequest Build()
            {
                return new CalculateOrderRequest(order,
                    proposedRewards);
            }
        }
    }
}