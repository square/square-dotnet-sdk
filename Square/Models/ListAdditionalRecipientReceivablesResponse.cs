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
    public class ListAdditionalRecipientReceivablesResponse 
    {
        public ListAdditionalRecipientReceivablesResponse(IList<Models.Error> errors = null,
            IList<Models.AdditionalRecipientReceivable> receivables = null,
            string cursor = null)
        {
            Errors = errors;
            Receivables = receivables;
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
        /// An array of AdditionalRecipientReceivables that match your query.
        /// </summary>
        [JsonProperty("receivables")]
        public IList<Models.AdditionalRecipientReceivable> Receivables { get; }

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
                .Receivables(Receivables)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.AdditionalRecipientReceivable> receivables;
            private string cursor;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Receivables(IList<Models.AdditionalRecipientReceivable> value)
            {
                receivables = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public ListAdditionalRecipientReceivablesResponse Build()
            {
                return new ListAdditionalRecipientReceivablesResponse(errors,
                    receivables,
                    cursor);
            }
        }
    }
} 