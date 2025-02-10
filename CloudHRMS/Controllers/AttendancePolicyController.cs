using CloudHRMS.Models.ViewModels;
using CloudHRMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers
{
    public class AttendancePolicyController : Controller
    {
        private readonly IAttendancePolicyServices _attendancePolicyServices;

        public AttendancePolicyController(IAttendancePolicyServices attendancePolicyServices)
        {
            this._attendancePolicyServices = attendancePolicyServices;
        }
        public IActionResult Entry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(AttendancePolicyViewModel attendancePolicyViewModel)
        {
            try
            {
                _attendancePolicyServices.Cerate(attendancePolicyViewModel);
                TempData["Msg"] = "The record of Attendance Policy is created successfully.";
            }
            catch (Exception)
            {
                TempData["Msg"] = "Error occurs when the record of Attendance Policy is created.";
            }
            return RedirectToAction("List");
        }
        public IActionResult List()
        {
            return View(_attendancePolicyServices.GetAll());
        }
        public IActionResult DeletebyId(string id)
        {
            try
            {
                _attendancePolicyServices.Delete(id);
                TempData["Msg"] = "The record of Attendance Policy is deleted successfully.";

            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Error occurs when the record of Attendance Policy is deleted.";
            }
            return RedirectToAction("List");
        }
        public IActionResult Edit(string Id)
        {
            return View(_attendancePolicyServices.GetById(Id));
        }
        [HttpPost]
        public IActionResult Update(AttendancePolicyViewModel attendancePolicyViewModel)
        {
            try
            {
                _attendancePolicyServices.Update(attendancePolicyViewModel);
                ViewBag.Msg = "The record of Attendance Policy is updated SUCCESSFULLY.";
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "Error occurs when The record of Attendance Policy is updated.";
            }
            return RedirectToAction("List");
        }
    }
   
}
