namespace Metrics_Track.Areas.Management.Pages
{
    using Metrics_Track.Infrastructure.Extensions;
    using Metrics_Track.Services.Models.Transaction;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class FileHandlerModel : ManagementModel
    {
        private IHostingEnvironment hostingEnvironment;

        public FileHandlerModel(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        public void OnGet()
        {
            ViewData["message"] =  @TempData.Get<string>("inputMessage");
        }

        public async Task<IActionResult> OnGetDataSetAsync()
        {
            var transactions = TempData.Get<ICollection<AllTransactionsListModel>>("filtered");

            if (transactions == null)
            {
                return RedirectToPage("/Reporting");
            }

            string sWebRootFolder = hostingEnvironment.WebRootPath;

            string sFileExtension = TempData.Get<string>("fileName");
            string sFileName = $"Metrics_Track_Reporting{sFileExtension}.xlsx";

            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);

            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));

            var memory = new MemoryStream();

            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Extracted_on_" + 
                                    Regex.Replace(DateTime.Now.ToString(),
                                                  @"[\/\\[\]\:\|\<>\+\=\;\,\?\*]", 
                                                  "_",
                                                  RegexOptions.CultureInvariant));
                IRow row = excelSheet.CreateRow(0);

                var headers = transactions
                                .FirstOrDefault()
                                .GetType()
                                .GetProperties()
                                .Select(p => p.Name)
                                .ToList();

                for (int i = 0; i < headers.Count(); i++)
                {
                    row.CreateCell(i).SetCellValue(headers[i]);
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
                    if (transaction.ReceivedDate != null) { row.CreateCell(9).SetCellValue((DateTime)transaction.ReceivedDate); };
                    if (transaction.StartDate != null) { row.CreateCell(10).SetCellValue((DateTime)transaction.StartDate); };
                    if (transaction.CompleteDate != null) { row.CreateCell(11).SetCellValue((DateTime)transaction.CompleteDate); };
                    row.CreateCell(12).SetCellValue(transaction.Comment);
                    row.CreateCell(13).SetCellValue(transaction.ID_Number);
                    row.CreateCell(14).SetCellValue(transaction.Status);
                    if (transaction.Premium != null) { row.CreateCell(15).SetCellValue((double)transaction.Premium); };
                    row.CreateCell(16).SetCellValue(transaction.CurrencyCode);
                    if (transaction.Priority != null) { row.CreateCell(17).SetCellValue((short)transaction.Priority); };
                    if (transaction.InceptionDate != null) { row.CreateCell(18).SetCellValue((DateTime)transaction.InceptionDate); };
                    if (transaction.DateReceivedInAig != null) { row.CreateCell(19).SetCellValue((DateTime)transaction.DateReceivedInAig); };
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

            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }
    }
}