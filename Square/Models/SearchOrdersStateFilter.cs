
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchOrdersStateFilter : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"States = {(States == null ? "null" : $"[{ string.Join(", ", States)} ]")}");
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

            return obj is SearchOrdersStateFilter other &&
                ((States == null && other.States == null) || (States?.Equals(other.States) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 615021182;

            if (States != null)
            {
               hashCode += States.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder States(IList<string> states)
            {
                this.states = states;
                return this;
            }

            public SearchOrdersStateFilter Build()
            {
                return new SearchOrdersStateFilter(states);
            }
        }
    }
}