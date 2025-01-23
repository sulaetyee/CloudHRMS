using CloudHRMS.DAO;
using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.Utility;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers
{
    public class PositionController : Controller
    {
        private readonly HRMSDBContext _hRMSDbContext;
        public PositionController(HRMSDBContext hRMSDBContext)
        {
            _hRMSDbContext = hRMSDBContext;
        }
        public IActionResult Entry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(PositionViewModel positionViewModel)
        {
            try
            {
                var positionEntity = new PositionEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = positionViewModel.Code,
                    Description = positionViewModel.Description,
                    Level = positionViewModel.Level,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "system",
                    IsActive = true,
                    Ip = NetworkHelper.GetIpAddress()
                };
                _hRMSDbContext.Positions.Add(positionEntity);
                _hRMSDbContext.SaveChanges();
                ViewBag.Msg = "Position record is created successfully.";
            }
            catch (Exception)
            {
                ViewBag.Msg = "Error occurs when Position record is created.";
            }
            return View();
        }
        public IActionResult List()
        {
            IList<PositionViewModel> positions = _hRMSDbContext.Positions.Where(w => w.IsActive == true).Select(
                s => new PositionViewModel()
                {
                    Id = s.Id,
                    Code = s.Code,
                    Description = s.Description,
                    Level = s.Level
                }).ToList();
            return View(positions);
        }
        public IActionResult DeletebyId(string id)
        {
            try
            {
                PositionEntity position = _hRMSDbContext.Positions.Where(w => w.IsActive && w.Id == id).SingleOrDefault();
                if (position is not null)
                {
                    position.IsActive = false;
                    _hRMSDbContext.Positions.Update(position);
                    _hRMSDbContext.SaveChanges();
                    TempData["Msg"] = "Position record is deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Error occurs when Position record is deleted.";
            }
            return RedirectToAction("List");
        }
    }
}
