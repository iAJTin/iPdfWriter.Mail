﻿
using System;
using System.Drawing;

using iTin.Core.ComponentModel;
using iTin.Mail.Smtp.Net;
using iTin.Utilities.Pdf.Design.Image;

using iPdfWriter.Abstractions.Writer.Operations.Actions;
using iPdfWriter.Operations.Replace;
using iPdfWriter.Operations.Replace.Replacement.Text;

using iPdfWriter.Net.Mail.ConsoleApp.ComponentModel.Helpers;

namespace iPdfWriter.Net.Mail.ConsoleApp.Code;

/// <summary>
/// Shows how to send pdf output result by email with gmail.
/// </summary>
internal static class Sample01
{
    public static void Generate()
    {
        var pdfCreationResult = BuildPdfInput().CreateResult();
        if (!pdfCreationResult.Success)
        {
            return;
        }

        var sendResult = pdfCreationResult.Result.Action(new SendMail
        {
            AttachedFilename = "Sample-01",
            FromDisplayName = "",
            FromAddress = "",
            Settings = new SmtpMailSettings
            {
                Credential = new SmtpCredential
                {
                    Port = 465,
                    UseSsl = true,
                    Host = SmtpMail.GmailSmtpHost,
                    Email = "",
                    UserName = "",
                    Password = ""
                },
                Templates = new TemplateSettings
                {
                    IsBodyHtml = true,
                    BodyTemplate = "Hola",
                    SubjectTemplate = "Test > pdf file"
                },
                Recipients = new RecipientsSettings
                {
                    ToAddresses = new[] { "" }
                },
                Attachments = new[]
                {
                    "~/Resources/Sample-01/Images/bar-chart.png",
                    "~/Resources/Sample-01/Images/image-1.jpg"
                }
            }
        });

        if (!sendResult.Success)
        {
            Console.WriteLine(sendResult.Errors.AsMessages().ToStringBuilder());
        }
    }


    private static PdfInput BuildPdfInput()
    {
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

        return doc;
    }
}
