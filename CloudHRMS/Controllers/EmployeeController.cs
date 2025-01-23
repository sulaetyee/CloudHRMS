using CloudHRMS.DAO;
using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.Utility;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HRMSDBContext _hRMSDBContext;
        public EmployeeController(HRMSDBContext hRMSDBContext)
        {
            _hRMSDBContext = hRMSDBContext;
        }
        public IActionResult List()
        {
            return View();
        }

        public IActionResult Entry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(EmployeeViewModel employeeViewModel)
        {
            //DTO => data transfer object process in here
            try
            {
                var employeeEntity = new EmployeeEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = employeeViewModel.Code,
                    Name = employeeViewModel.Name,
                    Email = employeeViewModel.Email,
                    Gender = employeeViewModel.Gender,
                    DOB = employeeViewModel.DOB,
                    DOE = employeeViewModel.DOE,
                    DOR = employeeViewModel.DOR,
                    BasicSalary = employeeViewModel.BasicSalary,
                    Phone = employeeViewModel.Phone,
                    Address = employeeViewModel.Address,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    IsActive = true,
                    Ip = NetworkHelper.GetIpAddress()

                };
                _hRMSDBContext.Employees.Add(employeeEntity);//collect the entity to the context
                _hRMSDBContext.SaveChanges();//actually save the data to the database
                ViewBag.Msg = "Employee record is created successfully.";
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "Error occurs when Employee record is created."; //show theStatus message in English only(we don't support multi language)
                
            }
            return View();
        }
    }
}
