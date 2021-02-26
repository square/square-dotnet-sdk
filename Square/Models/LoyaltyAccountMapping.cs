
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
    public class LoyaltyAccountMapping 
    {
        public LoyaltyAccountMapping(string type,
            string mValue,
            string id = null,
            string createdAt = null)
        {
            Id = id;
            Type = type;
            MValue = mValue;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// The Square-assigned ID of the mapping.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The type of mapping.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// The phone number, in E.164 format. For example, "+14155551111".
        /// </summary>
        [JsonProperty("value")]
        public string MValue { get; }

        /// <summary>
        /// The timestamp when the mapping was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyAccountMapping : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"Type = {(Type == null ? "null" : Type == string.Empty ? "" : Type)}");
            toStringOutput.Add($"MValue = {(MValue == null ? "null" : MValue == string.Empty ? "" : MValue)}");
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
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

            return obj is LoyaltyAccountMapping other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((Type == null && other.Type == null) || (Type?.Equals(other.Type) == true)) &&
                ((MValue == null && other.MValue == null) || (MValue?.Equals(other.MValue) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1007052003;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (Type != null)
            {
               hashCode += Type.GetHashCode();
            }

            if (MValue != null)
            {
               hashCode += MValue.GetHashCode();
            }

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Type,
                MValue)
                .Id(Id)
                .CreatedAt(CreatedAt);
            return builder;
        }

        public class Builder
        {
            private string type;
            private string mValue;
            private string id;
            private string createdAt;

            public Builder(string type,
                string mValue)
            {
                this.type = type;
                this.mValue = mValue;
            }

            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

            public Builder MValue(string mValue)
            {
                this.mValue = mValue;
                return this;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public LoyaltyAccountMapping Build()
            {
                return new LoyaltyAccountMapping(type,
                    mValue,
                    id,
                    createdAt);
            }
        }
    }
}