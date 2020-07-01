using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Asset.Model.UserAdmin;
using Asset.ORM.Entity.UserAdmin;
using Asset.Framework.Repository;

namespace Asset.Repository.UserAdmin
{
    public class CompanyRepository : Repository<TCompanyMaster>, ICompanyRepository
    {

        
        public CompanyRepository()
        {
           dbContext = new useradminContext ();
        }

        public List<TCompanyMaster> GetAllCompanyAsync()
        {
            return  base.GetAllAsync();
          
        }

        public  List<TCompanyMaster> GetCompanyByIdAsync(int userId)
        {
            return base.GetByIdAsync(a => a.CmId == userId);
           
        }

        public async Task AddCompany(TCompanyMaster companies)
        {
            var cmp = GetCompanyByIdAsync(companies.CmId);
            if (cmp == null)
            {
                
               
               await base.Add(companies);
               
            }

        }

        public async Task  UpdateCompanyAsync(TCompanyMaster companies)
        {

          await base.Update(companies);
        }

        public async Task DeleteCompanyAsync(TCompanyMaster companies)
        {
            var cmp = GetCompanyByIdAsync(companies.CmId);
            if(cmp != null)
            {
              await  base.Delete(companies);
              
           
            }
        }

     }
}