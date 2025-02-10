using CloudHRMS.Models.ViewModels;

namespace CloudHRMS.Services
{
    public interface IAttendancePolicyServices
    {
        void Cerate(AttendancePolicyViewModel attendancePolicyViewModel);
        IEnumerable<AttendancePolicyViewModel> GetAll();
        AttendancePolicyViewModel GetById(string id);
        void Update(AttendancePolicyViewModel attendancePolicyViewModel);
        bool Delete(string id);
    }
}
