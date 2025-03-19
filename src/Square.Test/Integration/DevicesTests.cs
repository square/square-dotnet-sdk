using NUnit.Framework;
using Square.Devices.Codes;

// ReSharper disable NullableWarningSuppressionIsUsed

namespace Square.Test.Integration;

[TestFixture]
public class DevicesTests
{
    private readonly SquareClient _client = Helpers.CreateClient();
    private string? _deviceCodeId;

    [SetUp]
    public async Task SetUp()
    {
        var createResponse = await _client.Devices.Codes.CreateAsync(
            new CreateDeviceCodeRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                DeviceCode = new DeviceCode { ProductType = "TERMINAL_API" },
            }
        );

        var deviceCode =
            createResponse.DeviceCode ?? throw new Exception("Failed to create device code.");
        _deviceCodeId = deviceCode.Id ?? throw new Exception("Device code ID is null.");
    }

    [Test]
    public async Task TestListDeviceCodes()
    {
        var response = await _client.Devices.Codes.ListAsync(new ListCodesRequest());
        await foreach (var deviceCode in response)
        {
            Assert.That(deviceCode, Is.Not.Null);
        }
    }

    [Test]
    public async Task TestCreateDeviceCode()
    {
        var response = await _client.Devices.Codes.CreateAsync(
            new CreateDeviceCodeRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                DeviceCode = new DeviceCode { ProductType = "TERMINAL_API" },
            }
        );

        Assert.Multiple(() =>
        {
            Assert.That(response.DeviceCode, Is.Not.Null);
            Assert.That(response.DeviceCode?.ProductType, Is.EqualTo("TERMINAL_API"));
        });
    }

    [Test]
    public async Task TestGetDeviceCode()
    {
        var response = await _client.Devices.Codes.GetAsync(
            new GetCodesRequest { Id = _deviceCodeId! }
        );

        Assert.Multiple(() =>
        {
            Assert.That(response.DeviceCode, Is.Not.Null);
            Assert.That(response.DeviceCode?.Id, Is.EqualTo(_deviceCodeId));
            Assert.That(response.DeviceCode?.ProductType, Is.EqualTo("TERMINAL_API"));
        });
    }
}
