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
    public class RetrieveInventoryPhysicalCountResponse 
    {
        public RetrieveInventoryPhysicalCountResponse(IList<Models.Error> errors = null,
            Models.InventoryPhysicalCount count = null)
        {
            Errors = errors;
            Count = count;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents the quantity of an item variation that is physically present
        /// at a specific location, verified by a seller or a seller's employee. For example,
        /// a physical count might come from an employee counting the item variations on
        /// hand or from syncing with an external system.
        /// </summary>
        [JsonProperty("count")]
        public Models.InventoryPhysicalCount Count { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Count(Count);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.InventoryPhysicalCount count;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Count(Models.InventoryPhysicalCount value)
            {
                count = value;
                return this;
            }

            public RetrieveInventoryPhysicalCountResponse Build()
            {
                return new RetrieveInventoryPhysicalCountResponse(errors,
                    count);
            }
        }
    }
}