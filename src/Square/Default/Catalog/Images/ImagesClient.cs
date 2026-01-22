using System.Text.Json;
using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Catalog;

public partial class ImagesClient : IImagesClient
{
    private RawClient _client;

    internal ImagesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Uploads an image file to be represented by a [CatalogImage](entity:CatalogImage) object that can be linked to an existing
    /// [CatalogObject](entity:CatalogObject) instance. The resulting `CatalogImage` is unattached to any `CatalogObject` if the `object_id`
    /// is not specified.
    ///
    /// This `CreateCatalogImage` endpoint accepts HTTP multipart/form-data requests with a JSON part and an image file part in
    /// JPEG, PJPEG, PNG, or GIF format. The maximum file size is 15MB.
    /// </summary>
    /// <example><code>
    /// await client.Default.Catalog.Images.CreateAsync(new CreateImagesRequest());
    /// </code></example>
    public async Task<CreateCatalogImageResponse> CreateAsync(
        CreateImagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var multipartFormRequest_ = new MultipartFormRequest
        {
            BaseUrl = _client.Options.BaseUrl,
            Method = HttpMethod.Post,
            Path = "v2/catalog/images",
            Options = options,
        };
        multipartFormRequest_.AddJsonPart(
            "request",
            request.Request,
            "application/json; charset=utf-8"
        );
        multipartFormRequest_.AddFileParameterPart("image_file", request.ImageFile, "image/jpeg");
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<CreateCatalogImageResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Uploads a new image file to replace the existing one in the specified [CatalogImage](entity:CatalogImage) object.
    ///
    /// This `UpdateCatalogImage` endpoint accepts HTTP multipart/form-data requests with a JSON part and an image file part in
    /// JPEG, PJPEG, PNG, or GIF format. The maximum file size is 15MB.
    /// </summary>
    /// <example><code>
    /// await client.Default.Catalog.Images.UpdateAsync(new UpdateImagesRequest { ImageId = "image_id" });
    /// </code></example>
    public async Task<UpdateCatalogImageResponse> UpdateAsync(
        UpdateImagesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var multipartFormRequest_ = new MultipartFormRequest
        {
            BaseUrl = _client.Options.BaseUrl,
            Method = HttpMethod.Put,
            Path = string.Format(
                "v2/catalog/images/{0}",
                ValueConvert.ToPathParameterString(request.ImageId)
            ),
            Options = options,
        };
        multipartFormRequest_.AddJsonPart(
            "request",
            request.Request,
            "application/json; charset=utf-8"
        );
        multipartFormRequest_.AddFileParameterPart("image_file", request.ImageFile, "image/jpeg");
        var response = await _client
            .SendRequestAsync(multipartFormRequest_, cancellationToken)
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<UpdateCatalogImageResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
