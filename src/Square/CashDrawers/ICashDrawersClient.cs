namespace Square.CashDrawers;

public partial interface ICashDrawersClient
{
    public Square.CashDrawers.Shifts.ShiftsClient Shifts { get; }
}
