using NUnit.Framework;
using Square.Core;
using Square.Default;
using Square.Default.Invoices;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.Invoices;

[TestFixture]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "errors": [
                {
                  "category": "API_ERROR",
                  "code": "INTERNAL_SERVER_ERROR",
                  "detail": "detail",
                  "field": "field"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/invoices/invoice_id")
                    .WithParam("version", "1")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Default.Invoices.DeleteAsync(
            new DeleteInvoicesRequest { InvoiceId = "invoice_id", Version = 1 }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeleteInvoiceResponse>(mockResponse)).UsingDefaults()
        );
    }
}
