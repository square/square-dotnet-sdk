using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Devices;

public partial interface ICodesClient
{
    /// <summary>
    /// Lists all DeviceCodes associated with the merchant.
    /// </summary>
    Task<Pager<DeviceCode>> ListAsync(
        ListCodesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a DeviceCode that can be used to login to a Square Terminal device to enter the connected
    /// terminal mode.
    /// </summary>
    Task<CreateDeviceCodeResponse> CreateAsync(
        CreateDeviceCodeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves DeviceCode with the associated ID.
    /// </summary>
    Task<GetDeviceCodeResponse> GetAsync(
        GetCodesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
