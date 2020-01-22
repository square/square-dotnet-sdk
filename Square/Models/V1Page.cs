using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1Page 
    {
        public V1Page(string id = null,
            string name = null,
            int? pageIndex = null,
            IList<Models.V1PageCell> cells = null)
        {
            Id = id;
            Name = name;
            PageIndex = pageIndex;
            Cells = cells;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The page's unique identifier.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The page's name, if any.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The page's position in the merchant's list of pages. Always an integer between 0 and 6, inclusive.
        /// </summary>
        [JsonProperty("page_index")]
        public int? PageIndex { get; }

        /// <summary>
        /// The cells included on the page.
        /// </summary>
        [JsonProperty("cells")]
        public IList<Models.V1PageCell> Cells { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .Name(Name)
                .PageIndex(PageIndex)
                .Cells(Cells);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string name;
            private int? pageIndex;
            private IList<Models.V1PageCell> cells = new List<Models.V1PageCell>();

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder PageIndex(int? value)
            {
                pageIndex = value;
                return this;
            }

            public Builder Cells(IList<Models.V1PageCell> value)
            {
                cells = value;
                return this;
            }

            public V1Page Build()
            {
                return new V1Page(id,
                    name,
                    pageIndex,
                    cells);
            }
        }
    }
}