using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Asset.BO.UserAdmin;
using Asset.Model.UserAdmin;
using Asset.DTO.UserAdmin;
using Asset.Services.UserAdmin;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Abstractions;

namespace Asset.BO.UserAdmin
{
    [Produces("application/json")]
    [Route("api/Role")]
    public class RoleController : Controller
    {
        RoleBO roleBO = new RoleBO();

        [HttpGet]
        [Route("all")]
     //   [BasicAuthenticationFilter]
      //  [Authorize("Bearer")]
        public List<RoleDTO> GetList()
        {
           
            var Result = roleBO.GetRoleList();
            var roleDto = ConvertModelToDto.ConvertRoleListModelToDTO(Result);
            return roleDto;
            

        }

        [HttpGet]
        [Route("Function/all")]
        public List<FunctionDTO> GetFunction()
        {
            //   rolesObj = new RolesObj();
            var Result = roleBO.GetFunctionList();
            var functionDto = ConvertModelToDto.FunctionListModelToDTO(Result);

            return functionDto;
        }
        [HttpGet]
        [Route("viewdata/{id}")]
        public RoleFunctionDTO Get(int id)
        {
            // rolesObj = new RolesObj();
            var roleFunctionDto = new RoleFunctionDTO();
            roleBO = new RoleBO(id);
            roleFunctionDto.Roles = ConvertModelToDto.ConvertRoleModelToDTO(roleBO.RoleInfo);
            roleFunctionDto.Funtions = ConvertModelToDto.FunctionListModelToDTO(roleBO.FunctionLinkedToRole);
            return roleFunctionDto;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RoleFunctionDTO role)
        {
            // rolesObj = new RolesObj();
           var  roleModel =  ConvertDtoToModel.ConvertRoleDtoToRoleModel(role.Roles);
            var functionModel = ConvertDtoToModel.FunctionListDtoToModel(role.Funtions);
            roleBO = new RoleBO();
            roleBO.RoleInfo = roleModel;
            roleBO.FunctionLinkedToRole = functionModel;
            var Result = roleBO.Add(roleModel, functionModel);
            await Result;

            var roleFunctionDTO = ConvertModelToDto.ConvertGroupRoleModelToDTO((Role)Result.Result[0], (List<Function>)Result.Result[1]);

            if (roleFunctionDTO != null)
            {
                return Ok(roleFunctionDTO);
            }
            else
            {
                return BadRequest(role);
            }

        }

        [HttpDelete]
        [Route("{RoleId}")]  
        public async Task<IActionResult> Delete(int RoleId)
        {

            roleBO = new RoleBO();
            var Result = await roleBO.Delete(RoleId);
            if (Result != null)
            {
                return Ok(Result);
            }
            else
            {
                return BadRequest(Result);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]RoleFunctionDTO roleFunction)
        {
            //rolesObj = new RolesObj();
            var roleModel = ConvertDtoToModel.ConvertRoleDtoToRoleModel(roleFunction.Roles);
            var functionModel = ConvertDtoToModel.FunctionListDtoToModel(roleFunction.Funtions);

            roleBO = new RoleBO();
            roleBO.RoleInfo = roleModel;
            roleBO.FunctionLinkedToRole = functionModel;

            var Result = roleBO.UpdateRoleFunction(roleModel, functionModel);

            await Result;

            var roleFunctionDTO = ConvertModelToDto.ConvertGroupRoleModelToDTO((Role)Result.Result[0], (List<Function>)Result.Result[1]);

            if (roleFunctionDTO != null)
            {
                return Ok(roleFunctionDTO);
            }
            else
            {
                return BadRequest(roleFunction);
            }
        }
    }

}