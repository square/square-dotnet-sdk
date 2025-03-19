using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Square.Legacy
{
    /// <summary>
    /// Available environments.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Environment
    {
        /// <summary>
        /// Production.
        /// </summary>
        [EnumMember(Value = "production")]
        Production,

        /// <summary>
        /// Sandbox.
        /// </summary>
        [EnumMember(Value = "sandbox")]
        Sandbox,

        /// <summary>
        /// Custom.
        /// </summary>
        [EnumMember(Value = "custom")]
        Custom,
    }
}
