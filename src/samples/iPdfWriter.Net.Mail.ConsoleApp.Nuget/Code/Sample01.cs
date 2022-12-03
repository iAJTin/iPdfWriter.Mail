﻿
using System.Drawing;

using iTin.Mail.Smtp.Net;

using iTin.Utilities.Pdf.Design.Image;

using iPdfWriter.Abstractions.Writer.Operations.Actions;
using iPdfWriter.Operations.Replace;
using iPdfWriter.Operations.Replace.Replacement.Text;

namespace iPdfWriter.Net.Mail.ConsoleApp.Code
{
    using ComponentModel.Helpers;

    /// <summary>
    /// Shows the use of text and image replacement in a pdf document.
    /// </summary>
    internal static class Sample01
    {
        public static void Generate()
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

            var result = doc.CreateResult();
            if (!result.Success)
            {
                return;
            }

            var sendResult = result.Result.Action(new SendMail
            {
                FromAddress = "",
                FromDisplayName = "",
                AttachedFilename = "",
                Settings = new SmtpMailSettings
                {
                    Attachments = new[]
                    {
                        ""
                    },
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
                    Recipients = new RecipientsSettings
                    {
                        CCAddresses = new[] { "" },
                        ToAddresses = new[] { "" }
                    },
                    Templates = new TemplateSettings
                    {
                        BodyTemplate = "",
                        IsBodyHtml = true,
                        SubjectTemplate = ""
                    }
                }
            });
        }
    }
}