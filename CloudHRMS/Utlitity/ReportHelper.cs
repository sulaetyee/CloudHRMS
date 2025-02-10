using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace CloudHRMS.Utlitity
{
    public static class ReportHelper
    {
        public static byte[] ExportToExcel<T>(IList<T> data, string exportFilename)
        {
            using ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(exportFilename);
            worksheet.Cells["A1"].LoadFromCollection(data, true,TableStyles.Light1);
            return package.GetAsByteArray();
        }
    }
}
