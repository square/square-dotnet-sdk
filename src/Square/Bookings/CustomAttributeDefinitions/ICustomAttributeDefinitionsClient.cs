using Square;
using Square.Core;

namespace Square.Bookings.CustomAttributeDefinitions;

public partial interface ICustomAttributeDefinitionsClient
{
    /// <summary>
    /// Get all bookings custom attribute definitions.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
    /// </summary>
    Task<Pager<CustomAttributeDefinition>> ListAsync(
        ListCustomAttributeDefinitionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a bookings custom attribute definition.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
    ///
    /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
    /// or *Appointments Premium*.
    /// </summary>
    Task<CreateBookingCustomAttributeDefinitionResponse> CreateAsync(
        CreateBookingCustomAttributeDefinitionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a bookings custom attribute definition.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
    /// </summary>
    Task<RetrieveBookingCustomAttributeDefinitionResponse> GetAsync(
        GetCustomAttributeDefinitionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a bookings custom attribute definition.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
    ///
    /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
    /// or *Appointments Premium*.
    /// </summary>
    Task<UpdateBookingCustomAttributeDefinitionResponse> UpdateAsync(
        UpdateBookingCustomAttributeDefinitionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a bookings custom attribute definition.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
    ///
    /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
    /// or *Appointments Premium*.
    /// </summary>
    Task<DeleteBookingCustomAttributeDefinitionResponse> DeleteAsync(
        DeleteCustomAttributeDefinitionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
