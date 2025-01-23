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
    }
}
