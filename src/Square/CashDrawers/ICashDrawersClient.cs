namespace Square.CashDrawers;

public partial interface ICashDrawersClient
{
    public ShiftsClient Shifts { get; }
}
