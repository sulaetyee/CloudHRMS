using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.UnitOfWorks;
using CloudHRMS.Utlitity;

namespace CloudHRMS.Services
{
    public class ShiftAssignService : IShiftAssignService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShiftAssignService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public void Create(ShiftAssignViewModel entity)
        {
            try
            {
                ShiftAssignEntity shiftAssign = new ShiftAssignEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    EmployeeId = entity.EmployeeId,
                    ShiftId = entity.ShiftId,
                    FromDate = entity.FromDate,
                    ToDate = entity.ToDate,
                    CreatedBy = "system",
                    CreatedAt = DateTime.Now,
                    Ip = NetworkHelper.GetIpAddress(),
                    IsActive = true
                };
                _unitOfWork.ShiftAssignRepository.Create(shiftAssign);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }
        public void Delete(string id)
        {
            try
            {
                ShiftAssignEntity shiftAssignEntity = _unitOfWork.ShiftAssignRepository.GetBy(W => W.IsActive && W.Id == id).SingleOrDefault();
                if (shiftAssignEntity != null)
                {
                    shiftAssignEntity.IsActive = false;
                  
                    shiftAssignEntity.Ip = NetworkHelper.GetIpAddress();
                    _unitOfWork.ShiftAssignRepository.Update(shiftAssignEntity);
                    _unitOfWork.Commit();
                }
            }
            catch
            {
                 _unitOfWork.Rollback();
            }

        }
        public IEnumerable<ShiftAssignViewModel> GetAll()
        {
            IList<ShiftAssignViewModel> shiftAssigns = _unitOfWork.ShiftAssignRepository.GetAll(w => w.IsActive)
                .Select(x => new ShiftAssignViewModel
                {
                    Id = x.Id,
                    EmployeeId = x.EmployeeId,
                    ShiftId = x.ShiftId,
                    FromDate = x.FromDate,
                    ToDate = x.ToDate
                }).ToList();
            return shiftAssigns;
        }
        public ShiftAssignViewModel GetBy(string Id)
        {
            ShiftAssignViewModel shiftAssignViewModel = _unitOfWork.ShiftAssignRepository.GetBy(w => w.IsActive && w.Id == Id).Select(s => new ShiftAssignViewModel
            {
                Id = s.Id,
                EmployeeId = s.EmployeeId,
                ShiftId = s.ShiftId,
                FromDate = s.FromDate,
                ToDate = s.ToDate
            }).SingleOrDefault();
            return shiftAssignViewModel;
        }
        public void Update(ShiftAssignViewModel entity)
        {
            try
            {
                ShiftAssignEntity shiftAssignEntity = _unitOfWork.ShiftAssignRepository.GetBy(w => w.IsActive && w.Id == entity.Id).SingleOrDefault();
                if (shiftAssignEntity != null)
                {
                    shiftAssignEntity.EmployeeId = entity.EmployeeId;
                    shiftAssignEntity.ShiftId = entity.ShiftId;
                    shiftAssignEntity.FromDate = entity.FromDate;
                    shiftAssignEntity.ToDate = entity.ToDate;
                    shiftAssignEntity.UpdatedBy = "system";
                    shiftAssignEntity.UpdatedAt = DateTime.Now;
                    shiftAssignEntity.IsActive = true;
                    shiftAssignEntity.Ip = NetworkHelper.GetIpAddress();
                    _unitOfWork.ShiftAssignRepository.Update(shiftAssignEntity);
                    _unitOfWork.Commit();
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }

    }
}
