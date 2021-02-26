
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
        [JsonProperty("action", NullValueHandling = NullValueHandling.Ignore)]
        public string Action { get; }

        /// <summary>
        /// The time when the action was performed, in ISO 8601 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1OrderHistoryEntry : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Action = {(Action == null ? "null" : Action.ToString())}");
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

            return obj is V1OrderHistoryEntry other &&
                ((Action == null && other.Action == null) || (Action?.Equals(other.Action) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -2009518531;

            if (Action != null)
            {
               hashCode += Action.GetHashCode();
            }

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            return hashCode;
        }

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



            public Builder Action(string action)
            {
                this.action = action;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
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