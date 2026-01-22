using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record GetGiftCardFromGanRequest
{
    /// <summary>
    /// The gift card account number (GAN) of the gift card to retrieve.
    /// The maximum length of a GAN is 255 digits to account for third-party GANs that have been imported.
    /// Square-issued gift cards have 16-digit GANs.
    /// </summary>
    [JsonPropertyName("gan")]
    public required string Gan { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
