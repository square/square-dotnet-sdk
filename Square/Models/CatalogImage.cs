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
    /// CatalogImage.
    /// </summary>
    public class CatalogImage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogImage"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="url">url.</param>
        /// <param name="caption">caption.</param>
        public CatalogImage(
            string name = null,
            string url = null,
            string caption = null)
        {
            this.Name = name;
            this.Url = url;
            this.Caption = caption;
        }

        /// <summary>
        /// The internal name to identify this image in calls to the Square API.
        /// This is a searchable attribute for use in applicable query filters
        /// using the [SearchCatalogObjects]($e/Catalog/SearchCatalogObjects).
        /// It is not unique and should not be shown in a buyer facing context.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// The URL of this image, generated by Square after an image is uploaded
        /// using the [CreateCatalogImage]($e/Catalog/CreateCatalogImage) endpoint.
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; }

        /// <summary>
        /// A caption that describes what is shown in the image. Displayed in the
        /// Square Online Store. This is a searchable attribute for use in applicable query filters
        /// using the [SearchCatalogObjects]($e/Catalog/SearchCatalogObjects).
        /// </summary>
        [JsonProperty("caption", NullValueHandling = NullValueHandling.Ignore)]
        public string Caption { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogImage : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogImage other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Url == null && other.Url == null) || (this.Url?.Equals(other.Url) == true)) &&
                ((this.Caption == null && other.Caption == null) || (this.Caption?.Equals(other.Caption) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -261675541;

            if (this.Name != null)
            {
               hashCode += this.Name.GetHashCode();
            }

            if (this.Url != null)
            {
               hashCode += this.Url.GetHashCode();
            }

            if (this.Caption != null)
            {
               hashCode += this.Caption.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Url = {(this.Url == null ? "null" : this.Url == string.Empty ? "" : this.Url)}");
            toStringOutput.Add($"this.Caption = {(this.Caption == null ? "null" : this.Caption == string.Empty ? "" : this.Caption)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name)
                .Url(this.Url)
                .Caption(this.Caption);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string name;
            private string url;
            private string caption;

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
             /// Url.
             /// </summary>
             /// <param name="url"> url. </param>
             /// <returns> Builder. </returns>
            public Builder Url(string url)
            {
                this.url = url;
                return this;
            }

             /// <summary>
             /// Caption.
             /// </summary>
             /// <param name="caption"> caption. </param>
             /// <returns> Builder. </returns>
            public Builder Caption(string caption)
            {
                this.caption = caption;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogImage. </returns>
            public CatalogImage Build()
            {
                return new CatalogImage(
                    this.name,
                    this.url,
                    this.caption);
            }
        }
    }
}