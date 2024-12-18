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
    /// UpdateCustomerGroupRequest.
    /// </summary>
    public class UpdateCustomerGroupRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCustomerGroupRequest"/> class.
        /// </summary>
        /// <param name="mGroup">group.</param>
        public UpdateCustomerGroupRequest(
            Models.CustomerGroup mGroup)
        {
            this.MGroup = mGroup;
        }

        /// <summary>
        /// Represents a group of customer profiles.
        /// Customer groups can be created, be modified, and have their membership defined using
        /// the Customers API or within the Customer Directory in the Square Seller Dashboard or Point of Sale.
        /// </summary>
        [JsonProperty("group")]
        public Models.CustomerGroup MGroup { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"UpdateCustomerGroupRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is UpdateCustomerGroupRequest other &&
                (this.MGroup == null && other.MGroup == null ||
                 this.MGroup?.Equals(other.MGroup) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1040897599;
            hashCode = HashCode.Combine(hashCode, this.MGroup);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MGroup = {(this.MGroup == null ? "null" : this.MGroup.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.MGroup);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.CustomerGroup mGroup;

            /// <summary>
            /// Initialize Builder for UpdateCustomerGroupRequest.
            /// </summary>
            /// <param name="mGroup"> mGroup. </param>
            public Builder(
                Models.CustomerGroup mGroup)
            {
                this.mGroup = mGroup;
            }

             /// <summary>
             /// MGroup.
             /// </summary>
             /// <param name="mGroup"> mGroup. </param>
             /// <returns> Builder. </returns>
            public Builder MGroup(Models.CustomerGroup mGroup)
            {
                this.mGroup = mGroup;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateCustomerGroupRequest. </returns>
            public UpdateCustomerGroupRequest Build()
            {
                return new UpdateCustomerGroupRequest(
                    this.mGroup);
            }
        }
    }
}