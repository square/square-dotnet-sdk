## V1 Settlement Entry Type

### Enumeration

`V1SettlementEntryType`

### Fields

| Name | Description |
|  --- | --- |
| `ADJUSTMENT` | A manual adjustment applied to the merchant's account by Square |
| `BALANCECHARGE` | A payment from an existing Square balance, such as a gift card |
| `CHARGE` | A credit card payment CAPTURE |
| `FREEPROCESSING` | Square offers Free Payments Processing for a variety of business scenarios including seller referral or when we want to apologize for a bug, customer service, repricing complication, etc. This entry represents a credit to the merchant for the purposes of Free Processing. |
| `HOLDADJUSTMENT` | An adjustment made by Square related to holding/releasing a payment |
| `PAIDSERVICEFEE` | a fee paid to a 3rd party merchant |
| `PAIDSERVICEFEEREFUND` | a refund for a 3rd party merchant fee |
| `REDEMPTIONCODE` | Repayment for a redemption code |
| `REFUND` | A refund for an existing card payment |
| `RETURNEDPAYOUT` | An entry created when we receive a response for the ACH file we sent indicating that the settlement of the original entry failed. |
| `SQUARECAPITALADVANCE` | Initial deposit to a merchant for a Capital merchant cash advance (MCA). |
| `SQUARECAPITALPAYMENT` | Capital merchant cash advance (MCA) assessment. These are, generally, proportional to the merchant's sales but may be issued for other reasons related to the MCA. |
| `SQUARECAPITALREVERSEDPAYMENT` | Capital merchant cash advance (MCA) assessment refund. These are, generally, proportional to the merchant's refunds but may be issued for other reasons related to the MCA. |
| `SUBSCRIPTIONFEE` | Fee charged for subscription to a Square product |
| `SUBSCRIPTIONFEEREFUND` | Refund of a previously charged Square product subscription fee. |
| `OTHER` |  |
| `INCENTEDPAYMENT` | A payment in which Square covers part of the funds for a purchase |
| `RETURNEDACHENTRY` | A settlement failed to be processed and the settlement amount has been returned to the account |
| `RETURNEDSQUARE275` | Refund for cancelling a Square Plus subscription |
| `SQUARE275` | Fee charged for a Square Plus subscription ($275) |
| `SQUARECARD` | Settlements to or withdrawals from the Square Card (an asset) |

