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
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// SearchTerminalCheckoutsResponse.
    /// </summary>
    public class SearchTerminalCheckoutsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchTerminalCheckoutsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="checkouts">checkouts.</param>
        /// <param name="cursor">cursor.</param>
        public SearchTerminalCheckoutsResponse(
            IList<Models.Error> errors = null,
            IList<Models.TerminalCheckout> checkouts = null,
            string cursor = null
        )
        {
            this.Errors = errors;
            this.Checkouts = checkouts;
            this.Cursor = cursor;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The requested search result of `TerminalCheckout` objects.
        /// </summary>
        [JsonProperty("checkouts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.TerminalCheckout> Checkouts { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent request. If empty,
        /// this is the final response.
        /// See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SearchTerminalCheckoutsResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is SearchTerminalCheckoutsResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.Checkouts == null && other.Checkouts == null
                    || this.Checkouts?.Equals(other.Checkouts) == true
                )
                && (
                    this.Cursor == null && other.Cursor == null
                    || this.Cursor?.Equals(other.Cursor) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -958586851;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Checkouts, this.Cursor);

            return hashCode;
        }

        internal SearchTerminalCheckoutsResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
            toStringOutput.Add(
                $"this.Checkouts = {(this.Checkouts == null ? "null" : $"[{string.Join(", ", this.Checkouts)} ]")}"
            );
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Checkouts(this.Checkouts)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.TerminalCheckout> checkouts;
            private string cursor;

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
            /// Checkouts.
            /// </summary>
            /// <param name="checkouts"> checkouts. </param>
            /// <returns> Builder. </returns>
            public Builder Checkouts(IList<Models.TerminalCheckout> checkouts)
            {
                this.checkouts = checkouts;
                return this;
            }

            /// <summary>
            /// Cursor.
            /// </summary>
            /// <param name="cursor"> cursor. </param>
            /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchTerminalCheckoutsResponse. </returns>
            public SearchTerminalCheckoutsResponse Build()
            {
                return new SearchTerminalCheckoutsResponse(
                    this.errors,
                    this.checkouts,
                    this.cursor
                );
            }
        }
    }
}
