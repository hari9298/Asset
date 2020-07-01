using System;
using System.Collections.Generic;

namespace Asset.DTO.UserAdmin
{
    public class UserRoleDTO
    {
        public UserDTO user {get;set;}

        public List<RoleDTO> roles{get;set;}
    }
}