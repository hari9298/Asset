using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asset.Framework.Repository;
using Asset.ORM.Entity.UserAdmin;
using Asset.Model.UserAdmin;
using Microsoft.EntityFrameworkCore;
using Asset.Repository.Common;
//using LoggerProject.Logger;

namespace Asset.Repository.UserAdmin
{
    public class RoleRepository : Repository<TRoleMaster>,IRoleRepository
    {
      //  private readonly useradminContext _dbContext;
       //private ILog logger;
        public RoleRepository()
        {
               dbContext = new useradminContext ();
            
        }
        public useradminContext GetDBContext()
        {
            return dbContext as useradminContext;
        }
        public RoleRepository(useradminContext  dataBaseContext)
        {
            dbContext =dataBaseContext;
        }

        public async Task<Role> AddRole(Role roleInfo, List<Function> functions)
        {
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var roleResult = RoleMapper.ConvertToRolesFEntity(roleInfo);
            roleResult.RmStatus = (int)RecordStatus.Active;
            roleResult.RmCreatedOn = DateTime.Now;
            await base.Add(roleResult);
            userUnitOfWork.Save();
            int latestRoleid = (int)roleResult.RmId;
            return GetRoleById(latestRoleid);
           

        }
        public async Task<Role> UpdateRole(Role roleInfo, List<Function> functions)
        {
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var roleResult = RoleMapper.ConvertToRolesFEntity(roleInfo);
            roleResult.RmStatus = (int)RecordStatus.Active;
            await base.Update(roleResult);
            userUnitOfWork.Save();
            return GetRoleById((int)roleResult.RmId);
            //  await dbContext.SaveChangesAsync();
        }

        public async Task DeleteRole(int role)
        {
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var getRoleDetail = GetRoleById(role);
            var roleResult = RoleMapper.ConvertToRolesFEntity(getRoleDetail);
            roleResult.RmStatus = (int)RecordStatus.Inactive;
            await base.Update(roleResult);
            userUnitOfWork.Save();
            // return GetUserDetails((int)userResult.UmId);

        }
        public List<Role> GetRolesWithDetails()
        {
          
            var queryRoleM = from rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == 1).Distinct()
                             select new Role
                             {
                                 RoleId = rm.RmId,
                                 RoleDescription = rm.RmDescription,
                                 RoleType = rm.RmType,
                                 RoleName = rm.RmName,
                                 RoleStatus = rm.RmStatus,

                             };
            return (queryRoleM.ToList());

        }
     
        public Role GetRoleById(int roleId)
        {
            var roleById = new Role();
            var role = from rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == 1 && a.RmId == roleId).Distinct()

                      select new Role
                      {
                          RoleId = rm.RmId,
                          RoleDescription = rm.RmDescription,
                          RoleType = rm.RmType,
                          RoleName = rm.RmName,
                          RoleStatus = rm.RmStatus,
                          //CreatedBy = rm.RmCreatedBy,
                          //CreatedOn = rm.RmCreatedOn,
                          RoleModifiedBy = rm.RmModifiedBy,
                          RoleModifiedOn = rm.RmModifiedOn
                      };

