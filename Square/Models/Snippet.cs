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
    /// Snippet.
    /// </summary>
    public class Snippet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Snippet"/> class.
        /// </summary>
        /// <param name="content">content.</param>
        /// <param name="id">id.</param>
        /// <param name="siteId">site_id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        public Snippet(
            string content,
            string id = null,
            string siteId = null,
            string createdAt = null,
            string updatedAt = null)
        {
            this.Id = id;
            this.SiteId = siteId;
            this.Content = content;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// The Square-assigned ID for the snippet.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The ID of the site that contains the snippet.
        /// </summary>
        [JsonProperty("site_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SiteId { get; }

        /// <summary>
        /// The snippet code, which can contain valid HTML, JavaScript, or both.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; }

        /// <summary>
        /// The timestamp of when the snippet was initially added to the site, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp of when the snippet was last updated on the site, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Snippet : ({string.Join(", ", toStringOutput)})";
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
            return obj is Snippet other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.SiteId == null && other.SiteId == null) || (this.SiteId?.Equals(other.SiteId) == true)) &&
                ((this.Content == null && other.Content == null) || (this.Content?.Equals(other.Content) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 812751980;
            hashCode = HashCode.Combine(this.Id, this.SiteId, this.Content, this.CreatedAt, this.UpdatedAt);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.SiteId = {(this.SiteId == null ? "null" : this.SiteId == string.Empty ? "" : this.SiteId)}");
            toStringOutput.Add($"this.Content = {(this.Content == null ? "null" : this.Content == string.Empty ? "" : this.Content)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Content)
                .Id(this.Id)
                .SiteId(this.SiteId)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string content;
            private string id;
            private string siteId;
            private string createdAt;
            private string updatedAt;

            public Builder(
                string content)
            {
                this.content = content;
            }

             /// <summary>
             /// Content.
             /// </summary>
             /// <param name="content"> content. </param>
             /// <returns> Builder. </returns>
            public Builder Content(string content)
            {
                this.content = content;
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
             /// SiteId.
             /// </summary>
             /// <param name="siteId"> siteId. </param>
             /// <returns> Builder. </returns>
            public Builder SiteId(string siteId)
            {
                this.siteId = siteId;
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
            /// <returns> Snippet. </returns>
            public Snippet Build()
            {
                return new Snippet(
                    this.content,
                    this.id,
                    this.siteId,
                    this.createdAt,
                    this.updatedAt);
            }
        }
    }
}