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

namespace Square.Models
{
    /// <summary>
    /// CatalogObjectBatch.
    /// </summary>
    public class CatalogObjectBatch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogObjectBatch"/> class.
        /// </summary>
        /// <param name="objects">objects.</param>
        public CatalogObjectBatch(
            IList<Models.CatalogObject> objects)
        {
            this.Objects = objects;
        }

        /// <summary>
        /// A list of CatalogObjects belonging to this batch.
        /// </summary>
        [JsonProperty("objects")]
        public IList<Models.CatalogObject> Objects { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogObjectBatch : ({string.Join(", ", toStringOutput)})";
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
            return obj is CatalogObjectBatch other &&                ((this.Objects == null && other.Objects == null) || (this.Objects?.Equals(other.Objects) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -481009855;
            hashCode = HashCode.Combine(this.Objects);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Objects = {(this.Objects == null ? "null" : $"[{string.Join(", ", this.Objects)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Objects);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.CatalogObject> objects;

            /// <summary>
            /// Initialize Builder for CatalogObjectBatch.
            /// </summary>
            /// <param name="objects"> objects. </param>
            public Builder(
                IList<Models.CatalogObject> objects)
            {
                this.objects = objects;
            }

             /// <summary>
             /// Objects.
             /// </summary>
             /// <param name="objects"> objects. </param>
             /// <returns> Builder. </returns>
            public Builder Objects(IList<Models.CatalogObject> objects)
            {
                this.objects = objects;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogObjectBatch. </returns>
            public CatalogObjectBatch Build()
            {
                return new CatalogObjectBatch(
                    this.objects);
            }
        }
    }
}