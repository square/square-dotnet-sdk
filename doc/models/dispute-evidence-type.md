## Dispute Evidence Type

Type of the dispute evidence.

### Enumeration

`DisputeEvidenceType`

### Fields

| Name | Description |
|  --- | --- |
| `GENERICEVIDENCE` | Square assumes this evidence type if you don't provide a type when uploading evidence.<br><br>Use when uploading evidence as: file or string |
| `ONLINEORAPPACCESSLOG` | Server or activity logs that show proof of the cardholder’s identity and that the cardholder successfully ordered and received the goods (digitally or otherwise).<br>Example evidence: IP addresses, corresponding timestamps/dates, cardholder’s name/email address linked to a cardholder profile held by Merchant, proof the same device and card (used in dispute) were previously used in prior undisputed transaction, any related detailed activity.<br><br>Use when uploading evidence as: file or string |
| `AUTHORIZATIONDOCUMENTATION` | Evidence that the cardholder did provide authorization of the charge.<br>Example evidence: a signed credit card authorization.<br><br>Use when uploading evidence as: file |
| `CANCELLATIONORREFUNDDOCUMENTATION` | Evidence that the cardholder acknowledged your refund or cancellation policy.<br>Example evidence: a signature or checkbox showing the cardholder’s acknowledgement of your refund or cancellation policy.<br><br>Use when uploading evidence as: file or string |
| `CARDHOLDERCOMMUNICATION` | Evidence that shows relevant communication with the cardholder.<br>Example evidence: emails or texts that show the cardholder received goods/services or demonstrate cardholder satisfaction.<br><br>Use when uploading evidence as: file |
| `CARDHOLDERINFORMATION` | Evidence that validates customer identity.<br>Example evidence: personally identifiable details such as name, email address, purchaser IP address, copy of cardholder ID.<br><br>Use when uploading evidence as: file or string |
| `PURCHASEACKNOWLEDGEMENT` | Evidence that shows proof of the sale/transaction.<br>Example evidence: an invoice, contract, etc. showing the customer’s acknowledgement of the purchase and your terms.<br><br>Use when uploading evidence as: file or string |
| `DUPLICATECHARGEDOCUMENTATION` | Evidence that shows the charge(s) in question are valid and distinct from one another.<br>Example evidence: receipts, shipping labels, and invoices along with their distinct payment IDs.<br><br>Use when uploading evidence as: file |
| `PRODUCTORSERVICEDESCRIPTION` | A description of the product or service sold.<br><br>Use when uploading evidence as: file or string |
| `RECEIPT` | A receipt or message sent to the cardholder detailing the charge.<br>Note: You don’t need to upload the Square receipt; Square submits the receipt on your behalf.<br><br>Use when uploading evidence as: file or string |
| `SERVICERECEIVEDDOCUMENTATION` | Evidence that the service was provided to the cardholder or the expected date that services will be rendered.<br>Example evidence: signed delivery form, work order, expected delivery date, or other written agreement.<br><br>Use when uploading evidence as: file or string |
| `PROOFOFDELIVERYDOCUMENTATION` | Evidence that shows the product was provided to the cardholder or the expected date of delivery.<br>Example evidence: signed delivery form, or written agreement acknowledging receipt of goods or services.<br><br>Use when uploading evidence as: file or string |
| `RELATEDTRANSACTIONDOCUMENTATION` | Evidence that shows the cardholder previously processed transactions on the same card and did not dispute them.<br>Note: Square will automatically provide up to 5 distinct Square receipts for related transactions, when available.<br><br>Use when uploading evidence as: file or string |
| `REBUTTALEXPLANATION` | An explanation of why the cardholder’s claim is invalid.<br>Example evidence: explanation of why each distinct charge is a legitimate purchase why the cardholder’s claim for credit owed due to their attempt to cancel, return,<br>or refund is invalid per your stated policy and cardholder agreement,<br>or an explanation of how the cardholder did not attempt to remedy the issue with you first in order to receive credit.<br><br>Use when uploading evidence as: file or string |
| `TRACKINGNUMBER` | The tracking number for the order provided by the shipping carrier. If you have multiple numbers, they will need to be submitted individually as separate pieces of evidence.<br><br>Use when uploading evidence as: string |

