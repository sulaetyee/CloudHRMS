using CloudHRMS.DAO;
using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.Services;
using CloudHRMS.Utlitity;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers {
    public class PositionController : Controller {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService) {
            this._positionService = positionService;
        }
        public IActionResult Entry() {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(PositionViewModel positionViewModel) {
            try {
                _positionService.Create(positionViewModel);
                TempData["Msg"] = "Position record is created successfully.";
            }
            catch (Exception) {
                TempData["Msg"]= "Error occurs when Position record is created.";
            }
            return RedirectToAction("List");
        }
        public IActionResult List() {
            return View(_positionService.GetAll());
        }
        public IActionResult DeletebyId(string id) {
            try {
                _positionService.Delete(id);
                    TempData["Msg"] = "Position record is deleted successfully.";
                
            }
            catch (Exception ex) {
                TempData["Msg"] = "Error occurs when Position record is deleted.";
            }
            return RedirectToAction("List");
        }
        public IActionResult Edit(string Id) {
            
            return View(_positionService.GetById(Id));
        }
        [HttpPost]
        public IActionResult Update(PositionViewModel positionViewModel) {
            try {
                _positionService.Update(positionViewModel);
                TempData["Msg"]= "Position record is updated SUCCESSFULLY.";
            }
            catch (Exception ex) {
                TempData["Msg"] = "Error occurs when Position record is updated.";
            }
            return RedirectToAction("List");
        }

    }
}