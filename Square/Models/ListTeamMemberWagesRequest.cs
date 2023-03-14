namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// ListTeamMemberWagesRequest.
    /// </summary>
    public class ListTeamMemberWagesRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ListTeamMemberWagesRequest"/> class.
        /// </summary>
        /// <param name="teamMemberId">team_member_id.</param>
        /// <param name="limit">limit.</param>
        /// <param name="cursor">cursor.</param>
        public ListTeamMemberWagesRequest(
            string teamMemberId = null,
            int? limit = null,
            string cursor = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "team_member_id", false },
                { "limit", false },
                { "cursor", false }
            };

            if (teamMemberId != null)
            {
                shouldSerialize["team_member_id"] = true;
                this.TeamMemberId = teamMemberId;
            }

            if (limit != null)
            {
                shouldSerialize["limit"] = true;
                this.Limit = limit;
            }

            if (cursor != null)
            {
                shouldSerialize["cursor"] = true;
                this.Cursor = cursor;
            }

        }
        internal ListTeamMemberWagesRequest(Dictionary<string, bool> shouldSerialize,
            string teamMemberId = null,
            int? limit = null,
            string cursor = null)
        {
            this.shouldSerialize = shouldSerialize;
            TeamMemberId = teamMemberId;
            Limit = limit;
            Cursor = cursor;
        }

        /// <summary>
        /// Filter the returned wages to only those that are associated with the
        /// specified team member.
        /// </summary>
        [JsonProperty("team_member_id")]
        public string TeamMemberId { get; }

        /// <summary>
        /// The maximum number of `TeamMemberWage` results to return per page. The number can range between
        /// 1 and 200. The default is 200.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// A pointer to the next page of `EmployeeWage` results to fetch.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListTeamMemberWagesRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTeamMemberId()
        {
            return this.shouldSerialize["team_member_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLimit()
        {
            return this.shouldSerialize["limit"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCursor()
        {
            return this.shouldSerialize["cursor"];
        }

        /// <inheritdoc/>
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

            return obj is ListTeamMemberWagesRequest other &&
                ((this.TeamMemberId == null && other.TeamMemberId == null) || (this.TeamMemberId?.Equals(other.TeamMemberId) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1771115446;
            hashCode = HashCode.Combine(this.TeamMemberId, this.Limit, this.Cursor);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TeamMemberId = {(this.TeamMemberId == null ? "null" : this.TeamMemberId == string.Empty ? "" : this.TeamMemberId)}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMemberId(this.TeamMemberId)
                .Limit(this.Limit)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "team_member_id", false },
                { "limit", false },
                { "cursor", false },
            };

            private string teamMemberId;
            private int? limit;
            private string cursor;

             /// <summary>
             /// TeamMemberId.
             /// </summary>
             /// <param name="teamMemberId"> teamMemberId. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberId(string teamMemberId)
            {
                shouldSerialize["team_member_id"] = true;
                this.teamMemberId = teamMemberId;
                return this;
            }

             /// <summary>
             /// Limit.
             /// </summary>
             /// <param name="limit"> limit. </param>
             /// <returns> Builder. </returns>
            public Builder Limit(int? limit)
            {
                shouldSerialize["limit"] = true;
                this.limit = limit;
                return this;
            }

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                shouldSerialize["cursor"] = true;
                this.cursor = cursor;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTeamMemberId()
            {
                this.shouldSerialize["team_member_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLimit()
            {
                this.shouldSerialize["limit"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCursor()
            {
                this.shouldSerialize["cursor"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListTeamMemberWagesRequest. </returns>
            public ListTeamMemberWagesRequest Build()
            {
                return new ListTeamMemberWagesRequest(shouldSerialize,
                    this.teamMemberId,
                    this.limit,
                    this.cursor);
            }
        }
    }
}