using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace PostalTest
//{
//    public abstract class BaseReportGenerator
//    {
//        protected readonly IWebHostEnvironment _env;
//        protected readonly bool HasElectronicSign;
//        protected readonly Size _logoSize;
//        protected readonly Size _signatureSize;
//        protected readonly IElectronicSignatureService _electronicSignatureService;

//        protected const string FACTURE_TEMPLATES_FOLDER = "Templates";
//        protected const string FACTURE_FONT_NAME_NAZANIN = "bnazanin.ttf";
//        protected const string FACTURE_FONT_NAME_Titr_BD = "BTitr.ttf";
//        protected const string FACTURE_FONT_NAME_ZAR = "BZar.ttf";
//        protected const string LOGO = "Logo";
//        protected const string SECOND_LOGO = "SecondLogo";

//        public BaseReportGenerator(IWebHostEnvironment env,
//                                  IElectronicSignatureService electronicSignatureService,
//                                  bool hasElectronicSign = false,
//                                  Size? logoSize = null,
//                                  Size? signatureSize = null)
//        {
//            _env = env;
//            _electronicSignatureService = electronicSignatureService;
//            HasElectronicSign = hasElectronicSign;
//            _logoSize = logoSize ?? new Size(200, 100);
//            _signatureSize = signatureSize ?? new Size(100, 50);
//        }

//        // تابع اصلی که الگوی Template Method را پیاده‌سازی می‌کند  
//        public async Task<FileOutputResultDTO> GenerateReportAsync<T>(T model, string reportCode = null)
//        {
//            // 1. بارگذاری قالب گزارش  
//            StiReport Report = new();
//            LoadReportTemplate(Report);

//            // 2. تنظیم فونت‌ها  
//            ConfigureFonts(Report);

//            // 3. تنظیم لوگو و تصاویر  
//            await ConfigureImagesAsync(Report, model);

//            // 4. تنظیم متغیرها و داده‌های خاص گزارش  
//            ConfigureReportData(Report, model);

//            // 5. رندر کردن گزارش  
//            Report.LoadFonts();
//            Report.LoadDocumentFonts();
//            Report.Render();

//            // 6. تبدیل گزارش به فایل  
//            var reportFile = ConvertReportToFileDto(Report, reportCode);

//            // 7. امضای الکترونیکی (اگر نیاز باشد)  
//            if (HasElectronicSign)
//            {
//                string strFile = Convert.ToBase64String(reportFile.FileContents);
//                var signedReport = await _electronicSignatureService.SignPDFBase64(strFile, GetToken());
//                reportFile.FileContents = Convert.FromBase64String(signedReport);
//            }

//            return reportFile;
//        }

//        // متدهای انتزاعی که باید در زیر کلاس‌ها پیاده‌سازی شوند  
//        protected abstract void LoadReportTemplate(StiReport report);
//        protected abstract Task ConfigureImagesAsync<T>(StiReport report, T model);
//        protected abstract void ConfigureReportData<T>(StiReport report, T model);

//        // متدهای عمومی که در کلاس پایه پیاده‌سازی می‌شوند  
//        protected virtual void ConfigureFonts(StiReport report)
//        {
//            StiOptions.Export.Pdf.AllowImportSystemLibraries = true;
//            StiPdfExportSettings pdfSettings = new StiPdfExportSettings();
//            pdfSettings.EmbeddedFonts = true;

//            var FontFilePathTitr_BD = Path.Combine(_env.ContentRootPath, FACTURE_TEMPLATES_FOLDER, FACTURE_FONT_NAME_Titr_BD);
//            var FontFilePathNAZANIN = Path.Combine(_env.ContentRootPath, FACTURE_TEMPLATES_FOLDER, FACTURE_FONT_NAME_NAZANIN);
//            var FontFilePathZAR = Path.Combine(_env.ContentRootPath, FACTURE_TEMPLATES_FOLDER, FACTURE_FONT_NAME_ZAR);

//            report.Dictionary.Resources.Add(new StiResource("B Nazanin", "B Nazanin", false, StiResourceType.FontTtf, File.ReadAllBytes(FontFilePathNAZANIN), true));
//            report.Dictionary.Resources.Add(new StiResource("B Titr", "B Titr", false, StiResourceType.FontTtf, File.ReadAllBytes(FontFilePathTitr_BD), true));
//            report.Dictionary.Resources.Add(new StiResource("B Zar", "B Zar", false, StiResourceType.FontTtf, File.ReadAllBytes(FontFilePathZAR), true));
//        }

//        protected FileOutputResultDTO ConvertReportToFileDto(StiReport report, string reportCode)
//        {
//            // پیاده‌سازی تبدیل گزارش به FileOutputResultDTO  
//            // این بخش باید بر اساس پیاده‌سازی شما تکمیل شود  
//            return new FileOutputResultDTO
//            {
//                FileContents = report.ExportDocument(StiExportFormat.Pdf),
//                FileName = $"{reportCode ?? "Report"}.pdf",
//                ContentType = "application/pdf"
//            };
//        }

//        protected System.Drawing.Image ConvertBytearrayToImage(byte[] byteArray)
//        {
//            using (var ms = new MemoryStream(byteArray))
//            {
//                return System.Drawing.Image.FromStream(ms);
//            }
//        }

