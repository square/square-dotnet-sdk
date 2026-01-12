using Square.Default;

namespace Square;

public partial interface ISquareClient
{
    public DefaultClient Default { get; }
}
