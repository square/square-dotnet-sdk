namespace Square.Default.CashDrawers;

public partial interface ICashDrawersClient
{
    public Square.Default.CashDrawers.Shifts.ShiftsClient Shifts { get; }
}
