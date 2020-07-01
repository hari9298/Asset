using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asset.Framework.Repository;
using Asset.ORM.Entity.UserAdmin;
using Asset.Model.UserAdmin;

using Microsoft.EntityFrameworkCore;

namespace Asset.Repository.UserAdmin
{
    public class FunctionRepository : Repository<TFunctionMaster>, IFunctionRepository {

        public FunctionRepository()
        {
            dbContext = new useradminContext();
            // userRepository = new UserRepository();

        }

        public FunctionRepository(DbContext databaseContext)
        {
            dbContext = databaseContext;
        }

        public useradminContext _baseDBContext { get;set; }


            public List<Menu> GetMenuListForUser () {
               _baseDBContext = new useradminContext ();
            var menulist = (from fm in _baseDBContext.Set<TFunctionMaster> ().Distinct ()
            
            select new Menu {
            Id = fm.FmId,
            Name = fm.FmName,
            URI = fm.FmUri,
            ParentId = Convert.ToInt32(fm.FmType),
            MenuImagePath = fm.MenuImagePath
            });
          
            return ((menulist.GroupBy (f => f.Id).Select (o => o.FirstOrDefault ())).ToList ());

        }

        public List<Menu> GetMenuListForUser (String User) {
             string stringUser = String.Format("\"{0}\"", User);
             _baseDBContext = new useradminContext ();
            var menulist = (from fm in _baseDBContext.Set<TFunctionMaster> ().Distinct ()
            join trfl in _baseDBContext.Set<TRoleFunctionLink> () on fm.FmId equals trfl.RflFunction
            join tup in _baseDBContext.Set<TUserProfile> ().Where (t => t.UpRefType == 1 ||  t.UpRefType == 2 && t.UpStatus == 1) on trfl.RflRole equals tup.UpRoleId
            join um in _baseDBContext.Set<TUserMaster> ().Where(u =>  u.UmStatus == 1) on tup.UpRefId equals um.UmId
         
            select new Menu {
            Id = fm.FmId,
            Name = fm.FmName,
            URI = fm.FmUri,
            ParentId = Convert.ToInt32(fm.FmType),
            loginName = um.UmLogin
            }).Where(q => q.loginName.Equals(User));
          
            return ((menulist.GroupBy (f => f.Id).Select (o => o.FirstOrDefault ())).ToList ());

        }

          public List<Function> GetFunctionsWithDetails()
        {
          //  _baseDBContext = new useradminContext();

            var funt = from tfunM in dbContext.Set<TFunctionMaster>().Where(a => a.FmStatus == 1).Distinct()

                       select new Function
                       {
                           FunctionId = tfunM.FmId,
                           FunctionName = tfunM.FmName,
                           FunctionType = tfunM.FmType,
                           FunctionOrder = tfunM.FmOrder,
                           FunctionUri = tfunM.FmUri,
                           RolefunlId = 0,
                           RolefunctionlinkAccessKey = 0,
                           RolefunctionlinkFunction = tfunM.FmId,
                           RolefunctionlinkRole = 0,
                           array = Conversion.ConvertfromNumtoBinaryCharArray(Convert.ToInt32(0))

                       };


            return (funt.GroupBy(f => f.FunctionId).Select(o => o.FirstOrDefault()).ToList());

        }

       

    }
}