using CloudHRMS.DAO;
using CloudHRMS.Models.DataModels;
using CloudHRMS.Repositories.Common;

namespace CloudHRMS.Repositories.Domain
{
    public class PositionRepository : BaseRepository<PositionEntity>, IPositionRepository
    {
        private readonly HRMSDbContext _dbContext;      
        public PositionRepository(HRMSDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
