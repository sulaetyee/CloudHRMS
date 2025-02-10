using CloudHRMS.Models.ReportModels;
using CloudHRMS.Models.ViewModels;

namespace CloudHRMS.Services
{
    public interface IEmployeeService
    {
        void Create(EmployeeViewModel employeeViewModel);
        IEnumerable<EmployeeViewModel> GetAll();
        EmployeeViewModel GetById(string id);
        void Update(EmployeeViewModel employeeViewModel);
        bool Delete(string id);
        public IEnumerable<EmployeeDetailModel> DetailBy(string fromCode, string toCode);
    }
}
