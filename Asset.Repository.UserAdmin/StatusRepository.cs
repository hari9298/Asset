using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Asset.Framework.Repository;
using Asset.ORM.Entity.UserAdmin;



namespace Asset.Repository.UserAdmin
{
    public class StatusRepository : Repository<TStatusMaster>, IStatusRepository
    {

        public List<TStatusMaster> GetAllStatusAsync()
        {
            return  base.GetAllAsync();
           
        }
}
}