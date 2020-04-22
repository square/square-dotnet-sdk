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
        [JsonProperty("all")]
        public IList<string> All { get; }

        /// <summary>
        /// A list of terms where at least one of them must be present on the
        /// field of the resource.
        /// </summary>
        [JsonProperty("any")]
        public IList<string> Any { get; }

        /// <summary>
        /// A list of terms that must not be present on the field the resource
        /// </summary>
        [JsonProperty("none")]
        public IList<string> None { get; }

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
            private IList<string> all = new List<string>();
            private IList<string> any = new List<string>();
            private IList<string> none = new List<string>();

            public Builder() { }
            public Builder All(IList<string> value)
            {
                all = value;
                return this;
            }

            public Builder Any(IList<string> value)
            {
                any = value;
                return this;
            }

            public Builder None(IList<string> value)
            {
                none = value;
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