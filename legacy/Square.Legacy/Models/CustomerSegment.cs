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
    /// CustomerSegment.
    /// </summary>
    public class CustomerSegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerSegment"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="id">id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        public CustomerSegment(
            string name,
            string id = null,
            string createdAt = null,
            string updatedAt = null
        )
        {
            this.Id = id;
            this.Name = name;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// A unique Square-generated ID for the segment.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The name of the segment.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The timestamp when the segment was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the segment was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CustomerSegment : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CustomerSegment other
                && (this.Id == null && other.Id == null || this.Id?.Equals(other.Id) == true)
                && (
                    this.Name == null && other.Name == null || this.Name?.Equals(other.Name) == true
                )
                && (
                    this.CreatedAt == null && other.CreatedAt == null
                    || this.CreatedAt?.Equals(other.CreatedAt) == true
                )
                && (
                    this.UpdatedAt == null && other.UpdatedAt == null
                    || this.UpdatedAt?.Equals(other.UpdatedAt) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -749243172;
            hashCode = HashCode.Combine(
                hashCode,
                this.Id,
                this.Name,
                this.CreatedAt,
                this.UpdatedAt
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
            toStringOutput.Add($"this.Name = {this.Name ?? "null"}");
            toStringOutput.Add($"this.CreatedAt = {this.CreatedAt ?? "null"}");
            toStringOutput.Add($"this.UpdatedAt = {this.UpdatedAt ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Name)
                .Id(this.Id)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string name;
            private string id;
            private string createdAt;
            private string updatedAt;

            /// <summary>
            /// Initialize Builder for CustomerSegment.
            /// </summary>
            /// <param name="name"> name. </param>
            public Builder(string name)
            {
                this.name = name;
            }

            /// <summary>
            /// Name.
            /// </summary>
            /// <param name="name"> name. </param>
            /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

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
            /// Builds class object.
            /// </summary>
            /// <returns> CustomerSegment. </returns>
            public CustomerSegment Build()
            {
                return new CustomerSegment(this.name, this.id, this.createdAt, this.updatedAt);
            }
        }
    }
}
