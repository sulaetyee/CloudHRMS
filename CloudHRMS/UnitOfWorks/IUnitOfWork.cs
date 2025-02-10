using CloudHRMS.Repositories.Domain;

namespace CloudHRMS.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IPositionRepository PositionRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IAttendancePolicyRepository AttendancePolicyRepository { get; }
        IShiftRepository ShiftRepository { get; }
        IShiftAssignRepository ShiftAssignRepository { get; }
        IDailyAttendanceRepository DailyAttendanceRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        //for commit stage (insert,update, delete)
        void Commit();
        void Rollback();
    }
}
