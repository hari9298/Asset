using System;
using System.Collections.Generic;

using System.Threading.Tasks;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using Asset.Model.UserAdmin;
using Asset.ORM.Entity.UserAdmin;
using Asset.Framework.Repository;


namespace Asset.Repository.UserAdmin
{
    public class CommonListRepositoy : Repository<TCommonListMaster>
    {
        //public useradminContext _baseDBContext {get;}
  
         public CommonListRepositoy()
        {
           dbContext = new useradminContext ();
        }
        public List<TCommonListMaster> GetAllCommonAsync()
        {
            return  base.GetAllAsync();
          
        }
        public  List<TCommonListMaster> GetCommonByIdAsync(int commonId)
        {
            return base.GetByIdAsync(a => a.ClId == commonId);
           
        }

        public async Task AddCommonList(TCommonListMaster common)
        {
            var cmp = GetCommonByIdAsync(common.ClId);
            if (cmp == null)
            {
                
               
               await base.Add(common);
               
            }

        }

        public async Task  UpdateCommonList(TCommonListMaster common)
        {

          await base.Update(common);
        }

        public async Task DeleteCommonListAsync(TCommonListMaster common)
        {
            var cmp = GetCommonByIdAsync(common.ClId);
            if(cmp != null)
            {
              await  base.Delete(common);
              
           
            }
        }

       }
}