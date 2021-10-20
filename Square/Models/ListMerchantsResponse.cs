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
    /// ListMerchantsResponse.
    /// </summary>
    public class ListMerchantsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListMerchantsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="merchant">merchant.</param>
        /// <param name="cursor">cursor.</param>
        public ListMerchantsResponse(
            IList<Models.Error> errors = null,
            IList<Models.Merchant> merchant = null,
            int? cursor = null)
        {
            this.Errors = errors;
            this.Merchant = merchant;
            this.Cursor = cursor;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The requested `Merchant` entities.
        /// </summary>
        [JsonProperty("merchant", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Merchant> Merchant { get; }

        /// <summary>
        /// If the  response is truncated, the cursor to use in next  request to fetch next set of objects.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public int? Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListMerchantsResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is ListMerchantsResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Merchant == null && other.Merchant == null) || (this.Merchant?.Equals(other.Merchant) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1250434237;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.Merchant, this.Cursor);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Merchant = {(this.Merchant == null ? "null" : $"[{string.Join(", ", this.Merchant)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Merchant(this.Merchant)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.Merchant> merchant;
            private int? cursor;

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
             /// Merchant.
             /// </summary>
             /// <param name="merchant"> merchant. </param>
             /// <returns> Builder. </returns>
            public Builder Merchant(IList<Models.Merchant> merchant)
            {
                this.merchant = merchant;
                return this;
            }

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(int? cursor)
            {
                this.cursor = cursor;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListMerchantsResponse. </returns>
            public ListMerchantsResponse Build()
            {
                return new ListMerchantsResponse(
                    this.errors,
                    this.merchant,
                    this.cursor);
            }
        }
    }
}