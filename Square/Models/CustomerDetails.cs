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
    /// CustomerDetails.
    /// </summary>
    public class CustomerDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDetails"/> class.
        /// </summary>
        /// <param name="customerInitiated">customer_initiated.</param>
        /// <param name="sellerKeyedIn">seller_keyed_in.</param>
        public CustomerDetails(
            bool? customerInitiated = null,
            bool? sellerKeyedIn = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "customer_initiated", false },
                { "seller_keyed_in", false }
            };

            if (customerInitiated != null)
            {
                shouldSerialize["customer_initiated"] = true;
                this.CustomerInitiated = customerInitiated;
            }

            if (sellerKeyedIn != null)
            {
                shouldSerialize["seller_keyed_in"] = true;
                this.SellerKeyedIn = sellerKeyedIn;
            }

        }
        internal CustomerDetails(Dictionary<string, bool> shouldSerialize,
            bool? customerInitiated = null,
            bool? sellerKeyedIn = null)
        {
            this.shouldSerialize = shouldSerialize;
            CustomerInitiated = customerInitiated;
            SellerKeyedIn = sellerKeyedIn;
        }

        /// <summary>
        /// Indicates whether the customer initiated the payment.
        /// </summary>
        [JsonProperty("customer_initiated")]
        public bool? CustomerInitiated { get; }

        /// <summary>
        /// Indicates that the seller keyed in payment details on behalf of the customer.
        /// This is used to flag a payment as Mail Order / Telephone Order (MOTO).
        /// </summary>
        [JsonProperty("seller_keyed_in")]
        public bool? SellerKeyedIn { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CustomerDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerInitiated()
        {
            return this.shouldSerialize["customer_initiated"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSellerKeyedIn()
        {
            return this.shouldSerialize["seller_keyed_in"];
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
            return obj is CustomerDetails other &&                ((this.CustomerInitiated == null && other.CustomerInitiated == null) || (this.CustomerInitiated?.Equals(other.CustomerInitiated) == true)) &&
                ((this.SellerKeyedIn == null && other.SellerKeyedIn == null) || (this.SellerKeyedIn?.Equals(other.SellerKeyedIn) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1391775710;
            hashCode = HashCode.Combine(this.CustomerInitiated, this.SellerKeyedIn);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CustomerInitiated = {(this.CustomerInitiated == null ? "null" : this.CustomerInitiated.ToString())}");
            toStringOutput.Add($"this.SellerKeyedIn = {(this.SellerKeyedIn == null ? "null" : this.SellerKeyedIn.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CustomerInitiated(this.CustomerInitiated)
                .SellerKeyedIn(this.SellerKeyedIn);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "customer_initiated", false },
                { "seller_keyed_in", false },
            };

            private bool? customerInitiated;
            private bool? sellerKeyedIn;

             /// <summary>
             /// CustomerInitiated.
             /// </summary>
             /// <param name="customerInitiated"> customerInitiated. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerInitiated(bool? customerInitiated)
            {
                shouldSerialize["customer_initiated"] = true;
                this.customerInitiated = customerInitiated;
                return this;
            }

             /// <summary>
             /// SellerKeyedIn.
             /// </summary>
             /// <param name="sellerKeyedIn"> sellerKeyedIn. </param>
             /// <returns> Builder. </returns>
            public Builder SellerKeyedIn(bool? sellerKeyedIn)
            {
                shouldSerialize["seller_keyed_in"] = true;
                this.sellerKeyedIn = sellerKeyedIn;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCustomerInitiated()
            {
                this.shouldSerialize["customer_initiated"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSellerKeyedIn()
            {
                this.shouldSerialize["seller_keyed_in"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CustomerDetails. </returns>
            public CustomerDetails Build()
            {
                return new CustomerDetails(shouldSerialize,
                    this.customerInitiated,
                    this.sellerKeyedIn);
            }
        }
    }
}