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
        /// The timestamp when payment risk was evaluated, in RFC3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// Getter for risk_level
        /// </summary>
        [JsonProperty("risk_level", NullValueHandling = NullValueHandling.Ignore)]
        public string RiskLevel { get; }

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