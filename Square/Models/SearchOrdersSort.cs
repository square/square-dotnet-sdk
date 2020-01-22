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
    public class SearchOrdersSort 
    {
        public SearchOrdersSort(string sortField,
            string sortOrder = null)
        {
            SortField = sortField;
            SortOrder = sortOrder;
        }

        /// <summary>
        /// Specifies which timestamp to use to sort SearchOrder results.
        /// </summary>
        [JsonProperty("sort_field")]
        public string SortField { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("sort_order")]
        public string SortOrder { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(SortField)
                .SortOrder(SortOrder);
            return builder;
        }

        public class Builder
        {
            private string sortField;
            private string sortOrder;

            public Builder(string sortField)
            {
                this.sortField = sortField;
            }
            public Builder SortField(string value)
            {
                sortField = value;
                return this;
            }

            public Builder SortOrder(string value)
            {
                sortOrder = value;
                return this;
            }

            public SearchOrdersSort Build()
            {
                return new SearchOrdersSort(sortField,
                    sortOrder);
            }
        }
    }
}