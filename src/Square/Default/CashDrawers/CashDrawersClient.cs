using Square.Core;

namespace Square.Default.CashDrawers;

public partial class CashDrawersClient : ICashDrawersClient
{
    private RawClient _client;

    internal CashDrawersClient(RawClient client)
    {
        _client = client;
        Shifts = new Square.Default.CashDrawers.Shifts.ShiftsClient(_client);
    }

    public Square.Default.CashDrawers.Shifts.ShiftsClient Shifts { get; }
}
