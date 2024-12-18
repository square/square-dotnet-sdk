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
    /// CatalogQueryText.
    /// </summary>
    public class CatalogQueryText
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogQueryText"/> class.
        /// </summary>
        /// <param name="keywords">keywords.</param>
        public CatalogQueryText(
            IList<string> keywords)
        {
            this.Keywords = keywords;
        }

        /// <summary>
        /// A list of 1, 2, or 3 search keywords. Keywords with fewer than 3 alphanumeric characters are ignored.
        /// </summary>
        [JsonProperty("keywords")]
        public IList<string> Keywords { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CatalogQueryText : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CatalogQueryText other &&
                (this.Keywords == null && other.Keywords == null ||
                 this.Keywords?.Equals(other.Keywords) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -192618322;
            hashCode = HashCode.Combine(hashCode, this.Keywords);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Keywords = {(this.Keywords == null ? "null" : $"[{string.Join(", ", this.Keywords)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Keywords);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> keywords;

            /// <summary>
            /// Initialize Builder for CatalogQueryText.
            /// </summary>
            /// <param name="keywords"> keywords. </param>
            public Builder(
                IList<string> keywords)
            {
                this.keywords = keywords;
            }

             /// <summary>
             /// Keywords.
             /// </summary>
             /// <param name="keywords"> keywords. </param>
             /// <returns> Builder. </returns>
            public Builder Keywords(IList<string> keywords)
            {
                this.keywords = keywords;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogQueryText. </returns>
            public CatalogQueryText Build()
            {
                return new CatalogQueryText(
                    this.keywords);
            }
        }
    }
}