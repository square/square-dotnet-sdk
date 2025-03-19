using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Identifiers for the location used by various governments for tax purposes.
/// </summary>
public record TaxIds
{
    /// <summary>
    /// The EU VAT number for this location. For example, `IE3426675K`.
    /// If the EU VAT number is present, it is well-formed and has been
    /// validated with VIES, the VAT Information Exchange System.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("eu_vat")]
    public string? EuVat { get; set; }

    /// <summary>
    /// The SIRET (Système d'Identification du Répertoire des Entreprises et de leurs Etablissements)
    /// number is a 14-digit code issued by the French INSEE. For example, `39922799000021`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("fr_siret")]
    public string? FrSiret { get; set; }

    /// <summary>
    /// The French government uses the NAF (Nomenclature des Activités Françaises) to display and
    /// track economic statistical data. This is also called the APE (Activite Principale de l’Entreprise) code.
    /// For example, `6910Z`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("fr_naf")]
    public string? FrNaf { get; set; }

    /// <summary>
    /// The NIF (Numero de Identificacion Fiscal) number is a nine-character tax identifier used in Spain.
    /// If it is present, it has been validated. For example, `73628495A`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("es_nif")]
    public string? EsNif { get; set; }

    /// <summary>
    /// The QII (Qualified Invoice Issuer) number is a 14-character tax identifier used in Japan.
    /// For example, `T1234567890123`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("jp_qii")]
    public string? JpQii { get; set; }

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
