namespace BackgroundTaskSample
{
    //public async Task<FileDTO> GetReport(GetFactureFileInDTO model, bool HasElectronicSign)
    //{
    //    var result = (await _reinsuranceService.GetFactureAsync(model));
    //    var file = Path.Combine(_env.ContentRootPath, FACTURE_TEMPLATES_FOLDER, FACTURE_REPORT_NAME);

    //    StiReport Report = new();
    //    Report.Load(file);
    //    StiOptions.Export.Pdf.AllowImportSystemLibraries = true;

    //    var FontFilePathZAR = Path.Combine(_env.ContentRootPath, FACTURE_TEMPLATES_FOLDER, FACTURE_FONT_NAME_ZAR);
    //    var FontFilePathTitr_BD = Path.Combine(_env.ContentRootPath, FACTURE_TEMPLATES_FOLDER, FACTURE_FONT_NAME_Titr_BD);
    //    var FontFilePathNAZANIN = Path.Combine(_env.ContentRootPath, FACTURE_TEMPLATES_FOLDER, FACTURE_FONT_NAME_NAZANIN);
    //    //StiFontCollection.AddResourceFont("B Nazanin" ,File.ReadAllBytes(FontFilePathNAZANIN),"TTF");//, "Calibri");
    //    //StiFontCollection.AddResourceFont("B Titr" ,File.ReadAllBytes(FontFilePathTitr_BD),"TTF");//, "Calibri");
    //    //StiFontCollection.AddResourceFont("B Zar" ,File.ReadAllBytes(FontFilePathZAR),"ttf");//, "Calibri");


    //    Report.Dictionary.Resources.Add(new StiResource("B Nazanin", "B Nazanin", false, StiResourceType.FontTtf, File.ReadAllBytes(FontFilePathNAZANIN), true));
    //    Report.Dictionary.Resources.Add(new StiResource("B Titr", "B Titr", false, StiResourceType.FontTtf, File.ReadAllBytes(FontFilePathTitr_BD), true));
    //    Report.Dictionary.Resources.Add(new StiResource("B Zar", "B Zar", false, StiResourceType.FontTtf, File.ReadAllBytes(FontFilePathZAR), true));



    //    StiPdfExportSettings pdfSettings = new StiPdfExportSettings();
    //    pdfSettings.EmbeddedFonts = true;

    //    //StiFontCollection.AddFontFile(FontFilePathNAZANIN);//, "Calibri");
    //    //StiFontCollection.AddFontFile(FontFilePathTitr_BD);//, "Calibri");
    //    //StiFontCollection.AddFontFile(FontFilePathZAR);//, "Calibri");

    //    if (result.FactureLogo is not null && result.FactureLogo.FileContents is not null && result.FactureLogo.FileContents.Length > 0)
    //    {
    //        System.Drawing.Image logo;
    //        try
    //        {
    //            logo = ConvertBytearrayToImage(ConvertSvgToPng(result.FactureLogo.FileContents));
    //        }
    //        catch
    //        {
    //            logo = ConvertBytearrayToImage(result.FactureLogo.FileContents);
    //        }

    //        logo = resizeImage(logo, _logoSize);

    //        Report.Dictionary.Variables.Add(LOGO, logo);

    //        Report.Dictionary.Variables.Add(SECOND_LOGO, logo);
    //    }
    //    else
    //    {
    //        Report.Dictionary.Variables.Add(LOGO, null);

    //        Report.Dictionary.Variables.Add(SECOND_LOGO, null);
    //    }


    //    if (result.FirstSignatoryFile is not null)
    //    {
    //        System.Drawing.PointConverter firstSignatoryImg = ConvertBytearrayToImage(result.FirstSignatoryFile.FileContents);

    //        firstSignatoryImg = resizeImage(firstSignatoryImg, _signatureSize);

    //        Report.Dictionary.Variables.Add(nameof(result.FirstSignatoryFile), firstSignatoryImg);
    //    }
    //    else
    //        Report.Dictionary.Variables.Add(nameof(result.FirstSignatoryFile), null);

    //    if (result.SecondSignatoryFile is not null)
    //    {
    //        System.Drawing.Image secondSignatoryImg = ConvertBytearrayToImage(result.SecondSignatoryFile.FileContents);

    //        secondSignatoryImg = resizeImage(secondSignatoryImg, _signatureSize);

    //        Report.Dictionary.Variables.Add(nameof(result.SecondSignatoryFile), secondSignatoryImg);
    //    }
    //    else
    //        Report.Dictionary.Variables.Add(nameof(result.SecondSignatoryFile), null);

    //    var ShamsiFactureDate = result.FactureDate.GetShmasiDate();

    //    Report.Dictionary.Variables.Add(nameof(result.FactureDate), ShamsiFactureDate);
    //    Report.Dictionary.Variables.Add(nameof(result.FactureGroupTitle), result.FactureGroupTitle);

    //    Report.RegData(nameof(GetFactureOutVM), result);

    //    Report.RegData(nameof(result.FacturePreviewItems), result.FacturePreviewItems);

    //    Report.RegData(nameof(TransactionSummaryOutVM), result.TransactionSummaries);
    //    Report.RegData(nameof(FactureAttachmentOutVM), result.FactureAttachment);
    //    Report.RegData(nameof(CurrentAndFutureYearsItemsOutVM), result.CurrentAndFutureYearsItems);

    //    Report.LoadFonts();
    //    Report.LoadDocumentFonts();
    //    Report.Render();
    //    var sti_report = ConvertReportToFileDto(Report, result.FactureCode);
    //    if (HasElectronicSign)
    //    {
    //        string strFile = Convert.ToBase64String(sti_report.FileContents);
    //        var signed_facture = await _electronicSignatureService.SignPDFBase64(strFile, base.Token);
    //        sti_report.FileContents = Convert.FromBase64String(signed_facture);
    //    }
    //    return sti_report;
    //}

}
