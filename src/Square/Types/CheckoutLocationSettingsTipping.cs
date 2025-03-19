using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record CheckoutLocationSettingsTipping
{
    /// <summary>
    /// Set three custom percentage amounts that buyers can select at checkout. If Smart Tip is enabled, this only applies to transactions totaling $10 or more.
    /// </summary>
    [JsonPropertyName("percentages")]
    public IEnumerable<int>? Percentages { get; set; }

    /// <summary>
    /// Enables Smart Tip Amounts. If Smart Tip Amounts is enabled, tipping works as follows:
    /// If a transaction is less than $10, the available tipping options include No Tip, $1, $2, or $3.
    /// If a transaction is $10 or more, the available tipping options include No Tip, 15%, 20%, or 25%.
    /// You can set custom percentage amounts with the `percentages` field.
    /// </summary>
    [JsonPropertyName("smart_tipping_enabled")]
    public bool? SmartTippingEnabled { get; set; }

    /// <summary>
    /// Set the pre-selected percentage amounts that appear at checkout. If Smart Tip is enabled, this only applies to transactions totaling $10 or more.
    /// </summary>
    [JsonPropertyName("default_percent")]
    public int? DefaultPercent { get; set; }

    /// <summary>
    /// Show the Smart Tip Amounts for this location.
    /// </summary>
    [JsonPropertyName("smart_tips")]
    public IEnumerable<Money>? SmartTips { get; set; }

    /// <summary>
    /// Set the pre-selected whole amount that appears at checkout when Smart Tip is enabled and the transaction amount is less than $10.
    /// </summary>
    [JsonPropertyName("default_smart_tip")]
    public Money? DefaultSmartTip { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
