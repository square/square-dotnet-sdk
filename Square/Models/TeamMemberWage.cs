
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
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The `Team Member` that this wage is assigned to.
        /// </summary>
        [JsonProperty("team_member_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamMemberId { get; }

        /// <summary>
        /// The job title that this wage relates to.
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("hourly_rate", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money HourlyRate { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TeamMemberWage : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"TeamMemberId = {(TeamMemberId == null ? "null" : TeamMemberId == string.Empty ? "" : TeamMemberId)}");
            toStringOutput.Add($"Title = {(Title == null ? "null" : Title == string.Empty ? "" : Title)}");
            toStringOutput.Add($"HourlyRate = {(HourlyRate == null ? "null" : HourlyRate.ToString())}");
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

            return obj is TeamMemberWage other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((TeamMemberId == null && other.TeamMemberId == null) || (TeamMemberId?.Equals(other.TeamMemberId) == true)) &&
                ((Title == null && other.Title == null) || (Title?.Equals(other.Title) == true)) &&
                ((HourlyRate == null && other.HourlyRate == null) || (HourlyRate?.Equals(other.HourlyRate) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 2085057343;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (TeamMemberId != null)
            {
               hashCode += TeamMemberId.GetHashCode();
            }

            if (Title != null)
            {
               hashCode += Title.GetHashCode();
            }

            if (HourlyRate != null)
            {
               hashCode += HourlyRate.GetHashCode();
            }

            return hashCode;
        }

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



            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder TeamMemberId(string teamMemberId)
            {
                this.teamMemberId = teamMemberId;
                return this;
            }

            public Builder Title(string title)
            {
                this.title = title;
                return this;
            }

            public Builder HourlyRate(Models.Money hourlyRate)
            {
                this.hourlyRate = hourlyRate;
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