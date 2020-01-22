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
    public class ListAdditionalRecipientReceivableRefundsResponse 
    {
        public ListAdditionalRecipientReceivableRefundsResponse(IList<Models.Error> errors = null,
            IList<Models.AdditionalRecipientReceivableRefund> receivableRefunds = null,
            string cursor = null)
        {
            Errors = errors;
            ReceivableRefunds = receivableRefunds;
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
        /// An array of AdditionalRecipientReceivableRefunds that match your query.
        /// </summary>
        [JsonProperty("receivable_refunds")]
        public IList<Models.AdditionalRecipientReceivableRefund> ReceivableRefunds { get; }

        /// <summary>
        /// A pagination cursor for retrieving the next set of results,
        /// if any remain. Provide this value as the `cursor` parameter in a subsequent
        /// request to this endpoint.
        /// See [Paginating results](#paginatingresults) for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .ReceivableRefunds(ReceivableRefunds)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.AdditionalRecipientReceivableRefund> receivableRefunds = new List<Models.AdditionalRecipientReceivableRefund>();
            private string cursor;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder ReceivableRefunds(IList<Models.AdditionalRecipientReceivableRefund> value)
            {
                receivableRefunds = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public ListAdditionalRecipientReceivableRefundsResponse Build()
            {
                return new ListAdditionalRecipientReceivableRefundsResponse(errors,
                    receivableRefunds,
                    cursor);
            }
        }
    }
}