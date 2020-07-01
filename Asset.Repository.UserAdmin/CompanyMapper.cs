using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Asset.Framework.Repository;
using Asset.ORM.Entity.UserAdmin;
using Asset.Model.UserAdmin;

namespace Asset.Repository.UserAdmin
{
    public static class CompanyMapper
    {
        //TUserMaster destinationUsr ;
        public static TEn ConvertToEntity<TEn, T>(T classAdmin) where T : class
        {
            object value = classAdmin;
            return (TEn)Convert.ChangeType(value, typeof(TEn));

        }


        public static Company ConvertToCmpModel(this TCompanyMaster cmp)
        {
            return new Company
            {
                CompanyId = cmp.CmId,
                CompanyName = cmp.CmName,
                CompanyParentComp = cmp.CmParentComp,
                CompanyPrimaryContact = cmp.CmPrimaryContact,
                CompanyWebsite = cmp.CmWebsite,
                CompanyType = cmp.CmType,
                CompanyBusinessType = cmp.CmBusinessType,
                CompanyModifiedOn = cmp.CmModifiedOn,
                CompanyModifiedBy = cmp.CmModifiedBy,
                CompanyStatus = cmp.CmStatus
               

            };
        }

        public static List<Company> ConvertToCmpModelList(this List<TCompanyMaster> cmps)
        {
            return cmps.Select(cmp => cmp.ConvertToCmpModel()).ToList();
        }

        public static TCompanyMaster ConvertToCmpEntity(this Company cmp)
        {
            return new TCompanyMaster
            {
                CmId = Convert.ToInt32(cmp.CompanyId),
                CmName = cmp.CompanyName,
                CmParentComp = cmp.CompanyParentComp,
                CmPrimaryContact = cmp.CompanyPrimaryContact,
                CmWebsite = cmp.CompanyWebsite,
                CmType = cmp.CompanyType,
                CmBusinessType = cmp.CompanyBusinessType,
                CmModifiedOn = cmp.CompanyModifiedOn,
                CmModifiedBy = cmp.CompanyModifiedBy,
                CmStatus = cmp.CompanyStatus
               
               
            };
        }
        public static List<TCompanyMaster> ConvertToCompanyEntityList(this List<Company> cmps)
        {
            return cmps.Select(usr => usr.ConvertToCmpEntity()).ToList();

        }
    }


}