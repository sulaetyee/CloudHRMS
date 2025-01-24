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
            //Retriving data from the database and covert it to the viewmodel
            IList<EmployeeViewModel> employees = _hRMSDBContext.Employees.Where(w => w.IsActive == true).Select( //get the data from the database, retrive only essential attributes and convert it to the viewmodel
                                                                                                        s => new EmployeeViewModel()
                                                                                                        {
                                                                                                            Id = s.Id,
                                                                                                            Code = s.Code,
                                                                                                            Name = s.Name,
                                                                                                            Email = s.Email,
                                                                                                            Gender = s.Gender,
                                                                                                            DOB = s.DOB,
                                                                                                            DOE = s.DOE,
                                                                                                            DOR = s.DOR,
                                                                                                            BasicSalary = s.BasicSalary,
                                                                                                            Phone = s.Phone,
                                                                                                            Address = s.Address,
                                                                                                            DepartmentId = s.DepartmentId,
                                                                                                            PositionId = s.PositionId
                                                                                                        }
                ).ToList();
            return View(employees);
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
                    DepartmentId = employeeViewModel.DepartmentId,
                    PositionId = employeeViewModel.PositionId,
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

        public IActionResult DeleteById(string id)
        {
            try
            {
                EmployeeEntity employee = _hRMSDBContext.Employees.Where(w => w.IsActive == true && w.Id == id).SingleOrDefault();
                if (employee is not null)
                {
                    employee.IsActive = false;
                    _hRMSDBContext.Employees.Update(employee);
                    _hRMSDBContext.SaveChanges();
                    TempData["Msg"] = "Employee record is deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Error occurs when Employee record is deleted.";
            }
            return RedirectToAction("List");
        }
        public IActionResult Edit(string id)
        {

            EmployeeViewModel employee = _hRMSDBContext.Employees.Where(w => w.IsActive && w.Id == id).Select(s => new EmployeeViewModel()
            {
                Id = s.Id,
                Name = s.Name,
                Gender = s.Gender,
                Email = s.Email,
                Address = s.Address,
                BasicSalary = s.BasicSalary,
                Code = s.Code,
                DOB = s.DOB,
                DOE = s.DOE,
                DOR = s.DOR,
                Phone = s.Phone,
                DepartmentId = s.DepartmentId,
                PositionId = s.PositionId
            }).SingleOrDefault();

            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(EmployeeViewModel employeeViewModel)
        {
            try
            {
                EmployeeEntity employee = _hRMSDBContext.Employees.Where(w => w.IsActive && w.Id == employeeViewModel.Id).SingleOrDefault();
                if (employee is not null)
                {
                    employee.Name = employeeViewModel.Name;
                    employee.Gender = employeeViewModel.Gender;
                    employee.Address = employeeViewModel.Address;
                    employee.BasicSalary = employeeViewModel.BasicSalary;
                    employee.DOB = employeeViewModel.DOB;
                    employee.DOE = employeeViewModel.DOE;
                    employee.DOR = employeeViewModel.DOR;
                    employee.Phone = employeeViewModel.Phone;
                    employee.DepartmentId = employeeViewModel.DepartmentId;
                    employee.PositionId = employeeViewModel.PositionId;
                    //For audit purpose when the record is updated by the user
                    employee.UpdatedAt = DateTime.Now;
                    employee.UpdatedBy = "system";
                    employee.Ip = NetworkHelper.GetIpAddress();
                    _hRMSDBContext.Employees.Update(employee);
                    _hRMSDBContext.SaveChanges();
                    ViewBag.Msg = "Employee record is updated SUCCESSFULLY.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "Error occurs when Employee record is updated.";
            }
            return RedirectToAction("List");
        }
    }
}
