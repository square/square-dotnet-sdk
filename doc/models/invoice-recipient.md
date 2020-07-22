## Invoice Recipient

Provides customer data that Square uses to deliver an invoice.

### Structure

`InvoiceRecipient`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CustomerId` | `string` | Optional | The ID of the customer. This is the customer profile ID that <br>you provide when creating a draft invoice. |
| `GivenName` | `string` | Optional | The recipient's given (that is, first) name. |
| `FamilyName` | `string` | Optional | The recipient's family (that is, last) name. |
| `EmailAddress` | `string` | Optional | The recipient's email address. |
| `Address` | [`Models.Address`](/doc/models/address.md) | Optional | Represents a physical address. |
| `PhoneNumber` | `string` | Optional | The recipient's phone number. |
| `CompanyName` | `string` | Optional | The name of the recipient's company. |

### Example (as JSON)

```json
{
  "customer_id": null,
  "given_name": null,
  "family_name": null,
  "email_address": null,
  "address": null,
  "phone_number": null,
  "company_name": null
}
```

