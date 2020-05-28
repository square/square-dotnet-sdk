using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class SearchLoyaltyAccountsResponse 
    {
        public SearchLoyaltyAccountsResponse(IList<Models.Error> errors = null,
            IList<Models.LoyaltyAccount> loyaltyAccounts = null,
            string cursor = null)
        {
            Errors = errors;
            LoyaltyAccounts = loyaltyAccounts;
            Cursor = cursor;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The loyalty accounts that met the search criteria,  
        /// in order of creation date.
        /// </summary>
        [JsonProperty("loyalty_accounts")]
        public IList<Models.LoyaltyAccount> LoyaltyAccounts { get; }

        /// <summary>
        /// The pagination cursor to use in a subsequent 
        /// request. If empty, this is the final response.
        /// For more information, 
        /// see [Pagination](https://developer.squareup.com/docs/docs/basics/api101/pagination).
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .LoyaltyAccounts(LoyaltyAccounts)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.LoyaltyAccount> loyaltyAccounts = new List<Models.LoyaltyAccount>();
            private string cursor;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder LoyaltyAccounts(IList<Models.LoyaltyAccount> value)
            {
                loyaltyAccounts = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public SearchLoyaltyAccountsResponse Build()
            {
                return new SearchLoyaltyAccountsResponse(errors,
                    loyaltyAccounts,
                    cursor);
            }
        }
    }
}