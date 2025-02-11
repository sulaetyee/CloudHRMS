using CloudHRMS.DAO;
using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.UnitOfWorks;
using CloudHRMS.Utlitity;

namespace CloudHRMS.Services
{
    public class PositionService : IPositionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PositionService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public PositionViewModel Create(PositionViewModel positionViewModel)
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
                _unitOfWork.PositionRepository.Create(positionEntity);
                _unitOfWork.Commit();
                return positionViewModel;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw new Exception("Error!!");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                PositionEntity position = _unitOfWork.PositionRepository.GetBy(w=> w.Id==id && w.IsActive).SingleOrDefault();
                if (position is not null)
                {
                    position.IsActive = false;
                    _unitOfWork.PositionRepository.Update(position);
                    _unitOfWork.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
            return false;
        }

        public IEnumerable<PositionViewModel> GetAll()
        {
            IList<PositionViewModel> positions = _unitOfWork.PositionRepository.GetAll( w =>w.IsActive).Select(
                s => new PositionViewModel()
                {
                    Id = s.Id,
                    Code = s.Code,
                    Description = s.Description,
                    Level = s.Level
                }).ToList();
            return positions;
        }

        public PositionViewModel GetById(string id)
        {
            PositionViewModel position = _unitOfWork.PositionRepository.GetBy(w => w.IsActive && w.Id == id).Select(s => new PositionViewModel()
            {
                Id = s.Id,
                Code = s.Code,
                Description = s.Description,
                Level = s.Level
            }).SingleOrDefault();
            return position;
        }

        public PositionViewModel Update(PositionViewModel positionViewModel)
        {
            try
            {
                PositionEntity position = _unitOfWork.PositionRepository.GetBy(w => w.IsActive && w.Id == positionViewModel.Id).SingleOrDefault();
                if (position is not null)
                {
                    position.Description = positionViewModel.Description;
                    position.Level = positionViewModel.Level;
                    position.UpdatedBy = "system";
                    position.UpdatedAt = DateTime.Now;
                    position.Ip = NetworkHelper.GetIpAddress();
                }
                _unitOfWork.PositionRepository.Update(position);
                _unitOfWork.Commit();
                return positionViewModel;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception("Error");
            }
        }
    }
}
