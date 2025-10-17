using System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.Core;
using Square.Invoices;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Invoices;

[TestFixture]
public class DeleteInvoiceAttachmentTest : BaseMockServerTest
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
                    .WithPath("/v2/invoices/invoice_id/attachments/attachment_id")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Invoices.DeleteInvoiceAttachmentAsync(
            new DeleteInvoiceAttachmentRequest
            {
                InvoiceId = "invoice_id",
                AttachmentId = "attachment_id",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DeleteInvoiceAttachmentResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
