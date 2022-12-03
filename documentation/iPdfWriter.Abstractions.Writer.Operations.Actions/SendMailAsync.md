# SendMailAsync class

Specialization of IOutputAction interface that send the file by email.

```csharp
public class SendMailAsync : IOutputActionAsync
```

## Public Members

| name | description |
| --- | --- |
| [SendMailAsync](SendMailAsync/SendMailAsync.md)() | The default constructor. |
| [AttachedFilename](SendMailAsync/AttachedFilename.md) { get; set; } | Gets or sets the attached filename. |
| [FromAddress](SendMailAsync/FromAddress.md) { get; set; } | Gets or sets the email settings |
| [FromDisplayName](SendMailAsync/FromDisplayName.md) { get; set; } | Gets or sets the display name for [`FromAddress`](./SendMailAsync/FromAddress.md) email address. |
| [Settings](SendMailAsync/Settings.md) { get; set; } | Gets or sets the email settings |
| [ExecuteAsync](SendMailAsync/ExecuteAsync.md)(…) | Execute action for specified output result data. |

## See Also

* namespace [iPdfWriter.Abstractions.Writer.Operations.Actions](../iPdfWriter.Net.Mail.md)

<!-- DO NOT EDIT: generated by xmldocmd for iPdfWriter.Net.Mail.dll -->