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
    /// ApplicationDetails.
    /// </summary>
    public class ApplicationDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDetails"/> class.
        /// </summary>
        /// <param name="squareProduct">square_product.</param>
        /// <param name="applicationId">application_id.</param>
        public ApplicationDetails(
            string squareProduct = null,
            string applicationId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "application_id", false }
            };

            this.SquareProduct = squareProduct;
            if (applicationId != null)
            {
                shouldSerialize["application_id"] = true;
                this.ApplicationId = applicationId;
            }

        }
        internal ApplicationDetails(Dictionary<string, bool> shouldSerialize,
            string squareProduct = null,
            string applicationId = null)
        {
            this.shouldSerialize = shouldSerialize;
            SquareProduct = squareProduct;
            ApplicationId = applicationId;
        }

        /// <summary>
        /// A list of products to return to external callers.
        /// </summary>
        [JsonProperty("square_product", NullValueHandling = NullValueHandling.Ignore)]
        public string SquareProduct { get; }

        /// <summary>
        /// The Square ID assigned to the application used to take the payment.
        /// Application developers can use this information to identify payments that
        /// their application processed.
        /// For example, if a developer uses a custom application to process payments,
        /// this field contains the application ID from the Developer Dashboard.
        /// If a seller uses a [Square App Marketplace](https://developer.squareup.com/docs/app-marketplace)
        /// application to process payments, the field contains the corresponding application ID.
        /// </summary>
        [JsonProperty("application_id")]
        public string ApplicationId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ApplicationDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeApplicationId()
        {
            return this.shouldSerialize["application_id"];
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
            return obj is ApplicationDetails other &&                ((this.SquareProduct == null && other.SquareProduct == null) || (this.SquareProduct?.Equals(other.SquareProduct) == true)) &&
                ((this.ApplicationId == null && other.ApplicationId == null) || (this.ApplicationId?.Equals(other.ApplicationId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1983703019;
            hashCode = HashCode.Combine(this.SquareProduct, this.ApplicationId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SquareProduct = {(this.SquareProduct == null ? "null" : this.SquareProduct.ToString())}");
            toStringOutput.Add($"this.ApplicationId = {(this.ApplicationId == null ? "null" : this.ApplicationId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .SquareProduct(this.SquareProduct)
                .ApplicationId(this.ApplicationId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "application_id", false },
            };

            private string squareProduct;
            private string applicationId;

             /// <summary>
             /// SquareProduct.
             /// </summary>
             /// <param name="squareProduct"> squareProduct. </param>
             /// <returns> Builder. </returns>
            public Builder SquareProduct(string squareProduct)
            {
                this.squareProduct = squareProduct;
                return this;
            }

             /// <summary>
             /// ApplicationId.
             /// </summary>
             /// <param name="applicationId"> applicationId. </param>
             /// <returns> Builder. </returns>
            public Builder ApplicationId(string applicationId)
            {
                shouldSerialize["application_id"] = true;
                this.applicationId = applicationId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetApplicationId()
            {
                this.shouldSerialize["application_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ApplicationDetails. </returns>
            public ApplicationDetails Build()
            {
                return new ApplicationDetails(shouldSerialize,
                    this.squareProduct,
                    this.applicationId);
            }
        }
    }
}