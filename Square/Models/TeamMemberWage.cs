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
    public class TeamMemberWage 
    {
        public TeamMemberWage(string id = null,
            string teamMemberId = null,
            string title = null,
            Models.Money hourlyRate = null)
        {
            Id = id;
            TeamMemberId = teamMemberId;
            Title = title;
            HourlyRate = hourlyRate;
        }

        /// <summary>
        /// UUID for this object.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The `Team Member` that this wage is assigned to.
        /// </summary>
        [JsonProperty("team_member_id")]
        public string TeamMemberId { get; }

        /// <summary>
        /// The job title that this wage relates to.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("hourly_rate")]
        public Models.Money HourlyRate { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .TeamMemberId(TeamMemberId)
                .Title(Title)
                .HourlyRate(HourlyRate);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string teamMemberId;
            private string title;
            private Models.Money hourlyRate;

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder TeamMemberId(string value)
            {
                teamMemberId = value;
                return this;
            }

            public Builder Title(string value)
            {
                title = value;
                return this;
            }

            public Builder HourlyRate(Models.Money value)
            {
                hourlyRate = value;
                return this;
            }

            public TeamMemberWage Build()
            {
                return new TeamMemberWage(id,
                    teamMemberId,
                    title,
                    hourlyRate);
            }
        }
    }
}