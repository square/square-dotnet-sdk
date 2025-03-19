using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// DeviceCode.
    /// </summary>
    public class DeviceCode
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceCode"/> class.
        /// </summary>
        /// <param name="productType">product_type.</param>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="code">code.</param>
        /// <param name="deviceId">device_id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="status">status.</param>
        /// <param name="pairBy">pair_by.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="statusChangedAt">status_changed_at.</param>
        /// <param name="pairedAt">paired_at.</param>
        public DeviceCode(
            string productType,
            string id = null,
            string name = null,
            string code = null,
            string deviceId = null,
            string locationId = null,
            string status = null,
            string pairBy = null,
            string createdAt = null,
            string statusChangedAt = null,
            string pairedAt = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "location_id", false },
            };
            this.Id = id;

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }
            this.Code = code;
            this.DeviceId = deviceId;
            this.ProductType = productType;

            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }
            this.Status = status;
            this.PairBy = pairBy;
            this.CreatedAt = createdAt;
            this.StatusChangedAt = statusChangedAt;
            this.PairedAt = pairedAt;
        }

        internal DeviceCode(
            Dictionary<string, bool> shouldSerialize,
            string productType,
            string id = null,
            string name = null,
            string code = null,
            string deviceId = null,
            string locationId = null,
            string status = null,
            string pairBy = null,
            string createdAt = null,
            string statusChangedAt = null,
            string pairedAt = null
        )
        {
            this.shouldSerialize = shouldSerialize;
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
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// An optional user-defined name for the device code.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The unique code that can be used to login.
        /// </summary>
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; }

        /// <summary>
        /// The unique id of the device that used this code. Populated when the device is paired up.
        /// </summary>
        [JsonProperty("device_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceId { get; }

        /// <summary>
        /// Gets or sets ProductType.
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
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// When this DeviceCode will expire and no longer login. Timestamp in RFC 3339 format.
        /// </summary>
        [JsonProperty("pair_by", NullValueHandling = NullValueHandling.Ignore)]
        public string PairBy { get; }

        /// <summary>
        /// When this DeviceCode was created. Timestamp in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// When this DeviceCode's status was last changed. Timestamp in RFC 3339 format.
        /// </summary>
        [JsonProperty("status_changed_at", NullValueHandling = NullValueHandling.Ignore)]
        public string StatusChangedAt { get; }

        /// <summary>
        /// When this DeviceCode was paired. Timestamp in RFC 3339 format.
        /// </summary>
        [JsonProperty("paired_at", NullValueHandling = NullValueHandling.Ignore)]
        public string PairedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"DeviceCode : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is DeviceCode other
                && (this.Id == null && other.Id == null || this.Id?.Equals(other.Id) == true)
                && (
                    this.Name == null && other.Name == null || this.Name?.Equals(other.Name) == true
                )
                && (
                    this.Code == null && other.Code == null || this.Code?.Equals(other.Code) == true
                )
                && (
                    this.DeviceId == null && other.DeviceId == null
                    || this.DeviceId?.Equals(other.DeviceId) == true
                )
                && (
                    this.ProductType == null && other.ProductType == null
                    || this.ProductType?.Equals(other.ProductType) == true
                )
                && (
                    this.LocationId == null && other.LocationId == null
                    || this.LocationId?.Equals(other.LocationId) == true
                )
                && (
                    this.Status == null && other.Status == null
                    || this.Status?.Equals(other.Status) == true
                )
                && (
                    this.PairBy == null && other.PairBy == null
                    || this.PairBy?.Equals(other.PairBy) == true
                )
                && (
                    this.CreatedAt == null && other.CreatedAt == null
                    || this.CreatedAt?.Equals(other.CreatedAt) == true
                )
                && (
                    this.StatusChangedAt == null && other.StatusChangedAt == null
                    || this.StatusChangedAt?.Equals(other.StatusChangedAt) == true
                )
                && (
                    this.PairedAt == null && other.PairedAt == null
                    || this.PairedAt?.Equals(other.PairedAt) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1978949756;
            hashCode = HashCode.Combine(
                hashCode,
                this.Id,
                this.Name,
                this.Code,
                this.DeviceId,
                this.ProductType,
                this.LocationId,
                this.Status
            );

            hashCode = HashCode.Combine(
                hashCode,
                this.PairBy,
                this.CreatedAt,
                this.StatusChangedAt,
                this.PairedAt
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id ?? "null"}");
            toStringOutput.Add($"this.Name = {this.Name ?? "null"}");
            toStringOutput.Add($"this.Code = {this.Code ?? "null"}");
            toStringOutput.Add($"this.DeviceId = {this.DeviceId ?? "null"}");
            toStringOutput.Add($"this.ProductType = {this.ProductType ?? "null"}");
            toStringOutput.Add($"this.LocationId = {this.LocationId ?? "null"}");
            toStringOutput.Add(
                $"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}"
            );
            toStringOutput.Add($"this.PairBy = {this.PairBy ?? "null"}");
            toStringOutput.Add($"this.CreatedAt = {this.CreatedAt ?? "null"}");
            toStringOutput.Add($"this.StatusChangedAt = {this.StatusChangedAt ?? "null"}");
            toStringOutput.Add($"this.PairedAt = {this.PairedAt ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.ProductType)
                .Id(this.Id)
                .Name(this.Name)
                .Code(this.Code)
                .DeviceId(this.DeviceId)
                .LocationId(this.LocationId)
                .Status(this.Status)
                .PairBy(this.PairBy)
                .CreatedAt(this.CreatedAt)
                .StatusChangedAt(this.StatusChangedAt)
                .PairedAt(this.PairedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "location_id", false },
            };

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

            /// <summary>
            /// Initialize Builder for DeviceCode.
            /// </summary>
            /// <param name="productType"> productType. </param>
            public Builder(string productType)
            {
                this.productType = productType;
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
            /// Id.
            /// </summary>
            /// <param name="id"> id. </param>
            /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            /// <summary>
            /// Name.
            /// </summary>
            /// <param name="name"> name. </param>
            /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                shouldSerialize["name"] = true;
                this.name = name;
                return this;
            }

            /// <summary>
            /// Code.
            /// </summary>
            /// <param name="code"> code. </param>
            /// <returns> Builder. </returns>
            public Builder Code(string code)
            {
                this.code = code;
                return this;
            }

            /// <summary>
            /// DeviceId.
            /// </summary>
            /// <param name="deviceId"> deviceId. </param>
            /// <returns> Builder. </returns>
            public Builder DeviceId(string deviceId)
            {
                this.deviceId = deviceId;
                return this;
            }

            /// <summary>
            /// LocationId.
            /// </summary>
            /// <param name="locationId"> locationId. </param>
            /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                shouldSerialize["location_id"] = true;
                this.locationId = locationId;
                return this;
            }

            /// <summary>
            /// Status.
            /// </summary>
            /// <param name="status"> status. </param>
            /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            /// <summary>
            /// PairBy.
            /// </summary>
            /// <param name="pairBy"> pairBy. </param>
            /// <returns> Builder. </returns>
            public Builder PairBy(string pairBy)
            {
                this.pairBy = pairBy;
                return this;
            }

            /// <summary>
            /// CreatedAt.
            /// </summary>
            /// <param name="createdAt"> createdAt. </param>
            /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            /// <summary>
            /// StatusChangedAt.
            /// </summary>
            /// <param name="statusChangedAt"> statusChangedAt. </param>
            /// <returns> Builder. </returns>
            public Builder StatusChangedAt(string statusChangedAt)
            {
                this.statusChangedAt = statusChangedAt;
                return this;
            }

            /// <summary>
            /// PairedAt.
            /// </summary>
            /// <param name="pairedAt"> pairedAt. </param>
            /// <returns> Builder. </returns>
            public Builder PairedAt(string pairedAt)
            {
                this.pairedAt = pairedAt;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DeviceCode. </returns>
            public DeviceCode Build()
            {
                return new DeviceCode(
                    shouldSerialize,
                    this.productType,
                    this.id,
                    this.name,
                    this.code,
                    this.deviceId,
                    this.locationId,
                    this.status,
                    this.pairBy,
                    this.createdAt,
                    this.statusChangedAt,
                    this.pairedAt
                );
            }
        }
    }
}
