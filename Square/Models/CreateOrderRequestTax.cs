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
    public class CreateOrderRequestTax 
    {
        public CreateOrderRequestTax(string catalogObjectId = null,
            string name = null,
            string type = null,
            string percentage = null)
        {
            CatalogObjectId = catalogObjectId;
            Name = name;
            Type = type;
            Percentage = percentage;
        }

        /// <summary>
        /// Only used for catalog taxes. The catalog object ID of an existing [CatalogTax](#type-catalogtax).
        /// Do not provide a value for this field if you provide values in other fields for an ad hoc tax.
        /// </summary>
        [JsonProperty("catalog_object_id")]
        public string CatalogObjectId { get; }

        /// <summary>
        /// Only used for ad hoc taxes. The tax's name.
        /// Do not provide a value for this field if you set `catalog_object_id`.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Indicates how the tax is applied to the associated line item or order.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// Only used for ad hoc taxes. The percentage of the tax, as a string representation of a decimal number.
        /// A value of `7.25` corresponds to a percentage of 7.25%. This value range between 0.0 up to 100.0
        /// </summary>
        [JsonProperty("percentage")]
        public string Percentage { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CatalogObjectId(CatalogObjectId)
                .Name(Name)
                .Type(Type)
                .Percentage(Percentage);
            return builder;
        }

        public class Builder
        {
            private string catalogObjectId;
            private string name;
            private string type;
            private string percentage;

            public Builder() { }
            public Builder CatalogObjectId(string value)
            {
                catalogObjectId = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder Type(string value)
            {
                type = value;
                return this;
            }

            public Builder Percentage(string value)
            {
                percentage = value;
                return this;
            }

            public CreateOrderRequestTax Build()
            {
                return new CreateOrderRequestTax(catalogObjectId,
                    name,
                    type,
                    percentage);
            }
        }
    }
} 