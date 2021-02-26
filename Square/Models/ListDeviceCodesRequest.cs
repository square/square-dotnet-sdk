
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
            string productType = null,
            IList<string> status = null)
        {
            Cursor = cursor;
            LocationId = locationId;
            ProductType = productType;
            Status = status;
        }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for your original query.
        /// See [Paginating results](#paginatingresults) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// If specified, only returns DeviceCodes of the specified location.
        /// Returns DeviceCodes of all locations if empty.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// Getter for product_type
        /// </summary>
        [JsonProperty("product_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductType { get; }

        /// <summary>
        /// If specified, returns DeviceCodes with the specified statuses.
        /// Returns DeviceCodes of status `PAIRED` and `UNPAIRED` if empty.
        /// See [DeviceCodeStatus](#type-devicecodestatus) for possible values
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Status { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListDeviceCodesRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Cursor = {(Cursor == null ? "null" : Cursor == string.Empty ? "" : Cursor)}");
            toStringOutput.Add($"LocationId = {(LocationId == null ? "null" : LocationId == string.Empty ? "" : LocationId)}");
            toStringOutput.Add($"ProductType = {(ProductType == null ? "null" : ProductType.ToString())}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : $"[{ string.Join(", ", Status)} ]")}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is ListDeviceCodesRequest other &&
                ((Cursor == null && other.Cursor == null) || (Cursor?.Equals(other.Cursor) == true)) &&
                ((LocationId == null && other.LocationId == null) || (LocationId?.Equals(other.LocationId) == true)) &&
                ((ProductType == null && other.ProductType == null) || (ProductType?.Equals(other.ProductType) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -400983667;

            if (Cursor != null)
            {
               hashCode += Cursor.GetHashCode();
            }

            if (LocationId != null)
            {
               hashCode += LocationId.GetHashCode();
            }

            if (ProductType != null)
            {
               hashCode += ProductType.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(Cursor)
                .LocationId(LocationId)
                .ProductType(ProductType)
                .Status(Status);
            return builder;
        }

        public class Builder
        {
            private string cursor;
            private string locationId;
            private string productType;
            private IList<string> status;



            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public Builder ProductType(string productType)
            {
                this.productType = productType;
                return this;
            }

            public Builder Status(IList<string> status)
            {
                this.status = status;
                return this;
            }

            public ListDeviceCodesRequest Build()
            {
                return new ListDeviceCodesRequest(cursor,
                    locationId,
                    productType,
                    status);
            }
        }
    }
}