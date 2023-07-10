using Microsoft.AspNetCore.Mvc;
using DevExpress.Spreadsheet;
using DevExpress.XtraRichEdit;
using DevExpress.XtraSpreadsheet.Export;

namespace DocumentConversionWebApi.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ConvertFileController : ControllerBase {
        [HttpPost]
        public async Task<IActionResult> PostConvertFile(IFormFile file) {
            if (file != null) {
                try {
                    using (var stream = new MemoryStream()) {
                        await file.CopyToAsync(stream);
                        stream.Seek(0, SeekOrigin.Begin);
                        switch (Path.GetExtension(file.FileName)) {
                            case ".rtf":
                            case ".doc":
                            case ".docx":
                            case ".txt":
                            case ".mht":
                            case ".odt":
                            case ".xml":
                            case ".epub":
                            case ".html":
                                return new FileStreamResult(ConvertWordDocument(stream), "text/html");
                            case ".xlsx":
                            case ".xlsm":
                            case ".xlsb":
                            case ".xls":
                            case ".xltx":
                            case ".xltm":
                            case ".xlt":
                            case ".csv":
                                return new FileStreamResult(ConvertSpreadsheetDocument(stream), "text/html");
                        }
                    }
                } catch (Exception e) {
                    return StatusCode(500, e.Message + Environment.NewLine + e.StackTrace);
                }
            }
            return new BadRequestResult();
        }

        Stream ConvertWordDocument(Stream inputStream) {
            using (var wordProcessor = new RichEditDocumentServer()) {
                wordProcessor.LoadDocument(inputStream);
                var resultStream = new MemoryStream();
                wordProcessor.Options.Export.Html.EmbedImages = true;
                wordProcessor.SaveDocument(resultStream, DevExpress.XtraRichEdit.DocumentFormat.Html);
                resultStream.Seek(0, SeekOrigin.Begin);
                return resultStream;
            }
        }
        Stream ConvertSpreadsheetDocument(Stream inputStream) {
            using (var workbook = new Workbook()) {
                workbook.LoadDocument(inputStream);
                var resultStream = new MemoryStream();
                var options = new HtmlDocumentExporterOptions();
                options.EmbedImages = true;
                options.AnchorImagesToPage = true;
                workbook.ExportToHtml(resultStream, options);
                resultStream.Seek(0, SeekOrigin.Begin);
                return resultStream;
            }
        }
    }
}