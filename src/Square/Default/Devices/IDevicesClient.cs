using Square;
using Square.Core;
using Square.Default.Devices;

namespace Square.Default;

public partial interface IDevicesClient
{
    public CodesClient Codes { get; }

    /// <summary>
    /// List devices associated with the merchant. Currently, only Terminal API
    /// devices are supported.
    /// </summary>
    Task<Pager<Device>> ListAsync(
        ListDevicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves Device with the associated `device_id`.
    /// </summary>
    Task<GetDeviceResponse> GetAsync(
        GetDevicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
