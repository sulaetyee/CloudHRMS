using CloudHRMS.Models.ViewModels;

namespace CloudHRMS.Services
{
    public interface IPositionService
    {
        public PositionViewModel Create(PositionViewModel positionViewModel);
        IEnumerable<PositionViewModel> GetAll();
        PositionViewModel GetById(string id);
        public PositionViewModel Update(PositionViewModel positionViewModel);
        bool Delete(string id);
    }
}
