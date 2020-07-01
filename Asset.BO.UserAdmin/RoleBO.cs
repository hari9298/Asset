using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asset.Repository.UserAdmin;
using Asset.Model.UserAdmin;
using Asset.DTO.UserAdmin;
using Asset.ORM.Entity.UserAdmin;
using Asset.Framework.Repository;
//using Microsoft.AspNetCore.Mvc;
//using Asset.Services.UserAdmin.Models;
//using CoreApi.Repositories;
//using CoreApi.Entities;
//using CoreApi.Mapper;
//using CoreApi.Utilities;
//using Microsoft.EntityFrameworkCore;
//using Asset.Services.UserAdmin.Mapper;

namespace Asset.BO.UserAdmin
{
    public  class RoleBO
    {
      // useradminContext dbcontext;
        RoleRepository roleRepository ;

        FunctionsLinkedToRoleRepository functionsLinkedToRoleRepository;

       

        public Role RoleInfo { get; set; }
        public List<Function> FunctionLinkedToRole { get; set; }
        public RoleBO()
        {
            roleRepository = new RoleRepository();
            functionsLinkedToRoleRepository = new FunctionsLinkedToRoleRepository(roleRepository.GetDBContext());
        }
        public RoleBO(int roleId)
        {
            roleRepository = new RoleRepository();
            RoleInfo = GetRoleData(roleId);
            FunctionLinkedToRole = GetFunctionRole(roleId);
        }
        public List<Role> GetRoleList()
        {
            var Result = roleRepository.GetRolesWithDetails();
            return Result;
              
        }
        public Role GetRoleData(int roleId)
        {
            var roleEntity = roleRepository.GetRoleById(roleId);
            try
            {
                return roleEntity;
            }
            catch(Exception e)
            {
                throw (e);
            }
        }
        public List<Function> GetFunctionRole(int roleId)
        {
           
            var Result = roleRepository.GetFunctionListById(roleId);
            for (int i = 0; i < Result.Count; i++)
            {
                Result[i].canView = Result[i].array[0].ToString() == "1" ? true : false;
                Result[i].canAdd = Result[i].array[1].ToString() == "1" ? true : false;
                Result[i].canUpdate = Result[i].array[2].ToString() == "1" ? true : false;
                Result[i].canDelete = Result[i].array[3].ToString() == "1" ? true : false;
            }
            return Result;

        }
        //public List<Role> GetRoleList()
        //{
        //    dbcontext = new useradminContext();
        //    var rol = new RoleRepository(dbcontext);
        //    // var Result = RoleDTO.ConvertToDTORolList(rol.GetRolesWithDetails(dbcontext));
        //    //List<Role>
        //    //return Result.ToList();
        //}
        public List<Function> GetFunctionList()
        {
            // dbcontext = new useradminContext();
            // var rol = new RoleRepository(dbcontext);
            // var Result = RoleDTO.ConvertToDTOFunList(rol.GetFunctionsWithDetails(dbcontext));
            FunctionRepository functionRepository = new FunctionRepository();
            var Result = functionRepository.GetFunctionsWithDetails();
            return Result.ToList();
            // return UserMapper.ConvertToUserModelList(Result);
        }
        public async Task<List<object>> Add(Role roleInfo, List<Function> functions)
        {
            List<object> roleFunctions = new List<object>();
            var currentRole = await roleRepository.AddRole(roleInfo, functions);
            var RoleFunctions = await functionsLinkedToRoleRepository.AddRoleFunctions(currentRole, functions);
            for (int i = 0; i < RoleFunctions.Count; i++)
            {
                RoleFunctions[i].canView = RoleFunctions[i].array[0].ToString() == "1" ? true : false;
                RoleFunctions[i].canAdd = RoleFunctions[i].array[1].ToString() == "1" ? true : false;
                RoleFunctions[i].canUpdate = RoleFunctions[i].array[2].ToString() == "1" ? true : false;
                RoleFunctions[i].canDelete = RoleFunctions[i].array[3].ToString() == "1" ? true : false;
            }
            roleFunctions.Add(currentRole);
            roleFunctions.Add(RoleFunctions);
            return roleFunctions;

        }
        public async Task<List<object>> UpdateRoleFunction(Role roleInfo, List<Function> Functions)
        {
            List<object> roleFunctions = new List<object>();
            var role = await roleRepository.UpdateRole(roleInfo, Functions);
            var RoleFunctions = await functionsLinkedToRoleRepository.UpdateRolesFunctions(role, Functions);
            for (int i = 0; i < RoleFunctions.Count; i++)
            {
                RoleFunctions[i].canView = RoleFunctions[i].array[0].ToString() == "1" ? true : false;
                RoleFunctions[i].canAdd = RoleFunctions[i].array[1].ToString() == "1" ? true : false;
                RoleFunctions[i].canUpdate = RoleFunctions[i].array[2].ToString() == "1" ? true : false;
                RoleFunctions[i].canDelete = RoleFunctions[i].array[3].ToString() == "1" ? true : false;
            }
            roleFunctions.Add(role);
            roleFunctions.Add(RoleFunctions);
            return roleFunctions;

        }
        public async Task<Role> Delete(int roleId)
        {

            var getRoleDetail = roleRepository.GetRoleById(roleId);
            if (getRoleDetail != null)
            {
              // var roleFunctions = functionsLinkedToRoleRepository.DeleteRoleFunctions(roleId);
                //for (int i = 0; i < roleFunctions.Count; i++)
                //{
                //    funt[i].canView = funt[i].array[0].ToString() == "1" ? true : false;
                //    funt[i].canAdd = funt[i].array[1].ToString() == "1" ? true : false;
                //    funt[i].canUpdate = funt[i].array[2].ToString() == "1" ? true : false;
                //    funt[i].canDelete = funt[i].array[3].ToString() == "1" ? true : false;
                //}
                await functionsLinkedToRoleRepository.DeleteRoleFunctions(roleId);
                await roleRepository.DeleteRole(roleId);
            }
            return getRoleDetail;

        }
        // public RoleFunction GetRoleFunctionAll()
        //{
        //    dbcontext = new useradminContext();
        //    var rol = new RoleRepository(dbcontext);
        //    var Result = RoleDTO.ConvertToDTORole(rol.GetRolesWithFunctions(dbcontext));
        //    return Result;
        //    // return UserMapper.ConvertToUserModelList(Result);
        //}
        //public RoleFunction GetRolewithId(int roleId)
        //{
        //   // dbcontext = new useradminContext();
        //    var rol = new RoleRepository(dbcontext);
        //    var Result = RoleDTO.ConvertToDTORole(rol.GetRoleByIdAsync(id));
        //    var funt = Result.Funtions;
        //    for (int i = 0; i < funt.Count; i++)
        //    {
        //        funt[i].canView = funt[i].array[0].ToString() == "1" ? true : false;
        //        funt[i].canAdd = funt[i].array[1].ToString() == "1" ? true : false;
        //        funt[i].canUpdate = funt[i].array[2].ToString() == "1" ? true : false;
        //        funt[i].canDelete = funt[i].array[3].ToString() == "1" ? true : false;
        //    }