//        protected System.Drawing.Image resizeImage(System.Drawing.Image img, Size size)
//        {
//            return new Bitmap(img, size);
//        }

//        protected byte[] ConvertSvgToPng(byte[] svgData)
//        {
//            // پیاده‌سازی تبدیل SVG به PNG  
//            // این بخش باید بر اساس پیاده‌سازی شما تکمیل شود  
//            return svgData; // این خط باید با پیاده‌سازی واقعی جایگزین شود  
//        }

//        protected virtual string GetToken()
//        {
//            // پیاده‌سازی دریافت توکن  
//            return string.Empty;
//        }
//    }

//    public class AgencyProfileReportGenerator : BaseReportGenerator
//    {
//        private readonly IReinsuranceService _reinsuranceService;
//        private const string FACTURE_REPORT_NAME = "AgencyProfileReport.mrt";

//        public AgencyProfileReportGenerator(
//            IWebHostEnvironment env,
//            IElectronicSignatureService electronicSignatureService,
//            IReinsuranceService reinsuranceService,
//            bool hasElectronicSign = false,
//            Size? logoSize = null,
//            Size? signatureSize = null)
//            : base(env, electronicSignatureService, hasElectronicSign, logoSize, signatureSize)
//        {
//            _reinsuranceService = reinsuranceService;
//        }

//        public async Task<FileOutputResultDTO> GenrerateAgencyProfilePDFAsync(object model)
//        {
//            var result = (await _reinsuranceService.GetFactureAsync(model));
//            return await GenerateReportAsync(result, result.FactureCode);
//        }

//        protected override void LoadReportTemplate(StiReport report)
//        {
//            var file = Path.Combine(_env.ContentRootPath, FACTURE_TEMPLATES_FOLDER, FACTURE_REPORT_NAME);
//            report.Load(file);
//        }

//        protected override async Task ConfigureImagesAsync<T>(StiReport report, T model)
//        {
//            var result = model as GetFactureOutVM; // یا هر نوع داده‌ای که استفاده می‌کنید  
//            if (result == null) return;

//            // تنظیم لوگو  
//            if (result.FactureLogo is not null && result.FactureLogo.FileContents is not null && result.FactureLogo.FileContents.Length > 0)
//            {
//                System.Drawing.Image logo;
//                try
//                {
//                    logo = ConvertBytearrayToImage(ConvertSvgToPng(result.FactureLogo.FileContents));
//                }
//                catch
//                {
//                    logo = ConvertBytearrayToImage(result.FactureLogo.FileContents);
//                }

//                logo = resizeImage(logo, _logoSize);

//                report.Dictionary.Variables.Add(LOGO, logo);
//                report.Dictionary.Variables.Add(SECOND_LOGO, logo);
//            }
//            else
//            {
//                report.Dictionary.Variables.Add(LOGO, null);
//                report.Dictionary.Variables.Add(SECOND_LOGO, null);
//            }

//            // تنظیم امضاها  
//            if (result.FirstSignatoryFile is not null)
//            {
//                System.Drawing.Image firstSignatoryImg = ConvertBytearrayToImage(result.FirstSignatoryFile.FileContents);
//                firstSignatoryImg = resizeImage(firstSignatoryImg, _signatureSize);
//                report.Dictionary.Variables.Add(nameof(result.FirstSignatoryFile), firstSignatoryImg);
//            }
//            else
//                report.Dictionary.Variables.Add(nameof(result.FirstSignatoryFile), null);

//            if (result.SecondSignatoryFile is not null)
//            {
//                System.Drawing.Image secondSignatoryImg = ConvertBytearrayToImage(result.SecondSignatoryFile.FileContents);
//                secondSignatoryImg = resizeImage(secondSignatoryImg, _signatureSize);
//                report.Dictionary.Variables.Add(nameof(result.SecondSignatoryFile), secondSignatoryImg);
//            }
//            else
//                report.Dictionary.Variables.Add(nameof(result.SecondSignatoryFile), null);
//        }

//        protected override void ConfigureReportData<T>(StiReport report, T model)
//        {
//            var result = model as GetFactureOutVM; // یا هر نوع داده‌ای که استفاده می‌کنید  
//            if (result == null) return;

//            var ShamsiFactureDate = result.FactureDate.GetShmasiDate();

//            report.Dictionary.Variables.Add(nameof(result.FactureDate), ShamsiFactureDate);
//            report.Dictionary.Variables.Add(nameof(result.FactureGroupTitle), result.FactureGroupTitle);

//            report.RegData(nameof(GetFactureOutVM), result);
//            report.RegData(nameof(result.FacturePreviewItems), result.FacturePreviewItems);
//            report.RegData(nameof(TransactionSummaryOutVM), result.TransactionSummaries);
//            report.RegData(nameof(FactureAttachmentOutVM), result.FactureAttachment);
//            report.RegData(nameof(CurrentAndFutureYearsItemsOutVM), result.CurrentAndFutureYearsItems);
//        }

//        protected override string GetToken()
//        {
//            // پیاده‌سازی دریافت توکن خاص برای این گزارش  
//            return base.GetToken();
//        }
//    }
//}
