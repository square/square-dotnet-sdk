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
    public class V1ListCashDrawerShiftsResponse 
    {
        public V1ListCashDrawerShiftsResponse(IList<Models.V1CashDrawerShift> items = null)
        {
            Items = items;
        }

        /// <summary>
        /// Getter for items
        /// </summary>
        [JsonProperty("items")]
        public IList<Models.V1CashDrawerShift> Items { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Items(Items);
            return builder;
        }

        public class Builder
        {
            private IList<Models.V1CashDrawerShift> items = new List<Models.V1CashDrawerShift>();

            public Builder() { }
            public Builder Items(IList<Models.V1CashDrawerShift> value)
            {
                items = value;
                return this;
            }

            public V1ListCashDrawerShiftsResponse Build()
            {
                return new V1ListCashDrawerShiftsResponse(items);
            }
        }
    }
}