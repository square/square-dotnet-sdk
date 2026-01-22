using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Catalog;

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
