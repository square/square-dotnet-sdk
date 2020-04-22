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
    public class CustomerSegment 
    {
        public CustomerSegment(string name,
            string id = null,
            string createdAt = null,
            string updatedAt = null)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Unique Square-generated ID for the segment.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// Name of the segment.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The timestamp when the segment was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the segment was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Name)
                .Id(Id)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt);
            return builder;
        }

        public class Builder
        {
            private string name;
            private string id;
            private string createdAt;
            private string updatedAt;

            public Builder(string name)
            {
                this.name = name;
            }
            public Builder Name(string value)
            {
                name = value;
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

            public Builder UpdatedAt(string value)
            {
                updatedAt = value;
                return this;
            }

            public CustomerSegment Build()
            {
                return new CustomerSegment(name,
                    id,
                    createdAt,
                    updatedAt);
            }
        }
    }
}