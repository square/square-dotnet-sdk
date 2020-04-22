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
    public class TerminalCheckoutQuerySort 
    {
        public TerminalCheckoutQuerySort(string sortOrder = null)
        {
            SortOrder = sortOrder;
        }

        /// <summary>
        /// The order in which results are listed.
        /// - `ASC` - oldest to newest
        /// - `DESC` - newest to oldest (default).
        /// </summary>
        [JsonProperty("sort_order")]
        public string SortOrder { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .SortOrder(SortOrder);
            return builder;
        }

        public class Builder
        {
            private string sortOrder;

            public Builder() { }
            public Builder SortOrder(string value)
            {
                sortOrder = value;
                return this;
            }

            public TerminalCheckoutQuerySort Build()
            {
                return new TerminalCheckoutQuerySort(sortOrder);
            }
        }
    }
}