using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record TipSettings
{
    /// <summary>
    /// Indicates whether tipping is enabled for this checkout. Defaults to false.
    /// </summary>
    [JsonPropertyName("allow_tipping")]
    public bool? AllowTipping { get; set; }

    /// <summary>
    /// Indicates whether tip options should be presented on the screen before presenting
    /// the signature screen during card payment. Defaults to false.
    /// </summary>
    [JsonPropertyName("separate_tip_screen")]
    public bool? SeparateTipScreen { get; set; }

    /// <summary>
    /// Indicates whether custom tip amounts are allowed during the checkout flow. Defaults to false.
    /// </summary>
    [JsonPropertyName("custom_tip_field")]
    public bool? CustomTipField { get; set; }

    /// <summary>
    /// A list of tip percentages that should be presented during the checkout flow, specified as
    /// up to 3 non-negative integers from 0 to 100 (inclusive). Defaults to 15, 20, and 25.
    /// </summary>
    [JsonPropertyName("tip_percentages")]
    public IEnumerable<int>? TipPercentages { get; set; }

    /// <summary>
    /// Enables the "Smart Tip Amounts" behavior.
    /// Exact tipping options depend on the region in which the Square seller is active.
    ///
    /// For payments under 10.00, in the Australia, Canada, Ireland, United Kingdom, and United States, tipping options are presented as no tip, .50, 1.00 or 2.00.
    ///
    /// For payment amounts of 10.00 or greater, tipping options are presented as the following percentages: 0%, 5%, 10%, 15%.
    ///
    /// If set to true, the `tip_percentages` settings is ignored.
    /// Defaults to false.
    ///
    /// To learn more about smart tipping, see [Accept Tips with the Square App](https://squareup.com/help/us/en/article/5069-accept-tips-with-the-square-app).
    /// </summary>
    [JsonPropertyName("smart_tipping")]
    public bool? SmartTipping { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
