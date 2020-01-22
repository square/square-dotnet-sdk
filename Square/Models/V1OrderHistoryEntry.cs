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
    public class V1OrderHistoryEntry 
    {
        public V1OrderHistoryEntry(string action = null,
            string createdAt = null)
        {
            Action = action;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// Getter for action
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; }

        /// <summary>
        /// The time when the action was performed, in ISO 8601 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Action(Action)
                .CreatedAt(CreatedAt);
            return builder;
        }

        public class Builder
        {
            private string action;
            private string createdAt;

            public Builder() { }
            public Builder Action(string value)
            {
                action = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public V1OrderHistoryEntry Build()
            {
                return new V1OrderHistoryEntry(action,
                    createdAt);
            }
        }
    }
}