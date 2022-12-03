<p align="center">
  <img src="https://github.com/iAJTin/iPdfWriter.Net.Mail/blob/master/nuget/iPdfWriter.Net.Mail.png" height="32"/>
</p>
<p align="center">
  <a href="https://github.com/iAJTin/iPdfWriter.Net.Mail">
    <img src="https://img.shields.io/badge/iTin-iPdfWriter.Net.Mail-green.svg?style=flat"/>
  </a>
</p>

***

# What is iPdfWriter.Net.Mail?

**iPdfWriter.Net.Mail**, extends [iPdfWriter](https://github.com/iAJTin/iPdfWriter), contains extension methods to send by mail **PdfInput** instances as well as **OutputResult**.

I hope it helps someone. :smirk:

# Install via NuGet

- From nuget gallery

<table>
  <tr>
    <td>
      <a href="https://github.com/iAJTin/iPdfWriter.Net.Mail">
        <img src="https://img.shields.io/badge/-iPdfWriter.Net.Mail-green.svg?style=flat"/>
      </a>
    </td>
    <td>
      <a href="https://www.nuget.org/packages/iPdfWriter.Net.Mail/">
        <img alt="NuGet Version" 
             src="https://img.shields.io/nuget/v/iPdfWriter.Net.Mail.svg" /> 
      </a>
    </td>  
  </tr>
</table>

- From package manager console

```PM> Install-Package iPdfWriter.Net.Mail```

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

# How can I send feedback!!!

If you have found **iPdfWriter.Net.Mail** useful at work or in a personal project, I would love to hear about it. If you have decided not to use **iPdfWriter.Net.Mail**, please send me and email stating why this is so. I will use this feedback to improve **iPdfWriter.Net.Mail** in future releases.

My email address is 

![email.png][email] 


[email]: ./assets/email.png "email"
[documentation]: ./documentation/iPdfWriter.Net.Mail.md
