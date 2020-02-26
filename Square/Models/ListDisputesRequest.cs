using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class ListDisputesRequest 
    {
        public ListDisputesRequest(string cursor = null,
            IList<string> states = null,
            string locationId = null)
        {
            Cursor = cursor;
            States = states;
            LocationId = locationId;
        }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for the original query.
        /// For more information, see [Paginating](https://developer.squareup.com/docs/basics/api101/pagination).
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// The dispute states to filter the result.
        /// If not specified, the endpoint
        /// returns all open disputes (dispute status is not
        /// `INQUIRY_CLOSED`, `WON`, or `LOST`).
        /// See [DisputeState](#type-disputestate) for possible values
        /// </summary>
        [JsonProperty("states")]
        public IList<string> States { get; }

        /// <summary>
        /// The ID of the location for which to return 
        /// a list of disputes. If not specified,
        /// the endpoint returns all open disputes
        /// (dispute status is not `INQUIRY_CLOSED`, `WON`, or 
        /// `LOST`) associated with all locations.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(Cursor)
                .States(States)
                .LocationId(LocationId);
            return builder;
        }

        public class Builder
        {
            private string cursor;
            private IList<string> states = new List<string>();
            private string locationId;

            public Builder() { }
            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public Builder States(IList<string> value)
            {
                states = value;
                return this;
            }

            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public ListDisputesRequest Build()
            {
                return new ListDisputesRequest(cursor,
                    states,
                    locationId);
            }
        }
    }
}