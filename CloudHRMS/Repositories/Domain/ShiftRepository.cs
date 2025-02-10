﻿using CloudHRMS.DAO;
using CloudHRMS.Models.DataModels;
using CloudHRMS.Repositories.Common;

namespace CloudHRMS.Repositories.Domain
{
    public class ShiftRepository : BaseRepository<ShiftEntity>, IShiftRepository
    {
        private readonly HRMSDbContext _hRMSDBContext;
        public ShiftRepository(HRMSDbContext hRMSDBContext) : base(hRMSDBContext)
        {
        }
    }
}
