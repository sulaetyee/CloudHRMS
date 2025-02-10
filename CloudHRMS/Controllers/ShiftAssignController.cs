using CloudHRMS.Models.ViewModels;
using CloudHRMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers
{
    public class ShiftAssignController : Controller
    {
        private readonly IShiftAssignService _shiftAssignService;

        public ShiftAssignController(IShiftAssignService shiftAssignService)
        {
            this._shiftAssignService = shiftAssignService;
        }
        public IActionResult Entry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(ShiftAssignViewModel shiftAssignViewModel)
        {
            try
            {
                _shiftAssignService.Create(shiftAssignViewModel);
                TempData["Msg"] = "ShiftAssign record is created successfully.";
            }
            catch (Exception)
            {
                TempData["Msg"] = "Error occurs when ShiftAssign record is created.";
            }
            return RedirectToAction("List");
        }
        public IActionResult List()
        {
            return View(_shiftAssignService.GetAll());
        }
        public IActionResult DeletebyId(string id)
        {
            try
            {
                _shiftAssignService.Delete(id);
                TempData["Msg"] = "Position record is deleted successfully.";

            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Error occurs when Position record is deleted.";
            }
            return RedirectToAction("List");
        }
        public IActionResult Edit(string Id)
        {
            return View(_shiftAssignService.GetBy(Id));
        }
        [HttpPost]
        public IActionResult Update(ShiftAssignViewModel shiftAssignViewModel)
        {
            try
            {
                _shiftAssignService.Update(shiftAssignViewModel);
                TempData["Msg"] = "Position record is updated SUCCESSFULLY.";
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Error occurs when Position record is updated.";
            }
            return RedirectToAction("List");
        }
    }
}
