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
    public class CatalogQueryText 
    {
        public CatalogQueryText(IList<string> keywords)
        {
            Keywords = keywords;
        }

        /// <summary>
        /// A list of 1, 2, or 3 search keywords. Keywords with fewer than 3 characters are ignored.
        /// </summary>
        [JsonProperty("keywords")]
        public IList<string> Keywords { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Keywords);
            return builder;
        }

        public class Builder
        {
            private IList<string> keywords;

            public Builder(IList<string> keywords)
            {
                this.keywords = keywords;
            }
            public Builder Keywords(IList<string> value)
            {
                keywords = value;
                return this;
            }

            public CatalogQueryText Build()
            {
                return new CatalogQueryText(keywords);
            }
        }
    }
}