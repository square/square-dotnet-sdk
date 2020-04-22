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
    public class ListCustomerGroupsResponse 
    {
        public ListCustomerGroupsResponse(IList<Models.Error> errors = null,
            IList<Models.CustomerGroup> groups = null,
            string cursor = null)
        {
            Errors = errors;
            Groups = groups;
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
        /// A list of customer groups belonging to the current merchant.
        /// </summary>
        [JsonProperty("groups")]
        public IList<Models.CustomerGroup> Groups { get; }

        /// <summary>
        /// A pagination cursor to retrieve the next set of results for your
        /// original query to the endpoint. This value is present only if the request
        /// succeeded and additional results are available.
        /// See the [Pagination guide](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Groups(Groups)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.CustomerGroup> groups = new List<Models.CustomerGroup>();
            private string cursor;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Groups(IList<Models.CustomerGroup> value)
            {
                groups = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public ListCustomerGroupsResponse Build()
            {
                return new ListCustomerGroupsResponse(errors,
                    groups,
                    cursor);
            }
        }
    }
}