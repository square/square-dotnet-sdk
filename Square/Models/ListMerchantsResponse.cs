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
    public class ListMerchantsResponse 
    {
        public ListMerchantsResponse(IList<Models.Error> errors = null,
            IList<Models.Merchant> merchant = null,
            int? cursor = null)
        {
            Errors = errors;
            Merchant = merchant;
            Cursor = cursor;
        }

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

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Merchant(Merchant)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.Merchant> merchant;
            private int? cursor;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Merchant(IList<Models.Merchant> merchant)
            {
                this.merchant = merchant;
                return this;
            }

            public Builder Cursor(int? cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public ListMerchantsResponse Build()
            {
                return new ListMerchantsResponse(errors,
                    merchant,
                    cursor);
            }
        }
    }
}