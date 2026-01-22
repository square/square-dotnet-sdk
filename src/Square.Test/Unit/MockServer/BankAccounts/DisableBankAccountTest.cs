using NUnit.Framework;
using Square;
using Square.BankAccounts;
using Square.Core;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.BankAccounts;

[TestFixture]
public class DisableBankAccountTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "bank_account": {
                "id": "bact:OxfBTiXgByaXds1K4GB",
                "account_number_suffix": "000",
                "country": "US",
                "currency": "USD",
                "account_type": "CHECKING",
                "holder_name": "Nicola Snow",
                "primary_bank_identification_number": "011401533",
                "secondary_bank_identification_number": "secondary_bank_identification_number",
                "debit_mandate_reference_id": "debit_mandate_reference_id",
                "reference_id": "reference_id",
                "location_id": "location_id",
                "status": "DISABLED",
                "creditable": true,
                "debitable": true,
                "fingerprint": "sq-1-mO3XNctJpTLL8uYowOWpioS8nQyTc838gcBo90254XonoEJ_c7Uw6yqL6qihFNY8fA",
                "version": 3,
                "bank_name": "Citizens Bank",
                "customer_id": "HM3B2D5JKGZ69359BTEHXM2V8M"
              },
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
                    .WithPath("/v2/bank-accounts/bank_account_id/disable")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.BankAccounts.DisableBankAccountAsync(
            new DisableBankAccountRequest { BankAccountId = "bank_account_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<DisableBankAccountResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
