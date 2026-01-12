using Square;
using Square.Default;

namespace Square.Default.Catalog.Images;

public partial interface IImagesClient
{
    /// <summary>
    /// Uploads an image file to be represented by a [CatalogImage](entity:CatalogImage) object that can be linked to an existing
    /// [CatalogObject](entity:CatalogObject) instance. The resulting `CatalogImage` is unattached to any `CatalogObject` if the `object_id`
    /// is not specified.
    ///
    /// This `CreateCatalogImage` endpoint accepts HTTP multipart/form-data requests with a JSON part and an image file part in
    /// JPEG, PJPEG, PNG, or GIF format. The maximum file size is 15MB.
    /// </summary>
    Task<CreateCatalogImageResponse> CreateAsync(
        CreateImagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Uploads a new image file to replace the existing one in the specified [CatalogImage](entity:CatalogImage) object.
    ///
    /// This `UpdateCatalogImage` endpoint accepts HTTP multipart/form-data requests with a JSON part and an image file part in
    /// JPEG, PJPEG, PNG, or GIF format. The maximum file size is 15MB.
    /// </summary>
    Task<UpdateCatalogImageResponse> UpdateAsync(
        UpdateImagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
