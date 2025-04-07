using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// An accounting of the amount owed the seller and record of the actual transfer to their
/// external bank account or to the Square balance.
/// </summary>
public record Payout
{
    /// <summary>
    /// A unique ID for the payout.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Indicates the payout status.
    /// See [PayoutStatus](#type-payoutstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public PayoutStatus? Status { get; set; }

    /// <summary>
    /// The ID of the location associated with the payout.
    /// </summary>
    [JsonPropertyName("location_id")]
    public required string LocationId { get; set; }

    /// <summary>
    /// The timestamp of when the payout was created and submitted for deposit to the seller's banking destination, in RFC 3339 format.
    /// </summary>
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp of when the payout was last updated, in RFC 3339 format.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The amount of money involved in the payout. A positive amount indicates a deposit, and a negative amount indicates a withdrawal. This amount is never zero.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public Money? AmountMoney { get; set; }

    /// <summary>
    /// Information about the banking destination (such as a bank account, Square checking account, or debit card)
    /// against which the payout was made.
    /// </summary>
    [JsonPropertyName("destination")]
    public Destination? Destination { get; set; }

    /// <summary>
    /// The version number, which is incremented each time an update is made to this payout record.
    /// The version number helps developers receive event notifications or feeds out of order.
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// Indicates the payout type.
    /// See [PayoutType](#type-payouttype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public PayoutType? Type { get; set; }

    /// <summary>
    /// A list of transfer fees and any taxes on the fees assessed by Square for this payout.
    /// </summary>
    [JsonPropertyName("payout_fee")]
    public IEnumerable<PayoutFee>? PayoutFee { get; set; }

    /// <summary>
    /// The calendar date, in ISO 8601 format (YYYY-MM-DD), when the payout is due to arrive in the seller’s banking destination.
    /// </summary>
    [JsonPropertyName("arrival_date")]
    public string? ArrivalDate { get; set; }

    /// <summary>
    /// A unique ID for each `Payout` object that might also appear on the seller’s bank statement. You can use this ID to automate the process of reconciling each payout with the corresponding line item on the bank statement.
    /// </summary>
    [JsonPropertyName("end_to_end_id")]
    public string? EndToEndId { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
