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
    public class BatchChangeInventoryResponse 
    {
        public BatchChangeInventoryResponse(IList<Models.Error> errors = null,
            IList<Models.InventoryCount> counts = null)
        {
            Errors = errors;
            Counts = counts;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The current counts for all objects referenced in the request.
        /// </summary>
        [JsonProperty("counts")]
        public IList<Models.InventoryCount> Counts { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Counts(Counts);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.InventoryCount> counts = new List<Models.InventoryCount>();

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Counts(IList<Models.InventoryCount> value)
            {
                counts = value;
                return this;
            }

            public BatchChangeInventoryResponse Build()
            {
                return new BatchChangeInventoryResponse(errors,
                    counts);
            }
        }
    }
}