using System.Text.Json.Serialization;

namespace Square.Core;

public interface IStringEnum : IEquatable<string>
{
    public string Value { get; }
}
