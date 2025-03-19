using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an action processed by the Square Terminal.
/// </summary>
public record TerminalAction
{
    /// <summary>
    /// A unique ID for this `TerminalAction`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The unique Id of the device intended for this `TerminalAction`.
    /// The Id can be retrieved from /v2/devices api.
    /// </summary>
    [JsonPropertyName("device_id")]
    public string? DeviceId { get; set; }

    /// <summary>
    /// The duration as an RFC 3339 duration, after which the action will be automatically canceled.
    /// TerminalActions that are `PENDING` will be automatically `CANCELED` and have a cancellation reason
    /// of `TIMED_OUT`
    ///
    /// Default: 5 minutes from creation
    ///
    /// Maximum: 5 minutes
    /// </summary>
    [JsonPropertyName("deadline_duration")]
    public string? DeadlineDuration { get; set; }

    /// <summary>
    /// The status of the `TerminalAction`.
    /// Options: `PENDING`, `IN_PROGRESS`, `CANCEL_REQUESTED`, `CANCELED`, `COMPLETED`
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// The reason why `TerminalAction` is canceled. Present if the status is `CANCELED`.
    /// See [ActionCancelReason](#type-actioncancelreason) for possible values
    /// </summary>
    [JsonPropertyName("cancel_reason")]
    public ActionCancelReason? CancelReason { get; set; }

    /// <summary>
    /// The time when the `TerminalAction` was created as an RFC 3339 timestamp.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The time when the `TerminalAction` was last updated as an RFC 3339 timestamp.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The ID of the application that created the action.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("app_id")]
    public string? AppId { get; set; }

    /// <summary>
    /// The location id the action is attached to, if a link can be made.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// Represents the type of the action.
    /// See [ActionType](#type-actiontype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public TerminalActionActionType? Type { get; set; }

    /// <summary>
    /// Describes configuration for the QR code action. Requires `QR_CODE` type.
    /// </summary>
    [JsonPropertyName("qr_code_options")]
    public QrCodeOptions? QrCodeOptions { get; set; }

    /// <summary>
    /// Describes configuration for the save-card action. Requires `SAVE_CARD` type.
    /// </summary>
    [JsonPropertyName("save_card_options")]
    public SaveCardOptions? SaveCardOptions { get; set; }

    /// <summary>
    /// Describes configuration for the signature capture action. Requires `SIGNATURE` type.
    /// </summary>
    [JsonPropertyName("signature_options")]
    public SignatureOptions? SignatureOptions { get; set; }

    /// <summary>
    /// Describes configuration for the confirmation action. Requires `CONFIRMATION` type.
    /// </summary>
    [JsonPropertyName("confirmation_options")]
    public ConfirmationOptions? ConfirmationOptions { get; set; }

    /// <summary>
    /// Describes configuration for the receipt action. Requires `RECEIPT` type.
    /// </summary>
    [JsonPropertyName("receipt_options")]
    public ReceiptOptions? ReceiptOptions { get; set; }

    /// <summary>
    /// Describes configuration for the data collection action. Requires `DATA_COLLECTION` type.
    /// </summary>
    [JsonPropertyName("data_collection_options")]
    public DataCollectionOptions? DataCollectionOptions { get; set; }

    /// <summary>
    /// Describes configuration for the select action. Requires `SELECT` type.
    /// </summary>
    [JsonPropertyName("select_options")]
    public SelectOptions? SelectOptions { get; set; }

    /// <summary>
    /// Details about the Terminal that received the action request (such as battery level,
    /// operating system version, and network connection settings).
    ///
    /// Only available for `PING` action type.
    /// </summary>
    [JsonPropertyName("device_metadata")]
    public DeviceMetadata? DeviceMetadata { get; set; }

    /// <summary>
    /// Indicates the action will be linked to another action and requires a waiting dialog to be
    /// displayed instead of returning to the idle screen on completion of the action.
    ///
    /// Only supported on SIGNATURE, CONFIRMATION, DATA_COLLECTION, and SELECT types.
    /// </summary>
    [JsonPropertyName("await_next_action")]
    public bool? AwaitNextAction { get; set; }

    /// <summary>
    /// The timeout duration of the waiting dialog as an RFC 3339 duration, after which the
    /// waiting dialog will no longer be displayed and the Terminal will return to the idle screen.
    ///
    /// Default: 5 minutes from when the waiting dialog is displayed
    ///
    /// Maximum: 5 minutes
    /// </summary>
    [JsonPropertyName("await_next_action_duration")]
    public string? AwaitNextActionDuration { get; set; }

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
