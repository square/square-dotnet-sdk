
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
    public class RiskEvaluation 
    {
        public RiskEvaluation(string createdAt = null,
            string riskLevel = null)
        {
            CreatedAt = createdAt;
            RiskLevel = riskLevel;
        }

        /// <summary>
        /// The timestamp when payment risk was evaluated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// Getter for risk_level
        /// </summary>
        [JsonProperty("risk_level", NullValueHandling = NullValueHandling.Ignore)]
        public string RiskLevel { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RiskEvaluation : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
            toStringOutput.Add($"RiskLevel = {(RiskLevel == null ? "null" : RiskLevel.ToString())}");
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

            return obj is RiskEvaluation other &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((RiskLevel == null && other.RiskLevel == null) || (RiskLevel?.Equals(other.RiskLevel) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 692810603;

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            if (RiskLevel != null)
            {
               hashCode += RiskLevel.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CreatedAt(CreatedAt)
                .RiskLevel(RiskLevel);
            return builder;
        }

        public class Builder
        {
            private string createdAt;
            private string riskLevel;



            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder RiskLevel(string riskLevel)
            {
                this.riskLevel = riskLevel;
                return this;
            }

            public RiskEvaluation Build()
            {
                return new RiskEvaluation(createdAt,
                    riskLevel);
            }
        }
    }
}