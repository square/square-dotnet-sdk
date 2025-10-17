using Square.Core;

namespace Square.CashDrawers;

public partial class CashDrawersClient
{
    private RawClient _client;

    internal CashDrawersClient(RawClient client)
    {
        _client = client;
        Shifts = new Square.CashDrawers.Shifts.ShiftsClient(_client);
    }

    public Square.CashDrawers.Shifts.ShiftsClient Shifts { get; }
}
