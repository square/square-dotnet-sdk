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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// RetrieveSnippetResponse.
    /// </summary>
    public class RetrieveSnippetResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveSnippetResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="snippet">snippet.</param>
        public RetrieveSnippetResponse(
            IList<Models.Error> errors = null,
            Models.Snippet snippet = null)
        {
            this.Errors = errors;
            this.Snippet = snippet;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents the snippet that is added to a Square Online site. The snippet code is injected into the `head` element of all pages on the site, except for checkout pages.
        /// </summary>
        [JsonProperty("snippet", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Snippet Snippet { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveSnippetResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is RetrieveSnippetResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Snippet == null && other.Snippet == null) || (this.Snippet?.Equals(other.Snippet) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 94025010;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.Snippet);

            return hashCode;
        }
        internal RetrieveSnippetResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Snippet = {(this.Snippet == null ? "null" : this.Snippet.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Snippet(this.Snippet);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.Snippet snippet;

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
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
            /// <returns> RetrieveSnippetResponse. </returns>
            public RetrieveSnippetResponse Build()
            {
                return new RetrieveSnippetResponse(
                    this.errors,
                    this.snippet);
            }
        }
    }
}