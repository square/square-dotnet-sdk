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
var bodyOrderOrderSource = new OrderSource.Builder()
    .Name("name8")
    .Build();
var bodyOrderOrderLineItems = new List<OrderLineItem>();

var bodyOrderOrderLineItems0QuantityUnitMeasurementUnit = new MeasurementUnit.Builder()
    .AreaUnit("IMPERIAL_SQUARE_YARD")
    .LengthUnit("METRIC_CENTIMETER")
    .VolumeUnit("GENERIC_SHOT")
    .WeightUnit("METRIC_MILLIGRAM")
    .Build();
var bodyOrderOrderLineItems0QuantityUnit = new OrderQuantityUnit.Builder()
    .MeasurementUnit(bodyOrderOrderLineItems0QuantityUnitMeasurementUnit)
    .Precision(191)
    .Build();
var bodyOrderOrderLineItems0AppliedTaxes = new List<OrderLineItemAppliedTax>();

var bodyOrderOrderLineItems0AppliedTaxes0AppliedMoney = new Money.Builder()
    .Amount(53L)
    .Currency("GBP")
    .Build();
var bodyOrderOrderLineItems0AppliedTaxes0 = new OrderLineItemAppliedTax.Builder(
        "38ze1696-z1e3-5628-af6d-f1e04d947fg3")
    .Uid("uid3")
    .AppliedMoney(bodyOrderOrderLineItems0AppliedTaxes0AppliedMoney)
    .Build();
bodyOrderOrderLineItems0AppliedTaxes.Add(bodyOrderOrderLineItems0AppliedTaxes0);

var bodyOrderOrderLineItems0AppliedDiscounts = new List<OrderLineItemAppliedDiscount>();

var bodyOrderOrderLineItems0AppliedDiscounts0AppliedMoney = new Money.Builder()
    .Amount(161L)
    .Currency("LSL")
    .Build();
var bodyOrderOrderLineItems0AppliedDiscounts0 = new OrderLineItemAppliedDiscount.Builder(
        "56ae1696-z1e3-9328-af6d-f1e04d947gd4")
    .Uid("uid7")
    .AppliedMoney(bodyOrderOrderLineItems0AppliedDiscounts0AppliedMoney)
    .Build();
bodyOrderOrderLineItems0AppliedDiscounts.Add(bodyOrderOrderLineItems0AppliedDiscounts0);

var bodyOrderOrderLineItems0BasePriceMoney = new Money.Builder()
    .Amount(1500L)
    .Currency("USD")
    .Build();
var bodyOrderOrderLineItems0 = new OrderLineItem.Builder(
        "2")
    .Uid("uid3")
    .Name("Printed T Shirt")
    .QuantityUnit(bodyOrderOrderLineItems0QuantityUnit)
    .Note("note1")
    .CatalogObjectId("catalog_object_id3")
    .AppliedTaxes(bodyOrderOrderLineItems0AppliedTaxes)
    .AppliedDiscounts(bodyOrderOrderLineItems0AppliedDiscounts)
    .BasePriceMoney(bodyOrderOrderLineItems0BasePriceMoney)
    .Build();
bodyOrderOrderLineItems.Add(bodyOrderOrderLineItems0);

var bodyOrderOrderLineItems1QuantityUnitMeasurementUnit = new MeasurementUnit.Builder()
    .AreaUnit("IMPERIAL_SQUARE_MILE")
    .LengthUnit("METRIC_MILLIMETER")
    .VolumeUnit("GENERIC_CUP")
    .WeightUnit("IMPERIAL_STONE")
    .Build();
var bodyOrderOrderLineItems1QuantityUnit = new OrderQuantityUnit.Builder()
    .MeasurementUnit(bodyOrderOrderLineItems1QuantityUnitMeasurementUnit)
    .Precision(192)
    .Build();
var bodyOrderOrderLineItems1BasePriceMoney = new Money.Builder()
    .Amount(2500L)
    .Currency("USD")
    .Build();
var bodyOrderOrderLineItems1 = new OrderLineItem.Builder(
        "1")
    .Uid("uid4")
    .Name("Slim Jeans")
    .QuantityUnit(bodyOrderOrderLineItems1QuantityUnit)
    .Note("note0")
    .CatalogObjectId("catalog_object_id2")
    .BasePriceMoney(bodyOrderOrderLineItems1BasePriceMoney)
    .Build();
bodyOrderOrderLineItems.Add(bodyOrderOrderLineItems1);

var bodyOrderOrderLineItems2QuantityUnitMeasurementUnit = new MeasurementUnit.Builder()
    .AreaUnit("METRIC_SQUARE_CENTIMETER")
    .LengthUnit("IMPERIAL_MILE")
    .VolumeUnit("GENERIC_PINT")
    .WeightUnit("IMPERIAL_POUND")
    .Build();
var bodyOrderOrderLineItems2QuantityUnit = new OrderQuantityUnit.Builder()
    .MeasurementUnit(bodyOrderOrderLineItems2QuantityUnitMeasurementUnit)
    .Precision(193)
    .Build();
var bodyOrderOrderLineItems2BasePriceMoney = new Money.Builder()
    .Amount(3500L)
    .Currency("USD")
    .Build();
var bodyOrderOrderLineItems2 = new OrderLineItem.Builder(
        "3")
    .Uid("uid5")
    .Name("Woven Sweater")
    .QuantityUnit(bodyOrderOrderLineItems2QuantityUnit)
    .Note("note9")
    .CatalogObjectId("catalog_object_id1")
    .BasePriceMoney(bodyOrderOrderLineItems2BasePriceMoney)
    .Build();
bodyOrderOrderLineItems.Add(bodyOrderOrderLineItems2);

var bodyOrderOrderTaxes = new List<OrderLineItemTax>();

var bodyOrderOrderTaxes0 = new OrderLineItemTax.Builder()
    .Uid("38ze1696-z1e3-5628-af6d-f1e04d947fg3")
    .CatalogObjectId("catalog_object_id7")
    .Name("name9")
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
    .CatalogObjectId("catalog_object_id1")
    .Name("name7")
    .Type("FIXED_AMOUNT")
    .Percentage("percentage5")
    .AmountMoney(bodyOrderOrderDiscounts0AmountMoney)
    .Scope("LINE_ITEM")
    .Build();
bodyOrderOrderDiscounts.Add(bodyOrderOrderDiscounts0);

var bodyOrderOrder = new Order.Builder(
        "location_id")
    .Id("id6")
    .ReferenceId("reference_id")
    .Source(bodyOrderOrderSource)
    .CustomerId("customer_id")
    .LineItems(bodyOrderOrderLineItems)
    .Taxes(bodyOrderOrderTaxes)
    .Discounts(bodyOrderOrderDiscounts)
    .Build();
var bodyOrder = new CreateOrderRequest.Builder()
    .Order(bodyOrderOrder)
    .LocationId("location_id4")
    .IdempotencyKey("12ae1696-z1e3-4328-af6d-f1e04d947gd4")
    .Build();
var bodyPrePopulateShippingAddress = new Address.Builder()
    .AddressLine1("1455 Market St.")
    .AddressLine2("Suite 600")
    .AddressLine3("address_line_36")
    .Locality("San Francisco")
    .Sublocality("sublocality0")
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

