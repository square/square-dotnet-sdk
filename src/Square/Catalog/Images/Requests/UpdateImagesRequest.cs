using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Catalog.Images;

public record UpdateImagesRequest
{
    /// <summary>
    /// The ID of the `CatalogImage` object to update the encapsulated image file.
    /// </summary>
    [JsonIgnore]
    public required string ImageId { get; set; }

    public UpdateCatalogImageRequest? Request { get; set; }

    public FileParameter? ImageFile { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
