using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asset.Framework.Repository;
using Asset.ORM.Entity.UserAdmin;
using Asset.Model.UserAdmin;
using Microsoft.EntityFrameworkCore;
using Asset.Repository.Common;

namespace Asset.Repository.UserAdmin
{
   public class FunctionsLinkedToRoleRepository : Repository<TRoleFunctionLink>, IFunctionsLinkedToRoleRepository
    {
        // FunctionRepository functionRepository = new FunctionRepository();

        RoleRepository roleRepository = new RoleRepository();
        public FunctionsLinkedToRoleRepository()
        {
            dbContext = new useradminContext();
          
        }


        public FunctionsLinkedToRoleRepository(DbContext databaseContext)
        {
            dbContext = databaseContext;
        }
        public async Task<List<Function>> AddRoleFunctions(Role roleInfo, List<Function> functions)
        {

            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var rolesLinkedToUser = RoleMapper.ConvertToRolesfunEntity(roleInfo, functions, (int)actionRequest.insert);
            for (int i = 0; i < functions.Count; i++)
            {
                functions[i].canView = functions[i].array[0].ToString() == "1" ? true : false;
                functions[i].canAdd = functions[i].array[1].ToString() == "1" ? true : false;
                functions[i].canUpdate = functions[i].array[2].ToString() == "1" ? true : false;
                functions[i].canDelete = functions[i].array[3].ToString() == "1" ? true : false;
            }
            await base.AddRange(rolesLinkedToUser);
            userUnitOfWork.Save();
            return roleRepository.GetFunctionListById((int)roleInfo.RoleId);
        }

        public async Task<List<Function>> UpdateRolesFunctions(Role roleInfo, List<Function> functions)
        {

            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var rolesLinkedToUser = RoleMapper.ConvertToRolesfunEntity(roleInfo, functions, (int)actionRequest.edit);
            await base.UpdateRange(rolesLinkedToUser);
            userUnitOfWork.Save();
            return roleRepository.GetFunctionListById((int)roleInfo.RoleId);
        }
        public async Task DeleteRoleFunctions(int roleId)
        {

            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var getRoleDetail = roleRepository.GetRoleById(roleId); 
            var getRoleFunctionDetail = roleRepository.GetFunctionListById(roleId);
            // var deleteRole= getRolesDetail.Where(r => r.CheckRole == true).Select(u => { u.CheckRole = false; return u; }).ToList();
            var userResult = RoleMapper.ConvertToRolesfunEntity(getRoleDetail, getRoleFunctionDetail, (int)actionRequest.delete);

            await base.UpdateRange(userResult);
            userUnitOfWork.Save();

        }
        //public List<Function> GetFunctionListById(int roleId)
        //{
        //    var rol = from rm in dbContext.Set<TRoleMaster>().Where(a => a.RmStatus == 1 && a.RmId == roleId).Distinct()

        //              select new Role
        //              {
        //                  RoleId = rm.RmId,
        //                  RoleDescription = rm.RmDescription,
        //                  RoleType = rm.RmType,
        //                  RoleName = rm.RmName,
        //                  RoleStatus = rm.RmStatus,

        //              };
        //    var rols = rol.FirstOrDefault();
        //    var rolwithId =  //from rm in _baseDBContext.Set<TRoleMaster> ().Where (a => a.RmId == 0 &&  a.RmStatus == 0).Distinct()
        //     new Role
        //     {
        //         RoleId = 0,
        //         RoleDescription = "",
        //         RoleType = 1,
        //         RoleName = "",
        //         RoleStatus = 0,

        //     };
        //    //var rolswithId = rolwithId;

        //    var funtwithId = from rfun in dbContext.Set<TRoleFunctionLink>().Where(o => o.RflStatus == 1).Distinct()

