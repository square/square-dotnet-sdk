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
    public class RetrieveMerchantResponse 
    {
        public RetrieveMerchantResponse(IList<Models.Error> errors = null,
            Models.Merchant merchant = null)
        {
            Errors = errors;
            Merchant = merchant;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a Square seller.
        /// </summary>
        [JsonProperty("merchant", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Merchant Merchant { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Merchant(Merchant);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.Merchant merchant;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Merchant(Models.Merchant merchant)
            {
                this.merchant = merchant;
                return this;
            }

            public RetrieveMerchantResponse Build()
            {
                return new RetrieveMerchantResponse(errors,
                    merchant);
            }
        }
    }
}