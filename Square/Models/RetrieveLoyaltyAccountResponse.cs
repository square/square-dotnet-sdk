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
    public class RetrieveLoyaltyAccountResponse 
    {
        public RetrieveLoyaltyAccountResponse(IList<Models.Error> errors = null,
            Models.LoyaltyAccount loyaltyAccount = null)
        {
            Errors = errors;
            LoyaltyAccount = loyaltyAccount;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Describes a loyalty account. For more information, see 
        /// [Loyalty Overview](https://developer.squareup.com/docs/docs/loyalty/overview).
        /// </summary>
        [JsonProperty("loyalty_account")]
        public Models.LoyaltyAccount LoyaltyAccount { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .LoyaltyAccount(LoyaltyAccount);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.LoyaltyAccount loyaltyAccount;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder LoyaltyAccount(Models.LoyaltyAccount value)
            {
                loyaltyAccount = value;
                return this;
            }

            public RetrieveLoyaltyAccountResponse Build()
            {
                return new RetrieveLoyaltyAccountResponse(errors,
                    loyaltyAccount);
            }
        }
    }
}