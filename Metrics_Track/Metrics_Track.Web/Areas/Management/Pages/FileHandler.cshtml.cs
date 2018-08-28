namespace Metrics_Track.Web.Areas.Management.Pages
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using NPOI.HSSF.Util;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using Services.Contracts;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class FileHandlerModel : ManagementModel
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ITransaction transaction;

        public FileHandlerModel(IHostingEnvironment hostingEnvironment, ITransaction transaction)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.transaction = transaction;
        }

        public void OnGet() => ViewData["message"] = TempData.Get<string>("inputMessage");       

        public async Task<IActionResult> OnGetDataSetAsync()
        {
            DateTime receivedDate = DateTime.Parse(TempData.Get<string>("ReceivedDate"));
            DateTime completeDate = DateTime.Parse(TempData.Get<string>("CompleteDate"));
            
            var transactions = this.transaction.AllTransactions(receivedDate, completeDate);

            if (transactions.Count() == 0)
            {
                TempData.AddErrorMessage(WebConstants.MissingRecords);
                return RedirectToPage("/Reporting");
            }

            string webRootFolder = this.hostingEnvironment.WebRootPath;

            string fileExtension = $"_{receivedDate.ToShortDateString().Replace('/', '_')}_{completeDate.ToShortDateString().Replace('/', '_')}";
            string fileName = $"Metrics_Track_Reporting{fileExtension}.xlsx";

            string url = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, fileName);

            FileInfo file = new FileInfo(Path.Combine(webRootFolder, fileName));

            var memory = new MemoryStream();

            using (var fs = new FileStream(Path.Combine(webRootFolder, fileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Extracted_on_" + 
                                    Regex.Replace(DateTime.Now.ToString(),
                                                  @"[\/\\[\]\:\|\<>\+\=\;\,\?\*]", 
                                                  string.Empty,
                                                  RegexOptions.CultureInvariant));
                
                IRow row = excelSheet.CreateRow(0);

                var headers = transactions
                                .FirstOrDefault()
                                .GetType()
                                .GetProperties()
                                .Select(p => p.Name)
                                .ToList();

                var boldFont = workbook.CreateFont();
                boldFont.Boldweight = (short)FontBoldWeight.Bold;
                boldFont.Color = HSSFColor.White.Index;

                ICellStyle boldStyle = workbook.CreateCellStyle();

                boldStyle.SetFont(boldFont);
                boldStyle.BorderBottom = BorderStyle.Medium;
                boldStyle.FillBackgroundColor = HSSFColor.LightBlue.Index;
                boldStyle.FillPattern = FillPattern.SolidForeground;

                for (int i = 0; i < headers.Count(); i++)
                {
                    var cell = row.CreateCell(i);

                    cell.SetCellValue(headers[i]);
                    cell.CellStyle = boldStyle;
                }

                int counter = 1;
                foreach (var transaction in transactions)
                {
                    row = excelSheet.CreateRow(counter);

                    row.CreateCell(0).SetCellValue(transaction.TransactionId);
                    row.CreateCell(1).SetCellValue(transaction.FunctionName);
                    row.CreateCell(2).SetCellValue(transaction.Country);
                    row.CreateCell(3).SetCellValue(transaction.TeamLead);
                    row.CreateCell(4).SetCellValue(transaction.UserName);
                    row.CreateCell(5).SetCellValue(transaction.Process);
                    row.CreateCell(6).SetCellValue(transaction.ProcessMap);
                    row.CreateCell(7).SetCellValue(transaction.Activity);
                    row.CreateCell(8).SetCellValue(transaction.Lob);
                    if (transaction.ReceivedDate != null) { row.CreateCell(9).SetCellValue((DateTime)transaction.ReceivedDate); }
                    if (transaction.StartDate != null) { row.CreateCell(10).SetCellValue((DateTime)transaction.StartDate); }
                    if (transaction.CompleteDate != null) { row.CreateCell(11).SetCellValue((DateTime)transaction.CompleteDate); }
                    row.CreateCell(12).SetCellValue(transaction.Comment);
                    row.CreateCell(13).SetCellValue(transaction.ID_Number);
                    row.CreateCell(14).SetCellValue(transaction.Status);
                    if (transaction.Premium != null) { row.CreateCell(15).SetCellValue((double)transaction.Premium); }
                    row.CreateCell(16).SetCellValue(transaction.CurrencyCode);
                    if (transaction.Priority != null) { row.CreateCell(17).SetCellValue((short)transaction.Priority); }
                    if (transaction.InceptionDate != null) { row.CreateCell(18).SetCellValue((DateTime)transaction.InceptionDate); }
                    if (transaction.DateReceivedInAig != null) { row.CreateCell(19).SetCellValue((DateTime)transaction.DateReceivedInAig); }
                    row.CreateCell(20).SetCellValue(transaction.SlaHrs);
                    row.CreateCell(21).SetCellValue(transaction.SlaTarget);
                    row.CreateCell(22).SetCellValue(transaction.SlaType);
                    row.CreateCell(23).SetCellValue(transaction.SlaAchievement);
                    row.CreateCell(24).SetCellValue(transaction.HandlingTime);
                    row.CreateCell(25).SetCellValue(transaction.Week);
                    row.CreateCell(26).SetCellValue(transaction.Month);
                    row.CreateCell(27).SetCellValue(transaction.Sandbox);

                    counter++;
                }

                workbook.Write(fs);
            }

            using (var stream = new FileStream(Path.Combine(webRootFolder, fileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}