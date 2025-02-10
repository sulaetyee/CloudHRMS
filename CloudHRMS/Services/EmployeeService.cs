using CloudHRMS.Models.ReportModels;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void Create(EmployeeViewModel employeeViewModel)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<EmployeeDetailModel> DetailBy(string fromCode, string toCode)
        { 
            return (from e in _unitOfWork.EmployeeRepository.GetAll(w => w.IsActive)
           join p in _unitOfWork.PositionRepository.GetAll(w => w.IsActive) on e.PositionId equals p.Id
           where e.Code.CompareTo(fromCode) >= 0 && e.Code.CompareTo(toCode) <= 0
                  select new EmployeeDetailModel()
                  {
                      Code = e.Code,
                      Name = e.Name,
                      Email = e.Email,
                      Gender = e.Gender,
                      DOB = e.DOB.ToString(),
                      DOE = e.DOE.ToString(),
                      DOR = e.DOR.ToString(),
                      BasicSalary = e.BasicSalary,
                      Phone = e.Phone,
                      Address = e.Address,
                      PositionInfo = p.Code + " / " + p.Description
                  }).AsEnumerable();
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public EmployeeViewModel GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(EmployeeViewModel employeeViewModel)
        {
            throw new NotImplementedException();
        }

        
    }
}
