using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;

namespace Square.Catalog.Object;

public partial class ObjectClient
{
    private RawClient _client;

    internal ObjectClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Creates a new or updates the specified [CatalogObject](entity:CatalogObject).
    ///
    /// To ensure consistency, only one update request is processed at a time per seller account.
    /// While one (batch or non-batch) update request is being processed, other (batched and non-batched)
    /// update requests are rejected with the `429` error code.
    /// </summary>
    /// <example><code>
    /// await client.Catalog.Object.UpsertAsync(
    ///     new UpsertCatalogObjectRequest
    ///     {
    ///         IdempotencyKey = "af3d1afc-7212-4300-b463-0bfc5314a5ae",
    ///         Object = new CatalogObject(new CatalogObject.Item(new CatalogObjectItem { Id = "id" })),
    ///     }
    /// );
    /// </code></example>
    public async Task<UpsertCatalogObjectResponse> UpsertAsync(
        UpsertCatalogObjectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/catalog/object",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<UpsertCatalogObjectResponse>(responseBody)!;
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
    /// Returns a single [CatalogItem](entity:CatalogItem) as a
    /// [CatalogObject](entity:CatalogObject) based on the provided ID. The returned
    /// object includes all of the relevant [CatalogItem](entity:CatalogItem)
    /// information including: [CatalogItemVariation](entity:CatalogItemVariation)
    /// children, references to its
    /// [CatalogModifierList](entity:CatalogModifierList) objects, and the ids of
    /// any [CatalogTax](entity:CatalogTax) objects that apply to it.
    /// </summary>
    /// <example><code>
    /// await client.Catalog.Object.GetAsync(new GetObjectRequest { ObjectId = "object_id" });
    /// </code></example>
    public async Task<GetCatalogObjectResponse> GetAsync(
        GetObjectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.IncludeRelatedObjects != null)
        {
            _query["include_related_objects"] = JsonUtils.Serialize(
                request.IncludeRelatedObjects.Value
            );
        }
        if (request.CatalogVersion != null)
        {
            _query["catalog_version"] = request.CatalogVersion.Value.ToString();
        }
        if (request.IncludeCategoryPathToRoot != null)
        {
            _query["include_category_path_to_root"] = JsonUtils.Serialize(
                request.IncludeCategoryPathToRoot.Value
            );
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/catalog/object/{0}",
                        ValueConvert.ToPathParameterString(request.ObjectId)
                    ),
                    Query = _query,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<GetCatalogObjectResponse>(responseBody)!;
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
    /// Deletes a single [CatalogObject](entity:CatalogObject) based on the
    /// provided ID and returns the set of successfully deleted IDs in the response.
    /// Deletion is a cascading event such that all children of the targeted object
    /// are also deleted. For example, deleting a [CatalogItem](entity:CatalogItem)
    /// will also delete all of its
    /// [CatalogItemVariation](entity:CatalogItemVariation) children.
    ///
    /// To ensure consistency, only one delete request is processed at a time per seller account.
    /// While one (batch or non-batch) delete request is being processed, other (batched and non-batched)
    /// delete requests are rejected with the `429` error code.
    /// </summary>
    /// <example><code>
    /// await client.Catalog.Object.DeleteAsync(new DeleteObjectRequest { ObjectId = "object_id" });
    /// </code></example>
    public async Task<DeleteCatalogObjectResponse> DeleteAsync(
        DeleteObjectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "v2/catalog/object/{0}",
                        ValueConvert.ToPathParameterString(request.ObjectId)
                    ),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<DeleteCatalogObjectResponse>(responseBody)!;
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
