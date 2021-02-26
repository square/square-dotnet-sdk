
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
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// An optional user-defined name for the device code.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
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
        /// Getter for product_type
        /// </summary>
        [JsonProperty("product_type")]
        public string ProductType { get; }

        /// <summary>
        /// The location assigned to this code.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DeviceCode : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"Name = {(Name == null ? "null" : Name == string.Empty ? "" : Name)}");
            toStringOutput.Add($"Code = {(Code == null ? "null" : Code == string.Empty ? "" : Code)}");
            toStringOutput.Add($"DeviceId = {(DeviceId == null ? "null" : DeviceId == string.Empty ? "" : DeviceId)}");
            toStringOutput.Add($"ProductType = {(ProductType == null ? "null" : ProductType == string.Empty ? "" : ProductType)}");
            toStringOutput.Add($"LocationId = {(LocationId == null ? "null" : LocationId == string.Empty ? "" : LocationId)}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status.ToString())}");
            toStringOutput.Add($"PairBy = {(PairBy == null ? "null" : PairBy == string.Empty ? "" : PairBy)}");
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
            toStringOutput.Add($"StatusChangedAt = {(StatusChangedAt == null ? "null" : StatusChangedAt == string.Empty ? "" : StatusChangedAt)}");
            toStringOutput.Add($"PairedAt = {(PairedAt == null ? "null" : PairedAt == string.Empty ? "" : PairedAt)}");
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

            return obj is DeviceCode other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((Name == null && other.Name == null) || (Name?.Equals(other.Name) == true)) &&
                ((Code == null && other.Code == null) || (Code?.Equals(other.Code) == true)) &&
                ((DeviceId == null && other.DeviceId == null) || (DeviceId?.Equals(other.DeviceId) == true)) &&
                ((ProductType == null && other.ProductType == null) || (ProductType?.Equals(other.ProductType) == true)) &&
                ((LocationId == null && other.LocationId == null) || (LocationId?.Equals(other.LocationId) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true)) &&
                ((PairBy == null && other.PairBy == null) || (PairBy?.Equals(other.PairBy) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((StatusChangedAt == null && other.StatusChangedAt == null) || (StatusChangedAt?.Equals(other.StatusChangedAt) == true)) &&
                ((PairedAt == null && other.PairedAt == null) || (PairedAt?.Equals(other.PairedAt) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1978949756;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (Name != null)
            {
               hashCode += Name.GetHashCode();
            }

            if (Code != null)
            {
               hashCode += Code.GetHashCode();
            }

            if (DeviceId != null)
            {
               hashCode += DeviceId.GetHashCode();
            }

            if (ProductType != null)
            {
               hashCode += ProductType.GetHashCode();
            }

            if (LocationId != null)
            {
               hashCode += LocationId.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }

            if (PairBy != null)
            {
               hashCode += PairBy.GetHashCode();
            }

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            if (StatusChangedAt != null)
            {
               hashCode += StatusChangedAt.GetHashCode();
            }

            if (PairedAt != null)
            {
               hashCode += PairedAt.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder ProductType(string productType)
            {
                this.productType = productType;
                return this;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder Code(string code)
            {
                this.code = code;
                return this;
            }

            public Builder DeviceId(string deviceId)
            {
                this.deviceId = deviceId;
                return this;
            }

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public Builder PairBy(string pairBy)
            {
                this.pairBy = pairBy;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder StatusChangedAt(string statusChangedAt)
            {
                this.statusChangedAt = statusChangedAt;
                return this;
            }

            public Builder PairedAt(string pairedAt)
            {
                this.pairedAt = pairedAt;
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