using System;
using System.Collections.Generic;

namespace Asset.DTO.UserAdmin
{
    public class GroupRoleDTO
    {
        public GroupDTO group {get;set;}

        public List<RoleDTO> roles{get;set;}
    }
}