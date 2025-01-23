using CloudHRMS.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CloudHRMS.DAO
{
    public class HRMSDBContext :DbContext
    {
        public HRMSDBContext(DbContextOptions<HRMSDBContext> db) : base(db) { }
        //has a relationship for all of entities as DBset
        //all the created db table entity have to be declared in here and declared names should be in plural form eg;Eployees
        public DbSet<EmployeeEntity> Employees { get; set; } 
        public DbSet<PositionEntity> Positions { get; set; }
    }
}
