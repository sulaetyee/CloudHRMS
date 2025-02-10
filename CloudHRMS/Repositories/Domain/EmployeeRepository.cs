using CloudHRMS.DAO;
using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ReportModels;
using CloudHRMS.Repositories.Common;

namespace CloudHRMS.Repositories.Domain
{
    public class EmployeeRepository : BaseRepository<EmployeeEntity>, IEmployeeRepository
    {
        private readonly HRMSDbContext _dbContext;
        public EmployeeRepository(HRMSDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        
    }
    
}
