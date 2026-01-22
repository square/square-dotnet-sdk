using Square;
using Square.Core;
using Square.Default.Customers;

namespace Square.Default;

public partial interface ICustomersClient
{
    public Square.Default.Customers.CustomAttributeDefinitionsClient CustomAttributeDefinitions { get; }
    public GroupsClient Groups { get; }
    public SegmentsClient Segments { get; }
    public Square.Default.Customers.CardsClient Cards { get; }
    public Square.Default.Customers.CustomAttributesClient CustomAttributes { get; }

    /// <summary>
    /// Lists customer profiles associated with a Square account.
    ///
    /// Under normal operating conditions, newly created or updated customer profiles become available
    /// for the listing operation in well under 30 seconds. Occasionally, propagation of the new or updated
    /// profiles can take closer to one minute or longer, especially during network incidents and outages.
    /// </summary>
    Task<Pager<Customer>> ListAsync(
        ListCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new customer for a business.
    ///
    /// You must provide at least one of the following values in your request to this
    /// endpoint:
    ///
    /// - `given_name`
    /// - `family_name`
    /// - `company_name`
    /// - `email_address`
    /// - `phone_number`
    /// </summary>
    Task<CreateCustomerResponse> CreateAsync(
        CreateCustomerRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates multiple [customer profiles](entity:Customer) for a business.
    ///
    /// This endpoint takes a map of individual create requests and returns a map of responses.
    ///
    /// You must provide at least one of the following values in each create request:
    ///
    /// - `given_name`
    /// - `family_name`
    /// - `company_name`
    /// - `email_address`
    /// - `phone_number`
    /// </summary>
    Task<BulkCreateCustomersResponse> BatchCreateAsync(
        BulkCreateCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes multiple customer profiles.
    ///
    /// The endpoint takes a list of customer IDs and returns a map of responses.
    /// </summary>
    Task<BulkDeleteCustomersResponse> BulkDeleteCustomersAsync(
        BulkDeleteCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves multiple customer profiles.
    ///
    /// This endpoint takes a list of customer IDs and returns a map of responses.
    /// </summary>
    Task<BulkRetrieveCustomersResponse> BulkRetrieveCustomersAsync(
        BulkRetrieveCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates multiple customer profiles.
    ///
    /// This endpoint takes a map of individual update requests and returns a map of responses.
    /// </summary>
    Task<BulkUpdateCustomersResponse> BulkUpdateCustomersAsync(
        BulkUpdateCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Searches the customer profiles associated with a Square account using one or more supported query filters.
    ///
    /// Calling `SearchCustomers` without any explicit query filter returns all
    /// customer profiles ordered alphabetically based on `given_name` and
    /// `family_name`.
    ///
    /// Under normal operating conditions, newly created or updated customer profiles become available
    /// for the search operation in well under 30 seconds. Occasionally, propagation of the new or updated
    /// profiles can take closer to one minute or longer, especially during network incidents and outages.
    /// </summary>
    Task<SearchCustomersResponse> SearchAsync(
        SearchCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns details for a single customer.
    /// </summary>
    Task<GetCustomerResponse> GetAsync(
        GetCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a customer profile. This endpoint supports sparse updates, so only new or changed fields are required in the request.
    /// To add or update a field, specify the new value. To remove a field, specify `null`.
    ///
    /// To update a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile.
    /// </summary>
    Task<UpdateCustomerResponse> UpdateAsync(
        UpdateCustomerRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a customer profile from a business.
    ///
    /// To delete a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile.
    /// </summary>
    Task<DeleteCustomerResponse> DeleteAsync(
        DeleteCustomersRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
