using NUnit.Framework;
using Square.Disputes;
using Square.Disputes.Evidence;
using Square.Payments;

// ReSharper disable NullableWarningSuppressionIsUsed

namespace Square.Test.Integration;

[TestFixture]
public class DisputesTests
{
    private readonly SquareClient _client = Helpers.CreateClient();
    private string? _disputeId;
    private string _textEvidenceId;

    [SetUp]
    public async Task SetUp()
    {
        // Create a payment that will generate a dispute
        await _client.Payments.CreateAsync(
            new CreatePaymentRequest
            {
                SourceId = "cnon:card-nonce-ok",
                IdempotencyKey = Guid.NewGuid().ToString(),
                AmountMoney = new Money { Amount = 8803, Currency = Currency.Usd },
            }
        );

        // Poll for dispute to be created
        for (var i = 0; i < 100; i++)
        {
            var disputesPager = await _client.Disputes.ListAsync(
                new ListDisputesRequest { States = DisputeState.EvidenceRequired }
            );
            await foreach (var dispute in disputesPager)
            {
                _disputeId = dispute.Id ?? throw new Exception("Dispute ID is null");
                break;
            }

            if (_disputeId is not null)
            {
                break;
            }

            // Wait for 2 seconds before polling again
            await Task.Delay(2000);
        }

        if (_disputeId == null)
        {
            throw new Exception("Dispute was not created within the expected time frame.");
        }

        // Create evidence text for testing
        var evidenceResponse = await _client.Disputes.CreateEvidenceTextAsync(
            new CreateDisputeEvidenceTextRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                DisputeId = _disputeId,
                EvidenceText = "This is not a duplicate",
                EvidenceType = DisputeEvidenceType.GenericEvidence,
            }
        );
        _textEvidenceId =
            evidenceResponse.Evidence?.Id
            ?? throw new Exception("evidenceResponse.Evidence.Id is null");
    }

    [TearDown]
    public async Task TearDown()
    {
        // Clean up evidence if it exists
        try
        {
            await _client.Disputes.Evidence.DeleteAsync(
                new DeleteEvidenceRequest { DisputeId = _disputeId!, EvidenceId = _textEvidenceId }
            );
        }
        catch (Exception)
        {
            // Evidence might already be deleted by test
        }
    }

    [Test]
    public async Task TestCreateDisputeEvidenceFile()
    {
        await using var fileParameter = Helpers.GetTestFile();
        var response = await _client.Disputes.CreateEvidenceFileAsync(
            new CreateEvidenceFileDisputesRequest
            {
                DisputeId = _disputeId!,
                Request = new CreateDisputeEvidenceFileRequest
                {
                    IdempotencyKey = Guid.NewGuid().ToString(),
                    ContentType = "image/jpeg",
                    EvidenceType = DisputeEvidenceType.GenericEvidence,
                },
                ImageFile = fileParameter,
            }
        );

        Assert.Multiple(() =>
        {
            Assert.That(response.Evidence, Is.Not.Null);
            Assert.That(_disputeId, Is.EqualTo(response.Evidence?.DisputeId));
        });
    }

    [Test]
    public async Task TestListDisputes()
    {
        var response = await _client.Disputes.ListAsync(
            new ListDisputesRequest { States = DisputeState.EvidenceRequired }
        );
        var disputes = new List<Dispute>();
        await foreach (var dispute in response)
        {
            disputes.Add(dispute);
            if (disputes.Count >= 10)
                break;
        }
        Assert.Multiple(() =>
        {
            Assert.That(disputes, Is.Not.Empty);
            Assert.That(disputes[0].Reason, Is.EqualTo(DisputeReason.Duplicate));
            Assert.That(disputes[0].State, Is.EqualTo(DisputeState.EvidenceRequired));
            Assert.That(disputes[0].CardBrand, Is.EqualTo(CardBrand.Visa));
        });
    }

    [Test]
    public async Task TestRetrieveDispute()
    {
        var response = await _client.Disputes.GetAsync(
            new GetDisputesRequest { DisputeId = _disputeId! }
        );
        Assert.Multiple(() =>
        {
            Assert.That(response.Dispute, Is.Not.Null);
            Assert.That(response.Dispute?.Id, Is.EqualTo(_disputeId));
        });
    }

    [Test]
    public async Task TestCreateDisputeEvidenceText()
    {
        var response = await _client.Disputes.CreateEvidenceTextAsync(
            new CreateDisputeEvidenceTextRequest
            {
                DisputeId = _disputeId!,
                IdempotencyKey = Guid.NewGuid().ToString(),
                EvidenceText = "This is not a duplicate",
                EvidenceType = DisputeEvidenceType.GenericEvidence,
            }
        );
        Assert.That(response.Evidence, Is.Not.Null);
    }

    [Test]
    public async Task TestRetrieveDisputeEvidence()
    {
        var response = await _client.Disputes.Evidence.GetAsync(
            new GetEvidenceRequest { DisputeId = _disputeId!, EvidenceId = _textEvidenceId }
        );
        Assert.Multiple(() =>
        {
            Assert.That(response.Evidence, Is.Not.Null);
            Assert.That(response.Evidence?.Id, Is.EqualTo(_textEvidenceId));
        });
    }

    [Test]
    public async Task TestListDisputeEvidence()
    {
        var response = await _client.Disputes.Evidence.ListAsync(
            new ListEvidenceRequest { DisputeId = _disputeId! }
        );
        var evidenceList = new List<DisputeEvidence>();
        await foreach (var evidence in response)
        {
            evidenceList.Add(evidence);
            if (evidenceList.Count >= 10)
                break;
        }
        Assert.That(evidenceList, Is.Not.Empty);
    }

    [Test]
    public async Task TestDeleteDisputeEvidence()
    {
        var response = await _client.Disputes.Evidence.DeleteAsync(
            new DeleteEvidenceRequest { DisputeId = _disputeId!, EvidenceId = _textEvidenceId }
        );
        Assert.That(response, Is.Not.Null);
    }

    [Test]
    public async Task TestSubmitEvidence()
    {
        var response = await _client.Disputes.SubmitEvidenceAsync(
            new SubmitEvidenceDisputesRequest { DisputeId = _disputeId! }
        );
        Assert.That(response, Is.Not.Null);
    }

    [Test]
    public async Task TestAcceptDispute()
    {
        var response = await _client.Disputes.AcceptAsync(
            new AcceptDisputesRequest { DisputeId = _disputeId! }
        );
        Assert.That(response, Is.Not.Null);
    }
}
