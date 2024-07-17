namespace Square.Models
{
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
    using Square;
    using Square.Utilities;

    /// <summary>
    /// CatalogImage.
    /// </summary>
    public class CatalogImage
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogImage"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="url">url.</param>
        /// <param name="caption">caption.</param>
        /// <param name="photoStudioOrderId">photo_studio_order_id.</param>
        public CatalogImage(
            string name = null,
            string url = null,
            string caption = null,
            string photoStudioOrderId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "url", false },
                { "caption", false },
                { "photo_studio_order_id", false }
            };

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            if (url != null)
            {
                shouldSerialize["url"] = true;
                this.Url = url;
            }

            if (caption != null)
            {
                shouldSerialize["caption"] = true;
                this.Caption = caption;
            }

            if (photoStudioOrderId != null)
            {
                shouldSerialize["photo_studio_order_id"] = true;
                this.PhotoStudioOrderId = photoStudioOrderId;
            }

        }
        internal CatalogImage(Dictionary<string, bool> shouldSerialize,
            string name = null,
            string url = null,
            string caption = null,
            string photoStudioOrderId = null)
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
            Url = url;
            Caption = caption;
            PhotoStudioOrderId = photoStudioOrderId;
        }

        /// <summary>
        /// The internal name to identify this image in calls to the Square API.
        /// This is a searchable attribute for use in applicable query filters
        /// using the [SearchCatalogObjects](api-endpoint:Catalog-SearchCatalogObjects).
        /// It is not unique and should not be shown in a buyer facing context.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The URL of this image, generated by Square after an image is uploaded
        /// using the [CreateCatalogImage](api-endpoint:Catalog-CreateCatalogImage) endpoint.
        /// To modify the image, use the UpdateCatalogImage endpoint. Do not change the URL field.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; }

        /// <summary>
        /// A caption that describes what is shown in the image. Displayed in the
        /// Square Online Store. This is a searchable attribute for use in applicable query filters
        /// using the [SearchCatalogObjects](api-endpoint:Catalog-SearchCatalogObjects).
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; }

        /// <summary>
        /// The immutable order ID for this image object created by the Photo Studio service in Square Online Store.
        /// </summary>
        [JsonProperty("photo_studio_order_id")]
        public string PhotoStudioOrderId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogImage : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUrl()
        {
            return this.shouldSerialize["url"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCaption()
        {
            return this.shouldSerialize["caption"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePhotoStudioOrderId()
        {
            return this.shouldSerialize["photo_studio_order_id"];
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
            return obj is CatalogImage other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Url == null && other.Url == null) || (this.Url?.Equals(other.Url) == true)) &&
                ((this.Caption == null && other.Caption == null) || (this.Caption?.Equals(other.Caption) == true)) &&
                ((this.PhotoStudioOrderId == null && other.PhotoStudioOrderId == null) || (this.PhotoStudioOrderId?.Equals(other.PhotoStudioOrderId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1007024352;
            hashCode = HashCode.Combine(this.Name, this.Url, this.Caption, this.PhotoStudioOrderId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.Url = {(this.Url == null ? "null" : this.Url)}");
            toStringOutput.Add($"this.Caption = {(this.Caption == null ? "null" : this.Caption)}");
            toStringOutput.Add($"this.PhotoStudioOrderId = {(this.PhotoStudioOrderId == null ? "null" : this.PhotoStudioOrderId)}");
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
                .Caption(this.Caption)
                .PhotoStudioOrderId(this.PhotoStudioOrderId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "url", false },
                { "caption", false },
                { "photo_studio_order_id", false },
            };

            private string name;
            private string url;
            private string caption;
            private string photoStudioOrderId;

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                shouldSerialize["name"] = true;
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
                shouldSerialize["url"] = true;
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
                shouldSerialize["caption"] = true;
                this.caption = caption;
                return this;
            }

             /// <summary>
             /// PhotoStudioOrderId.
             /// </summary>
             /// <param name="photoStudioOrderId"> photoStudioOrderId. </param>
             /// <returns> Builder. </returns>
            public Builder PhotoStudioOrderId(string photoStudioOrderId)
            {
                shouldSerialize["photo_studio_order_id"] = true;
                this.photoStudioOrderId = photoStudioOrderId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetUrl()
            {
                this.shouldSerialize["url"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCaption()
            {
                this.shouldSerialize["caption"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPhotoStudioOrderId()
            {
                this.shouldSerialize["photo_studio_order_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogImage. </returns>
            public CatalogImage Build()
            {
                return new CatalogImage(shouldSerialize,
                    this.name,
                    this.url,
                    this.caption,
                    this.photoStudioOrderId);
            }
        }
    }
}