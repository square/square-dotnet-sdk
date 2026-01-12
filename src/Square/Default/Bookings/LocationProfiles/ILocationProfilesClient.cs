using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Bookings.LocationProfiles;

public partial interface ILocationProfilesClient
{
    /// <summary>
    /// Lists location booking profiles of a seller.
    /// </summary>
    Task<Pager<LocationBookingProfile>> ListAsync(
        ListLocationProfilesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