            try
            {
                var roleQuery = role.FirstOrDefault();
                var Result = (roleId != 0) ? roleQuery : roleById;
                return Result;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public List<Function> GetFunctionListById(int roleId)
        {
            var rol = from rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == 1 && a.RmId == roleId).Distinct()

                      select new Role
                      {
                          RoleId = rm.RmId,
                          RoleDescription = rm.RmDescription,
                          RoleType = rm.RmType,
                          RoleName = rm.RmName,
                          RoleStatus = rm.RmStatus,

                      };
            var rols = rol.FirstOrDefault();
            var rolwithId =  //from rm in _baseDBContext.Set<TRoleMaster> ().Where (a => a.RmId == 0 &&  a.RmStatus == 0).Distinct()
             new Role
             {
                 RoleId = 0,
                 RoleDescription = "",
                 RoleType = 1,
                 RoleName = "",
                 RoleStatus = 0,

             };
            //var rolswithId = rolwithId;

            var funtwithId = from rfun in dbContext.Set<TRoleFunctionLink>().Where(o => o.RflStatus == 1).Distinct()

                             join fun in dbContext.Set<TFunctionMaster>().Distinct() on rfun.RflFunction equals fun.FmId into rfuns
                             from fl in rfuns.DefaultIfEmpty()
                             select new Function
                             {
                                 FunctionId = fl.FmId,
                                 FunctionName = fl.FmName,
                                 FunctionType = fl.FmType,
                                 FunctionOrder = fl.FmOrder,
                                 FunctionUri = fl.FmUri,
                                 RolefunlId = 0,
                                 RolefunctionlinkAccessKey = 0,
                                 RolefunctionlinkFunction = rfun.RflFunction,
                                 RolefunctionlinkRole = rfun.RflRole,
                                 array = Conversion.ConvertfromNumtoBinaryCharArray(Convert.ToInt32(0))


                             };
            var funtswithId = funtwithId.GroupBy(f => f.FunctionId).Select(o => o.FirstOrDefault()).ToList();
            var queryFunctRId = from tfunM in dbContext.Set<TFunctionMaster>()
                                join trfl in dbContext.Set<TRoleFunctionLink>().Where(o => o.RflRole == roleId && o.RflStatus == 1).Distinct()
                                on tfunM.FmId equals trfl.RflFunction
                                select new Function
                                {
                                    FunctionId = tfunM.FmId,
                                    FunctionName = tfunM.FmName,
                                    FunctionType = tfunM.FmType,
                                    FunctionOrder = tfunM.FmOrder,
                                    FunctionUri = tfunM.FmUri,
                                    RolefunlId = trfl.RflId,
                                    RolefunctionlinkAccessKey = trfl.RflAccessKey,
                                    RolefunctionlinkFunction = trfl.RflFunction,
                                    RolefunctionlinkRole = trfl.RflRole,
                                    array = Conversion.ConvertfromNumtoBinaryCharArray(Convert.ToInt32(trfl.RflAccessKey))
                                };
            var qidList = queryFunctRId.ToList();
            var funt = from fun in dbContext.Set<TFunctionMaster>().Distinct()
                       join rfun in dbContext.Set<TRoleFunctionLink>().Distinct() on fun.FmId equals rfun.RflFunction
                       where !(from tfunM in dbContext.Set<TFunctionMaster>()
                               join trfl in dbContext.Set<TRoleFunctionLink>().Where(o => o.RflRole == roleId && o.RflStatus == 1).Distinct()
                               on tfunM.FmId equals trfl.RflFunction
                               select tfunM.FmId).Contains(fun.FmId)

                       select new Function
                       {
                           FunctionId = fun.FmId,
                           FunctionName = fun.FmName,
                           FunctionType = fun.FmType,
                           FunctionOrder = fun.FmOrder,
                           FunctionUri = fun.FmUri,
                           RolefunlId = rfun.RflId,
                           RolefunctionlinkAccessKey = rfun.RflAccessKey,
                           RolefunctionlinkFunction = rfun.RflFunction,
                           RolefunctionlinkRole = rfun.RflRole,
                           array = Conversion.ConvertfromNumtoBinaryCharArray(Convert.ToInt32(0))


                       };
            // var qexceptfId =  funt.Where(c => !qidList.Contains(new Function {
            //     FunctionId = c.FunctionId}));

            var funexceptrole = funt.GroupBy(f => f.FunctionId);


            var functR = funexceptrole.Select(o => o.FirstOrDefault()).Except(queryFunctRId);
            var functResult = (functR
                              .Union(qidList));
            //var rolesAndfunctions = new RoleFunction
            //{
            //    Roles = (roleId != 0) ? rols : rolwithId,

            //    Funtions = (roleId != 0) ? functResult.ToList() : funtswithId

            //};

            //return (rolesAndfunctions);

            return functResult.ToList();
        }
        //public void UpdateUsersAsync(User userInfo, List<Role> Roles)
        //{
        // var addRole = (from Roles in  item  where actionRequired = 'A' select item).Any();
        //  var DeleteRole = (from Roles in  item  where actionRequired = 'D' select item).Any();

        // var addRolesLinkedToUser =UserMapper.ConvertToUserRolesEntity(userInfo,addRole);
        //   base.AddRange(addRolesLinkedToUser);
        //  var deleteRolesLinkedToUser =UserMapper.ConvertToUserRolesEntity(userInfo,DeleteRole);

        //   base.DeleteRole(deleteRolesLinkedToUser);
        //    dbContext.SaveChanges();
        // }

        // public void AddUsersRole(User userInfo, List<Role> Roles)
        //{

        //    var rolesLinkedToUser =UserMapper.ConvertToUserRolesEntity(userInfo,Roles, (int)actionRequest.insert);
        //      base.AddRange(rolesLinkedToUser);
        //       dbContext.SaveChanges();
        //}


        //   public  void DeleteRole(User userInfo)
        //{

        //   var result =  (dbContext as useradminContext).TUserProfile.Where(x=>x.UpRefId == userInfo.UserID).ToList();

        //    if(result != null)
        //    {
        //       (dbContext as useradminContext).TUserProfile.RemoveRange(result);
        //       dbContext.SaveChangesAsync();
        //    }

        //}

    }
}