using ClosedXML.Excel;
using LR6.Interfaces;
using LR6.Models;
using Microsoft.AspNetCore.Mvc;

namespace LR6.Services
{
    public class LR9Service:ILR9Service
    {
        public async Task<int> GetInt()
        {
            return 1337;
        }

        public async Task<string> GetString()
        {
            return "Hello world!";
        }

        public async Task<FileStreamResult> GetExcel()
        {
            XLWorkbook workbook = new XLWorkbook();
            IXLWorksheet worksheet = workbook.Worksheets.Add("LR9Worksheet");
            worksheet.Cell(1, 1).SetValue("Current API version:");
            worksheet.Cell(1, 2).SetValue("3.0");
            MemoryStream ms=new MemoryStream();
            workbook.SaveAs(ms);
            ms.Position = 0;
            return new FileStreamResult(ms, "application/openxmlformats-officedocument.spreadsheetml.sheet") { FileDownloadName="LR9Result.xlsx"};
        }
    }
}