        //    return Result;
        //}
        //public async Task<RoleFunction> PostRoles(RoleFunction role)
        //{
        //    dbcontext = new useradminContext();
        //    var rol = new RoleRepository(dbcontext);

        //    // if(role.RoleId == null)
        //    // {

        //    var roles = RoleDTO.ConvertToDTORoleEntity(role);
        //    var roleResult = RoleMapper.ConvertToRolesFEntity(roles);
        //    var roleFunLResult = RoleMapper.ConvertToRolesfunEntity(roles);
        //   // var roleFunctionmaster = RoleMapper.ConvertToFunctionsEntity(role);
        //    //roleFunLResult.RflAccessKey = Conversions.ConvertBinaryStringtoInt(Convert.ToBoolean(role.Funtions[0].canView), Convert.ToBoolean(role.Funtions[0].canAdd), Convert.ToBoolean(roles.Funtions[0].canUpdate), Convert.ToBoolean(role.Funtions[0].canDelete));
        //    await rol.AddRolesWithAllEntities(roleResult, roleFunLResult);
        //    var Result = RoleDTO.ConvertToDTORole(rol.GetRolesWithFunctions(dbcontext));
        //    var funt = Result.Funtions;
        //    for (int i = 0; i < funt.Count; i++)
        //    {
        //        funt[i].canView = funt[i].array[0].ToString() == "1" ? true : false;
        //        funt[i].canAdd = funt[i].array[1].ToString() == "1" ? true : false;
        //        funt[i].canUpdate = funt[i].array[2].ToString() == "1" ? true : false;
        //        funt[i].canDelete = funt[i].array[3].ToString() == "1" ? true : false;
        //    }
        //    return Result;
        //    // }
        //    // return BadRequest("Error:Roles and its details not added");
        //}
        //public  async Task<RoleFunction> PutRoles(RoleFunction role)
        //{

