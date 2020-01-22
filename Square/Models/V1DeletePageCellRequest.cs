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
        [JsonProperty("row")]
        public string Row { get; }

        /// <summary>
        /// The column of the cell to clear. Always an integer between 0 and 4, inclusive. Column 0 is the leftmost column.
        /// </summary>
        [JsonProperty("column")]
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

            public Builder() { }
            public Builder Row(string value)
            {
                row = value;
                return this;
            }

            public Builder Column(string value)
            {
                column = value;
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