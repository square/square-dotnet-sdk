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
    /// TerminalRefundQuerySort.
    /// </summary>
    public class TerminalRefundQuerySort
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalRefundQuerySort"/> class.
        /// </summary>
        /// <param name="sortOrder">sort_order.</param>
        public TerminalRefundQuerySort(
            string sortOrder = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "sort_order", false }
            };

            if (sortOrder != null)
            {
                shouldSerialize["sort_order"] = true;
                this.SortOrder = sortOrder;
            }

        }
        internal TerminalRefundQuerySort(Dictionary<string, bool> shouldSerialize,
            string sortOrder = null)
        {
            this.shouldSerialize = shouldSerialize;
            SortOrder = sortOrder;
        }

        /// <summary>
        /// The order in which results are listed.
        /// - `ASC` - Oldest to newest.
        /// - `DESC` - Newest to oldest (default).
        /// </summary>
        [JsonProperty("sort_order")]
        public string SortOrder { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TerminalRefundQuerySort : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSortOrder()
        {
            return this.shouldSerialize["sort_order"];
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
            return obj is TerminalRefundQuerySort other &&                ((this.SortOrder == null && other.SortOrder == null) || (this.SortOrder?.Equals(other.SortOrder) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -926271698;
            hashCode = HashCode.Combine(this.SortOrder);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SortOrder = {(this.SortOrder == null ? "null" : this.SortOrder)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .SortOrder(this.SortOrder);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "sort_order", false },
            };

            private string sortOrder;

             /// <summary>
             /// SortOrder.
             /// </summary>
             /// <param name="sortOrder"> sortOrder. </param>
             /// <returns> Builder. </returns>
            public Builder SortOrder(string sortOrder)
            {
                shouldSerialize["sort_order"] = true;
                this.sortOrder = sortOrder;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSortOrder()
            {
                this.shouldSerialize["sort_order"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TerminalRefundQuerySort. </returns>
            public TerminalRefundQuerySort Build()
            {
                return new TerminalRefundQuerySort(shouldSerialize,
                    this.sortOrder);
            }
        }
    }
}