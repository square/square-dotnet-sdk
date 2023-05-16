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
    /// SearchLoyaltyAccountsRequestLoyaltyAccountQuery.
    /// </summary>
    public class SearchLoyaltyAccountsRequestLoyaltyAccountQuery
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchLoyaltyAccountsRequestLoyaltyAccountQuery"/> class.
        /// </summary>
        /// <param name="mappings">mappings.</param>
        /// <param name="customerIds">customer_ids.</param>
        public SearchLoyaltyAccountsRequestLoyaltyAccountQuery(
            IList<Models.LoyaltyAccountMapping> mappings = null,
            IList<string> customerIds = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "mappings", false },
                { "customer_ids", false }
            };

            if (mappings != null)
            {
                shouldSerialize["mappings"] = true;
                this.Mappings = mappings;
            }

            if (customerIds != null)
            {
                shouldSerialize["customer_ids"] = true;
                this.CustomerIds = customerIds;
            }

        }
        internal SearchLoyaltyAccountsRequestLoyaltyAccountQuery(Dictionary<string, bool> shouldSerialize,
            IList<Models.LoyaltyAccountMapping> mappings = null,
            IList<string> customerIds = null)
        {
            this.shouldSerialize = shouldSerialize;
            Mappings = mappings;
            CustomerIds = customerIds;
        }

        /// <summary>
        /// The set of mappings to use in the loyalty account search.
        /// This cannot be combined with `customer_ids`.
        /// Max: 30 mappings
        /// </summary>
        [JsonProperty("mappings")]
        public IList<Models.LoyaltyAccountMapping> Mappings { get; }

        /// <summary>
        /// The set of customer IDs to use in the loyalty account search.
        /// This cannot be combined with `mappings`.
        /// Max: 30 customer IDs
        /// </summary>
        [JsonProperty("customer_ids")]
        public IList<string> CustomerIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchLoyaltyAccountsRequestLoyaltyAccountQuery : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMappings()
        {
            return this.shouldSerialize["mappings"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerIds()
        {
            return this.shouldSerialize["customer_ids"];
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
            return obj is SearchLoyaltyAccountsRequestLoyaltyAccountQuery other &&                ((this.Mappings == null && other.Mappings == null) || (this.Mappings?.Equals(other.Mappings) == true)) &&
                ((this.CustomerIds == null && other.CustomerIds == null) || (this.CustomerIds?.Equals(other.CustomerIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1219141926;
            hashCode = HashCode.Combine(this.Mappings, this.CustomerIds);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Mappings = {(this.Mappings == null ? "null" : $"[{string.Join(", ", this.Mappings)} ]")}");
            toStringOutput.Add($"this.CustomerIds = {(this.CustomerIds == null ? "null" : $"[{string.Join(", ", this.CustomerIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Mappings(this.Mappings)
                .CustomerIds(this.CustomerIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "mappings", false },
                { "customer_ids", false },
            };

            private IList<Models.LoyaltyAccountMapping> mappings;
            private IList<string> customerIds;

             /// <summary>
             /// Mappings.
             /// </summary>
             /// <param name="mappings"> mappings. </param>
             /// <returns> Builder. </returns>
            public Builder Mappings(IList<Models.LoyaltyAccountMapping> mappings)
            {
                shouldSerialize["mappings"] = true;
                this.mappings = mappings;
                return this;
            }

             /// <summary>
             /// CustomerIds.
             /// </summary>
             /// <param name="customerIds"> customerIds. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerIds(IList<string> customerIds)
            {
                shouldSerialize["customer_ids"] = true;
                this.customerIds = customerIds;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMappings()
            {
                this.shouldSerialize["mappings"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCustomerIds()
            {
                this.shouldSerialize["customer_ids"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchLoyaltyAccountsRequestLoyaltyAccountQuery. </returns>
            public SearchLoyaltyAccountsRequestLoyaltyAccountQuery Build()
            {
                return new SearchLoyaltyAccountsRequestLoyaltyAccountQuery(shouldSerialize,
                    this.mappings,
                    this.customerIds);
            }
        }
    }
}