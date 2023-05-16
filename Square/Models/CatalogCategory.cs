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
    /// CatalogCategory.
    /// </summary>
    public class CatalogCategory
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCategory"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="imageIds">image_ids.</param>
        public CatalogCategory(
            string name = null,
            IList<string> imageIds = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "image_ids", false }
            };

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            if (imageIds != null)
            {
                shouldSerialize["image_ids"] = true;
                this.ImageIds = imageIds;
            }

        }
        internal CatalogCategory(Dictionary<string, bool> shouldSerialize,
            string name = null,
            IList<string> imageIds = null)
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
            ImageIds = imageIds;
        }

        /// <summary>
        /// The category name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The IDs of images associated with this `CatalogCategory` instance.
        /// Currently these images are not displayed by Square, but are free to be displayed in 3rd party applications.
        /// </summary>
        [JsonProperty("image_ids")]
        public IList<string> ImageIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogCategory : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeImageIds()
        {
            return this.shouldSerialize["image_ids"];
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
            return obj is CatalogCategory other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.ImageIds == null && other.ImageIds == null) || (this.ImageIds?.Equals(other.ImageIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1003634873;
            hashCode = HashCode.Combine(this.Name, this.ImageIds);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.ImageIds = {(this.ImageIds == null ? "null" : $"[{string.Join(", ", this.ImageIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name)
                .ImageIds(this.ImageIds);
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
                { "image_ids", false },
            };

            private string name;
            private IList<string> imageIds;

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
             /// ImageIds.
             /// </summary>
             /// <param name="imageIds"> imageIds. </param>
             /// <returns> Builder. </returns>
            public Builder ImageIds(IList<string> imageIds)
            {
                shouldSerialize["image_ids"] = true;
                this.imageIds = imageIds;
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
            public void UnsetImageIds()
            {
                this.shouldSerialize["image_ids"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogCategory. </returns>
            public CatalogCategory Build()
            {
                return new CatalogCategory(shouldSerialize,
                    this.name,
                    this.imageIds);
            }
        }
    }
}