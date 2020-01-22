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
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The list of requested refunds.
        /// </summary>
        [JsonProperty("refunds")]
        public IList<Models.PaymentRefund> Refunds { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent request. If empty,
        /// this is the final response.
        /// See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor")]
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
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.PaymentRefund> refunds = new List<Models.PaymentRefund>();
            private string cursor;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Refunds(IList<Models.PaymentRefund> value)
            {
                refunds = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
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