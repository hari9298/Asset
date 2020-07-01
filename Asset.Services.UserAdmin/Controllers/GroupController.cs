using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Abstractions;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Authorization;
using Asset.Model.UserAdmin;
using Asset.Repository.UserAdmin;
using Asset.BO.UserAdmin;
using Asset.DTO.UserAdmin;

namespace Asset.Services.UserAdmin.Controllers
{
    [Produces("application/json")]
    [Route("api/Group")]
    public class GroupController : Controller
    {
        GroupBO groupBO = new GroupBO();
        //FunctionObj cmpobj;


        [HttpGet]
        [Route("List/all")]
        //[BasicAuthenticationFilter]
        //[Authorize("Bearer")]
        public List<GroupDTO> Get()
        {

            var Result = groupBO.GetGroupList();
            var groupDTO = ConvertModelToDto.ConvertGroupListModelToDTO(Result);
            return groupDTO;

        }

        [HttpGet]
        [Route("Role/all")]
        public List<RoleDTO> GetRoles()
        {
            var Result = groupBO.GetRoles();
            var roleDto = ConvertModelToDto.ConvertRoleListModelToDTO(Result);
            return roleDto;

        }
        [HttpGet]
        [Route("viewdata/{id}")]
        public GroupRoleDTO Get(int id)
        {
            var groupRoleDto = new GroupRoleDTO();
            groupBO = new GroupBO(id);
            //var Result = groupsBO.GetGroupwithId(id);
            groupRoleDto.group = ConvertModelToDto.ConvertGroupModelToDTO(groupBO.GroupInfo);
            groupRoleDto.roles = ConvertModelToDto.ConvertRoleListModelToDTO(groupBO.RolesLinkedToGroup);
            return groupRoleDto;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GroupRoleDTO groupDto)
        {
            var groupModel = ConvertDtoToModel.ConvertGroupDtoToGroupModel(groupDto.group);

            var roleModel = ConvertDtoToModel.ConvertRoleListDtoToRoleModel(groupDto.roles);

            groupBO = new GroupBO();
            groupBO.GroupInfo = groupModel;
            groupBO.RolesLinkedToGroup = roleModel;
            var Result = groupBO.Add(groupModel, roleModel);
            await Result;
            var groupRoleDTO = ConvertModelToDto.ConvertGroupRoleModelToDTO((Group)Result.Result[0], (List<Role>)Result.Result[1]);
            if (groupRoleDTO != null)
            {
                return Ok(groupRoleDTO);
            }
            else
            {
                return BadRequest(groupDto);
            }

        }

        [HttpDelete]
        [Route("{GroupId}")]
        public async Task<IActionResult> Delete(int GroupId)
        {

            var Result = await groupBO.Delete(GroupId);
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
        public async Task<IActionResult> Put([FromBody]GroupRoleDTO group)
        {
            //var Result = await groupBO.Update(group);

            var groupModel = ConvertDtoToModel.ConvertGroupDtoToGroupModel(group.group);
            var addRole = group.roles.Where(r => r.ActionRequired.Equals('A'));
            var deleterole = group.roles.Where(r => r.ActionRequired.Equals('D'));

            var AddRoles = ConvertDtoToModel.ConvertRoleListDtoToRoleModel(addRole.ToList());
            var DeleteRoles = ConvertDtoToModel.ConvertRoleListDtoToRoleModel(deleterole.ToList());

            GroupBO groupBO = new GroupBO();

            groupBO.GroupInfo = groupModel;
            var Result = groupBO.UpdateGroupDetails(groupModel, AddRoles, DeleteRoles);

            await Result;
            var groupRoleDTO = ConvertModelToDto.ConvertGroupRoleModelToDTO((Group)Result.Result[0], (List<Role>)Result.Result[1]);
            if (groupRoleDTO != null)
            {
                return Ok(groupRoleDTO);

            }
            else
            {
                return BadRequest(group);
            }
        }

        [HttpGet]
        [Route("all")]
        public List<CommonList> GetGroupDP()
        {
            GroupBO groupBO = new GroupBO();
            var Result = groupBO.GetGroup();

            return Result;
        }


    }

}