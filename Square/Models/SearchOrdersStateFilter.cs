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
    public class SearchOrdersStateFilter 
    {
        public SearchOrdersStateFilter(IList<string> states)
        {
            States = states;
        }

        /// <summary>
        /// States to filter for.
        /// See [OrderState](#type-orderstate) for possible values
        /// </summary>
        [JsonProperty("states")]
        public IList<string> States { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(States);
            return builder;
        }

        public class Builder
        {
            private IList<string> states;

            public Builder(IList<string> states)
            {
                this.states = states;
            }
            public Builder States(IList<string> value)
            {
                states = value;
                return this;
            }

            public SearchOrdersStateFilter Build()
            {
                return new SearchOrdersStateFilter(states);
            }
        }
    }
}