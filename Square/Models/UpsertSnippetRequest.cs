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
    /// UpsertSnippetRequest.
    /// </summary>
    public class UpsertSnippetRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpsertSnippetRequest"/> class.
        /// </summary>
        /// <param name="snippet">snippet.</param>
        public UpsertSnippetRequest(
            Models.Snippet snippet)
        {
            this.Snippet = snippet;
        }

        /// <summary>
        /// Represents the snippet that is added to a Square Online site. The snippet code is injected into the `head` element of all pages on the site, except for checkout pages.
        /// </summary>
        [JsonProperty("snippet")]
        public Models.Snippet Snippet { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpsertSnippetRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is UpsertSnippetRequest other &&                ((this.Snippet == null && other.Snippet == null) || (this.Snippet?.Equals(other.Snippet) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1430080341;
            hashCode = HashCode.Combine(this.Snippet);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Snippet = {(this.Snippet == null ? "null" : this.Snippet.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Snippet);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Snippet snippet;

            /// <summary>
            /// Initialize Builder for UpsertSnippetRequest.
            /// </summary>
            /// <param name="snippet"> snippet. </param>
            public Builder(
                Models.Snippet snippet)
            {
                this.snippet = snippet;
            }

             /// <summary>
             /// Snippet.
             /// </summary>
             /// <param name="snippet"> snippet. </param>
             /// <returns> Builder. </returns>
            public Builder Snippet(Models.Snippet snippet)
            {
                this.snippet = snippet;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpsertSnippetRequest. </returns>
            public UpsertSnippetRequest Build()
            {
                return new UpsertSnippetRequest(
                    this.snippet);
            }
        }
    }
}