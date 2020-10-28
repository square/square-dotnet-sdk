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