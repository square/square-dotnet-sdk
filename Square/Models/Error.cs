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
    public class Error 
    {
        public Error(string category,
            string code,
            string detail = null,
            string field = null)
        {
            Category = category;
            Code = code;
            Detail = detail;
            Field = field;
        }

        /// <summary>
        /// Indicates which high-level category of error has occurred during a
        /// request to the Connect API.
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; }

        /// <summary>
        /// Indicates the specific error that occurred during a request to a
        /// Square API.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; }

        /// <summary>
        /// A human-readable description of the error for debugging purposes.
        /// </summary>
        [JsonProperty("detail")]
        public string Detail { get; }

        /// <summary>
        /// The name of the field provided in the original request (if any) that
        /// the error pertains to.
        /// </summary>
        [JsonProperty("field")]
        public string Field { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Category,
                Code)
                .Detail(Detail)
                .Field(Field);
            return builder;
        }

        public class Builder
        {
            private string category;
            private string code;
            private string detail;
            private string field;

            public Builder(string category,
                string code)
            {
                this.category = category;
                this.code = code;
            }
            public Builder Category(string value)
            {
                category = value;
                return this;
            }

            public Builder Code(string value)
            {
                code = value;
                return this;
            }

            public Builder Detail(string value)
            {
                detail = value;
                return this;
            }

            public Builder Field(string value)
            {
                field = value;
                return this;
            }

            public Error Build()
            {
                return new Error(category,
                    code,
                    detail,
                    field);
            }
        }
    }
}