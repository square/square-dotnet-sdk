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
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The requested `Merchant` entities.
        /// </summary>
        [JsonProperty("merchant")]
        public IList<Models.Merchant> Merchant { get; }

        /// <summary>
        /// If the  response is truncated, the cursor to use in next  request to fetch next set of objects.
        /// </summary>
        [JsonProperty("cursor")]
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
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.Merchant> merchant = new List<Models.Merchant>();
            private int? cursor;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Merchant(IList<Models.Merchant> value)
            {
                merchant = value;
                return this;
            }

            public Builder Cursor(int? value)
            {
                cursor = value;
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