
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
    public class CatalogObjectBatch 
    {
        public CatalogObjectBatch(IList<Models.CatalogObject> objects)
        {
            Objects = objects;
        }

        /// <summary>
        /// A list of CatalogObjects belonging to this batch.
        /// </summary>
        [JsonProperty("objects")]
        public IList<Models.CatalogObject> Objects { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogObjectBatch : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Objects = {(Objects == null ? "null" : $"[{ string.Join(", ", Objects)} ]")}");
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

            return obj is CatalogObjectBatch other &&
                ((Objects == null && other.Objects == null) || (Objects?.Equals(other.Objects) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -481009855;

            if (Objects != null)
            {
               hashCode += Objects.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Objects);
            return builder;
        }

        public class Builder
        {
            private IList<Models.CatalogObject> objects;

            public Builder(IList<Models.CatalogObject> objects)
            {
                this.objects = objects;
            }

            public Builder Objects(IList<Models.CatalogObject> objects)
            {
                this.objects = objects;
                return this;
            }

            public CatalogObjectBatch Build()
            {
                return new CatalogObjectBatch(objects);
            }
        }
    }
}