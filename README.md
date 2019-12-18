![Square logo]

# Square .NET SDK

[![Travis status](https://travis-ci.com/square/square-dotnet-sdk.svg?branch=master)](https://travis-ci.com/square/square-dotnet-sdk)
[![NuGet](https://badge.fury.io/nu/Square.svg)](https://badge.fury.io/nu/Square)
[![Apache-2 license](https://img.shields.io/badge/license-Apache2-brightgreen.svg)](https://www.apache.org/licenses/LICENSE-2.0)

Use this library to integrate Square payments into your app and grow your business with Square APIs including Catalog, Customers, Employees, Inventory, Labor, Locations, and Orders.

## Requirements

Use of the Square .NET SDK requires:

* NET Standard 2.0 or higher

Generating DLLs from source requires:

* [RestSharp](https://www.nuget.org/packages/RestSharp) - 106.3.1 or later
* [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 11.0.2 or later


## Installation

### Install with Package Manager Console
```
Install-Package Square
```

### Install with NuGet
```
nuget install Square
```

### Install with .NET Core
```
dotnet add package Square
```

## API documentation

### Take Payments

* [Payments]
* [Checkout]

### More Square APIs

* [Catalog]
* [Customers]
* [Employees]
* [Inventory]
* [Labor]
* [Locations]
* [Merchants]
* [Orders]
* [Apple Pay]
* [Refunds]
* [Reporting]

### Authorization APIs

* [Mobile Authorization]
* [O Auth]

### Deprecated APIs

* [V1 Locations]
* [V1 Employees]
* [V1 Transactions]
* [V1 Items]
* [Transactions]

## Usage

First time using Square? Here’s how to get started:

1. **Create a Square account.** If you don’t have one already, [sign up for a developer account].
1. **Create an application.** Go to your [Developer Dashboard] and create your first application. All you need to do is give it a name. When you’re doing this for your production application, enter the name as you would want a customer to see it.
1. **Make your first API call.** Almost all Square API calls require a location ID. You’ll make your first call to `ListLocations`, which happens to be one of the API calls that don’t require a location ID. For more information about locations, see the [Locations] API documentation.

Now let’s call your first Square API.

```csharp
using System;
using Square;
using Square.Models;
using Square.Exceptions;

namespace Example
{
    public class Example
    {

        static void Main(string[] args)
        {
            SquareClient client = new SquareClient.Builder()
                .Environment(Square.Environment.Sandbox)
                .AccessToken("YOUR_SANDBOX_ACCESS_TOKEN")
                .Build();

            var api = client.LocationsApi;

            try
            {
                var locations = api.ListLocations().Locations;
                Console.WriteLine("Successfully called ListLocations");
                // Your business logic here
            }
            catch (ApiException e)
            {
                var errors = e.Errors;
                int statusCode = e.ResponseCode;
                var HttpContext = e.HttpContext;
                Console.WriteLine("ApiException occurred");
                // Your error handling code
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred");
                // Your error handling code
            }
        }
    }
}
```

Next, get an access token and reference it in your code:

1. Open the Developer Dashboard and select your application. The **Credentials** page for your app opens by default.
1. Set the dashboard mode to **Sandbox Settings** for a sandbox access token.
1. Copy the Access Token in the Credentials section of the page and replace `YOUR_SANDBOX_ACCESS_TOKEN` with the token.

**Important** When you eventually switch from trying things out on sandbox to actually working with your real production resources, you should not embed the access token in your code. Make sure you store and access your production access tokens securely.

## SDK patterns
If you know a few patterns, you’ll be able to call any API in the SDK. Here are some important ones:

### Get an access token

To use the Square API to manage the resources (such as payments, orders, customers, etc.) of a Square account, you need to create an application (or use an existing one) in the Developer Dashboard and get an access token.

When you call a Square API, you call it using an access key. An access key has specific permissions to resources in a specific Square account that can be accessed by a specific application in a specific developer account.
Use an access token that is appropriate for your use case. There are two options:

- To manage the resources for your own Square account, use the Personal Access Token for the application created in your Square account.
- To manage resources for other Square accounts, use OAuth to ask owners of the accounts you want to manage so that you can work on their behalf. When you implement OAuth, you ask the Square account holder for permission to manage resources in their account (you can define the specific resources to access) and get an OAuth access token and refresh token for their account.

**Important** For both use cases, make sure you store and access the tokens securely.

### Import and Instantiate the Client Class

To use the Square API, you import the Client class, instantiate a Client object, and initialize it with the appropriate access token. Here’s how:

- Initialize the `SquareClient` with environment set to sandbox:

```csharp
SquareClient client = new SquareClient.Builder()
    .Environment(Square.Environment.Sandbox)
    .AccessToken("YOUR_SQUARE_SANDBOX_ACCESS_TOKEN")
    .Build();
```

- To access production resources, set environment to production:

```csharp
SquareClient client = new SquareClient.Builder()
    .Environment(Square.Environment.Production)
    .AccessToken("YOUR_SQUARE_ACCESS_TOKEN")
    .Build();
```

### Get an Instance of an API object and call its methods

Each API is implemented as a class. The Client object instantiates every API class and exposes them as properties so you can easily start using any Square API. You work with an API by calling methods on an instance of an API class. Here’s how:

- Work with an API by calling the methods on the API object. For example, you would call ListCustomers to get a list of all customers in the Square account:

```csharp
ListCustomersResponse listCustomersResponse = client.CustomersApi.ListCustomers();
```

See the SDK documentation for the list of methods for each API class.

- Pass complex parameters (such as create, update, search, etc.) as a model. For example, you would pass a model containing the values used to create a new customer using create_customer:

```csharp
CustomersApi api = client.CustomersApi;

Address address = new Address.Builder()
    .AddressLine1("1455 Market St")
    .AddressLine2("San Francisco, CA 94103")
    .Build();

// Create a unique key(idempotency) for this creation operation so you don't accidentally
// create the customer multiple times if you need to retry this operation.
// For the purpose of example, we mark it as `unique_idempotency_key`
CreateCustomerRequest createCustomerRequest = new CreateCustomerRequest.Builder()
    .IdempotencyKey("unique_idempotency_key")
    .GivenName("John")
    .FamilyName("Smith")
    .Address(address)
    .Build();

// Call createCustomer method to create a new customer in this Square account
try {
    CreateCustomerResponse response = api.CreateCustomer(createCustomerRequest);
} catch (ApiException e) {
    List<Error> errors = e.errors;
    int statusCode = e.ResponseCode;
    HttpContext httpContext = e.HttpContext;

    // Your error handling code
    Console.WriteLine("ApiException when calling API");
}

```

- Use idempotency for create, update, or other calls that you want to avoid calling twice. To make an idempotent API call, you add the idempotency_key with a unique value in the Hash for the API call’s request.
- Specify a location ID for APIs such as Transactions, Orders, and Checkout that deal with payments. When a payment or order is created in Square, it is always associated with a location.

### Handle the response

If your API call suceeds, a response object that contains HttpContext that describe both the request and the response. Otherwise, it will throw `ApiException`:

```csharp
try {
    var locations = api.ListLocations().Locations;
    Console.WriteLine("Successfully called ListLocations");
    // Your business logic here
}
catch (ApiException e){
    var errors = e.Errors;
    int statusCode = e.ResponseCode;
    var HttpContext = e.HttpContext;
    Console.WriteLine("ApiException occurred");
    // Your error handling code
}
```

## Tests

First, clone the repo locally and `cd` into the directory.

```sh
git clone https://github.com/square/square-dotnet-sdk.git
cd square-dotnet-sdk
```

Before running the tests, find a sandbox token in your [Developer Dashboard] and set a `SQUARE_ACCESS_TOKEN` environment variable.

```sh
export SQUARE_ENVIRONMENT=sandbox
export SQUARE_ACCESS_TOKEN="YOUR_SANDBOX_ACCESS_TOKEN"
```

Run the tests with below command

```sh
dotnet test
```

## Learn more

The Square Platform is built on the [Square API]. Square has a number of other SDKs that enable you to securely handle credit card information on both mobile and web so that you can process payments via the Square API.

You can also use the Square API to create applications or services that work with payments, orders, inventory, etc. that have been created and managed in Square’s in-person hardware products (Square Point of Sale and Square Register).

[Square Logo]: https://docs.connect.squareup.com/images/github/github-square-logo.svg
[Developer Dashboard]: https://developer.squareup.com/apps
[Square API]: https://squareup.com/developers
[sign up for a developer account]: https://squareup.com/signup?v=developers
[Client]: doc/client.md
[Payments]: doc/payments.md
[Checkout]: doc/checkout.md
[Catalog]: doc/catalog.md
[Customers]: doc/customers.md
[Employees]: doc/employees.md
[Inventory]: doc/inventory.md
[Labor]: doc/labor.md
[Locations]: doc/locations.md
[Merchants]: doc/merchants.md
[Orders]: doc/orders.md
[Apple Pay]: doc/apple-pay.md
[Refunds]: doc/refunds.md
[Reporting]: doc/reporting.md
[Mobile Authorization]: doc/mobile-authorization.md
[O Auth]: doc/o-auth.md
[V1 Locations]: doc/v1-locations.md
[V1 Employees]: doc/v1-employees.md
[V1 Transactions]: doc/v1-transactions.md
[V1 Items]: doc/v1-items.md
[Transactions]: doc/transactions.md
