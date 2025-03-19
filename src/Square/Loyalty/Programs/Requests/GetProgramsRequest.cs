using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Loyalty.Programs;

public record GetProgramsRequest
{
    /// <summary>
    /// The ID of the loyalty program or the keyword `main`. Either value can be used to retrieve the single loyalty program that belongs to the seller.
    /// </summary>
    [JsonIgnore]
    public required string ProgramId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
