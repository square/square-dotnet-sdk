using System.Globalization;
using NUnit.Framework;
using Square.CashDrawers.Shifts;

namespace Square.Test.Integration;

[TestFixture]
public class CashDrawersTests
{
    private readonly SquareClient _client = Helpers.CreateClient();

    [Test]
    public async Task TestListCashDrawerShifts()
    {
        var beginTime = DateTimeOffset
            .UtcNow.AddSeconds(-1)
            .ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);
        var endTime = DateTimeOffset.UtcNow.ToString(
            "yyyy-MM-ddTHH:mm:ss.fffZ",
            CultureInfo.InvariantCulture
        );
        var locationId = await Helpers.GetDefaultLocationIdAsync(_client);

        var request = new ListShiftsRequest
        {
            LocationId = locationId,
            BeginTime = beginTime,
            EndTime = endTime,
        };

        var pager = await _client.CashDrawers.Shifts.ListAsync(request);

        var counter = 0;
        await foreach (var shift in pager)
        {
            if (counter++ == 10)
            {
                break;
            }
            Assert.That(shift, Is.Not.Null);
        }
    }
}
