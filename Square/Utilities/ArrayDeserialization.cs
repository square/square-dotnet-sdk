using Newtonsoft.Json.Converters;

namespace Square.Utilities
{
    public enum ArrayDeserialization
    {
        /// <summary>
        /// Example: variableName[0] = value1
        /// </summary>
        Indexed = 0,
        /// <summary>
        /// Example: variableName[] = value1
        /// </summary>
        UnIndexed = 1,
        /// <summary>
        /// Example: variableName = value1, variableName = value 2
        /// </summary>
        Plain = 2,
        /// <summary>
        /// Example: variableName = value1,value2
        /// </summary>
        Csv = 3,
        /// <summary>
        /// Example: variableName = value1\tvalue2
        /// </summary>
        Tsv = 4,
        /// <summary>
        /// Example: variableName = value1|value2
        /// </summary>
        Psv = 5,
        /// <summary>
        /// Example: Ignore format
        /// </summary>
        None = 6
    }
}