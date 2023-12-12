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
    /// CategoryPathToRootNode.
    /// </summary>
    public class CategoryPathToRootNode
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryPathToRootNode"/> class.
        /// </summary>
        /// <param name="categoryId">category_id.</param>
        /// <param name="categoryName">category_name.</param>
        public CategoryPathToRootNode(
            string categoryId = null,
            string categoryName = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "category_id", false },
                { "category_name", false }
            };

            if (categoryId != null)
            {
                shouldSerialize["category_id"] = true;
                this.CategoryId = categoryId;
            }

            if (categoryName != null)
            {
                shouldSerialize["category_name"] = true;
                this.CategoryName = categoryName;
            }

        }
        internal CategoryPathToRootNode(Dictionary<string, bool> shouldSerialize,
            string categoryId = null,
            string categoryName = null)
        {
            this.shouldSerialize = shouldSerialize;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        /// <summary>
        /// The category's ID.
        /// </summary>
        [JsonProperty("category_id")]
        public string CategoryId { get; }

        /// <summary>
        /// The category's name.
        /// </summary>
        [JsonProperty("category_name")]
        public string CategoryName { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CategoryPathToRootNode : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCategoryId()
        {
            return this.shouldSerialize["category_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCategoryName()
        {
            return this.shouldSerialize["category_name"];
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
            return obj is CategoryPathToRootNode other &&                ((this.CategoryId == null && other.CategoryId == null) || (this.CategoryId?.Equals(other.CategoryId) == true)) &&
                ((this.CategoryName == null && other.CategoryName == null) || (this.CategoryName?.Equals(other.CategoryName) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 879731714;
            hashCode = HashCode.Combine(this.CategoryId, this.CategoryName);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CategoryId = {(this.CategoryId == null ? "null" : this.CategoryId)}");
            toStringOutput.Add($"this.CategoryName = {(this.CategoryName == null ? "null" : this.CategoryName)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CategoryId(this.CategoryId)
                .CategoryName(this.CategoryName);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "category_id", false },
                { "category_name", false },
            };

            private string categoryId;
            private string categoryName;

             /// <summary>
             /// CategoryId.
             /// </summary>
             /// <param name="categoryId"> categoryId. </param>
             /// <returns> Builder. </returns>
            public Builder CategoryId(string categoryId)
            {
                shouldSerialize["category_id"] = true;
                this.categoryId = categoryId;
                return this;
            }

             /// <summary>
             /// CategoryName.
             /// </summary>
             /// <param name="categoryName"> categoryName. </param>
             /// <returns> Builder. </returns>
            public Builder CategoryName(string categoryName)
            {
                shouldSerialize["category_name"] = true;
                this.categoryName = categoryName;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCategoryId()
            {
                this.shouldSerialize["category_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCategoryName()
            {
                this.shouldSerialize["category_name"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CategoryPathToRootNode. </returns>
            public CategoryPathToRootNode Build()
            {
                return new CategoryPathToRootNode(shouldSerialize,
                    this.categoryId,
                    this.categoryName);
            }
        }
    }
}