using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// Job.
    /// </summary>
    public class Job
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="Job"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="title">title.</param>
        /// <param name="isTipEligible">is_tip_eligible.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="version">version.</param>
        public Job(
            string id = null,
            string title = null,
            bool? isTipEligible = null,
            string createdAt = null,
            string updatedAt = null,
            int? version = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "title", false },
                { "is_tip_eligible", false },
            };
            this.Id = id;

            if (title != null)
            {
                shouldSerialize["title"] = true;
                this.Title = title;
            }

            if (isTipEligible != null)
            {
                shouldSerialize["is_tip_eligible"] = true;
                this.IsTipEligible = isTipEligible;
            }
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.Version = version;
        }

        internal Job(
            Dictionary<string, bool> shouldSerialize,
            string id = null,
            string title = null,
            bool? isTipEligible = null,
            string createdAt = null,
            string updatedAt = null,
            int? version = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            Title = title;
            IsTipEligible = isTipEligible;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Version = version;
        }

        /// <summary>
        /// **Read only** The unique Square-assigned ID of the job. If you need a job ID for an API request,
        /// call [ListJobs](api-endpoint:Team-ListJobs) or use the ID returned when you created the job.
        /// You can also get job IDs from a team member's wage setting.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The title of the job.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; }

        /// <summary>
        /// Indicates whether team members can earn tips for the job.
        /// </summary>
        [JsonProperty("is_tip_eligible")]
        public bool? IsTipEligible { get; }

        /// <summary>
        /// The timestamp when the job was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the job was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// **Read only** The current version of the job. Include this field in `UpdateJob` requests to enable
        /// [optimistic concurrency](https://developer.squareup.com/docs/working-with-apis/optimistic-concurrency)
        /// control and avoid overwrites from concurrent requests. Requests fail if the provided version doesn't
        /// match the server version at the time of the request.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"Job : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTitle()
        {
            return this.shouldSerialize["title"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIsTipEligible()
        {
            return this.shouldSerialize["is_tip_eligible"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is Job other
                && (this.Id == null && other.Id == null || this.Id?.Equals(other.Id) == true)
                && (
                    this.Title == null && other.Title == null
                    || this.Title?.Equals(other.Title) == true
                )
                && (
                    this.IsTipEligible == null && other.IsTipEligible == null
                    || this.IsTipEligible?.Equals(other.IsTipEligible) == true
                )
                && (
                    this.CreatedAt == null && other.CreatedAt == null
                    || this.CreatedAt?.Equals(other.CreatedAt) == true
                )
                && (
                    this.UpdatedAt == null && other.UpdatedAt == null
                    || this.UpdatedAt?.Equals(other.UpdatedAt) == true
                )
                && (
                    this.Version == null && other.Version == null
                    || this.Version?.Equals(other.Version) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 2105241580;
            hashCode = HashCode.Combine(
                hashCode,
                this.Id,
                this.Title,
                this.IsTipEligible,
                this.CreatedAt,
                this.UpdatedAt,
                this.Version
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id ?? "null"}");
            toStringOutput.Add($"this.Title = {this.Title ?? "null"}");
            toStringOutput.Add(
                $"this.IsTipEligible = {(this.IsTipEligible == null ? "null" : this.IsTipEligible.ToString())}"
            );
            toStringOutput.Add($"this.CreatedAt = {this.CreatedAt ?? "null"}");
            toStringOutput.Add($"this.UpdatedAt = {this.UpdatedAt ?? "null"}");
            toStringOutput.Add(
                $"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .Title(this.Title)
                .IsTipEligible(this.IsTipEligible)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .Version(this.Version);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "title", false },
                { "is_tip_eligible", false },
            };

            private string id;
            private string title;
            private bool? isTipEligible;
            private string createdAt;
            private string updatedAt;
            private int? version;

            /// <summary>
            /// Id.
            /// </summary>
            /// <param name="id"> id. </param>
            /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            /// <summary>
            /// Title.
            /// </summary>
            /// <param name="title"> title. </param>
            /// <returns> Builder. </returns>
            public Builder Title(string title)
            {
                shouldSerialize["title"] = true;
                this.title = title;
                return this;
            }

            /// <summary>
            /// IsTipEligible.
            /// </summary>
            /// <param name="isTipEligible"> isTipEligible. </param>
            /// <returns> Builder. </returns>
            public Builder IsTipEligible(bool? isTipEligible)
            {
                shouldSerialize["is_tip_eligible"] = true;
                this.isTipEligible = isTipEligible;
                return this;
            }

            /// <summary>
            /// CreatedAt.
            /// </summary>
            /// <param name="createdAt"> createdAt. </param>
            /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            /// <summary>
            /// UpdatedAt.
            /// </summary>
            /// <param name="updatedAt"> updatedAt. </param>
            /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            /// <summary>
            /// Version.
            /// </summary>
            /// <param name="version"> version. </param>
            /// <returns> Builder. </returns>
            public Builder Version(int? version)
            {
                this.version = version;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetTitle()
            {
                this.shouldSerialize["title"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetIsTipEligible()
            {
                this.shouldSerialize["is_tip_eligible"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Job. </returns>
            public Job Build()
            {
                return new Job(
                    shouldSerialize,
                    this.id,
                    this.title,
                    this.isTipEligible,
                    this.createdAt,
                    this.updatedAt,
                    this.version
                );
            }
        }
    }
}
