
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
    public class FilterValue 
    {
        public FilterValue(IList<string> all = null,
            IList<string> any = null,
            IList<string> none = null)
        {
            All = all;
            Any = any;
            None = none;
        }

        /// <summary>
        /// A list of terms that must be present on the field of the resource.
        /// </summary>
        [JsonProperty("all", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> All { get; }

        /// <summary>
        /// A list of terms where at least one of them must be present on the
        /// field of the resource.
        /// </summary>
        [JsonProperty("any", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Any { get; }

        /// <summary>
        /// A list of terms that must not be present on the field the resource
        /// </summary>
        [JsonProperty("none", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> None { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FilterValue : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"All = {(All == null ? "null" : $"[{ string.Join(", ", All)} ]")}");
            toStringOutput.Add($"Any = {(Any == null ? "null" : $"[{ string.Join(", ", Any)} ]")}");
            toStringOutput.Add($"None = {(None == null ? "null" : $"[{ string.Join(", ", None)} ]")}");
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

            return obj is FilterValue other &&
                ((All == null && other.All == null) || (All?.Equals(other.All) == true)) &&
                ((Any == null && other.Any == null) || (Any?.Equals(other.Any) == true)) &&
                ((None == null && other.None == null) || (None?.Equals(other.None) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 547827750;

            if (All != null)
            {
               hashCode += All.GetHashCode();
            }

            if (Any != null)
            {
               hashCode += Any.GetHashCode();
            }

            if (None != null)
            {
               hashCode += None.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .All(All)
                .Any(Any)
                .None(None);
            return builder;
        }

        public class Builder
        {
            private IList<string> all;
            private IList<string> any;
            private IList<string> none;



            public Builder All(IList<string> all)
            {
                this.all = all;
                return this;
            }

            public Builder Any(IList<string> any)
            {
                this.any = any;
                return this;
            }

            public Builder None(IList<string> none)
            {
                this.none = none;
                return this;
            }

            public FilterValue Build()
            {
                return new FilterValue(all,
                    any,
                    none);
            }
        }
    }
}