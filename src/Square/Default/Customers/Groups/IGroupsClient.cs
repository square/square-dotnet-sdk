using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Customers.Groups;

public partial interface IGroupsClient
{
    /// <summary>
    /// Retrieves the list of customer groups of a business.
    /// </summary>
    Task<Pager<CustomerGroup>> ListAsync(
        ListGroupsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new customer group for a business.
    ///
    /// The request must include the `name` value of the group.
    /// </summary>
    Task<CreateCustomerGroupResponse> CreateAsync(
        CreateCustomerGroupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a specific customer group as identified by the `group_id` value.
    /// </summary>
    Task<GetCustomerGroupResponse> GetAsync(
        GetGroupsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a customer group as identified by the `group_id` value.
    /// </summary>
    Task<UpdateCustomerGroupResponse> UpdateAsync(
        UpdateCustomerGroupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a customer group as identified by the `group_id` value.
    /// </summary>
    Task<DeleteCustomerGroupResponse> DeleteAsync(
        DeleteGroupsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds a group membership to a customer.
    ///
    /// The customer is identified by the `customer_id` value
    /// and the customer group is identified by the `group_id` value.
    /// </summary>
    Task<AddGroupToCustomerResponse> AddAsync(
        AddGroupsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a group membership from a customer.
    ///
    /// The customer is identified by the `customer_id` value
    /// and the customer group is identified by the `group_id` value.
    /// </summary>
    Task<RemoveGroupFromCustomerResponse> RemoveAsync(
        RemoveGroupsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
