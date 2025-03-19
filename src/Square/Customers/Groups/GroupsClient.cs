using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;

namespace Square.Customers.Groups;

public partial class GroupsClient
{
    private RawClient _client;

    internal GroupsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieves the list of customer groups of a business.
    /// </summary>
    private async Task<ListCustomerGroupsResponse> ListInternalAsync(
        ListGroupsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/customers/groups",
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
                return JsonUtils.Deserialize<ListCustomerGroupsResponse>(responseBody)!;
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
    /// Retrieves the list of customer groups of a business.
    /// </summary>
    /// <example><code>
    /// await client.Customers.Groups.ListAsync(new ListGroupsRequest());
    /// </code></example>
    public async Task<Pager<CustomerGroup>> ListAsync(
        ListGroupsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListGroupsRequest,
            RequestOptions?,
            ListCustomerGroupsResponse,
            string?,
            CustomerGroup
        >
            .CreateInstanceAsync(
                request,
                options,
                ListInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response?.Cursor,
                response => response?.Groups?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Creates a new customer group for a business.
    ///
    /// The request must include the `name` value of the group.
    /// </summary>
    /// <example><code>
    /// await client.Customers.Groups.CreateAsync(
    ///     new CreateCustomerGroupRequest { Group = new CustomerGroup { Name = "Loyal Customers" } }
    /// );
    /// </code></example>
    public async Task<CreateCustomerGroupResponse> CreateAsync(
        CreateCustomerGroupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/customers/groups",
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
                return JsonUtils.Deserialize<CreateCustomerGroupResponse>(responseBody)!;
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
    /// Retrieves a specific customer group as identified by the `group_id` value.
    /// </summary>
    /// <example><code>
    /// await client.Customers.Groups.GetAsync(new GetGroupsRequest { GroupId = "group_id" });
    /// </code></example>
    public async Task<GetCustomerGroupResponse> GetAsync(
        GetGroupsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/customers/groups/{0}",
                        ValueConvert.ToPathParameterString(request.GroupId)
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
                return JsonUtils.Deserialize<GetCustomerGroupResponse>(responseBody)!;
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
    /// Updates a customer group as identified by the `group_id` value.
    /// </summary>
    /// <example><code>
    /// await client.Customers.Groups.UpdateAsync(
    ///     new UpdateCustomerGroupRequest
    ///     {
    ///         GroupId = "group_id",
    ///         Group = new CustomerGroup { Name = "Loyal Customers" },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateCustomerGroupResponse> UpdateAsync(
        UpdateCustomerGroupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "v2/customers/groups/{0}",
                        ValueConvert.ToPathParameterString(request.GroupId)
                    ),
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
                return JsonUtils.Deserialize<UpdateCustomerGroupResponse>(responseBody)!;
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
    /// Deletes a customer group as identified by the `group_id` value.
    /// </summary>
    /// <example><code>
    /// await client.Customers.Groups.DeleteAsync(new DeleteGroupsRequest { GroupId = "group_id" });
    /// </code></example>
    public async Task<DeleteCustomerGroupResponse> DeleteAsync(
        DeleteGroupsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "v2/customers/groups/{0}",
                        ValueConvert.ToPathParameterString(request.GroupId)
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
                return JsonUtils.Deserialize<DeleteCustomerGroupResponse>(responseBody)!;
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
    /// Adds a group membership to a customer.
    ///
    /// The customer is identified by the `customer_id` value
    /// and the customer group is identified by the `group_id` value.
    /// </summary>
    /// <example><code>
    /// await client.Customers.Groups.AddAsync(
    ///     new AddGroupsRequest { CustomerId = "customer_id", GroupId = "group_id" }
    /// );
    /// </code></example>
    public async Task<AddGroupToCustomerResponse> AddAsync(
        AddGroupsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "v2/customers/{0}/groups/{1}",
                        ValueConvert.ToPathParameterString(request.CustomerId),
                        ValueConvert.ToPathParameterString(request.GroupId)
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
                return JsonUtils.Deserialize<AddGroupToCustomerResponse>(responseBody)!;
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
    /// Removes a group membership from a customer.
    ///
    /// The customer is identified by the `customer_id` value
    /// and the customer group is identified by the `group_id` value.
    /// </summary>
    /// <example><code>
    /// await client.Customers.Groups.RemoveAsync(
    ///     new RemoveGroupsRequest { CustomerId = "customer_id", GroupId = "group_id" }
    /// );
    /// </code></example>
    public async Task<RemoveGroupFromCustomerResponse> RemoveAsync(
        RemoveGroupsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "v2/customers/{0}/groups/{1}",
                        ValueConvert.ToPathParameterString(request.CustomerId),
                        ValueConvert.ToPathParameterString(request.GroupId)
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
                return JsonUtils.Deserialize<RemoveGroupFromCustomerResponse>(responseBody)!;
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
