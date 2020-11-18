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
    public class ListPaymentRefundsResponse 
    {
        public ListPaymentRefundsResponse(IList<Models.Error> errors = null,
            IList<Models.PaymentRefund> refunds = null,
            string cursor = null)
        {
            Errors = errors;
            Refunds = refunds;
            Cursor = cursor;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The list of requested refunds.
        /// </summary>
        [JsonProperty("refunds", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.PaymentRefund> Refunds { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent request. If empty,
        /// this is the final response.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Refunds(Refunds)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.PaymentRefund> refunds;
            private string cursor;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Refunds(IList<Models.PaymentRefund> refunds)
            {
                this.refunds = refunds;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public ListPaymentRefundsResponse Build()
            {
                return new ListPaymentRefundsResponse(errors,
                    refunds,
                    cursor);
            }
        }
    }
}