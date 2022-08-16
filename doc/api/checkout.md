# Checkout

```csharp
ICheckoutApi checkoutApi = client.CheckoutApi;
```

## Class Name

`CheckoutApi`

## Methods

* [Create Checkout](../../doc/api/checkout.md#create-checkout)
* [List Payment Links](../../doc/api/checkout.md#list-payment-links)
* [Create Payment Link](../../doc/api/checkout.md#create-payment-link)
* [Delete Payment Link](../../doc/api/checkout.md#delete-payment-link)
* [Retrieve Payment Link](../../doc/api/checkout.md#retrieve-payment-link)
* [Update Payment Link](../../doc/api/checkout.md#update-payment-link)


# Create Checkout

**This endpoint is deprecated.**

Links a `checkoutId` to a `checkout_page_url` that customers are
directed to in order to provide their payment information using a
payment processing workflow hosted on connect.squareup.com.

NOTE: The Checkout API has been updated with new features.
For more information, see [Checkout API highlights](https://developer.squareup.com/docs/checkout-api#checkout-api-highlights).
We recommend that you use the new [CreatePaymentLink](../../doc/api/checkout.md#create-payment-link) 
endpoint in place of this previously released endpoint.

```csharp
CreateCheckoutAsync(
    string locationId,
    Models.CreateCheckoutRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the business location to associate the checkout with. |
| `body` | [`Models.CreateCheckoutRequest`](../../doc/models/create-checkout-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateCheckoutResponse>`](../../doc/models/create-checkout-response.md)

## Example Usage

```csharp
string locationId = "location_id4";
var bodyOrderOrderLineItems = new List<OrderLineItem>();

var bodyOrderOrderLineItems0AppliedTaxes = new List<OrderLineItemAppliedTax>();

var bodyOrderOrderLineItems0AppliedTaxes0 = new OrderLineItemAppliedTax.Builder(
        "38ze1696-z1e3-5628-af6d-f1e04d947fg3")
    .Build();
bodyOrderOrderLineItems0AppliedTaxes.Add(bodyOrderOrderLineItems0AppliedTaxes0);

var bodyOrderOrderLineItems0AppliedDiscounts = new List<OrderLineItemAppliedDiscount>();

var bodyOrderOrderLineItems0AppliedDiscounts0 = new OrderLineItemAppliedDiscount.Builder(
        "56ae1696-z1e3-9328-af6d-f1e04d947gd4")
    .Build();
bodyOrderOrderLineItems0AppliedDiscounts.Add(bodyOrderOrderLineItems0AppliedDiscounts0);

var bodyOrderOrderLineItems0BasePriceMoney = new Money.Builder()
    .Amount(1500L)
    .Currency("USD")
    .Build();
var bodyOrderOrderLineItems0 = new OrderLineItem.Builder(
        "2")
    .Name("Printed T Shirt")
    .AppliedTaxes(bodyOrderOrderLineItems0AppliedTaxes)
    .AppliedDiscounts(bodyOrderOrderLineItems0AppliedDiscounts)
    .BasePriceMoney(bodyOrderOrderLineItems0BasePriceMoney)
    .Build();
bodyOrderOrderLineItems.Add(bodyOrderOrderLineItems0);

var bodyOrderOrderLineItems1BasePriceMoney = new Money.Builder()
    .Amount(2500L)
    .Currency("USD")
    .Build();
var bodyOrderOrderLineItems1 = new OrderLineItem.Builder(
        "1")
    .Name("Slim Jeans")
    .BasePriceMoney(bodyOrderOrderLineItems1BasePriceMoney)
    .Build();
bodyOrderOrderLineItems.Add(bodyOrderOrderLineItems1);

var bodyOrderOrderLineItems2BasePriceMoney = new Money.Builder()
    .Amount(3500L)
    .Currency("USD")
    .Build();
var bodyOrderOrderLineItems2 = new OrderLineItem.Builder(
        "3")
    .Name("Woven Sweater")
    .BasePriceMoney(bodyOrderOrderLineItems2BasePriceMoney)
    .Build();
bodyOrderOrderLineItems.Add(bodyOrderOrderLineItems2);

var bodyOrderOrderTaxes = new List<OrderLineItemTax>();

var bodyOrderOrderTaxes0 = new OrderLineItemTax.Builder()
    .Uid("38ze1696-z1e3-5628-af6d-f1e04d947fg3")
    .Type("INCLUSIVE")
    .Percentage("7.75")
    .Scope("LINE_ITEM")
    .Build();
bodyOrderOrderTaxes.Add(bodyOrderOrderTaxes0);

var bodyOrderOrderDiscounts = new List<OrderLineItemDiscount>();

var bodyOrderOrderDiscounts0AmountMoney = new Money.Builder()
    .Amount(100L)
    .Currency("USD")
    .Build();
var bodyOrderOrderDiscounts0 = new OrderLineItemDiscount.Builder()
    .Uid("56ae1696-z1e3-9328-af6d-f1e04d947gd4")
    .Type("FIXED_AMOUNT")
    .AmountMoney(bodyOrderOrderDiscounts0AmountMoney)
    .Scope("LINE_ITEM")
    .Build();
bodyOrderOrderDiscounts.Add(bodyOrderOrderDiscounts0);

var bodyOrderOrder = new Order.Builder(
        "location_id")
    .ReferenceId("reference_id")
    .CustomerId("customer_id")
    .LineItems(bodyOrderOrderLineItems)
    .Taxes(bodyOrderOrderTaxes)
    .Discounts(bodyOrderOrderDiscounts)
    .Build();
var bodyOrder = new CreateOrderRequest.Builder()
    .Order(bodyOrderOrder)
    .IdempotencyKey("12ae1696-z1e3-4328-af6d-f1e04d947gd4")
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
    CreateCheckoutResponse result = await checkoutApi.CreateCheckoutAsync(locationId, body);
}
catch (ApiException e){};
```


# List Payment Links

Lists all payment links.

```csharp
ListPaymentLinksAsync(
    string cursor = null,
    int? limit = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this cursor to retrieve the next set of results for the original query.<br>If a cursor is not provided, the endpoint returns the first page of the results.<br>For more  information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination). |
| `limit` | `int?` | Query, Optional | A limit on the number of results to return per page. The limit is advisory and<br>the implementation might return more or less results. If the supplied limit is negative, zero, or<br>greater than the maximum limit of 1000, it is ignored.<br><br>Default value: `100` |

## Response Type

[`Task<Models.ListPaymentLinksResponse>`](../../doc/models/list-payment-links-response.md)

## Example Usage

```csharp
try
{
    ListPaymentLinksResponse result = await checkoutApi.ListPaymentLinksAsync(null, null);
}
catch (ApiException e){};
```


# Create Payment Link

Creates a Square-hosted checkout page. Applications can share the resulting payment link with their buyer to pay for goods and services.

```csharp
CreatePaymentLinkAsync(
    Models.CreatePaymentLinkRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreatePaymentLinkRequest`](../../doc/models/create-payment-link-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreatePaymentLinkResponse>`](../../doc/models/create-payment-link-response.md)

## Example Usage

```csharp
var bodyQuickPayPriceMoney = new Money.Builder()
    .Amount(10000L)
    .Currency("USD")
    .Build();
var bodyQuickPay = new QuickPay.Builder(
        "Auto Detailing",
        bodyQuickPayPriceMoney,
        "A9Y43N9ABXZBP")
    .Build();
var body = new CreatePaymentLinkRequest.Builder()
    .IdempotencyKey("cd9e25dc-d9f2-4430-aedb-61605070e95f")
    .QuickPay(bodyQuickPay)
    .Build();

try
{
    CreatePaymentLinkResponse result = await checkoutApi.CreatePaymentLinkAsync(body);
}
catch (ApiException e){};
```


# Delete Payment Link

Deletes a payment link.

```csharp
DeletePaymentLinkAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The ID of the payment link to delete. |

## Response Type

[`Task<Models.DeletePaymentLinkResponse>`](../../doc/models/delete-payment-link-response.md)

## Example Usage

```csharp
string id = "id0";

try
{
    DeletePaymentLinkResponse result = await checkoutApi.DeletePaymentLinkAsync(id);
}
catch (ApiException e){};
```


# Retrieve Payment Link

Retrieves a payment link.

```csharp
RetrievePaymentLinkAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The ID of link to retrieve. |

## Response Type

[`Task<Models.RetrievePaymentLinkResponse>`](../../doc/models/retrieve-payment-link-response.md)

## Example Usage

```csharp
string id = "id0";

try
{
    RetrievePaymentLinkResponse result = await checkoutApi.RetrievePaymentLinkAsync(id);
}
catch (ApiException e){};
```


# Update Payment Link

Updates a payment link. You can update the `payment_link` fields such as
`description`, `checkout_options`, and  `pre_populated_data`.
You cannot update other fields such as the `order_id`, `version`, `URL`, or `timestamp` field.

```csharp
UpdatePaymentLinkAsync(
    string id,
    Models.UpdatePaymentLinkRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The ID of the payment link to update. |
| `body` | [`Models.UpdatePaymentLinkRequest`](../../doc/models/update-payment-link-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdatePaymentLinkResponse>`](../../doc/models/update-payment-link-response.md)

## Example Usage

```csharp
string id = "id0";
var bodyPaymentLinkCheckoutOptions = new CheckoutOptions.Builder()
    .AskForShippingAddress(true)
    .Build();
var bodyPaymentLink = new PaymentLink.Builder(
        1)
    .CheckoutOptions(bodyPaymentLinkCheckoutOptions)
    .Build();
var body = new UpdatePaymentLinkRequest.Builder(
        bodyPaymentLink)
    .Build();

try
{
    UpdatePaymentLinkResponse result = await checkoutApi.UpdatePaymentLinkAsync(id, body);
}
catch (ApiException e){};
```

