using NUnit.Framework;
using Square.Payments;
using Square.Refunds;

// ReSharper disable NullableWarningSuppressionIsUsed

namespace Square.Test.Integration;

[TestFixture]
public class RefundsTests
{
    private readonly SquareClient _client = Helpers.CreateClient();
    private string? _paymentId;
    private string? _refundId;

    [SetUp]
    public async Task SetUp()
    {
        // Create payment for testing refunds
        var paymentRequest = new CreatePaymentRequest
        {
            SourceId = "cnon:card-nonce-ok",
            IdempotencyKey = Guid.NewGuid().ToString(),
            AmountMoney = Helpers.NewTestMoney(200),
            AppFeeMoney = Helpers.NewTestMoney(10),
            Autocomplete = true,
        };
        var paymentResponse = await _client.Payments.CreateAsync(paymentRequest);
        var payment =
            paymentResponse.Payment ?? throw new Exception("Payment or Payment ID is null.");
        _paymentId = payment.Id ?? throw new Exception("Payment ID is null.");

        // Create initial refund for testing
        var refundRequest = new RefundPaymentRequest
        {
            IdempotencyKey = Guid.NewGuid().ToString(),
            AmountMoney = Helpers.NewTestMoney(200),
            PaymentId = _paymentId,
        };
        var refundResponse = await _client.Refunds.RefundPaymentAsync(refundRequest);
        var refund = refundResponse.Refund ?? throw new Exception("Refund is null.");
        _refundId = refund.Id;
    }

    [Test]
    public async Task TestListPaymentRefunds()
    {
        var listRequest = new ListRefundsRequest();
        var response = await _client.Refunds.ListAsync(listRequest);
        var refunds = new List<PaymentRefund>();
        await foreach (var refund in response)
        {
            refunds.Add(refund);
            if (refunds.Count >= 10)
                break;
        }
        Assert.That(refunds, Is.Not.Empty);
    }

    [Test]
    public async Task TestRefundPayment()
    {
        // Create new payment to refund
        var paymentRequest = new CreatePaymentRequest
        {
            SourceId = "cnon:card-nonce-ok",
            IdempotencyKey = Guid.NewGuid().ToString(),
            AmountMoney = Helpers.NewTestMoney(200),
            AppFeeMoney = Helpers.NewTestMoney(10),
            Autocomplete = true,
        };
        var paymentResponse = await _client.Payments.CreateAsync(paymentRequest);
        var payment =
            paymentResponse.Payment ?? throw new Exception("Payment or Payment ID is null.");
        _paymentId = payment.Id ?? throw new Exception("Payment ID is null.");

        var refundRequest = new RefundPaymentRequest
        {
            IdempotencyKey = Guid.NewGuid().ToString(),
            AmountMoney = Helpers.NewTestMoney(200),
            PaymentId = _paymentId,
        };
        var response = await _client.Refunds.RefundPaymentAsync(refundRequest);

        Assert.Multiple(() =>
        {
            Assert.That(response.Refund, Is.Not.Null);
            Assert.That(response.Refund?.PaymentId, Is.EqualTo(_paymentId));
        });
    }

    [Test]
    public async Task TestGetPaymentRefund()
    {
        var response = await _client.Refunds.GetAsync(
            new GetRefundsRequest { RefundId = _refundId! }
        );
        Assert.Multiple(() =>
        {
            Assert.That(response.Refund, Is.Not.Null);
            Assert.That(response.Refund?.Id, Is.EqualTo(_refundId));
            Assert.That(response.Refund?.PaymentId, Is.EqualTo(_paymentId));
        });
    }

    [Test]
    public void TestHandleInvalidRefundId()
    {
        Assert.ThrowsAsync<SquareApiException>(async () =>
        {
            await _client.Refunds.GetAsync(new GetRefundsRequest { RefundId = "invalid-id" });
        });
    }
}
