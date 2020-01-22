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
    public class ListCatalogResponse 
    {
        public ListCatalogResponse(IList<Models.Error> errors = null,
            string cursor = null,
            IList<Models.CatalogObject> objects = null)
        {
            Errors = errors;
            Cursor = cursor;
            Objects = objects;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on any errors encountered.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent request. If unset, this is the final response.
        /// See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// The CatalogObjects returned.
        /// </summary>
        [JsonProperty("objects")]
        public IList<Models.CatalogObject> Objects { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Cursor(Cursor)
                .Objects(Objects);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private string cursor;
            private IList<Models.CatalogObject> objects = new List<Models.CatalogObject>();

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public Builder Objects(IList<Models.CatalogObject> value)
            {
                objects = value;
                return this;
            }

            public ListCatalogResponse Build()
            {
                return new ListCatalogResponse(errors,
                    cursor,
                    objects);
            }
        }
    }
}