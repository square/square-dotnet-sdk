namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// ListDeviceCodesRequest.
    /// </summary>
    public class ListDeviceCodesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListDeviceCodesRequest"/> class.
        /// </summary>
        /// <param name="cursor">cursor.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="productType">product_type.</param>
        /// <param name="status">status.</param>
        public ListDeviceCodesRequest(
            string cursor = null,
            string locationId = null,
            string productType = null,
            IList<string> status = null)
        {
            this.Cursor = cursor;
            this.LocationId = locationId;
            this.ProductType = productType;
            this.Status = status;
        }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for your original query.
        /// See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.
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
        /// Gets or sets ProductType.
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListDeviceCodesRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.ProductType == null && other.ProductType == null) || (this.ProductType?.Equals(other.ProductType) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -400983667;

            if (this.Cursor != null)
            {
               hashCode += this.Cursor.GetHashCode();
            }

            if (this.LocationId != null)
            {
               hashCode += this.LocationId.GetHashCode();
            }

            if (this.ProductType != null)
            {
               hashCode += this.ProductType.GetHashCode();
            }

            if (this.Status != null)
            {
               hashCode += this.Status.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.ProductType = {(this.ProductType == null ? "null" : this.ProductType.ToString())}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : $"[{string.Join(", ", this.Status)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(this.Cursor)
                .LocationId(this.LocationId)
                .ProductType(this.ProductType)
                .Status(this.Status);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string cursor;
            private string locationId;
            private string productType;
            private IList<string> status;

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// ProductType.
             /// </summary>
             /// <param name="productType"> productType. </param>
             /// <returns> Builder. </returns>
            public Builder ProductType(string productType)
            {
                this.productType = productType;
                return this;
            }

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(IList<string> status)
            {
                this.status = status;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListDeviceCodesRequest. </returns>
            public ListDeviceCodesRequest Build()
            {
                return new ListDeviceCodesRequest(
                    this.cursor,
                    this.locationId,
                    this.productType,
                    this.status);
            }
        }
    }
}