using NUnit.Framework;
using Square;
using WireMock.Logging;
using WireMock.Server;
using WireMock.Settings;

namespace Square.Test.Unit.MockServer;

[SetUpFixture]
public class BaseMockServerTest
{
    protected static WireMockServer Server { get; set; } = null!;

    protected static SquareClient Client { get; set; } = null!;

    protected static RequestOptions RequestOptions { get; set; } = null!;

    [OneTimeSetUp]
    public void GlobalSetup()
    {
        // Start the WireMock server
        Server = WireMockServer.Start(
            new WireMockServerSettings { Logger = new WireMockConsoleLogger() }
        );

        // Initialize the Client
        Client = new SquareClient("TOKEN");

        RequestOptions = new RequestOptions { BaseUrl = Server.Urls[0] };
    }

    [OneTimeTearDown]
    public void GlobalTeardown()
    {
        Server.Stop();
        Server.Dispose();
    }
}
