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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// LoyaltyProgramAccrualRuleCategoryData.
    /// </summary>
    public class LoyaltyProgramAccrualRuleCategoryData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyProgramAccrualRuleCategoryData"/> class.
        /// </summary>
        /// <param name="categoryId">category_id.</param>
        public LoyaltyProgramAccrualRuleCategoryData(string categoryId)
        {
            this.CategoryId = categoryId;
        }

        /// <summary>
        /// The ID of the `CATEGORY` [catalog object](entity:CatalogObject) that buyers can purchase to earn
        /// points.
        /// </summary>
        [JsonProperty("category_id")]
        public string CategoryId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"LoyaltyProgramAccrualRuleCategoryData : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is LoyaltyProgramAccrualRuleCategoryData other
                && (
                    this.CategoryId == null && other.CategoryId == null
                    || this.CategoryId?.Equals(other.CategoryId) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 307764476;
            hashCode = HashCode.Combine(hashCode, this.CategoryId);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CategoryId = {this.CategoryId ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.CategoryId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string categoryId;

            /// <summary>
            /// Initialize Builder for LoyaltyProgramAccrualRuleCategoryData.
            /// </summary>
            /// <param name="categoryId"> categoryId. </param>
            public Builder(string categoryId)
            {
                this.categoryId = categoryId;
            }

            /// <summary>
            /// CategoryId.
            /// </summary>
            /// <param name="categoryId"> categoryId. </param>
            /// <returns> Builder. </returns>
            public Builder CategoryId(string categoryId)
            {
                this.categoryId = categoryId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyProgramAccrualRuleCategoryData. </returns>
            public LoyaltyProgramAccrualRuleCategoryData Build()
            {
                return new LoyaltyProgramAccrualRuleCategoryData(this.categoryId);
            }
        }
    }
}
