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
    public class DeviceCode 
    {
        public DeviceCode(string productType,
            string id = null,
            string name = null,
            string code = null,
            string deviceId = null,
            string locationId = null,
            string status = null,
            string pairBy = null,
            string createdAt = null,
            string statusChangedAt = null,
            string pairedAt = null)
        {
            Id = id;
            Name = name;
            Code = code;
            DeviceId = deviceId;
            ProductType = productType;
            LocationId = locationId;
            Status = status;
            PairBy = pairBy;
            CreatedAt = createdAt;
            StatusChangedAt = statusChangedAt;
            PairedAt = pairedAt;
        }

        /// <summary>
        /// The unique id for this device code.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// An optional user-defined name for the device code.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The unique code that can be used to login.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; }

        /// <summary>
        /// The unique id of the device that used this code. Populated when the device is paired up.
        /// </summary>
        [JsonProperty("device_id")]
        public string DeviceId { get; }

        /// <summary>
        /// Getter for product_type
        /// </summary>
        [JsonProperty("product_type")]
        public string ProductType { get; }

        /// <summary>
        /// The location assigned to this code.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// DeviceCode.Status enum.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// When this DeviceCode will expire and no longer login. Timestamp in RFC 3339 format.
        /// </summary>
        [JsonProperty("pair_by")]
        public string PairBy { get; }

        /// <summary>
        /// When this DeviceCode was created. Timestamp in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// When this DeviceCode's status was last changed. Timestamp in RFC 3339 format.
        /// </summary>
        [JsonProperty("status_changed_at")]
        public string StatusChangedAt { get; }

        /// <summary>
        /// When this DeviceCode was paired. Timestamp in RFC 3339 format.
        /// </summary>
        [JsonProperty("paired_at")]
        public string PairedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(ProductType)
                .Id(Id)
                .Name(Name)
                .Code(Code)
                .DeviceId(DeviceId)
                .LocationId(LocationId)
                .Status(Status)
                .PairBy(PairBy)
                .CreatedAt(CreatedAt)
                .StatusChangedAt(StatusChangedAt)
                .PairedAt(PairedAt);
            return builder;
        }

        public class Builder
        {
            private string productType;
            private string id;
            private string name;
            private string code;
            private string deviceId;
            private string locationId;
            private string status;
            private string pairBy;
            private string createdAt;
            private string statusChangedAt;
            private string pairedAt;

            public Builder(string productType)
            {
                this.productType = productType;
            }
            public Builder ProductType(string value)
            {
                productType = value;
                return this;
            }

            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder Code(string value)
            {
                code = value;
                return this;
            }

            public Builder DeviceId(string value)
            {
                deviceId = value;
                return this;
            }

            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder PairBy(string value)
            {
                pairBy = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public Builder StatusChangedAt(string value)
            {
                statusChangedAt = value;
                return this;
            }

            public Builder PairedAt(string value)
            {
                pairedAt = value;
                return this;
            }

            public DeviceCode Build()
            {
                return new DeviceCode(productType,
                    id,
                    name,
                    code,
                    deviceId,
                    locationId,
                    status,
                    pairBy,
                    createdAt,
                    statusChangedAt,
                    pairedAt);
            }
        }
    }
}