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
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a Square seller.
        /// </summary>
        [JsonProperty("merchant")]
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
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.Merchant merchant;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Merchant(Models.Merchant value)
            {
                merchant = value;
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