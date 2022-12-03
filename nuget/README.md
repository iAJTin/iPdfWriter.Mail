# What is iPdfWriter.Net.Mail?

**iPdfWriter.Net.Mail**, extends [iPdfWriter](https://github.com/iAJTin/iPdfWriter), contains extension methods to send by mail **PdfInput** instances as well as **OutputResult**.

I hope it helps someone. :smirk:

# Usage

## Samples

### Sample 1 - Shows the use of synchronous mail by SendMail action

``` csharp
var doc = new PdfInput
{
    AutoUpdateChanges = true,
    Input = "~/Resources/Sample-01/file-sample.pdf"
};

// report title
doc.Replace(new ReplaceText(
    new WithTextObject
    {
        Text = "#TITLE#",
        NewText = "Lorem ipsum",
        Offset = PointF.Empty,
        Style = StylesHelper.Sample01.TextStylesTable["ReportTitle"],
        ReplaceOptions = ReplaceTextOptions.AccordingToMargins
    }))
    // bar-chart image
    .Replace(new ReplaceText(
        new WithImageObject
        {
            Text = "#BAR-CHART#",
            Offset = PointF.Empty,
            Style = StylesHelper.Sample01.ImagesStylesTable["Default"],
            ReplaceOptions = ReplaceTextOptions.Default,
            Image = PdfImage.FromFile("~Resources/Sample-01/Images/bar-chart.png")
        }))
    // image
    .Replace(new ReplaceText(
        new WithImageObject
        {
            Text = "#IMAGE1#",
            Offset = PointF.Empty,
            Style = StylesHelper.Sample01.ImagesStylesTable["Center"],
            ReplaceOptions = ReplaceTextOptions.AccordingToMargins,
            Image = PdfImage.FromFile("~/Resources/Sample-01/Images/image-1.jpg")
        }));

var pdfCreationResult = doc.CreateResult();
if (!pdfCreationResult.Success)
{
    return;
}

var sendResult = pdfCreationResult.Result.Action(new SendMail
{
    FromAddress = "",
    FromDisplayName = "",
    AttachedFilename = "",
    Settings = new SmtpMailSettings
    {
        Credential = new SmtpCredential
        {
            Domain = "",
            Email = "",
            Host = "",
            Password = "",
            Port = 0,
            UserName = "",
            UseSsl = true
        },
        Templates = new TemplateSettings
        {
            BodyTemplate = "",
            IsBodyHtml = true,
            SubjectTemplate = ""
        }
    }
});

if (!sendResult.Success)
{
    // Handle error(s)
}
```             

### Sample 2 - Shows the use of asynchronous mail by SendMailAsync action

```csharp   
var doc = new PdfInput
{
    AutoUpdateChanges = true,
    Input = "~/Resources/Sample-01/file-sample.pdf"
};

// report title
doc.Replace(new ReplaceText(
    new WithTextObject
    {
        Text = "#TITLE#",
        NewText = "Lorem ipsum",
        Offset = PointF.Empty,
        Style = StylesHelper.Sample01.TextStylesTable["ReportTitle"],
        ReplaceOptions = ReplaceTextOptions.AccordingToMargins
    }))
    // bar-chart image
    .Replace(new ReplaceText(
        new WithImageObject
        {
            Text = "#BAR-CHART#",
            Offset = PointF.Empty,
            Style = StylesHelper.Sample01.ImagesStylesTable["Default"],
            ReplaceOptions = ReplaceTextOptions.Default,
            Image = PdfImage.FromFile("~Resources/Sample-01/Images/bar-chart.png")
        }))
    // image
    .Replace(new ReplaceText(
        new WithImageObject
        {
            Text = "#IMAGE1#",
            Offset = PointF.Empty,
            Style = StylesHelper.Sample01.ImagesStylesTable["Center"],
            ReplaceOptions = ReplaceTextOptions.AccordingToMargins,
            Image = PdfImage.FromFile("~/Resources/Sample-01/Images/image-1.jpg")
        }));

var pdfCreationResult = await doc.CreateResultAsync();
if (!pdfCreationResult.Success)
{
    return;
}

var sendResult = await pdfCreationResult.Result.Action(new SendMailAsync
{
    FromAddress = "",
    FromDisplayName = "",
    AttachedFilename = "",
    Settings = new SmtpMailSettings
    {
        Credential = new SmtpCredential
        {
            Domain = "",
            Email = "",
            Host = "",
            Password = "",
            Port = 0,
            UserName = "",
            UseSsl = true
        },
        Templates = new TemplateSettings
        {
            BodyTemplate = "",
            IsBodyHtml = true,
            SubjectTemplate = ""
        }
    }
});

if (!sendResult.Success)
{
    // Handle error(s)
}
```

# Documentation

 - Please see next link [documentation].

# Changes

For more information, please visit the next link [CHANGELOG](https://github.com/iAJTin/iPdfWriter.Net.Mail/blob/main/CHANGELOG.md)