        //                     join fun in dbContext.Set<TFunctionMaster>().Distinct() on rfun.RflFunction equals fun.FmId into rfuns
        //                     from fl in rfuns.DefaultIfEmpty()
        //                     select new Function
        //                     {
        //                         FunctionId = fl.FmId,
        //                         FunctionName = fl.FmName,
        //                         FunctionType = fl.FmType,
        //                         FunctionOrder = fl.FmOrder,
        //                         FunctionUri = fl.FmUri,
        //                         RolefunlId = 0,
        //                         RolefunctionlinkAccessKey = 0,
        //                         RolefunctionlinkFunction = rfun.RflFunction,
        //                         RolefunctionlinkRole = rfun.RflRole,
        //                         array = Conversion.ConvertfromNumtoBinaryCharArray(Convert.ToInt32(0))


        //                     };
        //    var funtswithId = funtwithId.GroupBy(f => f.FunctionId).Select(o => o.FirstOrDefault()).ToList();
        //    var queryFunctRId = from tfunM in dbContext.Set<TFunctionMaster>()
        //                        join trfl in dbContext.Set<TRoleFunctionLink>().Where(o => o.RflRole == roleId && o.RflStatus == 1).Distinct()
        //                        on tfunM.FmId equals trfl.RflFunction
        //                        select new Function
        //                        {
        //                            FunctionId = tfunM.FmId,
        //                            FunctionName = tfunM.FmName,
        //                            FunctionType = tfunM.FmType,
        //                            FunctionOrder = tfunM.FmOrder,
        //                            FunctionUri = tfunM.FmUri,
        //                            RolefunlId = trfl.RflId,
        //                            RolefunctionlinkAccessKey = trfl.RflAccessKey,
        //                            RolefunctionlinkFunction = trfl.RflFunction,
        //                            RolefunctionlinkRole = trfl.RflRole,
        //                            array = Conversion.ConvertfromNumtoBinaryCharArray(Convert.ToInt32(trfl.RflAccessKey))
        //                        };
        //    var qidList = queryFunctRId.ToList();
        //    var funt = from fun in dbContext.Set<TFunctionMaster>().Distinct()
        //               join rfun in dbContext.Set<TRoleFunctionLink>().Distinct() on fun.FmId equals rfun.RflFunction
        //               where !(from tfunM in dbContext.Set<TFunctionMaster>()
        //                       join trfl in dbContext.Set<TRoleFunctionLink>().Where(o => o.RflRole == roleId && o.RflStatus == 1).Distinct()
        //                       on tfunM.FmId equals trfl.RflFunction
        //                       select tfunM.FmId).Contains(fun.FmId)

        //               select new Function
        //               {
        //                   FunctionId = fun.FmId,
        //                   FunctionName = fun.FmName,
        //                   FunctionType = fun.FmType,
        //                   FunctionOrder = fun.FmOrder,
        //                   FunctionUri = fun.FmUri,
        //                   RolefunlId = rfun.RflId,
        //                   RolefunctionlinkAccessKey = rfun.RflAccessKey,
        //                   RolefunctionlinkFunction = rfun.RflFunction,
        //                   RolefunctionlinkRole = rfun.RflRole,
        //                   array = Conversion.ConvertfromNumtoBinaryCharArray(Convert.ToInt32(0))


        //               };
        //    // var qexceptfId =  funt.Where(c => !qidList.Contains(new Function {
        //    //     FunctionId = c.FunctionId}));

        //    var funexceptrole = funt.GroupBy(f => f.FunctionId);


        //    var functR = funexceptrole.Select(o => o.FirstOrDefault()).Except(queryFunctRId);
        //    var functResult = (functR
        //                      .Union(qidList));
        //    //var rolesAndfunctions = new RoleFunction
        //    //{
        //    //    Roles = (roleId != 0) ? rols : rolwithId,

        //    //    Funtions = (roleId != 0) ? functResult.ToList() : funtswithId

        //    //};

        //    //return (rolesAndfunctions);

        //    return functResult.ToList();
        //}
    }
}
