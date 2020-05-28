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
        [JsonProperty("id")]
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
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

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
            public Builder Type(string value)
            {
                type = value;
                return this;
            }

            public Builder MValue(string value)
            {
                mValue = value;
                return this;
            }

            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
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