namespace Square.Default.CashDrawers;

public partial interface ICashDrawersClient
{
    public ShiftsClient Shifts { get; }
}
