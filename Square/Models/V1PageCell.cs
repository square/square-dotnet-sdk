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
    public class V1PageCell 
    {
        public V1PageCell(string pageId = null,
            int? row = null,
            int? column = null,
            string objectType = null,
            string objectId = null,
            string placeholderType = null)
        {
            PageId = pageId;
            Row = row;
            Column = column;
            ObjectType = objectType;
            ObjectId = objectId;
            PlaceholderType = placeholderType;
        }

        /// <summary>
        /// The unique identifier of the page the cell is included on.
        /// </summary>
        [JsonProperty("page_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PageId { get; }

        /// <summary>
        /// The row of the cell. Always an integer between 0 and 4, inclusive.
        /// </summary>
        [JsonProperty("row", NullValueHandling = NullValueHandling.Ignore)]
        public int? Row { get; }

        /// <summary>
        /// The column of the cell. Always an integer between 0 and 4, inclusive.
        /// </summary>
        [JsonProperty("column", NullValueHandling = NullValueHandling.Ignore)]
        public int? Column { get; }

        /// <summary>
        /// Getter for object_type
        /// </summary>
        [JsonProperty("object_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectType { get; }

        /// <summary>
        /// The unique identifier of the entity represented in the cell. Not present for cells with an object_type of PLACEHOLDER.
        /// </summary>
        [JsonProperty("object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectId { get; }

        /// <summary>
        /// Getter for placeholder_type
        /// </summary>
        [JsonProperty("placeholder_type", NullValueHandling = NullValueHandling.Ignore)]
        public string PlaceholderType { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .PageId(PageId)
                .Row(Row)
                .Column(Column)
                .ObjectType(ObjectType)
                .ObjectId(ObjectId)
                .PlaceholderType(PlaceholderType);
            return builder;
        }

        public class Builder
        {
            private string pageId;
            private int? row;
            private int? column;
            private string objectType;
            private string objectId;
            private string placeholderType;



            public Builder PageId(string pageId)
            {
                this.pageId = pageId;
                return this;
            }

            public Builder Row(int? row)
            {
                this.row = row;
                return this;
            }

            public Builder Column(int? column)
            {
                this.column = column;
                return this;
            }

            public Builder ObjectType(string objectType)
            {
                this.objectType = objectType;
                return this;
            }

            public Builder ObjectId(string objectId)
            {
                this.objectId = objectId;
                return this;
            }

            public Builder PlaceholderType(string placeholderType)
            {
                this.placeholderType = placeholderType;
                return this;
            }

            public V1PageCell Build()
            {
                return new V1PageCell(pageId,
                    row,
                    column,
                    objectType,
                    objectId,
                    placeholderType);
            }
        }
    }
}