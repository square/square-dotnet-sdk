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

namespace Square.Models
{
    /// <summary>
    /// PaymentLinkRelatedResources.
    /// </summary>
    public class PaymentLinkRelatedResources
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentLinkRelatedResources"/> class.
        /// </summary>
        /// <param name="orders">orders.</param>
        /// <param name="subscriptionPlans">subscription_plans.</param>
        public PaymentLinkRelatedResources(
            IList<Models.Order> orders = null,
            IList<Models.CatalogObject> subscriptionPlans = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "orders", false },
                { "subscription_plans", false }
            };

            if (orders != null)
            {
                shouldSerialize["orders"] = true;
                this.Orders = orders;
            }

            if (subscriptionPlans != null)
            {
                shouldSerialize["subscription_plans"] = true;
                this.SubscriptionPlans = subscriptionPlans;
            }

        }
        internal PaymentLinkRelatedResources(Dictionary<string, bool> shouldSerialize,
            IList<Models.Order> orders = null,
            IList<Models.CatalogObject> subscriptionPlans = null)
        {
            this.shouldSerialize = shouldSerialize;
            Orders = orders;
            SubscriptionPlans = subscriptionPlans;
        }

        /// <summary>
        /// The order associated with the payment link.
        /// </summary>
        [JsonProperty("orders")]
        public IList<Models.Order> Orders { get; }

        /// <summary>
        /// The subscription plan associated with the payment link.
        /// </summary>
        [JsonProperty("subscription_plans")]
        public IList<Models.CatalogObject> SubscriptionPlans { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaymentLinkRelatedResources : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrders()
        {
            return this.shouldSerialize["orders"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSubscriptionPlans()
        {
            return this.shouldSerialize["subscription_plans"];
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
            return obj is PaymentLinkRelatedResources other &&                ((this.Orders == null && other.Orders == null) || (this.Orders?.Equals(other.Orders) == true)) &&
                ((this.SubscriptionPlans == null && other.SubscriptionPlans == null) || (this.SubscriptionPlans?.Equals(other.SubscriptionPlans) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -255234939;
            hashCode = HashCode.Combine(this.Orders, this.SubscriptionPlans);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Orders = {(this.Orders == null ? "null" : $"[{string.Join(", ", this.Orders)} ]")}");
            toStringOutput.Add($"this.SubscriptionPlans = {(this.SubscriptionPlans == null ? "null" : $"[{string.Join(", ", this.SubscriptionPlans)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Orders(this.Orders)
                .SubscriptionPlans(this.SubscriptionPlans);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "orders", false },
                { "subscription_plans", false },
            };

            private IList<Models.Order> orders;
            private IList<Models.CatalogObject> subscriptionPlans;

             /// <summary>
             /// Orders.
             /// </summary>
             /// <param name="orders"> orders. </param>
             /// <returns> Builder. </returns>
            public Builder Orders(IList<Models.Order> orders)
            {
                shouldSerialize["orders"] = true;
                this.orders = orders;
                return this;
            }

             /// <summary>
             /// SubscriptionPlans.
             /// </summary>
             /// <param name="subscriptionPlans"> subscriptionPlans. </param>
             /// <returns> Builder. </returns>
            public Builder SubscriptionPlans(IList<Models.CatalogObject> subscriptionPlans)
            {
                shouldSerialize["subscription_plans"] = true;
                this.subscriptionPlans = subscriptionPlans;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetOrders()
            {
                this.shouldSerialize["orders"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSubscriptionPlans()
            {
                this.shouldSerialize["subscription_plans"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PaymentLinkRelatedResources. </returns>
            public PaymentLinkRelatedResources Build()
            {
                return new PaymentLinkRelatedResources(shouldSerialize,
                    this.orders,
                    this.subscriptionPlans);
            }
        }
    }
}