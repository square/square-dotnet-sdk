using global::System.Threading.Tasks;
using NUnit.Framework;
using Square;
using Square.BankAccounts;
using Square.Core;

namespace Square.Test.Unit.MockServer;

[TestFixture]
public class GetByV1IdTest : BaseMockServerTest
{
    [Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
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
              ],
              "bank_account": {
                "id": "w3yRgCGYQnwmdl0R3GB",
                "account_number_suffix": "971",
                "country": "US",
                "currency": "USD",
                "account_type": "CHECKING",
                "holder_name": "Jane Doe",
                "primary_bank_identification_number": "112200303",
                "secondary_bank_identification_number": "secondary_bank_identification_number",
                "debit_mandate_reference_id": "debit_mandate_reference_id",
                "reference_id": "reference_id",
                "location_id": "S8GWD5example",
                "status": "VERIFICATION_IN_PROGRESS",
                "creditable": false,
                "debitable": false,
                "fingerprint": "fingerprint",
                "version": 5,
                "bank_name": "Bank Name"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/bank-accounts/by-v1-id/v1_bank_account_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.BankAccounts.GetByV1IdAsync(
            new GetByV1IdBankAccountsRequest { V1BankAccountId = "v1_bank_account_id" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetBankAccountByV1IdResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
