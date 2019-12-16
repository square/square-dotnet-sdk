# Checkout

```csharp
ICheckoutApi checkoutApi = client.CheckoutApi;
```

## Class Name

`CheckoutApi`

## Create Checkout

Links a `checkoutId` to a `checkout_page_url` that customers will
be directed to in order to provide their payment information using a
payment processing workflow hosted on connect.squareup.com.

```csharp
CreateCheckoutAsync(string locationId, Models.CreateCheckoutRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the business location to associate the checkout with. |
| `body` | [`Models.CreateCheckoutRequest`](/doc/models/create-checkout-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreateCheckoutResponse>`](/doc/models/create-checkout-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
var bodyOrderLineItems = new List<CreateOrderRequestLineItem>();

var bodyOrderLineItems0BasePriceMoney = new Money.Builder()
    .Amount(1500L)
    .Currency("USD")
    .Build();
var bodyOrderLineItems0Discounts = new List<CreateOrderRequestDiscount>();

var bodyOrderLineItems0Discounts0 = new CreateOrderRequestDiscount.Builder()
    .Name("7% off previous season item")
    .Percentage("7")
    .Build();
bodyOrderLineItems0Discounts.Add(bodyOrderLineItems0Discounts0);

var bodyOrderLineItems0Discounts1AmountMoney = new Money.Builder()
    .Amount(300L)
    .Currency("USD")
    .Build();
var bodyOrderLineItems0Discounts1 = new CreateOrderRequestDiscount.Builder()
    .Name("$3 off Customer Discount")
    .AmountMoney(bodyOrderLineItems0Discounts1AmountMoney)
    .Build();
bodyOrderLineItems0Discounts.Add(bodyOrderLineItems0Discounts1);

var bodyOrderLineItems0 = new CreateOrderRequestLineItem.Builder(
        "2")
    .Name("Printed T Shirt")
    .BasePriceMoney(bodyOrderLineItems0BasePriceMoney)
    .Discounts(bodyOrderLineItems0Discounts)
    .Build();
bodyOrderLineItems.Add(bodyOrderLineItems0);

var bodyOrderLineItems1BasePriceMoney = new Money.Builder()
    .Amount(2500L)
    .Currency("USD")
    .Build();
var bodyOrderLineItems1 = new CreateOrderRequestLineItem.Builder(
        "1")
    .Name("Slim Jeans")
    .BasePriceMoney(bodyOrderLineItems1BasePriceMoney)
    .Build();
bodyOrderLineItems.Add(bodyOrderLineItems1);

var bodyOrderLineItems2BasePriceMoney = new Money.Builder()
    .Amount(3500L)
    .Currency("USD")
    .Build();
var bodyOrderLineItems2Taxes = new List<CreateOrderRequestTax>();

var bodyOrderLineItems2Taxes0 = new CreateOrderRequestTax.Builder()
    .Name("Fair Trade Tax")
    .Percentage("5")
    .Build();
bodyOrderLineItems2Taxes.Add(bodyOrderLineItems2Taxes0);

var bodyOrderLineItems2Discounts = new List<CreateOrderRequestDiscount>();

var bodyOrderLineItems2Discounts0AmountMoney = new Money.Builder()
    .Amount(1100L)
    .Currency("USD")
    .Build();
var bodyOrderLineItems2Discounts0 = new CreateOrderRequestDiscount.Builder()
    .Name("$11 off Customer Discount")
    .AmountMoney(bodyOrderLineItems2Discounts0AmountMoney)
    .Build();
bodyOrderLineItems2Discounts.Add(bodyOrderLineItems2Discounts0);

var bodyOrderLineItems2 = new CreateOrderRequestLineItem.Builder(
        "3")
    .Name("Woven Sweater")
    .BasePriceMoney(bodyOrderLineItems2BasePriceMoney)
    .Taxes(bodyOrderLineItems2Taxes)
    .Discounts(bodyOrderLineItems2Discounts)
    .Build();
bodyOrderLineItems.Add(bodyOrderLineItems2);

var bodyOrderTaxes = new List<CreateOrderRequestTax>();

var bodyOrderTaxes0 = new CreateOrderRequestTax.Builder()
    .Name("Sales Tax")
    .Percentage("8.5")
    .Build();
bodyOrderTaxes.Add(bodyOrderTaxes0);

var bodyOrderDiscounts = new List<CreateOrderRequestDiscount>();

var bodyOrderDiscounts0 = new CreateOrderRequestDiscount.Builder()
    .Name("Father's day 12% OFF")
    .Percentage("12")
    .Build();
bodyOrderDiscounts.Add(bodyOrderDiscounts0);

var bodyOrderDiscounts1AmountMoney = new Money.Builder()
    .Amount(5500L)
    .Currency("USD")
    .Build();
var bodyOrderDiscounts1 = new CreateOrderRequestDiscount.Builder()
    .Name("Global Sales $55 OFF")
    .AmountMoney(bodyOrderDiscounts1AmountMoney)
    .Build();
bodyOrderDiscounts.Add(bodyOrderDiscounts1);

var bodyOrder = new CreateOrderRequest.Builder()
    .ReferenceId("reference_id")
    .LineItems(bodyOrderLineItems)
    .Taxes(bodyOrderTaxes)
    .Discounts(bodyOrderDiscounts)
    .Build();
var bodyPrePopulateShippingAddress = new Address.Builder()
    .AddressLine1("1455 Market St.")
    .AddressLine2("Suite 600")
    .Locality("San Francisco")
    .AdministrativeDistrictLevel1("CA")
    .PostalCode("94103")
    .Country("US")
    .FirstName("Jane")
    .LastName("Doe")
    .Build();
var bodyAdditionalRecipients = new List<ChargeRequestAdditionalRecipient>();

var bodyAdditionalRecipients0AmountMoney = new Money.Builder()
    .Amount(60L)
    .Currency("USD")
    .Build();
var bodyAdditionalRecipients0 = new ChargeRequestAdditionalRecipient.Builder(
        "057P5VYJ4A5X1",
        "Application fees",
        bodyAdditionalRecipients0AmountMoney)
    .Build();
bodyAdditionalRecipients.Add(bodyAdditionalRecipients0);

var body = new CreateCheckoutRequest.Builder(
        "86ae1696-b1e3-4328-af6d-f1e04d947ad6",
        bodyOrder)
    .AskForShippingAddress(true)
    .MerchantSupportEmail("merchant+support@website.com")
    .PrePopulateBuyerEmail("example@email.com")
    .PrePopulateShippingAddress(bodyPrePopulateShippingAddress)
    .RedirectUrl("https://merchant.website.com/order-confirm")
    .AdditionalRecipients(bodyAdditionalRecipients)
    .Build();

try
{
    CreateCheckoutResponse result = checkoutApi.CreateCheckoutAsync(locationId, body).Result;
}
catch (ApiException e){};
```

