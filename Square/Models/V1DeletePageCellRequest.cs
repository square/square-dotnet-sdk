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
    public class V1DeletePageCellRequest 
    {
        public V1DeletePageCellRequest(string row = null,
            string column = null)
        {
            Row = row;
            Column = column;
        }

        /// <summary>
        /// The row of the cell to clear. Always an integer between 0 and 4, inclusive. Row 0 is the top row.
        /// </summary>
        [JsonProperty("row", NullValueHandling = NullValueHandling.Ignore)]
        public string Row { get; }

        /// <summary>
        /// The column of the cell to clear. Always an integer between 0 and 4, inclusive. Column 0 is the leftmost column.
        /// </summary>
        [JsonProperty("column", NullValueHandling = NullValueHandling.Ignore)]
        public string Column { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Row(Row)
                .Column(Column);
            return builder;
        }

        public class Builder
        {
            private string row;
            private string column;



            public Builder Row(string row)
            {
                this.row = row;
                return this;
            }

            public Builder Column(string column)
            {
                this.column = column;
                return this;
            }

            public V1DeletePageCellRequest Build()
            {
                return new V1DeletePageCellRequest(row,
                    column);
            }
        }
    }
}