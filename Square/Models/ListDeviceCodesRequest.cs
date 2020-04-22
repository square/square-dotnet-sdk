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
    public class ListDeviceCodesRequest 
    {
        public ListDeviceCodesRequest(string cursor = null,
            string locationId = null,
            string productType = null)
        {
            Cursor = cursor;
            LocationId = locationId;
            ProductType = productType;
        }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for your original query.
        /// See [Paginating results](#paginatingresults) for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// If specified, only returns DeviceCodes of the specified location.
        /// Returns DeviceCodes of all locations if empty.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// Getter for product_type
        /// </summary>
        [JsonProperty("product_type")]
        public string ProductType { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(Cursor)
                .LocationId(LocationId)
                .ProductType(ProductType);
            return builder;
        }

        public class Builder
        {
            private string cursor;
            private string locationId;
            private string productType;

            public Builder() { }
            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public Builder ProductType(string value)
            {
                productType = value;
                return this;
            }

            public ListDeviceCodesRequest Build()
            {
                return new ListDeviceCodesRequest(cursor,
                    locationId,
                    productType);
            }
        }
    }
}