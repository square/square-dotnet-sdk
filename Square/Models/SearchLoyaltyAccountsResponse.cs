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
    /// SearchLoyaltyAccountsResponse.
    /// </summary>
    public class SearchLoyaltyAccountsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchLoyaltyAccountsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="loyaltyAccounts">loyalty_accounts.</param>
        /// <param name="cursor">cursor.</param>
        public SearchLoyaltyAccountsResponse(
            IList<Models.Error> errors = null,
            IList<Models.LoyaltyAccount> loyaltyAccounts = null,
            string cursor = null)
        {
            this.Errors = errors;
            this.LoyaltyAccounts = loyaltyAccounts;
            this.Cursor = cursor;
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
        /// The loyalty accounts that met the search criteria,
        /// in order of creation date.
        /// </summary>
        [JsonProperty("loyalty_accounts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.LoyaltyAccount> LoyaltyAccounts { get; }

        /// <summary>
        /// The pagination cursor to use in a subsequent
        /// request. If empty, this is the final response.
        /// For more information,
        /// see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchLoyaltyAccountsResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchLoyaltyAccountsResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.LoyaltyAccounts == null && other.LoyaltyAccounts == null) || (this.LoyaltyAccounts?.Equals(other.LoyaltyAccounts) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1725580243;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.LoyaltyAccounts, this.Cursor);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.LoyaltyAccounts = {(this.LoyaltyAccounts == null ? "null" : $"[{string.Join(", ", this.LoyaltyAccounts)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .LoyaltyAccounts(this.LoyaltyAccounts)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.LoyaltyAccount> loyaltyAccounts;
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
             /// LoyaltyAccounts.
             /// </summary>
             /// <param name="loyaltyAccounts"> loyaltyAccounts. </param>
             /// <returns> Builder. </returns>
            public Builder LoyaltyAccounts(IList<Models.LoyaltyAccount> loyaltyAccounts)
            {
                this.loyaltyAccounts = loyaltyAccounts;
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
            /// <returns> SearchLoyaltyAccountsResponse. </returns>
            public SearchLoyaltyAccountsResponse Build()
            {
                return new SearchLoyaltyAccountsResponse(
                    this.errors,
                    this.loyaltyAccounts,
                    this.cursor);
            }
        }
    }
}