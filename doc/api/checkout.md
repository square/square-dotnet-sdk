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
We recommend that you use the new [CreatePaymentLink](api-endpoint:Checkout-CreatePaymentLink) 
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
Models.CreateCheckoutRequest body = new Models.CreateCheckoutRequest.Builder(
    "86ae1696-b1e3-4328-af6d-f1e04d947ad6",
    new Models.CreateOrderRequest.Builder()
    .Order(
        new Models.Order.Builder(
            "location_id"
        )
        .ReferenceId("reference_id")
        .CustomerId("customer_id")
        .LineItems(
            new List<Models.OrderLineItem>
            {
                new Models.OrderLineItem.Builder(
                    "2"
                )
                .Name("Printed T Shirt")
                .AppliedTaxes(
                    new List<Models.OrderLineItemAppliedTax>
                    {
                        new Models.OrderLineItemAppliedTax.Builder(
                            "38ze1696-z1e3-5628-af6d-f1e04d947fg3"
                        )
                        .Build(),
                    })
                .AppliedDiscounts(
                    new List<Models.OrderLineItemAppliedDiscount>
                    {
                        new Models.OrderLineItemAppliedDiscount.Builder(
                            "56ae1696-z1e3-9328-af6d-f1e04d947gd4"
                        )
                        .Build(),
                    })
                .BasePriceMoney(
                    new Models.Money.Builder()
                    .Build())
                .Build(),
                new Models.OrderLineItem.Builder(
                    "1"
                )
                .Name("Slim Jeans")
                .BasePriceMoney(
                    new Models.Money.Builder()
                    .Build())
                .Build(),
                new Models.OrderLineItem.Builder(
                    "3"
                )
                .Name("Woven Sweater")
                .BasePriceMoney(
                    new Models.Money.Builder()
                    .Build())
                .Build(),
            })
        .Taxes(
            new List<Models.OrderLineItemTax>
            {
                new Models.OrderLineItemTax.Builder()
                .Uid("38ze1696-z1e3-5628-af6d-f1e04d947fg3")
                .Type("INCLUSIVE")
                .Percentage("7.75")
                .Scope("LINE_ITEM")
                .Build(),
            })
        .Discounts(
            new List<Models.OrderLineItemDiscount>
            {
                new Models.OrderLineItemDiscount.Builder()
                .Uid("56ae1696-z1e3-9328-af6d-f1e04d947gd4")
                .Type("FIXED_AMOUNT")
                .AmountMoney(
                    new Models.Money.Builder()
                    .Build())
                .Scope("LINE_ITEM")
                .Build(),
            })
        .Build())
    .IdempotencyKey("12ae1696-z1e3-4328-af6d-f1e04d947gd4")
    .Build()
)
.AskForShippingAddress(true)
.MerchantSupportEmail("merchant+support@website.com")
.PrePopulateBuyerEmail("example@email.com")
.PrePopulateShippingAddress(
    new Models.Address.Builder()
    .AddressLine1("1455 Market St.")
    .AddressLine2("Suite 600")
    .Locality("San Francisco")
    .AdministrativeDistrictLevel1("CA")
    .PostalCode("94103")
    .Country("US")
    .FirstName("Jane")
    .LastName("Doe")
    .Build())
.RedirectUrl("https://merchant.website.com/order-confirm")
.AdditionalRecipients(
    new List<Models.ChargeRequestAdditionalRecipient>
    {
        new Models.ChargeRequestAdditionalRecipient.Builder(
            "057P5VYJ4A5X1",
            "Application fees",
            new Models.Money.Builder()
            .Amount(60L)
            .Currency("USD")
            .Build()
        )
        .Build(),
    })
.Build();

try
{
    CreateCheckoutResponse result = await checkoutApi.CreateCheckoutAsync(locationId, body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
Models.CreatePaymentLinkRequest body = new Models.CreatePaymentLinkRequest.Builder()
.IdempotencyKey("cd9e25dc-d9f2-4430-aedb-61605070e95f")
.QuickPay(
    new Models.QuickPay.Builder(
        "Auto Detailing",
        new Models.Money.Builder()
        .Amount(10000L)
        .Currency("USD")
        .Build(),
        "A9Y43N9ABXZBP"
    )
    .Build())
.Build();

try
{
    CreatePaymentLinkResponse result = await checkoutApi.CreatePaymentLinkAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
Models.UpdatePaymentLinkRequest body = new Models.UpdatePaymentLinkRequest.Builder(
    new Models.PaymentLink.Builder(
        1
    )
    .CheckoutOptions(
        new Models.CheckoutOptions.Builder()
        .AskForShippingAddress(true)
        .Build())
    .Build()
)
.Build();

try
{
    UpdatePaymentLinkResponse result = await checkoutApi.UpdatePaymentLinkAsync(id, body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

