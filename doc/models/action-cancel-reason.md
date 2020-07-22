## Action Cancel Reason

### Enumeration

`ActionCancelReason`

### Fields

| Name | Description |
|  --- | --- |
| `BUYERCANCELED` | A person canceled the `TerminalCheckout` from a Square device. |
| `SELLERCANCELED` | A client canceled the `TerminalCheckout` using the API. |
| `TIMEDOUT` | The `TerminalCheckout` timed out (see `deadline_duration` on the `TerminalCheckout`). |

