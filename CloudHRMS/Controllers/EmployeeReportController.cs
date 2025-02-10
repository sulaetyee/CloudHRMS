using CloudHRMS.Models.ReportModels;
using CloudHRMS.Services;
using CloudHRMS.Utlitity;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers
{
    public class EmployeeReportController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeReportController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }
        public IActionResult Detail()
        {
            return View();
        }
        [HttpPost] 
        //how to see dimension for your data
        public IActionResult Detail(string fromCode, string toCode)
        {
            string fileName= $"EmployeeDetail_{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}.csv";
            var fileContextType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            IList<EmployeeDetailModel> employees = _employeeService.DetailBy(fromCode, toCode).ToList();
            if (employees.Count > 0)
            {
                var fileOutput = ReportHelper.ExportToExcel(employees, fileName);
                TempData["Msg"] = "Employee detail ereecord is successfully exported.";
                return File(fileOutput, fileContextType,  fileName);
            }
            else
            {
                TempData["Msg"] = "No record found!";
            }
            return View();
        }
        public IActionResult Summary()
        {
            return View();
        }
    }
}