        //    dbcontext = new useradminContext();
        //    var rol = new RoleRepository(dbcontext);

        //   var Result = rol.GetRoleByIdAsync(Convert.ToInt32(role.Roles.RoleId));

        //    if (Result != null)
        //    {
        //        var roles = RoleDTO.ConvertToDTORoleEntity(role);
        //        var roleResult = RoleMapper.ConvertToRolesFEntity(roles);
        //        var roleFunLResult = RoleMapper.ConvertToRolesfunEntity(roles);
        //       // roleFunLResult.RflAccessKey = Conversions.ConvertBinaryStringtoInt(role.Funtions[0].canView, role.Funtions[0].canAdd, role.Funtions[0].canUpdate, role.Funtions[0].canDelete);
        //        await rol.UpdateRolesWithAllEntities(roleResult, roleFunLResult);
        //        var RResult =  RoleDTO.ConvertToDTORole(rol.GetRoleByIdAsync(Convert.ToInt32(role.Roles.RoleId)));
        //        var funt = RResult.Funtions;
        //    for (int i = 0; i < funt.Count; i++)
        //    {
        //        funt[i].canView = funt[i].array[0].ToString() == "1" ? true : false;
        //        funt[i].canAdd = funt[i].array[1].ToString() == "1" ? true : false;
        //        funt[i].canUpdate = funt[i].array[2].ToString() == "1" ? true : false;
        //        funt[i].canDelete = funt[i].array[3].ToString() == "1" ? true : false;
        //    }
        //        return RResult;

        //    }
        //    return null;
        //}

        // public async Task<RoleFunction> DeleteRoles(int roleId)
        //{

        //   dbcontext = new useradminContext();
        //    var rol = new RoleRepository(dbcontext);
        //    var role = rol.GetRoleByIdAsync(Convert.ToInt32(roleId));

        //     if (role != null)
        //    {
        //         //var Result = RoleDTO.ConvertToDTORoleEntity(role);
        //        var roleResult = RoleMapper.ConvertToRolesFEntity(role);
        //        var roleFunLResult = RoleMapper.ConvertToRolesfunEntity(role);


        //        await rol.DeleteRolesWithAllEntities(roleResult, roleFunLResult);
        //        var RResult = RoleDTO.ConvertToDTORole(role);
        //        var funt = RResult.Funtions;

        //    for (int i = 0; i < funt.Count; i++)
        //    {
        //        funt[i].canView = funt[i].array[0].ToString() == "1" ? true : false;
        //        funt[i].canAdd = funt[i].array[1].ToString() == "1" ? true : false;
        //        funt[i].canUpdate = funt[i].array[2].ToString() == "1" ? true : false;
        //        funt[i].canDelete = funt[i].array[3].ToString() == "1" ? true : false;
        //    }

        //        return RResult;

        //    }
        //    return null;
        //}



    }
}