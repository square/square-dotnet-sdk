using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// Error.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="category">category.</param>
        /// <param name="code">code.</param>
        /// <param name="detail">detail.</param>
        /// <param name="field">field.</param>
        public Error(
            string category,
            string code,
            string detail = null,
            string field = null)
        {
            this.Category = category;
            this.Code = code;
            this.Detail = detail;
            this.Field = field;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Error : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
            return obj is Error other &&                ((this.Category == null && other.Category == null) || (this.Category?.Equals(other.Category) == true)) &&
                ((this.Code == null && other.Code == null) || (this.Code?.Equals(other.Code) == true)) &&
                ((this.Detail == null && other.Detail == null) || (this.Detail?.Equals(other.Detail) == true)) &&
                ((this.Field == null && other.Field == null) || (this.Field?.Equals(other.Field) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1665691664;
            hashCode = HashCode.Combine(this.Category, this.Code, this.Detail, this.Field);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Category = {(this.Category == null ? "null" : this.Category.ToString())}");
            toStringOutput.Add($"this.Code = {(this.Code == null ? "null" : this.Code.ToString())}");
            toStringOutput.Add($"this.Detail = {(this.Detail == null ? "null" : this.Detail)}");
            toStringOutput.Add($"this.Field = {(this.Field == null ? "null" : this.Field)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Category,
                this.Code)
                .Detail(this.Detail)
                .Field(this.Field);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string category;
            private string code;
            private string detail;
            private string field;

            /// <summary>
            /// Initialize Builder for Error.
            /// </summary>
            /// <param name="category"> category. </param>
            /// <param name="code"> code. </param>
            public Builder(
                string category,
                string code)
            {
                this.category = category;
                this.code = code;
            }

             /// <summary>
             /// Category.
             /// </summary>
             /// <param name="category"> category. </param>
             /// <returns> Builder. </returns>
            public Builder Category(string category)
            {
                this.category = category;
                return this;
            }

             /// <summary>
             /// Code.
             /// </summary>
             /// <param name="code"> code. </param>
             /// <returns> Builder. </returns>
            public Builder Code(string code)
            {
                this.code = code;
                return this;
            }

             /// <summary>
             /// Detail.
             /// </summary>
             /// <param name="detail"> detail. </param>
             /// <returns> Builder. </returns>
            public Builder Detail(string detail)
            {
                this.detail = detail;
                return this;
            }

             /// <summary>
             /// Field.
             /// </summary>
             /// <param name="field"> field. </param>
             /// <returns> Builder. </returns>
            public Builder Field(string field)
            {
                this.field = field;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Error. </returns>
            public Error Build()
            {
                return new Error(
                    this.category,
                    this.code,
                    this.detail,
                    this.field);
            }
        }
    }
}