using Square.Core;

namespace Square.CashDrawers;

public partial class CashDrawersClient : ICashDrawersClient
{
    private RawClient _client;

    internal CashDrawersClient(RawClient client)
    {
        _client = client;
        Shifts = new ShiftsClient(_client);
    }

    public ShiftsClient Shifts { get; }
}
