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
    using Square.Utilities;

    /// <summary>
    /// CalculateOrderRequest.
    /// </summary>
    public class CalculateOrderRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculateOrderRequest"/> class.
        /// </summary>
        /// <param name="order">order.</param>
        /// <param name="proposedRewards">proposed_rewards.</param>
        public CalculateOrderRequest(
            Models.Order order,
            IList<Models.OrderReward> proposedRewards = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "proposed_rewards", false }
            };

            this.Order = order;
            if (proposedRewards != null)
            {
                shouldSerialize["proposed_rewards"] = true;
                this.ProposedRewards = proposedRewards;
            }

        }
        internal CalculateOrderRequest(Dictionary<string, bool> shouldSerialize,
            Models.Order order,
            IList<Models.OrderReward> proposedRewards = null)
        {
            this.shouldSerialize = shouldSerialize;
            Order = order;
            ProposedRewards = proposedRewards;
        }

        /// <summary>
        /// Contains all information related to a single order to process with Square,
        /// including line items that specify the products to purchase. `Order` objects also
        /// include information about any associated tenders, refunds, and returns.
        /// All Connect V2 Transactions have all been converted to Orders including all associated
        /// itemization data.
        /// </summary>
        [JsonProperty("order")]
        public Models.Order Order { get; }

        /// <summary>
        /// Identifies one or more loyalty reward tiers to apply during the order calculation.
        /// The discounts defined by the reward tiers are added to the order only to preview the
        /// effect of applying the specified rewards. The rewards do not correspond to actual
        /// redemptions; that is, no `reward`s are created. Therefore, the reward `id`s are
        /// random strings used only to reference the reward tier.
        /// </summary>
        [JsonProperty("proposed_rewards")]
        public IList<Models.OrderReward> ProposedRewards { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CalculateOrderRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeProposedRewards()
        {
            return this.shouldSerialize["proposed_rewards"];
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
            return obj is CalculateOrderRequest other &&                ((this.Order == null && other.Order == null) || (this.Order?.Equals(other.Order) == true)) &&
                ((this.ProposedRewards == null && other.ProposedRewards == null) || (this.ProposedRewards?.Equals(other.ProposedRewards) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 653159834;
            hashCode = HashCode.Combine(this.Order, this.ProposedRewards);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Order = {(this.Order == null ? "null" : this.Order.ToString())}");
            toStringOutput.Add($"this.ProposedRewards = {(this.ProposedRewards == null ? "null" : $"[{string.Join(", ", this.ProposedRewards)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Order)
                .ProposedRewards(this.ProposedRewards);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "proposed_rewards", false },
            };

            private Models.Order order;
            private IList<Models.OrderReward> proposedRewards;

            public Builder(
                Models.Order order)
            {
                this.order = order;
            }

             /// <summary>
             /// Order.
             /// </summary>
             /// <param name="order"> order. </param>
             /// <returns> Builder. </returns>
            public Builder Order(Models.Order order)
            {
                this.order = order;
                return this;
            }

             /// <summary>
             /// ProposedRewards.
             /// </summary>
             /// <param name="proposedRewards"> proposedRewards. </param>
             /// <returns> Builder. </returns>
            public Builder ProposedRewards(IList<Models.OrderReward> proposedRewards)
            {
                shouldSerialize["proposed_rewards"] = true;
                this.proposedRewards = proposedRewards;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetProposedRewards()
            {
                this.shouldSerialize["proposed_rewards"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CalculateOrderRequest. </returns>
            public CalculateOrderRequest Build()
            {
                return new CalculateOrderRequest(shouldSerialize,
                    this.order,
                    this.proposedRewards);
            }
        }
    }
}