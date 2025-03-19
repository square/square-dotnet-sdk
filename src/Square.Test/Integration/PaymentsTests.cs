using NUnit.Framework;
using Square.Payments;

namespace Square.Test.Integration;

[TestFixture]
public class PaymentsTests
{
    private SquareClient _client;
    private string _paymentId;

    [SetUp]
    public async Task SetUp()
    {
        _client = Helpers.CreateClient();
        // Create initial payment for testing
        var paymentRequest = new CreatePaymentRequest
        {
            SourceId = "cnon:card-nonce-ok",
            IdempotencyKey = Guid.NewGuid().ToString(),
            AmountMoney = Helpers.NewTestMoney(200),
            AppFeeMoney = Helpers.NewTestMoney(10),
            Autocomplete = false,
        };
        var paymentResponse = await _client.Payments.CreateAsync(paymentRequest);
        var payment = paymentResponse.Payment ?? throw new Exception("Payment is null.");
        _paymentId = payment.Id ?? throw new Exception("Payment ID is null.");
    }

    [Test]
    public async Task TestListPayments()
    {
        var listRequest = new ListPaymentsRequest();
        var pager = await _client.Payments.ListAsync(listRequest);
        Assert.That(pager.CurrentPage.Items, Is.Not.Empty);
    }

    [Test]
    public async Task TestCreatePayment()
    {
        var paymentRequest = new CreatePaymentRequest
        {
            SourceId = "cnon:card-nonce-ok",
            IdempotencyKey = Guid.NewGuid().ToString(),
            AmountMoney = Helpers.NewTestMoney(200),
            AppFeeMoney = Helpers.NewTestMoney(10),
            Autocomplete = false,
        };
        var response = await _client.Payments.CreateAsync(paymentRequest);

        Assert.Multiple(() =>
        {
            Assert.That(response.Payment, Is.Not.Null);
            Assert.That(response.Payment?.AppFeeMoney, Is.Not.Null);
            Assert.That(response.Payment?.AppFeeMoney?.Amount, Is.EqualTo(10));
            Assert.That(response.Payment?.AppFeeMoney?.Currency, Is.EqualTo("USD"));
            Assert.That(response.Payment?.AmountMoney, Is.Not.Null);
            Assert.That(response.Payment?.AmountMoney?.Amount, Is.EqualTo(200));
            Assert.That(response.Payment?.AmountMoney?.Currency, Is.EqualTo("USD"));
        });
    }

    [Test]
    public async Task TestGetPayment()
    {
        var response = await _client.Payments.GetAsync(
            new GetPaymentsRequest { PaymentId = _paymentId }
        );
        Assert.That(response.Payment, Is.Not.Null);
        Assert.That(response.Payment.Id, Is.EqualTo(_paymentId));
    }

    [Test]
    public async Task TestCancelPayment()
    {
        var response = await _client.Payments.CancelAsync(
            new CancelPaymentsRequest { PaymentId = _paymentId }
        );
        Assert.That(response.Payment, Is.Not.Null);
        Assert.That(response.Payment.Id, Is.EqualTo(_paymentId));
    }

    [Test]
    public async Task TestCancelPaymentByIdempotencyKey()
    {
        var idempotencyKey = Guid.NewGuid().ToString();

        // Create payment to cancel
        var paymentRequest = new CreatePaymentRequest
        {
            SourceId = "cnon:card-nonce-ok",
            IdempotencyKey = idempotencyKey,
            AmountMoney = Helpers.NewTestMoney(200),
            AppFeeMoney = Helpers.NewTestMoney(10),
            Autocomplete = false,
        };
        await _client.Payments.CreateAsync(paymentRequest);

        // Cancel by idempotency key
        var cancelRequest = new CancelPaymentByIdempotencyKeyRequest
        {
            IdempotencyKey = idempotencyKey,
        };
        var response = await _client.Payments.CancelByIdempotencyKeyAsync(cancelRequest);

        Assert.That(response, Is.Not.Null);
    }

    [Test]
    public async Task TestCompletePayment()
    {
        // Create payment to complete
        var paymentRequest = new CreatePaymentRequest
        {
            SourceId = "cnon:card-nonce-ok",
            IdempotencyKey = Guid.NewGuid().ToString(),
            AmountMoney = Helpers.NewTestMoney(200),
            AppFeeMoney = Helpers.NewTestMoney(10),
            Autocomplete = false,
        };
        var createResponse = await _client.Payments.CreateAsync(paymentRequest);

        var payment = createResponse.Payment ?? throw new Exception("Payment is null.");
        _paymentId = payment.Id ?? throw new Exception("Payment ID is null.");
        var response = await _client.Payments.CompleteAsync(
            new CompletePaymentRequest { PaymentId = _paymentId }
        );

        Assert.That(response.Payment, Is.Not.Null);
        Assert.That(response.Payment.Status, Is.EqualTo("COMPLETED"));
    }
}
