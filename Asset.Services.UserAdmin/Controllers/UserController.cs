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
using Asset.Exceptions.UserAdmin;
using Microsoft.AspNetCore.Identity;

namespace Asset.BO.UserAdmin
{
    [Produces("application/json")]
    [Route("api/User")]
  
    public class UserController : Controller
    {

        //private readonly UserManager<User> _userManager;
        UserAdminBO userAdmin = new UserAdminBO();
    
        //public UserController(UserManager<User> userManager)
        //{
        //    _userManager = userManager;
        //}

        //[HttpGet]
        //public async Task<int> GetCurrentUserId()
        //{
        //    User usr = await GetCurrentUserAsync();
        //    return (int)usr?.UserID;
        //}

        //private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [HttpGet]
       // [Authorize]
        [Route("all")]
     //   [CustomExceptionFilters]
        public List<UserDTO> GetUserList()
        {
          
            var Result = userAdmin.GetList();
            var userDto = ConvertModelToDto.ConvertUserListModelToDto(Result);
            //if(userDto == null)
            //{
            //    throw new BusinessException("custom business exception");
            //}
            return userDto;
          
        }

        [HttpGet]
        [Route("Role/all")]
        public List<RoleDTO> GetRoles()
        {
          //userAdmin = new UserAdminBO();
          var Result = userAdmin.GetRoleList();
          var roleDto = ConvertModelToDto.ConvertRoleListModelToDTO(Result);
          return roleDto;
        }

       [HttpGet]
        [Route("viewdata/{id}")]
        public UserRoleDTO Get(int id)
        {
          
           var userRoleDto = new UserRoleDTO();
            userAdmin = new UserAdminBO(id);
            userRoleDto.user = ConvertModelToDto.ConvertUserModelToDto(userAdmin.UserInfo);
            userRoleDto.roles = ConvertModelToDto.ConvertRoleListModelToDTO(userAdmin.RolesLinkedToUser);
        
            return userRoleDto;
        
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]UserRoleDTO userDto)
        {
  
            var userModel =ConvertDtoToModel.ConvertUserDtoToUserModel(userDto.user);
           
            var roleModel = ConvertDtoToModel.ConvertRoleListDtoToRoleModel(userDto.roles);

            userAdmin = new UserAdminBO();
            userAdmin.UserInfo = userModel;
            userAdmin.RolesLinkedToUser = roleModel; 
            var Result = userAdmin.Add(userModel,roleModel);
            await Result;
            var userRoleDTO =  ConvertModelToDto.ConvertUserRoleModelToDTO((User)Result.Result[0], (List<Role>)Result.Result[1]);
          
          if(userRoleDTO != null)
            {
             return Ok(userRoleDTO);

            }
            else
            {
                return BadRequest(userDto);
            }

         
        }

        [HttpDelete]
        [Route("{UserId}")]
        public async Task<IActionResult> Delete(int UserId)
        {
            userAdmin = new UserAdminBO();

                var Result = await userAdmin.Delete(UserId);
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
        public async Task<IActionResult> Update([FromBody]UserRoleDTO user)
        {
           

            var userModel =ConvertDtoToModel.ConvertUserDtoToUserModel(user.user);
            var addRole = user.roles.Where(r => r.ActionRequired.Equals('A'));
            var deleterole = user.roles.Where(r => r.ActionRequired.Equals('D'));

            var AddRoles = ConvertDtoToModel.ConvertRoleListDtoToRoleModel(addRole.ToList());
            var DeleteRoles = ConvertDtoToModel.ConvertRoleListDtoToRoleModel(deleterole.ToList());

            userAdmin = new UserAdminBO();
            
            userAdmin.UserInfo = userModel;
           // userAdmin.RolesLinkedToUser = AddRoles;
            //userAdmin.RolesLinkedToUser = DeleteRoles;
            var Result =userAdmin.UpdateUserDetails(userModel, AddRoles, DeleteRoles);
 
            await Result;
            var userRoleDTO = ConvertModelToDto.ConvertUserRoleModelToDTO((User)Result.Result[0], (List<Role>)Result.Result[1]);
            if (userRoleDTO != null)
            {
                return Ok(userRoleDTO);

            }
            else
            {
                return BadRequest(user);
            }


        }

        [HttpPut]
        [Route("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody]UserDTO user)
        {
            userAdmin = new UserAdminBO();
            var userModel = ConvertDtoToModel.ConvertUserDtoToUserModel(user);
            var userCredentail = userAdmin.ResetPassword(userModel);
            await userCredentail;
            if (userCredentail != null)
            {
                return Ok(userCredentail);

            }
            else
            {
                return BadRequest(user);
            }
        }
    }

}