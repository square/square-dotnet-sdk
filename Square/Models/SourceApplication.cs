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
    public class SourceApplication 
    {
        public SourceApplication(string product = null,
            string applicationId = null,
            string name = null)
        {
            Product = product;
            ApplicationId = applicationId;
            Name = name;
        }

        /// <summary>
        /// Indicates the Square product used to generate an inventory change.
        /// </summary>
        [JsonProperty("product")]
        public string Product { get; }

        /// <summary>
        /// Read-only Square ID assigned to the application. Only used for
        /// [Product](#type-product) type `EXTERNAL_API`.
        /// </summary>
        [JsonProperty("application_id")]
        public string ApplicationId { get; }

        /// <summary>
        /// Read-only display name assigned to the application
        /// (e.g. `"Custom Application"`, `"Square POS 4.74 for Android"`).
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Product(Product)
                .ApplicationId(ApplicationId)
                .Name(Name);
            return builder;
        }

        public class Builder
        {
            private string product;
            private string applicationId;
            private string name;

            public Builder() { }
            public Builder Product(string value)
            {
                product = value;
                return this;
            }

            public Builder ApplicationId(string value)
            {
                applicationId = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public SourceApplication Build()
            {
                return new SourceApplication(product,
                    applicationId,
                    name);
            }
        }
    }
}