using Square;
using Square.Core;

namespace Square.Catalog;

[Serializable]
public record CreateImagesRequest
{
    public CreateCatalogImageRequest? Request { get; set; }

    public FileParameter? ImageFile { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
