
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
        [JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
        public string Detail { get; }

        /// <summary>
        /// The name of the field provided in the original request (if any) that
        /// the error pertains to.
        /// </summary>
        [JsonProperty("field", NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Error : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Category = {(Category == null ? "null" : Category.ToString())}");
            toStringOutput.Add($"Code = {(Code == null ? "null" : Code.ToString())}");
            toStringOutput.Add($"Detail = {(Detail == null ? "null" : Detail == string.Empty ? "" : Detail)}");
            toStringOutput.Add($"Field = {(Field == null ? "null" : Field == string.Empty ? "" : Field)}");
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

            return obj is Error other &&
                ((Category == null && other.Category == null) || (Category?.Equals(other.Category) == true)) &&
                ((Code == null && other.Code == null) || (Code?.Equals(other.Code) == true)) &&
                ((Detail == null && other.Detail == null) || (Detail?.Equals(other.Detail) == true)) &&
                ((Field == null && other.Field == null) || (Field?.Equals(other.Field) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1665691664;

            if (Category != null)
            {
               hashCode += Category.GetHashCode();
            }

            if (Code != null)
            {
               hashCode += Code.GetHashCode();
            }

            if (Detail != null)
            {
               hashCode += Detail.GetHashCode();
            }

            if (Field != null)
            {
               hashCode += Field.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder Category(string category)
            {
                this.category = category;
                return this;
            }

            public Builder Code(string code)
            {
                this.code = code;
                return this;
            }

            public Builder Detail(string detail)
            {
                this.detail = detail;
                return this;
            }

            public Builder Field(string field)
            {
                this.field = field;
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