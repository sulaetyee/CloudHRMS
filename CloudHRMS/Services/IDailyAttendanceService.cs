﻿using CloudHRMS.Models.ViewModels;

namespace CloudHRMS.Services
{
    public interface IDailyAttendanceService
    {
        void Create(DailyAttendanceViewModel entity);
        IEnumerable<DailyAttendanceViewModel> GetAll();
        DailyAttendanceViewModel GetBy(string Id);
        void Update(DailyAttendanceViewModel entity);
        void Delete(string id);
        public IList<EmployeeViewModel> GetEmployeeList(string departmentId);
        public IList<DepartmentViewModel> GetDepartments();
    }
}
